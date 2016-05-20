<?php
include 'include/functions.php';
include 'include/filter.php';
include 'include/connection.php';



if(isset($_POST['search'])){
	
	
	//get filter words
  // $filters = array('CONCAT (title,description,address)', 'title', 'description', 'address');
  // $filter = $filters[$_POST['filter']]; 

   $search = mysqli_real_escape_string($conn,trim($_POST['search']));
   $search = preg_replace("#[^0-9a-z]#i","",$search); //allow only alphanumeric search
   $sql = "SELECT * FROM Post WHERE CONCAT (title,description,address) LIKE '%$search%';";
   $result = mysqli_query($conn,$sql);

   if(mysqli_num_rows($result) == 0){
      $output = 'There was no search result!';
   }else{
      while($row = mysqli_fetch_assoc($result)){
        $post_id = $row['post_id'];
		$title = $row['title'];
		$address = $row['address'];
        $count+=1;
		$output .= '<br/>
		<input type="hidden" name="post-id" value="'.$post_id.'"/>
		<p>'.$count.'.<strong> '.$title.'</strong> (Location/Address: '.$address.')
		<a  href="showChosenPost.php?post-id='.$post_id.'">Details</a></p>
		';

		//get image of post
        $query = 'SELECT * FROM image WHERE post_id="'.$post_id.'"';
		$result3 = mysqli_query($conn, $query);	    

		for ( $i = 0 ;$i < mysqli_num_rows($result3) ; $i++ ) {
			$row2 = mysqli_fetch_assoc($result3);
            $image = $row2['img'];
			$output.= '<img src="data:image/png;base64,' . base64_encode($image) . '" alt="'.$row['alt'].'" />';
		 }//get image of post
	  }

   }
}

?>
<?php echo '<?xml version="1.0" encoding="UTF-8"?>'; ?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<!--
Template Name: PlusBusiness
Author: <a href="http://www.os-templates.com/">OS Templates</a>
Author URI: http://www.os-templates.com/
Licence: Free to use under our free template licence terms
Licence URI: http://www.os-templates.com/template-terms
-->
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en" lang="en">
<head>
<title>Greenwich Freecycle</title>
<meta http-equiv="Content-Type" content="application/xhtml+xml; charset=utf-8" />
<meta http-equiv="Content-Script-Type" content="text/javascript" />
<link rel="stylesheet" href="layout/styles/layout.css" type="text/css" />
</head>
<body id="top">

<!-- ####################################################################################################### -->
<div class="wrapper col1">
  <div id="header">
    <div id="logo">
      <h1><a href="index.php">GREENWICH FREECYCLE</a></h1>
      <p>Freecycle your items</p>
    </div>
    <div id="topnav">
      <ul>
        <li class="active"><a href="index.php">Home</a></li>
        <li><a href="members.php">Members</a></li>
		<li><a href="showPost.php">My Posts</a></li>
        <li><a href="registration.php">Register</a></li>
        <li><a href="login.php">Login</a></li>
        <li class="last"><a href="logout.php">Logout</a></li>
      </ul>
    </div>
    <br class="clear" />
  </div>
</div>
<!-- ####################################################################################################### -->
<div class="wrapper col2">
  <div id="breadcrumb">
  </div>
</div>
<!-- ####################################################################################################### -->
<div class="wrapper col3">
  <div id="container">
    <div class="homepage">
	
		 <h1>HOME</h1>
		 		 <div class="center">

         <h2>Welcome to GREENWICH FREECYCLE</h2>
			<form method="post" action="index.php">
			<div id="forms">
            <div>
			<label for="search">Search..</label>
			<input type="text" id="search" name="search" value="<?php if(isset($_POST["search"])) echo $_POST["search"]; ?>" size="30"/>
			<label for="filter">Search by</label>
			<select id="filter" name="filter">
			<?php
			foreach($filter as $key=>$value){
				echo '<option value="'.$key.'">'.$value.'</option>';
			}
			?>
			</select>
            <label for="sort">Sort by</label>
			<select id="sort" name="sortby">
			<?php
			foreach($sortby as $key=>$value){
				echo '<option value="'.$key.'">'.$value.'</option>';
			}
			?>
			</select>
			<input type="submit" name="searchButton" value="Search"/> 
			</div>
			</div>
			</form>
			</div>
			<?php echo $output; 
			?>
			
			</div>
    
	     <br class="clear" />

	   	<!--  <div class="clearfooter"></div>-->

  </div>
</div>
<!-- ####################################################################################################### -->
<div class="wrapper col5">
  <div id="copyright">
	<p class="fl_right">
	<a href="http://www.w3.org/WAI/WCAG2AA-Conformance" title="WCAG 2.0 AA">
	<img class="valid" src="http://www.w3.org/WAI/wcag2AAA.png" alt="Level Triple-A conformance, W3C WAI Web Content Accessibility Guidelines 2.0" height="31" width="88"/></a>
	</p>
	<p class="fl_right">
    <a href="http://jigsaw.w3.org/css-validator/check/referer" title="Valid CSS">
        <img style="border:0;width:88px;height:31px"
            src="http://jigsaw.w3.org/css-validator/images/vcss" height="31" width="88"
            alt="Valid CSS!" />
    </a>
	</p>
	<p class="fl_right">
    <a href="http://validator.w3.org/check?uri=referer" title="Valid XHTML 1.1"><img
      src="http://www.w3.org/Icons/valid-xhtml11" alt="Valid XHTML 1.1" height="31" width="88" /></a>
	</p>
    <p class="fl_left">Template by <a  href="http://www.os-templates.com/" title="Free Website Templates">OS Templates</a></p>
    <br class="clear" />
  </div>
</div><!-- ####################################################################################################### -->
</body>
</html>