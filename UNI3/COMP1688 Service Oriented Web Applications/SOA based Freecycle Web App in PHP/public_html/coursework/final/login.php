<?php
include 'include/functions.php';
sessionOrCookie();
include 'include/connection.php';

/*** check if the user is already logged in ***/
if (loggedin()) {
    $message = 'You are already logged in';
    header('Location: members.php');
}

$sql    = "SELECT * FROM Account WHERE username = '$username'";
$result = mysqli_query($conn, $sql);

if ($_POST) {
    if (mysqli_num_rows($result) == 0) {
        $message = 'User does not exist. Please register!';
    }
    /*** first check input have been sent ***/
    if (!($_POST['log-username'] && $_POST['log-password'])) {
        $message = 'Please fill in your details.';
    }
    /*** check the username is the correct length ***/
    elseif (strlen($_POST['log-username']) > 20 || strlen($_POST['log-username']) < 5) {
        $message = 'Incorrect Length for Username';
    } /*** check the password is the correct length ***/ elseif (strlen($_POST['log-password']) > 20 || strlen($_POST['log-password']) < 5) {
        $message = 'Incorrect Length for Password';
    } /*** check the username has only alpha numeric characters ***/ elseif (ctype_alnum($_POST['log-username']) != true) {
        $message = 'Username must be alpha numeric';
    } /*** check the password has only alpha numeric characters ***/ elseif (ctype_alnum($_POST['log-password']) != true) {
        $message = 'Password must be alpha numeric';
    } else {
        
        $username   = filter_var($_POST['log-username'], FILTER_SANITIZE_STRING);
        $password   = md5(filter_var($_POST['log-password'], FILTER_SANITIZE_STRING));
        $rememberme = $_POST['rememberme'];
        
        $dbh = new PDO('mysql:host=mysql.cms.gre.ac.uk;dbname=mdb_ag306', 'ag306', 'hardsm2Z');
        /*** set the error mode to exceptions ***/
        $dbh->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        
        //username
        /*** prepare the select statement ***/
        $stmt = $dbh->prepare('SELECT username FROM Account 
                    WHERE username = :username;');
        /*** bind the parameters ***/
        $stmt->bindParam(':username', $username, PDO::PARAM_STR);
        /*** execute the prepared statement ***/
        $stmt->execute();
        /*** check for a result ***/
        $user_id = $stmt->fetchColumn();
        
        //get password
        /*** prepare the select statement ***/
        $stmt1 = $dbh->prepare('SELECT pass FROM Account 
                    WHERE username = :username AND pass = :password;');
        /*** bind the parameters ***/
        $stmt1->bindParam(':username', $username, PDO::PARAM_STR);
        $stmt1->bindParam(':password', $password, PDO::PARAM_STR);
        /*** execute the prepared statement ***/
        $stmt1->execute();
        /*** check for a result ***/
        $isPassword = $stmt1->fetchColumn();
        
        //get status
        $stmt2 = $dbh->prepare('SELECT isActive FROM Account 
                    WHERE username = :username;');
        $stmt2->bindParam(':username', $username, PDO::PARAM_STR);
        $stmt2->execute();
        $isActive = $stmt2->fetchColumn();
        
        
        
        /*** if we have no result ***/
        if ($user_id == '') {
            $message = 'User does not exist! Please register.';
        } elseif ($isPassword == '') {
            $message = 'The password is not correct!';
        } elseif ($isActive == 0) {
            //generate random activation code
            $length         = 5;
            $activationCode = substr(str_shuffle('0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ'), 0, $length);
            
            $stmt3 = $dbh->prepare('SELECT email FROM Account 
                    WHERE username = :username');
            $stmt3->bindParam(':username', $username, PDO::PARAM_STR);
            $stmt3->execute();
            $email = $stmt3->fetchColumn();
            
            $message = 'Account is not active!' . "</br>" . 'Please check your email to activate your account!';
            
            
            /*** set the session username variable ***/
            $_SESSION['username'] = $username;
            $_SESSION['email']    = $email;
            $_SESSION['code']     = $activationCode;
            
            mail($_SESSION['email'], 'Account activation mail', "
         Hello,\n
         Welcome to Greenwich Freecycle! \n
         Please use the code below to activate your account:\n\n
         ACTIVATION CODE: " . $_SESSION['code'] . "\n\n
         From: freecycle@gmail.com");
            
            header('refresh:3;url=activation.php');
            
        }
        
        /*** else, all is well ***/
        else {
            if ($rememberme == "on") {
                setcookie("username", $username, time() + 7200); //set for 48 hours
            } else {
                /*** set the session username variable ***/
                $_SESSION['username'] = $username;
            }
            
            
            /*** tell the user we are logged in ***/
            $message = 'You are now logged in ';
            header('Location: members.php');
        }
        #end else
    }
}

include 'include/header.php';
?>

<?php
echo $message;
?>

<div class="center">
<h1>LOGIN</h1>

<form id="formLogin" method="post" action="login.php" onsubmit="return validateLogForm()">
<div id="forms">
    <div>
        <label for="log-username">Username*:</label> <br/>
        <input type="text" value="<?php
if (isset($_POST["log-username"]))
    echo $_POST["log-username"];
?>" 
        name="log-username" id="log-username" maxlength="20" /> <br/><br/>
    </div>
    <div>
        <label for="log-password">Password*:</label><br/>
        <input type="password" name="log-password" id="log-password" maxlength="20"/> <br/><br/>
    </div>
    </div>
    <div>
        <input type="checkbox" id="rememberme" name="rememberme" /><label for="rememberme">Remember me</label> 
    </div>
    <div id="formss">
    <div>
        <input type="submit" name="login" value="Login"/>
    </div>
    </div>
</form>
</div>

        
<?php
include 'include/footer.php';
?> 