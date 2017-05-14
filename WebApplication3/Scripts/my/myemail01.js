 // myemail01.js 
/*!
 *  myemail01.js 
 */
 //alert('myemail01.js');
var mycmd22 = (function() {

   // private property
    var number = 0;

	// global method. Semi private. Not really.
    _privateIncrement = function(){
    	alert('_privateIncrement');    //number++;
    };

    function findId(src) { 
    	return src.id === "FU_WONTONDELIVERY";
    }

    function sendShit(src) { 
        var url = "./letsDoThis";
        //alert(src);

        //$.getJSON(url, function (data) {
        //    console.log("data = ", data);    
        //    //alert(data);
        //});
        console.log("get get"); // + result);

        $.getJSON("./letsDoThis", function (result) {
            console.log("result", result); // + result);
            //alert(JSON.stringify(result) );
            //$.each(result, function (i, field) {
            //      console.log(field + " ");
            //});
        });
    }

    _privateListIds = function(src, id){
    	console.log('src = '+ JSON.stringify(src) );
    	console.log(src.find(findId)); 
    };

  return {
  	my_test:function() {
  		_privateIncrement();
            alert('my_test:function()');
            //return sum;
        },

        sendMail: function (id) {
            var sss = document.getElementById('sendMailSubject').value;            
            sendShit("wtf");
            this.sendMailClear(id);
        },
        sendMail00: function (id) {
            // get subject
            var sss = document.getElementById('sendMailSubject').value;
            //alert('sendMail00: ' + id);
            // config stuff
            document.getElementById('sendMailTo').value = "tbd@gmail.com";

            document.getElementById('sendMailSubject').value = "This is a test of the American Botasdcasting syste,m.! " + id;
            document.getElementById('id01').style.display = 'block'
        },
        sendMailClear: function (id) {
            // get subject
            document.getElementById('sendMailFrom').value = '';
            document.getElementById('sendMailSubject').value = '';
            document.getElementById('sendMailBody').value = '';
        },

    openMailFromServer:function(divId, srcIds, id) {
  var item = srcIds.find(x => x.id === id);
  //console.log("FFF item = ", item);
  //console.log("item.path = ", item.path);
  // clear selections begin
   var x = document.getElementsByClassName("person");
    for (i = 0; i < x.length; i++) {
       x[i].style.display = "none";
   }

    x = document.getElementsByClassName("test");
    for (i = 0; i < x.length; i++) {
        //console.log(i, "x[i].className = ", x[i].className);
        x[i].style.background = '';
        //console.log(i, "x[i].innerHTML = ", x[i].innerHTML);

        //;//  [i].className = x[i].className.replace(" w3-light-grey", "");
        //[i].className = x[i].className.replace("w3-light-grey", " w3-light-green");
    }

    x = document.getElementById(id);
    if (x) {
        x.style.background = 'lightgrey';
    }
    //var x = document.getElementById('FU_WHOWEARE');
    // clear selections end
    
    var url = item.path; 

    $.get(url, function(data){
        document.getElementById(divId).innerHTML = data; //'hi hey  hole. <br/>';
        document.getElementById(divId).style.display = "block";
    });
}
}
}());