(function() {
    $(function () {
        $('#datetimepicker').datetimepicker({
            format: 'yyyy-mm-dd',
            minView: "month",
            language: 'zh-CN',
            todayBtn: 1,
            autoclose:1
        });
        var _comserver = abp.services.app.complays;
        var _$modal = $("#ComplayCreateModal");
        var _$form = _$modal.find("form");
        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();
            if (!_$form.valid()) {
                return;
            }
            var _comeditdto = _$form.serializeFormToObject();
            var Adde = {};
            Adde.Complays = {};
            Adde.Complays.NameTXT = _comeditdto.NameTXT;

            Adde.Complays.OverTime = _comeditdto.OverTime;
            Adde.Complays.Id = _comeditdto.Id;      

            abp.ui.setBusy(_$modal);
            _comserver.createOrUpdate(Adde).done(function () {
                //隐藏模态框

                _$modal.modal('hide');

                //刷新页面

                refreshpersonlist();
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });

        $("#RefreshButton").click(function () {

            refreshpersonlist();

        });

        function refreshpersonlist() {

            location.reload();

        }


        $(".edit-Complays").click(function (e) {

            e.preventDefault();

            var personid = $(this).attr("data-Complay-id");

            _comserver.getById({ id: personid }).done(function (ret) {

                $("input[name=Id]").val(ret.id);

                $("input[name=NameTXT]").val(ret.nameTXT).parent().addClass("focused");

                $("input[name=OverTime]").val(ret.overTime).parent().addClass("focused");

                //$("input[name=EmailAddress]").val(ret.person.emailAddress).parent().addClass("focused");

                //$("input[name=PhonNumber]").val(ret.person.phoneNumbers[0].number).parent().addClass("focused");

                //$("select[name=PhoneNumberType]").selectpicker('val', ret.person.phoneNumbers[0].type);



            });

        });


        //$("#ComplayCreateModal").on("hide.bs.modal", function () {
        //    _$form[0].reset();
        //    $("input").parent().removeClass("focused");
        //})
        
    });

})();