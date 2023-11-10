var productTable;

$(document).ready(function () {

    productTable = $('#tblProducts').DataTable({
        "ajax": {
            "url": "/Admin/Product/GetAll"
        },
        "columns": [
            { "data": "description" },
            { "data": "winemaker_Notes" },
            { "data": "variety" },
            { "data": "price" },
            { "data": "winery" },
            { "data": "stock" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    
                            <a class="btn btn-warning" href="/Product/UpSert?id=${data}" >
                                <i class="bi bi-pencil-square"></i>&nbsp;
                                Edit
                            </a>
                            <a class="btn btn-danger" onclick="Delete('/Product/Delete/${data}')" >
                                <i class="bi bi-trash3"></i> &nbsp;
                                Delete
                            </a>

                    `
                }
            }

        ]

    });

});