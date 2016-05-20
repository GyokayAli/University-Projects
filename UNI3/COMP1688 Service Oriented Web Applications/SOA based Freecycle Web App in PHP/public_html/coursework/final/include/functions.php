<?php
error_reporting(E_ERROR);

//will start session in all pages if included
session_start();

//check if Session or Cookie is set
//sessionOrCookie();

//used to check if the user is logged in
//checks the SESSION and COOKIE, either one will be successfull if true
function loggedin()
{
	if(isset($_SESSION['username']) || isset($_COOKIE['username']))
	{
		$loggedin = TRUE;
		return $loggedin;
	}
}

//used in every page to check if session or cookie is set
//not a very good solution! don't use in the future!
function sessionOrCookie(){
      
	if(isset($_COOKIE['username']))
	{   
		return $_SESSION['username'] = $_COOKIE['username'];;
	}
	else
	{   
		return $_SESSION['username'];
	}
}

//function used for the Go Back link
//usually prevents crashes
function goBack(){
 //go back in history -1 
	$referer = $_SERVER['HTTP_REFERER'];
	if (!$referer == '') {
	echo '<p><a href="' . $referer . '" title="Return to the previous page">&laquo; Go back</a></p>';
	} else {
		 echo '<p><a href="javascript:history.go(-1)" title="Return to the previous page">&laquo; Go back</a></p>';
	}
}

?>