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
<script type="text/javascript">
<!--

// Create an HTTP Object
var http = new XMLHttpRequest(); 

// Send a request asynchronusly
function requestXML(url) {
	http.open("GET",url,true);
	http.onreadystatechange = handleHttpResponse;
	http.send(null);
}

// Event handler for the XML response
function handleHttpResponse() {
	if (http.readyState == 4) {
		xmlDoc = http.responseXML; // returns a DOM object
		showIt();
	}
}

// Send request
function sendRequest(query) {
	if (query != "") {
		var phpUrl = "http://stu-nginx.cms.gre.ac.uk/~ag306/level7/proxyGreLew.php?keyword=" + query +"&pSize=12&pNum=1";
		requestXML(phpUrl);
	} else {
		document.getElementById("results").innerHTML = "";
	}
}

// DHTML DOM gets the results into the page
function showIt() {
	var itemID, title, descr, postDate, postcode, imgID, 
		output="";

	output += "<table id='myTable' border='1' width='50%'><thead><tr><th>Title<\/th><th>Description<\/th><th>Post date<\/th>";
		output += "<th>Post code<\/th><th>Images<\/th><\/tr><\/thead>";	

	var records = xmlDoc.documentElement.childNodes;
	for ( var i = 0; i < records.length; i++ ) {

		itemID = records[i].getAttribute("itemID");
		title = records[i].firstChild.firstChild.nodeValue;
		descr = records[i].firstChild.nextSibling.firstChild.nodeValue;
        postDate = xmlDoc.getElementsByTagName("post_date")[i].childNodes[0].nodeValue;
		postcode = xmlDoc.getElementsByTagName("postcode")[i].childNodes[0].nodeValue;
		imgID = records[i].lastChild.getAttribute("imgID");
		
		if(imgID === null) imgID = "";

		output += "<tbody><tr><td><a href='http://stu-nginx.cms.gre.ac.uk/~ag306/level5/showItemDetail.php?itemID="+itemID+"'>"+title+"<\/a><\/td>";
		output += "<td>"+descr+"<\/td><td>"+postDate+"<\/td><td>"+postcode+"<\/td>";

		if(imgID.substring(0,3) == "lew"){
			output +=	"<td><img src='http://stuiis.cms.gre.ac.uk/ag306/myroot/level2/freecycle/GetImage.ashx?imgID="+imgID+"' alt='' /><\/td><\/tr><\/tbody>\n";
		}
		else if(imgID.substring(0,3) == "gre"){
			output +=	"<td><img src='http://stuweb.cms.gre.ac.uk/~ag306/level3/getImage.php?imgID="+imgID+"' alt='' /><\/td><\/tr><\/tbody>\n";
		}
		else{
			output +=	"<td><\/td><\/tr><\/tbody>\n";
		}
	}
	output += "<\/table>";
	document.getElementById("results").innerHTML = output;
}
//-->
</script>
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
			<div id="MyForm">
			<label for="search">Search:</label>
			<input type="text" id="search" onkeyup="sendRequest(this.value)"  name="keyword" value="<?php if(isset($_POST["keyword"])) echo $_POST["keyword"]; ?>" size="50"/></div>
			</form>
			</div><br/>
			<!-- results come from javascript -->
			<p id="results"></p>
			
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