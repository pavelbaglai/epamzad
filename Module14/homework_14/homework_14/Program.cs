using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace homework_14
{
    class Program
    {
        static void Main(string[] args)
        {
            //path declaration
            string fullpathXml = @"C:\Users\Andrey.Novov\Documents\Visual Studio 2015\Projects\homework_14\homework_14\Employees.xml";
            string fullpathXsd = @"C:\Users\Andrey.Novov\Documents\Visual Studio 2015\Projects\homework_14\homework_14\Employees.xsd";
            string fullpathXslt = @"C:\Users\Andrey.Novov\Documents\Visual Studio 2015\Projects\homework_14\homework_14\Transform.xslt";
            string newXmlFileName = @"C:\Users\Andrey.Novov\Documents\Visual Studio 2015\Projects\homework_14\homework_14\EmployeeList.xml";

            //xml load
            if (!File.Exists(fullpathXml)) throw new FileNotFoundException("xml file not found");
            XDocument docXml = XDocument.Load(fullpathXml);

            //Validate processing
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            if (!File.Exists(fullpathXsd)) throw new FileNotFoundException("xsd file not found");
            settings.Schemas.Add(null, fullpathXsd);
            
            using (XmlReader r = XmlReader.Create(fullpathXml, settings))
            {
                try
                {
                    while (r.Read()) ;
                }
                catch (XmlSchemaValidationException ex)
                {
                    Console.WriteLine(ex);
                }
            }

            //xsl transformation
            var transform = new XslCompiledTransform();

            if (!File.Exists(fullpathXslt)) throw new FileNotFoundException("xslt file not found");
            transform.Load(fullpathXslt);

            if (string.IsNullOrEmpty(newXmlFileName)) throw new FileNotFoundException("new filename empty");
            transform.Transform(fullpathXml, newXmlFileName);

        }
    }
}
