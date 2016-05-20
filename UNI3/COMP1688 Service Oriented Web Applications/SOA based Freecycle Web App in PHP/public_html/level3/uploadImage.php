<?php 
$conn = mysqli_connect('studb.cms.gre.ac.uk', 'ag306', 'hardsm2Z', 'mdb_ag306') or die (mysqli_error($link)); 

			if ( !isset($_FILES['userFile']['type']) ) {
			   echo '<p>No image submitted</p>';
			}
			else{
			echo '<p>
			You submitted this file:<br /><br />
			Temporary name:  '.$_FILES['userFile']['tmp_name'].' <br />
			Original name: '.$_FILES['userFile']['name'].' <br />
			Size:  '.$_FILES['userFile']['size'].'  bytes<br />
			Type:  '.$_FILES['userFile']['type'].' </p>';
			}

			// Validate uploaded image file
			if ( !preg_match( '/gif|png|x-png|jpeg/', $_FILES['userFile']['type']) ) {
			   echo '<p>Only browser compatible images allowed</p>';
			} else if ( strlen($_POST['altText']) < 3 ) {
			   echo '<p>Please provide meaningful alternate text</p>';
			} else if ( $_FILES['userFile']['size'] > 16384 ) {
			   echo '<p>Sorry file too large</p>';
			} else if ( !($handle = fopen ($_FILES['userFile']['tmp_name'], "r")) ) {
			   echo '<p>Error opening temp file</p>';
			} else if ( !($image = fread ($handle, filesize($_FILES['userFile']['tmp_name']))) ) {
			   echo '<p>Error reading temp file</p>';
			} else {
			   fclose ($handle);
			   // Commit image to the database
			   $image = mysqli_real_escape_string($conn, $image);
			   $alt = htmlentities($_POST['altText']);
			   $imgID = htmlentities($_POST['imgID']);
			   $itemID = htmlentities($_POST['itemID']);
			   $query = 'INSERT INTO Image (imgID,imgName,img,itemID) VALUES ("'.$imgID.'","' . $alt  . '","' . $image . '","'.$itemID.'")';
			   if ( !(mysqli_query($conn, $query)) ) {
				  echo '<p>Error writing image to database</p>';
			   } else {
				  echo '<p>Image successfully copied to database</p>';
			   }
			}
?>

<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>PHP Web Service</title>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
<meta name="Author" content="ag306@gre.ac.uk" />
</head>
<body>
<h1>Uploading Images to Database</h1>
	    <form action="uploadImage.php" method="post" enctype="multipart/form-data">
			<fieldset>
			<div id="forms"> 
			<legend>Image Upload</legend>
			<label for="userFile">Small image to upload: </label>
			<input type="file" size="40" name="userFile" id="userFile"/><br />
			<br />
			<label for="altText">Description of image</label>
			<input type="text" size="60" name="altText" id="altText"/><br />
			<br />
			<label for="imgID">Image ID</label>
			<input type="text" size="60" name="imgID" id="imgID"/><br />
			<br />
			<label for="itemID">Foreign key Item ID</label>
			<input type="text" size="60" name="itemID" id="itemID"/><br />
			<br />
			<input type="submit" value="Upload File" />
			<div>
			</fieldset>
		</form>	
</form>
</body>

</html>