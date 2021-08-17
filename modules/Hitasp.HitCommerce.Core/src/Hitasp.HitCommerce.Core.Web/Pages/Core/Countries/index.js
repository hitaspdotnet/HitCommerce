$(function () {
    var l = abp.localization.getResource("Core");
	
	var countryService = window.hitasp.hitCommerce.core.countries.countries;
	
	
    var createModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Core/Countries/CreateModal",
        scriptUrl: "/Pages/Core/Countries/createModal.js",
        modalClass: "countryCreate"
    });

	var editModal = new abp.ModalManager({
        viewUrl: abp.appPath + "Core/Countries/EditModal",
        scriptUrl: "/Pages/Core/Countries/editModal.js",
        modalClass: "countryEdit"
    });

	var getFilter = function() {
        return {
            filterText: $("#FilterText").val(),
            name: $("#NameFilter").val(),
			code3: $("#Code3Filter").val(),
            isBillingEnabled: (function () {
                var value = $("#IsBillingEnabledFilter").val();
                if (value === undefined || value === null || value === '') {
                    return '';
                }
                return value === 'true';
            })(),
            isShippingEnabled: (function () {
                var value = $("#IsShippingEnabledFilter").val();
                if (value === undefined || value === null || value === '') {
                    return '';
                }
                return value === 'true';
            })()
        };
    };

    var dataTable = $("#CountriesTable").DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        scrollX: true,
        autoWidth: false,
        scrollCollapse: true,
        order: [[1, "asc"]],
        ajax: abp.libs.datatables.createAjax(countryService.getList, getFilter),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l("Edit"),
                                visible: abp.auth.isGranted('Core.Countries.Edit'),
                                action: function (data) {
                                    editModal.open({
                                     id: data.record.id
                                     });
                                }
                            },
                            {
                                text: l("Delete"),
                                visible: abp.auth.isGranted('Core.Countries.Delete'),
                                confirmMessage: function () {
                                    return l("DeleteConfirmationMessage");
                                },
                                action: function (data) {
                                    countryService.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l("SuccessfullyDeleted"));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
			{ data: "name" },
			{ data: "code3" },
            {
                data: "isBillingEnabled",
                render: function (isBillingEnabled) {
                    return isBillingEnabled ? l("Yes") : l("No");
                }
            },
            {
                data: "isShippingEnabled",
                render: function (isShippingEnabled) {
                    return isShippingEnabled ? l("Yes") : l("No");
                }
            }
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $("#NewCountryButton").click(function (e) {
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
