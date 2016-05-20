<?php
include 'include/functions.php';
include 'include/connection.php';

/////////// SAVE POST
if($_POST)
{
	$title=mysqli_real_escape_string($conn,trim($_POST['post-title']));
	$name=mysqli_real_escape_string($conn,trim($_POST['post-user-name']));
    $location=mysqli_real_escape_string($conn,trim($_POST['post-location']));
    $tel=mysqli_real_escape_string($conn,trim($_POST['post-tel']));
	$description=mysqli_real_escape_string($conn,trim($_POST['post-descr']));
    $date=mysqli_real_escape_string($conn,trim($_POST['post-date']));
    $post_id = mysqli_real_escape_string($conn,trim($_POST['post-id']));

        $sql_save='UPDATE Post SET title="'.$title.'", aname="'.$name.'", address="'.$location.'", tel="'.$tel.'", description="'.$description.'", post_date="'.$date.'"
		WHERE post_id="'.$post_id.'"';

		$result_save = mysqli_query($conn,$sql_save) ;

		if($result_save == false)
		{
			echo 'Problem connecting to MySQL';
			mysqli_error($conn);	
		}
		else{
            header('Location: showPost.php');
		}
}
/////////SAVE post
?>