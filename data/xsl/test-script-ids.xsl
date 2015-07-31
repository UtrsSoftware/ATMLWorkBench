<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output encoding="utf8" omit-xml-declaration="yes" />
    <!-- This Style Sheet assigns ids to the test-script cml data file -->
    <xsl:template match="/">

        <test-set>
            <application>
                <xsl:value-of select="/test-set/application/text()"/>
            </application>
            <narrative>
                <xsl:value-of select="/test-set/narrative/text()"/>
            </narrative>
            <equipment>
                <xsl:for-each select="/test-set/equipment/item">
                    <item>
                        <xsl:value-of select="text()"/>
                        <xsl:for-each select="example">
                            <example>
                                <xsl:value-of select="text()"/>
                            </example>
                        </xsl:for-each>
                    </item>
                </xsl:for-each>
            </equipment>
            <procedures>
                <xsl:for-each select="/test-set/procedures/procedure">
                    <procedure>
                        <xsl:variable name="procId" select="concat('P', position())"/>
                        <xsl:attribute name="id">
                            <xsl:value-of select="$procId"/>
                        </xsl:attribute>
                        <title>
                            <xsl:value-of select="title/text()"/>
                        </title>
                        <steps>
                            <xsl:for-each select="steps/step">
                                <xsl:variable name="stepId" select="concat($procId, 'S', position())"/>
                                <step>
                                    <xsl:attribute name="id">
                                        <xsl:value-of select="$stepId"/>
                                    </xsl:attribute>
                                    <xsl:value-of select="text()"/>
                                    <xsl:for-each select="confirm">
                                        <xsl:variable name="confId" select="concat($stepId, 'C', position())"/>
                                        <confirm>
                                            <xsl:attribute name="id">
                                                <xsl:value-of select="$confId"/>
                                            </xsl:attribute>
                                            <result>
                                                <xsl:attribute name="id">RES-<xsl:value-of select="$confId"/>
                                                </xsl:attribute>
                                                <xsl:attribute name="accepted"></xsl:attribute>
                                            </result>
                                            <xsl:value-of select="text()"/>
                                        </confirm>
                                    </xsl:for-each>
                                </step>
                            </xsl:for-each>
                        </steps>
                    </procedure>
                </xsl:for-each>
            </procedures>
        </test-set>
    </xsl:template>
</xsl:stylesheet>