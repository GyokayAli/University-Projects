<?php 
header('Content-type: text/xml'); 

if ( isset($_REQUEST['keyword']) ) {
   $nq = trim($_REQUEST['keyword']);

   if("" == $nq){
    $nq = " ";
} 
   if ( preg_match("/[^a-zA-Z0-9 \-']|^$/", $nq) ) die ('<items/>');
} else {
   die ('<items><error>illegal search term</error></items/>');
}

$link = mysqli_connect('studb.cms.gre.ac.uk', 'ag306', 'hardsm2Z', 'mdb_ag306') or die
    ('<items><error>'.mysqli_error($link).'</error></items>'); 
$query = "SELECT * FROM Item WHERE CONCAT (title,description) LIKE '%$nq%'
			ORDER BY itemID";
$result = mysqli_query($link, $query) or die
    ('<items><error>'.mysqli_error($link).'</error></items>'); 

$xmlDom = new DOMDocument(); 
$xmlDom->appendChild($xmlDom->createElement('items')); 
$xmlRoot = $xmlDom->documentElement;


while ( $row = mysqli_fetch_assoc($result) ) {
      $xmlItem = $xmlDom->createElement('item'); 
      $xmlItemID = $xmlDom->CreateAttribute('itemID'); 
      $xmlItemID->value = $row['itemID']; 
      $xmlItem->appendChild($xmlItemID); 

      $xmlTitle = $xmlDom->createElement('title'); 
      $xmlTxt = $xmlDom->createTextNode($row['title']); 
      $xmlTitle->appendChild($xmlTxt); 
      $xmlItem->appendChild($xmlTitle); 

      $xmlDescr = $xmlDom->createElement('descr'); 
      $xmlTxt = $xmlDom->createTextNode($row['description']); 
      $xmlDescr->appendChild($xmlTxt); 
      $xmlItem->appendChild($xmlDescr); 

      $xmlDate = $xmlDom->createElement('post_date'); 
      $xmlTxt = $xmlDom->createTextNode($row['post_date']); 
      $xmlDate->appendChild($xmlTxt); 
      $xmlItem->appendChild($xmlDate);

	  //get member postcode from db
	$query1 = 'SELECT postcode
          FROM Member 
          WHERE memID = "'.$row['memID'].'"'; 

	  if(mysqli_query($link, $query1) != false){
		$result1 = mysqli_query($link, $query1) or die
		('<items><error>'.mysqli_error($link).'</error></items>');

		  while ( $row1 = mysqli_fetch_assoc($result1) ){

			  $xmlMemPostcode = $xmlDom->createElement('postcode'); 
			  $xmlTxt = $xmlDom->createTextNode($row1['postcode']);
			  $xmlMemPostcode->appendChild($xmlTxt); 
			  $xmlItem->appendChild($xmlMemPostcode); 
		  }
	  }
	  //end member details


	//get image details from db
	$query2 = 'SELECT  *
          FROM Image
          WHERE itemID = "'.$row['itemID'].'" LIMIT 1'; 

	if(mysqli_query($link, $query2) != false){
		$result2 = mysqli_query($link, $query2) or die
		('<items><error>'.mysqli_error($link).'</error></items>');

		while ( $row2 = mysqli_fetch_assoc($result2) ){

			$xmlImage = $xmlDom->createElement('image');
			$xmlImageID = $xmlDom->CreateAttribute('imgID');
			$xmlImageID->value = $row2['imgID'];
			$xmlImage->appendChild($xmlImageID);
			$xmlTxt = $xmlDom->createTextNode($row2['imgName']);
			$xmlImage->appendChild($xmlTxt);
			$xmlItem->appendChild($xmlImage);
		}
	}
	//end

      $xmlRoot->appendChild($xmlItem); 
} 
echo $xmlDom->saveXML(); 
?>