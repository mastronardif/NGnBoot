using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;

namespace WebApplication3.Helpers
{
    public class Helpers
    {
        public static string DataTableRowbyColsHTML_Table(DataTable dt, int row)
        {
            if (dt.Rows.Count == 0) return ""; // enter code here

            StringBuilder builder = new StringBuilder();
            builder.Append("<html>");
            builder.Append("<head>");
            builder.Append("<title>");
            builder.Append("Page-");
            builder.Append(Guid.NewGuid());
            builder.Append("</title>");
            builder.Append("</head>");
            builder.Append("<body>");
            builder.Append("<table border='1px' cellpadding='5' cellspacing='0' ");
            builder.Append("style='border: solid 1px Silver; font-size: x-small;'>");
            builder.Append("<tr align='left' valign='top'>");

            string [] labels = { "Label", "old", "new" };
            foreach (var c in  labels)
            {
                builder.Append("<td align='left' valign='top'><b>");
                builder.Append(c);
                builder.Append("</b></td>");
            }
            builder.Append("</tr>");

            DataRow r = dt.Rows[row];
            {
                
                foreach (DataColumn c in dt.Columns)
                {
                    builder.Append("<tr align='left' valign='top'>");

                    // Name
                    builder.Append("<td align='left' valign='top'><b>");
                    builder.Append(c.ColumnName);
                    builder.Append("</b></td>");

                    // Old value
                    builder.Append("<td align='left' valign='top'>");
                    builder.Append(r[c.ColumnName]);
                    builder.Append("</td>");

                    //new entry
                    builder.Append("<td align='left' valign='top'><b>");
                    builder.Append("enter new");
                    builder.Append("</b></td>");

                    builder.Append("</tr>");
                }
                
            }

            builder.Append("</table>");
            builder.Append("</body>");
            builder.Append("</html>");

            return builder.ToString();
        }

        public static string DataTabletoHTML_Table(DataTable dt, int row)
        {
            if (dt.Rows.Count == 0) return ""; // enter code here

            StringBuilder builder = new StringBuilder();
            builder.Append("<html>");
            builder.Append("<head>");
            builder.Append("<title>");
            builder.Append("Page-");
            builder.Append(Guid.NewGuid());
            builder.Append("</title>");
            builder.Append("</head>");
            builder.Append("<body>");
            builder.Append("<table border='1px' cellpadding='5' cellspacing='0' ");
            builder.Append("style='border: solid 1px Silver; font-size: x-small;'>");
            builder.Append("<tr align='left' valign='top'>");
            foreach (DataColumn c in dt.Columns)
            {
                builder.Append("<td align='left' valign='top'><b>");
                builder.Append(c.ColumnName);
                builder.Append("</b></td>");
            }
            builder.Append("</tr>");
            //foreach (DataRow r in dt.Rows)            
            DataRow r = dt.Rows[row];
            {
                builder.Append("<tr align='left' valign='top'>");
                foreach (DataColumn c in dt.Columns)
                {
                    builder.Append("<td align='left' valign='top'>");
                    builder.Append(r[c.ColumnName]);
                    builder.Append("</td>");
                }
                builder.Append("</tr>");
            }
            builder.Append("</table>");
            builder.Append("</body>");
            builder.Append("</html>");

            return builder.ToString();
        }


        //static DataSet DeSerialize(byte[] content)
        public static object DeSerialize(byte[] content)
        {
            //var set = new DataSet();
            var set = new object();
            try
            {
                //var content = StringToBytes(s);
                var formatter = new BinaryFormatter();
                using (var ms = new MemoryStream(content))
                {
                    using (var ds = new DeflateStream(ms, CompressionMode.Decompress, true))
                    {
                        //set = (DataSet)formatter.Deserialize(ds);
                        set = (object)formatter.Deserialize(ds);
                        Console.WriteLine(string.Format("result({0})", set));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return set;
        }

        //static byte[] Serialize(string set)
        //static byte[] Serialize(DataSet set)
        static byte[] Serialize(object set)
        {
            byte[] content = null;

            try
            {
                var formatter = new BinaryFormatter();

                using (var ms = new MemoryStream())
                {
                    using (var ds = new DeflateStream(ms, CompressionMode.Compress, true))
                    {
                        //object set = null;
                        //string set = "what the fuck";
                        formatter.Serialize(ds, set);
                    }
                    ms.Position = 0;
                    content = ms.GetBuffer();

                    string result = System.Text.Encoding.UTF8.GetString(content);
                    //Console.WriteLine(string.Format("result({0})", result) );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return content;

        }
    }
}