<?php
header("Content-type: application/json");

if ( isset($_REQUEST['keyword']) ) {
    $nq = stripslashes($_REQUEST['keyword']);

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

		$data[$i]['_id']=$row['_id'];
		$data[$i]['title']=$row['title'];
		$data[$i]['description']=$row['description'];
		$data[$i]['post_date']=$row['post_date'];
		$data[$i]['memberID']=$row['memberID'];

		// Find postcoe in the collection where matches member ID
		$cursor2 = $collMember->find(array('_id'=>$row['memberID']));
		foreach($cursor2 as $document2 => $row2){
			$data[$i]['postcode']=$row2['postcode'];
		}

		// Find img URL in the collection where matches item ID
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