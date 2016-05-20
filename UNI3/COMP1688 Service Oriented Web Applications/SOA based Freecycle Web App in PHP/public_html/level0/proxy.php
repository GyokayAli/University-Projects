<?php
error_reporting(E_ERROR);
header("Content-type: application/json");

if ( isset($_REQUEST['keyword']) ) {
    $nq = stripslashes($_REQUEST['keyword']);

// The XML data file with whitespace such as tabs
$url = "http://stuweb.cms.gre.ac.uk/~ag306/level3/freecycleListItemsPHP.php?keyword=$nq";

$xmlDom1 = new DOMDocument();
$xmlDom1->load($url);

$xmlString = $xmlDom1->saveXML(); 
$doc = new DOMDocument();

$doc->loadXML($xmlString);

$records = $doc->documentElement->childNodes;
$i = 0;
foreach($records as $record) {
	
		$data[$i]['_id'] = $record->getAttribute("itemID");
		$data[$i]['title'] = $record->getElementsByTagName("title")->item(0)->textContent;
		$data[$i]['description'] = $record->getElementsByTagName("descr")->item(0)->textContent;
		$data[$i]['post_date'] = $record->getElementsByTagName("post_date")->item(0)->textContent;
		$data[$i]['postcode'] = $record->getElementsByTagName("postcode")->item(0)->textContent;
		$data[$i]['imgID'] = $record->getElementsByTagName("image")->item(0)->getAttribute("imgID");

	//	$json =   json_encode($data);
		$i+=1;
	}
	//echo $json;


// Connect to database
$m = new MongoClient("mongodb://ag306:hardsm2Z@mongo.cms.gre.ac.uk/mdb_ag306");

// Select a database
$db = $m->mdb_ag306;

$collItem = $db->Item; // Select the ITEM collection
$collMember = $db->Member; // Select the Member collection
$collImage = $db->Image; // Select the Image collection

$regex = new MongoRegex("/$nq/i");
$json = '';
$i = 0;

$where=array( '$or' => array( array('title'=>$regex), array('description'=>$regex) ) );
	// Find everything in the collection where keyword matches the title and description
	$cursor1 = $collItem->find($where);
	foreach($cursor1 as $document => $row){

		$data2[$i]['_id']=$row['_id'];
		$data2[$i]['title']=$row['title'];
		$data2[$i]['description']=$row['description'];
		$data2[$i]['post_date']=$row['post_date'];
		$data2[$i]['memberID']=$row['memberID'];

		// Find postcoe in the collection where matches member ID
		$cursor2 = $collMember->find(array('_id'=>$row['memberID']));
		foreach($cursor2 as $document2 => $row2){
			$data2[$i]['postcode']=$row2['postcode'];
		}

		// Find img URL in the collection where matches item ID
		$cursor3 = $collImage->find(array('itemID'=>$row['_id']));
		foreach($cursor3 as $document3 => $row3){
			$data2[$i]['URL']=$row3['imgURL'];
		}

		//$json2 =   json_encode($data);
		$i+=1;
	}
	//echo $json2;

	$args = array('keyword'=>$nq);
	$client = new SoapClient('http://stuiis.cms.gre.ac.uk/ag306/myroot/level2/freecycle/freecycleDotNet.asmx?WSDL'); 
	$xmls = $client->lookupListOfItemsByKeyWord($args)->lookupListOfItemsByKeyWordResult->any; 
	$xmlDom1 = new DOMDocument(); 
	$xmlDom1->loadXML($xmls, LIBXML_NOBLANKS);

	$records2 = $xmlDom1->documentElement->childNodes;
	$i = 0;
	foreach($records2 as $record) {
	
		$data3[$i]['_id'] = $record->getAttribute("itemID");
		$data3[$i]['title'] = $record->getElementsByTagName("title")->item(0)->textContent;
		$data3[$i]['description'] = $record->getElementsByTagName("descr")->item(0)->textContent;
		$data3[$i]['post_date'] = $record->getElementsByTagName("post_date")->item(0)->textContent;
		$data3[$i]['postcode'] = $record->getElementsByTagName("postcode")->item(0)->textContent;
		$data3[$i]['imgID'] = $record->getElementsByTagName("image")->item(0)->getAttribute("imgID");

		$i+=1;
	}
}

if ($data == null && $data2 == null){
	echo json_encode($data3);
}
else if ($data == null && $data3 == null){
	echo json_encode($data2);
}
else if ($data2 == null && $data3 == null){
	echo json_encode($data);
}
else if ($data2 == null){
	echo json_encode(array_merge($data,$data3));
}
else if ($data3 == null){
	echo json_encode(array_merge($data,$data2));
}
else if ($data == null){
	echo json_encode(array_merge($data3,$data2));
}
else{
	echo json_encode(array_merge($data,$data2,$data3));
}
?>