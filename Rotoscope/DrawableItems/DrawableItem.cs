using System.Drawing;
using System.Linq;
using System.Xml;

namespace Rotoscope.DrawableItems
{
#pragma warning disable CS1591
    public abstract class DrawableItem
    {
        public abstract void LoadFromXml(XmlNode xmlNode);

        public abstract void AddToXmlDoc(XmlDocument document, XmlElement parentElement);

        protected Point StringToPoint(string point)
        {
            var points = point.Split(',');
            return new Point(int.Parse(points.First()), int.Parse(points.Last()));
        }
        protected string PointToString(Point p)
        {
            return $"{p.X},{p.Y}";
        }
    }

    public static class XmlNameConst
    {
        public const string Dot = "dot";
        public const string Line = "line";
        public const string Bird = "bird";

        public const string DotPoint = "point";
        public const string LinePoint1 = "point1";
        public const string LinePoint2 = "point2";

        public const string Frame = "frame";
        public const string FrameNum = "num";
    }
#pragma warning restore CS1591
}
