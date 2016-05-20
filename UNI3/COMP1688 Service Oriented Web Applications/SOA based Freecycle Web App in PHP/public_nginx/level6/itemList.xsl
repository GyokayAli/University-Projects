<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
  <table cellpadding="3" >
    <thead>
      <tr>
    <!--    <th>Item ID</th> -->
        <th>Title</th>
        <th>Description</th>
        <th>Post Date</th>
        <th>Postcode</th>
        <th>Image</th>
      </tr>
    </thead><tbody>
      <xsl:for-each select="//item">
      <xsl:sort order="descending" select="post_date"/>
          <xsl:variable name="itemID" select="@itemID"/>
          <tr>
            <td><a href="http://stu-nginx.cms.gre.ac.uk/~ag306/level6/showItemDetail.php?itemID={$itemID}">
             <xsl:apply-templates select="title"/></a></td>
         <td><xsl:apply-templates select="descr"/></td>
         <td><xsl:apply-templates select="post_date"/></td>
         <td><xsl:apply-templates select="postcode"/></td>
         <td><xsl:apply-templates select="image"/></td>
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
