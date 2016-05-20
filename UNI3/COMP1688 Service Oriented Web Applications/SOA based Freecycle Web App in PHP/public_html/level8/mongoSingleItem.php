<?php
header("Content-type: application/json");

if ( isset($_REQUEST['itemID']) ) {
    $nq = stripslashes($_REQUEST['itemID']);

// Connect to database
$m = new MongoClient("mongodb://ag306:hardsm2Z@mongo.cms.gre.ac.uk/mdb_ag306");

// Select a database
$db = $m->mdb_ag306;

$collItem = $db->Item; // Select the ITEM collection
$collMember = $db->Member; // Select the Member collection
$collImage = $db->Image; // Select the Image collection

$json = '';
$i = 0;

	// Find item in the collection where item ID matches 
	$cursor1 = $collItem->find(array('_id'=>$nq));
	foreach($cursor1 as $document => $row){

		$data[$i]['_id']=$row['_id'];
		$data[$i]['title']=$row['title'];
		$data[$i]['description']=$row['description'];
		$data[$i]['post_date']=$row['post_date'];
		$data[$i]['memberID']=$row['memberID'];

		// Find in the collection where matches member ID
		$cursor2 = $collMember->find(array('_id'=>$row['memberID']));
		foreach($cursor2 as $document2 => $row2){
			$data[$i]['full_name']=$row2['name'];
			$data[$i]['postcode']=$row2['postcode'];
			$data[$i]['contact_number']=$row2['tel'];
			$data[$i]['email']=$row2['email'];
		}

		// Find in the collection where matches item ID
		$cursor3 = $collImage->find(array('itemID'=>$row['_id']));
		foreach($cursor3 as $document3 => $row3){
			$data[$i]['URL']=$row3['imgURL'];
		}

		$json =   json_encode($data);
		$i+=1;
	}
	echo $json;
}
?>