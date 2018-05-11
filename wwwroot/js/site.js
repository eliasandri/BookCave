$(function () {
  // Document.ready -> link up remove event handler
  $("#RemoveLink").click(function () {
      // Get the id from the link
      var recordToDelete = $(this).attr("data-id");
      console.log(5+6);
      console.log(recordToDelete);
      if (recordToDelete != '') {
          // Perform the ajax post
          $.post("/ShoppingCart/RemoveFromCartAsync", {"id": recordToDelete },
              function (data) {
                  console.log("success");
                  console.log(data);
                  // Successful requests get here
                  // Update the page elements
                  
                     
                  
                    if (data.itemCount == 0)
                    {
                        $('#row-' + data.deleteId).css("display","none");
                    }
                    
                   
                  else {
                    
                      $('#item-Count-' + data.deleteId).text(data.itemCount);
                  }
                  $("#cart-total").text(data.cartTotal);
                  /*$("#update-message").text(data.Message);
                  $("#cart-status").text('Cart (' + data.CartCount + ')');*/
              });
      }
  });
});// Write your JavaScript code.
﻿// Write your JavaScript code.
/*function empty(){
    var x;
    x = document.getElementById("layoutsearch").value;
    if(x == ""){
        alert("Search bar empty");
        return false;
    }
}*/
