/// <reference path="../../../../scripts/angular.min.js" />


var app = angular.module("Homeapp", ['ui.bootstrap']);

app.controller("HomeController", function ($scope, $http) {
    $scope.maxsize = 5;

    $scope.totalcount = 0;

    $scope.pageIndex = 1;

    $scope.pageSize = 5;

    $scope.searchText = '';
    //----------------------------------------------------------------------------------------------------------------
    $scope.SPLisst = function () {

        $http.get("/Admin/ManagerTypePhone/get_data?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

            $scope.Spdata = response.data.registerdata;

            $scope.totalcount = response.data.totalcount;

        }, function (error) {
            alert('failed');
        });
    }
    $scope.SPLisst();
    $scope.pagechanged = function () {

        $scope.SPLisst();

    }
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.SPLisst();
    }
    //----------------------------------------------------------------------------------------------------------------

    $scope.DTList = function () {
        $http.get("/Admin/ManagerPhone/Get_Paging_DienThoai?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {
            $scope.DTdata = response.data.listphone;
            $scope.totalcount = response.data.totalcount;
        }, function (error) {
            alert('failed');
        });
    }
    $scope.DTList();
    $scope.pagechangedsp = function () {
        $scope.DTList();
    }
    $scope.changePageSizesp = function () {
        $scope.pageIndex = 1;
        $scope.DTList();
    }
    //------------------------------------Xóa loại điện thoại----------------------------------------------------------------------------
    //$scope.deleteLoaiDT = function (id) {
    //    $http.get("/Admin/ManagerTypePhone/DeleteLoaiDT?id=" + id).then(function (d) {
    //        alert(d.data);
    //        $http.get("/Admin/ManagerTypePhone/get_data").then(function (d) {
    //            $scope.record = d.data;
    //        }, function (error) {
    //            alert('Deleted');
    //            $http.get("/Admin/ManagerTypePhone/get_data?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

    //                $scope.Spdata = response.data.registerdata;

    //                $scope.totalcount = response.data.totalcount;

    //            }, function (error) {
    //                alert('failed');
    //            });
    //        });
    //    }, function (error) {
    //        alert('Failed');
    //    });
    //};
    $scope.deleteLoaiDT = function (id) {
        $http.get("/Admin/ManagerTypePhone/DeleteLoaiDT?id=" + id).then(function (d) {
            alert(d.data);
            $http.get("/Admin/ManagerTypePhone/get_data?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {
                $scope.record = d.data;
                $scope.Spdata = response.data.registerdata;
                $scope.totalcount = response.data.totalcount;
            }, function (error) {
                alert('Failed');
            });
        }, function (error) {
            alert('Failed');
        });
    };
    //------------------------------------Xóa điện thoại----------------------------------------------------------------------------
    $scope.deleteDT = function (id) {
        $http.get("/Admin/ManagerPhone/Delete_DienThoai?id=" + id).then(function (d) {
            alert(d.data);
            $http.get("/Admin/ManagerPhone/Get_Paging_DienThoai?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {
                $scope.record = d.data;
                $scope.DTdata = response.data.listphone;
                $scope.totalcount = response.data.totalcount;
            }, function (error) {
                alert('Failed');
            });
        }, function (error) {
            alert('Failed');
        });
    };
    //------------------------------------Login Admin----------------------------------------------------------------------------

    $scope.btntext = "Login";

    $scope.login = function () {

        $scope.btntext = "Please wait..!";

        $http({

            method: "POST",

            url: '/Admin/Admin/LoginAdmin',

            data: $scope.user

        }).then(function (d) {

            $scope.btntext = 'Login';

            if (d != null) {
                window.location.href = '/Admin/ManagerTypePhone/ManagerTypePhone';
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
//----------------------------------------Thêm loại điện thoại------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------------------------
app.controller("AddTypePhone", function ($scope, $http) {
    $scope.btntextadd = 'Save';
    $scope.savedata = function () {
        $scope.btntextadd = "Please Wait..";
        $http({
            method: 'POST',
            url: '/Admin/ManagerTypePhone/Register',
            data: $scope.LoaiDT
        }).then(function (d) {
            $scope.LoaiDT = null;
            $scope.btntextadd = 'Save';
            alert('Data registred..');
            $http.get("/Admin/ManagerTypePhone/get_data?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

                $scope.Spdata = response.data.registerdata;
                $scope.totalcount = response.data.totalcount;


            }, function (error) {

            });
        }, function (e) {
            alert('failed');
        });

    }
});

//----------------------------------------Update loại điện thoại------------------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------------------------------------
app.controller("UpdateTypePhone", function ($scope, $http) {
    $scope.LoadLoaiDT = function (id) {
        $http.get("/Admin/ManagerTypePhone/Get_LoaiDTbyid?id=" + id).then(function (d) {
            $scope.LoaiDT = d.data[0];
        }, function (error) {
            alert('Failed');
        });
    }

    $scope.btnupdate = "Update";
    $scope.updateLoaiDT = function () {
        $scope.btnupdate = "Please wait";
        $http({
            method: 'POST',
            url: '/Admin/ManagerTypePhone/UpdateLoaiDT',
            data: $scope.LoaiDT
        }).then(function (d) {
            $scope.btnupdate = "Update";
            $scope.LoaiDT = null;
            alert(d);

        }, function (e) {
            alert('failed');
        });
    };
});
//-----------------------------Thêm điện thoại-----------------------------------------------------------------------------------
//-------------------------------------------------------------------------------------------------------------------------------
app.controller("AddPhone", function ($scope, $http) {

    $scope.btntextadd = 'Save';
    $scope.savedata = function () {
        $scope.btntextadd = "Please Wait..";
        var object = {
            "dt.TenDienThoai": $scope.TenDienThoai,
            "dt.MaLoai": $scope.MaLoai,
            "dt.HinhAnh": document.getElementById('anh').files[0].name,
            "dt.KichThuocManHinh": $scope.KichThuocManHinh,
            "dt.DoPhanGiai": $scope.DoPhanGiai,
            "dt.HeDieuHanh": $scope.HeDieuHanh,
            "dt.ChipXuLy": $scope.ChipXuLy,
            "dt.CameraSau": $scope.CameraSau,
            "dt.CameraTruoc": $scope.CameraTruoc,
            "dt.DungLuongPin": $scope.DungLuongPin,
            "dt.TheSim": $scope.TheSim,
        }

        $http({
            method: 'POST',
            url: '/Admin/ManagerPhone/Register',
            data: object
        }).then(function () {
            $scope.Phone = null;
            $scope.btntextadd = 'Save';

            alert('Data registed..');
            window.history.back();
            $http.get("/Admin/ManagerPhone/Get_Paging_DienThoai?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

                $scope.Spdata = response.data.listphone;

                $scope.totalcount = response.data.totalcount;

            }, function (error) {

            });
        }, function (e) {
            alert('failed');
        });

    }
    $http.get('/Admin/ManagerTypePhone/Get_LoaiDT').then(function (d) {
        $scope.regdata = d.data;
    }, function (error) {
        alert('failed');
    });

});

//---------------------------------Cập nhật điện thoại-------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------

app.controller("UpdatePhone", function ($scope, $http) {
    $scope.LoadPhone = function (id) {
        $http.get("/Admin/ManagerPhone/Get_DienThoai_byid?id=" + id).then(function (d) {
            $scope.Phone = d.data[0];
        }, function (error) {
            alert('Failed');
        });
    }
    $scope.btnphone = "Update";
    $scope.updatephone = function () {
        $scope.btnphone = "Please wait";
        $http({
            method: 'POST',
            url: '/Admin/ManagerPhone/Update_DienThoai',
            data: $scope.Phone
        }).then(function (d) {
            $scope.btnphone = "Update";
            $scope.Phone = null;
            alert(d.data);
        }, function (e) {
            alert('Failed');
        });
    };
});
//----------------------------------------------------------------------------------------------------------------
//----------------------------------------------------------------------------------------------------------------

//app.controller("SanPhamController", function ($scope, $http, Upload, $timeout, $document) {
//    $scope.UploadFiles = function (file, kieu) {
//        $scope.SelectedFile = file;
//        if ($scope.SelectedFile && $scope.SelectedFile.length) {
//            Upload.upload({
//                url: 'Admin/ManagerPhone/Upload',
//                data: { files: $scope.SelectedFile, anh: $scope.sp.anh }
//            }).then(function (d) {
//                if (kieu == 'Anh') { $scope.sp.anh = d.data[0]; }
//                else { $scope.sp.AnhTo = d.data[0]; }
//            }, function (error) { alert('loi'); });
//        }
//    }
//});
//----------------------------------------------------------------------------------------------------------------
//Đơn hàng chưa xác thực
app.controller("OrderNotComfirmController", function ($scope, $http) {
    $scope.maxsize = 5;

    $scope.totalcount = 0;

    $scope.pageIndex = 1;

    $scope.pageSize = 5;

    $scope.searchText = '';
    //----------------------------------------------------------------------------------------------------------------
    $scope.NotComfirm = function () {

        $http.get("/Admin/ManagerOrder/Get_Paging_DonHangChuaXacThuc?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

            $scope.Spdata = response.data.listdonhang;

            $scope.totalcount = response.data.totalcount;

        }, function (error) {
            alert('failed');
        });
    }
    $scope.NotComfirm();
    $scope.pagechanged = function () {

        $scope.NotComfirm();

    }
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.NotComfirm();
    }


    $scope.Comfirm = function (value) {
        $http.get('/Admin/ManagerOrder/Comfirm_ThisOrder?value=' + value).then(function (d) {
            alert(d.data);
            $http.get("/Admin/ManagerOrder/Get_Paging_DonHangChuaXacThuc?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

                $scope.Spdata = response.data.listdonhang;

                $scope.totalcount = response.data.totalcount;

            }, function (error) {
                alert('failed');
            });
        }, function (error) {
            alert('failed');
        });
    };
    $scope.View = function (val) {
        $("#view").show();
        $http.get('/Admin/ManagerOrder/View_Details?value=' + val).then(function (d) {
            $scope.details = d.data;
            alert(details);
        }, function (error) {
            alert('failed');
        });
        
    };
});

//----------------------------------------------------------------------------------------------------------------
app.controller("OrderComfirmController", function ($scope, $http) {
    $scope.maxsize = 5;

    $scope.totalcount = 0;

    $scope.pageIndex = 1;

    $scope.pageSize = 5;

    $scope.searchText = '';
    //----------------------------------------------------------------------------------------------------------------
    $scope.Comfirm = function () {

        $http.get("/Admin/ManagerOrder/Get_Paging_DonHangDaXacThuc?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

            $scope.Spdata = response.data.listdonhang;

            $scope.totalcount = response.data.totalcount;

        }, function (error) {
            alert('failed');
        });
    }
    $scope.Comfirm();
    $scope.pagechanged = function () {

        $scope.Comfirm();

    }
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.Comfirm();
    }
});
//----------------------------------------------------------------------------------------------------------------
app.controller("OrderDeliveredController", function ($scope, $http) {
    $scope.maxsize = 5;

    $scope.totalcount = 0;

    $scope.pageIndex = 1;

    $scope.pageSize = 5;

    $scope.searchText = '';
    //----------------------------------------------------------------------------------------------------------------
    $scope.Delivered = function () {

        $http.get("/Admin/ManagerOrder/Get_Paging_DonHangDaGiao?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

            $scope.Spdata = response.data.listdonhang;

            $scope.totalcount = response.data.totalcount;

        }, function (error) {
            alert('failed');
        });
    }
    $scope.Delivered();
    $scope.pagechanged = function () {

        $scope.Delivered();

    }
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.Delivered();
    }
});