<?php

$host = 'studb.cms.gre.ac.uk';
$user = 'ag306';
$passwd = 'hardsm2Z';
$dbName = 'mdb_ag306';

//establish db connection
$conn = mysqli_connect($host,$user,$passwd,$dbName);
if (mysqli_connect_errno($conn)) {
	echo 'Failed to connect to MySQL: ' . mysqli_connect_error();
	exit();
}
?>