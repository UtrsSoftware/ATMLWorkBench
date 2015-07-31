/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATMLCommonLibrary
{
    partial class test
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
            this.busControl1 = new ATMLCommonLibrary.controls.bus.BusControl();
            this.limitSimpleControl1 = new ATMLCommonLibrary.controls.limit.LimitSimpleControl();
            this.SuspendLayout();
            // 
            // busControl1
            // 
            this.busControl1.Location = new System.Drawing.Point(28, 52);
            this.busControl1.Name = "busControl1";
            this.busControl1.SchemaTypeName = null;
            this.busControl1.Size = new System.Drawing.Size(289, 37);
            this.busControl1.TabIndex = 1;
            this.busControl1.TargetNamespace = null;
            // 
            // limitSimpleControl1
            // 
            this.limitSimpleControl1.Limit = null;
            this.limitSimpleControl1.Location = new System.Drawing.Point(9, 10);
            this.limitSimpleControl1.Margin = new System.Windows.Forms.Padding(0);
            this.limitSimpleControl1.Name = "limitSimpleControl1";
            this.limitSimpleControl1.SchemaTypeName = null;
            this.limitSimpleControl1.Size = new System.Drawing.Size(154, 20);
            this.limitSimpleControl1.TabIndex = 0;
            this.limitSimpleControl1.TargetNamespace = null;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.busControl1);
            this.Controls.Add(this.limitSimpleControl1);
            this.Name = "test";
            this.Size = new System.Drawing.Size(374, 217);
            this.ResumeLayout(false);

        }

        #endregion

        private controls.limit.LimitSimpleControl limitSimpleControl1;
        private controls.bus.BusControl busControl1;
    }
}
