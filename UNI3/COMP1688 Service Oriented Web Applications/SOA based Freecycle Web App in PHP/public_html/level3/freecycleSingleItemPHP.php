<?php 
header('Content-type: text/xml'); 

if ( isset($_REQUEST['itemID']) ) {
   $nq = trim($_REQUEST['itemID']);
   if ( preg_match("/[^a-zA-Z0-9 \-']|^$/", $nq) ) die ('<items/>');
} else {
   die ('<items><error>illegal search term</error></items/>');
}

$link = mysqli_connect('studb.cms.gre.ac.uk', 'ag306', 'hardsm2Z', 'mdb_ag306') or die
    ('<items><error>'.mysqli_error($link).'</error></items>'); 
$query = 'SELECT * 
          FROM Item 
          WHERE itemID = "'.$nq.'"'; 
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

	  //get image details from db
	  $query1 = 'SELECT  *
          FROM Image 
          WHERE itemID = "'.$row['itemID'].'" LIMIT 1'; 

	  if(mysqli_query($link, $query1) != false){
		$result1 = mysqli_query($link, $query1) or die
		('<items><error>'.mysqli_error($link).'</error></items>');

		while ( $row1 = mysqli_fetch_assoc($result1) ){
			
			$xmlImage = $xmlDom->createElement('image'); 
			$xmlImageID = $xmlDom->CreateAttribute('imgID'); 
		    $xmlImageID->value = $row1['imgID']; 
		    $xmlImage->appendChild($xmlImageID);
			$xmlTxt = $xmlDom->createTextNode($row1['imgName']); 
			$xmlImage->appendChild($xmlTxt); 
		    $xmlItem->appendChild($xmlImage); 
		}
	  }
	  //end

	  $xmlMember = $xmlDom->createElement('member'); 
      $xmlMemID = $xmlDom->CreateAttribute('memID'); 
	  $xmlMemID->value = $row['memID']; 
      $xmlMember->appendChild($xmlMemID); 
	  $xmlItem->appendChild($xmlMember);

	  //get member details from db
	  $query2 = 'SELECT name, postcode, tel, email 
          FROM Member 
          WHERE memID = "'.$row['memID'].'"'; 

	  if(mysqli_query($link, $query2) != false){
		$result2 = mysqli_query($link, $query2) or die
		('<items><error>'.mysqli_error($link).'</error></items>');

		  while ( $row = mysqli_fetch_assoc($result2) ){

			  $xmlMemName = $xmlDom->createElement('full_name'); 
			  $xmlTxt = $xmlDom->createTextNode($row['name']); 
			  $xmlMemName->appendChild($xmlTxt); 
			  $xmlMember->appendChild($xmlMemName); 

			  $xmlMemPostcode = $xmlDom->createElement('postcode'); 
			  $xmlTxt = $xmlDom->createTextNode($row['postcode']); 
			  $xmlMemPostcode->appendChild($xmlTxt); 
			  $xmlMember->appendChild($xmlMemPostcode); 

			  if($row['tel'] != null )
			  {
				  $xmlMemTel = $xmlDom->createElement('contact_number'); 
				  $xmlTxt = $xmlDom->createTextNode($row['tel']); 
				  $xmlMemTel->appendChild($xmlTxt); 
				  $xmlMember->appendChild($xmlMemTel); 
			  }

			  if($row['email'] != null )
			  {
				  $xmlMemEmail = $xmlDom->createElement('email'); 
				  $xmlTxt = $xmlDom->createTextNode($row['email']); 
				  $xmlMemEmail->appendChild($xmlTxt); 
				  $xmlMember->appendChild($xmlMemEmail); 
			  }
		  }
	  }
	  //end member details

      $xmlRoot->appendChild($xmlItem); 
} 
echo $xmlDom->saveXML(); 
?>