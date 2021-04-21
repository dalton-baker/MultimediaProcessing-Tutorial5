using System.Drawing;
using System.Xml;

namespace Rotoscope.DrawableItems
{
#pragma warning disable CS1591
    public class DrawableLine : DrawableItem
    {
        public Point Point1 { get; private set; }
        public Point Point2 { get; private set; }

        public DrawableLine(Point point1, Point point2)
        {
            Point1 = point1;
            Point2 = point2;
        }

        public DrawableLine(XmlNode xmlNode)
        {
            LoadFromXml(xmlNode);
        }

        public override void AddToXmlDoc(XmlDocument document, XmlElement parentElement)
        {
            XmlElement lineElement = document.CreateElement(XmlNameConst.Line);
            lineElement.SetAttribute(XmlNameConst.LinePoint1, PointToString(Point1));
            lineElement.SetAttribute(XmlNameConst.LinePoint2, PointToString(Point2));
            parentElement.AppendChild(lineElement);
        }

        public override void LoadFromXml(XmlNode xmlNode)
        {
            foreach (XmlAttribute attribute in xmlNode.Attributes)
            {
                if (attribute.Name == XmlNameConst.LinePoint1)
                {
                    Point1 = StringToPoint(attribute.Value);
                }
                else if (attribute.Name == XmlNameConst.LinePoint2)
                {
                    Point2 = StringToPoint(attribute.Value);
                }
            }
        }
    }
#pragma warning restore CS1591
}
