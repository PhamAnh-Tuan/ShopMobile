/// <reference path="../../../../scripts/angular.min.js" />
/// <reference path="../../../../scripts/dirpagination.js" />


var app = angular.module('Homeapp', ['angularUtils.directives.dirPagination']);
/*======================================================================================================================================*/
app.controller("HomeClient", function ($rootScope, $scope, $http) {
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

});


app.controller("SanphamController", function ($scope, $http) {
    $http.get("/LoaiDienThoai/Get_DienThoai_byMaLoai").then(function (d) {
        if (d.data.length >= 1) {
            $scope.typephone = d.data;
            $scope.sort = function (keyname) {
                $scope.sortKey = keyname;   //set the sortKey to the param passed
                $scope.reverse = !$scope.reverse; //if true make it false and vice versa
            }
        }
    }, function (error) {
        alert('failed');
    });
});


///
app.controller("SearchController", function ($scope, $http) {
    $scope.name = '';
    $scope.changevalue = function () {
        $scope.name1 = document.getElementById("name").value;
        $scope.name = $scope.name1.replaceAll(' ', '_');
        console.log($scope.name1)
        console.log($scope.name)
        return $scope.name;
    }
    console.log($scope.name)
    $scope.loadrecord = function (name) {

        $scope.name = location.search.substr(6).toString();
        console.log($scope.name)
        $http.get("/DienThoai/Search_Product?name=" + $scope.name).then(function (d) {
            $scope.SanPham = d.data;

            $scope.viewby = 6;
            $scope.totalItems = $scope.SanPham.length;
            $scope.currentPage = 1;
            $scope.itemsPerPage = $scope.viewby;
            $scope.maxSize = 5;

            $scope.setPage = function (pageNo) {
                $scope.currentPage = pageNo;
            };

            $scope.setItemsPerPage = function (num) {
                $scope.itemsPerPage = num;
                $scope.currentPage = 1;
            }
        }, function (error) {

            alert('Failed');

        });

    };
});
///
app.controller("DetailsController", function ($scope, $http) {
    $scope.name = location
    $scope.Loadetails = function (details) {
        $http.get("/DienThoai/get_chitiet?details=" + details).then(function (d) {
            $scope.details = d.data;

        }, function (error) {
            alert('failed');
        });
    }
});
app.controller("RegisterController", function ($scope, $http) {
    $scope.Regis = function () {
        $http({
            method: 'POST',
            url: '/KhachHang/Register',
            data: $scope.regis
        }).then(function () {
            $scope.regis;
            window.history.back();
        })
    }
});
app.controller("NewsController", function ($scope, $http) {
    $http.get('/TinTuc/get_TinTuc').then(function (d) {
        $scope.news = d.data;
    }, function (error) {
        alert('failed');
    })

});
app.controller("ViewNewsController", function ($scope, $http) {
    $scope.viewTinTuc = function (news) {
        $http.get('/TinTuc/Details_TinTuc?id=' + news).then(function (d) {
            $scope.views = d.data;
        }, function (error) {
            alert('failed');
        })
    }

});
app.controller("GioHangController", function ($rootScope, $scope, $http) {
    $rootScope.AddCart = function (s) {
        $http({
            method: 'POST',
            datatype: 'json',
            url: '/GioHang/AddCart',
            data: JSON.stringify(s)
        }).then(function (d) {
            if (d.data.ctdon != null) {
                $rootScope.dsDonHang.push(d.data.ctdon);

            }
            else
                for (var i = 0; i < $rootScope.dsDonHang.length; i++)
                    if ($rootScope.dsDonHang[i].MaCauHinh == s.MaCauHinh) {
                        $rootScope.dsDonHang[i].SoLuong = $rootScope.dsDonHang[i].SoLuong + 1;
                    }
            $rootScope.SoLuong = d.data.sl;

        }, function () { alert("failed"); });
    }
    $rootScope.GetCart = function () {
        $http.get('/GioHang/GetCarts').then(function (d) {
            $rootScope.dsDonHang = d.data.DSDonHang;
            $rootScope.SoLuong = d.data.soluong;
            $rootScope.ThanhTien = d.data.ThanhTien
        }, function (e) { });
    };
});


