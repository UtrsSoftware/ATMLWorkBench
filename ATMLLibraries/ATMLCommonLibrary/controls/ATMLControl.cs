/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ATMLCommonLibrary.controls.awb;
using ATMLCommonLibrary.controls.lists;
using ATMLCommonLibrary.controls.validators;
using ATMLCommonLibrary.forms;
using ATMLCommonLibrary.managers;
using ATMLCommonLibrary.utils;
using ATMLUtilitiesLibrary;

namespace ATMLCommonLibrary.controls
{
    public class ATMLControl : UserControl
    {
        protected Boolean Initializing = false;

        protected ToolTip ToolTip = new AWBToolTip();

        public ATMLControl()
        {
            Validating += ATMLControl_Validating;
            BackColor = ATMLContext.COLOR_PANEL;
            ToolTip.UseAnimation = true;
            ToolTip.BackColor = Color.LightYellow;
            ToolTip.ForeColor = Color.Red;
        }

        public string HelpKeyWord { get; set; }

        [Category( "Behaviour" ), Description( "Enter the XML Schema Type Name." )]
        public string SchemaTypeName { get; set; }

        [Category( "Behaviour" ), Description( "Enter the target namespace for the Schema Type." )]
        public string TargetNamespace { get; set; }

        public string LastError { get; set; }

        protected string UndoBuffer { get; set; }

        public bool HasErrors { get; set; }
        public event EventHandler Error;

        protected virtual void OnError( object sender, string errorMessage )
        {
            EventHandler handler = Error;
            if (handler != null) handler( sender, new ValidationErrorEventArgs( errorMessage ) );
        }

        protected void InitControls()
        {
            foreach (Control ctrl in Controls)
            {
                InitControl( ctrl );
            }
        }

        private void InitControl( Control ctrl )
        {
            if (ctrl is TextBox)
            {
                SetTextBoxDelegate( ctrl );
            }
            else if (ctrl is ATMLControl)
            {
                ( (ATMLControl) ctrl ).InitControls();
            }
            else
            {
                foreach (Control ctrl1 in ctrl.Controls)
                {
                    InitControl( ctrl1 );
                }
            }
        }

        public virtual void Clear()
        {
            Clear( Controls );
        }

        protected virtual void Clear( ControlCollection controls )
        {
            foreach (Control control in controls)
            {
                Clear( control.Controls );
                var lc = control as ATMLListControl;
                var tb = control as TextBox;
                var dg = control as DataGridView;
                var lv = control as ListView;
                if (lc != null)
                    lc.Clear();
                if (tb != null)
                    tb.Clear();
                if (dg != null)
                    dg.Rows.Clear();
                if (lv != null)
                    lv.Items.Clear();
            }
        }

        private void SetTextBoxDelegate( Control ctrl )
        {
            ctrl.Enter += delegate( object sender, EventArgs e )
                          {
                              foreach (Control control in Controls)
                              {
                                  ResetTextBoxBackColor( control );
                              }
                              ResetTextBoxBackColor( FormManager.LastActiveControl );
                              FormManager.LastActiveControl = (Control) sender;
                              if (ParentForm is ATMLForm)
                              {
                                  ( (ATMLForm) ParentForm ).LastActiveControl = (Control) sender;
                              }
                          };
        }

        private void ResetTextBoxBackColor( Control control )
        {
            if (control != null)
            {
                if (control is TextBox)
                    control.BackColor = Color.White;
                else
                {
                    foreach (Control ctrl in control.Controls)
                    {
                        ResetTextBoxBackColor( ctrl );
                    }
                }
            }
        }

        private void ATMLControl_Validating( object sender, CancelEventArgs e )
        {
            e.Cancel = !ValidateChildren( ValidationConstraints.Enabled );
            if (e.Cancel)
            {
                OnError( sender, LastError );
            }
        }

        public static bool ValidateToSchema( object item )
        {
            bool validated = true;
            HourGlass.Enabled = true;
            try
            {
                //---------------------------------------//
                //--- Will Validate at the form level ---//
                //---------------------------------------//
                //SchemaManager.ValidateToSchema(item);
                /*
                MethodInfo miValidate = item.GetType().GetMethod("Validate");
                if (miValidate == null)
                    throw new Exception(string.Format("{0} does not support the Validate Method", item.GetType().Name));

                var errors = new SchemaValidationResult();
                object[] p = { errors };
                miValidate.Invoke(item, p);
                if (errors.HasErrors())
                {
                    ATMLErrorForm.ShowValidationMessage(errors.ErrorMessage, errors.Errors.ToString(), "Note: This error will not prevent you from continuing.");
                }
                else
                {
                    MessageBox.Show(string.Format(
                        "This {0} has passed all validation against the ATML Schema.",
                        item.GetType().Name), @"V a l i d a t i o n", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                 */
            }
            catch (Exception e)
            {
                HourGlass.Enabled = false;
                validated = false;
                ATMLErrorForm.ShowValidationMessage(
                    string.Format( "{0} has failed validation against the ATML schema.",
                                   item == null ? "Unknown" : item.GetType().Name ), e.Message,
                    "Note: This error will not prevent you from continuing." );
            }
            finally
            {
                HourGlass.Enabled = false;
            }
            return validated;
        }


        protected void RegisterForm( Form form )
        {
            if (ParentForm != null)
                ParentForm.AddOwnedForm( form );
        }

        protected void UnRegisterForm( Form form )
        {
            if (ParentForm != null)
                ParentForm.RemoveOwnedForm( form );
        }

        protected static bool CheckForErrors( ICollection controls )
        {
            bool hasError = false;
            foreach (Control control in controls)
            {
                PropertyInfo pi = control.GetType().GetProperty( "HasErrors" );
                if (pi != null)
                {
                    object obj = pi.GetValue( control, null );
                    if (obj is bool)
                        hasError |= (bool) obj;
                }
                hasError |= CheckForErrors( control.Controls );
                if (hasError)
                    break;
            }
            return hasError;
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // ATMLControl
            // 
            AutoScaleDimensions = new SizeF( 6F, 13F );
            AutoScaleMode = AutoScaleMode.Font;
            Name = "ATMLControl";
            ResumeLayout( false );
        }
    }
}