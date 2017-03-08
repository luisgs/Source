using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Outlook = Microsoft.Office.Interop.Outlook;
using Office = Microsoft.Office.Core;

namespace OBP
{
    public partial class ThisAddIn
    {
        private void ThisAddIn_Startup(object sender, System.EventArgs e)
        {
            LoadSettings();
        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        private void LoadSettings()
        {
            OBPGlobals.selectedLanguages = Properties.Settings.Default.selectedLanguages.Cast<string>().ToList<string>();
            OBPGlobals.templateDirectory = Properties.Settings.Default.templateDirectory;
            OBPGlobals.salesForceTrackingAddress = Properties.Settings.Default.salesForceTrackingAddress;
            OBPGlobals.consultantName = Properties.Settings.Default.consultantName;
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }
        
        #endregion
    }
}
