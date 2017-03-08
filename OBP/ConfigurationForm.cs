using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBP
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            selectedLanguagesListBox.Items.AddRange(OBPGlobals.coveredLanguages.ToArray());

            foreach (string language in OBPGlobals.selectedLanguages)
            {
                for (int i = 0; i < selectedLanguagesListBox.Items.Count; i++)
                {
                    if ((string)selectedLanguagesListBox.Items[i] == language)
                    {
                        selectedLanguagesListBox.SetItemChecked(i, true);
                    }
                }
            }
                
            // Set the height of the ListBox to the preferred height / 3 to display all items in three columns.
            // languageListBox.Height = languageListBox.PreferredHeight / 3;
            selectedLanguagesListBox.Height = selectedLanguagesListBox.GetItemHeight(0) * 3;
            templateDirectoryTextBox.Text = OBPGlobals.templateDirectory;
            salesForceTrackingAddressTextBox.Text = OBPGlobals.salesForceTrackingAddress;
            consultantNameTextBox.Text = OBPGlobals.consultantName;
        }

        private void languageListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            OBPGlobals.selectedLanguages = selectedLanguagesListBox.CheckedItems.OfType<string>().ToList<string>();
            Properties.Settings.Default.selectedLanguages = new System.Collections.Specialized.StringCollection();
            Properties.Settings.Default.selectedLanguages.AddRange(OBPGlobals.selectedLanguages.ToArray());
            OBPGlobals.templateDirectory = validateDirectory(templateDirectoryTextBox.Text);
            Properties.Settings.Default.templateDirectory = OBPGlobals.templateDirectory;
            OBPGlobals.salesForceTrackingAddress = salesForceTrackingAddressTextBox.Text;
            Properties.Settings.Default.salesForceTrackingAddress = OBPGlobals.salesForceTrackingAddress;
            OBPGlobals.consultantName = consultantNameTextBox.Text;
            Properties.Settings.Default.consultantName = OBPGlobals.consultantName;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private string validateDirectory(string testDir)
        {
            if (testDir[testDir.Length - 1] != '\\') // we expect diretory to end with as backslash
                testDir += '\\';
            return testDir;
        }


    }
}
