moviesapp.controller('SearchController',
    function ($scope) {
        $scope.searchOptions = {
            minLength: 3,
            dataTextField: "title",
            filter: 'contains',
            dataSource: new kendo.data.DataSource({
                dataType: "json",
                transport: {
                    read: {
                        type: "POST",
                        url: "/Movies/Search",
                        data:
                            {
                                filter: function () {
                                    return $("#txtSearch").data("kendoAutoComplete").value();
                                }
                            }
                    }
                },
                schema: {
                    data: function (result) {
                        return result.items;
                    }
                }
            }),
            change: function () {
                this.dataSource.read();
            }
        };
    });