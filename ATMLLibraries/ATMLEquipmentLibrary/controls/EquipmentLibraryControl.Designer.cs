namespace ATMLEquipmentLibrary.controls
{
    partial class EquipmentLibraryControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EquipmentLibraryControl));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabTestStations = new System.Windows.Forms.TabPage();
            this.tabInstruments = new System.Windows.Forms.TabPage();
            this.lvInstruments = new ATMLCommonLibrary.controls.lists.ATMLListControl();
            this.tabTestAdapters = new System.Windows.Forms.TabPage();
            this.tabUUTs = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabInstruments.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser);
            this.splitContainer1.Size = new System.Drawing.Size(839, 613);
            this.splitContainer1.SplitterDistance = 311;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabTestStations);
            this.tabControl1.Controls.Add(this.tabInstruments);
            this.tabControl1.Controls.Add(this.tabTestAdapters);
            this.tabControl1.Controls.Add(this.tabUUTs);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(839, 311);
            this.tabControl1.TabIndex = 0;
            // 
            // tabTestStations
            // 
            this.tabTestStations.Location = new System.Drawing.Point(4, 22);
            this.tabTestStations.Name = "tabTestStations";
            this.tabTestStations.Padding = new System.Windows.Forms.Padding(3);
            this.tabTestStations.Size = new System.Drawing.Size(831, 285);
            this.tabTestStations.TabIndex = 0;
            this.tabTestStations.Text = "Test Stations";
            this.tabTestStations.UseVisualStyleBackColor = true;
            // 
            // tabInstruments
            // 
            this.tabInstruments.Controls.Add(this.lvInstruments);
            this.tabInstruments.Location = new System.Drawing.Point(4, 22);
            this.tabInstruments.Name = "tabInstruments";
            this.tabInstruments.Padding = new System.Windows.Forms.Padding(3);
            this.tabInstruments.Size = new System.Drawing.Size(831, 285);
            this.tabInstruments.TabIndex = 1;
            this.tabInstruments.Text = "Instruments";
            this.tabInstruments.UseVisualStyleBackColor = true;
            // 
            // lvInstruments
            // 
            this.lvInstruments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvInstruments.Location = new System.Drawing.Point(3, 3);
            this.lvInstruments.Name = "lvInstruments";
            this.lvInstruments.Size = new System.Drawing.Size(825, 279);
            this.lvInstruments.TabIndex = 0;
            this.lvInstruments.SelectedIndexChanged += new ATMLCommonLibrary.controls.lists.ATMLListControl.OnIndexChangedDelegate(this.lvInstruments_SelectedIndexChanged);
            // 
            // tabTestAdapters
            // 
            this.tabTestAdapters.Location = new System.Drawing.Point(4, 22);
            this.tabTestAdapters.Name = "tabTestAdapters";
            this.tabTestAdapters.Size = new System.Drawing.Size(831, 285);
            this.tabTestAdapters.TabIndex = 2;
            this.tabTestAdapters.Text = "Test Adapters";
            this.tabTestAdapters.UseVisualStyleBackColor = true;
            // 
            // tabUUTs
            // 
            this.tabUUTs.Location = new System.Drawing.Point(4, 22);
            this.tabUUTs.Name = "tabUUTs";
            this.tabUUTs.Size = new System.Drawing.Size(831, 285);
            this.tabUUTs.TabIndex = 3;
            this.tabUUTs.Text = "UUTs";
            this.tabUUTs.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(839, 298);
            this.webBrowser.TabIndex = 0;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "document_import.png");
            // 
            // EquipmentLibraryControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "EquipmentLibraryControl";
            this.Size = new System.Drawing.Size(839, 613);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabInstruments.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabTestStations;
        private System.Windows.Forms.TabPage tabInstruments;
        private System.Windows.Forms.TabPage tabTestAdapters;
        private System.Windows.Forms.TabPage tabUUTs;
        private ATMLCommonLibrary.controls.lists.ATMLListControl lvInstruments;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.ImageList imageList;
    }
}
