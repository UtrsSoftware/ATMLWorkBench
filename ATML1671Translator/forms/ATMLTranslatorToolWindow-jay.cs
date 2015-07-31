/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
//using Microsoft.WindowsAPICodePack.Dialogs;
//using Ookii.Dialogs;
using ATMLCommonLibrary.managers;
using ATMLCommonLibrary.model;
using ATMLCommonLibrary.model.navigator;
using ATMLProject.managers;
using ATMLUtilitiesLibrary;
using WeifenLuo.WinFormsUI.Docking;

namespace ATML1671Translator.forms
{
    public partial class ATMLTranlatorToolWindowJay : DockContent, IATMLDockableWindow
    {
        public ATMLTranlatorToolWindowJay(ATMLNavigator i)
        {
            InitializeComponent();
        }

        private static bool _STACKPRINT = false;
        private static int  _INDENTLENGTH = 3;
        private static bool _FLAGREQUIRE = true;
        private static bool _FLAGAPPLY = true;

        private static String defaultPath = @"C:\Users\jjohnson\Desktop\SBIR\TPSs\";

        private static char srcDelimiter = ',';
        private static char srcTerminator = '$';
        private static char srcTab = '\t';
        String strUsing = "USING";
        String strComplexSignal = "COMPLEX SIGNAL";
        String strMax = "MAX";
        String strCNX = "CNX";
        private static String strMessage = "MESSAGE";
        String strRange = "RANGE";
        String strTo = "TO";
        String strContinuous = "CONTINUOUS";
        String strBy = "BY";

        public static Dictionary<String, int> pinDescriptors = new Dictionary<String, int>()
        {
	        {"HI", 0}, {"LO", 0}, {"VIA", 0},
	        {"A", 0}, {"B", 0}, {"C", 0}, {"N", 0},
	        {"TRUE", 0}, {"COMPL", 0},
	        {"TO", 0}, {"FROM", 0},
	        {"SCREEN", 0}, {"GUARD", 0},
	        {"X", 0}, {"Y", 0}, {"Z", 0},
	        {"S1", 0}, {"S2", 0}, {"S3", 0}, {"S4", 0},
	        {"R1", 0}, {"R2", 0}, {"R3", 0}, {"R4", 0}
	    };

        public static Dictionary<String, int> requireIO = new Dictionary<String, int>()
        {
            {"I-O DEVICE", 0},
            {"I-O FILE", 0},
            {"INPUT DEVICE", 0},
            {"OUTPUT DEVICE", 0},
            {"OUTPUT FILE", 0}
        };

        public static Dictionary<String, int> requireNoParam = new Dictionary<String, int>()
        {
	        {"ANALOG", 0},
	        {"BUILT-IN", 0},
	        {"CIRCULATE", 0},
	        {"CNX", 0},
	        {"COUPLING", 0},
	        {"COUPLING-REF", 0},
	        {"FILE-ORGANIZATION", 0},
	        {"FILE-FORM", 0},
	        {"MODE", 0},
	        {"PASS", 0},
	        {"RECORD-TYPE", 0},
	        {"REF-SOURCE", 0},
            {"SOURCE-IDENTIFIER", 0},
	        {"SWEEP-TYPE", 0},
	        {"TRIG-OUT-DRIVE", 0}
	    };

        public static Dictionary<String, int> requireParamList = new Dictionary<String, int>()
        {
	        {"COUPLING", 0},
	        {"COUPLING-REF", 0},
	        {"FREQ-DEV", 0},
	        {"PHASE-ANGLE", 0},
	        {"PHASE-ANGLE-PHASE-A", 0},
	        {"PHASE-ANGLE-PHASE-B", 0},
	        {"PHASE-ANGLE-PHASE-C", 0},
	        {"RES", 0},
	        {"TEST-EQUIP-IMP", 0},
	        {"TEST-EQUIP-IMP-REF", 0},
	        {"VOLTAGE", 0},
	        {"VOLTAGE-REF", 0}
	    };

        public static Dictionary<String, int> videoHorizontalTiming = new Dictionary<String, int>()
	    {
	        {"RATE", 0},
	        {"ACTIVE", 0},
	        {"BLANK", 0},
	        {"TOTAL", 0},
	        {"FRONT-PORCH", 0},
	        {"PULSE-WIDTH", 0},
	        {"SIZE", 0}
	    };

        public static Dictionary<String, int> videoVerticalTiming = new Dictionary<String, int>()	    
	    {
	        {"RATE", 0},
	        {"ACTIVE", 0},
	        {"BLANK", 0},
	        {"TOTAL", 0},
	        {"FRONT-PORCH", 0},
	        {"PULSE-WIDTH", 0},
	        {"SIZE", 0},
	        {"NON-INTERLACE", 0},
	        {"INTERLACE", 0}
	    };

        public static Dictionary<String, int> videoSync = new Dictionary<String, int>()
	    {
	        {"ON-VIDEO", 0},
	        {"EQ-BEFORE", 0},
	        {"EQ-AFTER", 0},
	        {"TYPE", 0},
	        {"SERRATION", 0},
	        {"PULSE-WIDTH", 0},
	        {"SWING", 0}
	    };


        public static Dictionary<String, int> videoSyncPolarity = new Dictionary<String, int>()	    
	    {
	        {"HORIZONTAL", 0},
	        {"VERTICAL", 0},
	        {"COMPOSITE", 0}
	    };

        public static Dictionary<String, int> videoVideo = new Dictionary<String, int>()
	    {
	        {"PEDESTAL", 0},
	        {"SWING", 0},
	        {"BIAS", 0},
	        {"GAMMA", 0}
	    };
        
        public static Dictionary<String, int> videoDraw = new Dictionary<String, int>()	    
	    {
	        {"WIDTH", 0},
	        {"HEIGHT", 0},
	        {"X1", 0},
	        {"X2", 0},
	        {"X3", 0},
	        {"XBOXES", 0},
	        {"Y1", 0},
	        {"Y2", 0},
	        {"Y3", 0},
	        {"YBOXES", 0},
	        {"FILL-COLOR", 0},
	        {"FILL-PATT", 0},
	        {"FONT", 0},
	        {"CHAR-CODE", 0}
	    };

        public static Dictionary<String, Dictionary<String, int>> requireMultiLineParams = new Dictionary<String, Dictionary<String, int>>()
	    {
	        {"HORIZONTAL-TIMING", videoHorizontalTiming},
	        {"VERTICAL-TIMING", videoVerticalTiming},
	        {"SYNC", videoSync},
	        {"SYNC-POLARITY", videoSyncPolarity},
	        {"VIDEO", videoVideo},
	        {"DRAW", videoDraw}
	    };

        public static Dictionary<String, int> applyNoParam = new Dictionary<String, int>()
        {
	        {"ANGLE", 0}, // 130500 -> ANGLE 'AZIMUTH' DEG ERRLMT +-0.0003 DEG
	        {"CURRENT-PHASE-A", 0},
	        {"CURRENT-PHASE-B", 0},
	        {"CURRENT-PHASE-C", 0},
	        {"GATED", 0},
	        {"REF-SOURCE", 0},
	        {"STIM", 0},
	        {"TRIG-OUT-DRIVE", 0},
	        {"VALUE", 0}
        };

        public static Dictionary<String, Dictionary<String, int>> applyMultiLineParams = new Dictionary<String, Dictionary<String, int>>()
	    {
	        {"HORIZONTAL-TIMING", videoHorizontalTiming},
	        {"VERTICAL-TIMING", videoVerticalTiming},
	        {"SYNC", videoSync},
	        {"SYNC-POLARITY", videoSyncPolarity},
	        {"VIDEO", videoVideo},
	        {"DRAW", videoDraw}
	    };

        public static Dictionary<String, int> requireFields = new Dictionary<String, int>()
        {
            {"CONTROL", 0},
            {"CAPABILITY", 0},
            {"LIMIT", 0},
            {"CNX", 0}
        };

        public static Dictionary<String, int> applyFields = new Dictionary<String, int>()
        {
            {"GATED", 0},
            {"CNX", 0}
        };

        public static string Serialize<T>(T value)
        {
            if (value == null)
            {
                return null;
            }

            Boolean unicode = false;

            MemoryStream memoryStream = new MemoryStream();

            XmlWriterSettings settings = new XmlWriterSettings();

            if (unicode)
            {
                settings.Encoding = new UnicodeEncoding(false, false); // no BOM in a .NET string
            }
            else
            {
                settings.Encoding = new UTF8Encoding(false);
            }
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.Indent = true;
            settings.OmitXmlDeclaration = false;

            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream, settings))
            {
                serializer.Serialize(xmlWriter, value);
            }

            if (unicode)
            {
                return Encoding.Unicode.GetString(memoryStream.ToArray());
            }
            else
            {
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        public static T Deserialize<T>(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return default(T);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
/*
            XmlReaderSettings settings = new XmlReaderSettings();
            // No settings need modifying here

            using (StringReader stringReader = new StringReader(xml))
            {
                using (XmlReader xmlReader = XmlReader.Create(stringReader, settings))
                {
                    return (T)serializer.Deserialize(xmlReader);
                }
            }
*/
            // XmlTextReader allows proper display of newlines contained in string elements
            using (StringReader stringReader = new StringReader(xml))
            {
                using (XmlTextReader xmlTextReader = new XmlTextReader(stringReader))
                {
                    return (T)serializer.Deserialize(xmlTextReader);
                }
            }

        }

        public static List<string> ProcessDirectory(List<string> fileList, string targetDirectory)
        {
            // Process the list of files found in the directory. 
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                fileList = ProcessFile(fileList, fileName);

            // Recurse into subdirectories of this directory. 
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                fileList = ProcessDirectory(fileList, subdirectory);

            return fileList;
        }

        public static List<string> ProcessFile(List<string> fileList, string path)
        {
            fileList.Add(path);
            return fileList;
        }







        private void btnExtractATLAS_Click(object sender, EventArgs e)
        {

            string selectedPath;

            List<string> filenameList;

            if (FileManager.OpenFolder(out selectedPath))
            {
                // clear text windows
                txtInput.Clear();
                txtOutput.Clear();

                string selPath = selectedPath;

                filenameList = FileManager.GetFolderNames(selectedPath);
                
                string aluDirOut = selPath + @"_xml\alu\"; // set directory of output files
                string aseDirOut = selPath + @"_xml\ase\"; // set directory of output files
                string fileExt;

                List<String> luInputFileList = new List<String>();
                OutputLU luOutput;
                List<String> luOutputFileList = null;
                List<String> asInputFileList = new List<String>();
                List<String> asOutputFileList = null;
                List<String> errInputFileList = new List<String>();
                List<String> errOutputFileList = null;

                String xmlStr;
                Boolean firstFlag = true;

                if (Directory.Exists(selPath))
                {
                    // This path is a directory
                    filenameList = ProcessDirectory(filenameList, selPath);
                }
                else
                {
                    Console.WriteLine("{0} is not a valid file or directory.", selPath);
                }

                foreach (string filePath in filenameList)
                {
                    fileExt = Path.GetExtension(filePath);
                    switch (fileExt)
                    {
                        case ".as":
                        case ".atl":
                            asInputFileList.Add(filePath);
                            break;
                        case ".lu":
                            luInputFileList.Add(filePath);
                            break;
                        default:
                            errInputFileList.Add(filePath);
                            break;
                    }
                }

                // process lookup files
                luOutput = ProcessFiles_lu(luInputFileList, aluDirOut, selPath);
                luOutputFileList = luOutput.luFiles;

//                foreach (KeyValuePair<string, SortedDictionary<string, string>> sd in luOutput.luSD)
//                {
//                    txtInput.AppendText(Environment.NewLine + sd.Key + Environment.NewLine + "====================" + Environment.NewLine);
//
//                    foreach (KeyValuePair<string, string> d in sd.Value)
//                    {
//                        txtInput.AppendText(d.Key + " -> " + d.Value + Environment.NewLine);
//                    }
//                }
//
                if (luOutput.luSD.ContainsKey("18d4205-1"))
                {
                    if (luOutput.luSD["18d4205-1"].ContainsKey("FTICINTTRIGVIA604NC2"))
                    {
                        Console.WriteLine("1>>>>> " + luOutput.luSD["18d4205-1"]["FTICINTTRIGVIA604NC2"]);
                    }
                }

                if (luOutput.luSD.ContainsKey("18d4605-1"))
                {
                    if (luOutput.luSD["18d4605-1"].ContainsKey("DMMHIR3-HI"))
                    {
                        Console.WriteLine("2>>>>> " + luOutput.luSD["18d4605-1"]["DMMHIR3-HI"]);
                    }
                }             

                // process test program files
                asOutputFileList = ProcessFiles_as(asInputFileList, aseDirOut, selPath, luOutput.luSD, luOutput.dupSD);

                // process test program files
                errOutputFileList = ProcessFiles_err(errInputFileList);

                //display output to screen
                firstFlag = true;
                // display XML for lookup files
                if (luOutputFileList != null)
                {
                    foreach (String luOutputFile in luOutputFileList)
                    {
                        if (firstFlag) // if first file being output 
                        {// update flag without adding white space
                            firstFlag = false;
                        }
                        else
                        {// add white space between results
                            txtOutput.AppendText(Environment.NewLine);
                        }

                        xmlStr = System.IO.File.ReadAllText(luOutputFile);
                        //LookupCatalog luXML = Deserialize<LookupCatalog>(xmlStr);
                        //txtOutput.AppendText(xmlStr + Environment.NewLine);
                        txtOutput.AppendText(luOutputFile + Environment.NewLine);
                    }
                }

                // display XML for test program files
                if (asOutputFileList != null)
                {
                    foreach (String asOutputFile in asOutputFileList)
                    {
                        if (firstFlag) // if first file being output 
                        {// update flag without adding white space
                            firstFlag = false;
                        }
                        else
                        {// add white space between results
                            txtOutput.AppendText(Environment.NewLine);
                        }

                        xmlStr = System.IO.File.ReadAllText(asOutputFile);
                        //AtlasSourceExtract tpXML = Deserialize<AtlasSourceExtract>(xmlStr);
                        //txtOutput.AppendText(xmlStr + Environment.NewLine);
                        txtOutput.AppendText(asOutputFile + Environment.NewLine);
                    }
                }
            } // if DialogResult.OK            
        } // btnExtractATLAS_Click

        public static OutputLU ProcessFiles_lu(List<String> luInputFileList, String fileDirOut, String baseDir)
        {
            OutputLU luOutput = new OutputLU();
            luOutput.luFiles = null;
            luOutput.luSD = null;
            luOutput.dupSD = null;

            if (luInputFileList.Count > 0)
            {
                luOutput.luFiles = new List<String>();
                luOutput.luSD = new SortedDictionary<String, SortedDictionary<String, SortedDictionary<String, String>>>();
                luOutput.dupSD = new SortedDictionary<String, SortedDictionary<String, SortedDictionary<String, List<String>>>>();

                // get references to text windows on active form
                ATMLTranlatorToolWindowJay.ActiveForm.Activate();
                TextBox frmTxtInput = (TextBox)ATMLTranlatorToolWindowJay.ActiveForm.Controls["txtInput"];
                TextBox frmTxtOutput = (TextBox)ATMLTranlatorToolWindowJay.ActiveForm.Controls["txtOutput"];

                String fileName;
                String fileWoExt;
                string parentDir;
                string tpsDir;
                String tmpStr;
                String tmpLabel;
                String tmpSsname;
                List<String[]> inputArrList;
                List<String[]> lineArrList;
                String line;
                String[] lineArr;
                String subfileStr = " SUBFILE";
                String subfile;

                List<LookupCatalog> lcList = new List<LookupCatalog>();
                LookupCatalog atlas_lu;
                Lookupfile luFile = null;
                List<Lookup> luList;
                Lookup lu;

                Boolean firstFlag = true;
                string xmlStr;
                string xmlDir;
                string xmlPath;

                foreach (String filePath in luInputFileList)
                {
                    fileName = System.IO.Path.GetFileName(filePath);
                    fileWoExt = System.IO.Path.GetFileNameWithoutExtension(filePath);

                    parentDir = Directory.GetParent(filePath).ToString();
                    if (parentDir == baseDir)
                    {
                        tpsDir = parentDir.Replace(Directory.GetParent(parentDir).ToString() + @"\", "");
                    }
                    else
                    {
                        tpsDir = parentDir.Replace(baseDir + @"\", "");
                    }

                    inputArrList = new List<String[]>();
                    lineArrList = new List<String[]>();

SortedDictionary<String, String> tmpSD = new SortedDictionary<String, String>();
SortedDictionary<String, List<String>> tmpDupSD = new SortedDictionary<String, List<String>>();
List<String> dupList = new List<String>();
String sdVal;
String dupStr;

                    atlas_lu = new LookupCatalog();
                    atlas_lu.Lookupfile = new Lookupfile();
                    luFile = new Lookupfile();
                    luFile.tpsname = tpsDir;
                    luFile.tablename = fileWoExt;
                    luFile.filename = fileName;

                    try
                    {
                        using (StreamReader sr = new StreamReader(filePath))
                        {
                            line = sr.ReadLine();
                            subfile = "";
                            while (line != null)  //remove comments and headers
                            {
                                if (! line.StartsWith("*"))
                                {
                                    if (!(String.IsNullOrWhiteSpace(line) || line.Contains(subfileStr) || line.StartsWith(((char)26).ToString())))
                                    {
                                        lineArr = new String[2];
                                        lineArr[0] = line;
                                        lineArr[1] = subfile;
                                        inputArrList.Add(lineArr);
                                    }
                                    else if (line.Contains(subfileStr))
                                    {
                                        subfile = line.Substring(line.IndexOf(subfileStr) + subfileStr.Length).Trim();
                                    }
                                }
                                line = sr.ReadLine();
                            }
                            sr.Close();
                        } // using
                    } // try
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine + ex.StackTrace);
                    }

                    if (inputArrList.Count > 0)
                    {
                        String[] tmpLineArr;
                        foreach (String[] tmpArr in inputArrList) // process multi-line definitions
                        {
                            if (!(tmpArr[0].StartsWith(" ") || tmpArr[0].StartsWith(srcTab.ToString()))) // line does not start with a space or a tab
                            {
                                lineArrList.Add(tmpArr);
                            }
                            else
                            {
                                tmpLineArr = lineArrList.ElementAt(lineArrList.Count - 1); // get last list item
                                tmpLineArr[0] = tmpLineArr[0] + " " + tmpArr[0].Trim(); // append current line
                                lineArrList.RemoveAt(lineArrList.Count - 1);
                                lineArrList.Add(tmpLineArr);
                            }
                        }

                        lu = null;
                        luList = new List<Lookup>();
                        foreach (String[] tmpArr in lineArrList)  //process lookup entries
                        {
                            // extract label and ssname
                            tmpStr = Regex.Replace(tmpArr[0], @"\s+", " "); // replace all whitespace with " "
                            tmpLabel = Regex.Replace(tmpStr.Substring(0, tmpStr.IndexOf(' ')).Trim(), @"\s+", " ");
                            tmpSsname = Regex.Replace(tmpStr.Substring(tmpStr.IndexOf(' ') + 1).Trim(), @"\s+", " ");

                            // add lookup entries to XML
                            lu = new Lookup();
                            lu.label = tmpLabel;
                            lu.ssname = tmpSsname;
                            lu.subfile = tmpArr[1];
                            luList.Add(lu);

                            // add lookup entries to dictionary
                            if (!tmpSD.ContainsKey(tmpLabel)) // if key does not exist in dictionary
                            {
                                tmpSD.Add(tmpLabel, tmpSsname);
                            }
                            else // update duplicates list
                            {
                                // if first entry is not in dup list, add to list
                                if (tmpSD.TryGetValue(tmpLabel, out sdVal))
                                {
                                    dupStr = String.Format("{0} => {1}", tmpLabel, sdVal);
                                    if (!dupList.Contains(dupStr) && !dupList.Contains(dupStr + " *"))
                                    {
                                        dupList.Add(dupStr + " *");
                                    }
                                }
                                Console.WriteLine("Duplicate Key: " + tmpLabel + " => " + tmpSsname + " [" + tmpLabel + " => " + sdVal + "] ");
                                dupList.Add(String.Format("{0} => {1}", tmpLabel, tmpSsname));
                            }
                        } // foreach

                        if (firstFlag) // if first file being output 
                        {// update flag without adding white space
                            firstFlag = false;
                        }
                        else
                        {// add white space between results
                            frmTxtInput.AppendText(Environment.NewLine + Environment.NewLine);
                        }

                        // print SortedDictionary in alphabetic order
                        foreach (KeyValuePair<String, String> p in tmpSD)
                        {
//                            frmTxtResults.AppendText(String.Format("{0} => {1}", p.Key, p.Value) + Environment.NewLine);
                        }

                        // print Duplicate Keys
                        frmTxtInput.AppendText(Environment.NewLine);
                        frmTxtInput.AppendText("Duplicate(s)" + Environment.NewLine);
                        if (dupList.Count > 0)
                        {
                            dupList.Sort();
                            foreach (Object dup in dupList)
                            {
                                frmTxtInput.AppendText(String.Format("{0}", dup) + Environment.NewLine);
                            }
                        }
                        else
                        {
                            frmTxtInput.AppendText("NONE" + Environment.NewLine);
                        }

                        //add to master lookup dictionary
                        if (luOutput.luSD.ContainsKey(tpsDir))
                        {
                            luOutput.luSD[tpsDir].Add(fileWoExt, tmpSD);
                        }
                        else
                        {
                            luOutput.luSD.Add(tpsDir, new SortedDictionary<string, SortedDictionary<string, string>>());
                            luOutput.luSD[tpsDir].Add(fileWoExt, tmpSD);
                        }

                        //add to master duplicate dictionary
                        if (luOutput.dupSD.ContainsKey(tpsDir))
                        {
                            luOutput.dupSD[tpsDir].Add(fileWoExt, tmpDupSD);
                        }
                        else
                        {
                            luOutput.dupSD.Add(tpsDir, new SortedDictionary<string, SortedDictionary<string, List<string>>>());
                            luOutput.dupSD[tpsDir].Add(fileWoExt, tmpDupSD);
                        }
                        luFile.Lookuptable = luList.ToArray();
                    } // if inputArrList.Count > 0
                    atlas_lu.Lookupfile = luFile;
                    lcList.Add(atlas_lu);
                } // foreach in luInputFileList

                // output XML for lookup catalog
                foreach (LookupCatalog lcOutput in lcList)
                {
                    xmlStr = Serialize<LookupCatalog>(lcOutput);
//////// modify destination path
                    xmlDir = fileDirOut + lcOutput.Lookupfile.tpsname;
                    xmlPath = xmlDir + @"\" + lcOutput.Lookupfile.tablename + "_alu.xml";

                    try
                    {// Determine whether the directory exists. 
                        if (!Directory.Exists(xmlDir))
                        {// Try to create the directory.
                            DirectoryInfo di = Directory.CreateDirectory(xmlDir);
                        }
                        File.WriteAllText(xmlPath, xmlStr);
                        luOutput.luFiles.Add(xmlPath);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Could not create output directory: {0}", e.ToString());
                    }
                }
            } // if luInputFileList.Count > 0
            return luOutput;
        } // ProcessFiles_lu

        public static List<String> ProcessFiles_as(List<String> asInputFileList, String fileDirOut, String baseDir,
            SortedDictionary<String, SortedDictionary<String, SortedDictionary<String, String>>> luSD,
            SortedDictionary<String, SortedDictionary<String, SortedDictionary<String, List<String>>>> dupSD)
        {
            List<String> asOutputFileList = null;

            if (asInputFileList.Count > 0)
            {
                asOutputFileList = new List<String>();

                // get references to text windows on active form
                ATMLTranlatorToolWindowJay.ActiveForm.Activate();
                TextBox frmTxtInput = (TextBox)ATMLTranlatorToolWindowJay.ActiveForm.Controls["txtInput"];
                TextBox frmTxtOutput = (TextBox)ATMLTranlatorToolWindowJay.ActiveForm.Controls["txtOutput"];

                String fileName;
                String fileExt;
                String fileWoExt;
                String fileDirIn;
                string parentDir;
                string tpsDir;

                List<AtlasSourceExtract> aseList = new List<AtlasSourceExtract>();
                AtlasSourceExtract atlas_ase = new AtlasSourceExtract();
                List<ASESourcefile> sourcefileList = new List<ASESourcefile>();
                ASESourcefile sourcefile = null;
                List<ASEStatement> statList = null;
                ASEStatement stat = null;
                String currLine = null;
                String nextLine = null;

                string xmlStr;
                string xmlDir;
                string xmlPath;

                int linecnt = 0;
                foreach (String filePath in asInputFileList)
                {
                    fileName = System.IO.Path.GetFileName(filePath);
                    fileExt = System.IO.Path.GetExtension(filePath);
                    fileWoExt = System.IO.Path.GetFileNameWithoutExtension(filePath);
                    fileDirIn = System.IO.Path.GetDirectoryName(filePath);

                    parentDir = Directory.GetParent(filePath).ToString();
                    if (parentDir == baseDir)
                    {
                        tpsDir = parentDir.Replace(Directory.GetParent(parentDir).ToString() + @"\", "");
                    }
                    else
                    {
                        tpsDir = parentDir.Replace(baseDir + @"\", "");
                    }

frmTxtInput.AppendText(fileName + " -> " + fileDirIn + @"\" + fileWoExt + fileExt + Environment.NewLine);

                    if (String.IsNullOrEmpty(atlas_ase.tpsfile))
                    {// first tp being processed, tpsname has not been set
                        atlas_ase.tpsname = tpsDir;
                        atlas_ase.tpsfile = fileWoExt;
                    }
                    else if (!fileWoExt.Contains(atlas_ase.tpsfile + "_"))
                    {// if file is first file of new tp
                        // add curr tp to tpeList
                        atlas_ase.sourcefiles = sourcefileList.ToArray();
                        aseList.Add(atlas_ase);
                        // init new tp
                        linecnt = 0;
                        sourcefileList = new List<ASESourcefile>();
                        atlas_ase = new AtlasSourceExtract();
                        atlas_ase.tpsname = tpsDir;
                        atlas_ase.tpsfile = fileWoExt;
                    }

                    sourcefile = new ASESourcefile();
                    sourcefile.filename = fileName;
                    statList = new List<ASEStatement>();

                    try
                    {
                        using (StreamReader sr = new StreamReader(filePath))
                        {
                            List<String> lineList;
                            String prevTestno = "";
                            String currTestno = "";

                            lineList = new List<String>();
                            currLine = sr.ReadLine();
                            nextLine = sr.ReadLine();

                            while (currLine != null)
                            {
                                while (currLine != null && (String.IsNullOrWhiteSpace(currLine) || currLine.Equals(" ") || currLine.StartsWith(((char)26).ToString())))
                                {
                                    currLine = nextLine;
                                    nextLine = sr.ReadLine();
                                }

                                if (currLine != null && !String.IsNullOrWhiteSpace(currLine))
                                {
                                    if (currLine.Contains("LEAVE ATLAS"))
                                    {
                                        while (currLine != null && !nextLine.Contains("RESUME ATLAS"))
                                        {
                                            lineList.Add(currLine);
                                            currLine = nextLine;
                                            nextLine = sr.ReadLine();
                                        }
                                        lineList.Add(currLine);
                                    }
                                    else
                                    {
                                        while (currLine != null && !currLine.Contains(srcTerminator.ToString()) && !nextLine.StartsWith("C")) // use Contains instead of EndsWith, there may be whitespace after $
                                        {
                                            lineList.Add(currLine);
                                            currLine = nextLine;
                                            nextLine = sr.ReadLine();
                                        }
                                        lineList.Add(currLine);
                                    }

                                    //process lineList
                                    linecnt++;
                                    if (lineList[0].Contains(srcTab)) // if line contains tabs
                                    {
                                        if (lineList[0].StartsWith(srcTab.ToString()))
                                        {
                                            lineList[0] = "        " + lineList[0].Substring(1);
                                        }
                                        else if (lineList[0].ToUpper().StartsWith("C" + srcTab))
                                        {
                                            lineList[0] = "C " + lineList[0].Substring(2);
                                        }
                                        else if (lineList[0].IndexOf(srcTab) > 0 && lineList[0].IndexOf(srcTab) < 10)
                                        {
                                            int tabIndex = lineList[0].IndexOf(srcTab);
                                            int trmIndex = lineList[0].IndexOf(srcTerminator);
                                            if (!lineList[0].Contains(srcTerminator) || (lineList[0].Contains(srcTerminator) && tabIndex < trmIndex))
                                            {
                                                lineList[0] = lineList[0].Substring(0, tabIndex) + " " + lineList[0].Substring(tabIndex + 1);
                                            }
                                            else
                                            {
                                                lineList[0] = lineList[0].Substring(0, trmIndex + 1);
                                            }
                                        }
                                    }

                                    if (!(lineList[0].ToUpper().StartsWith("C") || lineList[0].ToUpper().StartsWith("B"))) // if not a comment line or goto label
                                    {
                                        currTestno = lineList[0].Substring(1, 4);
                                        if (currTestno.Equals("    "))
                                        {
                                            currTestno = prevTestno;
                                        }
                                        else
                                        {
                                            prevTestno = currTestno;
                                        }
                                    }
                                    stat = getStatement(lineList, linecnt, currTestno);
                                    statList.Add(stat);

                                    // reset lineList to process resume atlas line
                                    lineList = new List<String>();

                                    // read data from file
                                    currLine = nextLine;
                                    nextLine = sr.ReadLine();
                                } // if currLine not null
                            }
                            sr.Close();

                            sourcefile.statements = statList.ToArray();
                            sourcefileList.Add(sourcefile);
                        } // using

                    } // try
                    catch (Exception ex)
                    {
                        MessageBox.Show("[" + currLine + "]" + Environment.NewLine + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + ex.StackTrace);
                    }
                } // foreach in asInputFileList

                // add last tp to tpeList
                atlas_ase.sourcefiles = sourcefileList.ToArray();
                aseList.Add(atlas_ase);

                // output XML for test programs
                foreach (AtlasSourceExtract tpeOutput in aseList)
                {
                    xmlStr = Serialize<AtlasSourceExtract>(tpeOutput);
//////// modify destination
                    xmlDir = fileDirOut + tpeOutput.tpsname;
                    xmlPath = xmlDir + @"\" + tpeOutput.tpsfile + "_ase.xml";

                    try
                    {// Determine whether the directory exists. 
                        if (!Directory.Exists(xmlDir))
                        {// Try to create the directory.
                            DirectoryInfo di = Directory.CreateDirectory(xmlDir);
                        }
                        File.WriteAllText(xmlPath, xmlStr);
                        asOutputFileList.Add(xmlPath);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Could not create output directory: {0}", e.ToString());
                    }
                }
            } // if asInputFileList.Count > 0
            return asOutputFileList;
        } // ProcessFiles_as

        public static ASEStatement getStatement(List<String> lineList, int linecnt, string currTestno)
        {
            ASEStatement stat = new ASEStatement();
            stat.lineno = linecnt;
            stat.linenoSpecified = true;
            stat.flag = lineList[0].Substring(0, 1).ToUpper().Replace("\t", " ");

             if (stat.flag.Equals("C") || stat.flag.Equals("B") || lineList[0].Equals(" ")
                || lineList[0].Trim().Equals(srcTerminator.ToString()))
            {
                // line is a comment, goto label, or blank
                // do not set verb
                // do not set Statno

                if (stat.flag.Equals("C") || stat.flag.Equals("B"))
                {
                    stat.remainder = getCommentRemainder(lineList);
                }
                else
                {
                    stat.remainder = "";
                }
                stat.source = getStatementSource(stat);
            }
            else
            {
                stat.statno = new ASEStatno();
                stat.statno.Value = getStatno(lineList[0]);
                stat.statno.testno = stat.statno.Value.Substring(0, 4).Trim();
                stat.statno.stepno = stat.statno.Value.Substring(4, 2).Trim();
                if (String.IsNullOrWhiteSpace(stat.statno.testno) && !String.IsNullOrWhiteSpace(stat.statno.stepno))
                {
                    stat.statno.testno = currTestno;
                }
                stat.verb = getStatementVerb(lineList[0]);
                stat.remainder = getStatementRemainder(lineList);
                stat.source = getStatementSource(stat);
                // update statno after getting original statement contents
                if (stat.statno.Value.Contains(" ") && !String.IsNullOrWhiteSpace(stat.statno.Value))
                {
                    stat.statno.Value = stat.statno.testno + stat.statno.stepno;
                }
            }
            return stat;
        } // getStatement

        public static String getStatno(String str)
        {
            String tmpStr = str.Substring(1);
            String statno = "";
            int statnoStart = 0;
            int statnoEnd = Array.FindIndex(tmpStr.ToCharArray(), x => !(char.IsWhiteSpace(x) || char.IsDigit(x))); //get index of first letter

            if (!String.IsNullOrWhiteSpace(tmpStr.Substring(statnoStart, statnoEnd)))
            {
                statno = tmpStr.Substring(statnoStart, statnoEnd - statnoStart).Trim();
            }
            return statno.PadLeft(6);
        } // getStatno

        public static String getStatementVerb(String str)
        {
            String verb;
            String tmpStr = str.Substring(1).TrimStart(); //trim leading space before statno
            int firstSpace = tmpStr.IndexOf(' '); //get index of first space after statno
            int firstChar = Array.FindIndex(tmpStr.ToCharArray(), x => !(char.IsWhiteSpace(x) || char.IsDigit(x))); //get index of first letter
            int verbStart;
            int verbEnd;
            
            if (tmpStr.Contains(srcDelimiter))
            {
                verbEnd = tmpStr.IndexOf(srcDelimiter);
            }
            else
            {
                if (str.Contains(srcTerminator.ToString()))
                {
                    verbEnd = tmpStr.IndexOf(srcTerminator);
                }
                else
                {
                    verbEnd = tmpStr.Length;
                }
            }

            if (firstSpace > 0 && firstSpace < firstChar && firstSpace < verbEnd) //first space is before first letter and end of verb
            {
                verbStart = firstSpace;
            }
            else
            {
                verbStart = 0;
            }
            verb = tmpStr.Substring(verbStart, verbEnd - verbStart).Trim();

            return verb;
        } // getStatementVerb

        public static String getStatementRemainder(List<String> al)
        {
            StringBuilder strbuf = new StringBuilder();
            String str = "";
            String tmpVerb;
            bool messageFlag = false;

            for (int i = 0; i < al.Count; i++)
            {
                if (i == al.Count - 1 && al[i].Contains(srcTerminator.ToString())) // use Contains instead of EndsWith, there may be whitespace after $
                { //if last or only line
                        str = al[i].Substring(0, al[i].IndexOf(srcTerminator));
                }
                else
                {
                    str = al[i];
                }

                if (i == 0) //if first line
                { //add contents after verb to remainder string
                    if (str.IndexOf(srcDelimiter) > 0)
                    { //if delimiter exists after verb
                        str = Regex.Replace(str.Substring(str.IndexOf(srcDelimiter) + 1).Trim(), @"\s+", " ");
                    }
                    else
                    { //no delimiter or remainder for ELSE and FINISH verbs
                        str = "";
                    }
                }
                else
                { //trim additional lines and add to remainder string
                    tmpVerb = getStatementVerb(al[0]);
                    if (tmpVerb.Equals("OUTPUT") || tmpVerb.Contains("LEAVE ATLAS") || (tmpVerb.Equals("DEFINE") && messageFlag))
                    {
                        str = Environment.NewLine + str.TrimEnd();
                    }
                    else
                    {
                        str = " " + Regex.Replace(str.Trim(), @"\s+", " ");
                    }
                }
                strbuf.Append(str);

                if (al[i].Contains(", MESSAGE,"))
                {
                    messageFlag = true;
                }
            }
            return strbuf.ToString().Trim();
        } // getStatementRemainder

        public static String getCommentRemainder(List<String> al)
        {
            StringBuilder strbuf = new StringBuilder();
            String str = "";

            for (int i = 0; i < al.Count; i++)
            { //if first line, add contents to remainder string
                if (i == al.Count - 1 && al[i].Contains(srcTerminator))
                { //if last or only line, drop line terminator
                    str = al[i].Substring(0, al[i].IndexOf(srcTerminator));
                }
                else
                {
                    str = al[i];
                }

                if (i == 0)
                { //if first line, add contents after flag to remainder string
                    str = " " + str.Substring(1);
                }
                else
                { //trim additional lines and add to remainder string
                    str = Environment.NewLine + str;
                }
                strbuf.Append(str);
            }
            return strbuf.ToString();
        } // getCommentRemainder

        public static String getStatementSource(ASEStatement s)
        {
            String source = "";
            String tmpStatno = "";

            if (s.flag.Equals("B") || s.flag.Equals("C"))
            {
                if (!String.IsNullOrEmpty(s.remainder))
                {
                    source += s.flag + s.remainder + srcTerminator;
                }
                else
                {
                    source += s.flag + "      " +  srcTerminator;
                }
            }
            else if (! String.IsNullOrEmpty(s.verb))
            {
                tmpStatno = s.statno.Value + "     ";
                if (s.verb.StartsWith("LEAVE ATLAS"))
                {
                    source = s.flag + tmpStatno + s.verb + " " + srcTerminator + Environment.NewLine + s.remainder;
                }
                else
                {
                    if (!String.IsNullOrEmpty(s.remainder))
                    {
                        source = s.flag + tmpStatno + s.verb + srcDelimiter + " " + s.remainder + " " + srcTerminator;
                    }
                    else
                    {
                        source = s.flag + tmpStatno + s.verb + " " + srcTerminator;
                    }
                }
            }
            return source;
        } // getStatementSource
        
        public static List<String> ProcessFiles_err(List<String> errInputFileList)
        {
            List<String> errOutputFileList = null;

            if (errInputFileList.Count > 0)
            {
                // get references to text windows on active form
                TextBox frmTxtInput = (TextBox)ATMLTranlatorToolWindowJay.ActiveForm.Controls["txtInput"];

                String fileName;
                String fileExt;

                foreach (String filePath in errInputFileList)
                {
                    fileName = System.IO.Path.GetFileName(filePath);
                    fileExt = System.IO.Path.GetExtension(filePath);

                    frmTxtInput.AppendText(fileName + " -> Incorrect File Type: " + fileExt + Environment.NewLine);
                } // foreach in errInputFileList
            }
            return errOutputFileList;
        } // ProcessFiles_err

        private void btnParseASE_Click(object sender, EventArgs e)
        {
            string selectedPath;


            if (FileManager.OpenFolder(out selectedPath))
            {
                List<string> filenameList = FileManager.GetFolderNames(selectedPath);
                // clear text windows
                txtInput.Clear();
                txtOutput.Clear();

                string selPath = selectedPath;

                filenameList = new List<String>();

                DirectoryInfo aseDir = new DirectoryInfo(selPath);
                String aspDirOut = aseDir.Parent.FullName + @"\asp\"; // set directory of output files

                string xmlStr;
                string xmlDir;
                string xmlPath;

                if (Directory.Exists(selPath))
                { // This path is a directory
                    filenameList = ProcessDirectory(filenameList, selPath);
                }
                else
                {
                    Console.WriteLine("{0} is not a valid file or directory.", selPath);
                }
                
                foreach (string filePath in filenameList)
                {
                    xmlStr = System.IO.File.ReadAllText(filePath);
                    xmlPath = "";

                    //txtInput.AppendText(xmlStr + Environment.NewLine);
txtInput.AppendText(filePath + Environment.NewLine);
                    AtlasSourceExtract atlas_ase = Deserialize<AtlasSourceExtract>(xmlStr);

                    Stack<Object> stackAtlas = new Stack<Object>();
                    AtlasSourceParsed atlas_asp = new AtlasSourceParsed();
                    atlas_asp.tpsname = atlas_ase.tpsname;
                    atlas_asp.tpsfile = atlas_ase.tpsfile;
                    stackAtlas.Push(atlas_asp);  //put null atlas_asp on stack first

                    int statcnt = 0;

                    foreach (ASESourcefile aseSrcfile in atlas_ase.sourcefiles)
                    {
int indent = 0;
String indentStr = "";
                        foreach (ASEStatement aseStat in aseSrcfile.statements)
                        {
                            statcnt++;
                            switch (aseStat.verb)
                            {
                                case "BEGIN":
if (_STACKPRINT)
{
Console.WriteLine("" + aseStat.statno.Value + " " + aseStat.verb + ", " + aseStat.remainder);
}
                                    if (aseStat.remainder.StartsWith("ATLAS PROGRAM"))
                                    {
                                        //push program
                                        stackAtlas = pushAtlasProgram(stackAtlas, atlas_ase.tpsname, aseStat);
                                    }
                                    if (aseStat.remainder.StartsWith("ATLAS MODULE"))
                                    {
                                        //push module
                                        stackAtlas = pushAtlasModule(stackAtlas, aseStat);
                                    }
                                    //push statement
                                    stackAtlas = pushAtlasStatement(stackAtlas, aseStat);
                                    break;
                                case "DEFINE":
                                    aseStat.remainder = aseStat.remainder.Replace(", ", ",").Replace(",", ", ");
                                    if (aseStat.remainder.Contains(", PROCEDURE") || aseStat.remainder.Contains(", COMPLEX SIGNAL")
                                         || aseStat.remainder.Contains(", DIGITAL CONFIGURATION"))
                                    {
if (_STACKPRINT)
{
    indent += _INDENTLENGTH;
    indentStr = new String(' ', indent);
    Console.WriteLine(indentStr + aseStat.statno.Value + " " + aseStat.verb + ", " + aseStat.remainder);
}
                                        //push block
                                        stackAtlas = pushAtlasBlock(stackAtlas, aseStat);
                                    }
                                    //push statement
                                    stackAtlas = pushAtlasStatement(stackAtlas, aseStat);
                                    break;
                                case "DO":
                                    aseStat.remainder = aseStat.remainder.Replace(", ", ",").Replace(",", ", ");
                                    if (aseStat.remainder.Contains(", SIMULTANEOUS") || aseStat.remainder.StartsWith("TIMED DIGITAL"))
                                    {
if (_STACKPRINT)
{
    indent += _INDENTLENGTH;
    indentStr = new String(' ', indent);
    Console.WriteLine(indentStr + aseStat.statno.Value + " " + aseStat.verb + ", " + aseStat.remainder);
}
                                        //push block
                                        stackAtlas = pushAtlasBlock(stackAtlas, aseStat);
                                    }
                                    //push statement
                                    stackAtlas = pushAtlasStatement(stackAtlas, aseStat);
                                    break;
                                case "IF":
                                case "WHILE":
                                case "FOR":
if (_STACKPRINT)
{
    indent += _INDENTLENGTH;
    indentStr = new String(' ', indent);
    Console.WriteLine(indentStr + aseStat.statno.Value + " " + aseStat.verb + ", " + aseStat.remainder);
}
                                    //push block
                                    stackAtlas = pushAtlasBlock(stackAtlas, aseStat);
                                    //push statement
                                    stackAtlas = pushAtlasStatement(stackAtlas, aseStat);
                                    break;
                                case "END":
if (_STACKPRINT)
{
    indentStr = new String(' ', indent);
    Console.WriteLine(indentStr + aseStat.statno.Value + " " + aseStat.verb + ", " + aseStat.remainder);
    indent -= _INDENTLENGTH;
}
                                    //push statement
                                    stackAtlas = pushAtlasStatement(stackAtlas, aseStat);
                                    //pop current block
                                    stackAtlas = popAtlasItem(stackAtlas);
                                    break;
                                case "TERMINATE":
if (_STACKPRINT)
{
    Console.WriteLine("" + aseStat.statno.Value + " " + aseStat.verb + ", " + aseStat.remainder);
}
                                    //push statement
                                    stackAtlas = pushAtlasStatement(stackAtlas, aseStat);
                                    //pop current module/program
                                    stackAtlas = popAtlasItem(stackAtlas);
                                    break;
                                default:  //push statement
                                    stackAtlas = pushAtlasStatement(stackAtlas, aseStat);
                                    break;
                            }
                        }
                    }
                    atlas_asp = (AtlasSourceParsed)stackAtlas.Pop();

                    // output XML for parsed code
                    xmlStr = Serialize<AtlasSourceParsed>(atlas_asp);
                    xmlDir = aspDirOut + atlas_asp.tpsname;
                    xmlPath = xmlDir + @"\" + atlas_asp.tpsfile + "_asp.xml";

                    try
                    {// Determine whether the directory exists. 
                        if (!Directory.Exists(xmlDir))
                        {// Try to create the directory.
                            DirectoryInfo di = Directory.CreateDirectory(xmlDir);
                        }
                        File.WriteAllText(xmlPath, xmlStr);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Could not create output directory: {0}", ex.ToString());
                    }
                    //txtOutput.AppendText(xmlStr + Environment.NewLine);
                    //txtOutput.AppendText(Environment.NewLine);
                    txtOutput.AppendText(statcnt.ToString().PadLeft(4) + " Statements" + "   >   " + xmlPath + Environment.NewLine);
                } // foreach
            } // if
        } // btnParseXML_Click

        public static Stack<Object> pushAtlasProgram(Stack<Object> stack, String tps, ASEStatement stat)
        {
            ASPProgram program = new ASPProgram();
            program.programname = stat.remainder.Substring(14).Replace("'", "").Trim();
            stack.Push(program);

            return stack;
        }

        public static Stack<Object> pushAtlasModule(Stack<Object> stack, ASEStatement stat)
        {
            ASPModule module = new ASPModule();
            module.modulename = stat.remainder.Substring(14).Replace("'", "").Trim();
            stack.Push(module);

            return stack;
        }

        public static Stack<Object> pushAtlasBlock(Stack<Object> stack, ASEStatement stat)
        {
            ASPBlock block = new ASPBlock();
            block.blocktype = stat.verb;
            stack.Push(block);
            return stack;
        }

        public static Stack<Object> pushAtlasStatement(Stack<Object> stack, ASEStatement stat)
        {            
            ASPStatement aspStat = new ASPStatement();
            ASPStatno aspStatno;
            ASPField aspField;

            aspStat.lineno = stat.lineno;
            aspStat.linenoSpecified = true;
            aspStat.flag = stat.flag;
            aspStat.source = stat.source;
            if (stat.statno != null)
            {
                aspStatno = new ASPStatno();
                aspStatno.stepno = stat.statno.stepno;
                aspStatno.testno = stat.statno.testno;
                aspStatno.Value = stat.statno.Value;
                aspStat.statno = aspStatno;
            }
            if (stat.verb != null)
            {
                aspStat.verb = stat.verb;
            }

            if (! String.IsNullOrEmpty(stat.remainder))
            {               
                List<ASPField> fieldList = new List<ASPField>();
                
                if (stat.flag.Equals("B") || stat.flag.Equals("C"))
                {
                    aspField = new ASPField();
                    aspField.fieldno = 1;
                    aspField.fieldnoSpecified = true;
                    aspField.Value = stat.remainder;
                    fieldList.Add(aspField);
                }
                else
                {
                    String tmpRemainder = stat.remainder;
                    List<String> tokenArr = new List<String>(tmpRemainder.Split(srcDelimiter).Select(tmp => tmp).ToArray());
                    
                    int p;
                    int tmpSplit;
                    String tmpFldType;
                    String tmpTokenType;
                    String nextToken;
                    Boolean done;
                    Dictionary<String, int> tmpDict;

                    switch (stat.verb)
                    {
/*
[2053as218.as]
 000038     REQUIRE, 'CAL-RES', LOAD, IMPEDANCE,
                RES 1 OHM, 100 OHM, 1 KOHM, 10 KOHM, 100 KOHM,
                1 MOHM, 10 MOHM,

[r-1379.as]
 000345   REQUIRE, 'PHASE-A', SOURCE,
              PHASE-ANGLE   0 DEG, 120 DEG, 180 DEG, 240 DEG,

 000420  REQUIRE, 'HPSG3-PAM',
             FREQ-DEV 0.1E+6 HZ, 1.0E+6 HZ, 10.0E+6 HZ,

[c50412.as]
 000650     REQUIRE, 'ACPSHVPP01_ABC', SOURCE, AC SIGNAL, CONTROL,
                PHASE-ANGLE-PHASE-A 0 DEG,
                120 DEG, 180 DEG, 240 DEG,
                PHASE-ANGLE-PHASE-B 0 DEG,
                120 DEG, 180 DEG, 240 DEG,
                PHASE-ANGLE-PHASE-C 0 DEG,
                120 DEG, 180 DEG, 240 DEG,

[18d4205-1.as]
 000335     REQUIRE, 'WDPDCPWA', SENSOR (PULSE-WIDTH), PULSED DC,
                TEST-EQUIP-IMP 50.0 OHM, 1.0E+6 OHM,

 000375     REQUIRE, 'WDACPPB', SENSOR (VOLTAGE-PP), AC SIGNAL,
                TEST-EQUIP-IMP 1.0E+6 OHM,

[18d4605-1.as]
 000105     REQUIRE, 'SYN_GEN_2', SOURCE, SYNCHRO,
                   VOLTAGE 11.8 V, 26 V, 90 V,
                   VOLTAGE-REF 26.0 V, 115.0 V,

 000110     REQUIRE, 'SYNC_MEAS1', SENSOR (ANGLE), SYNCHRO,
                VOLTAGE 11.8V, 26.0V, 90.0V,
                VOLTAGE-REF 26.0V, 115.0V,
 
 000149     REQUIRE, 'VPGANA', SOURCE, VIDEO SIGNAL,
                CAPABILITY,
                VFMT RANGE 1 TO 124,
                DOT-CLOCK RANGE 9.375E+6 HZ TO 135.0E+6 HZ,
                HORIZONTAL-TIMING,
                   RATE RANGE 3.0E+3 HZ TO 130.0E+3 HZ,
                   ACTIVE RANGE 16 PIXELS TO 2048 PIXELS,
                   BLANK RANGE 100 PIXELS TO 3072 PIXELS,
                   TOTAL RANGE 144 PIXELS TO 4096 PIXELS,
                   FRONT-PORCH RANGE 1 PIXELS TO 3071 PIXELS,
                   PULSE-WIDTH RANGE 1 PIXELS TO 3071 PIXELS,
                   SIZE RANGE 0.0 M TO 1.0E+6 M,
                VERTICAL-TIMING,
                   RATE RANGE 1 HZ TO 650 HZ,
                   ACTIVE RANGE 5 LINES TO 1024 LINES,
                   BLANK RANGE 3 LINES TO 3072 LINES,
                   TOTAL RANGE 7 LINES TO 4097 LINES,
                   FRONT-PORCH RANGE 1 LINES TO 4095 LINES,
                   PULSE-WIDTH RANGE 1 LINES TO 4095 LINES,
                   SIZE RANGE 0.0 M TO 1.0E+6 M,
                   NON-INTERLACE,
                   INTERLACE,
                SYNC ANALOG-COMP DIGITAL-COMP DIGITAL-SEPARATE,
                   ON-VIDEO RED GREEN BLUE,
                   EQ-BEFORE RANGE 0 LINES TO 4095 LINES,
                   EQ-AFTER  RANGE 0 LINES TO 4095 LINES,
                   TYPE AMERICAN EUROPEAN,
                   SERRATION ON OFF,
                   SWING RANGE 0.1V TO 0.400 V, 
                SYNC-POLARITY,
                   HORIZONTAL POS NEG,
                   VERTICAL POS NEG,
                   COMPOSITE POS NEG,
                VIDEO COLOR MONO,
                   PEDESTAL RANGE 0.0 PC TO 100.0 PC,
                   SWING RANGE 0.4 V TO 1.000 V,
                   BIAS RANGE 0.0 V TO 1.0 V,
                   GAMMA RANGE 0.1 TO 10.0,
                IMAGE RANGE 1 TO 141,
                DRAW 
                   RECT OVAL LINE DOT GRID H-GRILL V-GRILL
                   ASCII STRING LIMITS CENTERMARK TRIANGLE
                   DISPFMT HATCH_I-O HATCH_O-I CROSS,
                   WIDTH  RANGE 1 PIXELS TO 1024 PIXELS,
                   HEIGHT RANGE 1 LINES TO 1024 LINES,
                   X1     RANGE 1 PIXELS TO 1024 PIXELS,
                   X2     RANGE 1 PIXELS TO 1024 PIXELS,
                   X3     RANGE 1 PIXELS TO 1024 PIXELS,
                   XBOXES RANGE 1 PIXELS TO 1024 PIXELS,
                   Y1     RANGE 1 LINES TO 1024 LINES,
                   Y2     RANGE 1 LINES TO 1024 LINES,
                   Y3     RANGE 1 LINES TO 1024 LINES,
                   YBOXES RANGE 1 LINES TO 1024 LINES,
                   FILL-COLOR RANGE 0 TO 63,
                   FILL-PATT  RANGE 0 TO 30,
                   FONT       RANGE 0 TO 10,
                   CHAR-CODE  RANGE 0 TO 255,
                CNX VIA $ 
*/
                        case "APPLY":
                            p = 0;
                            tmpSplit = 0;
                            tmpFldType = "";
                            tmpTokenType = "";
                            for (int x = 0; x < tokenArr.Count; x++)
                            {
                                p++;
                                aspField = new ASPField();
                                aspField.fieldno = p;
                                aspField.fieldnoSpecified = true;
                                aspField.Value = tokenArr[x].Trim();
                                if (aspField.Value.IndexOf(" ") > 0)
                                {
                                    tmpSplit = aspField.Value.IndexOf(" ");
                                    tmpFldType = aspField.Value.Substring(0, tmpSplit).Trim();
                                }
                                else
                                {
                                    tmpFldType = aspField.Value;
                                }

                                if (requireMultiLineParams.ContainsKey(tmpFldType))
                                {
                                    tmpDict = requireMultiLineParams[tmpFldType];
                                    done = false;
                                    while (!done)
                                    {
                                        if (x + 1 < tokenArr.Count)
                                        {
                                            // check for additional parameters
                                            nextToken = tokenArr[x + 1].Trim();
                                            if (nextToken.IndexOf(" ") > 0)
                                            {
                                                tmpSplit = nextToken.IndexOf(" ");
                                                tmpTokenType = nextToken.Substring(0, tmpSplit).Trim();
                                            }
                                            else
                                            {
                                                tmpTokenType = nextToken;
                                            }
Console.WriteLine("          " + nextToken + " | " + tmpTokenType);

                                            if (tmpDict.ContainsKey(tmpTokenType))
                                            {
                                                aspField.Value += ", " + tokenArr[++x].Trim();
                                            }
                                            else
                                            {
                                                done = true;
                                            }
                                        }
                                        else
                                        {
                                            done = true;
                                        }
                                    }
                                }
                                fieldList.Add(aspField);
                            }
                            break;
                        case "REQUIRE":
                            p = 0;
                            tmpSplit = 0;
                            tmpFldType = "";
                            tmpTokenType = "";
                            for (int x = 0; x < tokenArr.Count; x++)
                            {
                                p++;
                                aspField = new ASPField();
                                aspField.fieldno = p;
                                aspField.fieldnoSpecified = true;
                                aspField.Value = tokenArr[x].Trim();
                                if (aspField.Value.IndexOf(" ") > 0)
                                {
                                    tmpSplit = aspField.Value.IndexOf(" ");
                                    tmpFldType = aspField.Value.Substring(0, tmpSplit).Trim();
                                }
                                else
                                {
                                    tmpFldType = aspField.Value;
                                }

                                if (requireMultiLineParams.ContainsKey(tmpFldType))
                                {
                                    tmpDict = requireMultiLineParams[tmpFldType];
                                    done = false;
                                    while (!done)
                                    {
                                        if (x + 1 < tokenArr.Count)
                                        {
                                            // check for additional parameters
                                            nextToken = tokenArr[x + 1].Trim();
                                            if (nextToken.IndexOf(" ") > 0)
                                            {
                                                tmpSplit = nextToken.IndexOf(" ");
                                                tmpTokenType = nextToken.Substring(0, tmpSplit).Trim();
                                            }
                                            else
                                            {
                                                tmpTokenType = nextToken;
                                            }
Console.WriteLine("          " + nextToken + " | " + tmpTokenType);

                                            if (tmpDict.ContainsKey(tmpTokenType))
                                            {
                                                aspField.Value += ", " + tokenArr[++x].Trim();
                                            }
                                            else
                                            {
                                                done = true;
                                            }
                                        }
                                        else
                                        {
                                            done = true;
                                        }
                                    }
                                }
                                else if (requireParamList.ContainsKey(tmpFldType) && !aspField.Value.Contains("RANGE"))
                                {
                                    done = false;
                                    while (!done)
                                    {
                                        if (x + 1 < tokenArr.Count)
                                        {
                                            // check for a following numeric parameter value
                                            String tmpStr = Regex.Split(tokenArr[x + 1].Trim(), @"[^0-9E\.\+\-]+")[0];
                                            if (!String.IsNullOrEmpty(tmpStr) || (tokenArr[x + 1].Trim().StartsWith(tmpFldType) && ! tokenArr[x + 1].Trim().StartsWith(tmpFldType + "-")))
                                            {
                                                aspField.Value += ", " + tokenArr[++x].Trim();
                                            }
                                            else
                                            {
                                                done = true;
                                            }
                                        }
                                        else
                                        {
                                            done = true;
                                        }
                                    }
                                }
                                fieldList.Add(aspField);
                            }
                            break;
                        case "OUTPUT":
                            int startIndex = 0;
                            int nextDelimiter = startIndex;
                            String tmpStat = tmpRemainder;

                            String token = tokenArr[0].Trim();
                            int t = 0;
                            while (token.StartsWith("USING"))
                            {
                                t++;
                                aspField = new ASPField();
                                aspField.fieldno = t;
                                aspField.fieldnoSpecified = true;
                                aspField.Value = token;
                                fieldList.Add(aspField);

                                startIndex = nextDelimiter + 1;
                                nextDelimiter = tmpRemainder.IndexOf(srcDelimiter, startIndex);

                                tmpStat = tmpRemainder.Substring(nextDelimiter + 1);
                                tokenArr = new List<String>(tmpStat.Split(srcDelimiter).ToArray());
                                token = tokenArr[0].Trim();
                            }  //while token = "USING*"
                            aspField = new ASPField();
                            aspField.fieldno = t + 1;
                            aspField.fieldnoSpecified = true;
                            aspField.Value = tmpStat;
                            fieldList.Add(aspField);
                            break;
                        case "DEFINE":
                            int i = 0;
                            while ( i < tokenArr.Count)
                            {
                                if (tokenArr[i].Trim().StartsWith("PROCEDURE") || tokenArr[i].Trim().Equals(strMessage))
                                {
                                    if (tokenArr[i].Trim().StartsWith("PROCEDURE"))
                                    {
                                        aspField = new ASPField();
                                        aspField.fieldno = i + 1;
                                        aspField.fieldnoSpecified = true;
                                        aspField.Value = tokenArr[i].Trim();

                                        i++;
                                        while (i < tokenArr.Count)
                                        {
                                            aspField.Value += ", " + tokenArr[i].Trim();
                                            i++;
                                        }
                                        fieldList.Add(aspField);
                                    }
                                    else // tokenArr[i].Trim().Equals(strMessage)
                                    {
                                        aspField = new ASPField();
                                        aspField.fieldno = i + 1;
                                        aspField.fieldnoSpecified = true;
                                        aspField.Value = tokenArr[i].Trim();
                                        fieldList.Add(aspField);

                                        i++;
                                        aspField = new ASPField();
                                        aspField.fieldno = i + 1;
                                        aspField.fieldnoSpecified = true;
                                        aspField.Value = tmpRemainder.Substring(tmpRemainder.IndexOf(strMessage + srcDelimiter) + strMessage.Length + 1);
                                        fieldList.Add(aspField);
                                        
                                        //no more tokens, set condition to exit loop
                                        i = tokenArr.Count;
                                     }
                                }
                                else
                                {
                                    aspField = new ASPField();
                                    aspField.fieldno = i + 1;
                                    aspField.fieldnoSpecified = true;
                                    aspField.Value = tokenArr[i].Trim();
                                    fieldList.Add(aspField);
                                    i++;
                                }
                            }
                            break; 
                        default:
                        //separate comma delimited fields
                        for (int x = 0; x < tokenArr.Count; x++)
                        {
                            aspField = new ASPField();
                            aspField.fieldno = x + 1;
                            aspField.fieldnoSpecified = true;
                            aspField.Value = tokenArr[x].Trim();
                            fieldList.Add(aspField);
                        }
                        break;
                    }
                }
                aspStat.remainder = fieldList.ToArray();
            }
            stack.Push(aspStat);
            stack = popAtlasItem(stack);

            return stack;
        } // pushAtlasStatement

        public static Stack<Object> popAtlasItem(Stack<Object> stack)
        {
            Object curr = stack.Pop();

            if (stack.Count > 0)
            {
                Object prev = stack.Pop();
                List<Object> itemsList = null;

                switch (prev.GetType().ToString())
                {
                    case "ASPBlock":
                        if (((ASPBlock)prev).Items == null)
                        {
                            itemsList = new List<Object>();
                        }
                        else
                        {
                            itemsList = new List<Object>(((ASPBlock)prev).Items);
                        }
                        itemsList.Add(curr);
                        ((ASPBlock)prev).Items = itemsList.ToArray();
                        break;
                    case "ASPModule":
                        if (((ASPModule)prev).Items == null)
                        {
                            itemsList = new List<Object>();
                        }
                        else
                        {
                            itemsList = new List<Object>(((ASPModule)prev).Items);
                        }
                        itemsList.Add(curr);
                        ((ASPModule)prev).Items = itemsList.ToArray();
                        break;
                    case "ASPProgram":
                        if (((ASPProgram)prev).Items == null)
                        {
                            itemsList = new List<Object>();
                        }
                        else
                        {
                            itemsList = new List<Object>(((ASPProgram)prev).Items);
                        }
                        itemsList.Add(curr);
                        ((ASPProgram)prev).Items = itemsList.ToArray();
                        break;
                    case "AtlasSourceParsed":
                        if (((AtlasSourceParsed)prev).Items == null)
                        {
                            itemsList = new List<Object>();
                        }
                        else
                        {
                            itemsList = new List<Object>(((AtlasSourceParsed)prev).Items);
                        }
                        itemsList.Add(curr);
                        ((AtlasSourceParsed)prev).Items = itemsList.ToArray();
                        break;
                }
                stack.Push(prev);
            }
            return stack;
        } // popAtlasItem

        public static String cleanupRemainder(String remainder)
        {
            String tmpRemainder = remainder;
            //clean up space in noun field names
            //tmpRemainder = tmpRemainder.Replace("DC SIGNAL USING", "DC_SIGNAL USING");
            //tmpRemainder = tmpRemainder.Replace("PULSED DC USING", "PULSED_DC_SIGNAL USING");
            //tmpRemainder = tmpRemainder.Replace("SQUARE WAVE USING", "SQUARE_WAVE USING");
            //tmpRemainder = tmpRemainder.Replace("COMPLEX SIGNAL", "COMPLEX_SIGNAL");
            //tmpRemainder = tmpRemainder.Replace("CURRENT MAX", "CURRENT_MAX");
            //tmpRemainder = tmpRemainder.Replace("VOLTAGE MAX", "VOLTAGE_MAX");
            ////tmpRemainder = tmpRemainder.replaceFirst(" USING ", " ");  //java version
            ////tmpRemainder = tmpRemainder.Replace("'", "");
            tmpRemainder = Regex.Replace(tmpRemainder, @"\s+", " "); // remove duplicate white spaces

            return tmpRemainder;
        }

        public List<ASPStatement> getStatementsByVerb(List<ASPStatement> aspStatList, Object aspObj, String verbStr)
        {
            List<ASPStatement> tmpStatList = new List<ASPStatement>();
            List<Object> aspObjList = new List<Object>();
            ASPStatement tmpStat;
            List<String> remList;

            switch (aspObj.GetType().ToString())
            {
                case "ASPStatement":
                    aspObjList = null;
                    break;
                case "ASPBlock":
                    aspObjList = ((ASPBlock)aspObj).Items.ToList();
                    break;
                case "ASPModule":
                    aspObjList = ((ASPModule)aspObj).Items.ToList();
                    break;
                case "ASPProgram":
                    aspObjList = ((ASPProgram)aspObj).Items.ToList();
                    break;
                case "AtlasSourceParsed":
                    aspObjList = ((AtlasSourceParsed)aspObj).Items.ToList();
                    break;
            }

            foreach (Object tmpObj in aspObjList)
            {
                switch (tmpObj.GetType().ToString())
                {
                    case "ASPStatement":
                        tmpStat = (ASPStatement)tmpObj;
                        if (!String.IsNullOrEmpty(tmpStat.verb) && tmpStat.verb.Contains(verbStr))
                        {
                            tmpStatList.Add(tmpStat);
                            remList = new List<String>();
                            foreach (ASPField aspFld in tmpStat.remainder)
                            {
                                remList.Add(aspFld.Value);
                            }
                        }
                        break;
                    case "ASPBlock":
                    case "ASPModule":
                    case "ASPProgram":
                        tmpStatList = getStatementsByVerb(tmpStatList, tmpObj, verbStr);
                        break;
                }
            }
            aspStatList.AddRange(tmpStatList);
            return aspStatList;
        }

        private void btnAnalyzeASP_Click(object sender, EventArgs e)
        {
            string selectedFolder;
            if (FileManager.OpenFolder(out selectedFolder))
            {
                // clear text windows
                txtInput.Clear();
                txtOutput.Clear();

                string selPath = selectedFolder;

                List<String> filenameList = FileManager.GetFolderNames(selectedFolder);

                if (Directory.Exists(selPath))
                { // This path is a directory
                    filenameList = ProcessDirectory(filenameList, selPath);
                }
                else
                {
                    Console.WriteLine("{0} is not a valid file or directory.", selPath);
                }

                // init dictionaries
                SortedDictionary<string, SortedDictionary<string, List<ASPRStatement>>> dicParamTotals = new SortedDictionary<string, SortedDictionary<string, List<ASPRStatement>>>();
                SortedDictionary<string, MinMax> dicMinMaxTotals = new SortedDictionary<string, MinMax>();
                SortedDictionary<string, List<ASPRStatement>> dicMinMaxTotalsStats = new SortedDictionary<string, List<ASPRStatement>>();

                String strVerb;
                AnalyzeResults resultsRequire;
                AnalyzeResults resultsApply;
                List<String> tpsnameList = new List<string>();

                SortedDictionary<string, List<string>> dicTPS = new SortedDictionary<string, List<string>>();

                foreach (string filePath in filenameList)
                {
                    string xmlStr = System.IO.File.ReadAllText(filePath);
                    string aspFilename = System.IO.Path.GetFileName(filePath);
                    //String xmlPath = "";

                    //txtInput.AppendText(xmlStr + Environment.NewLine);
                    txtInput.AppendText(filePath + Environment.NewLine);
                    AtlasSourceParsed atlas_asp = Deserialize<AtlasSourceParsed>(xmlStr);
                    if (! dicTPS.ContainsKey(atlas_asp.tpsname))
                    {
                        dicTPS.Add(atlas_asp.tpsname, new List<string>());
                    }
                    dicTPS[atlas_asp.tpsname].Add(atlas_asp.tpsfile);

                    List<ASPStatement> aspListApply = new List<ASPStatement>();
                    List<ASPStatement> aspListRequire = new List<ASPStatement>();

Console.WriteLine("[" + atlas_asp.tpsname + " -> " + atlas_asp.tpsfile + "]");

resultsRequire = null;
if (_FLAGREQUIRE)
{
                    strVerb = "REQUIRE";
                    aspListRequire = getStatementsByVerb(aspListRequire, atlas_asp, strVerb);
                    resultsRequire = analyzeRequire(aspListRequire, strVerb, atlas_asp, aspFilename);
                    dicParamTotals = updateParamTotals(resultsRequire.dicParams, dicParamTotals);
                    dicMinMaxTotals = updateMinMaxTotals(resultsRequire.dicMinMax, dicMinMaxTotals);
                    dicMinMaxTotalsStats = updateMinMaxTotalsStats(resultsRequire.dicMinMaxStats, dicMinMaxTotalsStats);
}
resultsApply = null;
if (_FLAGAPPLY)
{
                    strVerb = "APPLY";
                    aspListApply = getStatementsByVerb(aspListApply, atlas_asp, strVerb);
                    resultsApply = analyzeApply(aspListApply, strVerb, atlas_asp, aspFilename);
                    dicParamTotals = updateParamTotals(resultsApply.dicParams, dicParamTotals);
                    dicMinMaxTotals = updateMinMaxTotals(resultsApply.dicMinMax, dicMinMaxTotals);
                    dicMinMaxTotalsStats = updateMinMaxTotalsStats(resultsApply.dicMinMaxStats, dicMinMaxTotalsStats);
}
                    txtOutput.AppendText("[" + atlas_asp.tpsname + " -> " + atlas_asp.tpsfile + "]" + Environment.NewLine);
                    tpsnameList.Add(atlas_asp.tpsname + ", " + atlas_asp.tpsfile);
if (_FLAGREQUIRE)
{
                    txtOutput.AppendText(resultsRequire.DisplayParams());
                    txtOutput.AppendText(resultsRequire.DisplayMinMax());
} 
if (_FLAGAPPLY)
{
                    txtOutput.AppendText(resultsApply.DisplayParams());
                    txtOutput.AppendText(resultsApply.DisplayMinMax());
}
                }

                // if more than one file, display summary
                if (filenameList.Count() > 1)
                {
                    AnalyzeResults resultsSummary = new AnalyzeResults();
                    resultsSummary.verb = "";
                    resultsSummary.dicParams = dicParamTotals;
                    resultsSummary.dicMinMax = dicMinMaxTotals;
                    resultsSummary.dicMinMaxStats = dicMinMaxTotalsStats;

ASP_ResultsPatterns tmpResultsPatterns = new ASP_ResultsPatterns();
tmpResultsPatterns = resultsSummary.getASPResultsPatterns();
tmpResultsPatterns.TestPrograms = dicTPS.Keys.ToArray();
XDocument xmldocPatterns = XDocument.Parse(Serialize<ASP_ResultsPatterns>(tmpResultsPatterns));
txtOutput.AppendText(xmldocPatterns + Environment.NewLine);

ASP_ResultsParameters tmpResultsParameters = new ASP_ResultsParameters();
tmpResultsParameters = resultsSummary.getASPResultsParameters();
tmpResultsParameters.TestPrograms = dicTPS.Keys.ToArray();
XDocument xmldocParameters = XDocument.Parse(Serialize<ASP_ResultsParameters>(tmpResultsParameters));
txtOutput.AppendText(xmldocParameters + Environment.NewLine);

XElement xmlPatterns = xmldocPatterns.Root;
IEnumerable<TreeNode> nodesPatterns = getNodes(new TreeNode(xmlPatterns.Name.LocalName), xmlPatterns).ToArray();
treeViewPatterns.Nodes.Clear();
treeViewPatterns.Nodes.AddRange(nodesPatterns.ToArray());
treeViewPatterns.ExpandAll();
treeViewPatterns.Nodes[0].Nodes[0].Collapse(true);
treeViewPatterns.Nodes[0].EnsureVisible();

XElement xmlParameters = xmldocParameters.Root;
IEnumerable<TreeNode> nodesParameters = getNodes(new TreeNode(xmlParameters.Name.LocalName), xmlParameters).ToArray();
treeViewParameters.Nodes.Clear();
treeViewParameters.Nodes.AddRange(nodesParameters.ToArray());
treeViewParameters.ExpandAll();
treeViewParameters.Nodes[0].Nodes[0].Collapse(true);
treeViewParameters.Nodes[0].EnsureVisible();

                    txtOutput.AppendText("===== SUMMARY - PARAMS =====" + Environment.NewLine);
                    int dicTPSFiles = 0;
                    foreach (KeyValuePair<string, List<string>> p in dicTPS)
                    {
                        dicTPSFiles += p.Value.Count;
                        foreach (string s in p.Value)
                        {
                            txtOutput.AppendText("[ " + p.Key + " -> " + s + " ]" + Environment.NewLine);
                        }
                    }
                    txtOutput.AppendText("----" + Environment.NewLine);
                    txtOutput.AppendText(dicTPS.Count.ToString().PadLeft(4) + " TPSs" + Environment.NewLine);
                    txtOutput.AppendText(dicTPSFiles.ToString().PadLeft(4) + " Programs/Modules" + Environment.NewLine + Environment.NewLine);

                    txtOutput.AppendText(resultsSummary.DisplayParams());

                    txtOutput.AppendText("===== SUMMARY - MINMAX =====" + Environment.NewLine);
                    txtOutput.AppendText(resultsSummary.DisplayMinMax());
                }
            }
        } // btnAnalyzeASP_Click

        private AnalyzeResults analyzeApply(List<ASPStatement> applyList, string strVerb, AtlasSourceParsed asp, string aspFile)
        {
            SortedDictionary<string, SortedDictionary<string, List<ASPRStatement>>> dicParams = new SortedDictionary<string, SortedDictionary<string, List<ASPRStatement>>>();
            SortedDictionary<string, MinMax> dicMinMax = new SortedDictionary<string, MinMax>();
            SortedDictionary<string, List<ASPRStatement>> dicMinMaxStats = new SortedDictionary<string, List<ASPRStatement>>();
            List<String> remList = new List<String>();
            List<List<Param>> paramList = new List<List<Param>>();
            List<Param> tmpParamList;
            int startIndex = 0;
            ASPField aspFld;
            String tmpBaseKey;
            int tmpSplit;
            String tmpFldType;
            String tmpFldValue;
            Param tmpParam;
            String tmpParamLo;
            String tmpParamHi;
            List<String> valList;
            List<string> tmpValList;
            List<string> cnxList;
            String pinDesc;
            List<String> tmpKeyList;
            SortedList<String, int> tmpSortedList;
            Boolean done;
            String nextField;
            String tmpOrderedKey;
            String tmpSortedKey;
            String mmKey;
            String mmVal;
            MinMax tmpMinMax;
            Boolean initMinMax;
            
            foreach (ASPStatement tmpStat in applyList)
            {
                remList = new List<String>();
                paramList = new List<List<Param>>();

                startIndex = 1;
                aspFld = tmpStat.remainder[0];

                if (aspFld.Value.Contains(strUsing))
                {
                    tmpBaseKey = tmpStat.verb + "|" + aspFld.Value.Substring(0, aspFld.Value.IndexOf(strUsing)).Trim();
                }
                else if (aspFld.Value.Contains(strComplexSignal))
                {
                    tmpBaseKey = tmpStat.verb + "|" + aspFld.Value.Substring(0, aspFld.Value.IndexOf(" ", aspFld.Value.IndexOf(" ") + 1)).Trim();
                }
                else
                {
                    tmpBaseKey = tmpStat.verb + "|" + aspFld.Value;
                }

                if (aspFld.Value.StartsWith("'") && aspFld.Value.EndsWith("'"))  // not a user defined signal ('SQUARE WAVE' || 'STATIC DIGITAL STIM')
                {
/*
[PTF_AAV_TPH_ST.atl]
 	  APPLY, 'STATIC DIGITAL STIM', B'111111', 5.0, 0.0,
	          ITA_J3_16 ITA_J3_17 ITA_J3_31 
              ITA_J3_32 ITA_J3_52 ITA_J3_53  $

 	  APPLY, 'STATIC DIGITAL STIM', B'111111', 5.0, 0.0, ITA_J3_16 ITA_J3_17 ITA_J3_31 ITA_J3_32 ITA_J3_52 ITA_J3_53  $
*/
Console.WriteLine("     <" + tmpStat.statno + "> " + aspFld.Value);
                }
                else
                {
                    valList = new List<String>();
                    for (int x = startIndex; x < tmpStat.remainder.Length; x++)
                    {
                        tmpParamList = new List<Param>();
                        aspFld = tmpStat.remainder[x];

                        if (aspFld.Value.IndexOf(" ") > 0)
                        {
                            tmpSplit = aspFld.Value.IndexOf(" ");
                            tmpFldType = aspFld.Value.Substring(0, tmpSplit).Trim();
                            tmpFldValue = aspFld.Value.Substring(tmpSplit + 1).Trim();

                            if (tmpFldValue.StartsWith(strMax))
                            {
                                tmpSplit = tmpFldValue.IndexOf(" ");
                                tmpFldType += " " + strMax;
                                tmpFldValue = tmpFldValue.Substring(tmpSplit + 1).Trim();
                            }

                            if (tmpFldType.EndsWith(srcDelimiter.ToString()))  // 'HORIZONTAL-TIMING,' || 'VERTICAL-TIMING,' || 'SYNC-POLARITY,'
                            {
                                tmpFldType = tmpFldType.Substring(0, tmpFldType.Length - 1).Trim();
                            }
                        }
                        else
                        {
                            tmpFldType = aspFld.Value;
                            tmpFldValue = "";
                        }

                        if (applyNoParam.ContainsKey(tmpFldType) || applyMultiLineParams.ContainsKey(tmpFldType)
                            || String.IsNullOrEmpty(tmpFldValue))
                        {
                            tmpParamList.Add(null);
                        }
                        else
                        {
                            if (tmpFldValue.Contains(strRange))
                            {
                                tmpParamLo = tmpFldValue.Substring((tmpFldValue.IndexOf(strRange) + strRange.Length), tmpFldValue.IndexOf(strTo) - (tmpFldValue.IndexOf(strRange) + strRange.Length)).Trim();
                                tmpParam = new Param();
                                tmpParam.Parse(tmpParamLo);
                                tmpParamList.Add(tmpParam);

                                if (tmpFldValue.Contains(strContinuous) || tmpFldValue.Contains(strBy))
                                {
                                    if (tmpFldValue.Contains(strContinuous))
                                    {
                                        tmpParamHi = tmpFldValue.Substring((tmpFldValue.IndexOf(strTo) + strTo.Length), tmpFldValue.IndexOf(strContinuous) - (tmpFldValue.IndexOf(strTo) + strTo.Length)).Trim();
                                    }
                                    else
                                    {
                                        tmpParamHi = tmpFldValue.Substring((tmpFldValue.IndexOf(strTo) + strTo.Length), tmpFldValue.IndexOf(strBy) - (tmpFldValue.IndexOf(strTo) + strTo.Length)).Trim();
                                    }
                                }
                                else
                                {
                                    tmpParamHi = tmpFldValue.Substring(tmpFldValue.IndexOf(strTo) + strTo.Length).Trim();
                                }
                                tmpParam = new Param();
                                tmpParam.Parse(tmpParamHi);
                                tmpParamList.Add(tmpParam);
                            }
                            else
                            {
                                if (requireParamList.ContainsKey(tmpFldType) && tmpFldValue.IndexOf(",") > 0)
                                {
                                    tmpValList = tmpFldValue.Split(',').ToList();
                                    foreach (String tmpVal in tmpValList)
                                    {
                                        tmpParam = new Param();
                                        tmpParam.Parse(tmpVal.Trim());
                                        tmpParamList.Add(tmpParam);
                                    }
                                }
                                else if (tmpFldType.Equals(strCNX))
                                {
                                    cnxList = tmpFldValue.Split(' ').ToList();
                                    pinDesc = "";
                                    for (int i = 0; i < cnxList.Count; i++)
                                    {
                                        if (pinDescriptors.ContainsKey(cnxList[i]))
                                        {
                                            pinDesc = cnxList[i];

                                            if (i == 0)
                                            {
                                                tmpFldType += " ";
                                            }
                                        }
                                        else
                                        {
                                            //add current item to list
                                            if (!tmpFldType.EndsWith(pinDesc))
                                            {
                                                if (tmpFldType.EndsWith(" "))
                                                {
                                                    tmpFldType += pinDesc;
                                                }
                                                else
                                                {
                                                    tmpFldType += "-" + pinDesc;
                                                }
                                            }
                                            else
                                            {
                                                tmpFldType += "_" + pinDesc;
                                            }
                                        }
                                    }
                                    tmpParamList.Add(null);
                                }
                                else
                                {
                                    tmpParam = new Param();
                                    tmpParam.Parse(tmpFldValue);
                                    tmpParamList.Add(tmpParam);
                                }
                            }
                        }
                        valList.Add(tmpFldType);
                        paramList.Add(tmpParamList);
                    } // for

                    tmpKeyList = new List<String>();
                    tmpSortedList = null;
                    for (int x = 0; x < valList.Count; x++)
                    {
                        tmpKeyList.Add(valList[x]);
                        if (applyFields.ContainsKey(valList[x]))
                        {
                            tmpSortedList = new SortedList<String, int>();
                            done = false;
                            while (!done)
                            {
                                if (x + 1 < valList.Count)
                                {
                                    // check for subfields
                                    nextField = valList[x + 1].Trim();
                                    if (!applyFields.ContainsKey(nextField))
                                    {
                                        tmpSortedList.Add(nextField, 0);
                                        x++;
                                    }
                                    else
                                    {
                                        done = true;
                                    }
                                }
                                else
                                {
                                    done = true;
                                }
                            }

                            foreach (KeyValuePair<String, int> kvp in tmpSortedList)
                            {
                                Console.WriteLine(kvp.Key + " -> " + kvp.Value);
                                tmpKeyList.Add(kvp.Key);
                            }
                        }
                    } // for

                    // tmpOrderedKey uses the order of the parameters as listed in original statement
                    tmpOrderedKey = tmpBaseKey + "|" + String.Join("|", valList);
                    // tmpSortedKey sorts the key so that statements with the same parameters in a different order can be properly counted
                    tmpSortedKey = tmpBaseKey + "|" + String.Join("|", tmpKeyList);

                    // update param dictionary
                    ASPRStatement tmpASPR_Stat = new ASPRStatement();
                    tmpASPR_Stat.tpsname = asp.tpsname;
                    tmpASPR_Stat.aspstatno = tmpStat.statno.Value;
                    tmpASPR_Stat.asptestno = tmpStat.statno.testno;
                    tmpASPR_Stat.aspstepno = tmpStat.statno.stepno;
                    tmpASPR_Stat.aspfile = aspFile;
                    tmpASPR_Stat.lineno = tmpStat.lineno;
                    tmpASPR_Stat.linenoSpecified = true;
                    tmpASPR_Stat.source = tmpStat.source;

                    if (dicParams.ContainsKey(tmpSortedKey))
                    {
                        if (!dicParams[tmpSortedKey].ContainsKey(tmpOrderedKey))
                        {
                            dicParams[tmpSortedKey].Add(tmpOrderedKey, new List<ASPRStatement>());
                        }
                    }
                    else
                    {
                        dicParams.Add(tmpSortedKey, new SortedDictionary<string, List<ASPRStatement>>());
                        dicParams[tmpSortedKey].Add(tmpOrderedKey, new List<ASPRStatement>());
                    }
                    dicParams[tmpSortedKey][tmpOrderedKey].Add(tmpASPR_Stat);

                    // update minmax dictionary
                    for (int i = 0; i < valList.Count; i++)
                    {
                        mmVal = valList[i];
                        mmKey = tmpBaseKey + "|" + mmVal;
                        if (dicMinMax.ContainsKey(mmKey))
                        {
                            foreach (Param param in paramList[i])
                            {
                                if (param != null)
                                {
                                    dicMinMax[mmKey].SetMinMax(param);
                                }
                            } //foreach
                            tmpMinMax = dicMinMax[mmKey];
                        }
                        else
                        {
                            tmpMinMax = null;
                            initMinMax = false;
                            foreach (Param param in paramList[i])
                            {
                                if (param != null)
                                {
                                    if (!initMinMax)
                                    {
                                        tmpMinMax = new MinMax();
                                        tmpMinMax.Key = tmpBaseKey;
                                        tmpMinMax.Type = mmVal;
                                        initMinMax = true;
                                    }
                                    tmpMinMax.SetMinMax(param);
                                }
                            } //foreach

                            if (tmpMinMax != null)
                            {
                                dicMinMax.Add(mmKey, tmpMinMax);
                            }
                        }
                    } //for
Console.WriteLine(tmpBaseKey + " -> " + tmpASPR_Stat.aspfile + " " + tmpASPR_Stat.aspstatno);
                    if (!dicMinMaxStats.ContainsKey(tmpBaseKey))
                    {
                        dicMinMaxStats.Add(tmpBaseKey, new List<ASPRStatement>());
                    }
                    dicMinMaxStats[tmpBaseKey].Add(tmpASPR_Stat);
                }
            } //foreach

            AnalyzeResults results = new AnalyzeResults();
            results.verb = strVerb;
            results.dicParams = dicParams;
            results.dicMinMax = dicMinMax;
            results.dicMinMaxStats = dicMinMaxStats;
            return results;
        } // analyzeApply

        private AnalyzeResults analyzeRequire(List<ASPStatement> requireList, string strVerb, AtlasSourceParsed asp, string aspFile)
        {
            SortedDictionary<string, SortedDictionary<string, List<ASPRStatement>>> dicParams = new SortedDictionary<string, SortedDictionary<string, List<ASPRStatement>>>();
            SortedDictionary<string, MinMax> dicMinMax = new SortedDictionary<string, MinMax>();
            SortedDictionary<string, List<ASPRStatement>> dicMinMaxStats = new SortedDictionary<string, List<ASPRStatement>>();
            List<String> remList = new List<String>();
            List<List<Param>> paramList = new List<List<Param>>();
            List<Param> tmpParamList;
            int startIndex = 0;
            ASPField aspFld;
            String tmpBaseKey;
            int tmpSplit;
            String tmpFldType;
            String tmpFldValue;
            ParamField tmpField;
            List<String> valList;
            List<string> tmpValList;
            List<String> tmpKeyList;
            SortedList<String, int> tmpSortedList;
            Boolean done;
            String nextField;
            String tmpOrderedKey;
            String tmpSortedKey;
            String mmKey;
            String mmVal;
            MinMax tmpMinMax;
            Boolean initMinMax;
/*
List<String> tmpList = new List<string>();
tmpList.Add("RANGE 75HZ TO 150HZ BY 5HZ ERRLMT +-2HZ");
tmpList.Add("RANGE 7.3V TO 7.7V CONTINUOUS");
tmpList.Add("105HZ ERRLMT +-2HZ");
tmpList.Add("7.5V");

ParamField tmpParamField = new ParamField();
foreach (String s in tmpList)
{
    tmpParamField.Parse(s);
    Console.WriteLine(tmpParamField.ToString());
}

//RANGE 75 HZ TO 150 HZ BY 5 HZ ERRLMT +-2 HZ
//RANGE 7.3 V TO 7.7 V CONTINUOUS
//105 HZ ERRLMT +-2 HZ
//7.5 V
*/


            foreach (ASPStatement tmpStat in requireList)
            {
//Console.WriteLine("     " + tmpStat.statno);
                paramList = new List<List<Param>>();

                if (requireIO.ContainsKey(tmpStat.remainder[1].Value))
                {
                    startIndex = 2;
                    tmpBaseKey = tmpStat.verb + "|" + tmpStat.remainder[1].Value;
                    tmpFldType = tmpStat.remainder[1].Value;
                }
                else
                {
                    startIndex = 3;
                    tmpBaseKey = tmpStat.verb + "|" + tmpStat.remainder[1].Value + "|" + tmpStat.remainder[2].Value;
                    tmpFldType = tmpStat.remainder[2].Value;
                }

                valList = new List<String>();
                for (int x = startIndex; x < tmpStat.remainder.Length; x++)
                {
                    tmpParamList = new List<Param>();
                    aspFld = tmpStat.remainder[x];

                    if (aspFld.Value.IndexOf(" ") > 0)
                    {
                        tmpSplit = aspFld.Value.IndexOf(" ");
                        tmpFldType = aspFld.Value.Substring(0, tmpSplit).Trim();
                        tmpFldValue = aspFld.Value.Substring(tmpSplit + 1).Trim();

                        if (tmpFldValue.StartsWith(strMax))
                        {
                            tmpSplit = tmpFldValue.IndexOf(" ");
                            tmpFldType += " " + strMax;
                            tmpFldValue = tmpFldValue.Substring(tmpSplit + 1).Trim();
                        }

                        if (tmpFldType.EndsWith(srcDelimiter.ToString()))  // 'HORIZONTAL-TIMING,' || 'VERTICAL-TIMING,' || 'SYNC-POLARITY,'
                        {
                            tmpFldType = tmpFldType.Substring(0, tmpFldType.Length - 1).Trim();
                        }
                    }
                    else
                    {
                        tmpFldType = aspFld.Value;
                        tmpFldValue = "";
                    }

                    if (requireNoParam.ContainsKey(tmpFldType) || requireMultiLineParams.ContainsKey(tmpFldType) || String.IsNullOrEmpty(tmpFldValue))
                    {
                        tmpParamList.Add(null);
                    }
                    else
                    {
                        if (tmpFldValue.Contains(strRange))
                        {
                            tmpField = new ParamField();
                            tmpField.Parse(tmpFldValue);
                            if (tmpField.HasRange)
                            {
                                tmpParamList.Add(tmpField.BaseFrom);
                                tmpParamList.Add(tmpField.BaseTo);
                            }
                        }
                        else
                        {
                            if (requireParamList.ContainsKey(tmpFldType) && tmpFldValue.IndexOf(",") > 0)
                            {
                                tmpValList = tmpFldValue.Split(',').ToList();
                                foreach (String tmpVal in tmpValList)
                                {
/*
[ptf_aav_con_a4.atl]
000310 REQUIRE, 'CTR-FREQ-CH1', SENSOR(FREQ), AC SIGNAL,
         CONTROL, FREQ RANGE .001 HZ TO 100E+6 HZ,
         VOLTAGE RANGE .1 V TO 100V,
         TEST-EQUIP-IMP 50 OHM, TEST-EQUIP-IMP 1E6 OHM,
         COUPLING DC, COUPLING AC,
         MAX-TIME RANGE 0 SEC TO 1000 SEC,
         CNX HI  $
*/
                                    tmpField = new ParamField();
                                    if (tmpVal.Trim().StartsWith(tmpFldType))  // param preceded by field type e.g. "TEST-EQUIP-IMP 50 OHM, TEST-EQUIP-IMP 1E6 OHM,"
                                    {
                                        tmpField.Parse(tmpVal.Substring(tmpVal.IndexOf(tmpFldType) + tmpFldType.Length).Trim());
                                    }
                                    else
                                    {
                                        tmpField.Parse(tmpVal.Trim());
                                    }
                                    tmpParamList.Add(tmpField.Base);
                                }
                            }
                            else
                            {
                                tmpField = new ParamField();
                                tmpField.Parse(tmpFldValue);
                                tmpParamList.Add(tmpField.Base);
                            }
                        }
                    }
                    valList.Add(tmpFldType);
                    paramList.Add(tmpParamList);
                } // for

                tmpKeyList = new List<String>();
                tmpSortedList = null;
                for (int x = 0; x < valList.Count; x++)
                {
                    tmpKeyList.Add(valList[x]);
                    if (requireFields.ContainsKey(valList[x]))
                    {
                        tmpSortedList = new SortedList<String, int>();
                        done = false;
                        while (!done)
                        {
                            if (x + 1 < valList.Count)
                            {
                                // check for subfields
                                nextField = valList[x + 1].Trim();
                                if (! requireFields.ContainsKey(nextField))
                                {
                                    tmpSortedList.Add(nextField, 0);
                                    x++;
                                }
                                else
                                {
                                    done = true;
                                }
                            }
                            else
                            {
                                done = true;
                            }
                        }

                        foreach (KeyValuePair<String, int> kvp in tmpSortedList)
                        {
//Console.WriteLine(kvp.Key + " -> " + kvp.Value);
                            tmpKeyList.Add(kvp.Key);
                        }
                    }
                }
                // tmpOrderedKey uses the order of the parameters as listed in original statement
                tmpOrderedKey = tmpBaseKey + "|" + String.Join("|", valList);
                // tmpSortedKey sorts the key so that statements with the same parameters in a different order can be properly counted
                tmpSortedKey = tmpBaseKey + "|" + String.Join("|", tmpKeyList);

                // update param dictionary
                ASPRStatement tmpASPR_Stat = new ASPRStatement();
                tmpASPR_Stat.tpsname = asp.tpsname;
                tmpASPR_Stat.aspstatno = tmpStat.statno.Value;
                tmpASPR_Stat.asptestno = tmpStat.statno.testno;
                tmpASPR_Stat.aspstepno = tmpStat.statno.stepno;
                tmpASPR_Stat.aspfile = aspFile;
                tmpASPR_Stat.lineno = tmpStat.lineno;
                tmpASPR_Stat.linenoSpecified = true;
                tmpASPR_Stat.source = tmpStat.source;

                if (dicParams.ContainsKey(tmpSortedKey))
                {
                    if (! dicParams[tmpSortedKey].ContainsKey(tmpOrderedKey))
                    {
                        dicParams[tmpSortedKey].Add(tmpOrderedKey, new List<ASPRStatement>());
                    }
                }
                else
                {
                    dicParams.Add(tmpSortedKey, new SortedDictionary<string, List<ASPRStatement>>());
                    dicParams[tmpSortedKey].Add(tmpOrderedKey, new List<ASPRStatement>());
                }
                dicParams[tmpSortedKey][tmpOrderedKey].Add(tmpASPR_Stat);
                
                // update minmax dictionaries
                for (int i = 0; i < valList.Count; i++)
                {
                    mmVal = valList[i];
                    mmKey = tmpBaseKey + "|" + mmVal;
                    if (dicMinMax.ContainsKey(mmKey))
                    {
                        foreach (Param param in paramList[i])
                        {
                            if (param != null)
                            {
                                dicMinMax[mmKey].SetMinMax(param);
                            }
                        } //foreach
                        tmpMinMax = dicMinMax[mmKey];
                    }
                    else
                    {
                        tmpMinMax = null;
                        initMinMax = false;
                        foreach (Param param in paramList[i])
                        {
                            if (param != null)
                            {
                                if (!initMinMax)
                                {
                                    tmpMinMax = new MinMax();
                                    tmpMinMax.Key = tmpBaseKey;
                                    tmpMinMax.Type = mmVal;
                                    initMinMax = true;
                                }
                                tmpMinMax.SetMinMax(param);
                            }
                        } //foreach

                        if (tmpMinMax != null)
                        {
                            dicMinMax.Add(mmKey, tmpMinMax);
                        }
                    }
                } //for

                if (!dicMinMaxStats.ContainsKey(tmpBaseKey))
                {
                    dicMinMaxStats.Add(tmpBaseKey, new List<ASPRStatement>());
                }
                dicMinMaxStats[tmpBaseKey].Add(tmpASPR_Stat);
            }

            AnalyzeResults results = new AnalyzeResults();
            results.verb = strVerb;
            results.dicParams = dicParams;
            results.dicMinMax = dicMinMax;
            results.dicMinMaxStats = dicMinMaxStats;
            return results;
        } // analyzeRequire

        private void displayTotals(String strVerb, SortedDictionary<string, int> dicParams)
        {
            if (dicParams.Count() > 0)
            {
                int rowSum = 0;
                int rowCnt = 0;
                foreach (KeyValuePair<string, int> p in dicParams)
                {
                    txtOutput.AppendText(p.Value.ToString().PadLeft(4) + "   " + p.Key + Environment.NewLine);
                    rowSum += p.Value;
                    rowCnt++;
                }
                txtOutput.AppendText("----" + Environment.NewLine);
                txtOutput.AppendText(rowSum.ToString().PadLeft(4) + " Statements (" + rowCnt + " Types)" + Environment.NewLine);
                txtOutput.AppendText(Environment.NewLine);
            }
            else
            {
                txtOutput.AppendText("No statements with verb " + strVerb + Environment.NewLine + Environment.NewLine);
            }
        } // displayTotals

        private SortedDictionary<string, SortedDictionary<string, List<ASPRStatement>>> updateParamTotals(SortedDictionary<string, SortedDictionary<string, List<ASPRStatement>>> dict, SortedDictionary<string, SortedDictionary<string, List<ASPRStatement>>> dictTotals)
        {
            foreach (KeyValuePair<string, SortedDictionary<string, List<ASPRStatement>>> p in dict)
            {
                if (dictTotals.ContainsKey(p.Key))
                {
                    foreach (KeyValuePair<string, List<ASPRStatement>> d in p.Value)
                    {
                        if (! dictTotals[p.Key].ContainsKey(d.Key))
                        {
                            dictTotals[p.Key].Add(d.Key, new List<ASPRStatement>());
                        }
                        dictTotals[p.Key][d.Key].AddRange(d.Value);

                    }
                }
                else
                {
                    dictTotals.Add(p.Key, new SortedDictionary<string, List<ASPRStatement>>());
                    foreach (KeyValuePair<string, List<ASPRStatement>> d in p.Value)
                    {
                        dictTotals[p.Key].Add(d.Key, d.Value);
                    }
                }
            }
            return dictTotals;
        } // updateParamTotals

        private SortedDictionary<string, MinMax> updateMinMaxTotals(SortedDictionary<string, MinMax> dict, SortedDictionary<string, MinMax> dictTotals)
        {
            foreach (KeyValuePair<string, MinMax> p in dict)
            {
                if (dictTotals.ContainsKey(p.Key))
                {
                    dictTotals[p.Key].SetMinMax(p.Value.Min);
                    dictTotals[p.Key].SetMinMax(p.Value.Max);
                }
                else
                {
                    dictTotals.Add(p.Key, p.Value);
                }
            }
            return dictTotals;
        } // updateMinMaxTotals

        private SortedDictionary<string, List<ASPRStatement>> updateMinMaxTotalsStats(SortedDictionary<string, List<ASPRStatement>> dict, SortedDictionary<string, List<ASPRStatement>> dictTotals)
        {
            foreach (KeyValuePair<string, List<ASPRStatement>> p in dict)
            {
                if (dictTotals.ContainsKey(p.Key))
                {
                    dictTotals[p.Key].AddRange(p.Value.ToList());
                }
                else
                {
                    dictTotals.Add(p.Key, p.Value);
                }
            }
            return dictTotals;
        } // updateMinMaxTotals

        private XElement getNodeWithoutChildren(XElement element)
        {
            // Return XElement without descendants by making shallow copy and adding attributes
            XElement tmpItem = new XElement(element.Name);
            tmpItem.Add(element.Attributes().ToArray());
            return tmpItem;
        } // getNodeWithoutChildren

        private IEnumerable<TreeNode> getNodes(TreeNode node, XElement element)
        {
            return element.HasElements ?
                node.AddRange(from item in element.Elements()
                              let tree = new TreeNode(item.HasElements ? getNodeWithoutChildren(item).ToString() : item.ToString())
                              from newNode in getNodes(tree, item)
                              select newNode)
                              :
                new[] { node };
        } // getNodes


        public void CloseProject()
        {
            LogManager.Warn("CloseProject() Not Implemented.");
        }

        private void btnExtractATLAS_Click_1(object sender, EventArgs e)
        {

            string sourcePath = Path.Combine(ATMLContext.TESTSET_PATH, ProjectManager.GetProjectName(), "source");
            string fileName = "2053as218.as";
            Process exeProcess = new Process();
            ProcessStartInfo startInfo = exeProcess.StartInfo;
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.WorkingDirectory = sourcePath;
            startInfo.FileName = @"R:\atlas_translator\atlas.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.Arguments = " " + fileName + " out/" + fileName + ".out";
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardError = true;
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;

            exeProcess.EnableRaisingEvents = true;
            exeProcess.OutputDataReceived += new DataReceivedEventHandler(exeProcess_OutputDataReceived);
            exeProcess.ErrorDataReceived += new DataReceivedEventHandler(exeProcess_ErrorDataReceived);

            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                exeProcess.Start();
                StringBuilder sb = new StringBuilder();
                using (StreamReader std_out = exeProcess.StandardOutput)
                {
                    do
                    {
                        sb.Append(std_out.ReadLine()).Append("<br/>");
                    } while (!std_out.EndOfStream);                  //Loops until the stream ends
                    exeProcess.Close();
                    LogManager.Trace(sb.ToString());
                    
                }

                
            }
            catch( Exception err )
            {
                LogManager.Error( err );
            }
        }

        void exeProcess_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            LogManager.Error(e.Data);
        }

        void exeProcess_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            LogManager.Trace( e.Data );
        }


    } // class Form1

/*
 002010             APPLY, AC SIGNAL USING 'ACPSHVPP-3PH-ABC',
                       VOLTAGE-PHASE-A 'VOLT' V,
                       VOLTAGE-PHASE-B 'VOLT' V,
                       VOLTAGE-PHASE-C 'VOLT' V,
                       FREQ 'FREQ' HZ,
                       PHASE-ANGLE-PHASE-A 0 DEG,
                       PHASE-ANGLE-PHASE-B 120 DEG,
                       PHASE-ANGLE-PHASE-C 240 DEG,
                       CURRENT-PHASE-A MAX 'CURR' A,
                       CURRENT-PHASE-B MAX 'CURR' A,
                       CURRENT-PHASE-C MAX 'CURR' A,
                       THREE-PHASE-WYE,
                       CNX  A J1B-001  B J1B-002  C J1B-003  N J1B-004 $

*/
    public class Param
    {
        public Double Value;
        public String Unit;

        public void Parse(String strParam)
        {
            if (strParam.IndexOf(" ") > 0)
            {
                // if indexof <> lastindexof then split string on lastindexof and strip spaces -> String.Replace(" ", "")
                String strValue = strParam.Substring(0, strParam.LastIndexOf(" ")).Trim().Replace(" ", "");
                if (strValue.StartsWith("'") && strValue.EndsWith("'"))
                {
                    // variable name, do nothing
Console.WriteLine("     {" + strParam + "}");
                }
                else
                {
                    // parse numeric value and unit
                    this.Value = Double.Parse(strValue);
                    this.Unit = strParam.Substring(strParam.LastIndexOf(" ")).Trim();
                }
            }
            else
            {
                String strValue = Regex.Split(strParam, @"[^0-9E\.\+\-]+")[0];
                this.Value = Double.Parse(strParam.Substring(0, strValue.Length).Trim());
                this.Unit = strParam.Substring(strValue.Length).Trim();
            }
        } // parse

        public override String ToString()
        {
            String str = ((this.Unit != null) ? Value.ToString("0.##########", System.Globalization.CultureInfo.InvariantCulture) + " " + this.Unit : "");
            return str.Trim();
        }
    } // class Param

/*
 000200 REQUIRE, EXTERNAL, 'RAMP', SOURCE, RAMP SIGNAL,
            CONTROL,
                FREQ RANGE 75HZ TO 150HZ BY 5HZ ERRLMT +-2HZ,
                VOLTAGE-PP RANGE 7.3V TO 7.7V CONTINUOUS,
            CNX HI LO $

 050000 APPLY, RAMP SIGNAL USING 'RAMP',
            FREQ 105HZ ERRLMT +-2HZ,
            VOLTAGE-PP 7.5V,
            CNX HI J1-7 LO J3-5 $

ERRLMT + x dim – y dim
ERRLMT - x dim + y dim
ERRLMT + x dim – y PC
ERRLMT +– x dim
*/

    public class ParamField
    {
        private String strRange = "RANGE";
        private String strTo = "TO";
        private String strContinuous = "CONTINUOUS";
        private String strBy = "BY";
        private String strErrlmt = "ERRLMT";
        private String strPlus = "+";
        private String strMinus = "-";
        private String strPlusMinus = "+-";
        private String tmpStr = "";
        private String tmpErrlmt = "";

        public Param Base;
        public Param BaseFrom;
        public Param BaseTo;
        public Param By;
        public Param ErrlmtPlus;
        public Param ErrlmtMinus;

        public Boolean HasRange;
        public Boolean HasContinuous;
        public Boolean HasBy;
        public Boolean HasErrlmt;

        public void Parse(String strParamField)
        {
            if (strParamField.Contains(strRange))
            {
                this.HasRange = true;
                if (strParamField.Contains(strContinuous) || strParamField.Contains(strBy))
                {
                    if (strParamField.Contains(strContinuous))
                    {
                        this.HasContinuous = true;
                        this.HasBy = false;
                    }
                    else
                    {
                        this.HasBy = true;
                        this.HasContinuous = false;
                    }
                }
                else
                {
                    this.HasContinuous = false;
                    this.HasBy = false;
                }
            }
            else
            {
                this.HasRange = false;
                this.HasContinuous = false;
                this.HasBy = false;
            }

            if (strParamField.Contains(strErrlmt))
            {
                this.HasErrlmt = true;
            }
            else
            {
                this.HasErrlmt = false;
            }



            if (this.HasRange)
            {
                this.Base = null;
                this.BaseFrom = new Param();
                this.BaseTo = new Param();

                tmpStr = strParamField.Substring((strParamField.IndexOf(strRange) + strRange.Length), strParamField.IndexOf(strTo) - (strParamField.IndexOf(strRange) + strRange.Length)).Trim();
                this.BaseFrom.Parse(tmpStr);

                if (this.HasContinuous || this.HasBy)
                {
                    if (this.HasContinuous)
                    {
                        tmpStr = strParamField.Substring((strParamField.IndexOf(strTo) + strTo.Length), strParamField.IndexOf(strContinuous) - (strParamField.IndexOf(strTo) + strTo.Length)).Trim();
                    }
                    else // this.HasBy
                    {
                        tmpStr = strParamField.Substring((strParamField.IndexOf(strTo) + strTo.Length), strParamField.IndexOf(strBy) - (strParamField.IndexOf(strTo) + strTo.Length)).Trim();
                    }
                }
                else
                {
                    tmpStr = strParamField.Substring(strParamField.IndexOf(strTo) + strTo.Length).Trim();
                }
                this.BaseTo.Parse(tmpStr);

                if (this.HasBy)
                {
                    this.By = new Param();
                    if (this.HasErrlmt)
                    {
                        tmpStr = strParamField.Substring((strParamField.IndexOf(strBy) + strBy.Length), strParamField.IndexOf(strErrlmt) - (strParamField.IndexOf(strBy) + strBy.Length)).Trim();
                    }
                    else
                    {
                        tmpStr = strParamField.Substring(strParamField.IndexOf(strBy) + strBy.Length).Trim();
                    }
                    this.By.Parse(tmpStr);
                }
                else
                {
                    this.By = null;
                }
            }
            else
            {
                this.Base = new Param();
                this.BaseFrom = null;
                this.BaseTo = null;

                if (this.HasErrlmt)
                {
                    tmpStr = strParamField.Substring(0, strParamField.IndexOf(strErrlmt)).Trim();
                }
                else
                {
                    tmpStr = strParamField.Trim();
                }
                this.Base.Parse(tmpStr);
            }

            if (this.HasErrlmt)
            {
                this.ErrlmtPlus = new Param();
                this.ErrlmtMinus = new Param();

                tmpErrlmt = strParamField.Substring(strParamField.IndexOf(strErrlmt) + strErrlmt.Length).Trim();
                if (tmpErrlmt.Contains(strPlusMinus) || (tmpErrlmt.Contains(strPlus) && tmpErrlmt.Contains(strMinus)))
                {
                    if (tmpErrlmt.Contains(strPlusMinus))
                    {
                        tmpStr = tmpErrlmt.Substring(tmpErrlmt.IndexOf(strPlusMinus) + strPlusMinus.Length).Trim();
                        this.ErrlmtPlus.Parse(tmpStr);
                        this.ErrlmtMinus.Parse(tmpStr);
                    }
                    else if (tmpErrlmt.IndexOf(strPlus) < tmpErrlmt.IndexOf(strMinus))
                    {
                        tmpStr = tmpErrlmt.Substring((tmpErrlmt.IndexOf(strPlus) + strPlus.Length), tmpErrlmt.IndexOf(strMinus) - (tmpErrlmt.IndexOf(strPlus) + strPlus.Length)).Trim();
                        this.ErrlmtPlus.Parse(tmpStr);
                        tmpStr = tmpErrlmt.Substring(tmpErrlmt.IndexOf(strMinus) + strMinus.Length).Trim();
                        this.ErrlmtMinus.Parse(tmpStr);
                    }
                    else // tmpErrlmt.IndexOf(strMinus) < tmpErrlmt.IndexOf(strPlus)
                    {
                        tmpStr = tmpErrlmt.Substring((tmpErrlmt.IndexOf(strMinus) + strMinus.Length), tmpErrlmt.IndexOf(strPlus) - (tmpErrlmt.IndexOf(strMinus) + strMinus.Length)).Trim();
                        this.ErrlmtMinus.Parse(tmpStr);
                        tmpStr = tmpErrlmt.Substring(tmpErrlmt.IndexOf(strPlus) + strPlus.Length).Trim();
                        this.ErrlmtPlus.Parse(tmpStr);
                    }
                }
                else
                {
                    //invalid ERRLMT format
                }
            }
            else
            {
                this.ErrlmtPlus = null;
                this.ErrlmtMinus = null;
            }
        } // parse

        public override String ToString()
        {
            String str;
            
            if (this.HasRange)
            {
                str = strRange + " " + this.BaseFrom.Value + " " + this.BaseFrom.Unit + " " + strTo + " " + this.BaseTo.Value + " " + this.BaseTo.Unit;
                if (this.HasContinuous || this.HasBy)
                {
                    if (this.HasContinuous)
                    {
                        str += " " + strContinuous;
                    }
                    else // this.HasBy
                    {
                        str += " " + strBy + " " + this.By.Value + " " + this.By.Unit;
                    }
                }
            }
            else
            {
                str = this.Base.Value + " " + this.Base.Unit;
            }
            
            if (this.HasErrlmt)
            {
                if (this.ErrlmtPlus.Value == this.ErrlmtMinus.Value && this.ErrlmtPlus.Unit == this.ErrlmtMinus.Unit)
                {
                    str += " " + strErrlmt + " " + strPlusMinus + this.ErrlmtPlus.Value + " " + this.ErrlmtPlus.Unit;
                }
                else
                {
                    str += " " + strErrlmt + " " + strPlus + this.ErrlmtPlus.Value + " " + this.ErrlmtPlus.Unit + " " + strMinus + this.ErrlmtMinus.Value + " " + this.ErrlmtMinus.Unit;
                }
            }
            return str;
        }
    } // class ParamField



    public class MinMax
    {
        public String Key;
        public String Type;
        public Param Min;
        public Param Max;

        public void SetMinMax(Param param)
        {
            if (param != null)
            {
                Param conv;
                if (this.Min == null)
                {
                    this.Min = new Param();
                    this.Min.Value = param.Value;
                    this.Min.Unit = param.Unit;
                }
                else
                {
                    //convert to like units (e.g. mV to V) for comparison
                    conv = ParamManager.convertParam(param, this.Min.Unit);
                    if (conv != null)
                    {
                        if (conv.Value < this.Min.Value)
                        {
                            this.Min.Value = param.Value;
                            this.Min.Unit = param.Unit;
                        }
                    }
                }
                if (this.Max == null)
                {
                    this.Max = new Param();
                    this.Max.Value = param.Value;
                    this.Max.Unit = param.Unit;
                }
                else
                {
                    //convert to like units (e.g. mV to V) for comparison
                    conv = ParamManager.convertParam(param, this.Max.Unit);
                    if (conv != null)
                    {
                        if (conv.Value > this.Max.Value)
                        {
                            this.Max.Value = param.Value;
                            this.Max.Unit = param.Unit;
                        }
                    }
                }
            }
        } // SetMinMax

        public override String ToString()
        {
            String str;
            if ((this.Min.Value == this.Max.Value) && (this.Min.Unit == this.Max.Unit))
            {
                str = ((this.Min != null) ? this.Min.ToString() : "NULL");
            }
            else
            {
                str = ((this.Min != null) ? this.Min.ToString() : "NULL");
                str += " ~ ";
                str += ((this.Max != null) ? this.Max.ToString() : "NULL");
            }
            return str;
        } // ToString
    } // class MinMax

    public class ParamManager
    {
        private static Dictionary<String, Double> freqDimensions = new Dictionary<String, Double>()
        {
            {"HZ",  1.0},
            {"KHZ", 1000.0},
            {"MHZ", 1000000.0},
            {"GHZ", 1000000000.0},
            {"PPS",  1.0},
            {"KPPS", 1000.0}
        };

        private static Dictionary<String, Double> timeDimensions = new Dictionary<String, Double>()
        {
            {"PSEC", 0.000000000001},
            {"NSEC", 0.000000001},
            {"USEC", 0.000001},
            {"MSEC", 0.001},
            {"SEC",  1.0},
            {"MIN", 60.0},
            {"HR", 3600.0}
        };

        private static Dictionary<String, Double> currentDimensions = new Dictionary<String, Double>()
        {
            {"NA", 0.000000001},
            {"UA", 0.000001},
            {"MA", 0.001},
            {"A",  1.0},
            {"KA", 1000.0}
        };

        private static Dictionary<String, Double> resDimensions = new Dictionary<String, Double>()
        {
            {"OHM",  1.0},
            {"KOHM", 1000.0},
            {"MOHM", 1000000.0},
        };

        private static Dictionary<String, Double> voltageDimensions = new Dictionary<String, Double>()
        {
            {"UV", 0.000001},
            {"MV", 0.001},
            {"V",  1.0},
            {"KV", 1000.0}
        };

        private static Dictionary<String, Double> wattageDimensions = new Dictionary<String, Double>()
        {
            {"UW", 0.000001},
            {"MW", 0.001},
            {"W",  1.0},
            {"KW", 1000.0}
        };

        private static Dictionary<String, Double> dbDimensions = new Dictionary<String, Double>()
        {
            {"DBM", 0.0},
            {"DBW", -30.0},
            {"DBK", -60.0}
        };

        private static Dictionary<String, Double> dataDimensions = new Dictionary<String, Double>()
        {
            {"BYTE", 1.0},
            {"BYTES", 1.0}
        };

        public static Param convertParam(Param param, String convStr)
        {
            Param conv;
            if (param.Unit == convStr)
            {
                conv = new Param();
                conv.Value = param.Value;
                conv.Unit = param.Unit;
                return conv;
            }
            else
            {
                String type = "";
                Double paramFactor = 0;
                Double convFactor = 0;
                if (!String.IsNullOrEmpty(convStr) && param.Unit != null)
                {
                    if (freqDimensions.ContainsKey(param.Unit) && freqDimensions.ContainsKey(convStr))
                    {
                        paramFactor = freqDimensions[param.Unit];
                        convFactor = freqDimensions[convStr];
                        type = "FREQ";
                    }
                    if (timeDimensions.ContainsKey(param.Unit) && timeDimensions.ContainsKey(convStr))
                    {
                        paramFactor = timeDimensions[param.Unit];
                        convFactor = timeDimensions[convStr];
                        type = "TIME";
                    }
                    if (currentDimensions.ContainsKey(param.Unit) && currentDimensions.ContainsKey(convStr))
                    {
                        paramFactor = currentDimensions[param.Unit];
                        convFactor = currentDimensions[convStr];
                        type = "CURRENT";
                    }
                    if (resDimensions.ContainsKey(param.Unit) && resDimensions.ContainsKey(convStr))
                    {
                        paramFactor = resDimensions[param.Unit];
                        convFactor = resDimensions[convStr];
                        type = "RES";
                    }
                    if (voltageDimensions.ContainsKey(param.Unit) && voltageDimensions.ContainsKey(convStr))
                    {
                        paramFactor = voltageDimensions[param.Unit];
                        convFactor = voltageDimensions[convStr];
                        type = "VOLTAGE";
                    }
                    if (wattageDimensions.ContainsKey(param.Unit) && wattageDimensions.ContainsKey(convStr))
                    {
                        paramFactor = wattageDimensions[param.Unit];
                        convFactor = wattageDimensions[convStr];
                        type = "WATTAGE";
                    }
                    if (dbDimensions.ContainsKey(param.Unit) && dbDimensions.ContainsKey(convStr))
                    {
                        paramFactor = dbDimensions[param.Unit];
                        convFactor = dbDimensions[convStr];
                        type = "DB";
                    }
                    if (wattageDimensions.ContainsKey(param.Unit) && dbDimensions.ContainsKey(convStr))
                    {
                        type = "WtoDB";
                    }
                    if (dbDimensions.ContainsKey(param.Unit) && wattageDimensions.ContainsKey(convStr))
                    {
                        type = "DBtoW";
                    }
                    if (dataDimensions.ContainsKey(param.Unit) && dataDimensions.ContainsKey(convStr))
                    {
                        paramFactor = dataDimensions[param.Unit];
                        convFactor = dataDimensions[convStr];
                        type = "DATA";
                    }
                }

                if (!String.IsNullOrEmpty(type))
                {
                    conv = new Param();
                    switch (type)
                    {
                        case "FREQ":
                        case "TIME":
                        case "CURRENT":
                        case "RES":
                        case "VOLTAGE":
                        case "WATTAGE":
                        case "DATA":
                            conv.Value = param.Value * (paramFactor / convFactor);
                            conv.Unit = convStr;
                            break;
                        case "DB":
                            conv.Value = param.Value + (convFactor - paramFactor);
                            conv.Unit = convStr;
                            break;
                        case "WtoDB":
                            //convert param to Watts
                            conv = convertParam(param, "W");
                            //convert Watts to dBm
                            conv.Value = 10 * Math.Log10(1000 * conv.Value);
                            conv.Unit = "DBM";
                            //convert DBM to convStr
                            conv = convertParam(conv, convStr);
                            break;
                        case "DBtoW":
                            //convert param to dBm
                            conv = convertParam(param, "DBM");
                            //convert dBm to Watts
                            conv.Value = Math.Pow(10, (conv.Value / 10)) / 1000;
                            conv.Unit = "W";
                            //convert Watts to convStr
                            conv = convertParam(conv, convStr);
                            break;
                    }
                    return conv;
                }
                else
                {
                    return null;
                }
            }
        } // convertParam
    } // class ParamManager

    public class AnalyzeResults
    {
        public String verb;
        public SortedDictionary<string, SortedDictionary<string, List<ASPRStatement>>> dicParams;
        public SortedDictionary<string, MinMax> dicMinMax;
        public SortedDictionary<string, List<ASPRStatement>> dicMinMaxStats;

        public String DisplayParams()
        {
            String displayStr = "";
            if (dicParams.Count() > 0)
            {
                int rowSum = 0;
                int rowCnt = 0;
                foreach (KeyValuePair<string, SortedDictionary<string, List<ASPRStatement>>> p in dicParams)
                {
                    String displayKey = "";
                    int displayVal = 0;
                    int displaySum = 0;
                    // loop through and find most used OrderedKey, sum all occurences for display
                    foreach (KeyValuePair<string, List<ASPRStatement>> d in p.Value)
                        {
                        if (d.Value.Count > displayVal)
                        {
                            displayKey = d.Key;
                            displayVal += d.Value.Count;
                        }
                        displaySum += d.Value.Count;
                    }
                    displayStr += displaySum.ToString().PadLeft(4) + "   " + displayKey + Environment.NewLine;
                    rowSum += displaySum;
                    rowCnt++;
                }
                displayStr += "----" + Environment.NewLine;
                displayStr += rowSum.ToString().PadLeft(4) + " Statements (" + rowCnt + " Types)" + Environment.NewLine;
            }
            else
            {
                displayStr += "No statements for verb " + this.verb + Environment.NewLine;
            }
            displayStr += Environment.NewLine;
            return displayStr;
        }

        public String DisplayMinMax()
        {
            String displayStr = "";
            String currKey = "";
            foreach (KeyValuePair<string, MinMax> p in this.dicMinMax)
            {
                if (currKey != p.Value.Key)
                {
                    displayStr += p.Value.Key + Environment.NewLine;
                    currKey = p.Value.Key;
                }
                displayStr += "     " + p.Value.Type + " -> " + p.Value.ToString() + Environment.NewLine;
            }
            displayStr += Environment.NewLine;
            return displayStr;
        }

        public ASP_ResultsPatterns getASPResultsPatterns()
        {
            String currKey = "";
            ASP_ResultsPatterns tmpResultsPatterns = new ASP_ResultsPatterns();
            List<ASPRStatementPattern> tmpStatementPatterns = new List<ASPRStatementPattern>();
            ASPRStatementPattern tmpStatementPattern = new ASPRStatementPattern();
            List<ASPRStatement> tmpStatements = new List<ASPRStatement>();

            foreach (KeyValuePair<string, SortedDictionary<string, List<ASPRStatement>>> p in this.dicParams)
            {
                if (currKey != p.Key)
                {
                    if (currKey != "")
                    {
                        // add tmpStatements to tmpStatementPattern
                        tmpStatementPattern.Statements = tmpStatements.ToArray();
                        // add tmpStatementPattern to tmpStatementPatterns
                        tmpStatementPatterns.Add(tmpStatementPattern);
                        // reset tmpStatements
                        tmpStatements = new List<ASPRStatement>();
                        // reset tmpStatementPattern
                        tmpStatementPattern = new ASPRStatementPattern();
                    }
                    currKey = p.Key;
                    tmpStatementPattern.type = currKey;

                    foreach (KeyValuePair<string, List<ASPRStatement>> l in p.Value)
                    {
                        tmpStatements.AddRange(l.Value);
                    }
                    tmpStatementPattern.Statements = tmpStatements.ToArray();
                }
            }
            //clean up after last statementpattern
            tmpStatementPatterns.Add(tmpStatementPattern);

            tmpResultsPatterns.Patterns = tmpStatementPatterns.ToArray();

            return tmpResultsPatterns;
        }

        public ASP_ResultsParameters getASPResultsParameters()
        {
            String currKey = "";
            ASP_ResultsParameters tmpResultsParameters = new ASP_ResultsParameters();
            List<ASPRParamPattern> tmpParamPatterns = new List<ASPRParamPattern>();
            ASPRParamPattern tmpParamPattern = new ASPRParamPattern();
            List<ASPRStatement> tmpStatements = new List<ASPRStatement>();

            List<ASPRParam> tmpParams = new List<ASPRParam>();
            ASPRParam tmpParam = new ASPRParam();

//            foreach (KeyValuePair<string, SortedDictionary<string, List<ASPRStatement>>> p in this.dicParams)
            foreach (KeyValuePair<string, MinMax> p in this.dicMinMax)
            {
                if (currKey != p.Value.Key)
                {
                    if (currKey != "")
                    {
                        // add tmpParams to tmpParamPattern
                        tmpParamPattern.Params = tmpParams.ToArray();
                        // add tmpParamPattern to tmpParamPatterns
                        tmpParamPatterns.Add(tmpParamPattern);
                        // reset tmpParams
                        tmpParams = new List<ASPRParam>();
                        // reset tmpStatementPattern
                        tmpParamPattern = new ASPRParamPattern();
                    }
                    currKey = p.Value.Key;
                    tmpParamPattern.type = currKey;
                    tmpParamPattern.Statements = this.dicMinMaxStats[currKey].ToArray();

//                    foreach (KeyValuePair<string, List<ASPRStatement>> l in p.Value)
//                    {
//                        tmpStatements.AddRange(l.Value);
//                    }
//                    tmpParamPattern.Statements = tmpStatements.ToArray();
                }

                tmpParam = new ASPRParam();
                tmpParam.name = p.Value.Type;
                tmpParam.min = p.Value.Min.ToString();
                tmpParam.max = p.Value.Max.ToString();
                tmpParams.Add(tmpParam);
            }
            //clean up after last parampattern
            tmpParamPattern.Params = tmpParams.ToArray();
            tmpParamPatterns.Add(tmpParamPattern);

            tmpResultsParameters.Parameters = tmpParamPatterns.ToArray();

            return tmpResultsParameters;
        }
    } // class AnalyzeResults

    public class OutputLU
    {
        public List<String> luFiles;
//        public SortedDictionary<String, SortedDictionary<String, String>> luSD;
        public SortedDictionary<string, SortedDictionary<string, SortedDictionary<string, string>>> luSD;
//        public SortedDictionary<String, SortedDictionary<String, List<String>>> dupSD;
        public SortedDictionary<string, SortedDictionary<string, SortedDictionary<string, List<string>>>> dupSD;
    } // class OutputLU

    public static class TreeViewNode
    {
        public static IEnumerable<TreeNode> AddRange(this TreeNode collection, IEnumerable<TreeNode> nodes)
        {
            var items = nodes.ToArray();
            collection.Nodes.AddRange(items);
            return new[] { collection };
        }
    }

} // namespace
