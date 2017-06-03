// my.js 
/*!
 *  my.js 
 */
alert('my.js');

    function format(d) {
        return 'Full name: ' + d.first_name + ' ' + d.last_name + '<br>' +
            'Salary: ' + d.salary + '<br>' +
            'The child row can contain any data you wish, including links, images, inner tables etc.';
    }

    var staticdataTableUtils = {
        filingUID: "",
        headers: [],
        rawview: false,
        theTable: {},
        tableRawData: [],
        userCol: { show: [], hide: [] },
        initHeader: function () {
            return $.ajax({
                url: '/Home/GetTableColumns',
                success: function (data) {
                    headers = data;
                    staticdataTableUtils.userCol.show = [];
                    staticdataTableUtils.userCol.hide = [];
                    for (var i = 0; i < headers.length; i++) {

                        if (headers[i].visible) {
                            staticdataTableUtils.userCol.show.push(i);
                        } else {
                            staticdataTableUtils.userCol.hide.push(i);
                        }
                    }
                },
                data: {
                    id: staticdataTableUtils.filingUID
                },
                error: function (e) {
                    console.log(e);
                },
                type: "POST"
            });
        },
        initTable: function () {
            theTable = $('#staticdataTable').dataTable({
                "select": true,

                "scrollX": true,
                "columns": headers,
                "processing": true,
                "serverSide": false,
                "filter": true,
                "orderMulti": true,
                "columnDefs": [
                    { "bSearchable": true, "targets": '_all' },
                    //{ "defaultContent": "-", "targets": '_all' },
                    {
                        "targets": '_all',
                        "createdCell": function (td, cellData, rowData, row, col) {
                            $(td).css('background-color', 'white');

                            var rawdata = tableRawData.matrix[row][headers[col].data];

                            staticdataTableUtils.validationErrors.set(false);
                            var valError = rawdata != null && rawdata.input != null ? rawdata.input.ValidationResult : null;
                            if (valError == null || valError.ResponseType == null) {
                                return;
                            } else if (valError.ResponseType == 1) {
                                $(td).css('background-color', 'orange');
                            } else if (valError.ResponseType == 2) {
                                $(td).css('background-color', 'red');
                                staticdataTableUtils.validationErrors.set(true);
                            }
                        }
                    }
                ],
                "autoWidth": true,
                "paging": true,
                "select": {
                    "style": 'os',
                    "selector": 'td:first-child'
                },
                "ajax": {
                    "url": '/Home/GetTableData',
                    "data": function (d) {
                        d.id = staticdataTableUtils.filingUID;
                        d.rawview = staticdataTableUtils.rawview;
                    },
                    "type": "POST",
                    "dataSrc": function (json) {
                        tableRawData = json;
                        tableRawData.rows = [];
                        tableRawData.matrix = [];
                        $.each(json.data, function (i, val) {
                            row = [];
                            tableRawData.matrix[i] = [];
                            $.each(val, function (key, cell) {
                                row[key] = cell;
                                tableRawData.matrix[i][key] = cell;
                            });
                            tableRawData.rows.push(row);
                        });

                        return tableRawData.rows;
                    },
                    "dataFilter": function (reps) {
                        return reps;
                    }
                },
                "initComplete": function () {
                },
                "order": [[0, 'asc']],
                "buttons": [
                {
                    "className": 'darkorange',
                    "text": 'All',
                    "show": ':hidden'
                },
                {
                    "className": 'lightorange',
                    "text": 'All fields',
                    "show": staticdataTableUtils.userCol.nonkey + staticdataTableUtils.userCol.hide
                }],
                "dom": 'Bfrtlip',
                "pageLength": 10,
                "lengthMenu": [[10, 25, 50, 100, 200, 1000], [10, 25, 50, 100, 200, 1000]]
            });
        },
        validationErrors: {
            set: function (b) {
                if (this.status == b) {
                    return;
                }
                this.status = b;
                var valArea = $("#validationErrorsArea");
                if (this.status) {
                    valArea.replaceWith('<div class="alert alert-danger"  id="validationErrorsArea">' +
                        '<strong>Important!</strong> There are validation errors in this filing.' +
                        '</div>');
                } else {
                    valArea.replaceWith('<div class="alert alert-success"  id="validationErrorsArea">' +
                        '<strong>Looks ok!</strong> There are no validation errors in this filing.' +
                        '</div>');
                }
            },
            status: false
        }
    };

    $(document).ready(function () {
        $.when(staticdataTableUtils.initHeader()).done(function () { staticdataTableUtils.initTable(); });

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


