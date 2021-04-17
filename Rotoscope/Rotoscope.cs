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
        private List<LinkedList<Point>> draw = new List<LinkedList<Point>>();

        public LinkedList<Point> GetFromDrawList(int frame)
        {
            if (frame < 0 || draw.Count == 0 || draw.Count < frame)
                return null;

            //copy the list to ensure it is not overwritten
            return draw[frame];
        }

        public void AddToDrawList(int frame, Point p)
        {
            //if the frame doesn't exists yet, add it
            while (draw.Count < frame + 1)
                draw.Add(new LinkedList<Point>());

            // Add the mouse point to the list for the frame
            draw[frame].AddLast(p);
        }

        public void OnSaveRotoscope(XmlDocument doc, XmlNode node)
        {

        }
    }
}
