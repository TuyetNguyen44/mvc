var homeapp = angular.module("MyApp", [])
homeapp.controller("SanPhamController", function ($scope, $http) {
    $http.get('/SanPhamLoaiA/GetSanPham').then(function (d) {
        $scope.ListSanPham = d.data;
    }, function (error) { alert("failed"); });
});