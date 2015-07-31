using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;
using ATMLCommonLibrary.forms;
using ATMLDataAccessLibrary.db.beans;
using ATMLDataAccessLibrary.model;
using ATMLManagerLibrary.managers;
using ATMLModelLibrary.model.common;
using ATMLModelLibrary.model.equipment;
using ATMLUtilitiesLibrary;
using Resources = ATMLEquipmentLibrary.Properties.Resources;

namespace ATMLEquipmentLibrary.controls
{
    public partial class EquipmentLibraryControl : UserControl
    {
        public delegate void OnInstrumentSelectedDelegate( object sender, EventArgs e );


        public EquipmentLibraryControl()
        {
            InitializeComponent();
            InitializeInstrumentList();
        }


        public Document SelectedInstrument
        {
            get
            {
                return ( lvInstruments.SelectedItems.Count > 0 ) ? lvInstruments.SelectedItems[0].Tag as Document : null;
            }
        }

        public event OnInstrumentSelectedDelegate SelectedInstrumentChanged;

        /**
         * Initializes the instrument list view by setting the column names, 
         * adding the event handlers and any additional tool buttons.
         */
        private void InitializeInstrumentList()
        {
            lvInstruments.Columns.Add( Resources.Name );
            lvInstruments.Columns.Add( Resources.Description );
            lvInstruments.Columns.Add( Resources.Version );
            lvInstruments.SetDistributedColumnWidths();
            lvInstruments.Resize += lvInstruments_Resize;
            lvInstruments.SelectedIndexChanged += lvInstruments_SelectedIndexChanged;
            lvInstruments.OnAdd += lvInstruments_OnAdd;
            lvInstruments.OnEdit += lvInstruments_OnEdit;
            lvInstruments.OnDelete += lvInstruments_OnDelete;

            //----------------------------------------------------------------------------------------//
            //--- Add a button to provide the ability to import an instrument description document ---//
            //----------------------------------------------------------------------------------------//
            var btnImport = new ToolStripButton();
            btnImport.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnImport.Image = imageList.Images["document_import.png"];
            btnImport.ImageTransparentColor = Color.Magenta;
            btnImport.Name = "btnImport";
            btnImport.Size = new Size( 21, 20 );
            btnImport.Text = Resources.Import;
            btnImport.ToolTipText = Resources.Press_to_iport_an_Instrument_description_document;
            btnImport.Click += btnImport_Click;
            lvInstruments.AddButton( btnImport );
        }


        /**
         * Handler for the Import button click event.
         */
        private void btnImport_Click( object sender, EventArgs e )
        {
            ImportInstrumentDocument();
        }


        /**
         * Call this method to select and import an instrument description document. 
         * If the document already exists in the database the user
         * will be prompted to overwrite the existing document.
         */
        private void ImportInstrumentDocument()
        {
            try
            {
                bool ok2Save = true;
                String xmlContent;
                //---------------------//
                //--- Open the file ---//
                //---------------------//
                if (FileManager.OpenXmlFile( out xmlContent ))
                {
                    var dataState = BASEBean.eDataState.DS_ADD;
                    var document = new Document();
                    InstrumentDescription instrumentDescription = null;
                    //---------------------------------------------------------------------------------------//
                    //--- Check that its a valid Instrument Description document by trying to Marshall it ---//
                    //---------------------------------------------------------------------------------------//
                    try
                    {
                        instrumentDescription = InstrumentDescription.Deserialize( xmlContent );
                    }
                    catch (Exception err)
                    {
                        throw new Exception( string.Format( Resources.Invalid_Instrument_Description_File___0_,
                                                            err.Message ) );
                    }

                    //------------------------------------------------------------------------------------------------//
                    //--- Next check to see if the uuid already exists - if so ask if the user wants to replace it ---//
                    //------------------------------------------------------------------------------------------------//
                    String uuid = instrumentDescription.uuid;
                    if (DocumentManager.HasDocument( uuid ))
                    {
                        ok2Save = false;
                        if (DialogResult.Yes ==
                            MessageBox.Show(
                                Resources
                                    .This_Instrument_already_exists__would_you_like_to_overwrite_the_existing_Instrument_Description_,
                                Resources.Q_U_E_S_T_I_O_N,
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question ))
                        {
                            document = DocumentManager.GetDocument( uuid );
                            dataState = BASEBean.eDataState.DS_EDIT;
                            ok2Save = true;
                        }
                    }

                    //-------------------------//
                    //--- Save the document ---//
                    //-------------------------//
                    if (ok2Save)
                    {
                        SaveInstrumentDescriptionDocument( instrumentDescription, document, dataState );
                        //-----------------------------------------//
                        //--- If Addin new then add to the list ---//
                        //-----------------------------------------//
                        if (dataState == BASEBean.eDataState.DS_ADD)
                        {
                            AddDocumentToInstrumentList( document );
                        }
                        else
                        {
                            //-------------------------------------------------------------------//
                            //--- otherwise, find the existing doc in the list and replace it ---//
                            //-------------------------------------------------------------------//
                            UpdateExistingDocumentInList( document, uuid );
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show( err.Message );
            }
        }


        /**
         * Finds the document provided and updates the values listed appropriately.
         */
        private void UpdateExistingDocumentInList( Document document, String uuid )
        {
            foreach (ListViewItem lvi in lvInstruments.Items)
            {
                var doc = lvi.Tag as Document;
                if (doc.uuid.Equals( uuid ))
                {
                    lvi.Tag = document;
                    lvi.SubItems[0].Text = document.name;
                    lvi.SubItems[1].Text = document.Description;
                    lvi.SubItems[2].Text = document.version;
                    break;
                }
            }
        }


        /*
         * Handler for the Add Button click event
         */
        private void lvInstruments_OnAdd()
        {
            var form = new InstrumentForm();
            var instrumentDescription = new InstrumentDescription();
            form.InstrumentDescription = instrumentDescription;
            if (DialogResult.OK == form.ShowDialog())
            {
                instrumentDescription = form.InstrumentDescription;
                var document = new Document();
                SaveInstrumentDescriptionDocument( instrumentDescription, document, BASEBean.eDataState.DS_ADD );
                AddDocumentToInstrumentList( document );
                LoadInstrumentPreview();
            }
        }


        /*
         * Handler for the Edit Button click event
         */
        private void lvInstruments_OnEdit()
        {
            if (lvInstruments.HasSelected)
            {
                var document = lvInstruments.SelectedObject as Document;
                var form = new InstrumentForm();
                InstrumentDescription instrumentDescription =
                    InstrumentDescription.Deserialize( Encoding.UTF8.GetString( document.DocumentContent ) );
                form.InstrumentDescription = instrumentDescription;
                if (DialogResult.OK == form.ShowDialog())
                {
                    instrumentDescription = form.InstrumentDescription;
                    SaveInstrumentDescriptionDocument( instrumentDescription, document, BASEBean.eDataState.DS_EDIT );
                    UpdateExistingDocumentInList( document, instrumentDescription.uuid );
                    LoadInstrumentPreview();
                }
            }
        }


        /*
         * Handler for the Delete Button click event
         */
        private void lvInstruments_OnDelete()
        {
            if (lvInstruments.HasSelected)
            {
                var document = lvInstruments.SelectedObject as Document;
                if (document != null)
                {
                    String name = document.name;
                    String prompt = String.Format( MessageManager.getMessage( "Generic.delete.prompt" ),
                                                   Resources.Instrument_Description_Document, name );
                    String title = MessageManager.getMessage( "Generic.title.verification" );
                    if (DialogResult.Yes == MessageBox.Show( prompt,
                                                             title,
                                                             MessageBoxButtons.YesNo,
                                                             MessageBoxIcon.Question ))
                    {
                        document.DataState = BASEBean.eDataState.DS_DELETE;
                        DocumentManager.SaveDocument( document );
                        lvInstruments.RemoveSelectedItem();
                    }
                }
            }
        }


        /**
         * Call this method to save the document data to the database.
         */
        private static void SaveInstrumentDescriptionDocument( InstrumentDescription instrumentDescription,
                                                               Document document,
                                                               BASEBean.eDataState dataState )
        {
            var dbDocument = new dbDocument();
            String xml = instrumentDescription.Serialize();
            document.DocumentContent = dbDocument.documentContent = Encoding.UTF8.GetBytes( xml );
            dbDocument.documentSize = xml.Length;
            document.ContentType = dbDocument.contentType = ATMLContext.CONTEXT_TYPE_XML;
            dbDocument.DataState = dataState;
            if (dataState == BASEBean.eDataState.DS_ADD)
                dbDocument.dateAdded = DateTime.UtcNow;
            else if (dataState == BASEBean.eDataState.DS_EDIT)
                dbDocument.dateUpdated = DateTime.UtcNow;
            document.Description = dbDocument.documentDescription = instrumentDescription.Description;
            dbDocument.documentTypeId = (int) dbDocument.DocumentType.INSTRUMENT_DESCRIPTION;
            document.DocumentType = dbDocument.DocumentType.INSTRUMENT_DESCRIPTION;
            document.version = dbDocument.documentVersion = instrumentDescription.version;
            document.name = dbDocument.documentName = instrumentDescription.Identification.ModelName;
            dbDocument.UUID = Guid.Parse( instrumentDescription.uuid );
            document.uuid = instrumentDescription.uuid;
            dbDocument.save();
        }


        private void lvInstruments_Resize( object sender, EventArgs e )
        {
            lvInstruments.SetDistributedColumnWidths();
        }


        /**
         * Loads the Instrument List View from the Documents database table where the document type id equals 1 (instrument_description)
         */
        public void LoadInstruments()
        {
            try
            {
                List<Document> documents =
                    DocumentManager.GetDocumentsByType( (int) dbDocument.DocumentType.INSTRUMENT_DESCRIPTION );
                if (documents != null)
                {
                    foreach (Document document in documents)
                    {
                        AddDocumentToInstrumentList( document );
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show( err.Message );
            }
        }


        /**
         * Adds the provides document to the instrument list view.
         */
        private void AddDocumentToInstrumentList( Document document )
        {
            var lvi = new ListViewItem( document.name );
            lvi.SubItems.Add( document.Description );
            lvi.SubItems.Add( document.version );
            lvi.Tag = document;
            lvInstruments.Items.Add( lvi );
        }


        private void lvInstruments_SelectedIndexChanged( object sender, EventArgs e )
        {
            if (SelectedInstrumentChanged != null)
                SelectedInstrumentChanged( sender, e );
            LoadInstrumentPreview();
        }


        /**
         * Builds a preview of the selected instrument using the instrument's xml document and an xsl 
         * style sheet for formatting the xml into an html representation.
         */
        private void LoadInstrumentPreview()
        {
            Document xmlInstrument = SelectedInstrument;
            Document xslInstrument = DocumentManager.GetDocument( "{534E7F26-EF92-470C-B357-A09DD96AC0DD}" );
            if (xmlInstrument != null && xslInstrument != null)
            {
                TextWriter tw = new StringWriter();
                var srXml = new StringReader( Encoding.UTF8.GetString( xmlInstrument.DocumentContent ) );
                var srXsl = new StringReader( Encoding.UTF8.GetString( xslInstrument.DocumentContent ) );
                XmlReader xrXsl = new XmlTextReader( srXsl );
                XmlReader xrXml = new XmlTextReader( srXml );
                XmlWriter xwXml = new XmlTextWriter( tw );
                var myXslTrans = new XslCompiledTransform();
                myXslTrans.Load( xrXsl );
                myXslTrans.Transform( xrXml, xwXml );
                webBrowser.DocumentText = tw.ToString();
            }
        }
    }
}