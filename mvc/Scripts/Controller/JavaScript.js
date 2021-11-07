/// <reference path="../angular.min.js" />



//var homeapp = angular.module('SanPhamApp', ['angularUtils.directives.dirPagination']);

//window.onload = () => {
//    var maLoai = localStorage.getItem("MaLoai");
//    console.log(maLoai);
//    fetch(`/SanPham/GetSanPham?maloai=${maLoai}`)
//        .then((response) => response.json())
//        .then((data) => {
//            const renderList = document.querySelector('#render-list');
//            console.log(renderList);
//            for (var i = 0; i < data.length; i++) {
//                console.log(data[i]);
//                var html = `
//                    <div id='0' class="product">
//                    <img class="product-img" src="https://picsum.photos/200/300" />
//                    <a href="#" class="product-name">${data[i].TenSp}</a>
//                    <input type="button" class="btn-buy" value="CHỌN MUA"></input>
//                    <input type="button " class="btn-view" value="CHI TIẾT"
//                           onclick="location='./ProductDetail.html'"> </input>
//                </div>`;
//                renderList.insertAdjacentHTML('beforeend', html);
//            }
//        });
//}
//MEMU ĐỘNG
var homeapp = angular.module("CustomerApp", ['angularUtils.directives.dirPagination']);
homeapp.controller("MenuController",
    function ($scope, $rootScope, $http, $http) {
        $http.get('/Home/GetCategory').then(function (d) {
            $rootScope.listLoai = d.data;
        },
            function (e) { alert("Lỗi lấy loại") });
        $scope.SelectLoai = function (l) {
            localStorage.setItem("MaLoai", l);
        }
       
    });

// LẤY DANH SÁCH SẢN PHẦM THEO LOẠI
homeapp.controller("SanPhamController", function ($scope, $http) {
    var maloai = localStorage.getItem("MaLoai") //;
    $http({
        method: "get",
        url: '/SanPham/GetSanPhamTheoLoai',
        params: { MaLoai: maloai }
    }).then(function success(d) {
        $scope.ListSanPham = d.data;
        console.log(data);
    }, function error(e) { alert("Error") });
});
// CHI TIẾT SẢN PHẨM
homeapp.controller("DetailProduct", function ($scope,$rootScope,$http,$window) {
    $htpp({
        method: "get",
        url: "/ChiTietSP/GetProduct",
        params: { MaSP: localStorage.getItem("MaSP") }
    }).then(function success(d)
    {
        $scope.SanPham = d.data; },
        function error() { alert("error") });
    $scope.SelectSanPham = function (masp) {
        localStorage.setItem("MaSP", masp);
    }
    
});
// lấy toàn bộ sản phẩm 
homeapp.controller("SPController", function ($scope, $http) {
    $http({
            method: 'get',
            url: '/Home/GetProduct'
        }).then(function Success(d) {

            $rootScope.ListSanPham = d.data;
        },
            function Error() {
                alert("Lấy dòng sản phẩm lỗi");
            });

});
//homeapp.controller("LoaiSPController", function ($scope, $http) {
//    // Lấy về tất cả dòng sản phẩm
//    $http.get("/ChiTietSP/GetProduct").then(function (d) {
//        $scope.Categories = d.data;
//    }, function (error) {
//        alert('Failed');
//    });
//});
//var homeapp = angular.module("CustommerApp", ['angularUtils.directives.dirPagination']);

//homeapp.controller("MenuController",
//    function ($scope, $rootScope, $http) {
//        $http({
//            method: 'get',
//            url: '/LoaiSP/GetProduct'
//        }).then(function Success(d) {

//            $rootScope.listLoaiSP = d.data;
//        },
//            function Error() {
//                alert("Lấy dòng sản phẩm lỗi");
//            });

//        $scope.SelectDongSP = function (l) {
//            localStorage.setItem("MaLoai", l);
//        }
//    });
//homeapp.controller("SapXepController", function ($scope, $rootScope, $http,$window) {
//    //Begin sort
//    $rootScope.sortcolumn = "MaSP";
//    $rootScope.reverse = true;
//    $rootScope.direct = "Ascending";
//    //Khi nhấn button sẽ chuyển đổi chiều sắp xếp
//    $rootScope.Chon = function (d) {
//        if ($rootScope.direct == "Ascending") {
//            $rootScope.reverse = false;
//            $rootScope.direct = "Decreasing";
//        }
//        else {
//            $rootScope.reverse = true;
//            $rootScope.direct = "Ascending";
//        }  
//    };
//    //Lấy sản phẩm hiển thị lên giao diện
//    $scope.GetSanPhams = function () {
//        var MaLoai = localStorage.getItem("MaLoai");
//        if (MaLoai == undefined) {
//            MaLoai = "";
//        }

//        $http.get('/SanPham/GetProduct',
//            {
//                params: {
//                    maloai: MaLoai
//                }
//            }).then(function (d) {
//                $scope.ListSanPham = d.data;
                

//            }, function (error) { alert('Failed'); });
//    };
//});




///
homeapp.controller("SapXepController", function ($scope, $rootScope, $http, $window) {
    //Begin sort
    $rootScope.sortcolumn = "MaSP";
    $rootScope.reverse = true;
    $rootScope.direct = "Ascending";
    $rootScope.maxSize = 3; // limit number for pagination display number. 
    $rootScope.totalCount = 0; // total number of items in all pages. initialize as a zero 
    $rootScope.pageIndex = 1; // current page number. first page is 1
    $rootScope.pageSize = 3; // maximum number of items per page. 
    $rootScope.searchName = "";
    $rootScope.maloai = '';
    //Khi nhấn button sẽ chuyển đổi chiều sắp xếp
    $rootScope.Chon = function (d) {
        if ($rootScope.direct == "Ascending") {
            $rootScope.reverse = false;
            $rootScope.direct = "Decreasing";
        }
        else {
            $rootScope.reverse = true;
            $rootScope.direct = "Ascending";
        }
    };
    //Lấy sản phẩm hiển thị lên giao diện
    $scope.GetSanPhams = function () {
        var MaLoai = localStorage.getItem("MaLoai");
        if (MaLoai == undefined) {
            MaLoai = "";
        }

        $http.get('/Home/GetProduct',
            {
                params: {
                    maloai: MaLoai, pageIndex: $rootScope.pageIndex, pageSize:
                        $rootScope.pageSize, productName: $rootScope.searchName
                }
            }).then(function (d) {
                $scope.ListSanPham = d.data;
                $rootScope.totalCount = $scope.ListSanPham.totalCount

            }, function (error) { alert('Failed'); });
    };
    $scope.GetSanPhams();
    $scope.SelectLoai = function (l) {
        localStorage.setItem("MaLoai", l);
        $scope.GetSanPhams();
    }

});