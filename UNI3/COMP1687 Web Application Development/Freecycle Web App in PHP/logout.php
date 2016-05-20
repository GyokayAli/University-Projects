<?php 
include 'include/functions.php';
sessionOrCookie();
if(!loggedin())
{
    $message= 'WARNING! You are not logged in.';
	header( 'Location: index.php' ); 
	#exit();
}
else
{
    $message='Successfully logged out.';
    header('refresh:5;url=index.php'); 

session_unset();

// Destroy the session.
session_destroy();

//unset cookies
setcookie('username','',time()-7200);
}


include 'include/header.php';
?>
<h1>LOGOUT</h1>
<?php
echo $message;
include 'include/footer.php';
?>