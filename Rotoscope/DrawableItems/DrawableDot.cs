using System.Drawing;
using System.Xml;

namespace Rotoscope.DrawableItems
{
#pragma warning disable CS1591
    public class DrawableDot : DrawableItem
    {
        protected virtual string XmlName => XmlNameConst.Dot;

        public Point Point { get; set; }

        public DrawableDot(Point point)
        {
            Point = point;
        }

        public DrawableDot(XmlNode xmlNode)
        {
            LoadFromXml(xmlNode);
        }

        public override void AddToXmlDoc(XmlDocument document, XmlElement parentElement)
        {
            XmlElement pElement = document.CreateElement(XmlName);
            pElement.SetAttribute(XmlNameConst.DotPoint, PointToString(Point));
            parentElement.AppendChild(pElement);
        }

        public override void LoadFromXml(XmlNode xmlNode)
        {
            foreach (XmlAttribute attr in xmlNode.Attributes)
            {
                if (attr.Name == XmlNameConst.DotPoint)
                {
                    Point = StringToPoint(attr.Value);
                }
            }
        }
    }


    public class DrawableBird : DrawableDot
    {
        protected override string XmlName => XmlNameConst.Bird;

        public DrawableBird(Point point) : base(point)
        {
        }

        public DrawableBird(XmlNode xmlNode) : base(xmlNode)
        {
        }
    }
#pragma warning restore CS1591
}
