﻿var productTable;

$(document).ready(function () {

    productTable = $('#tblProducts').DataTable({
        "ajax": {
            "url": "/Product/GetAll"
        },
        "columns": [
            { "data": "description" },
            { "data": "winery" },
            { "data": "variety" },
            { "data": "price" },
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

function Delete(url) {
    console.log(url);
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                "url": url,
                "type": 'DELETE',
                "success": function (data) {
                    console.log(data);
                    if (data.success) {
                        productTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }

            });
        }
    })
};