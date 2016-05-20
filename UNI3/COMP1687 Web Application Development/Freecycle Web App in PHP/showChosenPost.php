<?php
include 'include/functions.php';
include 'include/connection.php';

if(isset($_GET['post-id'])){
	$post_id = $_GET['post-id'];
}

$sql= 'SELECT * FROM Post WHERE post_id="'.$post_id.'";';
$result = mysqli_query($conn, $sql);

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
		  </tr>
		</thead>';

        

		while($row = mysqli_fetch_assoc($result))
		{

		$message.= '<tbody><tr class="light">';

		//get image of post
        $query = 'SELECT * FROM image WHERE post_id="'.$row['post_id'].'"';
		$result3 = mysqli_query($conn, $query);	    

	    $message.= '<td>';
		for ( $i = 0 ; $i < mysqli_num_rows($result3) ; $i++ ) {
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
		$message.= '</tr>';
		}
		$message.= '</tbody></table>';
	}
	else{
			$message = 'The post is not available.';
		}

if(isset($_POST['backButton'])){
	
}

include 'include/header.php';
?>

<h1>Post in detail<br/></h1>

<?php echo $message;?>

<?php goBack(); //go back in history -1 ?>


<?php include 'include/footer.php'; ?>	