/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
*
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using ATMLCommonLibrary.utils;
using ATMLManagerLibrary.controllers;
using ATMLManagerLibrary.delegates;
using ATMLManagerLibrary.interfaces;
using ATMLModelLibrary;
using ATMLModelLibrary.interfaces;
using ATMLModelLibrary.model.equipment;
using ATMLSchemaLibrary.managers;

namespace ATMLCommonLibrary.forms
{
    public delegate void OKClickHandler( object sender, EventArgs e );

    public partial class InstrumentForm : ATMLForm, IAtmlActionable
    {

        public event AtmlActionDeligate<IAtmlObject> AtmlObjectAction;
        //public event OKClickHandler Saved;

        public InstrumentForm()
        {
            InitializeComponent();
            InitViewButton(btnViewATML);
            ValidateSchema += InstrumentForm_ValidateSchema;
            UndoChanges += InstrumentForm_UndoChanges;
            Saved += delegate { ValidateToSchema(); UpdateAtmlViewContent( InstrumentDescription ); };
        }


        protected override void OnSaved()
        {
            base.OnSaved();
            InstrumentDescription instrumentDescription = instrumentControl.InstrumentDescription;
            if (instrumentDescription != null)
                UpdateAtmlViewContent(instrumentDescription);
        }

        [Browsable( false ), DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public InstrumentDescription InstrumentDescription
        {
            get
            {
                return instrumentControl.InstrumentDescription;
            }
            set
            {
                instrumentControl.InstrumentDescription = value;
            }
        }

        protected virtual IAtmlObject OnAtmlObjectAction( IAtmlObject obj, AtmlActionType actiontype )
        {
            AtmlActionDeligate<IAtmlObject> handler = AtmlObjectAction;
            if (handler != null) obj = handler( obj, actiontype, EventArgs.Empty );
            return obj;
        }

        private void InstrumentForm_UndoChanges( object sender, EventArgs e )
        {
            InstrumentDescription = InstrumentDescription.Deserialize( originalSerializedATMLObject );
        }

        private void InstrumentForm_ValidateSchema( object sender, EventArgs e )
        {
            ValidateToSchema();
        }

        private void ValidateToSchema()
        {
            HourGlass.Start();
            var error = new StringBuilder( 1024*1024*6 );
            InstrumentDescription instrument = InstrumentDescription;
            try
            {

                if (!SchemaManager.ValidateXml( instrument.Serialize(), ATMLCommon.InstrumentNameSpace, error ))
                {
                    HourGlass.Stop();
                    string name = GetName( instrument );
                    ATMLErrorForm.ShowValidationMessage(
                        string.Format( "The \"{0}\" Instrument has failed validation against the {1} ATML schema.", name,
                                       ATMLCommon.InstrumentNameSpace ),
                        error.ToString(), "Note: This error will not prevent you from continuing." );
                }
                else
                {
                    HourGlass.Stop();
                    MessageBox.Show( @"This Instrument generated valid ATML" );
                }
            }
            catch (Exception)
            {
                HourGlass.Stop();
            }
        }

        private static string GetName( InstrumentDescription instrument )
        {
            string name = instrument.name;
            if (string.IsNullOrEmpty( name ))
            {
                if (instrument.Identification != null && !string.IsNullOrEmpty( instrument.Identification.ModelName ))
                {
                    name = instrument.Identification.ModelName;
                }
                else
                {
                    name = instrument.uuid;
                }
            }
            return name;
        }

        //protected virtual void OnSave( EventArgs e )
        //{
        //    if (Saved != null)
        //        Saved( this, e );
        //}

        private String BuildAtml()
        {
            var tw = new StringWriter();
            try
            {
                var serializerObj = new XmlSerializer( typeof (InstrumentDescription) );
                serializerObj.Serialize( tw, InstrumentDescription );
            }
            catch (Exception e)
            {
                var error = new StringBuilder( "Error Building ATML Document for the Instrument.\n" );
                error.Append( e.Message ).Append( "\n" );
                Exception innerException = e.InnerException;
                while (innerException != null)
                {
                    error.Append( " * " ).Append( innerException.Message ).Append( "\n" );
                    innerException = innerException.InnerException;
                }
                MessageBox.Show( error.ToString() );
            }
            return tw.ToString();
        }

        //protected override void btnOk_Click( object sender, EventArgs e )
        protected void btnOk_Clicka( object sender, EventArgs e )
        {
            ValidateChildren();
            if (!ValidateChildren())
            {
                MessageBox.Show( @"Errors Exist. Please correct them to continue." );
            }
            else
            {
                InstrumentDescription instrumentDescription = instrumentControl.InstrumentDescription;

                if (instrumentDescription == null)
                    return;

                //------------------------------------------------------------------------------------------------//
                //--- Cleanup Objects - if Lists are empty then set list to null - may need to switch to array ---//
                //---                   if extension is not used then set it to null                           ---//
                //------------------------------------------------------------------------------------------------//
                if (instrumentDescription.Extension != null && instrumentDescription.Extension.Any != null &&
                    instrumentDescription.Extension.Any.Count == 0)
                    instrumentDescription.Extension = null;

                try
                {
                    InstrumentController.Instance.Save( instrumentDescription );
                    UpdateAtmlViewContent(instrumentDescription);
                    instrumentControl.Invalidate();
                    Update();
                }
                catch (Exception err)
                {
                    MessageBox.Show( string.Format( "An error has occurred saving the Instrument.\n{0}", err.Message ) );
                }
                //OnSaved(e);
                OnSaved();
            }
        }

        private void btnOk_Validating( object sender, CancelEventArgs e )
        {
        }

        private void InstrumentForm_Validating( object sender, CancelEventArgs e )
        {
        }

        private void InstrumentForm_FormClosing( object sender, FormClosingEventArgs e )
        {
            if (DialogResult.OK == DialogResult)
            {
                if (!ValidateChildren())
                    e.Cancel = true;
            }

        }

        protected override void OnResizeBegin( EventArgs e )
        {
            SuspendLayout();
            base.OnResizeBegin( e );
        }

        protected override void OnResizeEnd( EventArgs e )
        {
            ResumeLayout();
            base.OnResizeEnd( e );
        }

        private void btnValidate_Click( object sender, EventArgs e )
        {
            ValidateToSchema();
            /*
            var error = new StringBuilder( 1024*1024*6 );
            InstrumentDescription instrument = InstrumentDescription;
            if (instrument != null)
            {
                if (!SchemaManager.ValidateXml( instrument.Serialize(), ATMLCommon.InstrumentNameSpace, error ))
                {
                    ATMLErrorForm.ShowValidationMessage(
                        string.Format( "The \"{0}\" Instrument has failed validation against the {1} ATML schema.",
                                       instrument.name, ATMLCommon.InstrumentNameSpace ),
                        error.ToString(),
                        "Note: This error will not prevent you from continuing." );
                }
                else
                {
                    MessageBox.Show( @"This Instrument generated valid ATML" );
                }
            }
             */
        }

        private void btnViewATML_Click( object sender, EventArgs e )
        {
            InstrumentDescription instrumentDescription = instrumentControl.InstrumentDescription;
            ShowAtmlContent(instrumentDescription);
        }
    }
}