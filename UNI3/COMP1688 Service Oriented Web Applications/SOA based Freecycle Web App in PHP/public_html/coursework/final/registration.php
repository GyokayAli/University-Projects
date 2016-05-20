<?php
include 'include/functions.php';
sessionOrCookie();
include 'include/connection.php';

/*** check if the user is already logged in ***/
if(loggedin())
{
    $message = 'You are already logged in';
	header('Location: members.php');
}

if($_POST)
{
/*** first check input have been sent ***/
if(!( $_POST['reg-username'] && $_POST['reg-password'] && $_POST['reg-email'] && $_POST['reg-captcha']))
{
    $message = 'Please fill in your details.';
}
/*** check the username is the correct length ***/
elseif (strlen( $_POST['reg-username']) > 20 || strlen($_POST['reg-username']) < 5)
{
    $message = 'Incorrect Length for Username';
}
/*** check the password is the correct length ***/
elseif (strlen( $_POST['reg-password']) > 20 || strlen($_POST['reg-password']) < 5)
{
    $message = 'Incorrect Length for Password';
}
/*** check the username has only alpha numeric characters ***/
elseif (ctype_alnum($_POST['reg-username']) != true)
{
    $message = 'Username must be alpha numeric';
}
/*** check the password has only alpha numeric characters ***/
elseif (ctype_alnum($_POST['reg-password']) != true)
{
        $message = 'Password must be alpha numeric';
}
/*** check the email is valid format ***/
elseif (!filter_var($_POST['reg-email'], FILTER_VALIDATE_EMAIL) || strlen($_POST['reg-email']) < 6) 
{
    $message = 'Invalid email address';
}
/*** check the captcha is the correct length ***/
elseif (strlen($_POST['reg-captcha']) < 5)
{
        $message = 'Captcha is shorter than expected';
}


else
{

    if($_POST){
	$username=mysqli_real_escape_string($conn,trim($_POST['reg-username']));
	$pass=md5(mysqli_real_escape_string($conn,trim($_POST['reg-password'])));
    $email=mysqli_real_escape_string($conn,trim($_POST['reg-email']));
    $captcha=mysqli_real_escape_string($conn,trim($_POST['reg-captcha']));


	//generate random activation code
	$length = 5;
    $activationCode = substr(str_shuffle('0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ'), 0,                          $length);
     
    if($captcha != $_SESSION['digit']) die('Sorry, the CAPTCHA code entered was incorrect!');
    #session_destroy();

    $sql='INSERT INTO Account (username,pass,email) VALUES
          ("'.$username.'","'.$pass.'","'.$email.'");';
    $sql.='INSERT INTO Status (userstat,username) VALUES (0,"'.$username.'")';

    if(!mysqli_multi_query($conn, $sql))
    {
		$message = 'Username already exists!';
         
	}		
	else
	{
        $_SESSION['temp-username'] = $username;
	     $_SESSION['email'] = $email;
		 $_SESSION['code'] = $activationCode;

		 mail($_SESSION['email'],'Account activation mail',"
		 Hello,\n
		 Welcome to Greenwich Freecycle! \n
		 Please use the code below to activate your account:\n\n
		 ACTIVATION CODE: ".$_SESSION['code']."\n\n
		 From: freecycle@gmail.com");

		 header( 'Location: regactivation.php' );
	}
  }

}
}
include 'include/header.php';
?>

<?php echo $message;?> <!--messages from the validation will come here -->

<h1>REGISTER</h1>
<!--Registration form -->
<form id="formRegister" method="post" action="registration.php" onsubmit="return validateRegForm()" >
<div id="forms">
	<div>
		<label for="reg-username">Username*:</label><br/>
		<input type="text" value="<?php if(isset($_POST["reg-username"])) echo $_POST["reg-username"]; ?>" 
		name="reg-username" id="reg-username" maxlength="20"/><br/><br/>
	</div>
	<div>
		<label for="reg-password">Password*:</label> <br/>
		<input type="password" value="<?php if(isset($_POST["reg-password"])) echo $_POST["reg-password"]; ?>" 
		name="reg-password" id="reg-password" maxlength="20"/><br/><br/>
	</div>
	<div>
		<label for="reg-email">Email*:</label><br/> 
		<input type="text" value="<?php if(isset($_POST["reg-email"])) echo $_POST["reg-email"]; ?>" 
		name="reg-email" id="reg-email" maxlength="124"/><br/><br/>
	</div>
	<div>
		<small>copy the characters from the image into the box below</small>
		<img src="captcha.php" id="captcha" alt="Captcha image" title="Captcha" width="160"  height="45"/> <br/>
		<input type="text" name="reg-captcha" id="reg-captcha" title="Captcha" size="6" maxlength="5"/><br/><br/> 
	</div>
	<div>
		<input type="submit" value="Register" name="reg-myButton"/>
	</div>
	</div>
</form>

<?php include 'include/footer.php';?>
