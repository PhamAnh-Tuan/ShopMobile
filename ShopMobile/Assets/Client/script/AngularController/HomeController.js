

var app = angular.module('Homeapp', ['ui.bootstrap']);
/*======================================================================================================================================*/
app.controller("HomeClient", function ($rootScope, $scope, $http) {
    $http.get('/home/get_loaidt').then(function (d) {
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
            localStorage.setItem('TaiKhoan', d.data.TaiKhoanDangNhap);
            localStorage.setItem('MatKhau', d.data.MatKhau);
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
    $scope.AddCart= function (mch, giaban) {
        var data = {

            taikhoan: localStorage.getItem('TaiKhoan'),

            matkhau: localStorage.getItem('MatKhau'),
        };
        //chưa đăng nhập
        if (data.taikhoan === null && data.matkhau === null) {
            window.location.href = '/KhachHang/Login';
        }
        //trường hợp đăng nhập thường
        else {
            var gh = {
                MaKhachHang: localStorage.getItem("MaKH"),
                MaCauHinh: mch,
                DonGia: giaban,
                SoLuong: 1
            }
            $http({
                method: 'POST',
                url: '/GioHang/Add_To_Cart',
                data: gh
            }).then(function successCallback(response) {
                console.log(response);
            })
        }
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
            $scope.viewby = 5;
            $scope.totalItems = $scope.typephone.length;
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
        }
    }, function (error) {
        alert('failed');
    });
});
///
app.controller("SettingController", function ($scope, $http) {
    $scope.log = true;
    if (localStorage.getItem("TaiKhoan") != null) {
        $scope.log = false;
        $scope.tk = true;
        $scope.taikhoan = localStorage.getItem("TaiKhoan")

    }
    $http.get('/KhachHang/Get_Info?TK=' + localStorage.getItem('TaiKhoan')).then(function (d) {
        localStorage.setItem('MaKH', d.data.MaKhachHang);
    }, function (error) {
        alert('failed');
    })
    $http.get('/GioHang/Get_Cart?MaKhach=' + localStorage.getItem('MaKH')).then(function (d) {
        $scope.datacar = d.data;
        var c = 0;
        for (var i = 0; i < d.data.length; i++) {
            c = c + 1;
        }
        $scope.coun = c;
    }, function (error) {
        alert('failed');
    })
})
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
    $scope.loadrecord = function (name) {

        $scope.name = location.search.substr(6).toString();
        console.log($scope.name)
        $http.get("/DienThoai/Search_Product?name=" + $scope.name).then(function (d) {
            $scope.SanPham = d.data;

            $scope.viewby = 5;
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
///
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
///
app.controller("NewsController", function ($scope, $http) {
    $http.get('/TinTuc/get_TinTuc').then(function (d) {
        $scope.news = d.data;
    }, function (error) {
        alert('failed');
    })

});
///
app.controller("ViewNewsController", function ($scope, $http) {
    $scope.viewTinTuc = function (news) {
        $http.get('/TinTuc/Details_TinTuc?id=' + news).then(function (d) {
            $scope.views = d.data;
        }, function (error) {
            alert('failed');
        })
    }

});
///
app.controller("GioHangController", function ($scope, $http) {
    $http.get('/KhachHang/Get_Info?TK=' + localStorage.getItem('TaiKhoan')).then(function (d) {
        localStorage.setItem('MaKH', d.data.MaKhachHang);
    }, function (error) {
        alert('failed');
    })
    $http.get('/GioHang/Get_Cart?MaKhach=' + localStorage.getItem('MaKH')).then(function (d) {
        $scope.datacart = d.data;
        var tt = 0;
        for (var i = 0; i < d.data.length; i++) {
            tt = Number(d.data[i].SoLuong * d.data[i].DonGia);
        }
        var x = Number(tt);
        $scope.tongtien = x;
        console.log($scope.tongtien)
    }, function (error) {
        alert('failed');
    })
    $scope.countasc = function (id) {
        $http.get('/GioHang/Cart_ASC?MaCT=' + id).then(function () {
            $http.get('/GioHang/Get_Cart?MaKhach=' + localStorage.getItem('MaKH')).then(function (d) {
                $scope.datacart = d.data;
                var tt = 0;
                for (var i = 0; i <= d.data.length; i++) {
                    tt = Number(d.data[i].SoLuong * d.data[i].DonGia);
                }
                var x = Number(tt);
                $scope.tongtien = x;
            }, function (error) {
                alert('failed');
            })
        }, function (error) {
            alert('failed');
        });
    };
    $scope.countdesc = function (id) {
        $http.get('/GioHang/Cart_DESC?MaCT=' + id).then(function () {
            $http.get('/GioHang/Get_Cart?MaKhach=' + localStorage.getItem('MaKH')).then(function (d) {
                $scope.datacart = d.data;
            }, function (error) {
                alert('failed');
            })
        }, function (error) {
            alert('failed');
        });
    };
    $scope.deleteproduct = function (id) {
        $http.get('/GioHang/DELETE_PRODUCTCART?MaCT=' + id).then(function () {
            $http.get('/GioHang/Get_Cart?MaKhach=' + localStorage.getItem('MaKH')).then(function (d) {
                $scope.datacart = d.data;
            }, function (error) {
                alert('failed');
            })
        }, function (error) {
            alert('failed');
        });
    };
});
///
app.controller("PayController", function ($scope, $http, $rootScope) {
    $http.get('/KhachHang/Get_Info?TK=' + localStorage.getItem('TaiKhoan')).then(function (d) {
        $scope.thongtin = d.data;
    }, function (error) {
        alert('failed');
    })
    $http.get('/GioHang/Get_Cart?MaKhach=' + localStorage.getItem('MaKH')).then(function (d) {
        $scope.datacart = d.data;
        $rootScope.cart = d.data;
        localStorage.setItem('sp', angular.toJson($rootScope.cart));
        
        var tt = 0;
        for (var i = 0; i < d.data.length; i++) {
            tt = Number(d.data[i].SoLuong * d.data[i].DonGia);
        }
        var x = Number(tt);
        $scope.tongtien = x;
        localStorage.setItem('tongtien', x);
        $scope.datacar = d.data;
        var c = 0;
        for (var i = 0; i < d.data.length; i++) {
            c = c + 1;
        }
        $scope.coun = c;
    }, function (error) {
        alert('failed');
    })

    $scope.checkOut = function () {
        var a = new Date();
        var b = a.getTime();
        localStorage.setItem('maddh', b);
        var currentdate = new Date();
        var datetime = currentdate.getMonth() + "/"
            + (currentdate.getDate()) + "/"
            + currentdate.getFullYear()

        $http({
            method: 'POST',
            url: '/ThanhToan/Add_DonHang',
            data: {
                MaDonHang: 'DH' + localStorage.getItem('MaKH') + localStorage.getItem('maddh'),
                MaKhachHang: localStorage.getItem('MaKH'),
                NgayTao: datetime,
                TrangThaiDonHang: 'Chưa xác nhận',              
                TongTien: localStorage.getItem('tongtien'),
                TenKhachHang: $scope.thongtin.TenKhachHang,
                DiaChi: $scope.thongtin.SDT,
                SDT: $scope.thongtin.DiaChi,
                GhiChu: document.getElementById('comment').value,
            }
        }).then(function () {

            var sp = JSON.parse(localStorage.getItem('sp'));
           
            for (var i = 0; i < sp.length; i++) {
                $http({
                    method: 'POST',
                    url: '/ThanhToan/Add_ChiTietDonHang',
                    data: {
                        MaDonHang: 'DH' + localStorage.getItem('MaKH') + localStorage.getItem('maddh'),
                        MaCauHinh: sp[i].MaCauHinh,
                        SoLuong: sp[i].SoLuong,
                        DonGia: sp[i].DonGia,
                    }
                }).then(function (d) {
                    
                    $http.get('/Admin/GioHang/delete_GioHangByID?id=' + localStorage.getItem('ID')).then(function (d) {
                    })
                })
            }
            localStorage.removeItem('sp');
            alert('Chúc mừng bạn thanh toán thành công');
            window.location.href = '/Home/Index'
        })


    };
});
///
app.controller("RegisterController", function ($scope, $http) {
    $scope.register = function () {
        $http({
            method: 'POST',
            url: '/KhachHang/Register',
            data: $scope.kh
        }).then(function (d) {
            alert('Đăng ký thành công');
            window.location.href = '/Home/Index';
        }, function (e) {
            alert('failed');
        });

    }
});
///



