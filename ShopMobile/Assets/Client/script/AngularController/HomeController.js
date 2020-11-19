/// <reference path="../../../../scripts/angular.min.js" />
var app = angular.module('Homeapp', []);
/*======================================================================================================================================*/
app.controller("HomeClient", function ($scope, $http) {
    $http.get('/Home/Get_LoaiDT').then(function (d) {
        $scope.regdata = d.data;
    }, function (error) {
        alert('failed');
    });

    $http.get('/Home/Get_DienThoai10').then(function (d) {
        $scope.dataphone = d.data;
        $scope.dataphone1 = d.data[0];
    }, function (error) {
        alert('failed');
    });

    
    $scope.btntext = "Login";
    $scope.login = function () {
        $scope.btntext = "Please wait..!";
        $http({
            method: "POST",
            url: '/KhachHang/LoginClient',
            data: $scope.user
        }).then(function (d) {
            $scope.btntext = 'Login';
            if (d != null) {
                window.location.href = '/Home/Home';
            }
            else {
                alert(d);
            }
            $scope.user = null;
        }).error(function () {
            alert('failed');
        })
    }
});


app.controller("SanphamController", function ($scope, $http) {
$http.get("/LoaiDienThoai/Get_DienThoai_byMaLoai").then(function (d) {
            $scope.typephone = d.data;
            
        }, function (error) {
            alert('failed');
        });

});