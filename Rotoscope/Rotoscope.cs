using Rotoscope.DrawableItems;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Rotoscope
{
    class Rotoscope
    {
        private Dictionary<int, List<DrawableItem>> _drawableItemsByFrame = new Dictionary<int, List<DrawableItem>>();

        public List<DrawableItem> GetFromDrawList(int frame)
        {
            if (!_drawableItemsByFrame.ContainsKey(frame))
            {
                return new List<DrawableItem>();
            }

            return _drawableItemsByFrame[frame];
        }

        public void AddToDrawList(int frame, DrawableItem drawableItem)
        {
            if (!_drawableItemsByFrame.ContainsKey(frame))
            {
                _drawableItemsByFrame[frame] = new List<DrawableItem>();
            }

            _drawableItemsByFrame[frame].Add(drawableItem);
        }

        public void OnSaveRotoscope(XmlDocument doc, XmlNode node)
        {
            foreach(var frame in _drawableItemsByFrame)
            {
                XmlElement element = doc.CreateElement(XmlNameConst.Frame);
                element.SetAttribute(XmlNameConst.FrameNum, frame.Key.ToString());

                node.AppendChild(element);

                foreach (DrawableItem di in frame.Value)
                {
                    di.AddToXmlDoc(doc, element);
                }
            }
        }

        public void ClearFrame(int frame)
        {
            if(_drawableItemsByFrame.ContainsKey(frame))
            {
                _drawableItemsByFrame[frame].Clear();
            }
        }

        public void OnOpenRotoscope(XmlNode node)
        {
            foreach (XmlNode child in node.ChildNodes)
            {
                if (child.Name == XmlNameConst.Frame)
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
                if (attr.Name == XmlNameConst.FrameNum)
                {
                    frame = Convert.ToInt32(attr.Value);
                }
            }

            _drawableItemsByFrame[frame] = new List<DrawableItem>();

            foreach (XmlNode child in node.ChildNodes)
            {
                switch (child.Name)
                {
                    case XmlNameConst.Dot:
                        _drawableItemsByFrame[frame].Add(new DrawableDot(child));
                        break;

                    case XmlNameConst.Line:
                        _drawableItemsByFrame[frame].Add(new DrawableLine(child));
                        break;

                    case XmlNameConst.Bird:
                        _drawableItemsByFrame[frame].Add(new DrawableBird(child));
                        break;

                    default:
                        throw new NotImplementedException($"There is not handling for drawable item type '{child.Name}'");
                }
            }
        }
    }
}
