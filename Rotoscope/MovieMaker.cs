using Rotoscope.DrawableItems;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Events;

namespace Rotoscope
{
    /// <summary>
    /// Main class for managing making a rotoscoped movie.
    /// </summary>
    public class MovieMaker
    {
        #region save locations

        private int clipCount = 0;
        private string clipSaveName = "clip_";
        private string clipSavePath = "clips\\";
        private int clipSize = 120;
        private string frameSaveName = "frame_";
        private string frameSavePath = "frames\\";
        private string tempAudioSavePath = "tempAudioOutput.wav";
        private string tempVideoSavePath = "tempVideoOutput.mp4";
        private Rotoscope roto = new Rotoscope();
        private Frame initial = new Frame();
        private Point startingPoint = new Point(0, 0);

        #endregion


        #region Properties
        /// <summary>
        /// The color of Lines you are drawing to the screen
        /// </summary>
        public Color LineColor { get; set; }
        /// <summary>
        /// The color of Dots you are drawing to the screen
        /// </summary>
        public Color DotColor { get; set; }
        /// <summary>
        /// The tickness in pixels of a line
        /// </summary>
        public int LineThickness { get; set; } = 1;
        /// <summary>
        /// The tickness in pixels of a dot
        /// </summary>
        public int DotThickness { get; set; } = 2;
        /// <summary>
        /// This will replace a dot with a bird
        /// </summary>
        public bool BirdUp { get; set; } = false;
        /// <summary>
        /// This will apply the strange rotation thing
        /// </summary>
        public bool RotateThing { get; set; } = false;

        /// <summary>
        /// The background audio for the output movie.
        /// </summary>
        public Sound Audio { get => backgroundAudio; set => backgroundAudio = value; }

        /// <summary>
        /// Current Frame being shown
        /// </summary>
        public Frame CurFrame { get => curFrame; }

        /// <summary>
        /// Current frame count written
        /// </summary>
        public int CurFrameCount { get => framenum; }

        /// <summary>
        /// Area to draw the video frame
        /// </summary>
        public Rectangle DrawArea { set => drawArea = value; }

        /// <summary>
        /// Frames per second
        /// </summary>
        public double FPS { get => fps; set => fps = value; }

        /// <summary>
        /// Height of the movie
        /// </summary>
        public int Height { get => height; set => height = value; }

        /// <summary>
        /// Movie from which to pull frames
        /// </summary>
        public Movie SourceMovie
        {
            get => sourceMovie;
            set
            {
                sourceMovie = value;
                fps = sourceMovie.FrameRate;
            }
        }

        /// <summary>
        /// Width of the movie
        /// </summary>
        public int Width { get => width; set => width = value; }

        private Sound backgroundAudio;
        private Frame curFrame;
        private double fps = 30;
        private int framenum = 0;
        private int height = 480;
        private double outputTime = 0;
        private Movie sourceMovie = null;
        private int width = 720;
        private ProgressBar bar;
        private Rectangle drawArea = new Rectangle(100, 100, 100, 100);
        private string fmt = "00000";
        private MainForm form;
        private Font drawFont = new Font("Arial", 16);
        private SolidBrush drawBrush = new SolidBrush(Color.Red);
        private string processing = "";
        #endregion

        /// <summary>
        /// Constructor for a movie maker that taken in the form in which to draw the results
        /// </summary>
        /// <param name="form"></param>
        public MovieMaker(MainForm form)
        {
            Close();
            this.form = form;
            curFrame = new Frame(width, height);

            if (!Directory.Exists(frameSavePath))
                Directory.CreateDirectory(frameSavePath);

            if (!Directory.Exists(clipSavePath))
                Directory.CreateDirectory(clipSavePath);
        }

        /// <summary>
        /// Release data sources, and clean up temporary files
        /// </summary>
        public void Close()
        {
            backgroundAudio = null;
            framenum = 0;

            if (Directory.Exists(frameSavePath))
            {
                string[] files = Directory.GetFiles(frameSavePath);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }

            if (Directory.Exists(clipSavePath))
            {
                string[] files = Directory.GetFiles(clipSavePath);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
            }
        }

        /// <summary>
        /// Handles all mouse events
        /// </summary>
        /// <param name="x">X pixel</param>
        /// <param name="y">Y pixel</param>
        public void Mouse(Point p)
        {
            if (BirdUp)
            {
                roto.AddToDrawList(framenum, new DrawableBird(p));
            }
            else
            {
                roto.AddToDrawList(framenum, new DrawableDot(p));
            }
            BuildFrame();
        }

        public void MouseDown(Point p)
        {
            startingPoint = p;
        }

        public void MouseUp(Point p)
        {
            roto.AddToDrawList(framenum, new DrawableLine(startingPoint, p));
            startingPoint = new Point(0, 0);
            BuildFrame();
        }


        /// <summary>
        /// Draw the current state of the makers
        /// </summary>
        /// <param name="graphics">graphics reference to drawn area</param>
        public void OnDraw(Graphics graphics)
        {
            curFrame.OnDraw(graphics, drawArea);

            graphics.DrawString(processing, drawFont, drawBrush, 100, 100);

            if (processing == "Completed")
                processing = "";
        }


        /// <summary>
        /// Destructor to clean up files that were made during processing
        /// </summary>
        ~MovieMaker()
        {
            Close(); 
        }


        #region Frame load and save

        /// <summary>
        /// Creates one frame. If a input movie is given, and the are frame left, the frame is pulled from the 
        /// next frame in the movie. If not, a blank, black frame is generated. 
        /// 
        /// Loading is done asyncrounously
        /// </summary>
        /// <returns>a generic task </returns>
        public void CreateOneFrame()
        {  
            curFrame.Clear();

            if (sourceMovie != null)
            {
                Bitmap newImage = sourceMovie.LoadNextFrameImage();

                //sanity chack that an image is there
                if (newImage != null)
                {
                    try
                    {

                        Graphics g = Graphics.FromImage(curFrame.Image);
                        g.DrawImage(newImage, 0, 0); //this is MUCH faster than looping through
                        newImage.Dispose(); // release the image

                        // Save a copy of the original, unmodified image                    
                        initial = new Frame(curFrame.Image);

                        BuildFrame();

                        if (RotateThing)
                        {
                            curFrame.Rotate(_rotateAngle, rotatePoint);
                            _rotateAngle += 12f; //This is the angle per fram @ 30fps
                        }
                    }
                    catch (Exception)
                    {
                        //shouldn't happen, but...
                        Debug.WriteLine("Skipped frame!!!!!!!!!!!!!!!!!!!!!!!");
                    }
                }

                form.Invalidate();
            }
        }

        /// <summary>
        /// Takes the currently made clips, and audio if given, and converts them into a movie. 
        /// It will save in in the given location.
        /// 
        /// This is done asyncrounously.
        /// </summary>
        /// <param name="savePath">the location to save the movie</param>
        /// <returns>generic task</returns>
        public void ProcClipVideo(string savePath)
        {
            //sanity check for source images
            if (framenum <= 0)
            {
                MessageBox.Show("No frames currently generated", "Processing error");
                return;
            }

            processing = "Write remaining frames...";
            form.Invalidate();

            //some frames remaining? write to clip
            if (Directory.GetFiles(frameSavePath).Count() > 0)
            {
                Task taskFrames = Task.Run(() => WriteClip());
                taskFrames.Wait();
            }

            outputTime = (double)(framenum) / fps;

            //concatenate clip to the full movie first

            processing = "Concatenating clips..";
            form.Invalidate();

            //one clip, rename to output
            if (Directory.GetFiles(clipSavePath).Count() <= 1)
            {
                string file = Directory.GetFiles(clipSavePath).First();
                if (File.Exists(tempVideoSavePath))
                {
                    File.Delete(tempVideoSavePath);
                }
                File.Move(file, tempVideoSavePath);
            }
            else
            {
                //more than one clip, concat
                try
                {
                    Task taskConcat = Task.Run(() => ConcatClips());
                    taskConcat.Wait();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Processing error");
                }
            }


            //find silent video location
            Task<IMediaInfo> taskVid = Task.Run(() => FFmpeg.GetMediaInfo(tempVideoSavePath));
            IMediaInfo mediaInfoVid = taskVid.Result;

            //grab the video stream 
            IVideoStream video = mediaInfoVid.VideoStreams.First();

            //if there is a sound object, pull the audio information
            IMediaInfo mediaInfo = null;
            if (backgroundAudio != null)
            {
                Task<IMediaInfo> taskAudio = Task.Run(() => 
                                FFmpeg.GetMediaInfo(backgroundAudio.Filename));

                mediaInfo = taskAudio.Result;
            }

            try
            {
                processing = "Adding audio...";
                form.Invalidate();

                //make a new video (overwrite if needed), with the given video stream
                IConversion convert = FFmpeg.Conversions.New()
                    .AddStream(video)
                    .SetOutput(savePath)
                    .SetFrameRate(fps)
                    .SetOverwriteOutput(true);

                //if there is audio, add that stream
                if (mediaInfo != null)
                {
                    convert.AddStream(mediaInfo.AudioStreams);
                }

                //monitor and onvert
                Task taskConvert = Task.Run(() => convert.Start());
                taskConvert.Wait();

                processing = "Completed";
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Processing error");
            }
        }

        /// <summary>
        /// Takes the currently made frames, and audio if given, and converts them into a movie. 
        /// It will save in in the given location.
        /// 
        /// This is done asyncrounously.
        /// </summary>
        /// <param name="savePath">the location to save the movie</param>
        public async void ProcFrameVideo(string savePath)
        {
            //sanity check for source images
            if (framenum <= 0)
            {
                MessageBox.Show("No frames currently generated", "Processing error");
                return;
            }

            bar = new ProgressBar();
            bar.Show();

            //if there is a sound object, pull the audio
            IMediaInfo mediaInfo = null;

            //check if audio is avilable
            if (backgroundAudio != null)
            {
                //save the file locally for ease
                string tempAudio = tempAudioSavePath;
                if (File.Exists(tempAudio))
                {
                    File.Delete(tempAudio);
                }
                backgroundAudio.SaveAs(tempAudio, SoundFileTypes.MP3);

                mediaInfo = await FFmpeg.GetMediaInfo(backgroundAudio.Filename);
            }

            try
            {

                //grab file list, and setup for stitching
                List<string> files = Directory.EnumerateFiles(frameSavePath).ToList();
                outputTime = (double)files.Count / fps;

                //make a new file, overwrite if needed, with the FPS, and using the mp4 file format for movie frames
                IConversion convert = FFmpeg.Conversions.New()
                    .SetOverwriteOutput(true)
                    .SetInputFrameRate(fps)
                    .BuildVideoFromImages(files)
                    .SetFrameRate(fps)
                    .SetPixelFormat(Xabe.FFmpeg.PixelFormat.yuv420p)
                    .SetOutput(savePath);

                //if there is audio, add that stream
                if (mediaInfo != null) {
                    convert.AddStream(mediaInfo.AudioStreams);
                }

                //monitor and onvert
                convert.OnProgress += Progress;
                await convert.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Processing error");
            }
            finally
            {
                bar.Dispose();
            }
        }

        /// <summary>
        /// Creates a image file with the current frame to later be used in making the movie.
        /// </summary>
        /// <returns>generic task</returns>
        public void WriteFrame()
        {
            string name = frameSavePath + frameSaveName + framenum.ToString(fmt) + ".png";

            curFrame.SaveFile(name, ImageFormat.Png);
            framenum++;

            if (framenum % clipSize == 0)
            {
                Task task = Task.Run(() => WriteClip());
                task.Wait();
            }
        }

        /// <summary>
        /// Helper function to concatenate saved, silent, clips in the clip directory
        /// </summary>
        /// <param name="progressBar">should a progress bar be shown</param>
        /// <returns></returns>
        private async Task ConcatClips()
        {
            string[] files = Directory.GetFiles(clipSavePath);

            //nothing to do
            if (files.Length <= 1)
                return;

            try
            {

                IConversion result = await Concatenate(tempVideoSavePath, files);
                await result.Start();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Concatenate failure");
            }
        }


        /// <summary>
        /// Concatenate a list of videos together with no sound.
        /// </summary>
        /// <param name="output">where to save the result</param>
        /// <param name="inputVideos">a list of video file names to concatenate</param>
        /// <returns>a conversion interface that can be started later</returns>
        private async Task<IConversion> Concatenate(string output, params string[] inputVideos)
        {
            if (inputVideos.Length <= 1)
            {
                throw new ArgumentException("You must provide at least 2 files for the concatenation to work", "inputVideos");
            }

            var mediaInfos = new List<IMediaInfo>();

            //make a new video, and overwite old video if there
            IConversion conversion = FFmpeg.Conversions.New().SetOverwriteOutput(true);

            //for all videos, add them to the list
            foreach (string inputVideo in inputVideos)
            {
                IMediaInfo mediaInfo = await FFmpeg.GetMediaInfo(inputVideo);

                mediaInfos.Add(mediaInfo);
                conversion.AddParameter($"-i \"{inputVideo}\" ");
            }

            //set up FFmpeg command line argumetns to concatenate
            conversion.AddParameter($"-filter_complex \"");
            conversion.AddParameter($"concat=n={inputVideos.Length}:v=1:a=0 [v]\" -map \"[v]\"");

            return conversion.SetOutput(output);
        }

        /// <summary>
        /// Monitoring function
        /// </summary>
        /// <param name="o">the objec that sent the event</param>
        /// <param name="args">details aboutthe evernt and progress</param>
        private void Progress(object o, ConversionProgressEventArgs args)
        {
            double percent = args.Duration.TotalSeconds / outputTime;

            bar.UpdateProgress(percent);
        }


        /// <summary>
        /// Save a set of frames to a movie clip. This acts as cacheing 
        /// as movie clips take less space than idependent frames.
        /// </summary>
        /// <returns>generic task</returns>
        private async Task WriteClip()
        {
            string name = clipSavePath + clipSaveName + clipCount.ToString(fmt) + ".mp4";

            try
            {
                //grab file list, and setup for stitching
                List<string> files = Directory.EnumerateFiles(frameSavePath).ToList();

                Debug.WriteLine("Frames: " + files.ToString());
                outputTime = (double)files.Count / fps; //length of time to monitor progress

                //make a new mp4, with the curent video FPS, and frame images. Overwrite allowed
                IConversion convert = FFmpeg.Conversions.New()
                    .SetOverwriteOutput(true)
                    .SetInputFrameRate(fps)
                    .BuildVideoFromImages(files)
                    .SetFrameRate(fps)
                    .SetPixelFormat(Xabe.FFmpeg.PixelFormat.yuv420p)
                    .SetOutput(name);

                await convert.Start();

                //memory cleanup as frame files are no longer needed
                foreach (string file in files)
                {
                    MainForm.VolitilePermissionDelete(file);
                }
                clipCount++;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Clip save error");
            }
        }
        #endregion


        /// <summary>
        /// OnSaveRotoscope
        /// </summary>
        public bool OnSaveRotoscope(string filename)
        {
            //
            // Open an XML document
            //
            XmlDocument doc = new XmlDocument();

            //
            // Make first node
            XmlElement root = doc.CreateElement("movie");

            //
            // Have children save inside this node
            //
            roto.OnSaveRotoscope(doc, root);

            //Save the resulting DOM tree to a file
            doc.AppendChild(root);

            try
            {
                //
                // Make the output indented, and save
                //
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(filename, settings);
                doc.Save(writer);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Save Rotoscope Error");
                return false;
            }

            return true;
        }

        /// <summary>
        /// OnOpenRotoscope
        /// </summary>
        public void OnOpenRotoscope(string filename)
        {

            //
            // Open an XML document
            //
            XmlDocument reader = new XmlDocument();
            reader.Load(filename);

            //
            // Traverse the XML document in memory!!!!
            //

            foreach (XmlNode node in reader.ChildNodes)
            {
                if (node.Name == "movie")
                {
                    roto.OnOpenRotoscope(node);
                }
            }
        }

        /// <summary>
        /// OnEditClearFrame
        /// </summary>
        public void OnEditClearFrame()
        {
            roto.ClearFrame(framenum);
            BuildFrame();
        }

        /// <summary>
        /// BuildFrame
        /// </summary>
        public void BuildFrame()
        {
            curFrame = new Frame(initial.Image);

            // Write any saved drawings into the frame
            foreach (DrawableItem drawableItem in roto.GetFromDrawList(framenum))
            {
                if (drawableItem is DrawableBird drawableBird)
                {
                    curFrame.DrawBird(drawableBird.Point);
                }
                else if(drawableItem is DrawableDot drawableDot)
                {
                    curFrame.DrawDot(drawableDot.Point, DotColor, DotThickness);
                }
                else if (drawableItem is DrawableLine drawableLine)
                {
                    curFrame.DrawLine(drawableLine.Point1, drawableLine.Point2, LineColor, LineThickness);
                    rotatePoint = new Point((drawableLine.Point1.X + drawableLine.Point2.X) / 2, (drawableLine.Point1.Y + drawableLine.Point2.Y) / 2);
                }
            }

            form.Invalidate();
        }

        private float _rotateAngle = 0;
        Point rotatePoint = new Point(0, 0);
    }
}
