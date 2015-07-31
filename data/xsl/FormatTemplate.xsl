<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="2.0" 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
	xmlns:inst="urn:IEEE-1671.2:2012:InstrumentDescription" 
	xmlns:c="urn:IEEE-1671:2010:Common" 
	xmlns:hc="urn:IEEE-1671:2010:HardwareCommon" 
	xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
	<xsl:output method="html" version="1.0" encoding="UTF-8" indent="yes"/>
	<xsl:param name="ASpace" select="' '"/>
	<xsl:template match="/">
		<html>
			<head>
				<title>SI Template Viewer</title>
				<style>
BODY
{
    FONT-FAMILY: lucida console;
    BACKGROUND-COLOR: buttonface
}
TABLE
{
    BORDER-TOP: highlight 1px solid;
    BORDER-RIGHT: highlight 1px solid;
    BORDER-LEFT: highlight 1px solid;
    BORDER-BOTTOM: highlight 1px solid;
    
    PADDING-RIGHT: 0px;
    PADDING-LEFT: 0px;
    PADDING-BOTTOM: 0px;
    PADDING-TOP: 0px;
    
    WIDTH: 100%;
    BORDER-COLLAPSE: collapse
}
TD.HoldsTable
{
    BORDER-RIGHT: highlight 1px solid;
    BORDER-TOP: highlight 1px solid;
    BORDER-LEFT: highlight 1px solid;
    BORDER-BOTTOM: highlight 1px solid;

    FONT-WEIGHT: normal;
    FONT-SIZE: x-small;

    PADDING-RIGHT: 0px;
    PADDING-LEFT: 0px;
    PADDING-BOTTOM: 0px;
    PADDING-TOP: 0px;
    
    VERTICAL-ALIGN: top;
    LINE-HEIGHT: normal;
    FONT-STYLE: normal;
    FONT-VARIANT: normal
}
TD
{
    BORDER-RIGHT: highlight 1px solid;
    BORDER-TOP: highlight 1px solid;
    BORDER-LEFT: highlight 1px solid;
    BORDER-BOTTOM: highlight 1px solid;

    FONT-WEIGHT: normal;
    FONT-SIZE: x-small;

    PADDING-RIGHT: 3px;
    PADDING-LEFT: 3px;
    PADDING-BOTTOM: 1px;
    PADDING-TOP: 1px;
    
    VERTICAL-ALIGN: top;
    LINE-HEIGHT: normal;
    FONT-STYLE: normal;
    FONT-VARIANT: normal
}
TD.SpecValue
{
    BORDER-RIGHT: highlight 1px solid;
    BORDER-TOP: highlight 1px solid;
    BORDER-LEFT: highlight 1px solid;
    BORDER-BOTTOM: highlight 1px solid;

    FONT-WEIGHT: normal;
    FONT-SIZE: x-small;

    PADDING-RIGHT: 3px;
    PADDING-LEFT: 3px;
    PADDING-BOTTOM: 1px;
    PADDING-TOP: 1px;
    
    VERTICAL-ALIGN: top;
    LINE-HEIGHT: normal;
    FONT-STYLE: normal;
    FONT-VARIANT: normal
    COLOR: highlight;
    BACKGROUND-COLOR: window;
    WIDTH: 25%;
}
TD.SpecLimit
{
    BORDER-RIGHT: highlight 0px solid;
    BORDER-TOP: highlight 1px solid;
    BORDER-LEFT: highlight 0px solid;
    BORDER-BOTTOM: highlight 0px solid;

    FONT-WEIGHT: normal;
    FONT-SIZE: x-small;

    PADDING-RIGHT: 3px;
    PADDING-LEFT: 3px;
    PADDING-BOTTOM: 1px;
    PADDING-TOP: 1px;
    
    VERTICAL-ALIGN: top;
    LINE-HEIGHT: normal;
    FONT-STYLE: normal;
    FONT-VARIANT: normal
    COLOR: highlight;
    WIDTH: 25%;
}
TD.SpecNoValue
{
    BORDER-RIGHT: highlight 1px solid;
    BORDER-TOP: highlight 1px solid;
    BORDER-LEFT: highlight 1px solid;
    BORDER-BOTTOM: highlight 1px solid;

    FONT-WEIGHT: normal;
    FONT-SIZE: x-small;

    PADDING-RIGHT: 3px;
    PADDING-LEFT: 3px;
    PADDING-BOTTOM: 1px;
    PADDING-TOP: 1px;
    
    VERTICAL-ALIGN: top;
    LINE-HEIGHT: normal;
    FONT-STYLE: normal;
    FONT-VARIANT: normal
    COLOR: highlight;
    BACKGROUND-COLOR: red;
    WIDTH: 25%;
}
TD.SpecTable
{
    BORDER-RIGHT: highlight 1px solid;
    BORDER-TOP: highlight 1px solid;
    BORDER-LEFT: highlight 1px solid;
    BORDER-BOTTOM: highlight 1px solid;

    FONT-WEIGHT: normal;
    FONT-SIZE: x-small;

    PADDING-RIGHT: 0px;
    PADDING-LEFT: 0px;
    PADDING-BOTTOM: 0px;
    PADDING-TOP: 0px;
    
    VERTICAL-ALIGN: top;
    LINE-HEIGHT: normal;
    FONT-STYLE: normal;
    FONT-VARIANT: normal
    COLOR: highlight;
    BACKGROUND-COLOR: window;
    WIDTH: 25%;
}
TD.ControlTable
{
    BORDER-RIGHT: highlight 1px solid;
    BORDER-TOP: highlight 1px solid;
    BORDER-LEFT: highlight 1px solid;
    BORDER-BOTTOM: highlight 1px solid;

    FONT-WEIGHT: normal;
    FONT-SIZE: x-small;

    PADDING-RIGHT: 0px;
    PADDING-LEFT: 0px;
    PADDING-BOTTOM: 0px;
    PADDING-TOP: 0px;
    
    VERTICAL-ALIGN: top;
    LINE-HEIGHT: normal;
    FONT-STYLE: normal;
    FONT-VARIANT: normal
    COLOR: highlight;
    BACKGROUND-COLOR: lightblue;
    WIDTH: 25%;
}
TABLE.Embeded
{
    BORDER-TOP: highlight 0px solid;
    BORDER-RIGHT: highlight 0px solid;
    BORDER-LEFT: highlight 0px solid;
    BORDER-BOTTOM: highlight 0px solid;
    
    PADDING-RIGHT: 0px;
    PADDING-LEFT: 0px;
    PADDING-BOTTOM: 0px;
    PADDING-TOP: 0px;
    
    WIDTH: 100%;
    HEIGHT: 100%;
    BORDER-COLLAPSE: collapse
}
TH
{
    BORDER-RIGHT: highlight 1px solid;
    BORDER-TOP: highlight 1px solid;
    BORDER-LEFT: highlight 1px solid;
    BORDER-BOTTOM: highlight 1px solid;

    PADDING-RIGHT: 3px;
    PADDING-LEFT: 3px;
    PADDING-TOP: 3px;
    PADDING-BOTTOM: 3px;

    FONT-WEIGHT: bold;
    FONT-SIZE: small;
    COLOR: window;
    LINE-HEIGHT: normal;
    FONT-STYLE: normal;
    BACKGROUND-COLOR: highlight;
    TEXT-ALIGN: center;
    FONT-VARIANT: normal
}
TH.Sub
{
    BORDER-RIGHT: highlight 1px solid;
    BORDER-TOP: highlight 1px solid;
    BORDER-LEFT: highlight 1px solid;
    BORDER-BOTTOM: highlight 1px solid;

    PADDING-RIGHT: 3px;
    PADDING-LEFT: 3px;
    PADDING-TOP: 3px;
    PADDING-BOTTOM: 3px;

    FONT-WEIGHT: bold-italic;
    FONT-SIZE: small;
    LINE-HEIGHT: normal;
    FONT-STYLE: normal;
    COLOR: highlight;
    BACKGROUND-COLOR: window;
    TEXT-ALIGN: center;
    FONT-VARIANT: normal
}
		</style>
			</head>
			<body>
				<xsl:apply-templates select="inst:InstrumentDescription"/>
			</body>
		</html>
	</xsl:template>
	<xsl:template match="inst:InstrumentDescription">
		<xsl:apply-templates select="node()"/>
	</xsl:template>
	<xsl:template match="c:Identification">
		<table>
			<tr>
				<th colspan="2">
					<xsl:value-of select="../@type"/>:<xsl:value-of select="c:ModelName"/>
				</th>
			</tr>
		</table>
		<p/>
	</xsl:template>
	<xsl:template match="hc:Interface">
		<h1>Interface</h1>
		<xsl:apply-templates select="node()"/>
	</xsl:template>
	<xsl:template match="c:Ports">
		<h2>Ports</h2>
		<table>
			<tr>
				<th class="Sub">Name</th>
				<th class="Sub">Direction</th>
				<th class="Sub">Type</th>
			</tr>
			<xsl:apply-templates select="node()"/>
		</table>
		<p/>
	</xsl:template>
	<xsl:template match="c:Port">
		<tr>
			<td>
				<xsl:value-of select="@name"/>
			</td>
			<td>
				<xsl:value-of select="@direction"/>
			</td>
			<td>
				<xsl:value-of select="@type"/>
			</td>
		</tr>
	</xsl:template>
	<xsl:template match="c:Connectors">
		<h2>Connectors</h2>
		<table>
			<tr>
				<th class="Sub">ID</th>
				<th class="Sub">Location</th>
				<th class="Sub">Type</th>
				<th class="Sub">Mating Connector</th>
				<th class="Sub">Model Name</th>
			</tr>
			<xsl:apply-templates select="node()"/>
		</table>
		<p/>		
	</xsl:template>
	<xsl:template match="c:Connectors/c:Connector">
		<tr>
			<td>
				<xsl:value-of select="@ID"/>
			</td>
			<td>
				<xsl:value-of select="@location"/>
			</td>
			<td>
				<xsl:value-of select="@type"/>
			</td>
			<td>
				<xsl:value-of select="@matingConnectorType"/>
			</td>
			<td>
				<xsl:value-of select="./c:Identification/c:ModelName"/>
			</td>
		</tr>
	</xsl:template>
	<xsl:template match="hc:PowerRequirements">
		<h1>Power Requirements</h1>
		<table>
			<xsl:apply-templates select="node()"/>
		</table>
	</xsl:template>
	<xsl:template match="hc:AC">
		<tr>
			<td>AC</td>
			<td class="HoldsTable">
				<table class="Embeded">
				<xsl:if test="hc:Description">
					<tr>
						<td colspan="2"><xsl:value-of select="hc:Description"/></td>
					</tr>
				</xsl:if>
				<xsl:if test="@phase">
					<tr>
						<td>Phase</td>
						<td><xsl:value-of select="@phase"/></td>
					</tr>
				</xsl:if>
				<tr>
					<td>Frequency</td>
					<td class="HoldsTable">
						<xsl:call-template name="Output-Limit">
							<xsl:with-param name="Limit" select="hc:Frequency"/>
						</xsl:call-template>
					</td>
				</tr>
				<tr>
					<td>Voltage</td>
					<td class="HoldsTable">
						<xsl:call-template name="Output-Limit">
							<xsl:with-param name="Limit" select="hc:Voltage"/>
						</xsl:call-template>
					</td>
				</tr>
				<xsl:if test="hc:Amperage">
					<tr>
						<td>Amperage</td>
					<td class="HoldsTable">
						<xsl:call-template name="Output-Limit">
							<xsl:with-param name="Limit" select="hc:Amperage"/>
						</xsl:call-template>
					</td>
					</tr>
				</xsl:if>
				<xsl:if test="hc:PowerDraw">
					<tr>
						<td>Power Draw</td>
					<td class="HoldsTable">
						<xsl:call-template name="Output-Limit">
							<xsl:with-param name="Limit" select="hc:PowerDraw"/>
						</xsl:call-template>
					</td>
					</tr>
				</xsl:if>
				<xsl:if test="hc:Connector">
					<tr>
						<td>Connector</td>
						<td>
							<xsl:value-of select="hc:Connector/@connectorID"/>
							<xsl:if test="hc:Connector/@pinID">
							[<xsl:value-of select="hc:Connector/@pinID"/>]
							</xsl:if>
						</td>
					</tr>
				</xsl:if>
				</table>
			</td>
		</tr>
	</xsl:template>
	<xsl:template match="hc:DC">
		<tr>
			<td>DC</td>
			<td class="HoldsTable">
				<table class="Embeded">
				<xsl:if test="hc:Description">
					<tr>
						<td colspan="2"><xsl:value-of select="hc:Description"/></td>
					</tr>
				</xsl:if>
				<xsl:if test="@polarity">
					<tr>
						<td>Polarity</td>
						<td><xsl:value-of select="@polarity"/></td>
					</tr>
				</xsl:if>
				<xsl:if test="@ripple">
					<tr>
						<td>Ripple</td>
						<td><xsl:value-of select="@ripple"/></td>
					</tr>
				</xsl:if>
				<tr>
					<td>Voltage</td>
					<td class="HoldsTable">
						<xsl:call-template name="Output-Limit">
							<xsl:with-param name="Limit" select="hc:Voltage"/>
						</xsl:call-template>
					</td>
				</tr>
				<xsl:if test="hc:Amperage">
					<tr>
						<td>Amperage</td>
					<td class="HoldsTable">
						<xsl:call-template name="Output-Limit">
							<xsl:with-param name="Limit" select="hc:Amperage"/>
						</xsl:call-template>
					</td>
					</tr>
				</xsl:if>
				<xsl:if test="hc:PowerDraw">
					<tr>
						<td>Power Draw</td>
					<td class="HoldsTable">
						<xsl:call-template name="Output-Limit">
							<xsl:with-param name="Limit" select="hc:PowerDraw"/>
						</xsl:call-template>
					</td>
					</tr>
				</xsl:if>
				<xsl:if test="hc:Connector">
					<tr>
						<td>Connector</td>
						<td>
							<xsl:value-of select="hc:Connector/@connectorID"/>
							<xsl:if test="hc:Connector/@pinID">
							[<xsl:value-of select="hc:Connector/@pinID"/>]
							</xsl:if>
						</td>
					</tr>
				</xsl:if>
				</table>
			</td>
		</tr>
	</xsl:template>
	<xsl:template name="Output-Limit">
		<xsl:param name="Limit"/>
		<table class="Embeded">
			<xsl:if test="$Limit/@name">
				<tr>
					<td><b><xsl:value-of select="$Limit/@name"/></b></td>
				</tr>
			</xsl:if>
			<xsl:if test="$Limit/c:Description">
				<tr>
					<td><i><xsl:value-of select="$Limit/c:Description"/></i></td>
				</tr>
			</xsl:if>
			<tr>
				<td class="SpecValue"><xsl:apply-templates select="$Limit/node()"/></td>
			</tr>
		</table>
	</xsl:template>
	<xsl:template match="hc:OperationalRequirements">
		<h1>Operational Requirements</h1>
		<table>
			<tr>
				<th class="Sub">Name</th>
				<th class="Sub">Value</th>
			</tr>
			<tr>
				<td>Warm-Up Time</td>
				<td>
					<xsl:value-of select="@warmUpTime"/>
				</td>
			</tr>
			<xsl:apply-templates select="node()"/>
		</table>
	</xsl:template>
	<xsl:template match="hc:OperationalRequirement">
		<tr>
			<td><xsl:value-of select="@name"/></td>
			<td>
				<xsl:call-template name="Output-Value">
					<xsl:with-param name="Node" select="."/>
				</xsl:call-template>
			</td>
		</tr>
	</xsl:template>
	<xsl:template match="hc:EnvironmentalRequirements">
		<h1>Environmental Requirements</h1>
		<table>
			<xsl:if test="c:Operation">
			<tr>
				<td>Operation</td>
				<td class="HoldsTable">
					<xsl:call-template name="Output-Environmental">
						<xsl:with-param name="Env" select="c:Operation"/>
					</xsl:call-template>
				</td>
			</tr>
			</xsl:if>
			<xsl:if test="c:StorageTransport">
			<tr>
				<td>Storage Transport</td>
				<td class="HoldsTable">
					<xsl:call-template name="Output-Environmental">
						<xsl:with-param name="Env" select="c:StorageTransport"/>
					</xsl:call-template>
				</td>
			</tr>
			</xsl:if>
		</table>
	</xsl:template>
	<xsl:template name="Output-Environmental">
		<xsl:param name="Env"/>
		<table class="Embeded">
			<xsl:if test="$Env/c:Altitude">
			<tr>
				<td>Altitude</td>
				<td class="HoldsTable">
					<xsl:call-template name="Output-Limit">
						<xsl:with-param name="Limit" select="$Env/c:Altitude"/>
					</xsl:call-template>
				</td>
			</tr>
			</xsl:if>
			<xsl:if test="$Env/c:Humidity">
			<tr>
				<td>Humidity</td>
				<td class="HoldsTable">
					<xsl:call-template name="Output-Limit">
						<xsl:with-param name="Limit" select="$Env/c:Humidity"/>
					</xsl:call-template>
				</td>
			</tr>
			</xsl:if>
			<xsl:if test="$Env/c:Shock">
			<tr>
				<td>Shock</td>
				<td class="HoldsTable">
					<xsl:call-template name="Output-Limit">
						<xsl:with-param name="Limit" select="$Env/c:Shock"/>
					</xsl:call-template>
				</td>
			</tr>
			</xsl:if>
			<xsl:if test="$Env/c:Temperature">
			<tr>
				<td>Temperature</td>
				<td class="HoldsTable">
					<xsl:call-template name="Output-Limit">
						<xsl:with-param name="Limit" select="$Env/c:Temperature"/>
					</xsl:call-template>
				</td>
			</tr>
			</xsl:if>
			<xsl:if test="$Env/c:Vibration">
			<tr>
				<td>Vibration</td>
				<td class="HoldsTable">
					<xsl:call-template name="Output-Limit">
						<xsl:with-param name="Limit" select="$Env/c:Vibration"/>
					</xsl:call-template>
				</td>
			</tr>
			</xsl:if>
		</table>
	</xsl:template>
	<xsl:template match="hc:PhysicalCharacteristics">
		<h1>Physical Characteristics</h1>
		<table>
			<tr>
				<td>Mass</td>
				<td>
					<xsl:value-of select="hc:Mass/@value"/>
					<xsl:call-template name="Just-a-Space"/>
					<xsl:value-of select="hc:Mass/@standardUnit"/>
				</td>
			</tr>
			<tr>
				<td>Volume</td>
				<td>
					<xsl:value-of select="hc:Volume/@value"/> 
					<xsl:call-template name="Just-a-Space"/>
					<xsl:value-of select="hc:Volume/@standardUnit"/>
				</td>
			</tr>
			<tr>
				<td>Height</td>
				<td>
					<xsl:value-of select="hc:LinearMeasurements/hc:Height/@value"/>
					<xsl:call-template name="Just-a-Space"/>
					<xsl:value-of select="hc:LinearMeasurements/hc:Height/@standardUnit"/>
				</td>
			</tr>
			<tr>
				<td>Width</td>
				<td>
					<xsl:value-of select="hc:LinearMeasurements/hc:Width/@value"/>
					<xsl:call-template name="Just-a-Space"/>
					<xsl:value-of select="hc:LinearMeasurements/hc:Width/@standardUnit"/>
				</td>
			</tr>
			<tr>
				<td>Depth</td>
				<td>
					<xsl:value-of select="hc:LinearMeasurements/hc:Depth/@value"/>
					<xsl:call-template name="Just-a-Space"/>
					<xsl:value-of select="hc:LinearMeasurements/hc:Depth/@standardUnit"/>
				</td>
			</tr>
			<tr>
				<td>RackUSize</td>
				<td>
					<xsl:value-of select="hc:LinearMeasurements/hc:RackUSize/@value"/>
					<xsl:call-template name="Just-a-Space"/>
					<xsl:value-of select="hc:LinearMeasurements/hc:RackUSize/@standardUnit"/>
				</td>
			</tr>
		</table>
		<p/>
	</xsl:template>
	<xsl:template match="inst:Specifications">
		<h1>Specifications</h1>
		<table>
			<tr>
				<td class="HoldsTable">
					<table class="Embeded">
						<xsl:apply-templates select="node()"/>
					</table>
				</td>
			</tr>
		</table>
		<p/>
	</xsl:template>
	<xsl:template match="hc:Specification">
		<tr>
			<td class="SpecValue">
				<xsl:value-of select="@name"/>
			</td>
			<td class="SpecValue">
				<xsl:choose>
					<xsl:when test="@xsi:type='hc:Guaranteed'">Guaranteed</xsl:when>
					<xsl:when test="@xsi:type='hc:Typical'">Typical</xsl:when>
					<xsl:when test="@xsi:type='hc:Nominal'">Nominal</xsl:when>
					<xsl:when test="@xsi:type='hc:Characteristic'">Characteristic</xsl:when>
					<xsl:when test="@xsi:type='hc:Feature'">Feature</xsl:when>
					<xsl:otherwise>Something Chris made up</xsl:otherwise>
				</xsl:choose>
			</td>
			<td class="SpecValue">
				<xsl:value-of select="hc:Description"/>
			</td>
			<xsl:choose>
				<xsl:when test="./hc:Limits/hc:Limit">
				<td>
					<xsl:attribute name="class">
					<xsl:choose>
						<xsl:when test="./hc:Limits/hc:Limit/@name">ControlTable</xsl:when>
						<xsl:otherwise>SpecTable</xsl:otherwise>
					</xsl:choose>
					</xsl:attribute>
					<table class="Embeded">
						<xsl:if test="./hc:Limits/hc:Limit/@name">
							<tr>
								<td><b><xsl:value-of select="./hc:Limits/hc:Limit/@name"/></b></td>
							</tr>
						</xsl:if>
						<xsl:for-each select="./hc:Limits/hc:Limit">
							<tr>
								<td class="SpecLimit">
									<xsl:call-template name="Output-Operator">
										<xsl:with-param name="OP" select="@operator"/>
									</xsl:call-template>
									<xsl:apply-templates select="node()"/>
								</td>
							</tr>
						</xsl:for-each>
					</table>
				</td>
				</xsl:when>
				<xsl:when test="hc:SupplementalInformation">
				<td class="SpecValue">
					<xsl:value-of select="hc:SupplementalInformation"/>
				</td>
				</xsl:when>
				<xsl:otherwise>
					<td class="SpecNoValue">None</td>
				</xsl:otherwise>
			</xsl:choose>
		</tr>
	</xsl:template>
	<xsl:template name="Just-a-Space">
		<xsl:value-of select="$ASpace"/>
	</xsl:template>
	<xsl:template name="Output-Value">
		<xsl:param name="Node"/>
		<xsl:if test="$Node/c:Datum/@value">
			<xsl:value-of select="$Node/c:Datum/@value"/>
		</xsl:if>
		<xsl:if test="$Node/c:Datum/c:Value">
			<xsl:value-of select="$Node/c:Datum/c:Value"/>
		</xsl:if>
		<xsl:if test="$Node/c:Datum/@standardUnit">
			<xsl:call-template name="Just-a-Space"/>
			<xsl:value-of select="$Node/c:Datum/@standardUnit"/>
		</xsl:if>
		<xsl:if test="$Node/c:Datum/@unitQualifier">
			<xsl:call-template name="Just-a-Space"/>
			<xsl:value-of select="$Node/c:Datum/@unitQualifier"/>
		</xsl:if>
	</xsl:template>
	<xsl:template name="Output-Operator">
		<xsl:param name="OP"/>
		<xsl:choose>
			<xsl:when test="$OP='OR'"> OR </xsl:when>
			<xsl:when test="$OP='XOR'"> XOR </xsl:when>
			<xsl:when test="$OP='AND'"> AND </xsl:when>
			<xsl:when test="$OP='EQ'"> = </xsl:when>
			<xsl:when test="$OP='NE'"> != </xsl:when>
			<xsl:when test="$OP='GT'"> > </xsl:when>
			<xsl:when test="$OP='GE'"> >= </xsl:when>
			<xsl:when test="$OP='LT'"> &#60; </xsl:when>
			<xsl:when test="$OP='LE'"> &#60;= </xsl:when>
		</xsl:choose>
	</xsl:template>
	<xsl:template match="c:Expected">
		<xsl:call-template name="Output-Operator">
			<xsl:with-param name="OP" select="@comparator"/>
		</xsl:call-template>
		<xsl:call-template name="Output-Value">
			<xsl:with-param name="Node" select="."/>
		</xsl:call-template>
	</xsl:template>
	<xsl:template match="c:SingleLimit">
		<xsl:call-template name="Output-Operator">
			<xsl:with-param name="OP" select="@comparator"/>
		</xsl:call-template>
		<xsl:call-template name="Output-Value">
			<xsl:with-param name="Node" select="."/>
		</xsl:call-template>
	</xsl:template>
	<xsl:template match="c:LimitPair">
		<xsl:call-template name="Output-Operator">
			<xsl:with-param name="OP" select="c:Limit[1]/@comparator"/>
		</xsl:call-template>
		<xsl:call-template name="Output-Value">
			<xsl:with-param name="Node" select="c:Limit[1]"/>
		</xsl:call-template>
		<xsl:call-template name="Output-Operator">
			<xsl:with-param name="OP" select="@operator"/>
		</xsl:call-template>
		<xsl:call-template name="Output-Operator">
			<xsl:with-param name="OP" select="c:Limit[2]/@comparator"/>
		</xsl:call-template>
		<xsl:call-template name="Output-Value">
			<xsl:with-param name="Node" select="c:Limit[2]"/>
		</xsl:call-template>
		<xsl:if test="c:Nominal">
			(Nominal: <xsl:call-template name="Just-a-Space"/>
			<xsl:call-template name="Output-Value">
				<xsl:with-param name="Node" select="c:Nominal"/>
			</xsl:call-template>)
		</xsl:if>
	</xsl:template>
	<xsl:template match="c:Mask">
		<xsl:call-template name="Output-Value">
			<xsl:with-param name="Node" select="c:Expected"/>
		</xsl:call-template>
		<xsl:call-template name="Output-Operator">
			<xsl:with-param name="OP" select="c:Mask/@operation"/>
		</xsl:call-template>
		<xsl:call-template name="Output-Value">
			<xsl:with-param name="Node" select="c:Mask"/>
		</xsl:call-template>
	</xsl:template>
	<xsl:template match="hc:Group">
		<tr>
			<td>
				<xsl:value-of select="@name"/>
			</td>
			<td class="HoldsTable" colspan="4">
				<table class="Embeded">
					<tr>
						<td>
							<xsl:value-of select="hc:Description"/>
						</td>
					</tr>
					<tr>
						<td class="HoldsTable">
							<table class="Embeded">
								<xsl:apply-templates select="node()"/>
							</table>
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</xsl:template>
	<xsl:template match="hc:Description">
	</xsl:template>
	<xsl:template match="c:Description">
	</xsl:template>
	<xsl:template match="hc:Control">
		<h1>Control</h1>
		<xsl:apply-templates select="node()"/>
	</xsl:template>
	<xsl:template match="hc:Drivers">
		<h2>Drivers</h2>
		<xsl:apply-templates select="node()"/>
	</xsl:template>
	<xsl:template match="hc:Type">
		<tr>
			<td>File Name</td>
			<td><xsl:value-of select="@fileName"/></td>
		</tr>
		<tr>
			<td>File Path</td>
			<td><xsl:value-of select="@filePath"/></td>
		</tr>
		<xsl:choose>
			<xsl:when test="@xsi:type='hc:VPP'">
			<tr>
				<td>Type</td>
				<td>VPP</td>
			</tr>
			<tr>
				<td>Prefix</td>
				<td><xsl:value-of select="@prefix"/></td>
			</tr>
			</xsl:when>
			<xsl:when test="@xsi:type='hc:IVI-C'">
			<tr>
				<td>Type</td>
				<td>IVI-C</td>
			</tr>
			<tr>
				<td>Prefix</td>
				<td><xsl:value-of select="@prefix"/></td>
			</tr>
			<xsl:if test="hc:Class">
			<tr>
				<td>Class</td>
				<td class="HoldsTable">
					<table class="Embeded">
					<xsl:for-each select="hc:Class">
						<tr>
							<td><xsl:value-of select="."/></td>
						</tr>
					</xsl:for-each>
					</table>
				</td>
			</tr>
			</xsl:if>
			<xsl:if test="hc:ComplianceDocument">
			<tr>
				<td>Compliance Document</td>
				<td class="HoldsTable">
					<table class="Embeded">
						<tr>
							<td>Name</td>
							<td><xsl:value-of select="hc:ComplianceDocument/@name"/></td>
						</tr>
						<tr>
							<td>UUID</td>
							<td><xsl:value-of select="hc:ComplianceDocument/@uuid"/></td>
						</tr>
						<xsl:if test="hc:ComplianceDocument/c:URL">
						<tr>
							<td>URL</td>
							<td><xsl:value-of select="hc:ComplianceDocument/c:URL"/></td>
						</tr>
						</xsl:if>
						<xsl:if test="hc:ComplianceDocument/c:Text">
						<tr>
							<td>Text</td>
							<td><xsl:value-of select="hc:ComplianceDocument/c:Text"/></td>
						</tr>
						</xsl:if>
					</table>
				</td>
			</tr>
			</xsl:if>
			</xsl:when>
			<xsl:when test="@xsi:type='hc:IVI-COM'">
			<tr>
				<td>Type</td>
				<td>IVI-COM</td>
			</tr>
			<tr>
				<td>ProgID</td>
				<td><xsl:value-of select="@progId"/></td>
			</tr>
			<xsl:if test="hc:Class">
			<tr>
				<td>Class</td>
				<td class="HoldsTable">
					<table class="Embeded">
					<xsl:for-each select="hc:Class">
						<tr>
							<td><xsl:value-of select="."/></td>
						</tr>
					</xsl:for-each>
					</table>
				</td>
			</tr>
			</xsl:if>
			<xsl:if test="hc:ComplianceDocument">
			<tr>
				<td>Compliance Document</td>
				<td class="HoldsTable">
					<table class="Embeded">
						<tr>
							<td>Name</td>
							<td><xsl:value-of select="hc:ComplianceDocument/@name"/></td>
						</tr>
						<tr>
							<td>UUID</td>
							<td><xsl:value-of select="hc:ComplianceDocument/@uuid"/></td>
						</tr>
						<xsl:if test="hc:ComplianceDocument/c:URL">
						<tr>
							<td>URL</td>
							<td><xsl:value-of select="hc:ComplianceDocument/c:URL"/></td>
						</tr>
						</xsl:if>
						<xsl:if test="hc:ComplianceDocument/c:Text">
						<tr>
							<td>Text</td>
							<td><xsl:value-of select="hc:ComplianceDocument/c:Text"/></td>
						</tr>
						</xsl:if>
					</table>
				</td>
			</tr>
			</xsl:if>
			</xsl:when>
			<xsl:otherwise>
			<tr>
				<td>Type</td>
				<td><xsl:value-of select="@xsi:type"/></td>
			</tr>
			</xsl:otherwise>
		</xsl:choose>	
	</xsl:template>
	<xsl:template match="hc:Driver">
		<h3><xsl:value-of select="@name"/></h3>
		<table>
			<tr>
				<th class="Sub">Version</th>
				<td>
					<xsl:value-of select="@qualifier"/>
					<xsl:call-template name="Just-a-Space"/>
					<xsl:value-of select="@version"/>
				</td>
			</tr>
			<tr>
				<th class="Sub">Type</th>
				<td class="HoldsTable">
					<xsl:if test="hc:Type">
					<table class="Embeded">
						<xsl:apply-templates select="node()"/>
					</table>
					</xsl:if>
				</td>
			</tr>
			<tr>
				<th class="Sub">Platform</th>
				<td>
					<xsl:value-of select="hc:Platform/hc:OperatingSystem/@name"/>
					<xsl:call-template name="Just-a-Space"/>
					<xsl:value-of select="hc:Platform/hc:OperatingSystem/@qualifier"/>
					<xsl:call-template name="Just-a-Space"/>
					<xsl:value-of select="hc:Platform/hc:OperatingSystem/@version"/>
				</td>
			</tr>
			
		</table>
	</xsl:template>
	<xsl:template match="inst:Buses">
		<h1>Buses</h1>
		<table>
			<tr>
				<th class="Sub">Type</th>
				<th class="Sub">Default Address</th>
				<th class="Sub">Additional Info</th>
			</tr>
		<xsl:apply-templates select="node()"/>
		</table>
	</xsl:template>
	<xsl:template match="inst:Bus">
		<tr>
			<td><xsl:value-of select="@xsi:type"/></td>
			<td><xsl:value-of select="@defaultAddress"/></td>
			<xsl:choose>
				<xsl:when test="@xsi:type='inst:VXI'">
				<td class="HoldsTable">
					<table class="Embeded">
						<tr>
							<td>Address Space</td>
							<td><xsl:value-of select="@addressSpace"/></td>
						</tr>
						<tr>
							<td>Device Category</td>
							<td><xsl:value-of select="@deviceCategory"/></td>
						</tr>
						<tr>
							<td>Dynamically Configured</td>
							<td><xsl:value-of select="@dynamicallyConfigured"/></td>
						</tr>
						<tr>
							<td>Interrupt Lines</td>
							<td><xsl:value-of select="@interruptLines"/></td>
						</tr>
						<tr>
							<td>Manufacturer ID</td>
							<td><xsl:value-of select="@manufacturerID"/></td>
						</tr>
						<tr>
							<td>Model Code</td>
							<td><xsl:value-of select="@modelCode"/></td>
						</tr>
						<tr>
							<td>Required Memory</td>
							<td><xsl:value-of select="@requiredMemory"/></td>
						</tr>
						<tr>
							<td>Slot Size</td>
							<td><xsl:value-of select="@slotSize"/></td>
						</tr>
						<tr>
							<td>Slot Weight</td>
							<td><xsl:value-of select="@slotWeight"/></td>
						</tr>
						<tr>
							<td>Slots</td>
							<td><xsl:value-of select="@slots"/></td>
						</tr>
						
					</table>
				</td>
				</xsl:when>
				<xsl:when test="@xsi:type='inst:Ethernet'">
				<td class="HoldsTable">
					<table class="Embeded">
						<tr>
							<td>Supports DHCP</td>
							<td><xsl:value-of select="@supportsDHCP"/></td>
						</tr>
					</table>
				</td>
				</xsl:when>
				<xsl:when test="@xsi:type='inst:USB'">
				<td class="HoldsTable">
					<table class="Embeded">
						<tr>
							<td>Version</td>
							<td>
								<xsl:value-of select="inst:Version/@qualifier"/>
								<xsl:call-template name="Just-a-Space"/>
								<xsl:value-of select="inst:Version/@version"/>
							</td>
						</tr>
					</table>
				</td>
				</xsl:when>
				<xsl:when test="@xsi:type='inst:LXI'">
				<td class="HoldsTable">
					<table class="Embeded">
						<tr>
							<td>Supports DHCP</td>
							<td><xsl:value-of select="@supportsDHCP"/></td>
						</tr>
						<tr>
							<td>LXI Version</td>
							<td><xsl:value-of select="@LXIVersion"/></td>
						</tr>
						<tr>
							<td>Class</td>
							<td><xsl:value-of select="@class"/></td>
						</tr>
					</table>
				</td>
				</xsl:when>
				<xsl:when test="@xsi:type='inst:PCI'">
				<td class="HoldsTable">
					<table class="Embeded">
						<tr>
							<td>Manufacturer ID</td>
							<td><xsl:value-of select="@manufacturerID"/></td>
						</tr>
					</table>
				</td>
				</xsl:when>
				<xsl:when test="@xsi:type='inst:PCIExpress'">
				<td class="HoldsTable">
					<table class="Embeded">
						<tr>
							<td>Manufacturer ID</td>
							<td><xsl:value-of select="@manufacturerID"/></td>
						</tr>
					</table>
				</td>
				</xsl:when>
				<xsl:otherwise><td/></xsl:otherwise>
			</xsl:choose>
		</tr>
	</xsl:template>
</xsl:stylesheet>
