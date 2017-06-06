using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;
using WebApplication3.Helpers;

namespace WebApplication3.Models
{
    public class StaticDataModel
    {
        public DataTable dtTable { get; set; }

        public StaticDataModel(string id)
        {
            string fn = id;
            // in
            byte[] datIn = File.ReadAllBytes(fn);
            
            object ds3 = Helpers.Helpers.DeSerialize(datIn);
            dtTable = (DataTable)ds3;

        }

        // helpers for datatable js BEGIN
        public List<DatatableHeaderDefinition> helperGetColDefs()
        {
            List<DatatableHeaderDefinition> tableData = new List<DatatableHeaderDefinition>();

            foreach (DataColumn col in dtTable.Columns)
            {
                var name = col.ColumnName;
                Debug.WriteLine("name = {0}", name);

                tableData.Add(new DatatableHeaderDefinition(name, name));
            }

            return tableData;
        }

        public List<Dictionary<string, object>> helperGetTableData()
        {
            //FilingTableResponse tableData = new FilingTableResponse();

            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;

            foreach (DataRow dr in dtTable.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dtTable.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }

                rows.Add(row);
            }

            return rows;
        }

    }
}