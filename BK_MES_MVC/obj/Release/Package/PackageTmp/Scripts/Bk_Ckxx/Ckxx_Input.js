$(function () {
    $('#appform').bootstrapValidator({
        message: 'This value is not valid',
        feedbackIcons: {
            valid: 'glyphicon glyphicon-ok',
            invalid: 'glyphicon glyphicon-remove',
            validating: 'glyphicon glyphicon-refresh'
        },
        fields: {
             zl: {
                validators: {
                    notEmpty: {
                        message: '重量不能为空'
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
  
});
