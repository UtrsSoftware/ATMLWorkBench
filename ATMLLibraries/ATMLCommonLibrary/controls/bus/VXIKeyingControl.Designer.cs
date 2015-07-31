/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/
namespace ATMLCommonLibrary.controls.bus
{
    partial class VXIKeyingControl
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
            this.gbFrame = new System.Windows.Forms.GroupBox();
            this.lblTopLeft = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblTopRight = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtTopLeft = new System.Windows.Forms.NumericUpDown();
            this.edtTopRight = new System.Windows.Forms.NumericUpDown();
            this.lblBottomLeft = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.lblBottomRight = new ATMLCommonLibrary.controls.HelpLabel(this.components);
            this.edtBottomLeft = new System.Windows.Forms.NumericUpDown();
            this.edtBottomRight = new System.Windows.Forms.NumericUpDown();
            this.gbFrame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTopLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTopRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBottomLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBottomRight)).BeginInit();
            this.SuspendLayout();
            // 
            // gbFrame
            // 
            this.gbFrame.Controls.Add(this.lblTopLeft);
            this.gbFrame.Controls.Add(this.lblTopRight);
            this.gbFrame.Controls.Add(this.edtTopLeft);
            this.gbFrame.Controls.Add(this.edtTopRight);
            this.gbFrame.Controls.Add(this.lblBottomLeft);
            this.gbFrame.Controls.Add(this.lblBottomRight);
            this.gbFrame.Controls.Add(this.edtBottomLeft);
            this.gbFrame.Controls.Add(this.edtBottomRight);
            this.gbFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFrame.Location = new System.Drawing.Point(0, 0);
            this.gbFrame.Name = "gbFrame";
            this.gbFrame.Size = new System.Drawing.Size(317, 91);
            this.gbFrame.TabIndex = 0;
            this.gbFrame.TabStop = false;
            this.gbFrame.Text = "VXI Keying";
            // 
            // lblTopLeft
            // 
            this.lblTopLeft.HelpMessageKey = "VXIKeying.TopLeft";
            this.lblTopLeft.Location = new System.Drawing.Point(10, 28);
            this.lblTopLeft.Name = "lblTopLeft";
            this.lblTopLeft.RequiredField = true;
            this.lblTopLeft.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopLeft.Size = new System.Drawing.Size(65, 13);
            this.lblTopLeft.TabIndex = 0;
            this.lblTopLeft.Text = "Top Left";
            // 
            // lblTopRight
            // 
            this.lblTopRight.HelpMessageKey = "VXIKeying.TopRight";
            this.lblTopRight.Location = new System.Drawing.Point(158, 28);
            this.lblTopRight.Name = "lblTopRight";
            this.lblTopRight.RequiredField = true;
            this.lblTopRight.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopRight.Size = new System.Drawing.Size(72, 13);
            this.lblTopRight.TabIndex = 4;
            this.lblTopRight.Text = "Top Right";
            // 
            // edtTopLeft
            // 
            this.edtTopLeft.Location = new System.Drawing.Point(79, 26);
            this.edtTopLeft.Name = "edtTopLeft";
            this.edtTopLeft.Size = new System.Drawing.Size(60, 20);
            this.edtTopLeft.TabIndex = 1;
            this.edtTopLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtTopRight
            // 
            this.edtTopRight.Location = new System.Drawing.Point(233, 26);
            this.edtTopRight.Name = "edtTopRight";
            this.edtTopRight.Size = new System.Drawing.Size(60, 20);
            this.edtTopRight.TabIndex = 5;
            this.edtTopRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblBottomLeft
            // 
            this.lblBottomLeft.HelpMessageKey = "VXIKeying.BottomLeft";
            this.lblBottomLeft.Location = new System.Drawing.Point(10, 56);
            this.lblBottomLeft.Name = "lblBottomLeft";
            this.lblBottomLeft.RequiredField = true;
            this.lblBottomLeft.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottomLeft.Size = new System.Drawing.Size(65, 13);
            this.lblBottomLeft.TabIndex = 2;
            this.lblBottomLeft.Text = "Bottom Left";
            // 
            // lblBottomRight
            // 
            this.lblBottomRight.HelpMessageKey = "VXIKeying.BottomRight";
            this.lblBottomRight.Location = new System.Drawing.Point(158, 56);
            this.lblBottomRight.Name = "lblBottomRight";
            this.lblBottomRight.RequiredField = true;
            this.lblBottomRight.RequiredFieldMarkerFont = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBottomRight.Size = new System.Drawing.Size(72, 13);
            this.lblBottomRight.TabIndex = 6;
            this.lblBottomRight.Text = "Bottom Right";
            // 
            // edtBottomLeft
            // 
            this.edtBottomLeft.Location = new System.Drawing.Point(79, 54);
            this.edtBottomLeft.Name = "edtBottomLeft";
            this.edtBottomLeft.Size = new System.Drawing.Size(60, 20);
            this.edtBottomLeft.TabIndex = 3;
            this.edtBottomLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // edtBottomRight
            // 
            this.edtBottomRight.Location = new System.Drawing.Point(233, 54);
            this.edtBottomRight.Name = "edtBottomRight";
            this.edtBottomRight.Size = new System.Drawing.Size(60, 20);
            this.edtBottomRight.TabIndex = 7;
            this.edtBottomRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // VXIKeyingControl
            // 
            this.Controls.Add(this.gbFrame);
            this.Name = "VXIKeyingControl";
            this.Size = new System.Drawing.Size(317, 91);
            this.gbFrame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtTopLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTopRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBottomLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBottomRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbFrame;
        private HelpLabel lblBottomLeft;
        private HelpLabel lblBottomRight;
        private System.Windows.Forms.NumericUpDown edtBottomLeft;
        private System.Windows.Forms.NumericUpDown edtBottomRight;
        private HelpLabel lblTopLeft;
        private HelpLabel lblTopRight;
        private System.Windows.Forms.NumericUpDown edtTopLeft;
        private System.Windows.Forms.NumericUpDown edtTopRight;
    }
}
