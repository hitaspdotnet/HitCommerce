var abp = abp || {};

abp.modals.addressEdit = function () {
    var initModal = function (publicApi, args) {

        var address_CountryId = $('#Address_CountryId');
        var address_StateOrProvinceId = $('#Address_StateOrProvinceId');
        var address_CityId = $('#Address_CityId');
        var address_DistrictId = $('#Address_DistrictId');
        
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
            
            address_CountryId.on('change', function (e) {
                address_StateOrProvinceId.val('').trigger('change');
                address_CityId.val('').trigger('change');
                address_DistrictId.val('').trigger('change');
            });

            address_StateOrProvinceId.on('change', function (e) {
                address_CityId.val('').trigger('change');
                address_DistrictId.val('').trigger('change');
            });

            address_CityId.on('change', function (e) {
                address_DistrictId.val('').trigger('change');
            });

            address_CountryId.select2({
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

            address_CountryId.on('select2:select', function (e) {
                address_StateOrProvinceId.select2({
                    ajax: {
                        url: abp.appPath + 'api/core/addresses/state-or-province-lookup/' + address_CountryId.val(),
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

            address_StateOrProvinceId.on('select2:select', function (e) {
                address_CityId.select2({
                    ajax: {
                        url: abp.appPath + 'api/core/addresses/city-lookup/' + address_StateOrProvinceId.val(),
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

            address_CityId.on('select2:select', function (e) {
                address_DistrictId.select2({
                    ajax: {
                        url: abp.appPath + 'api/core/addresses/district-lookup/' + address_CityId.val(),
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
        });

    };

    return {
        initModal: initModal
    };
};
