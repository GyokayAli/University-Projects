// validate activation form
function validateActivationForm()
    {
        // Create validation variables
        var valid = true;
		var activationMessage = 'Thank you!\nYour account has been activated.';
        var validationMessage = 'Please correct the followings:\r\n';

		// Validate username
        if (4 >= document.getElementById('act-code').value.length ||     document.getElementById('act-code').value.length >= 6)
        {
            validationMessage = validationMessage + '  - Activation code must be 5 characters long!\r\n';
            valid = false;
        }      

		// Display alert box with errors if any errors found
        if (valid == false)
        {
            alert(validationMessage);
        }
		else
		{
			alert(activationMessage);
		}
        return valid;
	}

// validate login form
function validateLogForm()
		{
			// Create validation variables
			var valid = true;
			var validationMessage = 'Please correct the followings:\r\n';

			// Validate username
			if (4 >= document.getElementById('log-username').value.length ||     document.getElementById('log-username').value.length >= 21)
			{
				validationMessage = validationMessage + '  - Username must be 5-20 characters long!\r\n';
				valid = false;
			}

			// Validate password
			if (4 >= document.getElementById('log-password').value.length || document.getElementById('log-password').value.length >= 21)
			{
				validationMessage = validationMessage + '  - Password must be 5-20 characters long!\r\n';
				valid = false;
			}

			// Display alert box with errors if any errors found
			if (valid == false)
			{
				alert(validationMessage);
			}
			return valid;
		}

// validate registration form
function validateRegForm()
    {
        // Create validation variables
        var valid = true;
        var validationMessage = 'Please correct the following:\r\n';

		// Validate username
        if (4 >= document.getElementById('reg-username').value.length ||     document.getElementById('reg-username').value.length >= 21)
        {
            validationMessage = validationMessage + '  - Username must be 5-20 characters long!\r\n';
            valid = false;
        }

        // Validate password
        if (4 >= document.getElementById('reg-password').value.length || document.getElementById('reg-password').value.length >= 21)
        {
            validationMessage = validationMessage + '  - Password must be 5-20 characters long!\r\n';
            valid = false;
        }

        // Validate email
        if (document.getElementById('reg-email').value.length == 0 || 
		document.getElementById('reg-email').value.length >= 125)
        {
            validationMessage = validationMessage + '  - Email not correct or missing!\r\n';
            valid = false;
        }

		// Validate captcha
        if (document.getElementById('reg-captcha').value.length == 0 || 4 >= document.getElementById('reg-captcha').value.length)
        {
            validationMessage = validationMessage + '  - Captcha is shorter than expected!\r\n';
            valid = false;
        }

        // Display alert box with errors if any errors found
        if (valid == false)
        {
            alert(validationMessage);
        }
		
        return valid;
    }

// to validate Post forms
function validatePostForm(){
        
        // Create validation variables
        var valid = true;
        var validationMessage = 'Please correct the following:\r\n';

		// Validate post title
        if (4 >= document.getElementById('post-title').value.length || document.getElementById('post-title').value.length >= 51)
        {
            validationMessage = validationMessage + '  - Title must be 5-50 characters long!\r\n';
            valid = false;
        }
		// Validate user's name
        if (1 >= document.getElementById('post-user-name').value.length || document.getElementById('post-user-name').value.length >= 41)
        {
            validationMessage = validationMessage + '  - Your name must be 2-40 characters long!\r\n';
            valid = false;
        }
		// Validate location
        if (4 >= document.getElementById('post-location').value.length || document.getElementById('post-location').value.length >= 101)
        {
            validationMessage = validationMessage + '  - Location/Address must be 2-100 characters long!\r\n';
            valid = false;
        }
		// Validate tel number
        if (4 >= document.getElementById('post-tel').value.length || !checkUKTelephone (document.getElementById('post-tel').value))
        {
            validationMessage = validationMessage + '  - Telephone number not correct!\r\n';
            valid = false;
        }
		
        // Validate description
        if (1 >= document.getElementById('post-descr').value.length || document.getElementById('post-descr').value.length >= 251)
        {
            validationMessage = validationMessage + '  - Description must be 2-250 characters long!\r\n';
            valid = false;
        }
		// Validate date
        if (0 == document.getElementById('date').value.length)
        {
            validationMessage = validationMessage + '  - Date missing\r\n';
            valid = false;
        }
		var date_regex = /^(0[1-9]|1[0-2])\/(0[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/ ;
		if((date_regex.test(document.getElementById('date').value)))
		{
			validationMessage = validationMessage + '  - Date format must be in format 2015/10/31\r\n';
			valid = false;
		}
        // Display alert box with errors if any errors found
        if (valid == false)
        {
            alert(validationMessage);
        }
        return valid;
    }


//reference for JS UK tel number validator
/*==============================================================================

This routine checks the value of the string variable specified by the parameter
for a valid UK telphone number. It returns false for an invalid number and the
reformatted telephone number false a valid number.

If false is returned, the global variable telNumberError contains an error
number, which may be used to index into the array of error descriptions 
contained in the global array telNumberErrors.

The definition of a valid telephone number has been taken from:

http://www.ofcom.org.uk/telecoms/ioi/numbers/numplan030809.pdf

All inappropriate telephone numbers are disallowed (e.g. premium lines, sex 
lines, radio-paging services etc.)

Author:    John Gardner
Date:      16th November 2003

Version:   V1.1  4th August 2006       
					 Updated to include 03 numbers being added by Ofcom in early 2007.

Version:   V1.2  9th January 2007
           Isle of Man mobile numbers catered for 

Version:   V1.3  6th November 2007
           Support for mobile numbers improved - thanks to Natham Lisgo

Version:   V1.4  14th April 2008
           Numbers allocated for drama excluded - thanks to David Legg
			
Example calling sequnce:

  if (!checkUKTelephone (myTelNo)) {
     alert (telNumberErrors[telNumberErrorNo]);
  }

------------------------------------------------------------------------------*/

function checkUKTelephone (telephoneNumber) {

  // Convert into a string and check that we were provided with something
  var telnum = telephoneNumber + " ";
  if (telnum.length == 1)  {
     telNumberErrorNo = 1;
     return false
  }
  telnum.length = telnum.length - 1;
  
  // Don't allow country codes to be included (assumes a leading "+")
  var exp = /^(\+)[\s]*(.*)$/;
  if (exp.test(telnum) == true) {
     telNumberErrorNo = 2;
     return false;
  }
  
  // Remove spaces from the telephone number to help validation
  while (telnum.indexOf(" ")!= -1)  {
    telnum = telnum.slice (0,telnum.indexOf(" ")) + telnum.slice (telnum.indexOf(" ")+1)
  }
  
  // Remove hyphens from the telephone number to help validation
  while (telnum.indexOf("-")!= -1)  {
    telnum = telnum.slice (0,telnum.indexOf("-")) + telnum.slice (telnum.indexOf("-")+1)
  }  
  
  // Now check that all the characters are digits
  exp = /^[0-9]{10,11}$/;
  if (exp.test(telnum) != true) {
     telNumberErrorNo = 3;
     return false;
  }
  
  // Now check that the first digit is 0
  exp = /^0[0-9]{9,10}$/;
  if (exp.test(telnum) != true) {
     telNumberErrorNo = 4;
     return false;
  }
	
	// Disallow numbers allocated for dramas.
	 
  // Array holds the regular expressions for the drama telephone numbers
  var tnexp = new Array ();
	tnexp.push (/^(0113|0114|0115|0116|0117|0118|0121|0131|0141|0151|0161)(4960)[0-9]{3}$/);
	tnexp.push (/^02079460[0-9]{3}$/);
	tnexp.push (/^01914980[0-9]{3}$/);
	tnexp.push (/^02890180[0-9]{3}$/);
	tnexp.push (/^02920180[0-9]{3}$/);
	tnexp.push (/^01632960[0-9]{3}$/);
	tnexp.push (/^07700900[0-9]{3}$/);
	tnexp.push (/^08081570[0-9]{3}$/);
	tnexp.push (/^09098790[0-9]{3}$/);
	tnexp.push (/^03069990[0-9]{3}$/);
	
	for (var i=0; i<tnexp.length; i++) {
    if ( tnexp[i].test(telnum) ) {
      telNumberErrorNo = 5;
      return false;
    }
	}
  
  // Finally check that the telephone number is appropriate.
  exp = (/^(01|02|03|05|070|071|072|073|074|075|07624|077|078|079)[0-9]+$/);
	if (exp.test(telnum) != true) {
     telNumberErrorNo = 5;
     return false;
  }
  
  // Telephone number seems to be valid - return the stripped telehone number  
  return telnum;
}
var telNumberErrorNo = 0;
var telNumberErrors = new Array ();
//telNumberErrors[0] = "Valid UK telephone number";
telNumberErrors[1] = "Telephone number not provided";
telNumberErrors[2] = "UK telephone number without the country code, please";
telNumberErrors[3] = "UK telephone numbers should contain 10 or 11 digits";
telNumberErrors[4] = "The telephone number should start with a 0";
telNumberErrors[5] = "The telephone number is either invalid or inappropriate";

////////////////////////////////////////////////////////////////////////////////////
