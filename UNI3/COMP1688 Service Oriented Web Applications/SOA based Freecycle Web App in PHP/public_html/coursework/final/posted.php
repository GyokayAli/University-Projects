<?php
include 'include/functions.php';
include 'include/connection.php';

sessionOrCookie();
/*** check if the user is  logged in ***/
if(!loggedin())
{
    $message = 'You must be logged in to access this page';
	header( 'Location: index.php' ); 
}

/*** first check input have been sent ***/
if(!isset( $_POST['post-title'], $_POST['post-user-name'], $_POST['post-location'], $_POST['post-tel'], $_POST['post-descr'], $_POST['post-date'])) #includ post image here later on
{
    $message = 'One or more input fields are not complete!';
}
/*** check the post title is the correct length ***/
elseif (strlen( $_POST['post-title']) > 50 || strlen($_POST['post-title']) < 5)
{
    $message = 'Incorrect Length for Title!';
}
/*** check if the user's name is the correct length ***/
elseif (strlen( $_POST['post-user-name']) > 40 || strlen($_POST['post-user-name']) < 2)
{
    $message = 'Incorrect Length for Name!';
}
/*** check if location is the correct length ***/
elseif (strlen( $_POST['post-location']) > 40 || strlen($_POST['post-location']) < 4)
{
    $message = 'Incorrect Length for Location!';
}
/*** check if telephone is the correct length ***/
elseif (strlen( $_POST['post-tel']) > 20 || strlen($_POST['post-tel']) < 6)
{
    $message = 'Incorrect Length for Telephone number!';
}
/*** check if description is the correct length ***/
elseif (strlen( $_POST['post-descr']) > 250 || strlen($_POST['post-descr']) < 10)
{
    $message = 'Incorrect Length for Description!';
}
/*** check if description is the correct length ***/
elseif (strlen( $_POST['post-date']) > 10 || strlen($_POST['post-date']) < 1)
{
    $message = 'Date is wrong!';
}
else
{
if($_POST){
	$title=mysqli_real_escape_string($conn,trim($_POST['post-title']));
	$name=mysqli_real_escape_string($conn,trim($_POST['post-user-name']));
    $location=mysqli_real_escape_string($conn,trim($_POST['post-location']));
    $tel=mysqli_real_escape_string($conn,trim($_POST['post-tel']));
	$description=mysqli_real_escape_string($conn,trim($_POST['post-descr']));
    $date=mysqli_real_escape_string($conn,trim($_POST['post-date']));
    $username = $_SESSION['username'];


	$sql='INSERT INTO Post (title,aname,address,tel,description,post_date,username) VALUES
          ("'.$title.'","'.$name.'","'.$location.'","'.$tel.'","'.$description.'","'.$date.'","'.$username.'");';

    $sql2='SELECT post_id FROM Post WHERE title="'.$title.'" AND aname="'.$name.'" AND address="'.$location.'" AND tel="'.$tel.'" AND
	   description="'.$description.'" AND post_date="'.$date.'" AND username="'.$username.'"';

	if(mysqli_query($conn, $sql))
    {
       $message.= '<div><h3>Your post has been submitted successfully.</h3><br/></div>'."<br/>".
			'
			 <div><h3>Submit another <a href="members.php">POST</a>.</h3></div>'."<br/>".
		    '<div><h3>Upload <a href="imageUpload.php">IMAGE/s</a> to your post.</h3></div>'."<br/>".
		   	'<div><h3><a href="showPost.php">DISPLAY</a> all my post.</h3></div>'."<br/>".
		    '<div><h3>Take me to <a id="link" href="index.php">HOME PAGE</a>.</h3></div>';
	}
	else
	{
       $message = 'We are sorry. Your post cannot be submitted at the moment.';
	}
	//check retrive of post id
    if($result = mysqli_query($conn,$sql2))
	{
		//get POST ID
		if (mysqli_num_rows($result)==1){
			$row = mysqli_fetch_array($result);
			$_SESSION['post_id'] = $row[0];
		}
		else{
			#echo "not found!";
		}
	}
}

}
include 'include/header.php';
?>
<h1>MORE ABOUT YOUR LAST POST<br/></h1>
<div class="center">
<?php echo $message;?>
</div>
<?php
include 'include/footer.php';
?>
