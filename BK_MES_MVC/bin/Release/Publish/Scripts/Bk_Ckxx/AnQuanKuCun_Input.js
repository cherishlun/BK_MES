$(function () {
    $('#appform').bootstrapValidator({
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
            cpbm: {
                validators: {
                    notEmpty: {
                        message: '产品不能为空'
                    }
                }
            }
            , gh: {
                validators: {
                    notEmpty: {
                        message: '钢号不能为空'
                    }
                }
            }
            , gg: {
                validators: {
                    notEmpty: {
                        message: '规格不能为空'
                    }
                }
            }
            , zb: {
                validators: {
                    notEmpty: {
                        message: '组别不能为空'
                    }
                }
            }
            , aqkczl: {
                validators: {
                    notEmpty: {
                        message: '安全库存量不能为空'
                    }
                    , number: {
                        message: "输入数字"

                    }
                    , greaterThan: {
                        value: 1,
                        message: '最小输入1'
                    }
                }
            }
        }
    });

    var options = {
        success: function (data) {
            swal(data.info, data.mess, data.status == 1 ? "success" : "error");
            if (data.status == 1) {
                ModalHide();
            }
        },
        error: function (result) {
            swal("数据保存失败！", result.responseText.substring(0, 100), "error");
        }
    };


    $("#btn_save").click(function () {
        $("#appform").bootstrapValidator('validate');
        var bootstrapValidator = $("#appform").data('bootstrapValidator');
        bootstrapValidator.validate();
        if (bootstrapValidator.isValid()) {
            swal({
                title: "保存确认"
                , text: "是否保存数据？"
                , type: "info"
                , cancelButtonText: "取消"
                , confirmButtonText: "保存！"
                , showCancelButton: true
                , closeOnConfirm: false
                , showLoaderOnConfirm: true,
            }, function () {
                $("#appform").ajaxSubmit(options);
            });
        }
    });

    $('#cpbm').selectpicker({});
});
