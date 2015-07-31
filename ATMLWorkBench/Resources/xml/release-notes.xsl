<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/">
        <html>
            <head>
                <style type="text/css">
                    body{
                    font-family: verdana;
                    background: cornsilk;
                    }
                </style>
            </head>
            <body>
                <h2>ATML Workbench - Release Notes</h2>
                <xsl:for-each select="//release-notes/release" >
                    <h3>Version: <xsl:value-of select="version"/> (<xsl:value-of select="date"/>)</h3>
                    <ul>
                        <xsl:for-each select="item" >
                            <li><xsl:value-of select="text()" disable-output-escaping="yes"/></li>
                        </xsl:for-each>
                    </ul>
                </xsl:for-each>
            </body>
        </html>

    </xsl:template>

</xsl:stylesheet>