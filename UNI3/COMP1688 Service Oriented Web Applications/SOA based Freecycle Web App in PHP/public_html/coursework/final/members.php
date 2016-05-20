<?php 
include 'include/functions.php';
sessionOrCookie();


if(!loggedin())
{
    $message= 'WARNING! You must be logged in to access this page.';
	header( 'Location: index.php' ); 
}

else
{
    try
    {
        /*** connect to database ***/
        /*** select the users name from the database ***/
        $dbh = new PDO('mysql:host=mysql.cms.gre.ac.uk;dbname=mdb_ag306', 'ag306', 'hardsm2Z');

        /*** set the error mode to excptions ***/
        $dbh->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

        /*** prepare the insert ***/
        $stmt = $dbh->prepare('SELECT username FROM Account 
        WHERE username = :username');

        /*** bind the parameters ***/
        $stmt->bindParam(':username', $_SESSION['username'], PDO::PARAM_STR);

        /*** execute the prepared statement ***/
        $stmt->execute();

        /*** check for a result ***/
        $username = $stmt->fetchColumn();

        /*** if something is wrong ***/
        if(!$username == $_SESSION['username'])
        {
            $message = 'Access Error';
        }
        else
        {
			include 'include/header.php';
			echo $message;
            ?>
            <h1>MEMBERS</h1>
		    <form id="formPost" method="post" action="posted.php" onsubmit="return validatePostForm()" enctype="multipart/form-data">
			<div id="forms">
			<h2><br/>New post<br/></h2>

			<div>
				<label for="post-title">Title: </label>
				<input type="text" name="post-title" id="post-title" size="50" maxlength="50" /> 
				<label for="post-user-name">Name: </label>
				<input type="text" name="post-user-name" id="post-user-name"  size="50" maxlength="40"/> <br/><br/>
			</div>
            <div>
				<label for="post-location">Location: </label>
				<input type="text" name="post-location" id="post-location"  size="50" maxlength="100"/> 
				<label for="post-tel">Telephone: </label>
				<input type="text" name="post-tel" id="post-tel"  size="50" maxlength="30"/> <br/><br/>
			</div>
			<div>
				<p>Description: </p>
				<textarea rows="5" cols="50" name="post-descr" id="post-descr" title="post description"></textarea><br/>
			</div>
			<div>
				<label for="date">Date: </label>
				<input type="text" id="date" name="post-date" maxlength="10"></input>(Format: 2015/12/31) 
				<input type="submit" value="Submit" name="post-myButton"/>
			</div>
			</div>
		</form>
		
		<?php
include 'include/footer.php';
?>
		<?php
        }
    }
    catch (Exception $e)
    {
        $message = 'We are unable to process your request. Please try again later"';
    }
}

?>


