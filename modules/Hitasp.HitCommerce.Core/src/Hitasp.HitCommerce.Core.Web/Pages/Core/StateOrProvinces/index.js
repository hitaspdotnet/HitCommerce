$(function () {
    var l = abp.localization.getResource("Core");
	
	var stateOrProvinceService = window.hitasp.hitCommerce.core.stateOrProvinces.stateOrProvince;
	
        var lastNpIdId = '';
        var lastNpDisplayNameId = '';

        var _lookupModal = new abp.ModalManager({
            viewUrl: abp.appPath + "Shared/LookupModal",
            scriptUrl: "/Pages/Shared/lookupModal.js",
            modalClass: "navigationPropertyLookup"
        });

        $('.lookupCleanButton').on('click', '', function () {
            $(this).parent().parent().find('input').val('');
        });

        _lookupModal.onClose(function () {
            var modal = $(_lookupModal.getModal());
            $('#' + lastNpIdId).val(modal.find('#CurrentLookupId').val());
            $('#' + lastNpDisplayNameId).val(modal.find('#CurrentLookupDisplayName').val());
        });
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Core/StateOrProvinces/CreateModal",
        scriptUrl: "/Pages/Core/StateOrProvinces/createModal.js",
        modalClass: "stateOrProvinceCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Core/StateOrProvinces/EditModal",
        scriptUrl: "/Pages/Core/StateOrProvinces/editModal.js",
        modalClass: "stateOrProvinceEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            name: $("#NameFilter").val(),
			code3: $("#Code3Filter").val(),
			type: $("#TypeFilter").val(),
			countryId: $("#CountryIdFilter").val()
        };
    };

    var dataTable = $("#StateOrProvincesTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(stateOrProvinceService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('Core.StateOrProvinces.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.stateOrProvince.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('Core.StateOrProvinces.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    stateOrProvinceService.delete(data.record.stateOrProvince.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "stateOrProvince.name" },
			{ data: "stateOrProvince.code3" },
			{ data: "stateOrProvince.type" },
            {
                data: "country.name",
                defaultContent : ""
            }
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewStateOrProvinceButton").click(function (e) {
        e.preventDefault();
        createModal.open();
    });

	$("#SearchForm").submit(function (e) {
        e.preventDefault();
        dataTable.ajax.reload();
    });

    $('#AdvancedFilterSectionToggler').on('click', function (e) {
        $('#AdvancedFilterSection').toggle();
    });

    $('#AdvancedFilterSection').on('keypress', function (e) {
        if (e.which === 13) {
            dataTable.ajax.reload();
        }
    });

    $('#AdvancedFilterSection select').change(function() {
        dataTable.ajax.reload();
    });
});
