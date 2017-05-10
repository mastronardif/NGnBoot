 // myemail01.js 
/*!
 *  myemail01.js 
 */
 alert('myXXXXXXXXXXXXXX.js');
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

  FUCKopenMailFromServer:function(divId, srcIds, id) {
      console.log('openMailFromServer '); //return;
  //fillDivBuf('FU');
  //_privateListIds(srcIds);

  //myArray.find(x => x.id === '45').foo
  
  var item = srcIds.find(x => x.id === id);
  console.log("ZZZZZZZZZZ item = ", item);
  console.log("item.path = ", item.path);
  // clear selections begin
   var x = document.getElementsByClassName("person");
    for (i = 0; i < x.length; i++) {
       x[i].style.display = "none";
    }
    x = document.getElementsByClassName("test");
    for (i = 0; i < x.length; i++) {
       x[i].className = x[i].className.replace(" w3-light-grey", "");
    }


    // clear selections end

    // get from server
var url = item.path; //'./index.html'; //'http://www.joeschedule.com/';
//url = 'http://www.joeschedule.com/';

 // $.get(url, function(data, status){
 //            //alert("Data: " + data + "\nStatus: " + status);
 //            //console.log("Data: " + data + "\nStatus: " + status);
 //            //document.getElementById(personName).style.display = data;
 //            document.getElementById(personName).innerHTML = data; //'hi hey  hole. <br/>';
 //            document.getElementById(personName).style.display = "block";
 //        });

//$.getJSON('http://anyorigin.com/go?url=http%3A//www.joeschedule.com/&callback=?', function(data){
$.get(url, function(data){
  //$('#output').html(data.contents);
              document.getElementById(divId).innerHTML = data; //'hi hey  hole. <br/>';
            document.getElementById(divId).style.display = "block";
            //alert( "Data Loaded: " + data );

});

        // set
    //document.getElementById(personName).style.display = "response";
}
}
}());