<?php
header('Content-type: text/xml');

if ( isset($_REQUEST['itemID']) ) {
    $nq = trim($_REQUEST['itemID']);

    if("" == $nq){
        $nq = " ";
    }
    if ( preg_match("/[^a-zA-Z0-9 \-']|^$/",$nq) ) die ('<directory/>');

} else {
    die ('<directory/>');
}

$args = array('itemID'=>$nq);
$client = new SoapClient('http://stuiis.cms.gre.ac.uk/ag306/myroot/level2/freecycle/freecycleDotNet.asmx?WSDL');
$xmls = $client->lookupSingleItemByID($args)->lookupSingleItemByIDResult->any;
$xmlDom1 = new DOMDocument();
$xmlDom1->loadXML($xmls, LIBXML_NOBLANKS);

$url = 'http://stuweb.cms.gre.ac.uk/~ag306/level3/freecycleSingleItemPHP.php?itemID='.$nq;
$xmlDom2 = new DOMDocument();
$xmlDom2->load($url);

$xmlRoot1 = $xmlDom1->documentElement;
foreach ( $xmlDom2->documentElement->childNodes as $node2 ) {
    $node1 = $xmlDom1->importNode($node2,true);
    $xmlRoot1->appendChild($node1);
}

echo $xmlDom1->saveXML();
?>
