namespace Rotoscope
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moviesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMovieItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeMovieItem = new System.Windows.Forms.ToolStripMenuItem();
            this.useSourceAudioItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pullAudioItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.generateVideoItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.openAudioItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAudioItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playbackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createFrameItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.writeFrameItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeThenCreateFrameItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeThenCreateSecondItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeThenCreateRemainingItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearFrame = new System.Windows.Forms.ToolStripMenuItem();
            this.openDlgRoto = new System.Windows.Forms.OpenFileDialog();
            this.openDlgMovie = new System.Windows.Forms.OpenFileDialog();
            this.openDlgAudio = new System.Windows.Forms.OpenFileDialog();
            this.saveDlgRoto = new System.Windows.Forms.SaveFileDialog();
            this.saveDlgAudio = new System.Windows.Forms.SaveFileDialog();
            this.openDlgOutMovie = new System.Windows.Forms.OpenFileDialog();
            this.saveDlgOutMovie = new System.Windows.Forms.SaveFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.createFrameItem_toolStrip = new System.Windows.Forms.ToolStripButton();
            this.clearFrameButton = new System.Windows.Forms.ToolStripButton();
            this.writeFrameItem_toolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.writeThenCreateFrameItem_toolStrip = new System.Windows.Forms.ToolStripButton();
            this.writeThenCreateSecondItem_toolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.writeThenCreateRemainingItem_toolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.dotSelector = new System.Windows.Forms.ToolStripButton();
            this.dotColorSelector = new System.Windows.Forms.ToolStripButton();
            this.dotThicknessSelector = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.lineSelector = new System.Windows.Forms.ToolStripButton();
            this.lineColorSelector = new System.Windows.Forms.ToolStripButton();
            this.lineThicknessSelector = new System.Windows.Forms.ToolStripComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.birdSelector = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.moviesToolStripMenuItem,
            this.playbackToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1108, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newItem,
            this.openItem,
            this.saveAsItem,
            this.saveItem,
            this.closeItem,
            this.toolStripSeparator4,
            this.exitItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newItem
            // 
            this.newItem.Name = "newItem";
            this.newItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newItem.Size = new System.Drawing.Size(146, 22);
            this.newItem.Text = "New";
            this.newItem.Click += new System.EventHandler(this.newItem_Click);
            // 
            // openItem
            // 
            this.openItem.Name = "openItem";
            this.openItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openItem.Size = new System.Drawing.Size(146, 22);
            this.openItem.Text = "Open";
            this.openItem.Click += new System.EventHandler(this.openRotoItem_Click);
            // 
            // saveAsItem
            // 
            this.saveAsItem.Name = "saveAsItem";
            this.saveAsItem.Size = new System.Drawing.Size(146, 22);
            this.saveAsItem.Text = "Save As";
            this.saveAsItem.Click += new System.EventHandler(this.saveAsRotoItem_Click);
            // 
            // saveItem
            // 
            this.saveItem.Name = "saveItem";
            this.saveItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveItem.Size = new System.Drawing.Size(146, 22);
            this.saveItem.Text = "Save";
            this.saveItem.Click += new System.EventHandler(this.saveRotoItem_Click);
            // 
            // closeItem
            // 
            this.closeItem.Name = "closeItem";
            this.closeItem.Size = new System.Drawing.Size(146, 22);
            this.closeItem.Text = "Close";
            this.closeItem.Click += new System.EventHandler(this.closeAllItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(143, 6);
            // 
            // exitItem
            // 
            this.exitItem.Name = "exitItem";
            this.exitItem.Size = new System.Drawing.Size(146, 22);
            this.exitItem.Text = "Exit";
            this.exitItem.Click += new System.EventHandler(this.exitItem_Click);
            // 
            // moviesToolStripMenuItem
            // 
            this.moviesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMovieItem,
            this.closeMovieItem,
            this.useSourceAudioItem,
            this.pullAudioItem,
            this.toolStripSeparator1,
            this.generateVideoItem,
            this.toolStripSeparator2,
            this.openAudioItem,
            this.closeAudioItem});
            this.moviesToolStripMenuItem.Name = "moviesToolStripMenuItem";
            this.moviesToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.moviesToolStripMenuItem.Text = "Movies";
            // 
            // openMovieItem
            // 
            this.openMovieItem.Name = "openMovieItem";
            this.openMovieItem.Size = new System.Drawing.Size(177, 22);
            this.openMovieItem.Text = "Open source movie";
            this.openMovieItem.Click += new System.EventHandler(this.openSourceMovieItem_Click);
            // 
            // closeMovieItem
            // 
            this.closeMovieItem.Name = "closeMovieItem";
            this.closeMovieItem.Size = new System.Drawing.Size(177, 22);
            this.closeMovieItem.Text = "Close source movie";
            this.closeMovieItem.Click += new System.EventHandler(this.closeMovieItem_Click);
            // 
            // useSourceAudioItem
            // 
            this.useSourceAudioItem.Checked = true;
            this.useSourceAudioItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useSourceAudioItem.Name = "useSourceAudioItem";
            this.useSourceAudioItem.Size = new System.Drawing.Size(177, 22);
            this.useSourceAudioItem.Text = "Use source audio";
            this.useSourceAudioItem.Click += new System.EventHandler(this.useSourceAudioItem_Click);
            // 
            // pullAudioItem
            // 
            this.pullAudioItem.Name = "pullAudioItem";
            this.pullAudioItem.Size = new System.Drawing.Size(177, 22);
            this.pullAudioItem.Text = "Save movie audio";
            this.pullAudioItem.Click += new System.EventHandler(this.pullAudioItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // generateVideoItem
            // 
            this.generateVideoItem.Name = "generateVideoItem";
            this.generateVideoItem.Size = new System.Drawing.Size(177, 22);
            this.generateVideoItem.Text = "Generate Video";
            this.generateVideoItem.Click += new System.EventHandler(this.generateVideoItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(174, 6);
            // 
            // openAudioItem
            // 
            this.openAudioItem.Name = "openAudioItem";
            this.openAudioItem.Size = new System.Drawing.Size(177, 22);
            this.openAudioItem.Text = "Open audio file";
            this.openAudioItem.Click += new System.EventHandler(this.openAudioItem_Click);
            // 
            // closeAudioItem
            // 
            this.closeAudioItem.Name = "closeAudioItem";
            this.closeAudioItem.Size = new System.Drawing.Size(177, 22);
            this.closeAudioItem.Text = "Close audio file";
            this.closeAudioItem.Click += new System.EventHandler(this.closeAudioItem_Click);
            // 
            // playbackToolStripMenuItem
            // 
            this.playbackToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createFrameItem,
            this.toolStripSeparator3,
            this.writeFrameItem,
            this.writeThenCreateFrameItem,
            this.writeThenCreateSecondItem,
            this.writeThenCreateRemainingItem});
            this.playbackToolStripMenuItem.Name = "playbackToolStripMenuItem";
            this.playbackToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.playbackToolStripMenuItem.Text = "Frame";
            // 
            // createFrameItem
            // 
            this.createFrameItem.Name = "createFrameItem";
            this.createFrameItem.Size = new System.Drawing.Size(221, 22);
            this.createFrameItem.Text = "Create 1 frame";
            this.createFrameItem.Click += new System.EventHandler(this.createFrameItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(218, 6);
            // 
            // writeFrameItem
            // 
            this.writeFrameItem.Name = "writeFrameItem";
            this.writeFrameItem.Size = new System.Drawing.Size(221, 22);
            this.writeFrameItem.Text = "Write 1 frame";
            this.writeFrameItem.Click += new System.EventHandler(this.writeFrameItem_Click);
            // 
            // writeThenCreateFrameItem
            // 
            this.writeThenCreateFrameItem.Name = "writeThenCreateFrameItem";
            this.writeThenCreateFrameItem.Size = new System.Drawing.Size(221, 22);
            this.writeThenCreateFrameItem.Text = "Write then create 1 frame";
            this.writeThenCreateFrameItem.Click += new System.EventHandler(this.writeThenCreateFrameItem_Click);
            // 
            // writeThenCreateSecondItem
            // 
            this.writeThenCreateSecondItem.Name = "writeThenCreateSecondItem";
            this.writeThenCreateSecondItem.Size = new System.Drawing.Size(221, 22);
            this.writeThenCreateSecondItem.Text = "Write then create 1 second";
            this.writeThenCreateSecondItem.Click += new System.EventHandler(this.writeThenCreateSecondItem_Click);
            // 
            // writeThenCreateRemainingItem
            // 
            this.writeThenCreateRemainingItem.Name = "writeThenCreateRemainingItem";
            this.writeThenCreateRemainingItem.Size = new System.Drawing.Size(221, 22);
            this.writeThenCreateRemainingItem.Text = "Write then create remaining";
            this.writeThenCreateRemainingItem.Click += new System.EventHandler(this.writeThenCreateRemainingItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearFrame});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // clearFrame
            // 
            this.clearFrame.Name = "clearFrame";
            this.clearFrame.Size = new System.Drawing.Size(137, 22);
            this.clearFrame.Text = "Clear Frame";
            this.clearFrame.Click += new System.EventHandler(this.clearFrame_Click);
            // 
            // openDlgRoto
            // 
            this.openDlgRoto.FileName = "openFileDialogRoto";
            this.openDlgRoto.Filter = "XML (*.xml)|*.xml|All Files (*.*)|*.*";
            // 
            // openDlgMovie
            // 
            this.openDlgMovie.Filter = "Video Files (*.avi;*.wmv; *.mp4)|*.avi; *.wmv; *.mp4|All Files (*.*)|*.*";
            // 
            // openDlgAudio
            // 
            this.openDlgAudio.FileName = "openFileDialog1";
            this.openDlgAudio.Filter = "Audio Files (*.wav;*.mp3)|*.wav; *.mp3|All Files (*.*)|*.*";
            // 
            // saveDlgRoto
            // 
            this.saveDlgRoto.Filter = "XML (*.xml)|*.xml|All Files (*.*)|*.*";
            // 
            // saveDlgAudio
            // 
            this.saveDlgAudio.Filter = "WAV (*.wav) |*.wav| MP3 (*.mp3) | *.mp3|All Files (*.*)|*.*";
            // 
            // openDlgOutMovie
            // 
            this.openDlgOutMovie.FileName = "openDlgOutMovie";
            this.openDlgOutMovie.Filter = "MP4 Files (*.mp4)|*.mp4|All Files (*.*)|*.*";
            // 
            // saveDlgOutMovie
            // 
            this.saveDlgOutMovie.Filter = "MP4 Files (*.mp4)|*.mp4|All Files (*.*)|*.*";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createFrameItem_toolStrip,
            this.clearFrameButton,
            this.writeFrameItem_toolStrip,
            this.toolStripSeparator5,
            this.writeThenCreateFrameItem_toolStrip,
            this.writeThenCreateSecondItem_toolStrip,
            this.toolStripSeparator6,
            this.writeThenCreateRemainingItem_toolStrip,
            this.toolStripSeparator7});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1108, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // createFrameItem_toolStrip
            // 
            this.createFrameItem_toolStrip.BackColor = System.Drawing.SystemColors.Control;
            this.createFrameItem_toolStrip.Image = ((System.Drawing.Image)(resources.GetObject("createFrameItem_toolStrip.Image")));
            this.createFrameItem_toolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.createFrameItem_toolStrip.Name = "createFrameItem_toolStrip";
            this.createFrameItem_toolStrip.Size = new System.Drawing.Size(97, 22);
            this.createFrameItem_toolStrip.Text = "Create Frame";
            this.createFrameItem_toolStrip.Click += new System.EventHandler(this.createFrameItem_Click);
            // 
            // clearFrameButton
            // 
            this.clearFrameButton.Image = ((System.Drawing.Image)(resources.GetObject("clearFrameButton.Image")));
            this.clearFrameButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearFrameButton.Name = "clearFrameButton";
            this.clearFrameButton.Size = new System.Drawing.Size(90, 22);
            this.clearFrameButton.Text = "Clear Frame";
            this.clearFrameButton.Click += new System.EventHandler(this.clearFrame_Click);
            // 
            // writeFrameItem_toolStrip
            // 
            this.writeFrameItem_toolStrip.Image = ((System.Drawing.Image)(resources.GetObject("writeFrameItem_toolStrip.Image")));
            this.writeFrameItem_toolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.writeFrameItem_toolStrip.Name = "writeFrameItem_toolStrip";
            this.writeFrameItem_toolStrip.Size = new System.Drawing.Size(91, 22);
            this.writeFrameItem_toolStrip.Text = "Write Frame";
            this.writeFrameItem_toolStrip.Click += new System.EventHandler(this.writeFrameItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // writeThenCreateFrameItem_toolStrip
            // 
            this.writeThenCreateFrameItem_toolStrip.Image = ((System.Drawing.Image)(resources.GetObject("writeThenCreateFrameItem_toolStrip.Image")));
            this.writeThenCreateFrameItem_toolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.writeThenCreateFrameItem_toolStrip.Name = "writeThenCreateFrameItem_toolStrip";
            this.writeThenCreateFrameItem_toolStrip.Size = new System.Drawing.Size(141, 22);
            this.writeThenCreateFrameItem_toolStrip.Text = "Write && Create Frame";
            this.writeThenCreateFrameItem_toolStrip.ToolTipText = "Write & Create Frame";
            this.writeThenCreateFrameItem_toolStrip.Click += new System.EventHandler(this.writeThenCreateFrameItem_Click);
            // 
            // writeThenCreateSecondItem_toolStrip
            // 
            this.writeThenCreateSecondItem_toolStrip.Image = ((System.Drawing.Image)(resources.GetObject("writeThenCreateSecondItem_toolStrip.Image")));
            this.writeThenCreateSecondItem_toolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.writeThenCreateSecondItem_toolStrip.Name = "writeThenCreateSecondItem_toolStrip";
            this.writeThenCreateSecondItem_toolStrip.Size = new System.Drawing.Size(135, 22);
            this.writeThenCreateSecondItem_toolStrip.Text = "Write && Create 1 Sec";
            this.writeThenCreateSecondItem_toolStrip.ToolTipText = "Write & Create 1 Sec";
            this.writeThenCreateSecondItem_toolStrip.Click += new System.EventHandler(this.writeThenCreateSecondItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // writeThenCreateRemainingItem_toolStrip
            // 
            this.writeThenCreateRemainingItem_toolStrip.Image = ((System.Drawing.Image)(resources.GetObject("writeThenCreateRemainingItem_toolStrip.Image")));
            this.writeThenCreateRemainingItem_toolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.writeThenCreateRemainingItem_toolStrip.Name = "writeThenCreateRemainingItem_toolStrip";
            this.writeThenCreateRemainingItem_toolStrip.Size = new System.Drawing.Size(162, 22);
            this.writeThenCreateRemainingItem_toolStrip.Text = "Write && Create Remaning";
            this.writeThenCreateRemainingItem_toolStrip.ToolTipText = "Write & Create Remaning";
            this.writeThenCreateRemainingItem_toolStrip.Click += new System.EventHandler(this.writeThenCreateRemainingItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator9,
            this.dotSelector,
            this.dotColorSelector,
            this.dotThicknessSelector,
            this.toolStripSeparator8,
            this.lineSelector,
            this.lineColorSelector,
            this.lineThicknessSelector,
            this.toolStripSeparator10,
            this.birdSelector});
            this.toolStrip2.Location = new System.Drawing.Point(0, 49);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1108, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(81, 22);
            this.toolStripLabel1.Text = "Drawing Tools";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
            // 
            // dotSelector
            // 
            this.dotSelector.Checked = true;
            this.dotSelector.CheckState = System.Windows.Forms.CheckState.Checked;
            this.dotSelector.Image = ((System.Drawing.Image)(resources.GetObject("dotSelector.Image")));
            this.dotSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dotSelector.Name = "dotSelector";
            this.dotSelector.Size = new System.Drawing.Size(46, 22);
            this.dotSelector.Text = "Dot";
            this.dotSelector.Click += new System.EventHandler(this.dotSelector_Click);
            // 
            // dotColorSelector
            // 
            this.dotColorSelector.Image = ((System.Drawing.Image)(resources.GetObject("dotColorSelector.Image")));
            this.dotColorSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dotColorSelector.Name = "dotColorSelector";
            this.dotColorSelector.Size = new System.Drawing.Size(78, 22);
            this.dotColorSelector.Text = "Dot Color";
            this.dotColorSelector.ToolTipText = "Dot Color";
            this.dotColorSelector.Click += new System.EventHandler(this.dotColorSelector_Click);
            // 
            // dotThicknessSelector
            // 
            this.dotThicknessSelector.Items.AddRange(new object[] {
            "1px",
            "2px",
            "3px",
            "4px",
            "5px",
            "6px",
            "7px",
            "8px",
            "9px",
            "10px",
            "11px",
            "12px",
            "13px",
            "14px",
            "15px",
            "16px",
            "17px",
            "18px",
            "20px"});
            this.dotThicknessSelector.Name = "dotThicknessSelector";
            this.dotThicknessSelector.Size = new System.Drawing.Size(121, 25);
            this.dotThicknessSelector.Text = "Dot Thickness";
            this.dotThicknessSelector.SelectedIndexChanged += new System.EventHandler(this.dotThicknessSelector_SelectedIndexChanged);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // lineSelector
            // 
            this.lineSelector.Image = ((System.Drawing.Image)(resources.GetObject("lineSelector.Image")));
            this.lineSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineSelector.Name = "lineSelector";
            this.lineSelector.Size = new System.Drawing.Size(49, 22);
            this.lineSelector.Text = "Line";
            this.lineSelector.Click += new System.EventHandler(this.lineSelector_Click);
            // 
            // lineColorSelector
            // 
            this.lineColorSelector.Image = ((System.Drawing.Image)(resources.GetObject("lineColorSelector.Image")));
            this.lineColorSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineColorSelector.Name = "lineColorSelector";
            this.lineColorSelector.Size = new System.Drawing.Size(81, 22);
            this.lineColorSelector.Text = "Line Color";
            this.lineColorSelector.ToolTipText = "Line Color";
            this.lineColorSelector.Click += new System.EventHandler(this.lineColorSelector_Click);
            // 
            // lineThicknessSelector
            // 
            this.lineThicknessSelector.Items.AddRange(new object[] {
            "1px",
            "2px",
            "3px",
            "4px",
            "5px",
            "6px",
            "7px",
            "8px",
            "9px",
            "10px",
            "11px",
            "12px",
            "13px",
            "14px",
            "15px",
            "16px",
            "17px",
            "18px",
            "20px"});
            this.lineThicknessSelector.Name = "lineThicknessSelector";
            this.lineThicknessSelector.Size = new System.Drawing.Size(121, 25);
            this.lineThicknessSelector.Text = "Line Thickness";
            this.lineThicknessSelector.SelectedIndexChanged += new System.EventHandler(this.lineThicknessSelector_SelectedIndexChanged);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
            // 
            // birdSelector
            // 
            this.birdSelector.Image = ((System.Drawing.Image)(resources.GetObject("birdSelector.Image")));
            this.birdSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.birdSelector.Name = "birdSelector";
            this.birdSelector.Size = new System.Drawing.Size(66, 22);
            this.birdSelector.Text = "Bird Up";
            this.birdSelector.ToolTipText = "Bird Up";
            this.birdSelector.Click += new System.EventHandler(this.birdSelector_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 654);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Rotoscope";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newItem;
        private System.Windows.Forms.ToolStripMenuItem playbackToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsItem;
        private System.Windows.Forms.ToolStripMenuItem saveItem;
        private System.Windows.Forms.ToolStripMenuItem closeItem;
        private System.Windows.Forms.ToolStripMenuItem exitItem;
        private System.Windows.Forms.ToolStripMenuItem moviesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMovieItem;
        private System.Windows.Forms.ToolStripMenuItem closeMovieItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem openAudioItem;
        private System.Windows.Forms.ToolStripMenuItem closeAudioItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem createFrameItem;
        private System.Windows.Forms.ToolStripMenuItem writeThenCreateFrameItem;
        private System.Windows.Forms.ToolStripMenuItem writeThenCreateSecondItem;
        private System.Windows.Forms.ToolStripMenuItem writeThenCreateRemainingItem;
        private System.Windows.Forms.OpenFileDialog openDlgRoto;
        private System.Windows.Forms.OpenFileDialog openDlgMovie;
        private System.Windows.Forms.OpenFileDialog openDlgAudio;
        private System.Windows.Forms.SaveFileDialog saveDlgRoto;
        private System.Windows.Forms.ToolStripMenuItem writeFrameItem;
        private System.Windows.Forms.ToolStripMenuItem generateVideoItem;
        private System.Windows.Forms.ToolStripMenuItem pullAudioItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.SaveFileDialog saveDlgAudio;
        private System.Windows.Forms.ToolStripMenuItem useSourceAudioItem;
        private System.Windows.Forms.OpenFileDialog openDlgOutMovie;
        private System.Windows.Forms.SaveFileDialog saveDlgOutMovie;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton createFrameItem_toolStrip;
        private System.Windows.Forms.ToolStripButton writeFrameItem_toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton writeThenCreateFrameItem_toolStrip;
        private System.Windows.Forms.ToolStripButton writeThenCreateSecondItem_toolStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton writeThenCreateRemainingItem_toolStrip;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearFrame;
        private System.Windows.Forms.ToolStripButton clearFrameButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton dotSelector;
        private System.Windows.Forms.ToolStripButton lineSelector;
        private System.Windows.Forms.ToolStripComboBox lineThicknessSelector;
        private System.Windows.Forms.ToolStripButton dotColorSelector;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripButton lineColorSelector;
        private System.Windows.Forms.ToolStripComboBox dotThicknessSelector;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton birdSelector;
    }
}

