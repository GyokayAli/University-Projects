<?php
include 'include/functions.php';
include 'include/connection.php';

sessionOrCookie();

$per_page=3;
if (isset($_GET["page"])) {

$page = $_GET["page"];

}

else {

$page=1;

}

// Page will start from 0 and Multiple by Per Page
$start_from = ($page-1) * $per_page;

$sql= 'SELECT * FROM Post WHERE username="'.$_SESSION['username'].'" LIMIT '.$start_from.','.$per_page.';';
$result = mysqli_query($conn, $sql);


/////////// DELETE POST
if(isset($_POST['delete']))
{
$sql_s='DELETE FROM image WHERE post_id="'.$_POST['post_id'].'";';
$sql_s.= 'DELETE FROM Post WHERE username="'.$_SESSION['username'].'" AND post_id="'.$_POST['post_id'].'"; ';
$result_s = mysqli_multi_query($conn,$sql_s) ;
	
	if($result_s == false)
	{
	mysqli_error($conn);
	}
header("Refresh:0");
}
/////////// DELETE POST


/////////// EDIT POST
if(isset($_POST['edit']))
{
	$result2 = mysqli_query($conn, $sql);

while($row = mysqli_fetch_assoc($result2))
	{
		$save = '<div id="forms">
		<form id="formPost" method="post" action="updatePost.php" onsubmit="return validatePostForm()" enctype="multipart/form-data">
			<h2><br/>Edit your post<br/></h2>
			<div>
				<label for="post-title">Title: </label>
				<input type="hidden" name="post-id" value="'.$row["post_id"].'"/>
				<input type="text" name="post-title" id="post-title" value="'. $row["title"] .'" maxlength="50" /> 
				<label for="post-user-name">Name: </label>
				<input type="text" name="post-user-name" id="post-user-name" value="'. $row["aname"] .'"  maxlength="40"/> <br/><br/>
			</div>
			<div>
				<label for="post-location">Location: </label>
				<input type="text" name="post-location" id="post-location" value="'. $row["address"] .'" size="50" maxlength="40"/> 
				<label for="post-tel">Telephone: </label>
				<input type="text" name="post-tel" id="post-tel" value="'. $row["tel"] .'" size="50" maxlength="20"/> <br/><br/>
			</div>
			<div>
				<p>Description: </p>
				<textarea rows="5" cols="50" name="post-descr" id="post-descr" title="post description" >'. $row["description"] .'
				</textarea><br/>
			</div>
			<div>
				<label for="date">Date: </label>
				<input type="text" id="date" name="post-date" value="'. $row["post_date"] .'"/>
				<input type="submit" value="Save" name="saveButton"/>
			</div>
		</form></div>';			
	}
}
/////////// EDIT POST

//check if there are posts at all
    if(mysqli_num_rows($result) > 0)
	{		

		$message = '<table id="myTable" border="1" width="100%" >
		  <thead>
			<tr>
				<th>Images</th>
				<th>Title</th>
				<th>Description</th>
				<th>Posted by</th>
				<th>Address</th>
				<th>Telephone</th>
				<th>Post date</th>
				<th></th>
				<th></th>
			</tr>
		  </thead>';


		while($row = mysqli_fetch_assoc($result))
		{
        
		$message.= '<tbody><tr class="light">';

		//get image of post
        $query = 'SELECT * FROM image WHERE post_id="'.$row['post_id'].'"';
		$result3 = mysqli_query($conn, $query);	    

	    $message.= '<td>';
		for ( $i = 0 ; $i < mysqli_num_rows($result3) ; $i++ ) { //error?
			$row2 = mysqli_fetch_assoc($result3);
            $image = $row2['img'];
			$message.= '<img class="imgr" src="data:image/png;base64,' . base64_encode($image) . '" alt="'.$row2['alt'].'" />';
		 }//get image of post
		
	    $message.='</td>';     //post image
		$message.= '<td>' . $row["title"] . '</td>'; //title
		$message.= '<td>' . $row["description"] . '</td>'; //description
		$message.= '<td>' . $row["aname"] . '</td>'; //posted by (name)
		$message.= '<td>' . $row["address"] . '</td>'; //address
		$message.= '<td>' . $row["tel"] . '</td>'; //tel number
		$message.= '<td>' . $row["post_date"] . '</td>'; //post date
		$message.= '<td> <form method="post" action="">
						<div><input type="submit" name="edit" value="Edit"/></div>
						<div><input type="hidden" name="post_id" value="'.$row["post_id"].'"/></div></form></td>';
		$message.= '<td> <form method="post" action=""> 
					<div><input type="submit" name="delete" value="Delete"/></div>
					<div><input type="hidden" name="post_id" value="'.$row["post_id"].'"/></div></form></td>';
		$message.= '</tr></tbody>';
		}
		$message.= '</table>';
	}
	else{
		        
		/*** check if the user is  logged in ***/
			if(!loggedin()){
				$message = 'You must be logged in to access this page';
				header('Location: index.php');
			}

			$message = 'No posts available. Please submit new ones if you wish!';
		}
include 'include/header.php';
?>

<h1>My posts<br/></h1>

<?php goBack(); //go back in history -1 ?>

<?php echo $message;?>
<?php echo $save;?>

<div>
<br/>
<?php

//Now select all from table
$query = 'select * from Post WHERE username = "'.$_SESSION['username'].'"';
$result = mysqli_query($conn, $query);

// Count the total records
$total_records = mysqli_num_rows($result);

//Using ceil function to divide the total records on per page
$total_pages = ceil($total_records / $per_page);
?>
<div class="center">
<?php
//Going to first page
echo "<a href='showPost.php?page=1'>".'First page'."</a> ";

for ($i=1; $i<=$total_pages; $i++) {

echo "<a href='showPost.php?page=".$i."'>".$i."</a> ";
};
// Going to last page
echo "<a href='showPost.php?page=$total_pages'>".'Last page'."</a> ";
?>
</div>
</div>
<br/>
<?php goBack(); //go back in history -1 ?>
<a id="link" href="members.php">UPLOAD NEW POST</a>

<?php include 'include/footer.php'; ?>