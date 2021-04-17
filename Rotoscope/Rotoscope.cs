using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Rotoscope
{
    class Rotoscope
    {
        private Dictionary<int, List<Point>> dots = new Dictionary<int, List<Point>>();
        private Dictionary<int, List<(Point, Point)>> lines = new Dictionary<int, List<(Point, Point)>>();

        public (List<Point>, List<(Point, Point)>) GetFromDrawList(int frame)
        {
            if (!dots.ContainsKey(frame) && !lines.ContainsKey(frame))
            {
                return (null, null);
            }

            return (dots[frame], lines[frame]);
        }

        public void AddToDrawList(int frame, Point p)
        {
            if (!dots.ContainsKey(frame))
            {
                dots[frame] = new List<Point>();
            }
            if (!lines.ContainsKey(frame))
            {
                lines[frame] = new List<(Point, Point)>();
            }

            dots[frame].Add(p);
        }

        public void AddToDrawList(int frame, (Point, Point) p)
        {
            if (!lines.ContainsKey(frame))
            {
                lines[frame] = new List<(Point, Point)>();
            }
            if (!dots.ContainsKey(frame))
            {
                dots[frame] = new List<Point>();
            }

            lines[frame].Add(p);
        }

        public void OnSaveRotoscope(XmlDocument doc, XmlNode node)
        {
            int numOfFrames = Math.Max(dots.Keys.Last(), lines.Keys.Last());

            for (int frame = 0; frame <= numOfFrames; frame++)
            {
                if(dots.ContainsKey(frame) || lines.ContainsKey(frame))
                {
                    XmlElement element = doc.CreateElement("frame");
                    element.SetAttribute("num", frame.ToString());

                    node.AppendChild(element);

                    foreach (Point p in dots[frame])
                    {
                        XmlElement pElement = doc.CreateElement("dot");
                        pElement.SetAttribute("point", PointToString(p));
                        element.AppendChild(pElement);
                    }

                    foreach ((Point, Point) p in lines[frame])
                    {
                        XmlElement pElement = doc.CreateElement("line");
                        pElement.SetAttribute("point1", PointToString(p.Item1));
                        pElement.SetAttribute("point2", PointToString(p.Item2));
                        element.AppendChild(pElement);
                    }
                }
            }
        }

        public void ClearFrame(int frame)
        {
            if(lines.ContainsKey(frame))
            {
                lines[frame].Clear();
            }

            if (dots.ContainsKey(frame))
            {
                dots[frame].Clear();
            }
        }

        public void OnOpenRotoscope(XmlNode node)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "frame")
                {
                    LoadFrame(child);
                }
            }
        }

        private void LoadFrame(XmlNode node)
        {
            int frame = 0;

            foreach (XmlAttribute attr in node.Attributes)
            {
                if (attr.Name == "num")
                {
                    frame = Convert.ToInt32(attr.Value);
                }
            }

            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == "dot")
                {
                    LoadDot(frame, child);
                }

                if (child.Name == "line")
                {
                    LoadLine(frame, child);
                }
            }
        }

        private void LoadDot(int frame, XmlNode node)
        {
            foreach (XmlAttribute attr in node.Attributes)
            {
                if (attr.Name == "point")
                {
                    AddToDrawList(frame, StringToPoint(attr.Value));
                }
            }
        }

        private void LoadLine(int frame, XmlNode node)
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 0);

            foreach (XmlAttribute attr in node.Attributes)
            {
                if (attr.Name == "point1")
                {
                    p1 = StringToPoint(attr.Value);
                }
                else if (attr.Name == "point2")
                {
                    p2 = StringToPoint(attr.Value);
                }
            }

            AddToDrawList(frame, (p1, p2));
        }


        private string PointToString(Point p)
        {
            return $"{p.X},{p.Y}";
        }

        private Point StringToPoint(string point)
        {
            var points = point.Split(',');
            return new Point(int.Parse(points.First()), int.Parse(points.Last()));
        }
    }
}
