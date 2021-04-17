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

            get => this.image.GetPixel(x, y);
            set => this.image.SetPixel(x, y, value);
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
        /// <param name="x">x position in pixels</param>
        /// <param name="y">y position in pixels</param>
        public void DrawDot(int x, int y)
        {
            g.DrawRectangle(new Pen(Color.Red), x, y, 2, 2);
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
        /// <param name="x1">point 1's x in pixels</param>
        /// <param name="y1">point 1's y in pixels</param>
        /// <param name="x2">point 2's x in pixels</param>
        /// <param name="y2">point 2's y in pixels</param>
        /// <param name="c">the color </param>
        public void DrawLine(int x1, int y1, int x2, int y2, Color c)
        {
            g.DrawLine(new Pen(c), x1, y1, x2, y2);
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

