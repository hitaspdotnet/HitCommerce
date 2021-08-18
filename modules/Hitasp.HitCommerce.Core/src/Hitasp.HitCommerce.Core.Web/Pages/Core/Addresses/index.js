$(function () {
    var l = abp.localization.getResource("Core");

    var addressService = window.hitasp.hitCommerce.core.addresses.address;

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
        viewUrl: abp.appPath + "Core/Addresses/CreateModal",
        scriptUrl: "/Pages/Core/Addresses/createModal.js",
        modalClass: "addressCreate"
    });

    var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Core/Addresses/EditModal",
        scriptUrl: "/Pages/Core/Addresses/editModal.js",
        modalClass: "addressEdit"
    });

    var getFilter = function () {
        return {
            filterText: $("#FilterText").val(),
            contactName: $("#ContactNameFilter").val(),
            phone: $("#PhoneFilter").val(),
            addressLine1: $("#AddressLine1Filter").val(),
            addressLine2: $("#AddressLine2Filter").val(),
            zipOrPostalCode: $("#ZipOrPostalCodeFilter").val(),
            countryId: $("#CountryIdFilter").val(),
            stateOrProvinceId: $("#StateOrProvinceIdFilter").val(),
            cityId: $("#CityIdFilter").val(),
            districtId: $("#DistrictIdFilter").val()
        };
    };

    var dataTable = $("#AddressesTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(addressService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('Core.Addresses.Edit'),
                                action: function (data) {
                                    editModal.open({
                                        id: data.record.address.id
                                    });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('Core.Addresses.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    addressService.delete(data.record.address.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {data: "address.contactName"},
            {data: "address.phone"},
            {data: "address.addressLine1"},
            {data: "address.addressLine2"},
            {data: "address.zipOrPostalCode"},
            {
                data: "country.name",
                defaultContent: ""
            },
            {
                data: "stateOrProvince.name",
                defaultContent: ""
            },
            {
                data: "city.name",
                defaultContent: ""
            },
            {
                data: "district.name",
                defaultContent: ""
            }
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewAddressButton").click(function (e) {
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

    $('#AdvancedFilterSection select').change(function () {
        dataTable.ajax.reload();
    });
});
