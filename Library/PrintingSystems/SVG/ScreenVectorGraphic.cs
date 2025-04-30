using System;
using System.Xml.Linq;

namespace PrintingSystems.SVG
{
    public class ScreenVectorGraphic
    {
        /// <summary>
        /// the root document
        /// </summary>
        public XDocument Model { get; }

        /// <summary>
        /// the root element
        /// </summary>
        public XElement SVG { get; }

        /// <summary>
        /// constructor
        /// </summary>
        public ScreenVectorGraphic()
        {
            var DocType = new XDocumentType("svg", "-//W3C//DTD SVG 1.1//EN",
                "http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd", null);

            Model = new XDocument();
            /*{
                Declaration =
                {
                    Encoding = "UTF-8",
                    Version = "1.0",
                    Standalone = "no"
                }
            };*/

            SVG = new XElement("svg");
            SVG.Add(new XAttribute("width", "100%"));
            SVG.Add(new XAttribute("height", "100%"));
            SVG.Add(new XAttribute("version", "1.1"));
            SVG.Add(new XAttribute("xmlns", "http://www.w3.org/2000/svg"));
        

            Model.Add(SVG);

        }



        public void Save(string fileName)
        {
            try
            {
                Model.Save(fileName);

            }
            catch (Exception Error)
            {
                Console.WriteLine(Error);
            }

        }
    }
}
