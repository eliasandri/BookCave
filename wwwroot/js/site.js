$(function () {
  // Document.ready -> link up remove event handler
  $(".RemoveLink").click(function () {
      // Get the id from the link
      var recordToDelete = $(this).attr("data-id");
      console.log(recordToDelete);
      if (recordToDelete != '') {
          // Perform the ajax post
          $.post("/ShoppingCart/RemoveFromCartAsync", {"id": recordToDelete },
              function (data) {
                  // Successful requests get here
                  // Update the page elements
                  if (data.ItemCount == 0) {
                      $('#row-' + data.DeleteId).fadeOut('slow');
                  } else {
                      $('#item-count-' + data.DeleteId).text(data.ItemCount);
                  }
                  $('#cart-total').text(data.CartTotal);
                  $('#update-message').text(data.Message);
                  $('#cart-status').text('Cart (' + data.CartCount + ')');
              });
      }
  });
});// Write your JavaScript code.
