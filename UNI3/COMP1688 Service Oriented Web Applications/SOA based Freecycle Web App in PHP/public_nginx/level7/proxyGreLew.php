<?php
error_reporting(E_ERROR);
header('Content-type: text/xml');

if ( isset($_REQUEST['keyword'])) {
   $nq = trim($_REQUEST['keyword']);
   $pSize = $_REQUEST['pSize'] ;
   $pNum = $_REQUEST['pNum'] ;

$url = 'http://stuweb.cms.gre.ac.uk/~ag306/level3/freecycleCombinedList.php?keyword='.$nq.'&pSize='.$pSize.'&pNum='.$pNum;
$xmlDom1 = new DOMDocument();
$xmlDom1->load($url);

$xmlString = $xmlDom1->saveXML(); 
//$doc = new DOMDocument();
//$simpleXml = new SimpleXMLElement($xmlString);
//$doc->loadXML($xmlString);

echo $xmlString;
}
?>