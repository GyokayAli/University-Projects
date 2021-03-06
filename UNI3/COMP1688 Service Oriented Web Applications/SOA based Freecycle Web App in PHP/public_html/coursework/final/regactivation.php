<?php
include 'include/functions.php';

$_SESSION['username'] =	$_SESSION['temp-username']; //no need of the temp session anymore

include 'include/connection.php';


if($_POST){


	/*** first check input have been sent ***/
	if(!isset($_POST['act-code']))
	{
		$message= 'Activation code missing';
	}
	/*** check the code is the correct length ***/
	elseif (strlen( $_POST['act-code']) > 5 || strlen($_POST['act-code']) < 5)
	{
		$message=  'Incorrect Length for Activation code';
	}
	elseif (ctype_alnum($_POST['act-code']) != true)
	{
		$message=  'Activation code must be alpha numeric';
	}
	else
	{

		$actCode=mysqli_real_escape_string($conn,trim($_POST['act-code']));
		if($actCode != $_SESSION['code']) $message='Sorry, the Activation code entered was incorrect!';

		$sql='UPDATE Account set isActive="1" WHERE  username="'.$_SESSION['username'].'" AND
											email="'.$_SESSION['email'].'"';

		 if(mysqli_query($conn, $sql))
		{

			 $message= 'Your account now has been activated successfully!';
			 header('Location: members.php');
		}
		else
		{
			$message= 'Activaion was not successfull. Please try again';
		}
    }
}
include 'include/header.php';
?>

<h1><br/>ACCOUNT ACTIVATION</h1>
<h2>Please check your email for the activation code</h2>

<form id="formActive" method="post" action="activation.php" onsubmit="return validateActivationForm()">
<div id="forms">
<label for="act-code">Activation code:</label>
<input type="text" name="act-code" id="act-code" size="10" maxlength="5" /> <br/>
<input type="submit" value="Submit" name="log-myButton"/>
</div>
</form>

<?php echo $message;?> <!--messages from the validation will come here -->

<?php include 'include/footer.php';?>