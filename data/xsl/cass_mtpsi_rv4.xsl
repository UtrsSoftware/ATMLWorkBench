<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0"
                xmlns="urn:IEEE-1671.4:2009.03:TestConfiguration"
                xmlns:tpsi="urn:MyNamespace"
                xmlns:atml="urn:utrs.atml-reader-tools"
                xmlns:tc="urn:IEEE-1671.4:2009.03:TestConfiguration"
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                xmlns:c="urn:IEEE-1671:2010:Common"
                xsi:schemaLocation=
                        "urn:MyNamespace
                            cass_mtpsi_rv2.xsd
                         urn:IEEE-1671:2010:Common
                            Common.xsd"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform" >
    <xsl:output method="xml"  encoding="utf-8"/>
    <xsl:param name="documentName"></xsl:param>

    <xsl:template match="/" >

        <xsl:element name="TestConfiguration" >
            <xsl:variable name="mtpsiId" select="tpsi:CASS_MTPSI/tpsi:CASS_MTPSI_page/tpsi:UUT/tpsi:UUT_ID/@TPS_Name" />
            <xsl:variable name="classification" select="tpsi:CASS_MTPSI/tpsi:CASS_MTPSI_page/tpsi:OP_Data/@R_T_CLASS" />
            <xsl:attribute name="uuid" ><xsl:value-of select="atml:GetDocumentReference($documentName, 'TEST_CONFIGURATION', 'ATML Test Configuration', 'Other', 'text/xml' )" /></xsl:attribute>
            <xsl:choose>
                <xsl:when test="$classification='UNCLASSIFIED'" >
                    <xsl:attribute name="classified" >false</xsl:attribute>
                </xsl:when>
                <xsl:otherwise>
                    <xsl:attribute name="classified" >true</xsl:attribute>
                </xsl:otherwise>
            </xsl:choose>
            <xsl:attribute name="securityClassification" ><xsl:value-of select="$classification" /></xsl:attribute>
            <xsl:call-template name="process-configuration-manager" >
                    <xsl:with-param name="mtpsiId" select="$mtpsiId" />
            </xsl:call-template>
            <xsl:call-template name="process-uut"  />
            <xsl:call-template name="process-test-equipment" />
            <xsl:call-template name="process-test-program-elements" />
            <xsl:call-template name="process-ancillary" />
            <xsl:element name="AdditionalSoftware" >
            </xsl:element>
        </xsl:element>
    </xsl:template>

    <!--
    Builds the Configuration Manager section of the Test Configuration document.
    -->
    <xsl:template name="process-configuration-manager">
        <xsl:param name="mtpsiId" />
        <xsl:element name="ConfigurationManager" >
            <xsl:attribute name="name" ><xsl:value-of select="$mtpsiId" /></xsl:attribute>
            <xsl:attribute name="cageCode" ></xsl:attribute>
            <xsl:element name="Contacts" />
            <xsl:element name="FaxNumber" />
            <xsl:element name="MailingAddress" />
        </xsl:element>
    </xsl:template>

    <xsl:template name="process-uut">
        <xsl:for-each select="tpsi:CASS_MTPSI/tpsi:CASS_MTPSI_page/tpsi:UUT" >
            <xsl:element name="TestedUUTs" >
                <xsl:element name="TestedUUT" >
                    <xsl:variable name="partNo" select="tpsi:UUT_ID/@Part_Number" />
                    <xsl:variable name="tpsName" select="tpsi:UUT_ID/@TPS_Name" />
                    <xsl:variable name="ofpSwitchPin" select="tpsi:UUT_ID/@OFP_SW_PIN" />
                    <xsl:variable name="swNo" select="tpsi:UUT_ID/@SW_NO" />
                    <xsl:variable name="testType" select="tpsi:UUT_ID/@TEST_TYPE" />
                    <xsl:variable name="model" select="tpsi:UUT_Data/@Model" />
                    <xsl:variable name="nomen" select="tpsi:UUT_Data/@Nomen" />
                    <xsl:variable name="system" select="tpsi:UUT_Data/@System" />
                    <xsl:variable name="refDes" select="tpsi:UUT_Data/@Ref_Des" />
                    <xsl:variable name="wuc" select="tpsi:UUT_Data/@WUC" />
                    <xsl:variable name="tpm" select="tpsi:UUT_Data/@TPM" />
                    <xsl:variable name="tm" select="tpsi:UUT_Data/@TM" />
                    <xsl:variable name="tec" select="tpsi:UUT_Data/@TEC" />
                    <xsl:variable name="uuid" select="atml:GetUUTReferenceId($partNo, $tpsName, $ofpSwitchPin, $swNo, $testType, $nomen, $model, $system, $refDes, $wuc, $tpm, $tm, $tec)" />
                    <xsl:if test="$uuid!=''" >
                        <xsl:element name="c:DescriptionDocumentReference"  >
                            <xsl:attribute name="ID" ><xsl:value-of select="$model" />-<xsl:value-of select="format-number(position(),'000')" /></xsl:attribute>
                            <xsl:attribute name="uuid" ><xsl:value-of select="$uuid" /></xsl:attribute>
                        </xsl:element>
                    </xsl:if>
                </xsl:element>
            </xsl:element>
        </xsl:for-each>
    </xsl:template>

    <xsl:template name="process-test-equipment">
        <xsl:element name="TestEquipment" >

            <!--
             First lets iterate through all the test stations. We will do a lookup for the station type and station
             If the station does not exist, we will create a test station stub document for the station type
             and store it in the database.
            -->
            <xsl:for-each select="tpsi:CASS_MTPSI/tpsi:CASS_MTPSI_page/tpsi:Min_Sta_req" >
                <xsl:variable name="stationType" select="@Sta_Type" />
                <xsl:variable name="changeNo" select="@Change_No" />
                <xsl:variable name="station" select="@Station" />
                <xsl:variable name="dateEntry" select="@Date_Entry" />
                <xsl:variable name="fst" select="@FST" />
                <!--
                    Now we need to iterate through all the instruments supposedly located within the test station. We need to look them
                    up in the asset table by the station type and instrument nomenclature.
                -->
                <xsl:element name="TestEquipmentItem" >
                    <xsl:variable name="testStationId" select="atml:InitializeTestStaion( $stationType, $station, $changeNo, $dateEntry, $fst )" />
                    <xsl:element name="c:DescriptionDocumentReference" >
                        <xsl:attribute name="ID" ><xsl:value-of select="$station" />_<xsl:value-of select="$stationType" />-<xsl:value-of select="format-number(position(),'000')" /></xsl:attribute>
                        <xsl:attribute name="uuid" >
                            <xsl:value-of select="$testStationId" />
                        </xsl:attribute>
                    </xsl:element>
                    <!-- Iterate Instruments     -->
                    <xsl:choose>
                        <xsl:when test="/tpsi:CASS_MTPSI/tpsi:CASS_MTPSI_page/tpsi:ATE_assets[@Station]" >
                            <xsl:comment>Iterating Specific Test Station</xsl:comment>
                            <xsl:for-each select="/tpsi:CASS_MTPSI/tpsi:CASS_MTPSI_page/tpsi:ATE_assets[@Station=$station]" >
                                <xsl:variable name="assetId" select="@Asset_Identifier" />
                                <xsl:element name="Instrumentation" >
                                    <xsl:element name="c:DescriptionDocumentReference" >
                                        <xsl:attribute name="ID" ><xsl:value-of select="$assetId" />-<xsl:value-of select="format-number(position(),'000')" /></xsl:attribute>
                                        <xsl:attribute name="uuid" >
                                            <xsl:value-of select="atml:FindInstrumentReference($assetId, $testStationId)" />
                                        </xsl:attribute>
                                        <!-- Need to lookup for description and identification -->
                                    </xsl:element>
                                </xsl:element>
                            </xsl:for-each>
                        </xsl:when>
                        <xsl:otherwise>
                            <xsl:comment>Iterating Non Specific Test Station</xsl:comment>
                            <xsl:for-each select="/tpsi:CASS_MTPSI/tpsi:CASS_MTPSI_page/tpsi:ATE_assets" >
                                <xsl:variable name="assetId" select="@Asset_Identifier" />
                                <xsl:element name="Instrumentation" >
                                    <xsl:element name="c:DescriptionDocumentReference" >
                                        <xsl:attribute name="ID" ><xsl:value-of select="$assetId" />-<xsl:value-of select="format-number(position(),'000')" /></xsl:attribute>
                                        <xsl:attribute name="uuid" >
                                            <xsl:value-of select="atml:FindInstrumentReference($assetId, $testStationId)" />
                                        </xsl:attribute>
                                        <!-- Need to lookup for description and identification -->
                                    </xsl:element>
                                </xsl:element>
                            </xsl:for-each>
                        </xsl:otherwise>
                    </xsl:choose>
                </xsl:element>
            </xsl:for-each>
        </xsl:element>
    </xsl:template>

    <xsl:template name="process-test-program-elements">
        <xsl:element name="TestProgramElements" >
            <xsl:call-template name="process-tps-hardware" />
            <xsl:call-template name="process-documentation" />
            <xsl:call-template name="process-uut-documentation" />
        </xsl:element>
    </xsl:template>

    <xsl:template name="process-tps-hardware">
        <xsl:for-each select="tpsi:CASS_MTPSI/tpsi:CASS_MTPSI_page/tpsi:OTPH" >
            <xsl:element name="TpsHardware" >
                <xsl:attribute name="quantity" ><xsl:value-of select="@Quantity" /></xsl:attribute>
                <xsl:attribute name="type" ><xsl:value-of select="@Type" /></xsl:attribute>
                <xsl:variable name="partNo" select="@Part_number" />
                <xsl:element name="c:DescriptionDocumentReference" >
                    <xsl:attribute name="ID" ><xsl:value-of select="$partNo" />-<xsl:value-of select="format-number(position(),'000')" /></xsl:attribute>
                    <xsl:attribute name="uuid" >
                        <xsl:value-of select="atml:LookupReferenceByPartNumber($partNo,
                                        'ATMLModelLibrary.model.equipment.TestAdapterDescription1' )"/>
                    </xsl:attribute>

                    <!-- Need to lookup for description and identification -->
                </xsl:element>
            </xsl:element>
        </xsl:for-each>
    </xsl:template>
		
		<xsl:template name="process-ancillary">
			<xsl:element name="AdditionalResources" >
        <xsl:for-each select="tpsi:CASS_MTPSI/tpsi:CASS_MTPSI_page/tpsi:Ancillary" >
            <xsl:element name="AdditionalResource" >
                <xsl:attribute name="quantity" ><xsl:value-of select="@Quantity" /></xsl:attribute>
                <xsl:attribute name="type" ></xsl:attribute>
                <xsl:variable name="partNo" select="@Part_Number" />
								<xsl:element name="c:DescriptionDocumentReference" >
                    <xsl:attribute name="ID" ><xsl:value-of select="$partNo" />-<xsl:value-of select="format-number(position(),'000')" /></xsl:attribute>
                    <xsl:attribute name="uuid" >
                        <xsl:value-of select="atml:LookupReferenceByPartNumber($partNo,
                                        'ATMLModelLibrary.model.equipment.TestAdapterDescription1' )"/>
                    </xsl:attribute>

                    <!-- Need to lookup for description and identification -->
                </xsl:element>								
            </xsl:element>
        </xsl:for-each>
			</xsl:element>
    </xsl:template>		
		
    <xsl:template name="process-documentation" >
        <xsl:for-each select="tpsi:CASS_MTPSI/tpsi:CASS_MTPSI_page/tpsi:OP_Data" >
            <xsl:variable name="otpi" select="@OTPI" />
            <xsl:variable name="tpi" select="@TPI" />
            <xsl:variable name="otpm" select="@OTPM" />
            <xsl:variable name="eteTime" select="@ETE_Time" />
            <xsl:variable name="rtClass" select="@R_T_CLASS" />
            <xsl:variable name="turboMode" select="@TURBO_MODE" />
            <xsl:if test="$otpi != '' " >
                <xsl:element name="Documentation" >
                    <xsl:attribute name="uuid" ><xsl:value-of select="atml:GetDocumentReference($otpi, 'OTPI', 'Operational Test Program Instruction', 'Other', '' )" /></xsl:attribute>
                    <xsl:attribute name="name" >OTPI</xsl:attribute>
                    <xsl:attribute name="documentNumber" ><xsl:value-of select="$otpi" /></xsl:attribute>
                </xsl:element>
            </xsl:if>
            <xsl:if test="$tpi != '' " >
                <xsl:element name="Documentation" >
                    <xsl:attribute name="uuid" ><xsl:value-of select="atml:GetDocumentReference($tpi, 'TPI', 'Test Program Instruction', 'Other', '' )" /></xsl:attribute>
                    <xsl:attribute name="name" >TPI</xsl:attribute>
                    <xsl:attribute name="documentNumber" ><xsl:value-of select="$tpi" /></xsl:attribute>
                </xsl:element>
            </xsl:if>
            <xsl:if test="$otpm != '' " >
                <xsl:element name="Documentation" >
                    <xsl:attribute name="uuid" ><xsl:value-of select="atml:GetDocumentReference($otpm, 'OTPM', 'Operation Test Program Medium', 'Other', '' )" /></xsl:attribute>
                    <xsl:attribute name="name" >OTPM</xsl:attribute>
                    <xsl:attribute name="documentNumber" ><xsl:value-of select="$otpm" /></xsl:attribute>
                </xsl:element>
            </xsl:if>
        </xsl:for-each>
    </xsl:template>

    <xsl:template name="process-uut-documentation">
        <xsl:for-each select="tpsi:CASS_MTPSI/tpsi:CASS_MTPSI_page/tpsi:UUT" >
            <xsl:variable name="wuc" select="tpsi:UUT_DATA/@WUC" />
            <xsl:variable name="tpm" select="tpsi:UUT_DATA/@TPM" />
            <xsl:variable name="tm" select="tpsi:UUT_DATA/@TM" />
            <xsl:variable name="tec" select="tpsi:UUT_DATA/@TEC" />
            <xsl:if test="$tm != '' " >
                <xsl:element name="Documentation" >
                    <xsl:attribute name="uuid" ><xsl:value-of select="atml:GetDocumentReference($tm, 'TM', 'Technical Manual', 'Other', '' )" /></xsl:attribute>
                    <xsl:attribute name="name" >TM</xsl:attribute>
                    <xsl:attribute name="documentNumber" ><xsl:value-of select="$tm" /></xsl:attribute>
                </xsl:element>
            </xsl:if>
        </xsl:for-each>
    </xsl:template>


</xsl:stylesheet>
