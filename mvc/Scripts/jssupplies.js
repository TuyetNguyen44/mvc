// tăng giảm số lượng
function plusAmount(a){
	var x = document.getElementById(a).value;
	document.getElementById(a).value=Number(x)+1;
}

function subAmount(a){
	var x = document.getElementById(a).value;
	if(Number(x)>1)
		document.getElementById(a).value=Number(x)-1;
} 
// thay đổi ảnh và màu ở trang chi tiết
function ChangeImg(id) {
	var image = document.getElementById(id).getAttribute('src');
	document.getElementById('anh-goc').setAttribute('src', image);
}
function ChangeColor(id) {
	var button = document.getElementById(id).getAttribute('button');
	document.getElementById('mau-goc').setAttribute('button', button);
}
// nút giữ màu ở trang chi tiết
$(window).on("load", function () {
	$(".color-item").click(function () {
		var color = $(this).val();
		$(".color-item").css("background-color", "white");
		$(".color-item").css("color", "black");
		$(this).css("background-color", "pink");
		$(this).css("color", "white")
	})
});
// chạy slideshow
var i=1;
var n=3;
function Next(){
    if(i<n){ 
        i+=1;
    }
    else{
        i=1; 
    }
    document.getElementById("slide").setAttribute("src",i+".jpg");

}
function Back(){
    if(i>1){ 
        i-=1;
    }
    else{
        i=n; 
    }
    document.getElementById("slide").setAttribute("src",i+".jpg");
}
function AutoPlay(){
    setInterval(Next,2000);
}
// sắp xếp sản phẩm
$('#sort-price').on('change',function(){
    var products = $('.product')
    var data=[]
    for (var i = 0;i<products.length;i++){
        var img = $(products[i]).find('.product-img').attr('src')
        var name = $(products[i]).find('.product-name').text()
        var old_price = $(products[i]).find('.product-old-price').text()
        old_price=old_price.replaceAll('.','')
        old_price=old_price.replace('đ','')
        var new_price = $(products[i]).find('.price').text()
        new_price=new_price.replaceAll('.','')
        new_price=new_price.replace('đ','')
        var product = {
            'img':img,
            'name':name,
            'old_price': parseInt(old_price),
            'new_price': parseInt(new_price)
        }
        data.push(product)
    }
    if($(this).val() == 2){
        console.log(data)
        data.sort(Sort_price_Increase('new_price'))
    }
    if($(this).val() == 1){
        console.log(data)
        data.sort(Sort_price_Decrease('new_price'))
    }
    var content = ''
    for (var i = 0;i<data.length;i++){
        content += Add_Product(data[i].img,data[i].name,Apply_format_price(data[i].old_price.toString()),Apply_format_price(data[i].new_price.toString()) )
    }    
    $('.list-product').html(content)
})
function Add_Product(img,name,old_price,new_price){
    var product = `<div class="col-3 col-m-4 col-s-6">
    <div class="product">
        <img class="product-img" src="${img}" />
        <label class="product-name">${name}</label><br />
        <label class="product-old-price"><s> ${old_price} đ</s></label>
        <label class="price">${new_price} đ</label>
        <input class="btn-buy" type="button" value="ĐẶT MUA" />
        <input class="btn-view" type="button" value="CHI TIẾT" />
    </div>
</div>`
    return product
}

function Sort_price_Increase(att){
    return function(a,b){
        if (a[att] > b[att])
            return 1
        else if (a[att] < b[att])
            return -1
        return 0
    }
}
function Sort_price_Decrease(att){
    return function(a,b){
        if (a[att] > b[att])
            return -1
        else if (a[att] < b[att])
            return 1
        return 0
    }
}
function Apply_format_price(str){
    var new_str = ''
    var j=0;
    for (var i=str.length-1;i>=0;i--){
        j++
        if (j % 3 == 0 && i != 0){
            new_str = '.' + str[i] + new_str
        }
        else{
            new_str=str[i] + new_str
        }
    }
    return new_str 
}


// tìm kiếm sản phẩm
$(document).ready(function () {
    $(".icon-search").on("click", function () {
        var value = $(".txt-search").val().toLowerCase();
        var data = [];
        var content = "<h2>Sản phẩm tìm được</h2>";
        var s = 0;
        var l = 12;
        for (var i = 0; i < l; i++) {
            $("#"+i).filter(function() {
                if ($("#" + i + " .product-name").text().toLowerCase().indexOf(value) > -1) {
                    var imglink = $("#"+i).find('.product-img').attr('src');
                    var productName = $("#"+i).find('.product-name').text();
                    var price = $("#"+i).find('.price').text();
                    var old_price = $("#"+i).find('.product-old-price').text();
                    var order = {
                        'imglink': imglink,
                        'name': productName,
                        'price': price,
                        'old_price': old_price
                    }
                    $(data[s] = order);
                    s++;
                }
            });
        }
        if (data.length > 0) {
            for (var i = 0; i < data.length; i++) {
                var cartItem = `
                <div class="col-3 col-m-6 col-s-12">
                <div id='0' class="product">
                    <img class="product-img" src="${data[i].imglink}" />
                    <a href="#" class="product-name">${data[i].name} </a>
                    Gía cũ:<label><s s class="product-old-price">${data[i].old_price}</s></label> <br>
                    Gía khuyến mại:<label class="price">${data[i].price}</label>
                    <input type="button" class="btn-buy" value="CHỌN MUA"></input>
                    <input type="button " class="btn-view" value="CHI TIẾT"
                        onclick="location='./ProductDetail.html'"> </input>
                </div>
            </div>`
                content += cartItem;
            }
        }
        else {
            content += "<h3>Không tìm thấy sản phẩm nào</h3>"
        }
        console.log(content);
        $("#search").html(content);
        document.getElementById("main").style.display = "none";
    });
});






