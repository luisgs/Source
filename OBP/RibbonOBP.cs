using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Tools.Ribbon;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OBP
{
    public partial class RibbonOBP
    {
        private void RibbonOBP_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void buttonNewReply_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                NewReplyForm nRF = new NewReplyForm();
                nRF.Show();
            }
            catch (ArgumentException aEx)
            {
                MessageBox.Show(aEx.Message, "Error");
            }
            
        }

        private void buttonOriginalEmail_Click(object sender, RibbonControlEventArgs e)
        {
            Outlook.MailItem selectedMailItem;
            SalesForceEmail sFE;
            try
            {
                if (Globals.ThisAddIn.Application.ActiveExplorer().Selection.Count > 0)
                {
                    Object selObject = Globals.ThisAddIn.Application.ActiveExplorer().Selection[1];
                    if (selObject is Outlook.MailItem)
                    {
                        selectedMailItem = (selObject as Outlook.MailItem);
                        sFE = new SalesForceEmail(selectedMailItem);
                        sFE.FindOriginal();
                        sFE.OriginalEmail.Display();
                    }
                    else
                    {
                        throw new ArgumentException("Selected Outlook item is not supported. Please select an email from Salesforce.com with a subject containing one of the following sentences:"
                        + Environment.NewLine + "-\tYou Have Been Assigned A Support Case"
                        + Environment.NewLine + "-\tNew case email notification");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void buttonConfiguration_Click(object sender, RibbonControlEventArgs e)
        {
            ConfigurationForm cF = new ConfigurationForm();
            cF.Show();
        }

        // todo: add user settings to Environment.SpecialFolder.ApplicationData = C:\Users\username\AppData\Roaming
        // https://msdn.microsoft.com/en-us/library/aa730869%28v=vs.80%29.aspx
    }
}
