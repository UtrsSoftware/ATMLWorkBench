<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/">
        <html>
            <head>
                <style type="text/css">
                    body{
                    font-family: verdana;
                    background: #3D578C;
                    }

                    ul{
                    list-style-type: none;
                    }

                    h1{
                    text-align: center;
                    }

                    h3{
                    padding-bottom: 0px;
                    margin-bottom: 5px;
                    }

                    h4{
                    padding-bottom: 0px;
                    margin-bottom: 5px;
                    }

                    p{
                        margin-top: 0px;
                    }

                    .actor_name{
                    font-weight: bold;
                    }
                    .actor_title{
                    font-style: italic;
                    }

                    #actors ul{
                    margin-bottom: 15px;
                    font-style: normal;
                    list-style-type: none;
                    font-size: small;
                    }

                    #responsibilities ul{
                    margin-bottom: 15px;
                    font-style: normal;
                    font-size: smaller;
                    }

                    #responsibilities span{
                    font-style: normal;
                    font-size: smaller;
                    }


                    #contributors{
                    }

                    #page{
                    width: 100%;
                    display: table;
                    margin: auto;
                    background: aliceblue;
                    padding-left: 10px;
                    padding-right: 10px;

                    }

                </style>
            </head>
            <body>
                <div id="page" >
                    <h1><xsl:value-of select="/about/product/title" /></h1>
                    <h3>Description</h3>
                    <p><xsl:value-of select="/about/product/description"  disable-output-escaping="yes" /></p>
                    <xsl:for-each select="/about/product/component">
                        <h4><xsl:value-of select="name" /></h4>
                        <p><xsl:value-of select="description"  disable-output-escaping="yes"  /></p>
                    </xsl:for-each>
                    <h3>License</h3>
                    <p><xsl:value-of select="/about/product/license" disable-output-escaping="yes" /></p>
                    <h3>Contributors</h3>
                    <marqueexx scrolldelay="60" scrollamount="2" height="100" width="100%" direction="up" >
                        <ul id="actors" >
                            <xsl:for-each select="/about/actors/actor" >
                                <li>
                                    <span class="actor_name"><xsl:value-of select="@name" /></span><br/>
                                    <span class="actor_title"><xsl:value-of select="@title" /></span>
                                    <ul id="responsibilities">
                                        <xsl:for-each select="responsibility" >
                                            <li><span><xsl:value-of select="text()" /></span></li>
                                        </xsl:for-each>
                                    </ul>
                                </li>
                            </xsl:for-each>
                        </ul>
                    </marqueexx>
                    <h3>Libraries</h3>
                    <marqueexx scrolldelay="60" scrollamount="2" height="100" width="100%" direction="up" >
                        <ul id="libraries" >
                            <xsl:for-each select="/about/libraries/library" >
                                <li><span class="library"><strong><xsl:value-of select="name" /></strong>
                                    <p><xsl:value-of select="description" disable-output-escaping="yes" /></p></span>
																		<strong>License</strong><br/>
																		<p><xsl:value-of select="license" disable-output-escaping="yes" /></p>
                                </li>
                            </xsl:for-each>
                        </ul>
                    </marqueexx>
                </div>
            </body>
        </html>
    </xsl:template>

</xsl:stylesheet>