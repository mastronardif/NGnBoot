using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace WebApplication3.Helpers
{
    public class Helpers
    {
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