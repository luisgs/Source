using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace OBP
{
    public partial class NewReplyForm : Form
    {
        private Outlook.MailItem selectedMailItem;
        private SalesForceEmail sFE;
        public NewReplyForm()
        {
            InitializeComponent();
            if (Globals.ThisAddIn.Application.ActiveExplorer().Selection.Count > 0)
            {
                Object selObject = Globals.ThisAddIn.Application.ActiveExplorer().Selection[1];
                if (selObject is Outlook.MailItem)
                {
                    selectedMailItem = (selObject as Outlook.MailItem);
                    sFE = new SalesForceEmail(selectedMailItem);
                }
                else
                {
                    throw new ArgumentException("Selected Outlook item is not supported. Please select an email from Salesforce.com with a subject containing one of the following sentences:"
                    + Environment.NewLine + "-\tYou Have Been Assigned A Support Case"
                    + Environment.NewLine + "-\tNew case email notification");
                }
            }
            
            this.Shown += new System.EventHandler(this.NewReplyForm_Shown);
        }

        private bool isValidSalesForceEmail(Outlook.MailItem selectedMailItem)
        {
            string subject = selectedMailItem.Subject;
            return ( subject.Contains("You Have Been Assigned A Support Case") || subject.Contains("New case email notification. Case number") );
        }
        private void languageListBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Ensure that we are checking an item
            if (e.NewValue != CheckState.Checked)
            {
                return;
            }

            // Get the items that are selected
            CheckedListBox.CheckedIndexCollection selectedItems = this.languageListBox.CheckedIndices;
            // Check that we have at least 1 item selected
            if (selectedItems.Count > 0)
            {
                // Uncheck the other item
                this.languageListBox.SetItemChecked(selectedItems[0], false);
            }
            validateLanguageButton.Focus();
        }

        private void NewReplyForm_Shown(object sender, EventArgs e)
        {

        }

        private void NewReplyForm_Load(object sender, EventArgs e)
        {
            languageListBox.Items.AddRange(OBPGlobals.selectedLanguages.ToArray());
            languageListBox.SetItemChecked(0, true);
            // Set the height of the ListBox to the preferred height to display all items.
            languageListBox.Height = languageListBox.PreferredHeight;
        }

        private void validateLanguageButton_Click(object sender, EventArgs e)
        {
            string language = languageListBox.GetItemText(languageListBox.CheckedItems[0]);
            this.Close();
            try
            {
                sFE.NewReply(language);
                sFE.ReplyEmail.Display();
            }
            catch (ArgumentException aEx)
            {
                MessageBox.Show(aEx.Message, "Error");
            }
            catch (FileNotFoundException fNFEx)
            {
                MessageBox.Show(fNFEx.Message, "Error");
            }

        }
    }
}
