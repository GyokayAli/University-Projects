<?php
if(isset($_GET['imgID'])){
$imgID = $_GET['imgID'];

$conn = mysqli_connect('studb.cms.gre.ac.uk', 'ag306', 'hardsm2Z', 'mdb_ag306') or die (mysqli_error($conn)); //MYSQL
$query = "SELECT * FROM Image WHERE imgID = '$imgID'";
$result = mysqli_query($conn,$query);
$row = mysqli_fetch_assoc($result);

header('Content-Type: image/png');

echo $row['img'];
}
?>