/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.forms
{
    partial class HelpMessageBox
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
            if( disposing && ( components != null ) )
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpMessageBox));
            this.edtMessageText = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblDenoteRequiredField = new System.Windows.Forms.Label();
            this.pnlShowMessage = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlShowMessage.SuspendLayout();
            this.SuspendLayout();
            // 
            // edtMessageText
            // 
            this.edtMessageText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMessageText.BackColor = System.Drawing.Color.Beige;
            this.edtMessageText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.edtMessageText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.edtMessageText.Location = new System.Drawing.Point(91, 29);
            this.edtMessageText.Multiline = true;
            this.edtMessageText.Name = "edtMessageText";
            this.edtMessageText.ReadOnly = true;
            this.edtMessageText.Size = new System.Drawing.Size(365, 73);
            this.edtMessageText.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(29, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(358, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOk.Location = new System.Drawing.Point(277, 6);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // lblDenoteRequiredField
            // 
            this.lblDenoteRequiredField.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDenoteRequiredField.AutoSize = true;
            this.lblDenoteRequiredField.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblDenoteRequiredField.Location = new System.Drawing.Point(1, 169);
            this.lblDenoteRequiredField.Name = "lblDenoteRequiredField";
            this.lblDenoteRequiredField.Size = new System.Drawing.Size(126, 13);
            this.lblDenoteRequiredField.TabIndex = 6;
            this.lblDenoteRequiredField.Text = "* Denotes a required field";
            // 
            // pnlShowMessage
            // 
            this.pnlShowMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlShowMessage.BackColor = System.Drawing.Color.Transparent;
            this.pnlShowMessage.Controls.Add(this.btnCancel);
            this.pnlShowMessage.Controls.Add(this.btnOk);
            this.pnlShowMessage.Location = new System.Drawing.Point(21, 117);
            this.pnlShowMessage.Name = "pnlShowMessage";
            this.pnlShowMessage.Size = new System.Drawing.Size(436, 32);
            this.pnlShowMessage.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Construction");
            this.imageList1.Images.SetKeyName(1, "Help");
            this.imageList1.Images.SetKeyName(2, "Information");
            this.imageList1.Images.SetKeyName(3, "Question");
            this.imageList1.Images.SetKeyName(4, "Stop");
            this.imageList1.Images.SetKeyName(5, "Warning");
            this.imageList1.Images.SetKeyName(6, "Cross");
            this.imageList1.Images.SetKeyName(7, "Error");
            // 
            // HelpMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(480, 167);
            this.Controls.Add(this.edtMessageText);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlShowMessage);
            this.Controls.Add(this.lblDenoteRequiredField);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HelpMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Help Message";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlShowMessage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlShowMessage;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox edtMessageText;
        protected System.Windows.Forms.Button btnCancel;
        protected System.Windows.Forms.Button btnOk;
        protected System.Windows.Forms.Label lblDenoteRequiredField;

    }
}