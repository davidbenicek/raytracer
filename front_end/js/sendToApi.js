const $ = require('jquery');


function sendToApi(formData){
  $.post( "localhost:8080/api/Render", formData)
    .done(function( data ) {
      console.log("Success",data);
  });
}

