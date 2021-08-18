var abp = abp || {};

abp.modals.addressEdit = function () {
    var initModal = function (publicApi, args) {

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

        publicApi.onOpen(function () {
            $('#Address_CountryId').select2({
                ajax: {
                    url: abp.appPath + 'api/core/addresses/country-lookup',
                    type: 'GET',
                    data: function (params) {
                        return {filter: params.term, maxResultCount: 10}
                    },
                    processResults: function (data) {
                        var mappedItems = _.map(data.items, function (item) {
                            return {id: item.id, text: item.displayName};
                        });

                        return {results: mappedItems};
                    }
                }
            });
        });
        publicApi.onOpen(function () {
            $('#Address_StateOrProvinceId').select2({
                ajax: {
                    url: abp.appPath + 'api/core/addresses/state-or-province-lookup/' + $('#Address_CountryId').val(),
                    type: 'GET',
                    data: function (params) {
                        return {filter: params.term, maxResultCount: 10}
                    },
                    processResults: function (data) {
                        var mappedItems = _.map(data.items, function (item) {
                            return {id: item.id, text: item.displayName};
                        });

                        return {results: mappedItems};
                    }
                }
            });
        });
        publicApi.onOpen(function () {
            $('#Address_CityId').select2({
                ajax: {
                    url: abp.appPath + 'api/core/addresses/city-lookup/' + $('#Address_StateOrProvinceId').val(),
                    type: 'GET',
                    data: function (params) {
                        return {filter: params.term, maxResultCount: 10}
                    },
                    processResults: function (data) {
                        var mappedItems = _.map(data.items, function (item) {
                            return {id: item.id, text: item.displayName};
                        });

                        mappedItems.unshift({id: '', text: ' - '});
                        return {results: mappedItems};
                    }
                }
            });
        });
        publicApi.onOpen(function () {
            $('#Address_DistrictId').select2({
                ajax: {
                    url: abp.appPath + 'api/core/addresses/district-lookup/' + $('#Address_CityId').val(),
                    type: 'GET',
                    data: function (params) {
                        return {filter: params.term, maxResultCount: 10}
                    },
                    processResults: function (data) {
                        var mappedItems = _.map(data.items, function (item) {
                            return {id: item.id, text: item.displayName};
                        });

                        mappedItems.unshift({id: '', text: ' - '});
                        return {results: mappedItems};
                    }
                }
            });
        });

    };

    return {
        initModal: initModal
    };
};
