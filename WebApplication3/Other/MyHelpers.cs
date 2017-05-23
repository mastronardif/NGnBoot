using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;


namespace myhelpers
{
    class MyHelpers
    {
        static public void ReadFromApp_Data(string fn, ref string results)
        {
            //string uriXML = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/testdata.xml");
            string uriXML = System.Web.HttpContext.Current.Server.MapPath(fn);
            using (System.IO.StreamReader myFile = new System.IO.StreamReader(uriXML))
            {
                results = myFile.ReadToEnd();
            }
        }
    }
}