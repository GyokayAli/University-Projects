<?php 
header('Content-type: text/xml'); 

if ( isset($_REQUEST['keyword']) && isset($_REQUEST['pSize']) && isset($_REQUEST['pNum']) ) {
   $nq = trim($_REQUEST['keyword']);
    $pSize = $_REQUEST['pSize'];
    $pNum = $_REQUEST['pNum'];

	if("" == $nq){
    $nq = " ";
}
   if ( preg_match("/[^a-zA-Z0-9 \-']|^$/",$nq) ) die ('<directory/>'); 

} else { 
   die ('<directory/>'); 
}

$args = array('keyword'=>$nq,'pSize'=>$pSize,'pNum'=>$pNum);
$client = new SoapClient('http://stuiis.cms.gre.ac.uk/ag306/myroot/level2/freecycle/freecycleDotNet.asmx?WSDL'); 
$xmls = $client->lookupListOfItemsBy3Param($args)->lookupListOfItemsBy3ParamResult->any; 
$xmlDom1 = new DOMDocument(); 
$xmlDom1->loadXML($xmls, LIBXML_NOBLANKS); 

$url = 'http://stuweb.cms.gre.ac.uk/~ag306/level3/freecycleListItemsPHP3.php?keyword='.$nq.'&pSize='.$pSize.'&pNum='.$pNum;
$xmlDom2 = new DOMDocument(); 
$xmlDom2->load($url); 

$xmlRoot1 = $xmlDom1->documentElement; 
foreach ( $xmlDom2->documentElement->childNodes as $node2 ) { 
    $node1 = $xmlDom1->importNode($node2,true); 
   $xmlRoot1->appendChild($node1); 
}

echo $xmlDom1->saveXML(); 
?>
