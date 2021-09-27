<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <Accounts>
      <xsl:for-each select="Accounts/Employee">
        <Employee>
          <xsl:attribute name="Code">
            <xsl:value-of select="@id"/>
          </xsl:attribute>
          <FullName>
            <xsl:value-of select="Family"/><xsl:text>&#032;</xsl:text><xsl:value-of select="Name"/>
            <xsl:text>&#032;</xsl:text>
            <xsl:value-of select="SecondName"/>
          </FullName>
          <Document>
            <xsl:value-of select="Document/DocumentCode"/>
            <xsl:text>&#044;</xsl:text>
            <xsl:text>&#032;</xsl:text>
            <xsl:value-of select="Document/Series"/>
            <xsl:text>&#032;</xsl:text>
            <xsl:value-of select="Document/Number"/>
          </Document>
          <BirthDate>
            <xsl:value-of select="BirthDate"/>
          </BirthDate>
          <Sex>
            <xsl:value-of select="Sex"/>
          </Sex>
        </Employee>
      </xsl:for-each>
    </Accounts>
  </xsl:template>

</xsl:stylesheet>