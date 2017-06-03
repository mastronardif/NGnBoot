// my.js 
/*!
 *  my.js 
 */
//alert('my.js');

var myTableUtils = {
    filingUID: "",
    getHeader: function () {
        return $.ajax({
            url: '/Home/GetTableColumns',
            success: function (data) {
                console.log(JSON.stringify(data));
                mycoldata = data;
            },
            data: {
                id: myTableUtils.filingUID
            },
            error: function (e) {
                console.log(e);
            },
            type: "POST"
        });
    },
    initTable: function () {

    }
};


////////////////////////////////////////
    function format(d) {
        return 'Full name: ' + d.first_name + ' ' + d.last_name + '<br>' +
            'Salary: ' + d.salary + '<br>' +
            'The child row can contain any data you wish, including links, images, inner tables etc.';
    }



    $(document).ready(function () {
        //$.when(staticdataTableUtils.initHeader()).done(function () { staticdataTableUtils.initTable(); });
        $.when(myTableUtils.getHeader()).done(function () {

            $(staticdataTableSPAN).html('Hello table = ' + myTableUtils.filingUID);


            myTableUtils.initTable();
            var url = "/Home/GetTableData/"+myTableUtils.filingUID;
            var dt00 = $('#staticdataTable').DataTable({
                "processing": true,
                "serverSide": false,
                "ajax": url,
                "columns": mycoldata,
                "order": [[1, 'asc']]
            });

            // Array to track the ids of the details displayed rows
            var detailRows00 = [];

            $('#staticdataTable tbody').on('click', 'tr td.details-control', function () {
                var tr = $(this).closest('tr');
                var row = dt00.row(tr);
                var idx = $.inArray(tr.attr('id'), detailRows00);

                if (row.child.isShown()) {
                    tr.removeClass('details');
                    row.child.hide();

                    // Remove from the 'open' array
                    detailRows00.splice(idx, 1);
                }
                else {
                    tr.addClass('details');
                    row.child(format(row.data())).show();

                    // Add to the 'open' array
                    if (idx === -1) {
                        detailRows00.push(tr.attr('id'));
                    }
                }
            });

            // On each draw, loop over the `detailRows` array and show any child rows
            dt00.on('draw', function () {
                $.each(detailRows00, function (i, id) {
                    $('#' + id + ' td.details-control').trigger('click');
                });
            });


        });




        //////////////////////////////////////////////
        /////////////////////////////////////////////

    var dt = $('#example').DataTable({
        "processing": true,
        "serverSide": false,
        "ajax": "/Home/letsDoThis/fu",
        "columns": [
            {
                "class": "details-control",
                "orderable": false,
                "data": null,
                "defaultContent": ""
            },
            { "data": "first_name" },
            { "data": "last_name" },
            { "data": "position" },
            { "data": "office" }
        ],
        "order": [[1, 'asc']]
    });

    // Array to track the ids of the details displayed rows
    var detailRows = [];

    $('#example tbody').on('click', 'tr td.details-control', function () {
        var tr = $(this).closest('tr');
        var row = dt.row(tr);
        var idx = $.inArray(tr.attr('id'), detailRows);

        if (row.child.isShown()) {
            tr.removeClass('details');
            row.child.hide();

            // Remove from the 'open' array
            detailRows.splice(idx, 1);
        }
        else {
            tr.addClass('details');
            row.child(format(row.data())).show();

            // Add to the 'open' array
            if (idx === -1) {
                detailRows.push(tr.attr('id'));
            }
        }
    });

    // On each draw, loop over the `detailRows` array and show any child rows
    dt.on('draw', function () {
        $.each(detailRows, function (i, id) {
            $('#' + id + ' td.details-control').trigger('click');
        });
    });
});


