/*
* Copyright (c) 2014 Universal Technical Resource Services, Inc.
* 
* This Source Code Form is subject to the terms of the Mozilla Public
* License, v. 2.0. If a copy of the MPL was not distributed with this
* file, You can obtain one at http://mozilla.org/MPL/2.0/.
*/

#error Couldn't generate code.
/*
System.Xml.Schema.XmlSchemaException: Undefined complexType 'urn:IEEE-1641:2010:STDBSC:SignalFunctionType' is used as a base for complex type extension.
   at System.Xml.Schema.XmlSchemaSet.InternalValidationCallback(Object sender, ValidationEventArgs e)
   at System.Xml.Schema.BaseProcessor.SendValidationEvent(XmlSchemaException e, XmlSeverityType severity)
   at System.Xml.Schema.Compiler.CompileComplexContentExtension(XmlSchemaComplexType complexType, XmlSchemaComplexContent complexContent, XmlSchemaComplexContentExtension complexExtension)
   at System.Xml.Schema.Compiler.CompileComplexType(XmlSchemaComplexType complexType)
   at System.Xml.Schema.Compiler.Compile()
   at System.Xml.Schema.Compiler.Execute(XmlSchemaSet schemaSet, SchemaInfo schemaCompiledInfo)
   at System.Xml.Schema.XmlSchemaSet.Compile()
   at CodeGeneration.Utility.CompileSchema(XmlSchema schema)
   at CodeGeneration.Generators.XsdClassGenerator..ctor(XmlSchema schema)
   at BlueToque.XsdToClasses.XsdCodeGenerator.OnGenerateCode(String inputFileName, String inputFileContent)
   at BlueToque.XsdToClasses.CustomTool.GenerateCode(String inputFileName, String inputFileContent)
*/