// TO DEBUG, DEFINE DEBUG

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Diagnostics;
using System.Globalization;


namespace OBP
{
    class SalesForceEmail
    {
        private Outlook.MailItem sfdcMail;
        private Outlook.MailItem originalEmail;
        private Outlook.MailItem replyEmail;

        private bool firstQuestion;

        private string fromAddress;
        private string ccAddress;
        private string bccAddress;

        private string body;
        private string subject;
        private string idNumber;
        private string questionSubject;
        private string questionSubjectFollowUp;
        private string toAddress;
        private string customerName;
        private string refCode;
        private string questionContent;
        private string consultantName;
        private string templatePath;
        private DateTime sentDateFollowUp;

        public Outlook.MailItem OriginalEmail
        {
            get { return originalEmail; }
            set { originalEmail = value; }
        }
        public Outlook.MailItem ReplyEmail
        {
            get { return replyEmail; }
            set { replyEmail = value; }
        }
        public Outlook.MailItem SfdcMail
        {
            get { return sfdcMail; }
            set { sfdcMail = value; }
        }
        #region Constructors
        public SalesForceEmail()
        {
            sfdcMail = null;
            // Initialize variables to empty strings
            body = sfdcMail.Body;
            subject = sfdcMail.Subject;
            idNumber = "";
            questionSubject = "";
            toAddress = "";
            customerName = "";
            refCode = "";
            questionContent = "";
            firstQuestion = true;
        }
        public SalesForceEmail(Outlook.MailItem mI)
        {
            sfdcMail = mI;
            // Initialize variables to empty strings
            mI.UnRead = false;
            body = sfdcMail.Body;
            subject = sfdcMail.Subject;
            idNumber = "";
            questionSubject = "";
            toAddress = "";
            customerName = "";
            refCode = "";
            questionContent = "";
            #region Parse selected email
            // Check which kind of email is selected in Outlook and start parsing
            if (subject.Contains("You Have Been Assigned A Support Case"))
            {   // First question
                firstQuestion = true;
                Dictionary<string, string> dict = GetInformationFromFirstQuestion(sfdcMail);
                idNumber = dict["idNumber"];
                questionSubject = dict["questionSubject"];
                toAddress = dict["toAddress"];
                customerName = dict["customerName"];
                refCode = dict["refCode"];
                questionContent = dict["questionContent"];
            }
            else if (subject.Contains("New case email notification. Case number"))
            {   // Follow-up
                firstQuestion = false;
                Dictionary<string, string> dict = GetInformationFromReply(sfdcMail);
                sentDateFollowUp = GetDateFromReply(sfdcMail);
                idNumber = dict["idNumber"];
                questionSubject = dict["questionSubject"];
                questionSubjectFollowUp = dict["questionSubjectFollowUp"];
                toAddress = dict["toAddress"];
                customerName = dict["customerName"];
                refCode = dict["refCode"];
                questionContent = dict["questionContent"];
            }
            else
            {
                throw new ArgumentException("Wrong email format detected. Please select an email from Salesforce.com with a subject containing one of the following sentences:"
                    + Environment.NewLine + "-\tYou Have Been Assigned A Support Case"
                    + Environment.NewLine + "-\tNew case email notification");
            }
            #endregion
        }
        #endregion

        internal void NewReply(string language)
        {
            // Create new reply
            templatePath = OBPGlobals.templatePathFromLanguage(language);
            consultantName = OBPGlobals.consultantName;
            fromAddress = OBPGlobals.fromAddressFromLanguage(language);
            bccAddress = OBPGlobals.salesForceTrackingAddress;
            Outlook.MailItem newReply;
            Outlook.Folder draftFolder;
            draftFolder = Globals.ThisAddIn.Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderDrafts) as Outlook.Folder;
            if (!File.Exists(templatePath))
                throw new FileNotFoundException("Unable to open the email template. " +
                    "Please verify that the correct email template path is specified in Settings. " +
                    "Default path:\n" +
                    @"X:\OBP Team\Team Folders\Tech PreSales\Outlook Templates for SFDC Macro\");
            newReply = Globals.ThisAddIn.Application.CreateItemFromTemplate(templatePath, draftFolder) as Outlook.MailItem;
            newReply.Subject = "Case ID " + idNumber + " - " + questionSubject + " " + refCode;
            newReply.To = toAddress;
            newReply.BCC = bccAddress;
            //newReply.CC = ccAddress;
            newReply.SentOnBehalfOfName = fromAddress;
            newReply.HTMLBody = newReply.HTMLBody.Replace("[CALLER]", customerName);
            newReply.HTMLBody = newReply.HTMLBody.Replace("[CONSULTANT]", consultantName);
            newReply.HTMLBody = newReply.HTMLBody.Replace("[QUESTION]", questionContent);
            // Luis
            newReply.HTMLBody = newReply.HTMLBody.Replace("%5bCASE_ID%5d", idNumber);
            replyEmail = newReply;
        }

        private Dictionary<string, string> GetInformationFromFirstQuestion(Outlook.MailItem mI)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string body = sfdcMail.Body;
            string subject = sfdcMail.Subject;
            string idNumber = "";
            string questionSubject = "";
            string toAddress = "";
            string customerName = "";
            string refCode = "";
            string questionContent = "";
            // start parsing
            string pattern;
            Match match;
            // Extract idNumber and questionSubject
            pattern = @"Case Subject[:]\s*(\d+)\s*(.*)\n";
            match = Regex.Match(body, pattern);
            if (match.Success)
            {
                idNumber = CleanString(match.Groups[1].Value);
                questionSubject = CleanString(match.Groups[2].Value);
            }
            // Extract customerName and toAddress
            pattern = @"From[:]\s*(.*)\s*[/]\s*(.*)\s*";
            match = Regex.Match(body, pattern);
            if (match.Success)
            {
                customerName = CleanString(match.Groups[1].Value);
                toAddress = CleanString(match.Groups[2].Value);
                // Correct customerName OAE Generic User
                if (customerName.Equals("Casecreator Realtime"))        //luis
                {
                    customerName = ReplaceCharAt(toAddress.Substring(0, toAddress.IndexOf('@')), 0, Char.ToUpper(toAddress[0]));
                    if (customerName.IndexOf('.') > 0)
                    {
                        customerName = customerName.Substring(0, customerName.IndexOf('.'));
                    }
                }
            }
            // Extract refCode
            pattern = @"(\[\s*ref[:].+[:]ref\s*\])";
            match = Regex.Match(subject, pattern);
            if (match.Success) refCode = CleanString(match.Groups[1].Value);
            // Extract questionContent
            pattern = @"Case Description[:]\s*([\s\S]*)\s*You can access the support case by searching for the case number";
            match = Regex.Match(body, pattern);
            if (match.Success) questionContent = match.Groups[1].Value.Trim();
            // Clean up questionContent
            pattern = @"([\s\S]*?)\s*((Best regards)|(Kind regards)|(Yours Sincerely)|(Thank you)|(Many thanks))";
            match = Regex.Match(questionContent, pattern);
            if (match.Success) questionContent = match.Groups[1].Value;
            pattern = @"([\s\S]*?)\s*((Regards)|(Sincerely)|(Thanks))";
            match = Regex.Match(questionContent, pattern);
            if (match.Success) questionContent = match.Groups[1].Value;
            // Correct SPOCK stuff
            pattern = @"SWD SPOCK Feedback[\s\S]*Name[:]\s*(.*)[\s\S]*Address[:]\s*(.*)[\s\S]*Your Organization[\s\S]*Technical Question[:]\s*([\s\S]*)";
            match = Regex.Match(questionContent, pattern);
            if (match.Success)
            {
                customerName = CleanString(match.Groups[1].Value);
                toAddress = CleanString(match.Groups[2].Value);
                questionContent = match.Groups[3].Value;
            }
            // Remove duplicate whitespace
            questionContent = Regex.Replace(questionContent, @"( |\t|\r?\n)\1+", "$1");
            // Replaces newlines by HTML newlines
            questionContent = questionContent.Replace(Environment.NewLine, "<br>");
            dict.Add("idNumber", idNumber);
            dict.Add("questionSubject", questionSubject);
            dict.Add("customerName", customerName);
            dict.Add("toAddress", toAddress);
            dict.Add("refCode", refCode);
            dict.Add("questionContent", questionContent);
            return dict;
        }

        private DateTime GetDateFromReply(Outlook.MailItem mI)
        {
            string body = mI.Body;
            DateTime date;
            // start parsing
            string pattern;
            Match match;
            // Extract sentDateFollowUp
            pattern = @"Sent[:] (\w{3}) (\w{3}) (\d{2}) (\d{2}):(\d{2}):(\d{2}) \w+ (\d{4})";
            match = Regex.Match(body, pattern);
            if (match.Success)
            {
                string dayOfWeek = match.Groups[1].Value.Trim();
                string monthString = match.Groups[2].Value.Trim();
                string[] monthNames = CultureInfo.InvariantCulture.DateTimeFormat.AbbreviatedMonthNames;
                int month = Array.IndexOf(monthNames, monthString) + 1;
                int day = Int32.Parse(match.Groups[3].Value.Trim());
                int hours = Int32.Parse(match.Groups[4].Value.Trim());
                int minutes = Int32.Parse(match.Groups[5].Value.Trim());
                int seconds = Int32.Parse(match.Groups[6].Value.Trim());
                int year = Int32.Parse(match.Groups[7].Value.Trim());
                date = new DateTime(year, month, day, hours, minutes, seconds);
            }
            else
            {
                date = DateTime.Now;
            }
            return date;
        }

        private Dictionary<string, string> GetInformationFromReply(Outlook.MailItem mI)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string body = mI.Body;
            string subject = mI.Subject;
            string idNumber = "";
            string questionSubject = "";
            string questionSubjectFollowUp = "";
            string toAddress = "";
            string customerName = "";
            string refCode = "";
            string questionContent = "";
            // start parsing
            string pattern;
            Match match;
            // Extract idNumber and questionSubject
            pattern = @"An email has been received for case\s*(\d+)[:]\s*(.*)[.]";
            match = Regex.Match(body, pattern);
            if (match.Success)
            {
                idNumber = CleanString(match.Groups[1].Value);
                questionSubject = CleanString(match.Groups[2].Value);
            }
            // Extract questionSubjectFollowUp
            pattern = @"Subject[:]\s*(.*)";
            match = Regex.Match(body, pattern);
            if (match.Success)
            {
                questionSubjectFollowUp = match.Groups[1].Value.Trim();
            }
            // Extract customerName and toAddress
            pattern = @"From[:]\s*(.*)[(](.*)\s*[)]";
            match = Regex.Match(body, pattern);
            if (match.Success)
            {
                toAddress = CleanString(match.Groups[1].Value);
                customerName = CleanString(match.Groups[2].Value);
            }
            // Extract extra people in CC
            pattern = @"To[:]\s*(.+)";
            match = Regex.Match(body, pattern);
            if (match.Success)
            {
                ccAddress = CleanString(match.Groups[1].Value);
            }
            // Extract refCode
            pattern = @"(\[\s*ref[:].+[:]ref\s*\])";
            match = Regex.Match(body, pattern);
            if (match.Success)
            {
                refCode = CleanString(match.Groups[1].Value);
            }
            // Extract questionContent
            pattern = @"Subject[:].*?\r\n(.+)?\r\nFrom[:]";
            match = Regex.Match(body, pattern, RegexOptions.Singleline);
            if (match.Success)
            {
                questionContent = match.Groups[1].Value.Trim();
            }
            // Clean up questionContent
            pattern = @"([\s\S]*?)\s*((Best regards)|(Kind regards)|(Yours Sincerely))";
            match = Regex.Match(questionContent, pattern);
            if (match.Success) questionContent = match.Groups[1].Value;
            pattern = @"([\s\S]*?)\s*((Regards)|(Sincerely))";
            match = Regex.Match(questionContent, pattern);
            if (match.Success) questionContent = match.Groups[1].Value;
            // Remove duplicate whitespace
            questionContent = Regex.Replace(questionContent, @"( |\t|\r?\n)\1+", "$1");
            // Replaces newlines by HTML newlines
            questionContent = questionContent.Replace(Environment.NewLine, "<br>");
            // add values to dict
            dict.Add("idNumber", idNumber);
            dict.Add("questionSubject", questionSubject);
            dict.Add("questionSubjectFollowUp", questionSubjectFollowUp);
            dict.Add("customerName", customerName);
            dict.Add("toAddress", toAddress);
            dict.Add("refCode", refCode);
            dict.Add("ccAddress", ccAddress);
            dict.Add("questionContent", questionContent);
            return dict;
        }

        private string CleanString(string s)
        {
            s = s.Replace(Environment.NewLine, ""); // Get rid of newlines
            s = s.Replace("\r", "");
            s = s.Replace("\n", "");
            s = s.Trim();
            return s;
        }

        internal void FindOriginal()
        {
            string subjectToFind = firstQuestion ? questionSubject : questionSubjectFollowUp;
            // Check language mailboxes
            List<string> selectedLanguagesPlusNone = new List<string>(OBPGlobals.selectedLanguages);
            selectedLanguagesPlusNone.Add("none");
            foreach (string language in selectedLanguagesPlusNone) // iterate over mailboxes
            {
                string mailBoxName = OBPGlobals.mailBoxFromLanguage(language);
                Outlook.Items mailFolderItems = GetFolder(mailBoxName).Items;
                mailFolderItems.Sort("[ReceivedTime]", true);
                foreach (object o in mailFolderItems) // iterate over items in mailbox
                {
                    if (o is Outlook.MailItem)
                    {
                        Outlook.MailItem tempMail = (Outlook.MailItem)o;
                        string tempSubject = tempMail.Subject;
                        if (subjectToFind.Equals(tempSubject)) // check subject
                        {
                            string tempEmailAddress = GetSenderSMTPAddress(tempMail);
                            if (toAddress.ToLower() == tempEmailAddress.ToLower()) // check sender
                            {
                                bool match = true;
                                if (!firstQuestion) // if reply, check date
                                {
                                    if (!tempMail.SentOn.Date.Equals(sentDateFollowUp.Date))
                                        match = false;
                                }
                                if (match)
                                {
                                    originalEmail = tempMail;
                                    return;
                                } 
                            }
                        }
                    }
                    
                }
            }
            string errorMessage = "Email was not found when searching the following mailboxes:";
                foreach (string l in selectedLanguagesPlusNone)
                {
                    errorMessage += Environment.NewLine + OBPGlobals.mailBoxFromLanguage(l);
                }
                throw new FileNotFoundException(errorMessage);
        }

        private string GetSenderSMTPAddress(Outlook.MailItem mail)
        {
            string PR_SMTP_ADDRESS =
                @"http://schemas.microsoft.com/mapi/proptag/0x39FE001E";
            if (mail == null)
            {
                throw new ArgumentNullException();
            }
            if (mail.SenderEmailType == "EX")
            {
                Outlook.AddressEntry sender =
                    mail.Sender;
                if (sender != null)
                {
                    //Now we have an AddressEntry representing the Sender
                    if (sender.AddressEntryUserType ==
                        Outlook.OlAddressEntryUserType.
                        olExchangeUserAddressEntry
                        || sender.AddressEntryUserType ==
                        Outlook.OlAddressEntryUserType.
                        olExchangeRemoteUserAddressEntry)
                    {
                        //Use the ExchangeUser object PrimarySMTPAddress
                        Outlook.ExchangeUser exchUser =
                            sender.GetExchangeUser();
                        if (exchUser != null)
                        {
                            return exchUser.PrimarySmtpAddress;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return sender.PropertyAccessor.GetProperty(
                            PR_SMTP_ADDRESS) as string;
                    }
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return mail.SenderEmailAddress;
            }
        }

        private Outlook.Folder GetFolder(string folderPath)
        {
            Outlook.Folder folder;
            string backslash = @"\";
            try
            {
                if (folderPath.StartsWith(@"\\"))
                {
                    folderPath = folderPath.Remove(0, 2);
                }
                String[] folders =
                    folderPath.Split(backslash.ToCharArray());
                folder = Globals.ThisAddIn.Application.Session.Folders[folders[0]] as Outlook.Folder;
                if (folder != null)
                {
                    for (int i = 1; i <= folders.GetUpperBound(0); i++)
                    {
                        Outlook.Folders subFolders = folder.Folders;
                        folder = subFolders[folders[i]] as Outlook.Folder;
                        if (folder == null)
                        {
                            return null;
                        }
                    }
                }
                return folder;
            }
            catch { return null; }
        }

        private string ReplaceCharAt(string input, int index, char newChar)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            char[] chars = input.ToCharArray();
            chars[index] = newChar;
            return new string(chars);
        }
    }
}
