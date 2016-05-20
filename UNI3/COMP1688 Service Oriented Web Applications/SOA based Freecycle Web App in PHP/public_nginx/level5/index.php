<?php
error_reporting(E_ERROR);

if(isset($_POST['keyword'])){

if ( isset($_REQUEST['keyword']) ) {
   $nq = trim($_REQUEST['keyword']);
   $pSize = $_POST['pSize'] ;
		$pNum = $_POST['pNum'] ;

	if("" == $nq){
    $nq = " ";
}
   if ( preg_match("/[^a-zA-Z0-9 \-']|^$/",$nq) ) die ('<item/>');

	} else {
	   die ('<item/>');
	}

$url = 'http://stuweb.cms.gre.ac.uk/~ag306/level3/freecycleCombinedList.php?keyword='.$nq.'&pSize='.$pSize.'&pNum='.$pNum;
$xmlDom1 = new DOMDocument();
$xmlDom1->load($url);

$xmlString = $xmlDom1->saveXML(); 
$doc = new DOMDocument();
$simpleXml = new SimpleXMLElement($xmlString);
$doc->loadXML($xmlString);

$output .= '<br/><table id="myTable" border="1" width="50%">
			<thead>
					<tr>
						<th>Title</th>
						<th>Description</th>
						<th>Post date</th>
						<th>Post code</th>
						<th>Images</th>
					</tr>
			</thead>';

$records = $doc->documentElement->childNodes;

	foreach($records as $record) {
	
		$itemID = $record->getAttribute("itemID");
		$title = $record->getElementsByTagName("title")->item(0)->textContent;
		$descr = $record->getElementsByTagName("descr")->item(0)->textContent;
		$post_date = $record->getElementsByTagName("post_date")->item(0)->textContent;
		$postcode = $record->getElementsByTagName("postcode")->item(0)->textContent;
		//check if img exists
		$imgExists = $record->getElementsByTagName("image")->item(0);
		if($imgExists != null){
			$imgID = $record->getElementsByTagName("image")->item(0)->getAttribute("imgID");
		}
		else{
			$imgID = "";
		}
	$loc = substr($imgID,0,3);
	$output .= " <tbody><tr>
					<td>
								<a href='http://stu-nginx.cms.gre.ac.uk/~ag306/level5/showItemDetail.php?itemID=$itemID'>$title</a>
					</td>
					<td>$descr</td>
					<td>$post_date</td>
					<td>$postcode</td>";
		if($imgExists){
			if($loc == 'gre'){
			$output .=	'<td><img src="http://stuweb.cms.gre.ac.uk/~ag306/level3/getImage.php?imgID='.$imgID.'" alt="" /></td>';
			}
			if($loc == 'lew'){
			$output .=	'<td><img src="http://stuiis.cms.gre.ac.uk/ag306/myroot/level2/freecycle/GetImage.ashx?imgID='.$imgID.'" alt="" /></td>';
			}
		}
		else{
		$output .= '<td></td>';
		}
		$output .=		"</tr></tbody>\n";
}
$output .= '</table>';
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
<title>Freecycle</title>
<meta http-equiv="Content-Type" content="application/xhtml+xml; charset=utf-8" />
<meta http-equiv="Content-Script-Type" content="text/javascript" />
<link rel="stylesheet" href="layout/styles/layout.css" type="text/css" />
</head>
<body id="top">

<!-- ####################################################################################################### -->
<div class="wrapper col1">
  <div id="header">
    <div id="logo">
      <h1><a href="index.php">FREECYCLE</a></h1>
      <p><i>Greenwich and Lewisham</i></p>
    </div>
    <div id="topnav">
      <ul>
        <li class="active"><a href="#">Home</a></li>
        <li><a href="http://stuiis.cms.gre.ac.uk/ag306/myroot/level2/freecycle/freecycleDotNet.asmx">Level 2</a></li>
		<li><a href="http://stuweb.cms.gre.ac.uk/~ag306/level3/searchPHP.html">Level 3</a></li>
        <li><a href="http://stu-nginx.cms.gre.ac.uk/~ag306/level4/searchCombinedPHP.html">Level 4</a></li>
        <li><a class="drop" href="#">Extra</a>
            <ul>
              <li><a href="http://stu-nginx.cms.gre.ac.uk/~ag306/level5/index.php">Level 5</a></li>
              <li><a href="http://stu-nginx.cms.gre.ac.uk/~ag306/level6/index.php">Level 6</a></li>
              <li><a href="http://stu-nginx.cms.gre.ac.uk/~ag306/level7/index.php">Level 7</a></li>
              <li><a href="http://stu-nginx.cms.gre.ac.uk/~ag306/level8/index.php">Level 8</a></li>
              <li><a href="http://stu-nginx.cms.gre.ac.uk/~ag306/final/index.php">Level Final</a></li>
            </ul>
        </li>
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

		<div class="center">
			<h1>Welcome to FREECYCLE</h1>
         <h2>Portal for Greenwich and Lewisham</h2>
			<form method="post" action="<?php $PHP_SELF ?>">
			<div id="forms">
            <div>
			<label for="search">Search..</label>
			<input type="text" id="search" name="keyword" value="<?php if(isset($_POST["keyword"])) echo $_POST["keyword"]; ?>" size="30"/>
			<label for="pSize">Items per page:</label>
			<select id="pSize" name="pSize">
				<option value="4">4</option>
				<option value="6">6</option>
				<option value="10">10</option>
			</select>
            <label for="pNum">Pages</label>
			<select id="pNum" name="pNum">
				<option value="1">1</option>
				<option value="2">2</option>
				<option value="3">3</option>
			</select>
			<input type="submit" name="searchButton" value="Search"/> 
			</div>
			</div>
			</form>
			</div>

		    <?php echo $output;?>

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