<?php 
include 'include/functions.php';
include 'include/connection.php';

if(!loggedin())
{
    echo '<p>You must be logged in to access this page</p>';
	header('Location: index.php');
}

include 'include/header.php';

?>
		<h1>Uploading Images to Database</h1>
	    <form action="imageUpload.php" method="post" enctype="multipart/form-data">
			<fieldset>
			<div id="forms"> 
			<legend>Image Upload</legend>
			<label for="userFile">Small image to upload: </label>
			<input type="file" size="40" name="userFile" id="userFile"/><br />
			<br />
			<label for="altText">Description of image</label>
			<input type="text" size="60" name="altText" id="altText"/><br />
			<br />
			<input type="submit" value="Upload File" />
			<div>
			</fieldset>
		</form>	
		
			<?php
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
			} else if ( strlen($_POST['altText']) < 9 ) {
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
			   $query = 'INSERT INTO image (type,name,alt,img,post_id) VALUES ("' . $_FILES['userFile']['type'] . '","' . $_FILES['userFile']['name']  . '","' . $alt  . '","' . $image . '","' . $_SESSION['post_id'] . '")';
			   if ( !(mysqli_query($conn, $query)) ) {
				  echo '<p>Error writing image to database</p>';
			   } else {
				  echo '<p>Image successfully copied to database</p>';
			   }
			}
?>
<a id="link" href="showPost.php">Check your post</a>
<?php
include 'include/footer.php';
?>
            

		

