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
                alert("Sai tài khoản hoặc mật khẩu");
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
    $scope.savedata = function () {
        $http({
            method: 'POST',
            url: '/Admin/ManagerTypePhone/Register',
            data: $scope.LoaiDT
        }).then(function (d) {
            alert(d.data);
            window.location.href = '/Admin/ManagerTypePhone/ManagerTypePhone';
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

    $scope.updateLoaiDT = function () {
        $http({
            method: 'POST',
            url: '/Admin/ManagerTypePhone/UpdateLoaiDT',
            data: $scope.LoaiDT
        }).then(function (d) {
            window.location.href = '/Admin/ManagerTypePhone/ManagerTypePhone';
        }, function (e) {
            alert('failed');
        });
    };
});
//----------------------------------------Thêm điện thoại-----------------------------------------------------------------------------------
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
            window.location.href = '/Admin/ManagerPhone/ManagerPhone';
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

//----------------------------------------Cập nhật điện thoại-------------------------------------------------------------------------------
//-----------------------------------------------------------------------------------------------------------------------------------

app.controller("UpdatePhone", function ($scope, $http) {
    $scope.LoadPhone = function (id) {
        $http.get("/Admin/ManagerPhone/Get_DienThoai_byid?id=" + id).then(function (d) {
            $scope.Phone = d.data[0];
        }, function (error) {
            alert('Failed');
        });
    }
    $scope.updatephone = function () {
        $http({
            method: 'POST',
            url: '/Admin/ManagerPhone/Update_DienThoai',
            data: $scope.Phone
        }).then(function (d) {
            alert(d.data);
            window.location.href = '/Admin/ManagerPhone/ManagerPhone';
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
    $scope.UnOrder = function (value) {
        $http.get('/Admin/ManagerOrder/UnThisOrder?value=' + value).then(function (d) {
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
        localStorage.setItem('MaDH', val);
              
    };
});
app.controller("vie", function ($scope, $http) {
    $http.get('/Admin/ManagerOrder/View_Details?value=' + localStorage.getItem('MaDH')).then(function (d) {
        $scope.details = d.data;
        console.log(d.data);
    }, function (error) {
            alert('failed');
            console.log($scope.details)
    }); 

})

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
    $scope.Shipping = function (value) {
        $http.get('/Admin/ManagerOrder/ComfirmShipping?value=' + value).then(function (d) {
            alert(d.data);
            $http.get("/Admin/ManagerOrder/Get_Paging_DonHangDaXacThuc?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

                $scope.Spdata = response.data.listdonhang;

                $scope.totalcount = response.data.totalcount;

            }, function (error) {
                alert('failed');
            });
        }, function (error) {
            alert('failed');
        });
    };
    $scope.UnOrder = function (value) {
        $http.get('/Admin/ManagerOrder/UnThisOrder?value=' + value).then(function (d) {
            alert(d.data);
            $http.get("/Admin/ManagerOrder/Get_Paging_DonHangDaXacThuc?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

                $scope.Spdata = response.data.listdonhang;

                $scope.totalcount = response.data.totalcount;

            }, function (error) {
                alert('failed');
            });
        }, function (error) {
            alert('failed');
        });
    };
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
    $scope.Change = function (value) {
        $http.get('/Admin/ManagerOrder/ConfirmChange?value=' + value).then(function (d) {
            alert(d.data);
            $http.get("/Admin/ManagerOrder/Get_Paging_DonHangDaGiao?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

                $scope.Spdata = response.data.listdonhang;

                $scope.totalcount = response.data.totalcount;

            }, function (error) {
                alert('failed');
            });
        }, function (error) {
            alert('failed');
        });
    };
});


app.controller("SupplierController", function ($scope, $http) {
    $scope.maxsize = 5;

    $scope.totalcount = 0;

    $scope.pageIndex = 1;

    $scope.pageSize = 5;

    $scope.searchText = '';
    //----------------------------------------------------------------------------------------------------------------
    $scope.Supplier = function () {

        $http.get("/Admin/ManagerSupplier/Get_Paging_Supplier?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

            $scope.Spdata = response.data.listsupplier;

            $scope.totalcount = response.data.totalcount;

        }, function (error) {
            alert('failed');
        });
    }
    $scope.Supplier();
    $scope.pagechanged = function () {

        $scope.Supplier();

    }
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.Supplier();
    }
    //
    $scope.btntextadd = 'Save';
    $scope.saveSupplier = function () {
        $scope.btntextadd = "Please Wait..";
        $http({
            method: 'POST',
            url: '/Admin/ManagerSupplier/Add_Supplier',
            data: $scope.Supp
        }).then(function (d) {
            alert(d.data);
            window.location.href = '/Admin/ManagerSupplier/Index';
        }, function (e) {
            alert('failed');
        });
    }
    //
    $scope.LoadSupplier = function (id) {
        $http.get("/Admin/ManagerSupplier/Get_SUPPLIER_ByID?MaNCC=" + id).then(function (d) {
            $scope.Sup = d.data;
        }, function (error) {
            alert('Failed');
        });
    }

    $scope.updateSupplier = function () {
        $http({
            method: 'POST',
            url: '/Admin/ManagerSupplier/Update_Supplier',
            data: $scope.Sup
        }).then(function (d) {
            window.location.href = '/Admin/ManagerSupplier/Index';
        }, function (e) {
            alert('failed');
        });
    };
    //
    $scope.deleteSupplier = function (id) {
        $http.get("/Admin/ManagerSupplier/Delete_Supplier?id=" + id).then(function (d) {
            alert(d.data);
            $http.get("/Admin/ManagerSupplier/Get_Paging_Supplier?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

                $scope.Spdata = response.data.listsupplier;
                $scope.totalcount = response.data.totalcount;
            }, function (error) {
                alert('Failed');
            });
        }, function (error) {
            alert('Failed');
        });
    };
});


app.controller("ConfigurationController", function ($scope, $http) {
    $scope.maxsize = 5;

    $scope.totalcount = 0;

    $scope.pageIndex = 1;

    $scope.pageSize = 5;

    $scope.searchText = '';
    //----------------------------------------------------------------------------------------------------------------
    $scope.Confi = function () {

        $http.get("/Admin/ManagerConfiguration/Get_Paging_Confi?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

            $scope.Spdata = response.data.listconfiguration;

            $scope.totalcount = response.data.totalcount;

        }, function (error) {
            alert('failed');
        });
    }
    $scope.Confi();
    $scope.pagechanged = function () {

        $scope.Confi();

    }
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.Confi();
    }
    //
    $http.get('/Admin/ManagerConfiguration/Get_DienThoai_Data').then(function (d) {
        $scope.dataDT = d.data;
    }, function (error) {
        alert('failed');
    })
    //
    $scope.saveConfi = function () {
        $http({
            method: 'POST',
            url: '/Admin/ManagerConfiguration/Add_Configuration',
            data: $scope.confi
        }).then(function (d) {
            alert(d.data);
            window.location.href = '/Admin/ManagerConfiguration/Index';
        }, function (error) {
            alert('Thất bại');
        });
    }
    //
    $scope.LoadConfiguration = function (id) {
        $http.get("/Admin/ManagerConfiguration/Get_Configuration_ByID?MaCauHinh=" + id).then(function (d) {
            $scope.dataconfi = d.data;
        }, function (error) {
            alert('Failed');
        });
    }

    $scope.btnupdate = "Update";
    $scope.updateConfiguration = function () {
        $scope.btnupdate = "Please wait";
        $http({
            method: 'POST',
            url: '/Admin/ManagerConfiguration/Update_Configuration',
            data: $scope.dataconfi
        }).then(function (d) {
            window.location.href = '/Admin/ManagerConfiguration/Index';
        }, function (e) {
            alert('failed');
        });
    };
    //
    $scope.deleteConfiguration = function (id) {
        $http.get("/Admin/ManagerConfiguration/Delete_Configuration?MaCauHinh=" + id).then(function (d) {
            alert(d.data);
            $http.get("/Admin/ManagerConfiguration/Get_Paging_Confi?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

                $scope.Spdata = response.data.listconfiguration;

                $scope.totalcount = response.data.totalcount;

            }, function (error) {
                alert('failed');
            });
        }, function (error) {
            alert('Failed');
        });
    };
});


app.controller("BillImportController", function ($scope, $http) {
    $scope.maxsize = 5;

    $scope.totalcount = 0;

    $scope.pageIndex = 1;

    $scope.pageSize = 5;

    $scope.searchText = '';
    //----------------------------------------------------------------------------------------------------------------
    $scope.Bill = function () {

        $http.get("/Admin/ManagerBillimport/Get_Paging_HoaDonNhap?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

            $scope.billdata = response.data.listbill;

            $scope.totalcount = response.data.totalcount;

        }, function (error) {
            alert('failed');
        });
    }
    $scope.Bill();
    $scope.pagechanged = function () {

        $scope.Bill();

    }
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.Bill();
    }
    //
    $http.get('/Admin/ManagerSupplier/Get_NCC').then(function (d) {
        $scope.dataSup = d.data;
    }, function (error) {
        alert('failed');
    })
    //
    $scope.saveBill = function () {
        $http({
            method: 'POST',
            url: '/Admin/ManagerBillimport/Add_Bill',
            data: $scope.hd
        }).then(function (d) {
            alert(d.data);
            window.location.href = '/Admin/ManagerBillimport/Index';
        }, function (error) {
            alert('Thất bại');
        });
    }
});

app.controller("BillDetailsController", function ($scope, $http) {
    $scope.maxsize = 5;

    $scope.totalcount = 0;

    $scope.pageIndex = 1;

    $scope.pageSize = 5;

    $scope.searchText = '';
    //----------------------------------------------------------------------------------------------------------------
    $scope.Bil = function () {

        $http.get("/Admin/ManagerBillDetails/Get_Paging_CTHoaDonNhap?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

            $scope.detailsdata = response.data.listBill_Details;

            $scope.totalcount = response.data.totalcount;

        }, function (error) {
            alert('failed');
        });
    }
    $scope.Bil();
    $scope.pagechanged = function () {

        $scope.Bil();

    }
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.Bil();
    }
    //
    $scope.save = function () {
        $scope.btntextadd = "Please Wait..";
        $http({
            method: 'POST',
            url: '/Admin/ManagerBillDetails/Add_BillDetails',
            data: $scope.Supp
        }).then(function (d) {
            window.location.href = '/Admin/ManagerBillDetails/Index';
        }, function (e) {
            alert('failed');
        });
    }
    //
    $scope.LoadBill = function (id) {
        $http.get("/Admin/ManagerBillDetails/GET_BillDetails_ID?id=" + id).then(function (d) {
            $scope.bill = d.data[0];
        }, function (error) {
            alert('Failed');
        });
    }

    $scope.updateBill = function () {
        $http({
            method: 'POST',
            url: '/Admin/ManagerBillDetails/Update_BillDetails',
            data: $scope.bill
        }).then(function (d) {
            alert(d.data);
            window.location.href = '/Admin/ManagerBillDetails/Index';
        }, function (e) {
            alert('failed');
        });
    };
    //
    $scope.deleteBill = function (id) {
        $http.get("/Admin/ManagerBillDetails/Delete_BillDetails?id=" + id).then(function (d) {
            alert(d.data);
            $http.get("/Admin/ManagerBillDetails/Get_Paging_CTHoaDonNhap?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

                $scope.detailsdata = response.data.listBill_Details;
                $scope.totalcount = response.data.totalcount;
            }, function (error) {
                alert('Failed');
            });
        }, function (error) {
            alert('Failed');
        });
    };
    $http.get('/Admin/ManagerBillDetails/Get_CauHinh').then(function (d) {
        $scope.ma = d.data;
    }, function (error) {
            alert('failed');
    })
    $http.get('/Admin/ManagerBillDetails/Get_HoaDonNhap').then(function (d) {
        $scope.databill = d.data;
    }, function (error) {
        alert('failed');
    })
});


app.controller("NewsController", function ($scope, $http) {
    $scope.maxsize = 5;

    $scope.totalcount = 0;

    $scope.pageIndex = 1;

    $scope.pageSize = 5;

    $scope.searchText = '';
    //----------------------------------------------------------------------------------------------------------------
    $scope.Bil = function () {

        $http.get("/Admin/ManagerNews/Get_Paging_TinTuc?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

            $scope.datanew = response.data.listnew;

            $scope.totalcount = response.data.totalcount;

        }, function (error) {
            alert('failed');
        });
    }
    $scope.Bil();
    $scope.pagechanged = function () {

        $scope.Bil();

    }
    $scope.changePageSize = function () {
        $scope.pageIndex = 1;
        $scope.Bil();
    }
    //
    $scope.deleteNews = function (id) {
        $http.get("/Admin/ManagerNews/Delete_News?id=" + id).then(function (d) {
            alert(d.data);
            $http.get("/Admin/ManagerNews/Get_Paging_TinTuc?pageindex=" + $scope.pageIndex + "&pagesize=" + $scope.pageSize).then(function (response) {

                $scope.datanew = response.data.listnew;

                $scope.totalcount = response.data.totalcount;

            }, function (error) {
                alert('failed');
            });
        }, function (error) {
            alert('Failed');
        });
    };
    //
    $scope.savedata = function () {
        var object = {
            "tt.TieuDe": $scope.TieuDe,
            "tt.Anh": document.getElementById('anh').files[0].name,
            "tt.NoiDung": $scope.NoiDung,
            "tt.NgayDang": $scope.NgayDang,
        }

        $http({
            method: 'POST',
            url: '/Admin/ManagerNews/Add_News',
            data: object
        }).then(function (d) {

            alert(d.data);
            window.location.href = '/Admin/ManagerNews/Index';
        }, function (e) {
            alert('failed');
        });
    }
    $scope.LoadNews = function (id) {
        $http.get("/Admin/ManagerNews/Get_News_byid?id=" + id).then(function (d) {
            $scope.New = d.data[0];
        }, function (error) {
            alert('Failed');
        });
    }
    $scope.updateNews = function () {
        $http({
            method: 'POST',
            url: '/Admin/ManagerNews/Update_News',
            data: $scope.New
        }).then(function (d) {
            alert(d.data);
            window.location.href = '/Admin/ManagerNews/Index';
        }, function (e) {
            alert('Failed');
        });
    };
});
////////////////////
app.controller("AccountController", function ($rootScope, $scope, $http, $window) {
    $scope.log = true;
    $scope.btntext = "Login";

    $scope.login = function () {

        $scope.btntext = "Please wait..!";

        $http({

            method: "POST",

            url: '/Account/userlogin',

            data: $scope.user

        }).then(function (d) {

            $scope.btntext = 'Login';
            app.run(function ($rootScope) {
                $rootScope.UserName12 = '';
            })
            if (d.data == 1) {


                $http.get("/Admin/Login/get_info_user?taikhoan=" + $scope.user.TaiKhoan).then(function (d) {
                    $scope.infoUser = d.data[0];
                    console.log($scope.infoUser)
                    localStorage.setItem('taikhoan', $scope.infoUser.TaiKhoan);
                    localStorage.setItem('avatar', $scope.infoUser.Avatar);

                    $rootScope.UserName12 = localStorage.getItem('taikhoan')
                    console.log($rootScope.UserName12)
                    location.reload();

                });



                console.log(d.data)
            }
            else {

                alert(d.data);

            }

            //$scope.user = null;

        }), function error() {

            alert('Can not connect to server');

        };

    };

    $(document).ready(function () {
        app.run(function ($rootScope) {
            $rootScope.UserName12 = '';
        })
        $rootScope.UserName12 = localStorage.getItem('taikhoan')
        var a = localStorage.getItem('taikhoan')
        if (a != null) {
            $('#cart-block').css('display', 'none')
            $('#infoUser').css('display', 'block')
        }
        else {
            $('#cart-block').css('display', 'block')
            $('#infoUser').css('display', 'none')
        }
    });
    dangxuat = function () {
        localStorage.removeItem('taikhoan');
        localStorage.removeItem('avatar');
        $('#cart-block').css('display', 'block')
        $('#infoUser').css('display', 'none')
    }
    $scope.btntext = "Save";

    $scope.savedata = function () {
        $scope.btntext = "Please Wait....";
        $scope.register.Avatar = '';
        $scope.register.HoTen = '';
        $scope.register.DiaChi = '';
        $scope.register.Email = '';
        $scope.register.Sodienthoai = '';
        $scope.register.RoleId = 2;
        console.log($scope.register)
        $http({
            method: 'POST',
            url: '/Account/Register_User',
            data: $scope.register
        }).then(function (d) {

            alert(d.data);
        }),
            function error() {

                alert('Can not connect to server');

            };
    };


})


app.controller("DashBoard", function ($scope, $http) {
    $http.get('/Admin/ManagerTypePhone/Get_LoaiDT').then(function (response) {
        $scope.totalcount = response.data;
        var counttype = 0;
        for (var i = 0; i < response.data.length; i++) {
            counttype = counttype + 1;
        }
        $scope.type = counttype;
        console.log($scope.type);
    }, function (error) {
        alert('failed');
    });
});