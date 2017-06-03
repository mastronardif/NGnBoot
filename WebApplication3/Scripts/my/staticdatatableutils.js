var staticdataTableUtils = {
    filingUID: "",
    headers: [],
    rawview: false,
    theTable: {},
    tableRawData: [],
    userCol: { show: [], hide: [] },
    initHeader: function () {
        return $.ajax({
            url: '/StaticData/GetTableColumns',
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
                "url": '/StaticData/GetTableData',
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
                            row[key] =  cell;
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
});