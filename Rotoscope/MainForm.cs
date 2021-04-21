/******************************************************************************
 * Mark off what items are complete (e.g. x, done, checkmark, etc), and put a 
 * P if partially complete. If 'P' include how to test what is working for 
 * partial credit below the checklist line.
 * 
 * Total available points:  100
 * 
 * 🗸______	25	Tutorial completed (honor system on this one)
 * 🗸______  10	Video: colbert1a draws any line
 * 🗸______	10	Video: colbert1a line is white
 * 🗸______	5	Video: colbert1b line is red
 * 🗸______	10	Video: colbert1b line is 2 pixels wide
 * 🗸______	15	Video: colbert2 Put a Bird On It
 * ______	20	Video: colbert3 rotation
 * 🗸______	5	Video: colbert3 line is green
 * ______	Total (please add the points and include the total here)
 * 
 * 
 * The grade you compute is the starting point for course staff, who reserve 
 * the right to change the grade if they disagree with your assessment and to 
 * deduct points for other issues they may encounter, such as errors in the 
 * submission process, naming issues, etc.
 *****************************************************************************/

using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Rotoscope
{
    /// <summary>
    /// Main form
    /// </summary>
    public partial class MainForm : Form
    {
        Movie inputMovie = null;
        private string lastSave = null;
        MovieMaker maker = null;

        /// <summary>
        /// initalizes the form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            DoubleBuffered = true;

            UpdateMenuBar();

        }

        /// <summary>
        /// Handle the resize event
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (maker != null)
            {
                SetupMaker();
            }
            Invalidate();
        }

        /// <summary>
        /// Refresh the window
        /// </summary>
        public new void Invalidate()
        {
            base.Invalidate();
        }

        /// <summary>
        /// Clean up files on close
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            maker = null;
            inputMovie = null;
        }

        /// <summary>
        /// Paint the frame
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            if (maker != null)
                maker.OnDraw(e.Graphics);
        }

        /// <summary>
        /// Updates what menu options are enabled and disabled
        /// </summary>
        private void UpdateMenuBar()
        {
            if (maker == null)
            {
                //file menu
                closeItem.Enabled = false;
                saveAsItem.Enabled = false;
                saveItem.Enabled = false;

                //movie menu
                closeAudioItem.Enabled = false;
                closeMovieItem.Enabled = false;
                generateVideoItem.Enabled = false;
                pullAudioItem.Enabled = false;
                generateVideoItem.Enabled = false;

                //frame menu
                createFrameItem.Enabled = false;
                writeFrameItem.Enabled = false;
                writeThenCreateFrameItem.Enabled = false;
                writeThenCreateSecondItem.Enabled = false;
                writeThenCreateRemainingItem.Enabled = false;

                toolStrip1.Enabled = false;
                toolStrip2.Enabled = false;

            }
            else
            {
                //file menu
                closeItem.Enabled = true;
                saveAsItem.Enabled = true;
                saveItem.Enabled = true;

                //movie menu
                closeMovieItem.Enabled = true;
                generateVideoItem.Enabled = true;

                if (maker.CurFrameCount > 0)
                    generateVideoItem.Enabled = true;
                else
                    generateVideoItem.Enabled = false;

                //Frame menu
                createFrameItem.Enabled = true;
                writeFrameItem.Enabled = true;
                writeThenCreateFrameItem.Enabled = true;

                toolStrip1.Enabled = true;
                toolStrip2.Enabled = true;


                if (maker.Audio != null)
                {
                    closeAudioItem.Enabled = true;
                    pullAudioItem.Enabled = true;
                }
                else
                {
                    closeAudioItem.Enabled = false;
                    useSourceAudioItem.Checked = false;
                }

                if (maker.SourceMovie != null)
                {
                    writeThenCreateSecondItem.Enabled = true;
                    writeThenCreateRemainingItem.Enabled = true;
                    writeThenCreateSecondItem_toolStrip.Enabled = true;
                    writeThenCreateRemainingItem_toolStrip.Enabled = true;
                }
                else
                {
                    writeThenCreateSecondItem.Enabled = false;
                    writeThenCreateRemainingItem.Enabled = false;
                    writeThenCreateSecondItem_toolStrip.Enabled = false;
                    writeThenCreateRemainingItem_toolStrip.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Pulls drawing area for the movie maker, and initalizes if needed.
        /// </summary>
        private void SetupMaker()
        {
            if (maker == null)
                maker = new MovieMaker(this);

            Rectangle r = ClientRectangle;
            r.Y = menuStrip1.Height + toolStrip1.Height + toolStrip2.Height;
            maker.DrawArea = r;

            maker.LineColor = lineColorSelector.BackColor = Color.Blue;
            maker.DotColor = dotColorSelector.BackColor = Color.Red;
        }

        #region Menu Handlers
        #region File menu
        private void newItem_Click(object sender, EventArgs e)
        {
            inputMovie = new Movie();
            SetupMaker();

            UpdateMenuBar();
            Invalidate();
        }

        private void openRotoItem_Click(object sender, EventArgs e)
        {
            if (openDlgRoto.ShowDialog() == DialogResult.OK)
            {
                maker.OnOpenRotoscope(openDlgRoto.FileName);
            }
            UpdateMenuBar();
        }

        private void saveAsRotoItem_Click(object sender, EventArgs e)
        {
            if (saveDlgRoto.ShowDialog() == DialogResult.OK)
            {
                maker.OnSaveRotoscope(saveDlgRoto.FileName);
                lastSave = saveDlgRoto.FileName;
            }
            saveDlgRoto.Dispose();

            maker.OnSaveRotoscope(saveDlgRoto.FileName);
        }

        private void saveRotoItem_Click(object sender, EventArgs e)
        {
            if (lastSave != null)
            {
                maker.OnSaveRotoscope(lastSave);
            }
            else
            {
                if (saveDlgRoto.ShowDialog() == DialogResult.OK)
                {
                    maker.OnSaveRotoscope(saveDlgRoto.FileName);
                    lastSave = saveDlgRoto.FileName;
                }
                saveDlgRoto.Dispose();
            }
        }

        private void closeAllItem_Click(object sender, EventArgs e)
        {
            inputMovie = null;
            maker = null;
            UpdateMenuBar();
            Invalidate();
        }

        private void exitItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Movie Menu
        private void openSourceMovieItem_Click(object sender, EventArgs e)
        {
            if (openDlgMovie.ShowDialog() == DialogResult.OK)
            {
                if(inputMovie == null)
                {
                    inputMovie = new Movie();
                }

                inputMovie.Open(openDlgMovie.FileName);

                //the first movie opened, should set the size of the output
                SetupMaker();
                if (maker.SourceMovie == null)
                {
                    maker.Width = inputMovie.Width;
                    maker.Height = inputMovie.Height;
                }

                maker.SourceMovie = inputMovie;

                //pull audio if  desired
                if (useSourceAudioItem.Checked)
                {
                    maker.Audio = inputMovie.GetAudio();
                }
            }
            UpdateMenuBar();
            Invalidate();
        }

        private void generateVideoItem_Click(object sender, EventArgs e)
        {
            if (saveDlgOutMovie.ShowDialog() == DialogResult.OK)
            {
                if (maker != null)
                    maker.ProcClipVideo(saveDlgOutMovie.FileName);
            }
            UpdateMenuBar();
            Invalidate();
            
        }

        private void pullAudioItem_Click(object sender, EventArgs e)
        {
            if (saveDlgAudio.ShowDialog() == DialogResult.OK)
            {
                if (inputMovie != null)
                {
                    Sound sound = inputMovie.GetAudio();
                    sound.SaveAs(saveDlgAudio.FileName, (SoundFileTypes)(saveDlgAudio.FilterIndex-1));
                }
            }

        }

        private void closeMovieItem_Click(object sender, EventArgs e)
        {
            inputMovie.Close();
            inputMovie = null;

            UpdateMenuBar();
            Invalidate();
        }


        private void openAudioItem_Click(object sender, EventArgs e)
        {
            if (openDlgAudio.ShowDialog() == DialogResult.OK)
            {
                if (maker != null)
                {
                    maker.Audio=new Sound(openDlgAudio.FileName);
                    useSourceAudioItem.Checked = false;
                    openAudioItem.Checked = true;
                }
            }

            UpdateMenuBar();
            Invalidate();
        }

        private void closeAudioItem_Click(object sender, EventArgs e)
        {
            maker.Audio= null;
            UpdateMenuBar();
            Invalidate();
        }

        private  void useSourceAudioItem_Click(object sender, EventArgs e)
        {
            useSourceAudioItem.Checked = !useSourceAudioItem.Checked;

            if (maker != null) {
                if (useSourceAudioItem.Checked)
                {
                    maker.Audio=  inputMovie.GetAudio();
                    openAudioItem.Checked = false;
                }
                else
                {
                    maker.Audio.Close();
                    maker.Audio=null;
                }
            }
            UpdateMenuBar();
            
        }
        #endregion

        #region Frame menu

        private void createFrameItem_Click(object sender, EventArgs e)
        {
            maker.CreateOneFrame();
            Invalidate();
        }

        private  void writeThenCreateFrameItem_Click(object sender, EventArgs e)
        {
            maker.WriteFrame();
            maker.CreateOneFrame();
            Invalidate();
        }

        private void writeFrameItem_Click(object sender, EventArgs e)
        {
            maker.WriteFrame();
        }

        private void writeThenCreateSecondItem_Click(object sender, EventArgs e)
        {
            ProgressBar dlg = new ProgressBar();
            dlg.Show();
            int count = (int)(maker.FPS + 0.5);
            for (int i = 0; i < count; i++)
            {
                maker.WriteFrame();
                maker.CreateOneFrame();
               
                //out of bound check?
                if (!inputMovie.HasMoreVideo)
                    break;

                dlg.UpdateProgress(i / count);
            }

            dlg.Dispose();
            UpdateMenuBar();

        }

        private void writeThenCreateRemainingItem_Click(object sender, EventArgs e)
        {
            var watch = new System.Diagnostics.Stopwatch();

            watch.Start();
            int count = inputMovie.TotalFrames - inputMovie.Position+1;
            float i = 0;

            ProgressBar dlg = new ProgressBar();
            dlg.Show();

            //TODO remove 1000  later
            while (inputMovie.HasMoreVideo)
            {
                maker.WriteFrame();
                maker.CreateOneFrame();
                dlg.UpdateProgress( i / count);
                i++;
            }
            dlg.Dispose();


            watch.Stop();

            Debug.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            UpdateMenuBar();
        }
        #endregion

        #endregion

        #region Mouse handlers
        private bool mouseDown = false;

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Point mouseLoc = new Point(e.X, e.Y - menuStrip1.Height - toolStrip1.Height - toolStrip2.Height);
            mouseDown = true;

            if (maker != null)
            {
                if (dotSelector.Checked || birdSelector.Checked)
                {
                    maker.Mouse(mouseLoc);
                }
                else if (lineSelector.Checked)
                {
                    maker.MouseDown(mouseLoc);
                }
            }

            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            Point mouseLoc = new Point(e.X, e.Y - menuStrip1.Height - toolStrip1.Height - toolStrip2.Height);
            mouseDown = false;

            if (maker != null && lineSelector.Checked)
            {
                maker.MouseUp(mouseLoc);
            }

            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            Point mouseLoc = new Point(e.X, e.Y - menuStrip1.Height - toolStrip1.Height - toolStrip2.Height);

            if (maker != null && mouseDown && dotSelector.Checked)
            {
                maker.Mouse(mouseLoc);
            }

            Invalidate();
        }



        #endregion


        /// <summary>
        /// Helper function to delete files that may temporarily be in use while closing a folder.
        /// </summary>
        /// <param name="file">file to delete</param>
        public static void VolitilePermissionDelete(string file)
        {
            //delete file
            int maxAttempts = 10;
            int attempt = 0;
            bool success = false;
            while (!success && attempt < maxAttempts)
            {
                try
                {
                    File.Delete(file);
                    success = true;
                }
                catch (Exception)
                {
                    Debug.WriteLine("File delayed: " + file); //delay slightly for the filesystem to catchup
                    Thread.Sleep(100);
                }
            }

            if (!success)
                Debug.WriteLine("File could not be deleted: " + file);
        }

        private void clearFrame_Click(object sender, EventArgs e)
        {
            maker.OnEditClearFrame();
            Invalidate();
        }

        private void dotSelector_Click(object sender, EventArgs e)
        {
            dotSelector.Checked = true;
            lineSelector.Checked = false;
            birdSelector.Checked = false;
            maker.BirdUp = false;
            maker.BuildFrame();
        }

        private void lineSelector_Click(object sender, EventArgs e)
        {
            lineSelector.Checked = true;
            dotSelector.Checked = false;
            birdSelector.Checked = false;
            maker.BirdUp = false;
            maker.BuildFrame();
        }
        private void birdSelector_Click(object sender, EventArgs e)
        {
            birdSelector.Checked = true;
            dotSelector.Checked = false;
            lineSelector.Checked = false;

            maker.BirdUp = true;
            maker.BuildFrame();
        }

        private void dotColorSelector_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                dotColorSelector.BackColor = maker.DotColor = colorDialog1.Color;
            }
            maker.BuildFrame();
        }

        private void lineColorSelector_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                lineColorSelector.BackColor = maker.LineColor = colorDialog1.Color;
            }
            maker.BuildFrame();
        }

        private void lineThicknessSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            maker.LineThickness = lineThicknessSelector.SelectedIndex + 1;
            maker.BuildFrame();
        }

        private void dotThicknessSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            maker.DotThickness = dotThicknessSelector.SelectedIndex + 1;
            maker.BuildFrame();
        }

        private void rotateSelector_Click(object sender, EventArgs e)
        {
            if(rotateSelector.Checked)
            {
                rotateSelector.Checked = maker.RotateThing = false;
            }
            else
            {
                rotateSelector.Checked = maker.RotateThing = true;
            }
        }
    }
}
