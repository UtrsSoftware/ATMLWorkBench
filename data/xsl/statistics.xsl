<xsl:stylesheet version="1.0"
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
        >



    <xsl:template match="/">



        <html>

            <head>
                <meta content="text/html; charset=ISO-8859-1" http-equiv="content-type"/>
                <title>
                    <xsl:value-of select="/test-set/application"/>
                </title>
                <style>
                    body { font-family: sans-serif; }
                    h1 { font-size: 14pt; }
                    h2 { font-size: 12pt; margin-bottom:5px; }
                    h3 { font-size: 10pt; margin-bottom:5px; }
                    table { font-size: 10pt; margin-left: 0px; border: 1px solid black; width:400px; }
                    table td {padding:3px; font-size:10px;}
                    table th {padding:3px;}
                    .header { background-color: lightblue; }
                    .count {text-align:right;}
                    .section { padding-left:20px; float:left; margin-bottom:20px;}
                    .odd { background: #ffffdd; }
                    .even { background: #ddffdd; }
                    .underline{ border-bottom:1pt solid black; }
                    .attribute-table { background-color: white; margin-right:10px; }
                    .page-header{ inline-block; float:right;  vertical-align: top; }
                    .columns {
                    -webkit-column-count: 4; /* Chrome, Safari, Opera */
                    -moz-column-count: 4; /* Firefox */
                    column-count: 4;
                    -webkit-column-gap: 40px; /* Chrome, Safari, Opera */
                    -moz-column-gap: 40px; /* Firefox */
                    column-gap: 40px;
                    -webkit-column-rule-style: solid; /* Chrome, Safari, Opera */
                    -moz-column-rule-style: solid; /* Firefox */
                    column-rule-style: solid;
                    -webkit-column-rule-width: 1px; /* Chrome, Safari, Opera */
                    -moz-column-rule-width: 1px; /* Firefox */
                    column-rule-width: 1px;
                    }
                </style>
            </head>

            <body>
                <h1>ATLAS Statistics</h1>
                <div class="section">
                    <h2>Source Files - <xsl:value-of select="/atlas/source_files/@count" /></h2>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr class="header" ><th>File Name</th></tr>
                        <xsl:for-each select="/atlas/source_files/*" >
                            <tr><td><xsl:value-of select="@name" /></td></tr>
                        </xsl:for-each>
                    </table>
                </div>
                <div class="section">
                    <h2>Signals - <xsl:value-of select="/atlas/signals/@count" /></h2>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr class="header" ><th>Name</th><th>Instance Count</th></tr>
                        <xsl:for-each select="/atlas/signals/*" >
                            <tr>
                                <td class="label" >
                                    <xsl:if test="name()='complex_signal'" >
                                        <xsl:value-of select="signal_name/@name" />(Complex)
                                    </xsl:if>
                                    <xsl:if test="name()='signal'" >
                                        <xsl:value-of select="signal_name/atlas/noun/@type" />
                                    </xsl:if>
                                </td>
                                <td class="count" ><xsl:value-of select="@count" /></td>
                            </tr>
                        </xsl:for-each>
                    </table>
                </div>
                <div class="section">
                    <h2>Built In Declares Used - <xsl:value-of select="/atlas/builtin_declares/@count" /></h2>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr class="header" ><th>Name</th></tr>
                        <xsl:for-each select="/atlas/builtin_declares/*" >
                            <tr>
                                <td class="label" ><xsl:value-of select="@name" /></td>
                            </tr>
                        </xsl:for-each>
                    </table>
                </div>
                <div class="section">
                    <h2>Declares Used - <xsl:value-of select="/atlas/declares/@count" /></h2>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr class="header" ><th>Name</th></tr>
                        <tr>
                            <td style="font-size:8px;">
                                <div class="columns">
                                    <xsl:for-each select="/atlas/declares/*" >
                                        <xsl:value-of select="@name" />
                                        <xsl:if test="not(position()=last())"><xsl:text>, </xsl:text></xsl:if>
                                    </xsl:for-each>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="section">
                    <h2>Signal Oriented Statements</h2>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr class="header" ><th>Statement</th><th>Count</th></tr>
                        <xsl:for-each select="//statistics/statements/statement[@signal_oriented='true']" >
                            <tr>
                                <td class="label" ><xsl:value-of select="./@name" /></td>
                                <td class="count" ><xsl:value-of select="./@count" /></td>
                            </tr>
                        </xsl:for-each>
                    </table>
                </div>
                <div class="section">
                    <h2>Statements</h2>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr class="header" ><th>Statement</th><th>Count</th></tr>
                        <xsl:for-each select="//statistics/statements/statement[not(@signal_oriented)]" >
                            <tr>
                                <td class="label" ><xsl:value-of select="./@name" /></td>
                                <td class="count" ><xsl:value-of select="./@count" /></td>
                            </tr>
                        </xsl:for-each>
                    </table>
                </div>
                <xsl:if test="/atlas/ipl_blocks/@count>0" >
                    <div class="section">
                        <h2>IPL Blocks - <xsl:value-of select="/atlas/ipl_blocks/@count" /></h2>
                        <xsl:for-each select="//atlas/ipl_blocks/ipl_block" >
                            <h3>IPL Block <xsl:value-of select="position()" /></h3>
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr class="header" ><th>IPL</th></tr>
                                <xsl:for-each select="./ipls/ipl" >
                                    <tr>
                                        <td class="label" ><xsl:value-of select="text()" /></td>
                                    </tr>
                                </xsl:for-each>
                            </table>
                        </xsl:for-each>
                    </div>
                </xsl:if>
                <div class="section">
                    <h2>Signal Mapping</h2>
                    <table cellpadding="0" cellspacing="0">
                        <tr class="header" ><th>Source</th><th>Target</th></tr>
                        <xsl:for-each select="//signal-mapping/signal" >
                            <xsl:variable name="css-class">
                                <xsl:choose>
                                    <xsl:when test="position() mod 2 = 0">even</xsl:when>
                                    <xsl:otherwise>odd</xsl:otherwise>
                                </xsl:choose>
                            </xsl:variable>
                            <tr class="{$css-class}" >
                                <td class="underline" valign="top" ><strong><xsl:value-of select="./@sourceName" /></strong></td>
                                <td class="underline" valign="top" ><strong><xsl:value-of select="./@targetType" />:
                                    <xsl:choose>
                                        <xsl:when test="./@targetName=''" >
                                            <span style="color:red;">[MISSING]</span>
                                        </xsl:when>
                                        <xsl:otherwise>
                                            <xsl:value-of select="./@targetName" />
                                        </xsl:otherwise>
                                    </xsl:choose>
                                </strong><br/><br/>
                                    <strong>Attributes</strong><br/>
                                    <table class="attribute-table" cellspacing="0" >
                                        <tr class="header" ><th>Source</th><th>Target</th></tr>
                                        <xsl:for-each select="attribute" >
                                            <tr>
                                                <td class="label" ><xsl:value-of select="./@sourceName" /></td>
                                                <td class="label" >
                                                    <xsl:choose>
                                                        <xsl:when test="./@targetName=''" >
                                                            <span style="color:red;">[MISSING]</span>
                                                        </xsl:when>
                                                        <xsl:otherwise>
                                                            <xsl:value-of select="./@targetName" />
                                                        </xsl:otherwise>
                                                    </xsl:choose>
                                                </td>
                                            </tr>
                                        </xsl:for-each>
                                    </table>
                                    <br/>
                                </td>
                            </tr>
                        </xsl:for-each>
                    </table>
                </div>
            </body>
        </html>



    </xsl:template>

</xsl:stylesheet>