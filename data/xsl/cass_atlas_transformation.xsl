<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0"
                xmlns="urn:IEEE-1671.1:2009:TestDescription"
                xmlns:std="urn:IEEE-1641:2010:STDBSC"
                xmlns:atml="urn:utrs.atml-translator-tools"
                xmlns:utrs="urn:utrs.atml-extensions"
                xmlns:tc="urn:IEEE-1671.4:2009.03:TestConfiguration"
                xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
                xmlns:c="urn:IEEE-1671:2010:Common"
                xmlns:hc="urn:IEEE-1671:2010:HardwareCommon"
                xmlns:exslt="http://exslt.org/common"
                xmlns:uut="urn:IEEE-1671.3:2009.03:UUTDescription"
                xsi:schemaLocation=
                        "urn:MyNamespace
                            cass_mtpsi_rv2.xsd
                         urn:IEEE-1671:2010:Common
                            Common.xsd"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="xml" encoding="utf-8"/>

    <xsl:variable name="g_mainProcedure" select="//procedure[@main_procedure='true']"/>
    <xsl:variable name="g_station-type" select="//atlas/@type"/>
    <xsl:variable name="g_tsfName" select="concat($g_station-type,'_atlas' )"/>
    <xsl:variable name="g_tsfNameSpace" select="concat($g_tsfName,'.xsd')"/>

    <xsl:template match="/">

        <xsl:variable name="uutname" select="//uut/@name"/>
        <xsl:variable name="uutid" select="//uut/@id"/>
        <xsl:variable name="ports" select="atml:GetInterfacePorts( $uutid )"/>
        <xsl:variable name="uut" select="atml:GetUUTDescription( $uutid )"/>
        <xsl:variable name="connectors" select="$uut/uut:Hardware/hc:Interface/c:Connectors/c:Connector"/>

        <xsl:comment>================================</xsl:comment>
        <xsl:comment>Create Test Description Document</xsl:comment>
        <xsl:comment>================================</xsl:comment>

        <TestDescription
                xmlns = "urn:IEEE-1671.1:2009:TestDescription"
                xmlns:xsi = "http://www.w3.org/2001/XMLSchema-instance"
                xmlns:hc = "urn:IEEE-1671:2010:HardwareCommon"
                xmlns:c = "urn:IEEE-1671:2010:Common"
                xsi:schemaLocation = "urn:IEEE-1671.1:2009:TestDescription TestDescription.xsd" >
            <xsl:attribute name="uuid" ><xsl:value-of select="atml:GenerateTestDescriptionUUID()"/></xsl:attribute>

            <xsl:comment>===============================</xsl:comment>
            <xsl:comment>Create UUT Description Section</xsl:comment>
            <xsl:comment>===============================</xsl:comment>
            <xsl:comment>This section is create from the</xsl:comment>
            <xsl:comment>UUT data stored in the document</xsl:comment>
            <xsl:comment>database stored with the uuid</xsl:comment>
            <xsl:comment>{<xsl:value-of select="$uutid"/>}
            </xsl:comment>
            <xsl:comment>===============================</xsl:comment>
            <UUT>
                <xsl:if test="$uutname!=''">
                    <xsl:if test="$uutid!=''">
                        <xsl:call-template name="uut-description">
                            <xsl:with-param name="uutId" select="$uutid"/>
                            <xsl:with-param name="uutName" select="$uutname"/>
                        </xsl:call-template>
                    </xsl:if>
                </xsl:if>
            </UUT>

            <xsl:comment>======================================</xsl:comment>
            <xsl:comment>Create Interface Requirements Section</xsl:comment>
            <xsl:comment>======================================</xsl:comment>
            <xsl:comment>The data for this section comes from</xsl:comment>
            <xsl:comment>the connection information stored in</xsl:comment>
            <xsl:comment>the UUT database.</xsl:comment>
            <xsl:comment>======================================</xsl:comment>
            <InterfaceRequirements>

                <xsl:comment>====================</xsl:comment>
                <xsl:comment>Create Ports Section</xsl:comment>
                <xsl:comment>====================</xsl:comment>
                <xsl:call-template name="ports">
                    <xsl:with-param name="ports" select="$ports"/>
                </xsl:call-template>

                <xsl:comment>=========================</xsl:comment>
                <xsl:comment>Create Connectors Section</xsl:comment>
                <xsl:comment>=========================</xsl:comment>
                <xsl:call-template name="connectors">
                    <xsl:with-param name="connectors" select="$connectors"/>
                </xsl:call-template>

                <!-- ========================== -->
                <!-- Create Test Points Section -->
                <!-- ========================== -->
                <!--
                    What do we do here? One idea is to walk through all the measures and determine the connections
                    - then do we create a Port with this information?
                -->

                <!-- ========================================= -->
                <!-- Create Electro Optical Interfaces Section -->
                <!-- ========================================= -->

                <!-- ======================= -->
                <!-- Create Fixtures Section -->
                <!-- ======================= -->

                <!-- ================================== -->
                <!-- Create Signal Conditioning Section -->
                <!-- ================================== -->

            </InterfaceRequirements>

            <xsl:call-template name="create-signal-requirements-section"/>

            <xsl:comment>========================================</xsl:comment>
            <xsl:comment>Create Detailed Test Information Section</xsl:comment>
            <xsl:comment>========================================</xsl:comment>
            <xsl:call-template name="detailed-information"/>


            <FailureFaultData>
            </FailureFaultData>
        </TestDescription>

    </xsl:template>


    <!-- ==================================================== -->
    <!-- ================ Signal Requirement ================ -->
    <!-- ==================================================== -->
    <xsl:template name="signal-requirement">
        <xsl:comment>@file="<xsl:value-of select="./atlas_source/@file"/>" @statement_number="<xsl:value-of
                select="./atlas_source/@statement_number"/>" @line_number="<xsl:value-of
                select="./atlas_source/@line_number"/>"
        </xsl:comment>
        <xsl:element name="SignalRequirement">
            <xsl:attribute name="role">Source</xsl:attribute>
            <xsl:comment>@file="<xsl:value-of select="./atlas_source/@file"/>" @statement_number="<xsl:value-of
                    select="./atlas_source/@statement_number"/>" @line_number="<xsl:value-of
                    select="./atlas_source/@line_number"/>"
            </xsl:comment>
            <xsl:element name="TsfClass">
                <xsl:attribute name="tsfLibraryID">TSF1</xsl:attribute>
                <!-- TODO: Figure out how to do a lookup for library id -->
                <xsl:if test="./signal_component/ieee_1641/tsf/@type">
                    <xsl:attribute name="tsfClassName">
                        <xsl:value-of select="./signal_component/ieee_1641/tsf/@type"/>
                    </xsl:attribute>
                </xsl:if>
                <xsl:if test="not(./signal_component/ieee_1641/tsf/@type)">
                    <xsl:variable name="type" select="./signal_component/atlas/noun/@type"/>
                    <xsl:attribute name="tsfClassName">
                        <xsl:value-of select="$type"/>
                    </xsl:attribute>
                </xsl:if>
            </xsl:element>
            <xsl:for-each select="./noun_modifiers/noun_modifier">

                <!-- ============================================================================= -->
                <xsl:variable name="noun" select="signal_component/atlas/noun/@type"/>
                <xsl:variable name="source" select="signal_component/atlas/noun_modifier/@type"/>
                <xsl:variable name="attribute" select="atml:LookupSignalAttribute( $noun, $source )"/>
                <xsl:variable name="maximum" select="./number/@maximum='true'"/>
                <xsl:element name="TsfClassAttribute">
                    <xsl:attribute name="role">Limit</xsl:attribute>

                    <xsl:comment>@file="<xsl:value-of select="../../atlas_source/@file"/>"
                        @statement_number="<xsl:value-of select="../../atlas_source/@statement_number"/>" @line_number="<xsl:value-of
                                select="../../atlas_source/@line_number"/>"
                    </xsl:comment>

                    <xsl:element name="Name">
                        <xsl:value-of select="$attribute/modifier/@tsf_attribute"/>
                        <xsl:if test="$maximum"></xsl:if>
                    </xsl:element>

                    <xsl:element name="Value">
                        <xsl:call-template name="datum">
                            <xsl:with-param name="value" select="./number/@value"/>
                            <xsl:with-param name="type" select="./number/@type"/>
                            <xsl:with-param name="unit" select="./number/@unit"/>
                            <xsl:with-param name="qualifier" select="$attribute/modifier/@tsf_qualifier"/>
                            <xsl:with-param name="range" select="./range"/>
                            <xsl:with-param name="errorLimit" select="./error_limit"/>
                            <xsl:with-param name="resolution" select="./resolution"/>
                            <xsl:with-param name="maximum" select="$maximum"/>
                        </xsl:call-template>
                    </xsl:element>
                </xsl:element>
                <!-- ============================================================================= -->
                <!--
        <xsl:if test="./signal_component/ieee_1641/attribute" >
            <xsl:element name="TsfClassAttribute" >
                                        <xsl:attribute name="role" >Limit</xsl:attribute>
                <xsl:comment>@file="<xsl:value-of select="../../atlas_source/@file" />" @statement_number="<xsl:value-of select="../../atlas_source/@statement_number" />" @line_number="<xsl:value-of select="../../atlas_source/@line_number" />" </xsl:comment>
                <xsl:element name="Name" ><xsl:value-of select="./signal_component/ieee_1641/attribute/@type" /><xsl:if test="./number/@maximum='true' " >_max</xsl:if></xsl:element>
                <xsl:element name="Value" >
                    <xsl:call-template name="datum">
                        <xsl:with-param name="value" select="./number/@value" />
                        <xsl:with-param name="unit" select="./number/@unit" />
                        <xsl:with-param name="qualifier" select="./signal_component/ieee_1641/qualifiers/qualifier" />
                        <xsl:with-param name="range" select="./range" />
                        <xsl:with-param name="errorLimit" select="./error_limit" />
                        <xsl:with-param name="resolution" select="./resolution" />
                    </xsl:call-template>
                </xsl:element>
            </xsl:element>
        </xsl:if>
        <xsl:if test="not(./signal_component/ieee_1641/attribute)" >
            <xsl:element name="TsfClassAttribute" >
                                        <xsl:attribute name="role" >Limit</xsl:attribute>
                <xsl:comment>No IEEE-1641 Attribute for <xsl:value-of select="./signal_component/atlas/noun_modifier/@type" /></xsl:comment>
                <xsl:comment>@file="<xsl:value-of select="../../atlas_source/@file" />" @statement_number="<xsl:value-of select="../../atlas_source/@statement_number" />" @line_number="<xsl:value-of select="../../atlas_source/@line_number" />" </xsl:comment>
                <xsl:element name="Name" ><xsl:value-of select="./signal_component/atlas/noun_modifier/@type" /></xsl:element>
                <xsl:element name="Value" >
                    <xsl:if test="./number/@maximum='true' " >range MAX </xsl:if><xsl:value-of select="./number/@value" /><xsl:value-of select="./number/@unit" />
                </xsl:element>
            </xsl:element>
        </xsl:if>
                -->
            </xsl:for-each>
        </xsl:element>
    </xsl:template>


    <!-- ======================================= -->
    <!-- ================ Datum ================ -->
    <!-- ======================================= -->
    <xsl:template name="datum">
        <xsl:param name="value"/>
        <xsl:param name="type"/>
        <xsl:param name="unit"/>
        <xsl:param name="qualifier"/>
        <xsl:param name="range"/>
        <xsl:param name="errorLimit"/>
        <xsl:param name="resolution"/>
        <xsl:param name="maximum"/>

        <xsl:variable name="isNumber" select="number($value)=$value"/>
        <xsl:variable name="datumType" select="atml:ConvertToCommonType($type)"/>

        <xsl:comment>Type: <xsl:value-of select="$type" /></xsl:comment>
        <xsl:comment>Datum Type: <xsl:value-of select="$datumType" /></xsl:comment>

        <xsl:element name="c:Datum">
            <xsl:choose>
                <xsl:when test="$datumType='c:'">
                    <xsl:attribute name="xsi:type">c:string</xsl:attribute>
                </xsl:when>
                <xsl:when test="$isNumber">
                    <xsl:attribute name="xsi:type">
                        <xsl:value-of select="$datumType"/>
                    </xsl:attribute>
                </xsl:when>
                <xsl:otherwise>
                    <xsl:attribute name="xsi:type">
                        <xsl:value-of select="$datumType"/>
                    </xsl:attribute>
                </xsl:otherwise>
            </xsl:choose>
            <xsl:if test="$unit">
                <xsl:attribute name="standardUnit">
                    <xsl:value-of select="$unit"/>
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="$qualifier">
                <xsl:attribute name="unitQualifier">
                    <xsl:value-of select="$qualifier"/>
                </xsl:attribute>
            </xsl:if>
            <xsl:attribute name="value">
                <xsl:choose>
                    <xsl:when test="$type='double' and not($isNumber)">
                        <xsl:value-of select="0"/>
                    </xsl:when>
                    <xsl:when test="$type='decimal' and not($isNumber)">
                        <xsl:value-of select="0"/>
                    </xsl:when>
                    <xsl:when test="$type='integer' and not($isNumber)">
                        <xsl:value-of select="0"/>
                    </xsl:when>
                    <xsl:when test="$type='long' and not($isNumber)">
                        <xsl:value-of select="0"/>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:value-of select="$value"/>
                    </xsl:otherwise>
                </xsl:choose>

            </xsl:attribute>
            <xsl:if test="resolution">
                <xsl:element name="resolution">
                    <xsl:value-of select="$resolution"/>
                </xsl:element>
            </xsl:if>
            <xsl:if test="$errorLimit">
                <xsl:element name="c:ErrorLimits">
                    <xsl:call-template name="limit-pair">
                        <xsl:with-param name="range" select="$errorLimit"/>
                        <xsl:with-param name="condition" select="''"/>
                    </xsl:call-template>
                </xsl:element>
            </xsl:if>
            <xsl:if test="$maximum">
                <xsl:call-template name="max_range">
                    <xsl:with-param name="value" select="$value"/>
                    <xsl:with-param name="unit" select="$unit"/>
                    <xsl:with-param name="qualifier" select="$qualifier"/>
                    <xsl:with-param name="resolution" select="$qualifier"/>
                </xsl:call-template>
            </xsl:if>
            <xsl:if test="$range">
                <xsl:call-template name="range">
                    <xsl:with-param name="range" select="$range"/>
                </xsl:call-template>
            </xsl:if>
        </xsl:element>
    </xsl:template>


    <!-- ======================================= -->
    <!-- ================ Range ================ -->
    <!-- ======================================= -->
    <xsl:template name="range">
        <xsl:param name="range"/>
        <xsl:element name="c:Range">
            <xsl:call-template name="limit">
                <xsl:with-param name="range" select="$range"/>
                <xsl:with-param name="condition" select="''"/>
            </xsl:call-template>
        </xsl:element>
    </xsl:template>


    <!-- =============================================== -->
    <!-- ================ Maximum Range ================ -->
    <!-- =============================================== -->
    <xsl:template name="max_range">
        <xsl:param name="value"/>
        <xsl:param name="unit"/>
        <xsl:param name="qualifier"/>
        <xsl:param name="resolution"/>
        <xsl:element name="c:Range">
            <xsl:call-template name="limit-single">
                <xsl:with-param name="comparator" select="'LE'"/>
                <xsl:with-param name="unit" select="$unit"/>
                <xsl:with-param name="value" select="$value"/>
                <xsl:with-param name="type" >double</xsl:with-param>
                <xsl:with-param name="qualifier" select="$qualifier"/>
            </xsl:call-template>
        </xsl:element>
    </xsl:template>


    <!-- ======================================= -->
    <!-- ================ Limit ================ -->
    <!-- ======================================= -->
    <xsl:template name="limit">
        <xsl:param name="range"/>
        <xsl:param name="condition"/>
        <!-- Check if there is an upper and lower limit - then Limit Pair -->
        <xsl:if test="$range/from and $range/to">
            <xsl:call-template name="limit-pair">
                <xsl:with-param name="range" select="$range"/>
                <xsl:with-param name="condition" select="''"/>
            </xsl:call-template>
        </xsl:if>
        <!-- Check if we asre dealing with a Condition -->
        <xsl:if test="$condition">
            <xsl:call-template name="limit-pair">
                <xsl:with-param name="range" select="''"/>
                <xsl:with-param name="condition" select="$condition"/>
            </xsl:call-template>
        </xsl:if>
        <!-- Check if there is a MAX or MIN - then Limit Single -->
        <!-- TODO: Don't know how to check for a Limit Mask at this time -->
        <!-- TODO: Also don't know what would constitute an Expected Limit -->
    </xsl:template>

    <!-- ============================================ -->
    <!-- ================ Limit Pair ================ -->
    <!-- ============================================ -->
    <xsl:template name="limit-pair">
        <xsl:param name="range"/>
        <xsl:param name="condition"/>
        <xsl:element name="c:LimitPair">
            <xsl:attribute name="operator">AND</xsl:attribute>
            <xsl:choose>
                <xsl:when test="$range">
                    <xsl:if test="$range/from">
                        <xsl:element name="c:Limit">
                            <xsl:attribute name="comparator">GE</xsl:attribute>
                            <xsl:element name="c:Datum">
                                <xsl:attribute name="xsi:type">c:double</xsl:attribute>
                                <xsl:attribute name="standardUnit">
                                    <xsl:value-of select="$range/from/@unit"/>
                                </xsl:attribute>
                                <xsl:attribute name="value">
                                    <xsl:value-of select="$range/from/@value"/>
                                </xsl:attribute>
                            </xsl:element>
                        </xsl:element>
                    </xsl:if>
                    <xsl:if test="$range/to">
                        <xsl:element name="c:Limit">
                            <xsl:attribute name="comparator">LE</xsl:attribute>
                            <xsl:element name="c:Datum">
                                <xsl:attribute name="xsi:type">c:double</xsl:attribute>
                                <xsl:attribute name="standardUnit">
                                    <xsl:value-of select="$range/to/@unit"/>
                                </xsl:attribute>
                                <xsl:attribute name="value">
                                    <xsl:value-of select="$range/to/@value"/>
                                </xsl:attribute>
                            </xsl:element>
                        </xsl:element>
                    </xsl:if>
                </xsl:when>
                <xsl:when test="$condition">
                    <xsl:if test="$condition/lower_limit">
                        <xsl:element name="c:Limit">
                            <xsl:attribute name="comparator">GE</xsl:attribute>
                            <xsl:element name="c:Datum">
                                <xsl:attribute name="xsi:type">
                                    <xsl:value-of select="$condition/lower_limit/@type"/>
                                </xsl:attribute>
                                <xsl:attribute name="value">
                                    <xsl:value-of select="$condition/lower_limit/@value"/>
                                </xsl:attribute>
                            </xsl:element>
                        </xsl:element>
                    </xsl:if>
                    <xsl:if test="$condition/upper_limit">
                        <xsl:element name="c:Limit">
                            <xsl:attribute name="comparator">LE</xsl:attribute>
                            <xsl:element name="c:Datum">
                                <xsl:attribute name="xsi:type">
                                    <xsl:value-of select="$condition/upper_limit/@type"/>
                                </xsl:attribute>
                                <xsl:attribute name="value">
                                    <xsl:value-of select="$condition/upper_limit/@value"/>
                                </xsl:attribute>
                            </xsl:element>
                        </xsl:element>
                    </xsl:if>
                </xsl:when>
            </xsl:choose>
        </xsl:element>
    </xsl:template>

    <!-- ================================================ -->
    <!-- ================ Expected Limit ================ -->
    <!-- ================================================ -->
    <xsl:template name="limit-expected">
        <xsl:param name="comparator"/>
        <xsl:param name="unit"/>
        <xsl:param name="value"/>
        <xsl:param name="qualifier"/>
        <xsl:param name="dataType"/>
        <xsl:element name="c:Expected">
            <xsl:attribute name="comparator">
                <xsl:value-of select="$comparator"/>
            </xsl:attribute>
            <xsl:call-template name="datum">
                <xsl:with-param name="value" select="$value"/>
                <xsl:with-param name="type" select="$dataType"/>
                <xsl:with-param name="unit" select="$unit"/>
                <xsl:with-param name="qualifier" select="$qualifier"/>
                <xsl:with-param name="errorLimit" select="''"/>
                <xsl:with-param name="maximum" select="''"/>
                <xsl:with-param name="range" select="''"/>
                <xsl:with-param name="resolution" select="''"/>
            </xsl:call-template>
        </xsl:element>
    </xsl:template>

    <!-- ============================================== -->
    <!-- ================ Single Limit ================ -->
    <!-- ============================================== -->
    <xsl:template name="limit-single">
        <xsl:param name="comparator"/>
        <xsl:param name="unit"/>
        <xsl:param name="value"/>
        <xsl:param name="type"/>
        <xsl:param name="qualifier"/>
        <xsl:element name="c:SingleLimit">
            <xsl:attribute name="comparator">
                <xsl:value-of select="$comparator"/>
            </xsl:attribute>
            <xsl:call-template name="datum">
                <xsl:with-param name="value" select="$value"/>
                <xsl:with-param name="type" select="$type"/>
                <xsl:with-param name="unit" select="$unit"/>
                <xsl:with-param name="qualifier" select="$qualifier"/>
                <xsl:with-param name="errorLimit" select="''"/>
                <xsl:with-param name="maximum" select="''"/>
                <xsl:with-param name="range" select="''"/>
                <xsl:with-param name="resolution" select="''"/>
            </xsl:call-template>
        </xsl:element>
    </xsl:template>


    <!-- ============================================ -->
    <!-- ================ Limit Mask ================ -->
    <!-- ============================================ -->
    <xsl:template name="limit-mask">

    </xsl:template>


    <!-- ======================================= -->
    <!-- ================ Ports ================ -->
    <!-- ======================================= -->
    <xsl:template name="ports">
        <xsl:param name="ports"/>
        <xsl:element name="c:Ports">
            <!-- Need to lookup ports from the UUT here -->
            <xsl:for-each select="$ports">
                <xsl:element name="c:Port">
                    <xsl:attribute name="name">
                        <xsl:value-of select="@name"/>
                    </xsl:attribute>
                    <xsl:attribute name="direction">
                        <xsl:value-of select="@direction"/>
                    </xsl:attribute>
                    <xsl:attribute name="type">
                        <xsl:value-of select="@type"/>
                    </xsl:attribute>
                    <xsl:if test="c:ConnectorPins/c:ConnectorPin">
                        <xsl:element name="c:ConnectorPins">
                            <xsl:for-each select="c:ConnectorPins/c:ConnectorPin">
                                <xsl:element name="c:ConnectorPin">
                                    <xsl:attribute name="connectorID">
                                        <xsl:value-of select="@connectorID"/>
                                    </xsl:attribute>
                                    <xsl:attribute name="pinID">
                                        <xsl:value-of select="@pinID"/>
                                    </xsl:attribute>
                                </xsl:element>
                            </xsl:for-each>
                        </xsl:element>
                    </xsl:if>
                </xsl:element>
            </xsl:for-each>
        </xsl:element>
    </xsl:template>

    <!-- ============================================ -->
    <!-- ================ Connectors ================ -->
    <!-- ============================================ -->
    <xsl:template name="connectors">
        <xsl:param name="connectors"/>
        <xsl:element name="c:Connectors">
            <xsl:for-each select="$connectors">
                <xsl:call-template name="connector">
                    <xsl:with-param name="connector" select="."/>
                </xsl:call-template>
            </xsl:for-each>
        </xsl:element>
    </xsl:template>


    <!-- =========================================== -->
    <!-- ================ Connector ================ -->
    <!-- =========================================== -->
    <xsl:template name="connector">
        <xsl:param name="connector"/>
        <xsl:variable name="definition" select="$connector/c:Definition"/>
        <xsl:variable name="identification" select="$connector/c:Identification"/>
        <xsl:variable name="connectorPins" select="$connector/c:Pins"/>
        <xsl:element name="c:Connector">
            <xsl:attribute name="ID">
                <xsl:value-of select="$connector/@ID"/>
            </xsl:attribute>
            <xsl:attribute name="location">
                <xsl:value-of select="$connector/@location"/>
            </xsl:attribute>
            <xsl:attribute name="type">
                <xsl:value-of select="$connector/@type"/>
            </xsl:attribute>
            <xsl:if test="$connector/@version!=''">
                <xsl:attribute name="version">
                    <xsl:value-of select="$connector/@version"/>
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="$connector/@name!=''">
                <xsl:attribute name="name">
                    <xsl:value-of select="$connector/@name"/>
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="$connector/@matingConnectorType!=''">
                <xsl:attribute name="matingConnectorType">
                    <xsl:value-of select="$connector/@matingConnectorType"/>
                </xsl:attribute>
            </xsl:if>
            <xsl:if test="$definition!=''">
                <xsl:element name="c:Definition">
                    <xsl:value-of select="$definition"/>
                </xsl:element>
            </xsl:if>
            <xsl:if test="$identification!=''">
                <xsl:call-template name="identification">
                    <xsl:with-param name="identification" select="$identification"/>
                </xsl:call-template>
            </xsl:if>
            <!-- If Pin Count > 0 add pins -->
            <xsl:if test="$connectorPins/c:Pin">
                <xsl:call-template name="connector-pins">
                    <xsl:with-param name="connectorPin" select="$connectorPins"/>
                </xsl:call-template>
            </xsl:if>
        </xsl:element>
    </xsl:template>

    <!-- ================================================ -->
    <!-- ================ Connector Pins ================ -->
    <!-- ================================================ -->
    <xsl:template name="connector-pins">
        <xsl:param name="connectorPin"/>
        <xsl:element name="c:Pins">
            <xsl:for-each select="$connectorPin/c:Pin">
                <xsl:element name="c:Pin">
                    <xsl:attribute name="ID">
                        <xsl:value-of select="@ID"/>
                    </xsl:attribute>
                    <xsl:attribute name="name">
                        <xsl:value-of select="@name"/>
                    </xsl:attribute>
                </xsl:element>
            </xsl:for-each>
        </xsl:element>
    </xsl:template>

    <!-- ================================================ -->
    <!-- ================ Identification ================ -->
    <!-- ================================================ -->
    <xsl:template name="identification">
        <xsl:param name="identification"/>
        <xsl:element name="c:Identification">
            <xsl:element name="c:ModelName">
                <xsl:value-of select="$identification/c:ModelName/text()"/>
            </xsl:element>
        </xsl:element>

    </xsl:template>

    <!-- ================================================= -->
    <!-- ================ UUT Description ================ -->
    <!-- ================================================= -->
    <xsl:template name="uut-description">
        <xsl:param name="uutName"/>
        <xsl:param name="uutId"/>
        <xsl:element name="Description">
            <xsl:element name="c:DescriptionDocumentReference">
                <xsl:attribute name="ID">
                    <xsl:value-of select="$uutName"/>
                </xsl:attribute>
                <xsl:attribute name="uuid">
                    <xsl:value-of select="$uutId"/>
                </xsl:attribute>
            </xsl:element>
        </xsl:element>
    </xsl:template>

    <!-- =========================================================== -->
    <!-- ================ Detailed Test Information ================ -->
    <!-- =========================================================== -->
    <xsl:template name="detailed-information">
        <DetailedTestInformation>
            <xsl:call-template name="create-tsf-library-section"/>
            <xsl:call-template name="create-signal-requirements-section"/>
            <xsl:call-template name="test-group-entry-points"/>

            <xsl:call-template name="state-variables"/>
            <xsl:call-template name="test-groups"/>
            <xsl:call-template name="actions"/>
            <xsl:call-template name="global-signals"/>
        </DetailedTestInformation>
    </xsl:template>


    <xsl:template name="global-signals" >
        <GlobalSignals>
            <xsl:for-each select="//apply/signal_component/atlas/noun[@type='SHORT']" >
                <xsl:variable name="id" ><xsl:value-of  select="../../../@id" /></xsl:variable>
                <xsl:element name="GlobalSignal" >
                    <xsl:attribute name="name"><xsl:value-of  select="concat(./@type,$id)" /></xsl:attribute>
                    <xsl:element name="Source" >
                        <xsl:attribute name="ID">GS<xsl:value-of  select="$id" /></xsl:attribute>
                    </xsl:element>
                </xsl:element>
            </xsl:for-each>
        </GlobalSignals>
    </xsl:template>

    <xsl:template name="create-signal-requirements-section">
        <xsl:comment>==================================</xsl:comment>
        <xsl:comment>Create Signal Requirements Section</xsl:comment>
        <xsl:comment>==================================</xsl:comment>
        <SignalRequirements>
            <xsl:for-each select="/atlas/signal_oriented_statements/apply_statement/applies/apply">
                <xsl:call-template name="signal-requirement"/>
            </xsl:for-each>
        </SignalRequirements>
    </xsl:template>

    <xsl:template name="create-tsf-library-section">
        <xsl:comment>===================================</xsl:comment>
        <xsl:comment>Create TSF Library Reference Section</xsl:comment>
        <xsl:comment>===================================</xsl:comment>
        <TsfLibraries>
            <xsl:element name="TsfLibrary">
                <xsl:attribute name="name"><xsl:value-of select="$g_tsfName"/></xsl:attribute>
                <xsl:attribute name="ID">TSF1</xsl:attribute>
                <xsl:element name="XmlSchemaURL"><xsl:value-of select="$g_tsfNameSpace"/></xsl:element>
                <xsl:element name="XmlInstanceDocumentURL"><xsl:value-of select="$g_station-type"/>_atlas.xml
                </xsl:element>
            </xsl:element>
        </TsfLibraries>
    </xsl:template>


    <xsl:template name="test-group-entry-points">
        <EntryPoints>
            <xsl:variable name="primary" select="//procedure[@main_procedure='true']" />
            <xsl:element name="TestGroupEntryPoints" >
                <xsl:if test="$primary" >
                    <xsl:attribute name="primaryTestGroupEntryPointID" ><xsl:value-of select="concat('ep', $primary/@id )" /></xsl:attribute>
                    <xsl:element name="TestGroupEntryPoint" >
                        <xsl:attribute name="ID" ><xsl:value-of select="concat('ep', $primary/@id )" /></xsl:attribute>
                        <xsl:attribute name="testGroupID" ><xsl:value-of select="concat('tg', $primary/@id )" /></xsl:attribute>
                    </xsl:element>
                </xsl:if>
            </xsl:element>
        </EntryPoints>
    </xsl:template>


    <xsl:template name="state-variables">
        <StateVariables>
            <xsl:for-each select="/atlas/declares/declare[@variable='true']">
                <xsl:variable name="varId" select="@id"/>
                <xsl:variable name="varName" select="@name"/>
                <xsl:variable name="varType" select="@type"/>
                <xsl:variable name="hasCalculation" select="assignments_by_statement/assignment[@type='arthimetic']"/>
                <xsl:variable name="hasAssignment" select="assignments_by_statement/assignment[@type='assign']"/>
                <xsl:variable name="hasVariable" select="assignments_by_statement/assignment/assign/@variable_name"/>
                <xsl:if test="not($hasCalculation) and not($hasVariable) and $hasAssignment">
                    <xsl:element name="StateVariable">
                        <xsl:attribute name="ID">
                            <xsl:value-of select="$varId"/>
                        </xsl:attribute>
                        <xsl:attribute name="name">
                            <xsl:value-of select="$varName"/>
                        </xsl:attribute>
                        <xsl:element name="Values">
                            <!-- Sort the list -->
                            <xsl:variable name="sortedCopy">
                                <xsl:for-each select="assignments_by_statement/assignment/assign">
                                    <xsl:sort select="concat(@value,@variable_name)"/>
                                    <xsl:copy-of select="."/>
                                </xsl:for-each>
                            </xsl:variable>
                            <!-- Grab the Node Set -->
                            <xsl:variable name="refList" select="exslt:node-set($sortedCopy)"/>
                            <!-- Iterate through the list -->
                            <xsl:for-each select="$refList/assign">
                                <xsl:variable name="prior" select="preceding-sibling::assign[1]"/>
                                <xsl:variable name="priorValue" select="concat($prior//@value,$prior//@variable_name)"/>
                                <xsl:variable name="thisValue" select="concat(@value,@variable_name)"/>
                                <xsl:variable name="valValue" select="concat(@value,@variable_name)"/>
                                <xsl:if test="not($priorValue=$thisValue)">
                                    <xsl:variable name="valId" select="concat($varName, '_', $valValue)"/>
                                    <xsl:element name="Value">
                                        <xsl:attribute name="ID">
                                            <xsl:value-of select="$valId"/>
                                        </xsl:attribute>
                                        <xsl:call-template name="datum">
                                            <xsl:with-param name="value" select="$valValue"/>
                                            <xsl:with-param name="type" select="$varType"/>
                                            <xsl:with-param name="resolution" select="''"/>
                                            <xsl:with-param name="range" select="''"/>
                                            <xsl:with-param name="maximum" select="''"/>
                                            <xsl:with-param name="errorLimit" select="''"/>
                                            <xsl:with-param name="qualifier" select="''"/>
                                            <xsl:with-param name="unit" select="''"/>
                                        </xsl:call-template>
                                    </xsl:element>
                                </xsl:if>
                            </xsl:for-each>
                        </xsl:element>
                    </xsl:element>
                </xsl:if>
            </xsl:for-each>
        </StateVariables>
    </xsl:template>


    <!-- ====================== -->
    <!-- Create Actions Section -->
    <!-- ====================== -->
    <xsl:template name="actions">
        <Actions>
            <xsl:call-template name="setup-global-action"/>
            <xsl:call-template name="action"/>
        </Actions>
    </xsl:template>


    <!--
    It appears that action parameters are globally
    accessible and therefore one could be used as the
    global variable container.
    -->
    <xsl:template name="setup-global-action">
        <xsl:variable name="mainProcId" select="$g_mainProcedure/@id"/>
        <xsl:element name="Action">
            <xsl:attribute name="xsi:type">Test</xsl:attribute>
            <xsl:attribute name="ID">ACT0001</xsl:attribute>
            <xsl:attribute name="name">GLOBAL-SETUP</xsl:attribute>

            <parameters>
                <xsl:for-each select="/atlas/declares/declare[@scope='global' and @variable='true']">
                    <xsl:variable name="false" select="1=2"/>
                    <xsl:variable name="varId" select="@id"/>
                    <xsl:variable name="varName" select="@name"/>
                    <xsl:variable name="varType" select="@type" />
                    <xsl:variable name="hasCalculation"
                                  select="assignments_by_statement/assignment[@type='arthimetic']"/>
                    <xsl:variable name="hasAssignment" select="assignments_by_statement/assignment[@type='assign']"/>
                    <xsl:variable name="hasVariable"
                                  select="assignments_by_statement/assignment/assign/@variable_name"/>
                    <xsl:element name="parameter">
                        <!-- We will use the variable name for the id because in the original
                        Atlas thats how global variables were referenced. They should be unique
                        across the application. -->
                        <xsl:attribute name="ID">ACT<xsl:value-of select="@name"/>
                        </xsl:attribute>
                        <xsl:attribute name="name">
                            <xsl:value-of select="@name"/>
                        </xsl:attribute>
                        <xsl:element name="Value">
                            <xsl:call-template name="datum">
                                <xsl:with-param name="unit" select="''"/>
                                <xsl:with-param name="qualifier" select="''"/>
                                <xsl:with-param name="errorLimit" select="''"/>
                                <xsl:with-param name="maximum" select="''"/>
                                <xsl:with-param name="range" select="''"/>
                                <xsl:with-param name="resolution" select="''"/>
                                <xsl:with-param name="value">
                                    <xsl:choose>
                                        <xsl:when test="$varType='boolean' ">
                                            <xsl:value-of select="$false"/>
                                        </xsl:when>
                                        <xsl:when test="$varType='string' ">
                                            <xsl:value-of select="''"/>
                                        </xsl:when>
                                        <xsl:when test="$varType='char' ">
                                            <xsl:value-of select="''"/>
                                        </xsl:when>
                                        <xsl:otherwise>
                                            <xsl:value-of select="0"/>
                                        </xsl:otherwise>
                                    </xsl:choose>
                                </xsl:with-param>
                                <xsl:with-param name="type" select="$varType"/>
                            </xsl:call-template>
                        </xsl:element>
                        <xsl:element name="ValueToParameter">
                            <xsl:attribute name="testGroupParameterID">TGP<xsl:value-of select="@name"/>
                            </xsl:attribute>
                        </xsl:element>
                    </xsl:element>
                </xsl:for-each>
            </parameters>
            <Behavior>
                <xsl:element name="TestGroupCall">
                    <xsl:attribute name="testGroupID">
                        <xsl:value-of select="$mainProcId"/>
                    </xsl:attribute>
                </xsl:element>
            </Behavior>
        </xsl:element>
    </xsl:template>

    <!-- ===================== -->
    <!-- Create Action Section -->
    <!-- ===================== -->
    <xsl:template name="action">

        <!--xsl:for-each select="atlas/procedures/procedure/test_numbers/test[@begin_test='true']"-->
        <xsl:for-each select="atlas/procedures/procedure/test_numbers/test">
            <xsl:if test="../test/@begin_test" >
                <xsl:variable name="testNo" select="@number" />
                <xsl:variable name="testId" select="concat( 'TST', @number )" />
                <!-- Try to determine test comments here -->
                <xsl:for-each select="//*/statement[@test_number=$testNo and @comment_refid]" >
                    <xsl:variable name="commentRefId" select="@comment_refid" />
                    <xsl:for-each select="//comment[@id=$commentRefId]/line" >
                        <xsl:comment><xsl:value-of select="." /></xsl:comment>
                    </xsl:for-each>
                </xsl:for-each>
                <xsl:element name="Action">
                    <xsl:attribute name="xsi:type">Test</xsl:attribute>
                    <xsl:attribute name="ID"><xsl:value-of select="$testId" /></xsl:attribute>
                    <xsl:attribute name="name"><xsl:value-of select="$testId"/></xsl:attribute>
                    <xsl:variable name="root" select="/" />
                    <!--xsl:variable name="signals" select="atml:GetLocalSignals($root, $testNo)" /-->
                    <xsl:variable name="signalStatements" select="./signal_oriented_statements" />


                    <xsl:for-each select="variables/variable" >
                        <xsl:element name="parameter">
                            <xsl:attribute name="ID">
                                <xsl:value-of select="concat($testId, '_', @refid )"/>
                            </xsl:attribute>
                            <xsl:attribute name="name">
                                <xsl:value-of select="@variable_name" />
                            </xsl:attribute>
                        </xsl:element>
                    </xsl:for-each>

                    <xsl:element name="Behavior">
                        <xsl:element name="Operations">
                            <xsl:for-each select="//*/statement[@test_number=$testNo]" >
                                <xsl:apply-templates select=".">
                                    <xsl:with-param name="actionId" select="$testId" />
                                    <xsl:with-param name="signalStatements" select="$signalStatements" />
                                </xsl:apply-templates>
                            </xsl:for-each>
                        </xsl:element>
                    </xsl:element>

                    <!-- Local Signals -->
                    <LocalSignals>
                        <xsl:for-each select="$signalStatements/statement" >
                            <xsl:variable name="resource" select="./@resource" />
                            <xsl:variable name="type" select="./@type" />
                            <xsl:variable name="id" select="./@id" />
                            <xsl:element name="LocalSignal" >
                                <xsl:attribute name="name" ><xsl:value-of select="$type" /></xsl:attribute>
                                <xsl:choose>
                                    <xsl:when test="$resource='SOURCE'">
                                        <xsl:element name="source" >
                                            <xsl:attribute name="ID" ><xsl:value-of select="$id" /></xsl:attribute>
                                        </xsl:element>
                                    </xsl:when>
                                    <xsl:when test="$resource='SENSOR'">
                                        <xsl:element name="sensor" >
                                            <xsl:attribute name="ID" ><xsl:value-of select="$id" /></xsl:attribute>
                                        </xsl:element>
                                    </xsl:when>
                                    <xsl:when test="$resource='MONITOR'">
                                        <xsl:element name="monitor" >
                                            <xsl:attribute name="ID" ><xsl:value-of select="$id" /></xsl:attribute>
                                        </xsl:element>
                                    </xsl:when>
                                </xsl:choose>
                            </xsl:element>
                        </xsl:for-each>
                    </LocalSignals>

                    <!-- Outcomes -->
                    <Outcomes>

                    </Outcomes>

                    <!-- Test Results -->
                    <TestResults>

                    </TestResults>
                </xsl:element>

            </xsl:if>
        </xsl:for-each>


        <xsl:for-each select="atlas/procedures/procedure">
            <xsl:call-template name="source_comment">
                <xsl:with-param name="sourceFile" select="atlas_source/@file"/>
                <xsl:with-param name="statementNo" select="atlas_source/@statement_number"/>
                <xsl:with-param name="lineNo" select="atlas_source/@line_number"/>
            </xsl:call-template>
            <xsl:element name="Action">
                <xsl:variable name="actionId" select="concat( 'ACT', @id )" />
                <xsl:attribute name="xsi:type">Test</xsl:attribute>
                <xsl:attribute name="ID"><xsl:value-of select="$actionId" /></xsl:attribute>
                <xsl:attribute name="name">
                    <xsl:value-of select="@name"/>
                </xsl:attribute>
                <xsl:if test="parameters/parameter">
                    <parameters>
                        <xsl:for-each select="parameters/parameter">
                            <xsl:element name="parameter">
                                <xsl:attribute name="ID">
                                    <xsl:value-of select="concat($actionId, '_', @name )"/>
                                </xsl:attribute>
                                <xsl:attribute name="name">
                                    <xsl:value-of select="@name" />
                                </xsl:attribute>
                            </xsl:element>
                        </xsl:for-each>
                    </parameters>
                </xsl:if>
                <!-- ======================= -->
                <!-- Create Behavior Section -->
                <!-- ======================= -->
                <xsl:element name="Behavior">
                    <xsl:choose>
                        <xsl:when test="statements/statement">
                            <xsl:element name="Operations">
                                <xsl:for-each select="statements/statement">
                                    <xsl:apply-templates select=".">
                                        <xsl:with-param name="actionId" select="$actionId" />
                                    </xsl:apply-templates>
                                </xsl:for-each>
                            </xsl:element>
                        </xsl:when>
                        <xsl:otherwise>
                            <Description>DoSomething....</Description>
                        </xsl:otherwise>
                    </xsl:choose>
                </xsl:element>
            </xsl:element>
        </xsl:for-each>
        <!--Action>
            <Outcomes>

            </Outcomes>
            <TestResults>

            </TestResults>
        </Action-->
    </xsl:template>

    <!-- ================== -->
    <!-- Process Statements -->
    <!-- ================== -->
    <xsl:template match="statements">
        <xsl:param name="actionId" />
        <xsl:for-each select="statement">
            <xsl:choose>
                <xsl:when test="./@refid">
                    <xsl:variable name="refId" select="./@refid" />
                    <xsl:apply-templates select="//*[@id=$refId]">
                        <xsl:with-param name="actionId" select="$actionId"/>
                    </xsl:apply-templates>
                </xsl:when>
                <xsl:otherwise>
                    <xsl:apply-templates select=".">
                        <xsl:with-param name="actionId" select="$actionId"/>
                    </xsl:apply-templates>
                </xsl:otherwise>
            </xsl:choose>
        </xsl:for-each>
    </xsl:template>

    <!-- ================= -->
    <!-- Process Statement -->
    <!-- ================= -->
    <xsl:template match="statement">
        <xsl:param name="actionId" />
        <xsl:param name="signalStatements" />
        <xsl:variable name="statementType" select="@type"/>
        <xsl:variable name="procRefId" select="@proc_refid"/>
        <xsl:variable name="elseId" select="@else_refid"/>
        <xsl:variable name="refId" select="@refid"/>
        <xsl:variable name="id" select="@id"/>

        <!--xsl:call-template name="source_comment">
            <xsl:with-param name="sourceFile" select="atlas_source/@file"/>
            <xsl:with-param name="statementNo" select="atlas_source/@statement_number"/>
            <xsl:with-param name="lineNo" select="atlas_source/@line_number"/>
        </xsl:call-template-->

        <xsl:choose>
            <xsl:when test="$statementType='PERFORM'">
                <!-- This needs to either perform a call or flatten the call to include operations -->
                <xsl:call-template name="perform-operation"/>
                <!--xsl:element name="Operation">
                    <xsl:attribute name="xsi:type" >OperationOther</xsl:attribute>
                    <DetailedInformation><xsl:text>Perform Call</xsl:text></DetailedInformation>
                </xsl:element-->

            </xsl:when>

            <xsl:when test="$statementType='REMOVE'">
                <xsl:call-template name="remove_statement">
                    <xsl:with-param name="refId" select="$refId" />
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$statementType='IF THEN'">
                <xsl:call-template name="if_then_statement">
                    <xsl:with-param name="elseId" select="$elseId"/>
                    <xsl:with-param name="actionId" select="$actionId"/>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$statementType='FOR THEN'">
                <xsl:call-template name="for_then_statement" >
                    <xsl:with-param name="actionId" select="$actionId" />
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$statementType='WHILE THEN'">
                <xsl:call-template name="while_then_statement">
                    <xsl:with-param name="actionId" select="$actionId" />
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$statementType='CALCULATE'">
                <xsl:call-template name="calculate_statement">
                    <xsl:with-param name="refId" select="$refId"/>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$statementType='INPUT'">
                <xsl:call-template name="input_statement">
                    <xsl:with-param name="refId" select="$refId"/>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$statementType='OUTPUT'">
                <xsl:call-template name="output_statement">
                    <xsl:with-param name="refId" select="$refId"/>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$statementType='COMPARE'">
                <xsl:call-template name="compare_statement">
                    <xsl:with-param name="refId" select="$refId"/>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$statementType='ENABLE'">
                <xsl:call-template name="enable_statement">
                    <xsl:with-param name="refId" select="$refId"/>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$statementType='DISABLE'">
                <xsl:call-template name="disable_statement">
                    <xsl:with-param name="refId" select="$refId"/>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$statementType='DELAY'">
                <xsl:call-template name="delay_statement">
                    <xsl:with-param name="refId" select="$refId"/>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$statementType='FILL'">
                <xsl:call-template name="fill_statement">
                    <xsl:with-param name="refId" select="$refId"/>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$statementType='READ DATETIME'">
                <xsl:call-template name="read_datetime_statement">
                    <xsl:with-param name="refId" select="$refId"/>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$statementType='APPLY'">
                <xsl:call-template name="apply_statement">
                    <xsl:with-param name="refId" select="$refId"/>
                    <xsl:with-param name="signalStatements" select="$signalStatements"/>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$statementType='MEASURE'">
                <xsl:call-template name="measure_statement">
                    <xsl:with-param name="refId" select="$refId"/>
                    <xsl:with-param name="signalStatements" select="$signalStatements"/>
                </xsl:call-template>
            </xsl:when>
            <xsl:when test="$statementType='VERIFY'">
                <xsl:call-template name="verify_statement">
                    <xsl:with-param name="refId" select="$refId"/>
                </xsl:call-template>
            </xsl:when>
        </xsl:choose>
    </xsl:template>

    <!-- ========================= -->
    <!-- Process a Apply Statement -->
    <!-- ========================= -->
    <xsl:template name="apply_statement">
        <xsl:param name="refId"/>
        <xsl:param name="signalStatements"/>
        <xsl:if test="$signalStatements" >
            <xsl:variable name="apply" select="//apply[@id=$refId]"/>
            <xsl:variable name="resource" select="$apply/signal_component/atlas/noun/@resource"  />
            <xsl:variable name="signalName" select="$apply/signal_component/atlas/noun/@type"  />
            <xsl:variable name="signal" select="$signalStatements/*[@type=$signalName]" />
            <xsl:comment>Apply <xsl:value-of select="concat( $signalName, ' - ', $refId )" /></xsl:comment>
            <xsl:variable name="statement" select="//*[@id=$refId]" />
            <xsl:call-template name="source_comment">
                <xsl:with-param name="sourceFile" select="$statement/atlas_source/@file"/>
                <xsl:with-param name="statementNo" select="$statement/atlas_source/@statement_number"/>
                <xsl:with-param name="lineNo" select="$statement/atlas_source/@line_number"/>
            </xsl:call-template>

            <xsl:comment>*****************************************************************************</xsl:comment>
            <xsl:comment>*************************** BEGIN APPLY STATEMENT ***************************</xsl:comment>
            <xsl:comment>*****************************************************************************</xsl:comment>
            <!-- ============================================ -->
            <!-- Question - would a SHORT be a Global Signal? -->
            <!-- ============================================ -->
            <xsl:call-template name="setup-statement" >
                <xsl:with-param name="signal" select="$signal" />
                <xsl:with-param name="statement" select="$apply" />
                <xsl:with-param name="resource" select="$resource" />
            </xsl:call-template>

            <xsl:call-template name="connect-statement" >
                <xsl:with-param name="signal" select="$signal" />
                <xsl:with-param name="statement" select="$apply" />
                <xsl:with-param name="resource" select="$resource" />
            </xsl:call-template>

            <xsl:comment>***************************************************************************</xsl:comment>
            <xsl:comment>*************************** END APPLY STATEMENT ***************************</xsl:comment>
            <xsl:comment>***************************************************************************</xsl:comment>

        </xsl:if>
    </xsl:template>


    <xsl:template name="measure-statement">
        <xsl:param name="signal" />
        <xsl:param name="statement" />
        <xsl:param name="resource" />

        <xsl:call-template name="setup-statement" >
            <xsl:with-param name="signal" select="$signal" />
            <xsl:with-param name="statement" select="$statement" />
            <xsl:with-param name="resource" select="$resource" />
        </xsl:call-template>

        <xsl:call-template name="connect-statement" >
            <xsl:with-param name="signal" select="$signal" />
            <xsl:with-param name="statement" select="$statement" />
            <xsl:with-param name="resource" select="$resource" />
        </xsl:call-template>

        <xsl:call-template name="read-statement" >
            <xsl:with-param name="signal" select="$signal" />
            <xsl:with-param name="statement" select="$statement" />
            <xsl:with-param name="resource" select="$resource" />
        </xsl:call-template>

        <xsl:call-template name="read-disconnect" >
            <xsl:with-param name="signal" select="$signal" />
            <xsl:with-param name="statement" select="$statement" />
            <xsl:with-param name="resource" select="$resource" />
        </xsl:call-template>

    </xsl:template>


    <xsl:template name="setup-statement">
        <xsl:param name="signal" />
        <xsl:param name="statement" />
        <xsl:param name="resource" />
        <!-- xsl:comment>
            setup-statement
            Id: <xsl:value-of select="$statement/@id" />,
            Noun Type: <xsl:value-of select="$statement/signal_component/atlas/noun/@type" />,
            Resource: <xsl:value-of select="$resource" />
        </xsl:comment -->

        <xsl:element name="Operation">
            <xsl:attribute name="xsi:type">OperationSetup</xsl:attribute>
            <xsl:attribute name="utrs:resource"><xsl:value-of select="$resource" /></xsl:attribute>
            <xsl:attribute name="utrs:stype"><xsl:value-of select="$signal/@type" /></xsl:attribute>
            <xsl:attribute name="utrs:sid"><xsl:value-of select="$signal/@id" /></xsl:attribute>
            <xsl:choose>
                <xsl:when test="$resource='SOURCE'" >
                    <xsl:call-template name="operation-setup-source" >
                        <xsl:with-param name="signal" select="$signal" />
                        <xsl:with-param name="statement" select="$statement" />
                    </xsl:call-template>
                </xsl:when>
                <xsl:when test="$resource='SENSOR'" >
                    <xsl:call-template name="operation-setup-sensor" >
                        <xsl:with-param name="signal" select="$signal" />
                        <xsl:with-param name="statement" select="$statement" />
                    </xsl:call-template>
                </xsl:when>
                <xsl:when test="$resource='MONITOR'" >
                    <xsl:call-template name="operation-setup-monitor" >
                        <xsl:with-param name="signal" select="$signal" />
                        <xsl:with-param name="statement" select="$statement" />
                    </xsl:call-template>
                </xsl:when>
                <xsl:otherwise>
                    <xsl:if test="$statement/signal_component/atlas/noun/@type='SHORT'" >
                        <xsl:call-template name="operation-setup-source" >
                            <xsl:with-param name="signal" select="$signal" />
                            <xsl:with-param name="statement" select="$statement" />
                        </xsl:call-template>
                    </xsl:if>
                </xsl:otherwise>
            </xsl:choose>
        </xsl:element>
    </xsl:template>

    <xsl:template name="connect-statement">
        <xsl:param name="signal" />
        <xsl:param name="statement" />
        <xsl:param name="resource" />
        <xsl:element name="Operation" >
            <xsl:attribute name="xsi:type" >OperationConnect</xsl:attribute>
            <xsl:element name="Signal" >
                <xsl:choose>
                    <xsl:when test="$statement/signal_component/atlas/noun/@type='SHORT'" >
                        <xsl:element name="GlobalSignalReference">
                            <xsl:attribute name="globalSignalID" >GS<xsl:value-of select="$statement/@id" /></xsl:attribute>
                        </xsl:element>
                    </xsl:when>
                    <xsl:otherwise>
                    </xsl:otherwise>
                </xsl:choose>
                <xsl:element name="std:Signal" >

                </xsl:element>
            </xsl:element>
        </xsl:element>

    </xsl:template>

    <xsl:template name="read-statement">
        <xsl:param name="signal" />
        <xsl:param name="statement" />
        <xsl:param name="resource" />

    </xsl:template>

    <xsl:template name="read-disconnect">
        <xsl:param name="signal" />
        <xsl:param name="statement" />
        <xsl:param name="resource" />

    </xsl:template>

    <xsl:template name="operation-setup-source" >
        <xsl:param name="signal" />
        <xsl:param name="statement" />
        <xsl:variable name="id" ><xsl:value-of select="$statement/@id" /></xsl:variable>
        <xsl:variable name="type" ><xsl:value-of select="$statement/signal_component/atlas/noun/@type" /></xsl:variable>
        <xsl:comment>operation-setup-source <xsl:value-of select="@id" /> <xsl:value-of select="@type" /></xsl:comment>
        <Source>
            <xsl:choose>
                <xsl:when test="$type='SHORT'">
                    <xsl:element name="GlobalSignalReference">
                        <xsl:attribute name="globalSignalID" >GS<xsl:value-of select="$id" /></xsl:attribute>
                    </xsl:element>
                </xsl:when>
                <xsl:otherwise>
                    <xsl:element name="LocalSourceSignalReference">
                        <xsl:attribute name="localSourceSignalID" ><xsl:value-of select="$signal/@id" /></xsl:attribute>
                    </xsl:element>
                </xsl:otherwise>
            </xsl:choose>
        </Source>
    </xsl:template>

    <xsl:template name="operation-setup-sensor" >
        <xsl:param name="signal" />
        <xsl:param name="statement" />
        <xsl:variable name="noun" select="$statement/signal_component/atlas/noun" />
        <xsl:variable name="nounModifiers" select="$statement/*/noun_modifiers" />
        <xsl:variable name="namespace" select="'CASS_ATLAS'" />
        <Sensor>
            <xsl:element name="LocalSourceSignalReference">
                <xsl:attribute name="localSourceSignalID" ><xsl:value-of select="$signal/@id" /></xsl:attribute>
            </xsl:element>
            <xsl:element name="std:Signal" >
                <xsl:attribute name="out" ><xsl:value-of select="concat($signal/@name, $signal/@id)"/> </xsl:attribute>
                <!-- Lookup Noun to get Mapped Signal - will need the TSF Namespace, Name, and attributes -->
                <xsl:if test="$noun" >
                    <xsl:comment>noun: <xsl:value-of select="$noun" /></xsl:comment>
                    <xsl:comment>type: <xsl:value-of select="$noun/@type" /></xsl:comment>
                    <!--xsl:element name="{$noun/@type}" namespace="{$namespace}" >
                        <xsl:for-each select="$nounModifiers/noun_modifier" >
                           <xsl:attribute name="mapped_attribute_name" ><xsl:value-of select="/get-value-of-mapped-attribute" /> </xsl:attribute>
                        </xsl:for-each>
                    </xsl:element-->
                </xsl:if>
            </xsl:element>
        </Sensor>
    </xsl:template>

    <xsl:template name="operation-setup-monitor" >
        <xsl:param name="signal" />
        <xsl:param name="statement" />
        <Monitor>
            <xsl:element name="LocalSourceSignalReference">
                <xsl:attribute name="localSourceSignalID" ><xsl:value-of select="$signal/@id" /></xsl:attribute>
            </xsl:element>
        </Monitor>
    </xsl:template>

    <!-- ========================== -->
    <!-- Process a Verify Statement -->
    <!-- ========================== -->
    <xsl:template name="verify_statement">
        <xsl:param name="refId"/>
        <xsl:variable name="verifyStatement" select="//*[@id=$refId]"/>
        <xsl:comment>Verify</xsl:comment>
        <xsl:variable name="statement" select="//*[@id=$refId]" />
        <xsl:call-template name="source_comment">
            <xsl:with-param name="sourceFile" select="$statement/atlas_source/@file"/>
            <xsl:with-param name="statementNo" select="$statement/atlas_source/@statement_number"/>
            <xsl:with-param name="lineNo" select="$statement/atlas_source/@line_number"/>
        </xsl:call-template>
        <xsl:element name="Operation">
            <xsl:attribute name="xsi:type">OperationOther</xsl:attribute>
            <DetailedInformation>
                <xsl:text>Perform Verify Operation Here</xsl:text>
            </DetailedInformation>
        </xsl:element>
    </xsl:template>

    <!-- =========================== -->
    <!-- Process a Measure Statement -->
    <!-- =========================== -->
    <xsl:template name="measure_statement">
        <xsl:param name="refId"/>
        <xsl:param name="signalStatements"/>
        <xsl:comment>Measure</xsl:comment>
        <xsl:variable name="statement" select="//*[@id=$refId]" />
        <xsl:variable name="resource" select="$statement/signal_component/atlas/noun/@resource"  />
        <xsl:variable name="signalName" select="$statement/signal_component/atlas/noun/@type"  />
        <xsl:variable name="signal" select="$signalStatements/*[@refid=$refId]" />

        <xsl:call-template name="source_comment">
            <xsl:with-param name="sourceFile" select="$statement/atlas_source/@file"/>
            <xsl:with-param name="statementNo" select="$statement/atlas_source/@statement_number"/>
            <xsl:with-param name="lineNo" select="$statement/atlas_source/@line_number"/>
        </xsl:call-template>

        <xsl:call-template name="setup-statement" >
            <xsl:with-param name="signal" select="$signal" />
            <xsl:with-param name="statement" select="$statement" />
            <xsl:with-param name="resource" select="$resource" />
        </xsl:call-template>

        <xsl:call-template name="connect-statement" >
            <xsl:with-param name="signal" select="$signal" />
            <xsl:with-param name="statement" select="$statement" />
            <xsl:with-param name="resource" select="$resource" />
        </xsl:call-template>

        <xsl:call-template name="read-statement" >
            <xsl:with-param name="signal" select="$signal" />
            <xsl:with-param name="statement" select="$statement" />
            <xsl:with-param name="resource" select="$resource" />
        </xsl:call-template>

        <xsl:call-template name="read-disconnect" >
            <xsl:with-param name="signal" select="$signal" />
            <xsl:with-param name="statement" select="$statement" />
            <xsl:with-param name="resource" select="$resource" />
        </xsl:call-template>


    </xsl:template>

    <!-- ========================== -->
    <!-- Process a Remove Statement -->
    <!-- ========================== -->
    <xsl:template name="remove_statement">
        <xsl:param name="refId"/>
        <xsl:comment>Remove</xsl:comment>
        <xsl:call-template name="source_comment">
            <xsl:with-param name="sourceFile" select="atlas_source/@file"/>
            <xsl:with-param name="statementNo" select="atlas_source/@statement_number"/>
            <xsl:with-param name="lineNo" select="atlas_source/@line_number"/>
        </xsl:call-template>
        <xsl:element name="Operation">
            <xsl:attribute name="xsi:type">OperationOther</xsl:attribute>
            <DetailedInformation>
                <xsl:text>Perform Remove Operation Here</xsl:text>
            </DetailedInformation>
        </xsl:element>
    </xsl:template>

    <!-- ============================================================== -->
    <!-- Process a For Then Statement - Current Tag Should Be Statement -->
    <!-- ============================================================== -->
    <xsl:template name="for_then_statement">
        <xsl:param name="actionId" />
        <xsl:call-template name="source_comment" >
            <xsl:with-param name="lineNo" select="atlas_source/@line_number" />
            <xsl:with-param name="statementNo" select="atlas_source/@statement_number" />
            <xsl:with-param name="sourceFile" select="atlas_source/@file" />
        </xsl:call-template>
        <xsl:element name="Operation">
            <xsl:attribute name="xsi:type">OperationRepeat</xsl:attribute>
            <xsl:attribute name="ID"><xsl:value-of select="concat('oprep',@id)"/> </xsl:attribute>
            <Setup></Setup>
            <Body>
                <xsl:apply-templates select="statements">
                    <xsl:with-param name="actionId" select="$actionId" />
                </xsl:apply-templates>
            </Body>
            <Decision>
                <xsl:element name="Iterator" >
                    <xsl:attribute name="ID" ><xsl:value-of select="concat('it', @id)"/></xsl:attribute>
                    <xsl:call-template name="IncrementedValues">
                        <xsl:with-param name="condition" select="condition" />
                        <xsl:with-param name="actionId" select="$actionId" />
                    </xsl:call-template>
                </xsl:element>

            </Decision>

        </xsl:element>
    </xsl:template>

    <!-- ============================================================ -->
    <!-- Process Incremented Values - Current Tag Should Be Statement -->
    <!-- ============================================================ -->
    <xsl:template name="IncrementedValues" >
        <xsl:param name="condition" />
        <xsl:param name="actionId" />
        <xsl:variable name="iterator" select="$condition/iterator" />
        <xsl:variable name="initialize" select="$condition/initialize" />
        <xsl:variable name="thru" select="$condition/thru" />
        <IncrementValues>
            <xsl:element name="Value" >
                <xsl:attribute name="xsi:type" >IncrementedValue</xsl:attribute>
                <InitialValue>
                    <xsl:call-template name="datum">
                        <xsl:with-param name="type"><xsl:value-of select="$initialize/@type"/> </xsl:with-param>
                        <xsl:with-param name="value"><xsl:value-of select="$initialize/@value"/></xsl:with-param>
                        <xsl:with-param name="unit"/>
                        <xsl:with-param name="errorLimit"/>
                        <xsl:with-param name="maximum"/>
                        <xsl:with-param name="qualifier"/>
                        <xsl:with-param name="range"/>
                        <xsl:with-param name="resolution"/>
                    </xsl:call-template>
                </InitialValue>
                <Increment>
                    <Linear>
                        <xsl:call-template name="datum">
                            <xsl:with-param name="type"><xsl:value-of select="$iterator/@type"/> </xsl:with-param>
                            <xsl:with-param name="value">
                                <xsl:choose>
                                    <xsl:when test="$iterator/@by"><xsl:value-of select="$iterator/@value"/></xsl:when>
                                    <xsl:otherwise>1</xsl:otherwise>
                                </xsl:choose>
                            </xsl:with-param>
                            <xsl:with-param name="unit"/>
                            <xsl:with-param name="errorLimit"/>
                            <xsl:with-param name="maximum"/>
                            <xsl:with-param name="qualifier"/>
                            <xsl:with-param name="range"/>
                            <xsl:with-param name="resolution"/>
                        </xsl:call-template>
                    </Linear>
                </Increment>
            </xsl:element>
            <Limits>
                <Limit>
                    <c:SingleLimit comparator="LE">
                        <xsl:element name="c:Datum" >
                            <xsl:attribute name="xsi:type" >
                                <xsl:choose>
                                    <xsl:when test="$thru/@variable_name">ValueFromActionParameter</xsl:when>
                                    <xsl:when test="$thru/@value"><xsl:value-of select="$thru/@type" /></xsl:when>
                                </xsl:choose>
                            </xsl:attribute>
                            <xsl:attribute name="parameterId" >
                                <xsl:choose>
                                    <xsl:when test="$thru/@variable_name"><xsl:value-of select="concat($actionId, '_', $thru/@variable_name)" /></xsl:when>
                                    <xsl:when test="$thru/@value"><xsl:value-of select="$thru/@value" /></xsl:when>
                                </xsl:choose>
                            </xsl:attribute>
                        </xsl:element>
                    </c:SingleLimit>
                </Limit>
            </Limits>
        </IncrementValues>
    </xsl:template>

    <!-- ============================== -->
    <!-- Process a While Then Statement -->
    <!-- ============================== -->
    <xsl:template name="while_then_statement">
        <xsl:param name="actionId" />
        <xsl:comment>While Then</xsl:comment>
        <xsl:call-template name="source_comment">
            <xsl:with-param name="sourceFile" select="atlas_source/@file"/>
            <xsl:with-param name="statementNo" select="atlas_source/@statement_number"/>
            <xsl:with-param name="lineNo" select="atlas_source/@line_number"/>
        </xsl:call-template>
        <xsl:element name="Operation">
            <xsl:attribute name="xsi:type">OperationRepeat</xsl:attribute>
            <Body>
                <xsl:apply-templates select="statements">
                    <xsl:with-param name="actionId" select="$actionId" />
                </xsl:apply-templates>
            </Body>
            <Decision>
                <xsl:element name="Iterator" >
                    <xsl:attribute name="ID" ><xsl:value-of select="concat('it', @id)"/></xsl:attribute>
                    <xsl:call-template name="IncrementedValues">
                        <xsl:with-param name="condition" select="condition" />
                        <xsl:with-param name="actionId" select="$actionId" />
                    </xsl:call-template>
                </xsl:element>

            </Decision>
        </xsl:element>
    </xsl:template>

    <!-- =========================== -->
    <!-- Process a If Then Statement -->
    <!-- =========================== -->
    <xsl:template name="if_then_statement">
        <xsl:param name="elseId"/>
        <xsl:param name="actionId"/>
        <xsl:comment>Perform -If Then- OperationConditional Here - Statement Id: <xsl:value-of select="@id" />, Else Id: <xsl:value-of select="@else_refid" /> /></xsl:comment>
        <xsl:variable name="condition" select="condition"/>
        <xsl:variable name="statements" select="statements"/>
        <xsl:if test="$condition">
            <xsl:variable name="conditionType" select="$condition/@type"/>
            <xsl:call-template name="source_comment">
                <xsl:with-param name="sourceFile" select="./atlas_source/@file"/>
                <xsl:with-param name="statementNo" select="./atlas_source/@statement_number"/>
                <xsl:with-param name="lineNo" select="./atlas_source/@line_number"/>
            </xsl:call-template>
            <xsl:element name="Operation">
                <xsl:attribute name="xsi:type">OperationConditional</xsl:attribute>
                <xsl:choose>
                    <xsl:when test="$conditionType='boolean'">
                        <xsl:call-template name="condition-boolean" >
                            <xsl:with-param name="condition" select="$condition" />
                            <xsl:with-param name="actionId" select="$actionId" />
                        </xsl:call-template>
                    </xsl:when>
                    <xsl:when test="$conditionType='limits'">
                        <xsl:call-template name="condition-sequence" >
                            <xsl:with-param name="condition" select="$condition" />
                            <xsl:with-param name="actionId" select="$actionId" />
                        </xsl:call-template>
                    </xsl:when>
                    <xsl:when test="$conditionType='sequence'">
                        <xsl:call-template name="condition-sequence" >
                            <xsl:with-param name="condition" select="$condition" />
                            <xsl:with-param name="actionId" select="$actionId" />
                        </xsl:call-template>
                    </xsl:when>
                    <xsl:when test="$conditionType='compare'">
                        <xsl:call-template name="condition-compare" >
                            <xsl:with-param name="condition" select="$condition" />
                            <xsl:with-param name="actionId" select="$actionId" />
                        </xsl:call-template>
                    </xsl:when>
                </xsl:choose>
                <xsl:if test="$statements">
                    <xsl:element name="OnTrue">
                        <xsl:apply-templates select="./statements">
                            <xsl:with-param name="actionId" select="$actionId" />
                        </xsl:apply-templates>
                    </xsl:element>
                </xsl:if>
                <xsl:if test="$elseId">
                    <xsl:comment>else - <xsl:value-of select="$elseId" /></xsl:comment>
                    <xsl:variable name="else" select="//statement[@id=$elseId]" />
                    <xsl:if test="$else" >
                        <xsl:call-template name="source_comment">
                            <xsl:with-param name="sourceFile" select="$else/atlas_source/@file"/>
                            <xsl:with-param name="statementNo" select="$else/atlas_source/@statement_number"/>
                            <xsl:with-param name="lineNo" select="$else/atlas_source/@line_number"/>
                        </xsl:call-template>
                        <xsl:element name="OnFalse">
                            <xsl:for-each select="$else/statements/statement" >
                                <xsl:apply-templates select="." >
                                    <xsl:with-param name="actionId" select="$actionId" />
                                </xsl:apply-templates>
                            </xsl:for-each>
                        </xsl:element>
                    </xsl:if>
                </xsl:if>
            </xsl:element>
        </xsl:if>
    </xsl:template>

    <xsl:template name="condition-boolean" >
        <xsl:param name="condition" />
        <xsl:param name="actionId"/>
        <xsl:variable name="boolean" select="$condition/boolean"/>
        <xsl:call-template name="decision-boolean">
            <xsl:with-param name="condition" select="$condition"/>
            <xsl:with-param name="actionId" select="$actionId"/>
        </xsl:call-template>
    </xsl:template>

    <xsl:template name="condition-compare" >
        <xsl:param name="condition" />
        <xsl:param name="actionId"/>
        <xsl:variable name="boolean" select="$condition/compare"/>
        <xsl:call-template name="decision-compare">
            <xsl:with-param name="condition" select="$condition"/>
            <xsl:with-param name="actionId" select="$actionId"/>
        </xsl:call-template>
    </xsl:template>

    <xsl:template name="condition-limits" >
        <xsl:param name="condition" />
        <xsl:variable name="limit" select="$condition/limit"/>
        <xsl:variable name="upperLimit" select="$condition/upper_limit"/>
        <xsl:variable name="lowerLimit" select="$condition/lower_limit"/>
        <xsl:call-template name="decision">
            <xsl:with-param name="limit" select="$limit"/>
            <xsl:with-param name="condition" select="''"/>
        </xsl:call-template>
    </xsl:template>

    <xsl:template name="condition-sequence" >
        <xsl:param name="condition" />
        <xsl:param name="actionId" />
        <xsl:variable name="iterator" select="$condition/limit"/>
        <xsl:variable name="upperLimit" select="$condition/upper_limit"/>
        <xsl:variable name="lowerLimit" select="$condition/lower_limit"/>
        <xsl:call-template name="decision-sequence">
            <xsl:with-param name="condition" select="$condition"/>
            <xsl:with-param name="actionId" select="$actionId"/>
        </xsl:call-template>
    </xsl:template>

    <xsl:template name="source_comment">
        <xsl:param name="sourceFile"/>
        <xsl:param name="statementNo"/>
        <xsl:param name="lineNo"/>
        <xsl:if test="$sourceFile!=''" >
            <xsl:comment>@file="<xsl:value-of select="$sourceFile"/>" @statement_number="<xsl:value-of select="$statementNo"/>" @line_number="<xsl:value-of select="$lineNo"/>"</xsl:comment>
        </xsl:if>
    </xsl:template>

    <!-- ============================ -->
    <!-- Process a ATML Descision tag -->
    <!-- ============================ -->
    <xsl:template name="decision">
        <xsl:param name="limit"/>
        <xsl:param name="condition"/>
        <xsl:element name="Decision">
            <xsl:call-template name="valueComparison">
                <xsl:with-param name="limit" select="$limit"/>
                <xsl:with-param name="condition" select="$condition"/>
            </xsl:call-template>
        </xsl:element>
    </xsl:template>

    <!-- ===================================================== -->
    <!-- Process a Sequence Decision - iterate through a limit -->
    <!-- ===================================================== -->
    <xsl:template name="decision-sequence">
        <xsl:param name="condition"/>
        <xsl:param name="actionId"/>
        <xsl:element name="Decision">
            <xsl:call-template name="valueComparison-sequence">
                <xsl:with-param name="condition" select="$condition"/>
                <xsl:with-param name="actionId" select="$actionId"/>
            </xsl:call-template>
        </xsl:element>
    </xsl:template>


    <!-- ========================================================== -->
    <!-- Process a Boolean Decision - test a variable is TRUE/FALSE -->
    <!-- ========================================================== -->
    <xsl:template name="decision-boolean">
        <xsl:param name="condition"/>
        <xsl:param name="actionId"/>
        <xsl:element name="Decision">
            <xsl:call-template name="valueComparison-boolean">
                <xsl:with-param name="condition" select="$condition"/>
                <xsl:with-param name="actionId" select="$actionId"/>
            </xsl:call-template>
        </xsl:element>
    </xsl:template>

    <xsl:template name="decision-compare">
        <xsl:param name="condition"/>
        <xsl:param name="actionId"/>
        <xsl:element name="Decision">
            <xsl:call-template name="valueComparison-compare">
                <xsl:with-param name="condition" select="$condition"/>
                <xsl:with-param name="actionId" select="$actionId"/>
            </xsl:call-template>
        </xsl:element>
    </xsl:template>

    <!-- ============================================================ -->
    <!-- Process a Limit Decision - test a value falls in limit range -->
    <!-- ============================================================ -->
    <xsl:template name="decision-limit">
        <xsl:param name="limit"/>
        <xsl:param name="condition"/>
        <xsl:element name="Decision">
            <xsl:call-template name="valueComparison">
                <xsl:with-param name="limit" select="$limit"/>
                <xsl:with-param name="condition" select="$condition"/>
            </xsl:call-template>
        </xsl:element>
    </xsl:template>

    <xsl:template name="valueComparison-boolean">
        <xsl:param name="condition"/>
        <xsl:param name="actionId"/>
        <xsl:variable name="isNot" select="$condition/boolean/@unary_operator='not'"/>
        <xsl:variable name="variableName" select="$condition/boolean/@variable_name"/>
        <xsl:variable name="variableScope" select="$condition/boolean/@scope"/>
        <!-- ================================================================================ -->
        <!-- Currently all variables will need to be Action Level until we figure out Globals -->
        <!-- ================================================================================ -->
        <xsl:element name="Value">
            <xsl:element name="c:Datum">
                <xsl:attribute name="xsi:type">ValueFromActionParameter</xsl:attribute>
                <xsl:attribute name="parameterID">
                    <xsl:value-of select="concat($actionId, '_', $variableName)"/>
                </xsl:attribute>
            </xsl:element>
        </xsl:element>
        <xsl:element name="Limits" >
            <xsl:element name="Limit" >
                <xsl:call-template name="limit-expected" >
                    <xsl:with-param name="comparator" >
                        <xsl:choose>
                            <xsl:when test="$isNot">NE</xsl:when>
                            <xsl:otherwise>EQ</xsl:otherwise>
                        </xsl:choose>
                    </xsl:with-param>
                    <xsl:with-param name="value" >1</xsl:with-param>
                    <xsl:with-param name="dataType" >boolean</xsl:with-param>
                    <xsl:with-param name="unit"/>
                    <xsl:with-param name="qualifier"/>
                </xsl:call-template>
            </xsl:element>
        </xsl:element>
    </xsl:template>

    <xsl:template name="valueComparison-compare">
        <xsl:param name="condition"/>
        <xsl:param name="actionId"/>
        <xsl:variable name="operator" select="$condition/compare/@operator"/>
        <xsl:variable name="variableName" select="$condition/compare/left/@variable_name"/>
        <xsl:variable name="variableScope" select="$condition/compare/left/@scope"/>
        <xsl:variable name="value" >
            <xsl:choose>
                <xsl:when test="$condition/compare/right/@value"><xsl:value-of select="$condition/compare/right/@value" /> </xsl:when>
                <xsl:when test="$condition/compare/right/@variable_name"><xsl:value-of select="$condition/compare/right/@variable_name" /> </xsl:when>
            </xsl:choose>
        </xsl:variable>
        <xsl:variable name="valueType" select="$condition/compare/right/@type"/>
        <!-- ================================================================================ -->
        <!-- Currently all variables will need to be Action Level until we figure out Globals -->
        <!-- ================================================================================ -->
        <xsl:element name="Value">
            <xsl:element name="c:Datum">
                <xsl:attribute name="xsi:type">ValueFromActionParameter</xsl:attribute>
                <xsl:attribute name="parameterID">
                    <xsl:value-of select="concat($actionId, '_', $variableName)"/>
                </xsl:attribute>
            </xsl:element>
        </xsl:element>
        <xsl:element name="Limits" >
            <xsl:element name="Limit" >
                <xsl:call-template name="limit-expected" >
                    <xsl:with-param name="comparator" >
                        <xsl:choose>
                            <xsl:when test="$operator='='">EQ</xsl:when>
                            <xsl:when test="$operator='&lt;'">LT</xsl:when>
                            <xsl:when test="$operator='&gt;'">GT</xsl:when>
                            <xsl:when test="$operator='&lt;='">LE</xsl:when>
                            <xsl:when test="$operator='&gt;='">GE</xsl:when>
                        </xsl:choose>
                    </xsl:with-param>
                    <xsl:with-param name="value" ><xsl:value-of select="$value" /></xsl:with-param>
                    <xsl:with-param name="dataType" ><xsl:value-of select="$valueType" /></xsl:with-param>
                    <xsl:with-param name="unit"/>
                    <xsl:with-param name="qualifier"/>
                </xsl:call-template>
            </xsl:element>
        </xsl:element>
    </xsl:template>


    <xsl:template name="valueComparison-sequence">
        <xsl:param name="condition"/>
        <xsl:param name="actionId"/>
        <xsl:variable name="iterator" select="$condition/iterator"/>
        <xsl:variable name="initialize" select="$condition/initialize"/>
        <xsl:variable name="thru" select="$condition/thru"/>
        <!-- ================================================================================ -->
        <!-- Currently all variables will need to be Action Level until we figure out Globals -->
        <!-- ================================================================================ -->
        <!--
        <xsl:element name="Value">
            <xsl:element name="c:Datum">
                <xsl:attribute name="xsi:type">ValueFromIterator</xsl:attribute>
                <xsl:attribute name="parameterID">
                    <xsl:value-of select="concat($actionId, $variableName)"/>
                </xsl:attribute>
            </xsl:element>
        </xsl:element>
        <xsl:element name="Limits" >
            <xsl:element name="Limit" >
                <xsl:call-template name="limit-expected" >
                    <xsl:with-param name="comparator" >
                        <xsl:choose>
                            <xsl:when test="$isNot">NE</xsl:when>
                            <xsl:otherwise>EQ</xsl:otherwise>
                        </xsl:choose>
                    </xsl:with-param>
                    <xsl:with-param name="value" >1</xsl:with-param>
                    <xsl:with-param name="dataType" >c:boolean</xsl:with-param>
                    <xsl:with-param name="unit"/>
                    <xsl:with-param name="qualifier"/>
                </xsl:call-template>
            </xsl:element>
        </xsl:element>
        -->
    </xsl:template>



    <!-- =================================== -->
    <!-- Process a ATML Value Comparison tag -->
    <!-- =================================== -->
    <xsl:template name="valueComparison">
        <xsl:param name="limit"/>
        <xsl:param name="condition"/>
        <xsl:element name="ValueComparison">
            <xsl:variable name="variable" select="$condition/left/@variable_name"/>
            <xsl:choose>
                <xsl:when test="$condition">
                    <!--
                    EXAMPLE AIXML COMPAIR
                    <compare operator="&lt;">
                            <left variable_name=".M" type="double" scope="global" refid="1329"/>
                            .M will come from TestGroup
                            <right variable_name="LLMAX" type="double" scope="proc_param" refid="7632"/>
                            LLMAX will come from Action - ????
                        </compare>

                        Get Left from AIXML - if it is a variable use ValueFromActionParameter or ValueFromTestGroupParameter
                        Use Right for Limit
                    -->
                    <xsl:choose>
                        <xsl:when test="$condition/@type='boolean'">
                            <xsl:variable name="isNot" select="$condition/boolean/@unary_operator='not'"/>
                            <xsl:variable name="variableName" select="$condition/boolean/@variable_name"/>
                            <xsl:variable name="variableScope" select="$condition/boolean/@scope"/>
                            <xsl:choose>
                                <xsl:when test="$variableScope='global'">
                                    <xsl:element name="Value">
                                        <xsl:element name="c:Datum">
                                            <xsl:attribute name="xsi:type">ValueFromTestGroupParameter
                                            </xsl:attribute>
                                            <xsl:attribute name="testGroupParameterID">
                                                <xsl:value-of select="concat('TGP', $variableName)"/>
                                            </xsl:attribute>
                                        </xsl:element>
                                    </xsl:element>
                                </xsl:when>
                            </xsl:choose>
                        </xsl:when>
                    </xsl:choose>

                    <!--
                    <xsl:if test="$variable" >
                        <xsl:variable name="scope" select="$condition/left/@scope" />
                        <xsl:choose>

                            <xsl:when test="$scope='proc_result'" >

                            </xsl:when>

                            <xsl:when test="$scope='proc_param'" >
                                <Value>
                                    <xsl:element name="c:Datum" >
                                        <xsl:attribute name="xsi:type" > ValueFromTestGroupParameter</xsl:attribute>
                                        <xsl:attribute name="testGroupParameterID" > <xsl:value-of select="concat('ACT', $variable )" /></xsl:attribute>
                                    </xsl:element>
                                </Value>
                            </xsl:when>

                            <xsl:when test="$scope='global'" >
                                <Value>
                                    <xsl:element name="c:Datum" >
                                        <xsl:attribute name="xsi:type" > ValueFromTestGroupParameter</xsl:attribute>
                                        <xsl:attribute name="testGroupParameterID" > <xsl:value-of select="concat('TGP', $variable )" /></xsl:attribute>
                                    </xsl:element>
                                </Value>
                            </xsl:when>

                            <xsl:when test="$scope='file_local'" >
                            </xsl:when>

                            <xsl:when test="$scope='segment_local'" >
                            </xsl:when>

                        </xsl:choose>
                    </xsl:if>
                    -->
                </xsl:when>
                <xsl:when test="$limit">
                    <xsl:variable name="variableName" select="$limit/@variable_name"/>
                    <xsl:element name="ValueComparison">
                        <xsl:element name="Value">
                            <xsl:attribute name="xsi:type">ValueFromActionParameter</xsl:attribute>
                            <xsl:attribute name="parameterId">
                                <xsl:value-of select="$variableName"/>
                            </xsl:attribute>
                            <xsl:element name="Limits">
                                <xsl:element name="Limit">
                                    <xsl:call-template name="limit-pair">
                                        <xsl:with-param name="condition" select="$condition"/>
                                        <xsl:with-param name="range"/>
                                    </xsl:call-template>
                                    <!--xsl:if test="$lowerLimit and $upperLimit" >
                                            <xsl:element name="LimitPair" >
                                                    <xsl:attribute name="operator">AND</xsl:attribute>
                                                            <xsl:element name="Limit" >
                                                                    <xsl:attribute name="comparator">GE</xsl:attribute>
                                                                    <xsl:element name="Datum" >
                                                                            <xsl:attribute name="xsi:type">c:<xsl:value-of select="$lowerLimit/@type" /></xsl:attribute>
                                                                            <xsl:attribute name="value"><xsl:value-of select="$lowerLimit/@value" /></xsl:attribute>
                                                                    </xsl:element>
                                                            </xsl:element>

                                                            <xsl:element name="Limit" >
                                                                    <xsl:attribute name="comparator">LE</xsl:attribute>
                                                                    <xsl:element name="Datum" >
                                                                            <xsl:attribute name="xsi:type">c:<xsl:value-of select="$upperLimit/@type" /></xsl:attribute>
                                                                            <xsl:attribute name="value"><xsl:value-of select="$upperLimit/@value" /></xsl:attribute>
                                                                    </xsl:element>
                                                            </xsl:element>


                                            </xsl:element>
                                    </xsl:if-->
                                </xsl:element>
                            </xsl:element>
                        </xsl:element>
                    </xsl:element>
                </xsl:when>
            </xsl:choose>
        </xsl:element>
    </xsl:template>

    <!-- ======================== -->
    <!-- Process a Else Statement -->
    <!-- ======================== -->
    <xsl:template name="else_statement">
        <xsl:comment>Else</xsl:comment>
        <xsl:call-template name="source_comment">
            <xsl:with-param name="sourceFile" select="atlas_source/@file"/>
            <xsl:with-param name="statementNo" select="atlas_source/@statement_number"/>
            <xsl:with-param name="lineNo" select="atlas_source/@line_number"/>
        </xsl:call-template>
        <xsl:element name="Operation">
            <xsl:attribute name="xsi:type">OperationOther</xsl:attribute>
            <DetailedInformation>
                <xsl:text>Remove</xsl:text>
            </DetailedInformation>
        </xsl:element>
    </xsl:template>

    <!-- ============================= -->
    <!-- Process a Calculate Statement -->
    <!-- ============================= -->
    <xsl:template name="calculate_statement">
        <xsl:param name="refId"/>
        <xsl:comment>Calculate</xsl:comment>
        <xsl:variable name="statement" select="//*[@id=$refId]" />
        <xsl:call-template name="source_comment">
            <xsl:with-param name="sourceFile" select="$statement/atlas_source/@file"/>
            <xsl:with-param name="statementNo" select="$statement/atlas_source/@statement_number"/>
            <xsl:with-param name="lineNo" select="$statement/atlas_source/@line_number"/>
        </xsl:call-template>
        <xsl:element name="Operation">
            <xsl:attribute name="xsi:type">OperationOther</xsl:attribute>
            <DetailedInformation>
                <xsl:text>Perform Calculate Operation Here</xsl:text>
            </DetailedInformation>
        </xsl:element>
    </xsl:template>

    <!-- ========================= -->
    <!-- Process a Input Statement -->
    <!-- ========================= -->
    <xsl:template name="input_statement">
        <xsl:param name="refId"/>
        <xsl:comment>Input</xsl:comment>
        <xsl:variable name="statement" select="//*[@id=$refId]" />
        <xsl:call-template name="source_comment">
            <xsl:with-param name="sourceFile" select="$statement/atlas_source/@file"/>
            <xsl:with-param name="statementNo" select="$statement/atlas_source/@statement_number"/>
            <xsl:with-param name="lineNo" select="$statement/atlas_source/@line_number"/>
        </xsl:call-template>
        <xsl:element name="Operation">
            <xsl:attribute name="xsi:type">OperationOther</xsl:attribute>
            <DetailedInformation>
                <xsl:text>Perform Input Operation Here</xsl:text>
            </DetailedInformation>
        </xsl:element>
    </xsl:template>

    <!-- ========================== -->
    <!-- Process a Output Statement -->
    <!-- ========================== -->
    <xsl:template name="output_statement">
        <xsl:param name="refId"/>
        <xsl:comment>Output</xsl:comment>
        <xsl:variable name="statement" select="//*[@id=$refId]" />
        <xsl:call-template name="source_comment">
            <xsl:with-param name="sourceFile" select="$statement/atlas_source/@file"/>
            <xsl:with-param name="statementNo" select="$statement/atlas_source/@statement_number"/>
            <xsl:with-param name="lineNo" select="$statement/atlas_source/@line_number"/>
        </xsl:call-template>
        <xsl:element name="Operation">
            <xsl:attribute name="xsi:type">OperationOther</xsl:attribute>
            <DetailedInformation>
                <xsl:text>Perform Output Operation Here</xsl:text>
            </DetailedInformation>
        </xsl:element>
    </xsl:template>

    <!-- =========================== -->
    <!-- Process a Compare Statement -->
    <!-- =========================== -->
    <xsl:template name="compare_statement">
        <xsl:param name="refId"/>
        <xsl:variable name="compare" select="//*[@id=$refId]"/>
        <xsl:variable name="varType" select="$compare/assignment/limit/@type"/>

        <xsl:if test="$compare">
            <xsl:comment>Compare</xsl:comment>
            <xsl:variable name="statement" select="//*[@id=$refId]" />
            <xsl:call-template name="source_comment">
                <xsl:with-param name="sourceFile" select="$statement/atlas_source/@file"/>
                <xsl:with-param name="statementNo" select="$statement/atlas_source/@statement_number"/>
                <xsl:with-param name="lineNo" select="$statement/atlas_source/@line_number"/>
            </xsl:call-template>
            <xsl:element name="Operation">
                <xsl:attribute name="xsi:type">OperationConditional</xsl:attribute>
                <xsl:attribute name="id">CMP<xsl:value-of select="@id"/>
                </xsl:attribute>
                <xsl:element name="Decision">
                    <xsl:element name="ValueComparison">
                        <xsl:element name="Value">
                            <xsl:attribute name="standardUnit">
                                <xsl:value-of select="$varType"/>
                            </xsl:attribute>
                        </xsl:element>
                        <xsl:element name="Limits">
                            <xsl:element name="Limit">
                                <xsl:if test="$compare/assignment/upper_limit and $compare/assignment/lower_limit">
                                </xsl:if>
                            </xsl:element>
                        </xsl:element>
                    </xsl:element>
                </xsl:element>
                <DetailedInformation>
                    <xsl:text>Remove</xsl:text>
                </DetailedInformation>
            </xsl:element>
        </xsl:if>
    </xsl:template>

    <!-- ========================== -->
    <!-- Process a Enable Statement -->
    <!-- ========================== -->
    <xsl:template name="enable_statement">
        <xsl:param name="refId"/>
        <xsl:comment>Enable</xsl:comment>
        <xsl:variable name="statement" select="//*[@id=$refId]" />
        <xsl:call-template name="source_comment">
            <xsl:with-param name="sourceFile" select="$statement/atlas_source/@file"/>
            <xsl:with-param name="statementNo" select="$statement/atlas_source/@statement_number"/>
            <xsl:with-param name="lineNo" select="$statement/atlas_source/@line_number"/>
        </xsl:call-template>
        <xsl:element name="Operation">
            <xsl:attribute name="xsi:type">OperationOther</xsl:attribute>
            <DetailedInformation>
                <xsl:text>Perform Enable Operation Here</xsl:text>
            </DetailedInformation>
        </xsl:element>
    </xsl:template>

    <!-- =========================== -->
    <!-- Process a Disable Statement -->
    <!-- =========================== -->
    <xsl:template name="disable_statement">
        <xsl:param name="refId"/>
        <xsl:comment>Disable</xsl:comment>
        <xsl:variable name="statement" select="//*[@id=$refId]" />
        <xsl:call-template name="source_comment">
            <xsl:with-param name="sourceFile" select="$statement/atlas_source/@file"/>
            <xsl:with-param name="statementNo" select="$statement/atlas_source/@statement_number"/>
            <xsl:with-param name="lineNo" select="$statement/atlas_source/@line_number"/>
        </xsl:call-template>
        <xsl:element name="Operation">
            <xsl:attribute name="xsi:type">OperationOther</xsl:attribute>
            <DetailedInformation>
                <xsl:text>Perform Disable Operation Here</xsl:text>
            </DetailedInformation>
        </xsl:element>
    </xsl:template>

    <!-- ========================= -->
    <!-- Process a Delay Statement -->
    <!-- ========================= -->
    <xsl:template name="delay_statement">
        <xsl:param name="refId"/>
        <xsl:variable name="delayStatement" select="//*[@id=$refId]"/>
        <xsl:if test="$delayStatement">
            <xsl:comment>Delay</xsl:comment>
            <xsl:variable name="statement" select="//*[@id=$refId]" />
            <xsl:call-template name="source_comment">
                <xsl:with-param name="sourceFile" select="$statement/atlas_source/@file"/>
                <xsl:with-param name="statementNo" select="$statement/atlas_source/@statement_number"/>
                <xsl:with-param name="lineNo" select="$statement/atlas_source/@line_number"/>
            </xsl:call-template>
            <xsl:element name="Operation">
                <xsl:attribute name="xsi:type">OperationWaitFor</xsl:attribute>
                <xsl:element name="TimeValue">
                    <xsl:attribute name="value">
                        <xsl:value-of select="$delayStatement/number/@value"/>
                    </xsl:attribute>
                    <xsl:attribute name="standardUnit">
                        <xsl:value-of select="$delayStatement/number/@unit"/>
                    </xsl:attribute>
                </xsl:element>
            </xsl:element>
        </xsl:if>
    </xsl:template>

    <!-- ======================== -->
    <!-- Process a Fill Statement -->
    <!-- ======================== -->
    <xsl:template name="fill_statement">
        <xsl:param name="refId"/>
        <xsl:comment>Fill</xsl:comment>
        <xsl:variable name="statement" select="//*[@id=$refId]" />
        <xsl:call-template name="source_comment">
            <xsl:with-param name="sourceFile" select="$statement/atlas_source/@file"/>
            <xsl:with-param name="statementNo" select="$statement/atlas_source/@statement_number"/>
            <xsl:with-param name="lineNo" select="$statement/atlas_source/@line_number"/>
        </xsl:call-template>
        <xsl:element name="Operation">
            <xsl:attribute name="xsi:type">OperationOther</xsl:attribute>
            <DetailedInformation>
                <xsl:text>Perform Fill Operation Here</xsl:text>
            </DetailedInformation>
        </xsl:element>
    </xsl:template>

    <!-- ================================= -->
    <!-- Process a Read DateTime Statement -->
    <!-- ================================= -->
    <xsl:template name="read_datetime_statement">
        <xsl:param name="refId"/>
        <xsl:comment>Read DateTime</xsl:comment>
        <xsl:variable name="statement" select="//*[@id=$refId]" />
        <xsl:call-template name="source_comment">
            <xsl:with-param name="sourceFile" select="$statement/atlas_source/@file"/>
            <xsl:with-param name="statementNo" select="$statement/atlas_source/@statement_number"/>
            <xsl:with-param name="lineNo" select="$statement/atlas_source/@line_number"/>
        </xsl:call-template>
        <xsl:element name="Operation">
            <xsl:attribute name="xsi:type">OperationOther</xsl:attribute>
            <DetailedInformation>
                <xsl:text>Perform Read DateTime Operation Here</xsl:text>
            </DetailedInformation>
        </xsl:element>
    </xsl:template>

    <!-- ============ -->
    <!-- Behavior Tag -->
    <!-- ============ -->
    <xsl:template name="behavior">
        <xsl:comment>Behavior</xsl:comment>
    </xsl:template>

    <!-- ================= -->
    <!-- Perform Operation -->
    <!-- ================= -->
    <xsl:template name="perform-operation">
        <xsl:variable name="statementId" select="@id"/>
        <xsl:variable name="procRefId" select="@proc_refid"/>
        <xsl:variable name="refId" select="@refid"/>
        <xsl:variable name="actionId" select="concat( 'ACT', $procRefId )"/>
        <xsl:variable name="procedure" select="//*[@id=$procRefId]"/>
        <xsl:variable name="varType" select="@type"/>
        <xsl:comment>Call to Procedure [<xsl:if test="$procRefId"><xsl:value-of select="//procedure[@id=$procRefId]/@name"/></xsl:if><xsl:if test="$refId"><xsl:value-of select="$procedure/@name"/></xsl:if>]</xsl:comment>
        <xsl:element name="utrs:call-action">
            <xsl:attribute name="actionId">
                <xsl:value-of select="$actionId"/>
            </xsl:attribute>
            <xsl:for-each select="parameters/parameter">
                <xsl:variable name="idx" select="position()"/>
                <xsl:element name="utrs:with-parameter">
                    <xsl:attribute name="name">
                        <xsl:value-of select="$procedure/parameters/parameter[$idx]/@name"/>
                    </xsl:attribute>
                    <xsl:attribute name="value">
                        <xsl:if test="@value">
                            <xsl:value-of select="@value"/>
                        </xsl:if>
                        <xsl:if test="@variable_name">
                            <xsl:value-of select="concat('$', @variable_name)"/>
                        </xsl:if>
                    </xsl:attribute>
                    <xsl:attribute name="type">
                        <xsl:value-of select="$varType"/>
                    </xsl:attribute>
                </xsl:element>
            </xsl:for-each>
        </xsl:element>
    </xsl:template>

    <!-- =========== -->
    <!-- Test Groups -->
    <!-- =========== -->
    <xsl:template name="test-groups">
        <TestGroups>
            <xsl:for-each select="/atlas/procedures/procedure">
                <xsl:if test="test_numbers/test/@begin_test" >
                    <xsl:call-template name="test-group"/>
                </xsl:if>
            </xsl:for-each>
        </TestGroups>
    </xsl:template>

    <!-- ========== -->
    <!-- Test Group -->
    <!-- ========== -->
    <xsl:template name="test-group">
        <xsl:comment>@file="<xsl:value-of select="./atlas_source/@file"/>" @statement_number="<xsl:value-of
                select="./atlas_source/@statement_number"/>" @line_number="<xsl:value-of
                select="./atlas_source/@line_number"/>"
        </xsl:comment>
        <xsl:element name="TestGroup">
            <xsl:attribute name="ID">
                <xsl:value-of select="concat('tg',@id)"/>
            </xsl:attribute>
            <xsl:attribute name="name">
                <xsl:value-of select="@name"/>
            </xsl:attribute>
            <!-- TODO: Need to determine the xsi type -->
            <xsl:attribute name="xsi:type">TestGroupSequence</xsl:attribute>

            <xsl:if test="@main_procedure='truexxx'">

                <ParameterDescriptions>
                    <xsl:for-each select="/atlas/declares/declare[@scope='global' and @variable='true']">
                        <xsl:variable name="false" select="1=2"/>
                        <xsl:variable name="varId" select="@id"/>
                        <xsl:variable name="varName" select="@name"/>
                        <xsl:variable name="varType" select="@type"/>
                        <xsl:variable name="isList" select="@list='true'"/>
                        <xsl:variable name="hasCalculation"
                                      select="assignments_by_statement/assignment[@type='arthimetic']"/>
                        <xsl:variable name="hasAssignment"
                                      select="assignments_by_statement/assignment[@type='assign']"/>
                        <xsl:variable name="hasVariable"
                                      select="assignments_by_statement/assignment/assign/@variable_name"/>
                        <xsl:element name="ParameterDescription">
                            <!-- We will use the variable name for the id because in the original
                            Atlas thats how global variables were referenced. They should be unique
                            across the application. -->
                            <xsl:attribute name="ID">TGP<xsl:value-of select="@name"/>
                            </xsl:attribute>
                            <xsl:attribute name="name">
                                <xsl:value-of select="@name"/>
                            </xsl:attribute>
                            <xsl:element name="ValueDescription">
                                <!-- ================================ -->
                                <!-- TODO: Figure out what to do here -->
                                <!-- ================================ -->
                                <xsl:choose>
                                    <xsl:when test="$isList">
                                        <xsl:element name="IndexedArrayDescription">
                                            <xsl:attribute name="xsi:type">
                                                <xsl:choose>
                                                    <xsl:when test="$varType='double'">doubleArrayDescription</xsl:when>
                                                    <xsl:when test="$varType='decimal'">doubleArrayDescription</xsl:when>
                                                    <xsl:when test="$varType='integer'">integerArrayDescription
                                                    </xsl:when>
                                                    <xsl:when test="$varType='boolean'">booleanArrayDescription
                                                    </xsl:when>
                                                    <xsl:when test="$varType='string'">stringArrayDescription</xsl:when>
                                                    <xsl:when test="$varType='char'">stringArrayDescription</xsl:when>
                                                </xsl:choose>
                                            </xsl:attribute>
                                            <xsl:attribute name="dimensions">[<xsl:value-of select="@list_length"/>]
                                            </xsl:attribute>
                                        </xsl:element>

                                        <!--IndexedArrayDescription xsi:type="doubleDescription" standardUnit="Ohm"/-->
                                    </xsl:when>
                                    <xsl:otherwise>
                                        <xsl:element name="DatumDescription">
                                            <xsl:attribute name="xsi:type">
                                                <xsl:choose>
                                                    <xsl:when test="$varType='double'">doubleDescription</xsl:when>
                                                    <xsl:when test="$varType='decimal'">doubleDescription</xsl:when>
                                                    <xsl:when test="$varType='integer'">integerDescription</xsl:when>
                                                    <xsl:when test="$varType='boolean'">booleanDescription</xsl:when>
                                                    <xsl:when test="$varType='string'">stringDescription</xsl:when>
                                                    <xsl:when test="$varType='char'">stringDescription</xsl:when>
                                                </xsl:choose>
                                            </xsl:attribute>
                                        </xsl:element>
                                    </xsl:otherwise>
                                </xsl:choose>

                                <!--xsl:call-template name="datum">
                                    <xsl:with-param name="value" >
                                            <xsl:choose>
                                                <xsl:when test="$varType='boolean' " >
                                                    <xsl:value-of select="$false" />
                                                </xsl:when>
                                                <xsl:when test="$varType='string' " >
                                                    <xsl:value-of select="''" />
                                                </xsl:when>
                                                <xsl:otherwise>
                                                    <xsl:value-of select="0" />
                                                </xsl:otherwise>
                                            </xsl:choose>
                                    </xsl:with-param>
                                    <xsl:with-param name="type" select="$varType" />
                                </xsl:call-template-->
                            </xsl:element>
                        </xsl:element>
                    </xsl:for-each>
                </ParameterDescriptions>


            </xsl:if>


            <xsl:call-template name="outcomes"/>
            <xsl:call-template name="initialization"/>
            <xsl:call-template name="termination"/>
            <xsl:call-template name="steps"/>
        </xsl:element>
    </xsl:template>

    <!-- ======== -->
    <!-- Outcomes -->
    <!-- ======== -->
    <xsl:template name="outcomes">
        <Outcomes>
        </Outcomes>
    </xsl:template>

    <!-- ============== -->
    <!-- Initialization -->
    <!-- ============== -->
    <xsl:template name="initialization">
        <Initialization>
            <InitializationAction actionID="test5"/>
        </Initialization>
    </xsl:template>

    <!-- =========== -->
    <!-- Termination -->
    <!-- =========== -->
    <xsl:template name="termination">
        <Termination>
            <TerminationAction actionID="test6"/>
        </Termination>
    </xsl:template>

    <!-- ===== -->
    <!-- Steps -->
    <!-- ===== -->
    <xsl:template name="steps">
        <Steps>
            <xsl:call-template name="step"/>
        </Steps>
    </xsl:template>

    <!-- ==== -->
    <!-- Step -->
    <!-- ==== -->
    <xsl:template name="step">

        <xsl:for-each select="test_numbers/test" >
            <xsl:variable name="idx" select="position()"/>
            <xsl:variable name="stepId" select="concat('step',$idx)"/>
            <xsl:element name="Step">
                <xsl:attribute name="ID">
                    <xsl:value-of select="$stepId"/>
                </xsl:attribute>
                <!--xsl:element name="TestGroupReference">
                    <xsl:attribute name="testGroupID">
                        <xsl:value-of select="concat('TST', @number)"/>
                    </xsl:attribute>
                </xsl:element-->
                <xsl:element name="ActionReference">
                    <xsl:attribute name="actionID">
                        <xsl:value-of select="concat('TST', @number)"/>
                    </xsl:attribute>
                </xsl:element>
            </xsl:element>
        </xsl:for-each>

        <!--
        <xsl:for-each select="./statements/statement">
            <xsl:variable name="idx" select="position()"/>
            <xsl:variable name="stepId" select="concat('step',$idx)"/>
            <xsl:variable name="type" select="@type"/>
            <xsl:variable name="refid" select="@refid"/>
            <xsl:variable name="source" select="/atlas/statements/*/*[@id=$refid]"/>
            <xsl:if test="$source">
                <xsl:comment>@file="<xsl:value-of select="$source/atlas_source/@file"/>"
                    @statement_number="<xsl:value-of select="$source/atlas_source/@statement_number"/>"
                    @line_number="<xsl:value-of select="$source/atlas_source/@line_number"/>"
                </xsl:comment>
            </xsl:if>

            <xsl:element name="Step">
                <xsl:attribute name="ID">
                    <xsl:value-of select="$stepId"/>
                </xsl:attribute>
                <xsl:choose>
                    <xsl:when test="'PERFORM'=$type">
                        <xsl:element name="TestGroupReference">
                            <xsl:attribute name="testGroupID">
                                <xsl:value-of select="$refid"/>
                            </xsl:attribute>
                        </xsl:element>
                    </xsl:when>
                    <xsl:otherwise>
                        <xsl:element name="ActionReference">
                            <xsl:attribute name="actionID">
                                <xsl:value-of select="$refid"/>
                            </xsl:attribute>
                            <xsl:for-each select="//*[@id=$refid]">
                                <xsl:variable name="label" select="@virtual_label"/>
                                <xsl:attribute name="sub"><xsl:value-of select="concat(local-name(.), '(', @id, ')')" /></xsl:attribute>
                                <xsl:for-each
                                        select="/atlas/signal_oriented_statement/require_statement/requires/require[@virtual_label=$label]">
                                    <xsl:attribute name="source"><xsl:value-of
                                            select="require_types/require_type/@type"/>(<xsl:value-of select="@id"/>)
                                    </xsl:attribute>
                                </xsl:for-each>

                            </xsl:for-each>
                        </xsl:element>
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:element>

            <Results    >
                <Result>
                    <ActionOutcomeReference actionOutcomeID="t1o1"/>
                    <NextStep stepID="before_step2"/>
                </Result>
                <Result>
                    <ActionOutcomeReference actionOutcomeID="t1o2"/>
                    <NextStep stepID="step3"/>
                </Result>
            </Results>

        </xsl:for-each>

        -->
    </xsl:template>

</xsl:stylesheet>