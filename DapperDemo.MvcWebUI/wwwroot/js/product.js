var productList = function () {
    var initTable = function () {
        var productTable = $('#productTable');
        productTable.DataTable({
            processing: true,
            serverSide: true,
            searching: true,
            ordering: true,
            paging: true,
            ajax: {
                url: "/Product/GetProducts",
                type: "POST",
                dataType: "json",
            },
            columns: [
                { data: "productName", "autoWidth": true },
                { data: "quantityPerUnit", "autoWidth": true },
                { data: "unitPrice", "autoWidth": true },
                { data: "unitsInStock", "autoWidth": true }
            ]
        });
    }

    var handleEvents = function () {

    }

    return {
        init: function () {
            initTable();
            handleEvents();
        }
    }
}();

$(document).ready(function () {
    productList.init();
});