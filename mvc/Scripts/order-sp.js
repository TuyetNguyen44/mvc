//tăng số lượng ở shopping-cart sau khi thêm ds sản phẩm vào giỏ hàng
$(document).ready(function () {
    let data = sessionStorage.getItem('orders');
    var amount =0
    let dataArr
		if (!data) {
				$(".cart-amount").hide()
		}
		else {
			dataArr = JSON.parse("[" + data + "]")
			if (dataArr.length < 1) {
				$(".cart-amount").hide()
			}
            else {
                $(".cart-amount").show()
                amount = dataArr.length;
            }
		}
    
    $(".cart-amount").text(amount);
    $('.product .btn-buy').click(function(){
        var product = $(this).parents('.product');
        var imgLink = product.find('.product-img').attr('src');
        var name = product.find('.product-name').text();
        var price = product.find('.price').text();
        var order = {
            "img_link": imgLink,
            "name": name,
            "price": price
        }

        var currentProduct = window.sessionStorage.getItem('orders');
        var newOrder="";
        if(currentProduct)
            newOrder = currentProduct + "," + JSON.stringify(order);
        else
            newOrder = JSON.stringify(order);
        window.sessionStorage.setItem('orders', newOrder);
        
        var current= Number($(".cart-amount").text());
        current+=1;
        $(".cart-amount").show()
        $(".cart-amount").text(current);  
    });
});

