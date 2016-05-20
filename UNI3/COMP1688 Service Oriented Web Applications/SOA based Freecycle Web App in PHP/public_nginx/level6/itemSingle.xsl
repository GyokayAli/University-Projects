<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:template match="/">
        <table id="table1" border="1" cellpadding="3" >
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Description</th>
                    <th>Post Date</th>
                    <th>Image</th>
                </tr>
            </thead>

            <tbody>
            <xsl:for-each select="//item">
                <tr>
                    <td><xsl:apply-templates select="title"/></td>
                    <td><xsl:apply-templates select="descr"/></td>
                    <td><xsl:apply-templates select="post_date"/></td>
                    <td><xsl:apply-templates select="image"/></td>
                </tr>
            </xsl:for-each>
        </tbody>
        </table>
        <br/>
        <table id="table2" border="1" cellpadding="3" >
            <thead>
                <tr>
                    <th>Posted by</th>
                    <th>Postcode</th>
                    <th>Contact Number</th>
                    <th>Email</th>
                </tr>
            </thead>
            <tbody>
                <xsl:for-each select="//member">
                    <tr>
                        <td><xsl:apply-templates select="full_name"/></td>
                        <td><xsl:apply-templates select="postcode"/></td>
                        <td><xsl:apply-templates select="contact_number"/></td>
                        <td><xsl:apply-templates select="email"/></td>
                    </tr>
                </xsl:for-each>
            </tbody>
        </table>
    </xsl:template>
    <xsl:template match="image">
     <img src="http://stuiis.cms.gre.ac.uk/ag306/myroot/level2/freecycle/GetImage.ashx?imgID={@imgID}" alt="" />
     <img src="http://stuweb.cms.gre.ac.uk/~ag306/level3/getImage.php?imgID={@imgID}" alt="" />
 </xsl:template> 
</xsl:stylesheet>
