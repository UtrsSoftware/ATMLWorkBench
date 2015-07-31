<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/">
        <xsl:element name="procedures" >
        <xsl:for-each select="/atlas/program_structure/procedures/procedure" >
            <xsl:element name="procedure" >
                <xsl:variable name="commentId" select="@comment_refid"  />
                <xsl:attribute name="name" ><xsl:value-of select="@name" /></xsl:attribute>
                <xsl:element name="comment" >
                    <xsl:for-each select="/atlas/comments//comment[@id=$commentId]/line" >
                        <xsl:sort select="@line_number" />
                        <xsl:element name="line" xml:space="preserve">
                            <xsl:value-of select="text()" />
                        </xsl:element>
                    </xsl:for-each>
                </xsl:element>
            </xsl:element>
        </xsl:for-each>
        </xsl:element>
    </xsl:template>

</xsl:stylesheet>