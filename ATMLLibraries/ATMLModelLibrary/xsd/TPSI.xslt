<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="@* | node()">
      <xsl:element name="TestConfiguration" >
        <xsl:
      </xsl:element>
      <TestConfiguration xmlns="urn:IEEE-1671.4:2008.01:TestConfiguration" 
                         xmlns:c="urn:IEEE-1671:2008.01:Common" 
                         xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" 
                         xsi:schemaLocation="urn:IEEE-1671.4:2008.01:TestConfiguration G:\ATML\P1671_4\1671_4~1\TestConfiguration.xsd" 
                         uuid="464A62B8-D061-48f7-8D08-9985704F0A56" 
                         securityClassification="String" >
        <ConfigurationManager name="FRC XY" cageCode="A1A1A">
          <c:Contacts>
            <c:Contact name="John Doe" email="John Doe@IEEE.ORG" phoneNumber="1-800-555-1212"/>
          </c:Contacts>
          <c:FaxNumber>1-800-555-1213</c:FaxNumber>
          <c:MailingAddress>
            <c:Address1>445 Hoes Lane</c:Address1>
            <c:Address2>P.O. Box 1331</c:Address2>
            <c:City>Piscataway</c:City>
            <c:State>NJ</c:State>
            <c:Country>USA</c:Country>
            <c:PostalCode>08855</c:PostalCode>
          </c:MailingAddress>
          <c:URL>http://www.ieee.org</c:URL>
        </ConfigurationManager>
        <TestedUUTs>
          <TestedUUT>
            <c:DescriptionDocumentReference uuid="F3B57C69-6381-412d-BCD8-B0DB19A4E7DF"/>
          </TestedUUT>
        </TestedUUTs>
        <TestEquipment>
          <TestEquipmentItem>
            <c:DescriptionDocumentReference uuid="B6237761-C88A-4b06-A527-99B31D17CAF4"/>
            <Software>
              <c:Definition>
                <c:Description>O/S</c:Description>
                <c:Identification>
                  <c:ModelName>OpenOS V6.2</c:ModelName>
                </c:Identification>
              </c:Definition>
              <c:SerialNumber>1234-4567</c:SerialNumber>
              <c:ReleaseDate>2007-10-06</c:ReleaseDate>
            </Software>
            <Software>
              <c:Definition>
                <c:Description>T/E</c:Description>
                <c:Identification>
                  <c:ModelName>VECP-1-101.3</c:ModelName>
                </c:Identification>
              </c:Definition>
              <c:SerialNumber>5161812-01</c:SerialNumber>
              <c:ReleaseDate>2007-10-06</c:ReleaseDate>
            </Software>
            <Instrumentation>
              <c:Definition name="ACPSHV">
                <c:Description>2A5A5</c:Description>
                <c:Identification>
                  <c:ModelName>5161812-01</c:ModelName>
                </c:Identification>
              </c:Definition>
            </Instrumentation>
            <Instrumentation>
              <c:Definition name="DCPSLVA">
                <c:Description>1A4A2</c:Description>
                <c:Identification>
                  <c:ModelName>5362195-01</c:ModelName>
                </c:Identification>
              </c:Definition>
            </Instrumentation>
            <Instrumentation>
              <c:Definition name="DMM">
                <c:Description>2A1A6</c:Description>
                <c:Identification>
                  <c:ModelName>E1412A</c:ModelName>
                </c:Identification>
              </c:Definition>
            </Instrumentation>
            <Instrumentation>
              <c:Definition name="PPLDL">
                <c:Description>1A4A9</c:Description>
                <c:Identification>
                  <c:ModelName>5362192-01</c:ModelName>
                </c:Identification>
              </c:Definition>
            </Instrumentation>
            <Resource>
              <c:Definition name="AC PWR CA W102">
                <c:Identification>
                  <c:ModelName> 000CA002-01</c:ModelName>
                </c:Identification>
              </c:Definition>
            </Resource>
            <Resource>
              <c:Definition name="GROUND STRAP (GS1)">
                <c:Identification>
                  <c:ModelName> 000GR001-1</c:ModelName>
                </c:Identification>
              </c:Definition>
            </Resource>
          </TestEquipmentItem>
        </TestEquipment>
        <TestProgramElements>
          <TpsHardware quantity="1" type="ID">
            <c:DescriptionDocumentReference uuid="783DCC8C-150C-486b-88D1-36347569E3AD"/>
          </TpsHardware>
          <TpsHardware quantity="1" type="CSET">
            <c:DescriptionDocumentReference uuid="8820137A-6B74-44a0-9FB4-6354B3387E6B"/>
          </TpsHardware>
          <TpsHardware quantity="1" type="CA">
            <c:DescriptionDocumentReference uuid="DB31DC37-817B-40e1-AA3D-5C164FF1296C"/>
          </TpsHardware>
          <TpsHardware quantity="1" type="CA">
            <c:DescriptionDocumentReference uuid="2816D5A7-9699-481e-99B1-57F5E4CA7397"/>
          </TpsHardware>
          <TpsSoftware type="PROG">
            <c:SerialNumber>3907AS1000-01</c:SerialNumber>
            <c:ReleaseDate>2007-10-06</c:ReleaseDate>
            <Checksum type="MD5" value="000000"/>
          </TpsSoftware>
          <Documentation uuid="84046841-90D9-4f85-A75A-86747AAF4C6B" name="TSR" documentNumber="3907AS1001TSR-01"/>
          <Documentation uuid="B444F09A-F40F-4175-AB22-74187B7DF65C" name="OTPI" documentNumber="3907AS7000-01"/>
          <Documentation uuid="544D9FEA-4C21-4f90-B6B4-0CCDA635A417" name="TPI" documentNumber="3907AS7001-01"/>
          <Documentation uuid="61EE7DE5-4205-4fed-BD67-F6937911C4AB" name="TM" documentNumber="AN61-53ON660-1"/>
          <Documentation uuid="7DC6D5F3-D121-4cfd-9427-D78AF5BC24F1" name="TEC" documentNumber="GSYB"/>
        </TestProgramElements>
        <AdditionalSoftware>
          <AdditionalSoftwareItem>
            <c:Definition name="OFP">
              <c:Identification>
                <c:IdentificationNumbers>
                  <c:IdentificationNumber number="N/A" type="Part" qualifier="N/A"/>
                </c:IdentificationNumbers>
                <c:ModelName> LRU OFP</c:ModelName>
              </c:Identification>
            </c:Definition>
            <c:SerialNumber>9999-1</c:SerialNumber>
          </AdditionalSoftwareItem>
        </AdditionalSoftware>
      </TestConfiguration>





      <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>
</xsl:stylesheet>
