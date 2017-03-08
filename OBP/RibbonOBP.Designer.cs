namespace OBP
{
    partial class RibbonOBP : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public RibbonOBP()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonOBP));
            this.TabMail = this.Factory.CreateRibbonTab();
            this.groupOBP = this.Factory.CreateRibbonGroup();
            this.buttonNewReply = this.Factory.CreateRibbonButton();
            this.buttonOriginalEmail = this.Factory.CreateRibbonButton();
            this.buttonConfiguration = this.Factory.CreateRibbonButton();
            this.TabMail.SuspendLayout();
            this.groupOBP.SuspendLayout();
            // 
            // TabMail
            // 
            this.TabMail.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.TabMail.ControlId.OfficeId = "TabMail";
            this.TabMail.Groups.Add(this.groupOBP);
            resources.ApplyResources(this.TabMail, "TabMail");
            this.TabMail.Name = "TabMail";
            this.TabMail.Position = this.Factory.RibbonPosition.BeforeOfficeId("GroupMailRespond");
            // 
            // groupOBP
            // 
            this.groupOBP.Items.Add(this.buttonNewReply);
            this.groupOBP.Items.Add(this.buttonOriginalEmail);
            this.groupOBP.Items.Add(this.buttonConfiguration);
            resources.ApplyResources(this.groupOBP, "groupOBP");
            this.groupOBP.Name = "groupOBP";
            // 
            // buttonNewReply
            // 
            this.buttonNewReply.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonNewReply.Image = global::OBP.Properties.Resources.metalhand;
            resources.ApplyResources(this.buttonNewReply, "buttonNewReply");
            this.buttonNewReply.Name = "buttonNewReply";
            this.buttonNewReply.ShowImage = true;
            this.buttonNewReply.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonNewReply_Click);
            // 
            // buttonOriginalEmail
            // 
            this.buttonOriginalEmail.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonOriginalEmail.Image = global::OBP.Properties.Resources.incomingmail;
            resources.ApplyResources(this.buttonOriginalEmail, "buttonOriginalEmail");
            this.buttonOriginalEmail.Name = "buttonOriginalEmail";
            this.buttonOriginalEmail.ShowImage = true;
            this.buttonOriginalEmail.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonOriginalEmail_Click);
            // 
            // buttonConfiguration
            // 
            this.buttonConfiguration.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.buttonConfiguration.Image = global::OBP.Properties.Resources.settings;
            resources.ApplyResources(this.buttonConfiguration, "buttonConfiguration");
            this.buttonConfiguration.Name = "buttonConfiguration";
            this.buttonConfiguration.ShowImage = true;
            this.buttonConfiguration.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.buttonConfiguration_Click);
            // 
            // RibbonOBP
            // 
            this.Name = "RibbonOBP";
            this.RibbonType = "Microsoft.Outlook.Explorer";
            this.Tabs.Add(this.TabMail);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.RibbonOBP_Load);
            this.TabMail.ResumeLayout(false);
            this.TabMail.PerformLayout();
            this.groupOBP.ResumeLayout(false);
            this.groupOBP.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab TabMail;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup groupOBP;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonNewReply;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonOriginalEmail;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton buttonConfiguration;
    }

    partial class ThisRibbonCollection
    {
        internal RibbonOBP Ribbon1
        {
            get { return this.GetRibbon<RibbonOBP>(); }
        }
    }
}
