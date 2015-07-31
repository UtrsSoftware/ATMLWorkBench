/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.operational
{
    partial class OperationalRequirementsControl
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.namedValueListControl1 = new ATMLCommonLibrary.controls.common.NamedValueListControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.warmUpTimeSpan = new ATMLCommonLibrary.controls.awb.AWBDurationControl();
            this.helpLabel1 = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.requiredFieldValidator1 = new ATMLCommonLibrary.controls.validators.RequiredFieldValidator();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // namedValueListControl1
            // 
            this.namedValueListControl1.AllowRowResequencing = false;
            this.namedValueListControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.namedValueListControl1.FormTitle = null;
            this.namedValueListControl1.ListName = null;
            this.namedValueListControl1.Location = new System.Drawing.Point(0, 61);
            this.namedValueListControl1.Margin = new System.Windows.Forms.Padding(0);
            this.namedValueListControl1.Name = "namedValueListControl1";
            this.namedValueListControl1.NamedValues = null;
            this.namedValueListControl1.SchemaTypeName = null;
            this.namedValueListControl1.ShowFind = false;
            this.namedValueListControl1.Size = new System.Drawing.Size(503, 161);
            this.namedValueListControl1.TabIndex = 0;
            this.namedValueListControl1.TargetNamespace = null;
            this.namedValueListControl1.TooltipTextAddButton = "Press to add a new ";
            this.namedValueListControl1.TooltipTextDeleteButton = "Press to delete the selected ";
            this.namedValueListControl1.TooltipTextEditButton = "Press to edit the selected ";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.warmUpTimeSpan);
            this.groupBox1.Controls.Add(this.helpLabel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(497, 52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Attributes";
            // 
            // warmUpTimeSpan
            // 
            this.warmUpTimeSpan.Location = new System.Drawing.Point(88, 18);
            this.warmUpTimeSpan.MaximumDuration = ATMLCommonLibrary.controls.awb.AWBDurationControl.MaxDuration.Hours;
            this.warmUpTimeSpan.Name = "warmUpTimeSpan";
            this.warmUpTimeSpan.Size = new System.Drawing.Size(247, 28);
            this.warmUpTimeSpan.TabIndex = 1;
            this.warmUpTimeSpan.TimeSpan = System.TimeSpan.Parse("00:00:00");
            // 
            // helpLabel1
            // 
            this.helpLabel1.AutoSize = true;
            this.helpLabel1.HelpMessageKey = "HarwareDescOperationReq.WarmupTime";
            this.helpLabel1.Location = new System.Drawing.Point(6, 24);
            this.helpLabel1.Name = "helpLabel1";
            this.helpLabel1.RequiredField = false;
            this.helpLabel1.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpLabel1.Size = new System.Drawing.Size(76, 13);
            this.helpLabel1.TabIndex = 0;
            this.helpLabel1.Text = "Warm-up Time";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ControlToValidate = null;
            this.requiredFieldValidator1.ErrorMessage = "Warm-up time required.";
            this.requiredFieldValidator1.ErrorProvider = null;
            this.requiredFieldValidator1.Icon = null;
            this.requiredFieldValidator1.InitialValue = null;
            this.requiredFieldValidator1.IsEnabled = true;
            // 
            // OperationalRequirementsControl
            // 
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.namedValueListControl1);
            this.Name = "OperationalRequirementsControl";
            this.Size = new System.Drawing.Size(503, 222);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private common.NamedValueListControl namedValueListControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private HelpLabel helpLabel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private validators.RequiredFieldValidator requiredFieldValidator1;
        private awb.AWBDurationControl warmUpTimeSpan;

    }
}
