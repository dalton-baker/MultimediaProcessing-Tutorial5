using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Rotoscope
{
    /// <summary>
    /// Holds the frame data
    /// </summary>
    public class Frame
    {
        /// <summary>
        /// The base bitmap of the frame
        /// </summary>
        public Bitmap Image { get => image; set => image = value; }

        /// <summary>
        /// Constructor for default frame
        /// </summary>
        public Frame()
        {
            image = new Bitmap(640, 480);
            init();
        }

        private Brush background = new SolidBrush(Color.DarkGray);
        private Graphics g;
        private Bitmap image;

        /// <summary>
        /// Constructor for a frame with the given image
        /// </summary>
        /// <param name="bmp">The image</param>
        public Frame(Bitmap bmp)
        {
            image = bmp.Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), bmp.PixelFormat);
            g = Graphics.FromImage(image);
        }

        /// <summary>
        /// Constructor for a empty frame with the given size
        /// </summary>
        /// <param name="width">width in pixels</param>
        /// <param name="height">height n pixels</param>
        public Frame(int width, int height)
        {
            image = new Bitmap(width, height);
            init();

        }

        public Color this[int x, int y]
        {

            get => image.GetPixel(x, y);
            set => image.SetPixel(x, y, value);
        }

        /// <summary>
        /// Clears the frame's image to black
        /// </summary>
        public void Clear()
        {
            Fill(0, 0, 0, 255);
        }

        
        /// <summary>
        /// Helper function for constructors to finish setup (fill with black)
        /// </summary>
        private void init()
        {
            Fill(0, 0, 0, 255);
            g = Graphics.FromImage(image);
        }
        #region Drawing

        /// <summary>
        /// Draws a hollow red dot at the given pixel
        /// </summary>
        /// <param name="p">the point where the dot will be drawn</param>
        /// <param name="c">The color of the dot</param>
        /// <param name="thickness">The thickness of the dot</param>
        public void DrawDot(Point p, Color c, int thickness = 2)
        {
            g.DrawEllipse(new Pen(c), p.X, p.Y, thickness, thickness);
            g.FillEllipse(new SolidBrush(c), p.X, p.Y, thickness, thickness);
        }

        /// <summary>
        /// Draws the frame's iamge with a background color in teh given area
        /// </summary>
        /// <param name="g">graphics reference to the view</param>
        /// <param name="drawArea">the area to draw the frame inside of</param>
        public void OnDraw(Graphics g, Rectangle drawArea)
        {
            g.FillRectangle(background, drawArea);
            g.DrawImage(image, new Point(drawArea.X, drawArea.Y));

        }

        /// <summary>
        /// Draws a line between the points given with the given color
        /// </summary>
        /// <param name="p1">point 1</param>
        /// <param name="p2">point 2</param>
        /// <param name="c">the color</param>
        /// <param name="thickness">the thickness</param>
        public void DrawLine(Point p1, Point p2, Color c, int thickness = 1)
        {
            g.DrawLine(new Pen(c, thickness), p1, p2);
        }

        /// <summary>
        /// Fills the frame's image with the given color
        /// </summary>
        /// <param name="r">red channel (0-255)</param>
        /// <param name="g">green channel (0-255)</param>
        /// <param name="b">blue channel (0-255)</param>
        void Fill(int r, int g, int b)
        {
            Color c = Color.FromArgb(255, r, g, b);
            Fill(c);
        }

        /// <summary>
        /// Fills the frame's image with the given color
        /// </summary>
        /// <param name="r">red channel (0-255)</param>
        /// <param name="g">green channel (0-255)</param>
        /// <param name="b">blue channel (0-255)</param>
        /// <param name="a">alpha channel (0-255)</param>
        void Fill(int r, int g, int b, int a)
        {
            Color c = Color.FromArgb(a, r, g, b);
            Fill(c);
        }

        /// <summary>
        /// Fills the frame's image with the given color
        /// </summary>
        /// <param name="c">the color</param>
        void Fill(Color c)
        {
            Graphics g = Graphics.FromImage(image);
            using (SolidBrush brush = new SolidBrush(c))
            {
                g.FillRectangle(brush, 0, 0, image.Width, image.Height);
            }

        }
        #endregion

        #region Save/open
      
        /// <summary>
        /// Loads the frames image from a file
        /// </summary>
        /// <param name="path">path to the file</param>
        /// <returns></returns>
        public bool LoadFile(string path)
        {
            try
            {
                image = new Bitmap(path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error loading frame");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Save the frames image to a file
        /// </summary>
        /// <param name="path">path</param>
        /// <param name="format"> the output format desired</param>
        /// <returns></returns>
        public bool SaveFile(string path, ImageFormat format)
        {
            try
            {
                image.Save(path, format);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error save frame");
                return false;
            }

            return true;
        }
        #endregion
    }
}

