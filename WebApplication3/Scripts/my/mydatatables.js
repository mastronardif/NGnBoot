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
    initTable: function () { },

    buildSetTableHeader: function () {
        console.log("mycoldata \n" + JSON.stringify(mycoldata));
        //mycoldat.data
        var trs = "";
        for (var j = 1; j < mycoldata.length; j++) {
            var label = mycoldata[j].data
            trs += "<th>"+ label +"</th>";
        }
        // empty for the fist col which is an edit button in this case.
        var thead = "<thead><tr><th></th>" + trs + "</tr></thead>";
        //console.log(theadZZ);
        //var thead = "<thead><tr><th></th><th>FirstTwoNEW</th><th>Last name</th><th>Position</th><th>Office</th></tr></thead>";
        return thead;
    }

};


////////////////////////////////////////

    $(document).ready(function () {
        $.when(myTableUtils.getHeader()).done(function () {

            $(staticdataTableSPAN).html('Hello table = ' + myTableUtils.filingUID);

            var myTable = jQuery("#staticdataTable");
            var thead = myTable.find("thead");
            var thRows =  myTable.find("tr:has(th)");

            if (thead.length === 0) {  //if there is no thead element, add one.
                var thehead = myTableUtils.buildSetTableHeader();
                thead = jQuery(thehead).appendTo(myTable);
                //jQuery("<thead><tr><th></th><th>FirstNEW</th><th>Last name</th><th>Position</th><th>Office</th></tr></thead>").appendTo(myTable);
            }

            var copy = thRows.clone(true).appendTo("thead");
            thRows.remove();

            myTableUtils.initTable();
            var url = "/Home/GetTableData/"+myTableUtils.filingUID;
            var dt00 = $('#staticdataTable').DataTable({
                "processing": true,
                "serverSide": false,
                "ajax": url,
                "columns": mycoldata,
                "order": [[1, 'asc']]
            });

            $('#staticdataTable tbody').on('click', 'tr td.details-control', function () {              
                var table = $('#staticdataTable').DataTable();
                var sss = table.cell(this).data();
                alert("sss = " + "sss.last_name " + sss.last_name + "\n\n" + JSON.stringify(sss) + "\n\n" + JSON.stringify(mycoldata) );
            });
        });

});


