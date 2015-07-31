<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
		<xsl:output doctype-public="HTML" doctype-system=""/>
    <xsl:template match="/atlas/procedure_call_hierarchy">
				

        <html>
            <head>
                <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
                <title></title>
                <script type="text/javascript"
                        src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.2/jquery.min.js"></script>
                <style>

                    body {
                    background:white;
                    font:normal normal 13px/1.4 Segoe,"Segoe UI",Calibri,Helmet,FreeSans,Sans-Serif;
                    padding:50px;
                    }

                    .tree,
                    .tree ul {
                    margin:0;
                    padding:0;
                    list-style:none;
                    }

                    .tree ul {
                    margin-left:1em; /* indentation */
                    position:relative;
                    }

                    .tree ul ul {margin-left:.5em} /* (indentation/2) */

                    .tree ul:before {
                    content:"";
                    display:block;
                    width:0;
                    position:absolute;
                    top:0;
                    bottom:0;
                    left:0;
                    border-left:1px solid;
                    }

                    .tree li {
                    margin:0;
                    padding:0 1.5em; /* indentation + .5em */
                    line-height:2em; /* default list item's `line-height` */
                    color:#369;
                    font-weight:bold;
                    position:relative;
                    }

                    .tree ul li:before {
                    content:"";
                    display:block;
                    width:10px; /* same with indentation */
                    height:0;
                    border-top:1px solid;
                    margin-top:-1px; /* border top width */
                    position:absolute;
                    top:1em; /* (line-height/2) */
                    left:0;
                    }

                    .tree ul li:last-child:before {
                    background:white; /* same with body background */
                    height:auto;
                    top:1em; /* (line-height/2) */
                    bottom:0;
                    }

                </style>
            </head>
            <h1>Program Flow For TPS:
                <xsl:value-of select="/atlas/@program_name"/>
            </h1>
            <ul class="tree">
                <xsl:for-each select="./perform">
                    <xsl:call-template name="perform"/>
                </xsl:for-each>
            </ul>

        </html>
    </xsl:template>

    <xsl:template name="perform">
        <li>
            <xsl:value-of select="@name"/>
            <xsl:if test="./parameters/parameter"><span style="font: 10px arial; color:blue;">
                (
                <xsl:for-each select="./parameters/parameter">
									<xsl:if test="@value" >
                    <xsl:value-of select="@value"/>
									</xsl:if>	
									<xsl:if test="@variable_name" >
                    <xsl:value-of select="@variable_name"/>
									</xsl:if>	
									<xsl:if test="not(position() = last())" >
									,
									</xsl:if>	
                </xsl:for-each>
                )</span>
            </xsl:if>
            <xsl:if test="./perform">
                <ul>
                    <xsl:for-each select="./perform">
                        <xsl:call-template name="perform"/>
                    </xsl:for-each>
                </ul>
            </xsl:if>
        </li>

    </xsl:template>

</xsl:stylesheet>