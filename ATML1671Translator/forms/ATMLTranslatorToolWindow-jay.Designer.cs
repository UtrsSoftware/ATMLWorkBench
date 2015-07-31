/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

namespace ATML1671Translator.forms
{
    partial class ATMLTranlatorToolWindowJay
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeViewParameters = new System.Windows.Forms.TreeView();
            this.treeViewPatterns = new System.Windows.Forms.TreeView();
            this.btnAnalyzeASP = new System.Windows.Forms.Button();
            this.btnParseASE = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnExtractATLAS = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.panel1.Controls.Add(this.treeViewParameters);
            this.panel1.Controls.Add(this.treeViewPatterns);
            this.panel1.Controls.Add(this.btnAnalyzeASP);
            this.panel1.Controls.Add(this.btnParseASE);
            this.panel1.Controls.Add(this.txtOutput);
            this.panel1.Controls.Add(this.txtInput);
            this.panel1.Controls.Add(this.btnExtractATLAS);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(750, 796);
            this.panel1.TabIndex = 0;
            // 
            // treeViewParameters
            // 
            this.treeViewParameters.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewParameters.Location = new System.Drawing.Point(363, 555);
            this.treeViewParameters.Name = "treeViewParameters";
            this.treeViewParameters.Size = new System.Drawing.Size(346, 225);
            this.treeViewParameters.TabIndex = 13;
            // 
            // treeViewPatterns
            // 
            this.treeViewPatterns.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeViewPatterns.Location = new System.Drawing.Point(17, 555);
            this.treeViewPatterns.Name = "treeViewPatterns";
            this.treeViewPatterns.Size = new System.Drawing.Size(340, 225);
            this.treeViewPatterns.TabIndex = 12;
            // 
            // btnAnalyzeASP
            // 
            this.btnAnalyzeASP.Location = new System.Drawing.Point(369, 16);
            this.btnAnalyzeASP.Name = "btnAnalyzeASP";
            this.btnAnalyzeASP.Size = new System.Drawing.Size(170, 23);
            this.btnAnalyzeASP.TabIndex = 11;
            this.btnAnalyzeASP.Text = "Analyze ASP XML";
            this.btnAnalyzeASP.UseVisualStyleBackColor = true;
            // 
            // btnParseASE
            // 
            this.btnParseASE.Location = new System.Drawing.Point(193, 16);
            this.btnParseASE.Name = "btnParseASE";
            this.btnParseASE.Size = new System.Drawing.Size(170, 23);
            this.btnParseASE.TabIndex = 10;
            this.btnParseASE.Text = "Parse ASE XML to ASP XML";
            this.btnParseASE.UseVisualStyleBackColor = true;
            // 
            // txtOutput
            // 
            this.txtOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(17, 304);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOutput.Size = new System.Drawing.Size(692, 225);
            this.txtOutput.TabIndex = 9;
            // 
            // txtInput
            // 
            this.txtInput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(17, 53);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInput.Size = new System.Drawing.Size(692, 225);
            this.txtInput.TabIndex = 8;
            // 
            // btnExtractATLAS
            // 
            this.btnExtractATLAS.Location = new System.Drawing.Point(17, 16);
            this.btnExtractATLAS.Name = "btnExtractATLAS";
            this.btnExtractATLAS.Size = new System.Drawing.Size(170, 23);
            this.btnExtractATLAS.TabIndex = 7;
            this.btnExtractATLAS.Text = "Extract ATLAS to ASE XML";
            this.btnExtractATLAS.UseVisualStyleBackColor = true;
            this.btnExtractATLAS.Click += new System.EventHandler(this.btnExtractATLAS_Click_1);
            // 
            // ATMLTranlatorToolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 796);
            this.CloseButton = false;
            this.CloseButtonVisible = false;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ATMLTranlatorToolWindow";
            this.Text = "Translator";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView treeViewParameters;
        private System.Windows.Forms.TreeView treeViewPatterns;
        private System.Windows.Forms.Button btnAnalyzeASP;
        private System.Windows.Forms.Button btnParseASE;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnExtractATLAS;



    }
}

