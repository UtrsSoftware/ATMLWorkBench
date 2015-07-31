<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/">

        <html>
            <head>
                <meta content="text/html; charset=ISO-8859-1" http-equiv="content-type"/>
                <title>
                    <xsl:value-of select="/test-set/application"/>
                </title>
                <style>
                    body
                    {
                    font-family: sans-serif;
                    }
                    ol li
                    {
                    padding-bottom: 10px;
                    margin-bottom: 5px;
                    }
                </style>
            </head>
            <body>
                <form>
                    <h1>
                        <xsl:value-of select="/test-set/application"/>
                    </h1>
                    <xsl:value-of select="/test-set/narrative"/>
                    <h2>Equipment</h2>
                    <ul>
                        <xsl:for-each select="/test-set/equipment/item">
                            <li>
                                <xsl:value-of select="text()"/>
                                <xsl:if test="example">
                                    <ul>
                                        <xsl:for-each select="example">
                                            <li>
                                                <xsl:value-of select="text()"/>
                                            </li>
                                        </xsl:for-each>
                                    </ul>
                                </xsl:if>
                            </li>
                        </xsl:for-each>
                    </ul>
                    <h2>Procedures</h2>
                    <xsl:for-each select="/test-set/procedures/procedure">
                        <xsl:variable name="procId" select="@id"/>
                        <h3>
                            <xsl:value-of select="title/text()"/>
                        </h3>
                        <ol>
                            <xsl:for-each select="steps/step">
                                <xsl:variable name="stepId" select="@id"/>
                                <li>
                                    <xsl:value-of select="text()"/>
                                    <xsl:if test="confirm">
                                        <div style="margin-left: 40px; padding-top:10px;  padding-bottom:15px; ">
                                            <table style="text-align: left; width: 100%;" border="1"
                                                   cellpadding="2" cellspacing="2">
                                                <tbody>
                                                    <xsl:for-each select="confirm">
																												<xsl:variable name="hasResult" select="not(result/@accepted='')"/>
																												<xsl:variable name="accepted" select="result/@accepted='passed'"/>
																												<xsl:variable name="failed" select="result/@accepted='failed'"/>
                                                        <xsl:variable name="confId" select="@id"/>
                                                        <xsl:variable name="rowId" select="concat('tr_',$confId )"/>
                                                        <tr>
                                                            <xsl:attribute name="id">
                                                                <xsl:value-of select="$rowId"/>
                                                            </xsl:attribute>
																														<xsl:attribute name="style">
																															<xsl:if test="$accepted" >background-color: #9f9; color: #000;</xsl:if>
																															<xsl:if test="$failed" >background-color: #f00; color: #ff0;</xsl:if>
                                                            </xsl:attribute>
                                                            <td width="600">
                                                                <xsl:value-of select="text()"/>
                                                            </td>
                                                            <td width="200">
                                                                <xsl:element name="input">
                                                                    <xsl:attribute name="name">accepted:<xsl:value-of
                                                                            select="$confId"/>
                                                                    </xsl:attribute>
                                                                    <xsl:attribute name="value">passed</xsl:attribute>
                                                                    <xsl:attribute name="type">radio</xsl:attribute>
                                                                    <xsl:attribute name="onclick">setBkColor(
                                                                        '<xsl:value-of select="$rowId"/>', '#000',
                                                                        '#9f9' );
                                                                    </xsl:attribute>
																																		<xsl:if test="$accepted" >
																																			<xsl:attribute name="checked" >checked</xsl:attribute>
																																		</xsl:if>
                                                                </xsl:element>
                                                                <xsl:text>Passed</xsl:text>

                                                                <xsl:element name="input">
                                                                    <xsl:attribute name="name">accepted:<xsl:value-of
                                                                            select="$confId"/>
                                                                    </xsl:attribute>
                                                                    <xsl:attribute name="value">failed</xsl:attribute>
                                                                    <xsl:attribute name="type">radio</xsl:attribute>
                                                                    <xsl:attribute name="onclick">setBkColor(
                                                                        '<xsl:value-of select="$rowId"/>', '#ff0',
                                                                        '#f00' );
                                                                    </xsl:attribute>
																																		<xsl:if test="$failed" >
																																			<xsl:attribute name="checked" >checked</xsl:attribute>
																																		</xsl:if>
                                                                </xsl:element>
                                                                <xsl:text>Failed</xsl:text>
                                                            </td>
                                                            <td>
                                                                <xsl:element name="textarea">
                                                                    <xsl:attribute name="cols">50</xsl:attribute>
                                                                    <xsl:attribute name="rows">1</xsl:attribute>
                                                                    <xsl:attribute name="name">text:<xsl:value-of
                                                                            select="$confId"/>
                                                                    </xsl:attribute>
																																		<xsl:value-of select="result/text()" />
                                                                </xsl:element>
                                                            </td>
                                                        </tr>
                                                    </xsl:for-each>
                                                </tbody>
                                            </table>
                                        </div>
                                    </xsl:if>
                                </li>
                            </xsl:for-each>
                        </ol>
                    </xsl:for-each>
                    <input type="submit" value="Submit"/>
                </form>
            </body>

            <script>
                function setBkColor( controlId, color, bgColor )
                {
                    var control = document.getElementById(controlId);
                    if( control != null )
                    {
                        control.style.backgroundColor = bgColor;
                        control.style.color = color;
                    }
                }

            </script>
        </html>

    </xsl:template>

</xsl:stylesheet>