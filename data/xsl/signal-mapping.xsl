<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/">
        <signal-map source_type="ATLAS" model_library="CASS_ATLAS">
            <xsl:for-each select="/atlas/signal_oriented_verbs//signal_component">
                <xsl:sort select="atlas/noun/@type"/>
                <xsl:if test="@complex_signal='true'" >
                    <xsl:variable name="refid" select="@refid" />
                    <xsl:variable name="complex" select="//complex_signal[@id=$refid]" />
                    <xsl:element name="signal">
                        <xsl:attribute name="name">
                            <xsl:value-of select="$complex/signal_name/@name"/>
                        </xsl:attribute>
                        <xsl:for-each select="$complex/*/*/noun_modifiers/noun_modifier/signal_component/atlas/noun_modifier">
                            <xsl:sort select="@type"/>
                            <xsl:if test="@type">
                                <xsl:variable name="specifyType" select="../../../../../@specify_type" />
                                <xsl:element name="modifier">
                                    <xsl:attribute name="name">
                                        <xsl:value-of select="$specifyType"/>_<xsl:value-of select="@type"/>
                                    </xsl:attribute>
                                    <xsl:if test="@suffix">
                                        <xsl:attribute name="suffix">
                                            <xsl:value-of select="@suffix"/>
                                        </xsl:attribute>
                                    </xsl:if>
                                    <xsl:attribute name="tsf_attribute">
                                        <xsl:value-of select="../../ieee_1641/attribute/@type"/>
                                    </xsl:attribute>
                                    <xsl:if test="@suffix">
                                        <xsl:attribute name="tsf_qualifier">
                                            <xsl:choose>
                                                <xsl:when test="@suffix='TRMS'">trms</xsl:when>
                                                <xsl:when test="@suffix='PP'">pk_pk</xsl:when>
                                                <xsl:when test="@suffix='P'">pk</xsl:when>
                                                <xsl:when test="@suffix='AV'">av</xsl:when>
                                                <xsl:when test="@suffix='P-POS'">pk_pos</xsl:when>
                                                <xsl:when test="@suffix='P-NEG'">pk_neg</xsl:when>
                                                <xsl:when test="@suffix='INST'">inst</xsl:when>
                                            </xsl:choose>
                                        </xsl:attribute>
                                    </xsl:if>
                                </xsl:element>
                            </xsl:if>
                        </xsl:for-each>
                    </xsl:element>
                </xsl:if>
                <xsl:if test="../noun_modifiers/noun_modifier/signal_component/atlas/noun_modifier" >
                    <xsl:element name="signal">
                        <xsl:attribute name="name">
                            <xsl:value-of select="atlas/noun/@type"/>
                        </xsl:attribute>
                        <xsl:attribute name="tsf">
                            <xsl:value-of select="ieee_1641/tsf/@type"/>
                        </xsl:attribute>
                        <xsl:for-each select="../noun_modifiers/noun_modifier/signal_component/atlas/noun_modifier">
                            <xsl:sort select="@type"/>
                            <xsl:if test="@type">
                                <xsl:element name="modifier">
                                    <xsl:attribute name="name">
                                        <xsl:value-of select="@type"/>
                                    </xsl:attribute>
                                    <xsl:if test="@suffix">
                                        <xsl:attribute name="suffix">
                                            <xsl:value-of select="@suffix"/>
                                        </xsl:attribute>
                                    </xsl:if>
                                    <xsl:attribute name="tsf_attribute">
                                        <xsl:value-of select="../../ieee_1641/attribute/@type"/>
                                    </xsl:attribute>
                                    <xsl:if test="@suffix">
                                        <xsl:attribute name="tsf_qualifier">
                                            <xsl:choose>
                                                <xsl:when test="@suffix='TRMS'">trms</xsl:when>
                                                <xsl:when test="@suffix='PP'">pk_pk</xsl:when>
                                                <xsl:when test="@suffix='P'">pk</xsl:when>
                                                <xsl:when test="@suffix='AV'">av</xsl:when>
                                                <xsl:when test="@suffix='P-POS'">pk_pos</xsl:when>
                                                <xsl:when test="@suffix='P-NEG'">pk_neg</xsl:when>
                                                <xsl:when test="@suffix='INST'">inst</xsl:when>
                                            </xsl:choose>
                                        </xsl:attribute>
                                    </xsl:if>
                                </xsl:element>
                            </xsl:if>
                        </xsl:for-each>
                    </xsl:element>
                </xsl:if>
            </xsl:for-each>
            <xsl:comment>*********************************************************</xsl:comment>
            <!--
            <xsl:for-each select="//complex_signal">
                <xsl:element name="signal">
                    <xsl:attribute name="name">
                        <xsl:value-of select="signal_name/@name"/>
                    </xsl:attribute>
                    <xsl:attribute name="type">
                        <xsl:value-of select="@type"/>
                    </xsl:attribute>

                    <xsl:for-each select="specifies/specify/noun_modifiers/noun_modifier">
                        <xsl:sort select="@type"/>
                        <xsl:element name="modifier">
                            <xsl:attribute name="name">
                                <xsl:value-of select="signal_component/atlas/noun_modifier/@type"/>
                            </xsl:attribute>
                            <xsl:if test="signal_component/atlas/noun_modifier/@suffix">
                                <xsl:attribute name="suffix">
                                    <xsl:value-of select="signal_component/atlas/noun_modifier/@suffix"/>
                                </xsl:attribute>
                            </xsl:if>
                            <xsl:attribute name="tsf_attribute">
                                <xsl:value-of select="signal_component/ieee_1641/attribute/@type"/>
                            </xsl:attribute>
                            <xsl:if test="signal_component/atlas/noun_modifier/@suffix">
                                <xsl:attribute name="tsf_qualifier">
                                    <xsl:choose>
                                        <xsl:when test="signal_component/atlas/noun_modifier/@suffix='TRMS'">trms
                                        </xsl:when>
                                        <xsl:when test="signal_component/atlas/noun_modifier/@suffix='PP'">pk_pk
                                        </xsl:when>
                                        <xsl:when test="signal_component/atlas/noun_modifier/@suffix='P'">pk</xsl:when>
                                        <xsl:when test="signal_component/atlas/noun_modifier/@suffix='AV'">av</xsl:when>
                                        <xsl:when test="signal_component/atlas/noun_modifier/@suffix='P-POS'">pk_pos
                                        </xsl:when>
                                        <xsl:when test="signal_component/atlas/noun_modifier/@suffix='P-NEG'">pk_neg
                                        </xsl:when>
                                        <xsl:when test="signal_component/atlas/noun_modifier/@suffix='INST'">inst
                                        </xsl:when>
                                    </xsl:choose>
                                </xsl:attribute>
                            </xsl:if>
                        </xsl:element>
                    </xsl:for-each>
                </xsl:element>
            </xsl:for-each>
            <xsl:for-each select="/atlas/signal_oriented_verbs/require_verb/requires/require">
                <xsl:for-each select="require_types/require_type">
                    <xsl:sort select="signal_component/atlas/noun/@type"/>
                    <xsl:if test="signal_component">
                        <xsl:element name="signal">
                            <xsl:attribute name="name">
                                <xsl:value-of select="../../@virtual_label"/>:<xsl:value-of
                                    select="signal_component/atlas/noun/@type"/>
                            </xsl:attribute>
                            <xsl:attribute name="type">
                                <xsl:value-of select="@type"/>
                            </xsl:attribute>
                            <xsl:attribute name="tsf">
                                <xsl:value-of select="signal_component/ieee_1641/tsf/@type"/>
                            </xsl:attribute>
                            <xsl:call-template name="signal"/>
                        </xsl:element>
                    </xsl:if>
                </xsl:for-each>
            </xsl:for-each>
            -->
        </signal-map>
    </xsl:template>

    <xsl:template name="signal">
        <xsl:for-each select="../..//signal_component">
            <xsl:sort select="atlas/noun_modifier/@type"/>
            <xsl:if test="atlas/noun_modifier/@type">
                <xsl:element name="modifier">
                    <xsl:attribute name="name">
                        <xsl:value-of select="atlas/noun_modifier/@type"/>
                    </xsl:attribute>
                    <xsl:if test="atlas/noun_modifier/@suffix">
                        <xsl:attribute name="suffix">
                            <xsl:value-of select="atlas/noun_modifier/@suffix"/>
                        </xsl:attribute>
                    </xsl:if>
                    <xsl:attribute name="tsf_attribute">
                        <xsl:value-of select="ieee_1641/attribute/@type"/>
                    </xsl:attribute>
                    <xsl:if test="atlas/noun_modifier/@suffix">
                        <xsl:attribute name="tsf_qualifier">
                            <xsl:choose>
                                <xsl:when test="atlas/noun_modifier/@suffix='TRMS'">trms</xsl:when>
                                <xsl:when test="atlas/noun_modifier/@suffix='PP'">pk_pk</xsl:when>
                                <xsl:when test="atlas/noun_modifier/@suffix='P'">pk</xsl:when>
                                <xsl:when test="atlas/noun_modifier/@suffix='AV'">av</xsl:when>
                                <xsl:when test="atlas/noun_modifier/@suffix='P-POS'">pk_pos</xsl:when>
                                <xsl:when test="atlas/noun_modifier/@suffix='P-NEG'">pk_neg</xsl:when>
                                <xsl:when test="atlas/noun_modifier/@suffix='INST'">inst</xsl:when>
                            </xsl:choose>
                        </xsl:attribute>
                    </xsl:if>
                </xsl:element>
            </xsl:if>
        </xsl:for-each>
    </xsl:template>

</xsl:stylesheet>