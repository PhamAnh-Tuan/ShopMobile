/// <reference path="../../../../scripts/angular.min.js" />
var app = angular.module('Homeapp', []);
/*======================================================================================================================================*/
app.controller("HomeClient", function ($rootScope,$scope, $http) {
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
                window.location.href = '/Home/Index';
            }
            else {
                alert(d);
            }
            $scope.user = null;
        }).error(function () {
            alert('failed');
        })
    }

        // displayCart
    //function($rootScope, $scope, $http) {
    //    $rootScope.AddCart = function (s) {
    //        $http({
    //            method: 'POST',
    //            datatype: 'json',
    //            url: 'GioHang/AddCart',
    //            data: JSON.stringify(s)
    //        }).then(function (d) {
    //            if (d.data.ctdon != null) {
    //                $rootScope.dsDonHang.push(d.data.ctdon);

    //            }
    //            else
    //                for (var i = 0; i < $rootScope.dsDonHang.length; i++)
    //                    if ($rootScope.dsDonHang[i].MaDienThoai == s.MaDienThoai) {
    //                        $rootScope.dsDonHang[i].SoLuong = $rootScope.dsDonHang[i].SoLuong + 1;
    //                    }
    //            $rootScope.SoLuong = d.data.sl;

    //        }, function () { alert("failed"); });
    //    }
    //}
    $rootScope.dsDonHang = null;
    $rootScope.GetCart = function () {
        $http.get('/GioHang/GetCarts').then(function (d) {
            $rootScope.dsDonHang = d.data.dsDonHang;
            $rootScope.SoLuong = d.data.SoLuong;
            $rootScope.Thanhtien = d.data.Thanhtien;
        }, function (e) { });
    };
});


app.controller("SanphamController", function ($scope, $http) {
    $http.get("/LoaiDienThoai/Get_DienThoai_byMaLoai").then(function (d) {
            $scope.typephone = d.data;
            
        }, function (error) {
            alert('failed');
        });
});

app.controller("DetailsController", function ($scope, $http) {
    $http.get("/DienThoai/get_chitiet").then(function (d) {
        $scope.details = d.data;

    }, function (error) {
        alert('failed');
    });
});



