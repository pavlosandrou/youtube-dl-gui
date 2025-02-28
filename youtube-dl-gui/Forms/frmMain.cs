﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace youtube_dl_gui {

    public partial class frmMain : Form {

        #region variables
        private Thread UpdateCheckThread;

        public bool ProtocolInput = false;
        #endregion

        #region form
        [DebuggerStepThrough]
        protected override void WndProc(ref Message m) {
            switch (m.Msg) {
                case Win32.WM_COPYDATA: {
                    Win32.CopyDataStruct ReceivedData = (Win32.CopyDataStruct)Marshal.PtrToStructure(m.LParam, typeof(Win32.CopyDataStruct));
                    string[] ReceivedArguments = Marshal.PtrToStringUni(ReceivedData.lpData).Split('|');
                    if (ReceivedArguments.Length > 0) {
                        if (ReceivedArguments.Length > 1) {
                            Program.CheckArgs(ReceivedArguments, false);
                        }
                        else {
                            txtUrl.Text = ReceivedArguments[0];
                        }
                    }
                } break;

                case Win32.WM_SHOWFORM: {
                    if (this.WindowState != FormWindowState.Normal)
                        this.WindowState = FormWindowState.Normal;
                    this.Show();
                    this.Activate();
                } break;

                default: {
                    base.WndProc(ref m);
                } break;
            }
        }

        public frmMain() {
            InitializeComponent();
            trayIcon.ContextMenu = cmTray;
            if (Program.IsDebug) {
                trayIcon.Visible = false;
                trayIcon.Dispose();
            }
            else {
                tcMain.TabPages.RemoveAt(3);
            }
            cbSchema.Text = Config.Settings.Downloads.fileNameSchema;
            if (!string.IsNullOrEmpty(Config.Settings.Saved.FileNameSchemaHistory)) {
                cbSchema.Items.AddRange(Config.Settings.Saved.FileNameSchemaHistory.Split('|'));
            }
        }

        private void frmMain_Load(object sender, EventArgs e) {
            if (Config.Settings.General.CheckForUpdatesOnLaunch) {
                UpdateCheckThread = new(() => {
                    try {
                        UpdateChecker.CheckForUpdate();
                    }
                    catch (ThreadAbortException) {
                        // do nothing
                    }
                    catch (Exception ex) {
                        ErrorLog.Report(ex);
                    }
                }) {
                    Name = "Checks for updates",
                    IsBackground = true
                };
                UpdateCheckThread.Start();
            }
            if (Config.Settings.Saved.MainFormSize != default) {
                this.Size = Config.Settings.Saved.MainFormSize;
            }
            if (!Program.IsDebug) {
                mDownloadSubtitles.Enabled = false;
            }

            if (Config.Settings.Saved.MainFormLocation.X != -3200 && Config.Settings.Saved.MainFormLocation.Y != -32000) {
                this.Location = Config.Settings.Saved.MainFormLocation;
            }

            LoadLanguage();

            switch (Config.Settings.General.SaveCustomArgs) {
                case 1:
                    if (System.IO.File.Exists(Environment.CurrentDirectory + "\\args.txt")) {
                        cbCustomArguments.Items.AddRange(System.IO.File.ReadAllLines(Environment.CurrentDirectory + "\\args.txt"));
                        if (Config.Settings.Saved.CustomArgumentsIndex > -1 && Config.Settings.Saved.CustomArgumentsIndex <= cbCustomArguments.Items.Count - 1) {
                            cbCustomArguments.SelectedIndex = Config.Settings.Saved.CustomArgumentsIndex;
                        }
                    }
                    break;
                case 2:
                    if (!string.IsNullOrWhiteSpace(Config.Settings.Saved.DownloadCustomArguments)) {
                        cbCustomArguments.Items.AddRange(Config.Settings.Saved.DownloadCustomArguments.Split('|'));
                        if (Config.Settings.Saved.CustomArgumentsIndex > -1 && Config.Settings.Saved.CustomArgumentsIndex <= cbCustomArguments.Items.Count - 1) {
                            cbCustomArguments.SelectedIndex = Config.Settings.Saved.CustomArgumentsIndex;
                        }
                    }
                    break;
            }
            switch (Config.Settings.Saved.downloadType) {
                case 0:
                    rbVideo.Checked = true;
                    break;
                case 1:
                    rbAudio.Checked = true;
                    break;
                case 2:
                    rbCustom.Checked = true;
                    break;
                default:
                    rbVideo.Checked = true;
                    break;
            }
            
            if (ProtocolInput) {
                if (Config.Settings.Downloads.AutomaticallyDownloadFromProtocol) {
                    // download ...
                }
            }

            if (Program.UseIni) {
                this.Text += " (ini)";
            }

            if (Config.Settings.General.DeleteUpdaterOnStartup) {
                System.IO.File.Delete(Environment.CurrentDirectory + "\\youtube-dl-gui-updater.exe");
            }
            if (Config.Settings.General.DeleteBackupOnStartup) {
                System.IO.File.Delete(Environment.CurrentDirectory + "\\youtube-dl-gui.old.exe");
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
            if (UpdateCheckThread != null && UpdateCheckThread.IsAlive) {
                UpdateCheckThread.Abort();
            }

            this.Opacity = 0;
            if (this.WindowState == FormWindowState.Minimized) {
                this.WindowState = FormWindowState.Normal;
            }

            chkUseSelection.Checked = false;
            Config.Settings.Saved.MainFormSize = this.Size;

            switch (Config.Settings.General.SaveCustomArgs) {
                case 1: // txt
                    StringBuilder txtOutputBuffer = new();
                    for (int i = 0; i < cbCustomArguments.Items.Count; i++) {
                        txtOutputBuffer.AppendLine(cbCustomArguments.GetItemText(cbCustomArguments.Items[i]));
                    }
                    System.IO.File.WriteAllText(Environment.CurrentDirectory + "\\args.txt", txtOutputBuffer.ToString());
                    Config.Settings.Saved.CustomArgumentsIndex = cbCustomArguments.SelectedIndex;
                    break;
                case 2: // settings
                    string stngOutputBuffer = string.Empty;
                    for (int i = 0; i < cbCustomArguments.Items.Count; i++) {
                        stngOutputBuffer += cbCustomArguments.GetItemText(cbCustomArguments.Items[i]) + "|";
                    }
                    Config.Settings.Saved.DownloadCustomArguments = stngOutputBuffer.Trim('|');
                    Config.Settings.Saved.CustomArgumentsIndex = cbCustomArguments.SelectedIndex;
                    break;
            }

            if (rbVideo.Checked)
                Config.Settings.Saved.downloadType = 0;
            else if (rbAudio.Checked)
                Config.Settings.Saved.downloadType = 1;
            else if (rbCustom.Checked)
                Config.Settings.Saved.downloadType = 2;
            else
                Config.Settings.Saved.downloadType = -1;

            if (rbConvertVideo.Checked)
                Config.Settings.Saved.convertType = 0;
            else if (rbConvertAudio.Checked)
                Config.Settings.Saved.convertType = 1;
            else if (rbConvertCustom.Checked)
                Config.Settings.Saved.convertType = 2;
            else if (rbConvertAutoFFmpeg.Checked)
                Config.Settings.Saved.convertType = 6;
            else
                Config.Settings.Saved.convertType = -1;

            Config.Settings.Saved.MainFormLocation = this.Location;

            Config.Settings.Save(ConfigType.Saved);
            trayIcon.Visible = false;
        }

        void LoadLanguage() {
            mSettings.Text = Program.lang.mSettings;
            mTools.Text = Program.lang.mTools;
            mBatchDownload.Text = Program.lang.mBatchDownload;
            mDownloadSubtitles.Text = Program.lang.mDownloadSubtitles;
            mMiscTools.Text = Program.lang.mMiscTools;
            mHelp.Text = Program.lang.mHelp;
            mLanguage.Text = Program.lang.mLanguage;
            mSupportedSites.Text = Program.lang.mSupportedSites;
            mAbout.Text = Program.lang.mAbout;

            tabDownload.Text = Program.lang.tabDownload;
            tabConvert.Text = Program.lang.tabConvert;
            tabMerge.Text = Program.lang.tabMerge;

            lbURL.Text = Program.lang.lbURL;
            txtUrl.TextHint = Program.lang.txtUrlHint;
            gbDownloadType.Text = Program.lang.gbDownloadType;
            rbVideo.Text = Program.lang.GenericVideo;
            rbAudio.Text = Program.lang.GenericAudio;
            rbCustom.Text = Program.lang.GenericCustom;
            lbQuality.Text = Program.lang.lbQuality;
            lbFormat.Text = Program.lang.lbFormat;
            chkDownloadSound.Text = Program.lang.chkDownloadSound;
            chkUseSelection.Text = Program.lang.chkUseSelection;
            rbVideoSelectionPlaylistIndex.Text = Program.lang.rbVideoSelectionPlaylistIndex;
            rbVideoSelectionPlaylistItems.Text = Program.lang.rbVideoSelectionPlaylistItems;
            rbVideoSelectionBeforeDate.Text = Program.lang.rbVideoSelectionBeforeDate;
            rbVideoSelectionOnDate.Text = Program.lang.rbVideoSelectionOnDate;
            rbVideoSelectionAfterDate.Text = Program.lang.rbVideoSelectionAfterDate;
            txtPlaylistStart.TextHint = Program.lang.txtPlaylistStartHint;
            txtPlaylistEnd.TextHint = Program.lang.txtPlaylistEndHint;
            txtPlaylistItems.TextHint = Program.lang.txtPlaylistItemsHint;
            txtVideoDate.TextHint = Program.lang.txtVideoDateHint;

            lbSchema.Text = Program.lang.lbSettingsDownloadsFileNameSchema;
            lbCustomArguments.Text = Program.lang.lbCustomArguments;
            sbDownload.Text = Program.lang.sbDownload;
            mDownloadWithAuthentication.Text = Program.lang.mDownloadWithAuthentication;
            mBatchDownloadFromFile.Text = Program.lang.mBatchDownloadFromFile;

            lbConvertInput.Text = Program.lang.lbConvertInput;
            lbConvertOutput.Text = Program.lang.lbConvertOutput;
            rbConvertVideo.Text = Program.lang.GenericVideo;
            rbConvertAudio.Text = Program.lang.GenericAudio;
            rbConvertCustom.Text = Program.lang.GenericCustom;
            rbConvertAuto.Text = Program.lang.rbConvertAuto;
            rbConvertAutoFFmpeg.Text = Program.lang.rbConvertAutoFFmpeg;
            btnConvert.Text = Program.lang.btnConvert;

            lbMergeInput1.Text = Program.lang.lbMergeInput1;
            lbMergeInput2.Text = Program.lang.lbMergeInput2;
            lbMergeOutput.Text = Program.lang.lbMergeOutput;
            chkMergeAudioTracks.Text = Program.lang.chkMergeAudioTracks;
            chkMergeDeleteInputFiles.Text = Program.lang.chkMergeDeleteInputFiles;
            btnMerge.Text = Program.lang.btnMerge;

            cmTrayShowForm.Text = Program.lang.cmTrayShowForm;
            cmTrayDownloader.Text = Program.lang.cmTrayDownloader;
            cmTrayDownloadClipboard.Text = Program.lang.cmTrayDownloadClipboard;
            cmTrayDownloadBestVideo.Text = Program.lang.cmTrayDownloadBestVideo;
            cmTrayDownloadBestAudio.Text = Program.lang.cmTrayDownloadBestAudio;
            cmTrayDownloadCustom.Text = Program.lang.cmTrayDownloadCustom;
            cmTrayDownloadCustomTxtBox.Text = Program.lang.cmTrayDownloadCustomTxtBox;
            cmTrayDownloadCustomTxt.Text = Program.lang.cmTrayDownloadCustomTxt;
            cmTrayDownloadCustomSettings.Text = Program.lang.cmTrayDownloadCustomSettings;
            cmTrayConverter.Text = Program.lang.cmTrayConverter;
            cmTrayConvertTo.Text = Program.lang.cmTrayConvertTo;
            cmTrayConvertVideo.Text = Program.lang.cmTrayConvertVideo;
            cmTrayConvertAudio.Text = Program.lang.cmTrayConvertAudio;
            cmTrayConvertCustom.Text = Program.lang.cmTrayConvertCustom;
            cmTrayConvertAutomatic.Text = Program.lang.cmTrayConvertAutomatic;
            cmTrayConvertAutoFFmpeg.Text = Program.lang.cmTrayConvertAutoFFmpeg;
            cmTrayExit.Text = Program.lang.cmTrayExit;

            if (cbFormat.Items.Count > 0) {
                cbFormat.Items[0] = Program.lang.GenericInputBest;
            }
            if (cbQuality.Items.Count > 0) {
                cbQuality.Items[0] = Program.lang.GenericInputBest;
            }

            CalculateLocations();
        }

        void CalculateLocations() {
            gbDownloadType.Size = new(
                ((rbVideo.Size.Width + 2) + rbAudio.Size.Width +  (rbCustom.Size.Width - 2)) + 12,
                gbDownloadType.Size.Height
            );
            gbDownloadType.Location = new(
                (tabDownload.Size.Width - gbDownloadType.Size.Width) / 2,
                gbDownloadType.Location.Y
            );

            rbVideo.Location = new(
                (gbDownloadType.Size.Width - (rbVideo.Size.Width + rbAudio.Size.Width + rbCustom.Size.Width)) / 2,
                rbVideo.Location.Y
            );
            rbAudio.Location = new(
                (rbVideo.Location.X + rbVideo.Size.Width) + 2,
                rbAudio.Location.Y
            );
            rbCustom.Location = new(
                ((rbAudio.Location.X + rbAudio.Size.Width) + 2),
                rbCustom.Location.Y
            );

            gbSelection.Size = new(
                (rbVideoSelectionBeforeDate.Size.Width + rbVideoSelectionOnDate.Size.Width + rbVideoSelectionAfterDate.Size.Width) + 12,
                20
            );
            gbSelection.Location = new(
                (tabDownload.Size.Width - gbSelection.Size.Width) / 2,
                gbSelection.Location.Y
            );
            rbVideoSelectionPlaylistIndex.Location = new(
                (gbSelection.Size.Width - (rbVideoSelectionPlaylistIndex.Size.Width + rbVideoSelectionPlaylistItems.Size.Width)) / 2,
                rbVideoSelectionPlaylistIndex.Location.Y
            );
            rbVideoSelectionPlaylistItems.Location = new(
                (rbVideoSelectionPlaylistIndex.Location.X + rbVideoSelectionPlaylistItems.Size.Width) + 2,
                rbVideoSelectionPlaylistItems.Location.Y
            );
            rbVideoSelectionBeforeDate.Location = new(
                (gbSelection.Size.Width - (rbVideoSelectionBeforeDate.Size.Width + rbVideoSelectionOnDate.Size.Width + rbVideoSelectionAfterDate.Size.Width)) / 2,
                rbVideoSelectionBeforeDate.Location.Y
            );
            rbVideoSelectionOnDate.Location = new(
                (rbVideoSelectionBeforeDate.Location.X + rbVideoSelectionBeforeDate.Size.Width) + 2,
                rbVideoSelectionOnDate.Location.Y
            );
            rbVideoSelectionAfterDate.Location = new(
                (rbVideoSelectionOnDate.Location.X + rbVideoSelectionOnDate.Width) + 2,
                rbVideoSelectionAfterDate.Location.Y
            );

            rbConvertVideo.Location = new(
                (tabConvert.Size.Width - (rbConvertVideo.Size.Width + rbConvertAudio.Size.Width + rbConvertCustom.Size.Width + 2)) / 2,
                rbConvertVideo.Location.Y
            );
            rbConvertAudio.Location = new(
                (rbConvertVideo.Location.X + rbConvertVideo.Width) + 2,
                rbConvertVideo.Location.Y
            );
            rbConvertCustom.Location = new(
                (rbConvertAudio.Location.X + rbConvertAudio.Size.Width) + 2,
                rbConvertAudio.Location.Y
            );
            rbConvertAuto.Location = new(
                ((tabConvert.Size.Width / 2) - ((rbConvertAuto.Width + rbConvertAutoFFmpeg.Width) / 2)),
                rbConvertAuto.Location.Y
            );
            rbConvertAutoFFmpeg.Location = new(
                (rbConvertAuto.Location.X + rbConvertAuto.Size.Width) + 2,
                rbConvertAutoFFmpeg.Location.Y
            );

            chkMergeAudioTracks.Location = new(
                (tabMerge.Size.Width - chkMergeAudioTracks.Size.Width) / 2,
                chkMergeAudioTracks.Location.Y
            );
            chkMergeDeleteInputFiles.Location = new(
                (tabMerge.Size.Width - chkMergeDeleteInputFiles.Size.Width) / 2,
                chkMergeDeleteInputFiles.Location.Y
            );
        }
        #endregion

        #region main menu
        private void mSettings_Click(object sender, EventArgs e) {
            using frmSettings settings = new();
            settings.ShowDialog();
            if (Program.UseIni && !this.Text.EndsWith(" (ini)")) {
                this.Text += " (ini)";
            }
            else if (!Program.UseIni && this.Text.EndsWith(" (ini)")) {
                this.Text = this.Text[0..^6];
            }
            cbSchema.Text = Config.Settings.Downloads.fileNameSchema;
            cbSchema.Items.Clear();
            if (!string.IsNullOrEmpty(Config.Settings.Saved.FileNameSchemaHistory)) {
                cbSchema.Items.AddRange(Config.Settings.Saved.FileNameSchemaHistory.Split('|'));
            }
        }

        private void mBatchDownload_Click(object sender, EventArgs e) {
            frmBatchDownloader batch = new();
            batch.Show();
        }
        private void mDownloadSubtitles_Click(object sender, EventArgs e) {
            frmSubtitles downloadSubtitles = new();
            downloadSubtitles.ShowDialog();
        }
        private void mMiscTools_Click(object sender, EventArgs e) {
            using frmMiscTools tools = new();
            tools.ShowDialog();
        }

        private void mLanguage_Click(object sender, EventArgs e) {
            using frmLanguage language = new();
            switch (language.ShowDialog()) {
                case DialogResult.Yes:
                    if (language.LanguageFile == null) {
                        Config.Settings.Initialization.LanguageFile = string.Empty;
                    }
                    else {
                        Config.Settings.Initialization.LanguageFile = language.LanguageFile;
                    }
                    Config.Settings.Initialization.Save();
                    LoadLanguage();
                    break;
            }
        }
        private void mSupportedSites_Click(object sender, EventArgs e) {
            switch (Config.Settings.Downloads.YtdlType) {
                case 1:
                    Process.Start("https://github.com/blackjack4494/youtube-dlc/blob/master/docs/supportedsites.md");
                    break;

                case 2:
                    Process.Start("https://github.com/yt-dlp/yt-dlp/blob/master/supportedsites.md");
                    break;


                default:
                    Process.Start("https://github.com/ytdl-org/youtube-dl/blob/master/docs/supportedsites.md");
                    break;
            }
        }

        private void mAbout_Click(object sender, EventArgs e) {
            using frmAbout about = new();
            about.ShowDialog();
        }
        #endregion

        #region tray menu
        private void cmTrayShowForm_Click(object sender, EventArgs e) {
            this.Show();
        }

        private void cmTrayDownloadBestVideo_Click(object sender, EventArgs e) {
            if (!Clipboard.ContainsText()) { return; }
            DownloadInfo NewInfo = new() {
                VideoQuality = (VideoQualityType)Config.Settings.Saved.videoQuality,
                Type = 0,
                DownloadURL = Clipboard.GetText()
            };
            frmDownloader Downloader = new(NewInfo);
            Downloader.Show();
        }
        private void cmTrayDownloadBestAudio_Click(object sender, EventArgs e) {
            DownloadInfo NewInfo = new() {
                AudioCBRQuality = AudioCBRQualityType.best,
                Type = DownloadType.Audio,
                DownloadURL = Clipboard.GetText()
            };
            frmDownloader Downloader = new(NewInfo);
            Downloader.Show();
        }

        private void cmTrayDownloadCustomTxtBox_Click(object sender, EventArgs e) {
            if (Clipboard.ContainsText()) {
                if (string.IsNullOrEmpty(cbCustomArguments.Text)) {
                    System.Media.SystemSounds.Asterisk.Play();
                    cbCustomArguments.Focus();
                    return;
                }
                else {
                    DownloadInfo NewInfo = new() {
                        DownloadArguments = cbCustomArguments.Text,
                        Type = DownloadType.Custom,
                        DownloadURL = Clipboard.GetText()
                    };
                    frmDownloader Downloader = new(NewInfo);
                    Downloader.Show();
                }
            }
        }
        private void cmTrayDownloadCustomTxt_Click(object sender, EventArgs e) {
            if (!Clipboard.ContainsText()) {
                if (!System.IO.File.Exists(Environment.CurrentDirectory + "\\args.txt")) {
                    MessageBox.Show(Program.lang.dlgMainArgsTxtDoesntExist, "youtube-dl-gui");
                    return;
                }
                else if (string.IsNullOrEmpty(System.IO.File.ReadAllText(Environment.CurrentDirectory + "\\args.txt"))) {
                    MessageBox.Show(Program.lang.dlgMainArgsTxtIsEmpty, "youtube-dl-gui");
                    return;
                }
                else {
                    DownloadInfo NewInfo = new() {
                        DownloadArguments = System.IO.File.ReadAllLines(Environment.CurrentDirectory + "\\args.txt")[0],
                        Type = DownloadType.Custom,
                        DownloadURL = Clipboard.GetText()
                    };
                    frmDownloader Downloader = new(NewInfo);
                    Downloader.Show();
                }
            }
        }
        private void cmTrayDownloadCustomSettings_Click(object sender, EventArgs e) {
            if (!Clipboard.ContainsText() && Config.Settings.Saved.CustomArgumentsIndex < 0) {
                if (string.IsNullOrEmpty(Config.Settings.Saved.DownloadCustomArguments)) {
                    MessageBox.Show(Program.lang.dlgMainArgsNoneSaved, "youtube-dl-gui");
                    return;
                }
                else
                {
                    DownloadInfo NewInfo = new() {
                        DownloadArguments = Config.Settings.Saved.DownloadCustomArguments.Split('|')[Config.Settings.Saved.CustomArgumentsIndex],
                        Type = DownloadType.Custom,
                        DownloadURL = Clipboard.GetText()
                    };
                    frmDownloader Downloader = new(NewInfo);
                    Downloader.Show();
                }
            }
        }

        private void cmTrayConvertVideo_Click(object sender, EventArgs e) {
            convertFromTray(ConversionType.Video);
        }
        private void cmTrayConvertAudio_Click(object sender, EventArgs e) {
            convertFromTray(ConversionType.Audio);
        }
        private void cmTrayConvertCustom_Click(object sender, EventArgs e) {
            convertFromTray(ConversionType.Custom);
        }
        private void cmTrayConvertAutomatic_Click(object sender, EventArgs e) {
            convertFromTray();
        }
        private void cmTrayConvertAutoFFmpeg_Click(object sender, EventArgs e) {
            convertFromTray(ConversionType.FfmpegDefault);
        }

        private void cmTrayExit_Click(object sender, EventArgs e) {
            Config.Settings.Save(ConfigType.All);
            trayIcon.Visible = false;
            Environment.Exit(0);
        }
        #endregion

        #region downloader
        private void rbVideo_CheckedChanged(object sender, EventArgs e) {
            if (rbVideo.Checked) {
                cbCustomArguments.Enabled = false;
                cbQuality.SelectedIndex = -1;
                cbQuality.Items.Clear();
                cbQuality.Items.AddRange(Download.Formats.VideoQualityArray);
                cbQuality.Items[0] = Program.lang.GenericInputBest;
                cbFormat.SelectedIndex = -1;
                cbFormat.Items.Clear();
                cbFormat.Items.AddRange(Download.Formats.VideoFormatsNamesArray);
                cbFormat.Items[0] = Program.lang.GenericInputBest;
                cbQuality.Enabled = true;
                cbFormat.Enabled = true;
                chkDownloadSound.Enabled = true;
                chkDownloadSound.Text = "Sound";
                if (Config.Settings.Downloads.SaveFormatQuality) {
                    cbQuality.SelectedIndex = Config.Settings.Saved.videoQuality;
                    cbFormat.SelectedIndex = Config.Settings.Saved.VideoFormat;
                    chkDownloadSound.Checked = Config.Settings.Downloads.VideoDownloadSound;
                }
                else {
                    cbQuality.SelectedIndex = 0;
                    cbFormat.SelectedIndex = 0;
                }
            }
        }
        private void rbAudio_CheckedChanged(object sender, EventArgs e) {
            if (rbAudio.Checked) {
                cbCustomArguments.Enabled = false;
                cbQuality.SelectedIndex = -1;
                cbFormat.SelectedIndex = -1;
                cbQuality.Items.Clear();
                if (Config.Settings.Downloads.AudioDownloadAsVBR) {
                    cbQuality.Items.AddRange(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" });
                }
                else {
                    cbQuality.Items.AddRange(Download.Formats.AudioQualityNamesArray);
                }
                cbFormat.Items.Clear();
                cbFormat.Items.AddRange(Download.Formats.AudioFormatsArray);
                cbQuality.Enabled = true;
                cbFormat.Enabled = true;
                chkDownloadSound.Enabled = true;
                chkDownloadSound.Checked = Config.Settings.Downloads.AudioDownloadAsVBR;
                chkDownloadSound.Text = "VBR";
                if (Config.Settings.Downloads.SaveFormatQuality) {
                    cbQuality.SelectedIndex = Config.Settings.Saved.audioQuality;
                    cbFormat.SelectedIndex = Config.Settings.Saved.AudioFormat;
                }
                else {
                    cbQuality.SelectedIndex = 0;
                    cbFormat.SelectedIndex = 0;
                }
            }
        }
        private void rbCustom_CheckedChanged(object sender, EventArgs e) {
            if (rbCustom.Checked) {
                cbCustomArguments.Enabled = true;
                cbQuality.SelectedIndex = -1;
                cbFormat.SelectedIndex = -1;
                cbQuality.Enabled = false;
                cbFormat.Enabled = false;
                chkDownloadSound.Checked = false;
                chkDownloadSound.Enabled = false;
                if (Config.Settings.Downloads.SaveFormatQuality) {
                    cbCustomArguments.SelectedIndex = Config.Settings.Saved.CustomArgumentsIndex;
                }
            }
            else {
                cbCustomArguments.Enabled = false;
            }
        }
        private void chkDownloadSound_CheckedChanged(object sender, EventArgs e) {
            if (rbAudio.Checked) {
                cbQuality.Items.Clear();

                if (chkDownloadSound.Checked) {
                    cbQuality.SelectedIndex = -1;
                    cbQuality.Items.AddRange(new string[]{"0", "1", "2", "3", "4", "5", "6", "7", "8", "9"});
                    if (Config.Settings.Downloads.SaveFormatQuality) {
                        cbQuality.SelectedIndex = Config.Settings.Saved.AudioVBRQuality;
                    }
                    else {
                        cbQuality.SelectedIndex = 0;
                    }
                }
                else {
                    cbQuality.Items.AddRange(Download.Formats.AudioQualityNamesArray);
                    cbQuality.Items[0] = Program.lang.GenericInputBest;
                    if (Config.Settings.Downloads.SaveFormatQuality) {
                        cbQuality.SelectedIndex = Config.Settings.Saved.audioQuality;
                    }
                    else {
                        cbQuality.SelectedIndex = 0;
                    }
                }
            }
        }
        private void chkUseSelection_CheckedChanged(object sender, EventArgs e) {
            // 375 minimum height

            // 86 difference

            // 274 ?? 446

            if (chkUseSelection.Checked) {
                //if (this.Size.Height < 446) {
                //    AddedHeight = (446 - this.Size.Height);
                //    gbSelection.Size = new Size(gbSelection.Size.Width, 106);
                //    this.Size = new Size(this.Width, this.Height + AddedHeight);
                //}
                //else {
                //    gbSelection.Size = new Size(gbSelection.Size.Width, 106);
                //}

                gbSelection.Size = new(gbSelection.Size.Width, 106);
                this.Size = new(this.Width, this.Height + 86);
                this.MinimumSize = new(this.MinimumSize.Width, this.MinimumSize.Height + 86);
            }
            else {
                //gbSelection.Size = new Size(gbSelection.Size.Width, 20);
                //if (this.Size.Height > 446) {
                //    this.Size = new Size(this.Width, this.Height - 86);
                //}
                //else {
                //    this.Size = new Size(this.Width, this.Height - AddedHeight);
                //}

                gbSelection.Size = new(gbSelection.Size.Width, 20);
                this.MinimumSize = new(this.MinimumSize.Width, this.MinimumSize.Height - 86);
                this.Size = new(this.Width, this.Height - 86);
            }
        }
        private void txtPlaylistItems_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',') {
                e.Handled = true;
            }
        }
        private void txtVideoDate_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) {
                e.Handled = true;
            }
        }
        private void rbVideoSelectionPlaylistIndex_CheckedChanged(object sender, EventArgs e) {
            if (rbVideoSelectionPlaylistIndex.Checked) {
                panelPlaylistStartEnd.Visible = true;
                panelPlaylistItems.Visible = false;
                panelDate.Visible = false;
                chkUseSelection.Checked = true;
            }
        }
        private void rbVideoSelectionPlaylistItems_CheckedChanged(object sender, EventArgs e) {
            if (rbVideoSelectionPlaylistItems.Checked) {
                panelPlaylistStartEnd.Visible = false;
                panelPlaylistItems.Visible = true;
                panelDate.Visible = false;
                chkUseSelection.Checked = true;
            }
        }
        private void rbVideoSelectionBeforeDate_CheckedChanged(object sender, EventArgs e) {
            if (rbVideoSelectionBeforeDate.Checked) {
                panelPlaylistStartEnd.Visible = false;
                panelPlaylistItems.Visible = false;
                panelDate.Visible = true;
                chkUseSelection.Checked = true;
            }
        }
        private void rbVideoSelectionOnDate_CheckedChanged(object sender, EventArgs e) {
            if (rbVideoSelectionOnDate.Checked) {
                panelPlaylistStartEnd.Visible = false;
                panelPlaylistItems.Visible = false;
                panelDate.Visible = true;
                chkUseSelection.Checked = true;
            }
        }
        private void rbVideoSelectionAfterDate_CheckedChanged(object sender, EventArgs e) {
            if (rbVideoSelectionAfterDate.Checked) {
                panelPlaylistStartEnd.Visible = false;
                panelPlaylistItems.Visible = false;
                panelDate.Visible = true;
                chkUseSelection.Checked = true;
            }
        }

        private void txtUrl_MouseEnter(object sender, EventArgs e) {
            if (Config.Settings.General.HoverOverURLTextBoxToPaste && txtUrl.Text != Clipboard.GetText()) {
                txtUrl.Text = Clipboard.GetText();
            }
        }
        private void txtUrl_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                StartDownload(false);
            }
        }
        private void txtArgs_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == 13) {
                StartDownload(false);
            }
        }
        private void sbDownload_Click(object sender, EventArgs e) {
            StartDownload(false);
        }
        private void mDownloadWithAuthentication_Click(object sender, EventArgs e) {
            StartDownload(true);
        }
        private void mBatchDownloadFromFile_Click(object sender, EventArgs e) {
            if (!Config.Settings.Downloads.SkipBatchTip) {
                switch (MessageBox.Show(Program.lang.msgBatchDownloadFromFile, "youtube-dl-gui", MessageBoxButtons.YesNoCancel)) {
                    case DialogResult.Cancel:
                        return;
                    case DialogResult.Yes:
                        Config.Settings.Downloads.SkipBatchTip = true;
                        break;
                }
            }

            string TextFile = string.Empty;
            using OpenFileDialog ofd = new();
            ofd.Filter = "Text Document (*.txt)|*.txt";
            ofd.Title = "Select a file with URLs...";
            ofd.Multiselect = false;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK) {
                TextFile = ofd.FileName;
            }
            else {
                return;
            }

            Thread BatchThread = new(() => {
                string videoArguments = string.Empty;
                DownloadType Type = DownloadType.None;
                int BatchQuality = 0;
                string schema = string.Empty;

                this.Invoke((Action)delegate {
                    if (!chkDownloadSound.Checked) { videoArguments += "-nosound"; }
                    BatchQuality = cbQuality.SelectedIndex;
                    if (!string.IsNullOrWhiteSpace(cbSchema.Text)) {
                        schema = cbSchema.Text;
                        if (!Config.Settings.Saved.FileNameSchemaHistory.Contains(cbSchema.Text)) {
                            cbSchema.Items.Add(cbSchema.Text);
                            if (Config.Settings.Saved.FileNameSchemaHistory == null) {
                                Config.Settings.Saved.FileNameSchemaHistory = cbSchema.Text;
                            }
                            else {
                                Config.Settings.Saved.FileNameSchemaHistory += "|" + cbSchema.Text;
                            }
                            Config.Settings.Saved.Save();
                        }
                    }
                    if (rbVideo.Checked) { Type = DownloadType.Video; }
                    else if (rbAudio.Checked) { Type = DownloadType.Audio; }
                    else if (rbCustom.Checked) { Type = DownloadType.Custom; }
                    else { Type = DownloadType.Unknown; }
                });

                if (System.IO.File.Exists(TextFile)) {
                    string[] ReadFile = System.IO.File.ReadAllLines(TextFile);
                    if (ReadFile.Length == 0) {
                        return;
                    }
                    for (int i = 0; i < ReadFile.Length; i++) {
                        DownloadInfo NewInfo = new() {
                            BatchDownload = true,
                            DownloadURL = ReadFile[i].Trim(' '),
                            FileNameSchema = schema
                        };
                        switch (Type) {
                            case DownloadType.Video:
                                if (!chkDownloadSound.Checked) {
                                    NewInfo.SkipAudioForVideos = true;
                                }
                                NewInfo.DownloadArguments = videoArguments;
                                NewInfo.VideoQuality = (VideoQualityType)BatchQuality;
                                NewInfo.Type = DownloadType.Video;
                                break;
                            case DownloadType.Audio:
                                if (chkDownloadSound.Checked) {
                                    NewInfo.AudioVBRQuality = (AudioVBRQualityType)BatchQuality;
                                }
                                else {
                                    NewInfo.AudioCBRQuality = (AudioCBRQualityType)BatchQuality;
                                }
                                NewInfo.Type = DownloadType.Audio;
                                break;
                            case DownloadType.Custom:
                                NewInfo.DownloadArguments = cbCustomArguments.Text;
                                NewInfo.Type = DownloadType.Custom;
                                break;
                            case DownloadType.Unknown:
                                NewInfo.VideoQuality = 0;
                                NewInfo.Type = DownloadType.Video;
                                break;
                        }
                        using frmDownloader Downloader = new(NewInfo);
                        Downloader.ShowDialog();
                        if (Downloader.DialogResult == DialogResult.Abort) {
                            break;
                        }
                    }
                }
            }) {
                Name = "Batch download"
            };
            BatchThread.Start();
        }

        [DebuggerStepThrough]
        private void StartDownload(bool WithAuth = false) {
            try {
                if (string.IsNullOrEmpty(txtUrl.Text)) { return; }
                txtUrl.Text = txtUrl.Text.Replace("\\", "-");
                DownloadInfo NewInfo = new();
                if (!string.IsNullOrWhiteSpace(cbSchema.Text)) {
                    NewInfo.FileNameSchema = cbSchema.Text;
                    if (!Config.Settings.Saved.FileNameSchemaHistory.Contains(cbSchema.Text)) {
                        cbSchema.Items.Add(cbSchema.Text);
                        if (Config.Settings.Saved.FileNameSchemaHistory == null) {
                            Config.Settings.Saved.FileNameSchemaHistory = cbSchema.Text;
                        }
                        else {
                            Config.Settings.Saved.FileNameSchemaHistory += "|" + cbSchema.Text;
                        }
                        Config.Settings.Saved.Save();
                    }
                }

                // First, authenticate.
                if (WithAuth) {
                    frmAuthentication auth = new();
                    if (auth.ShowDialog() == DialogResult.OK) {
                        if (auth.Username != null) {
                            NewInfo.AuthUsername = auth.Username;
                            auth.Username = null;
                        }
                        if (auth.Password != null) {
                            NewInfo.AuthPassword = auth.Password;
                            auth.Password = null;
                        }
                        if (auth.TwoFactor != null) {
                            NewInfo.Auth2Factor = auth.TwoFactor;
                            auth.TwoFactor = null;
                        }
                        if (auth.VideoPassword != null) {
                            NewInfo.AuthVideoPassword = auth.VideoPassword;
                            auth.VideoPassword = null;
                        }
                        NewInfo.AuthNetrc = auth.Netrc;
                        auth.Dispose();
                    }
                    else {
                        auth.Dispose();
                        return;
                    }
                }
                if (!rbCustom.Checked) {
                    if (chkUseSelection.Checked) {
                        if (rbVideoSelectionPlaylistIndex.Checked && txtPlaylistStart.Text.Length > 0 || txtPlaylistEnd.Text.Length > 0) {
                            NewInfo.PlaylistSelection = PlaylistSelectionType.PlaylistStartPlaylistEnd;
                            if (int.TryParse(txtPlaylistStart.Text, out int PlaylistStart)) {
                                NewInfo.PlaylistSelectionIndexStart = PlaylistStart;
                            }
                            if (int.TryParse(txtPlaylistEnd.Text, out int PlaylistEnd)) {
                                NewInfo.PlaylistSelectionIndexEnd = PlaylistEnd;
                            }
                        }
                        else if (rbVideoSelectionPlaylistItems.Checked && txtPlaylistItems.Text.Length > 0) {
                            NewInfo.PlaylistSelection = PlaylistSelectionType.PlaylistItems;
                            NewInfo.PlaylistSelectionArg = txtPlaylistItems.Text;
                        }
                        else if (rbVideoSelectionBeforeDate.Checked && txtVideoDate.Text.Length > 0) {
                            NewInfo.PlaylistSelection = PlaylistSelectionType.DateBefore;
                            NewInfo.PlaylistSelectionArg = txtVideoDate.Text;
                        }
                        else if (rbVideoSelectionOnDate.Checked && txtVideoDate.Text.Length > 0) {
                            NewInfo.PlaylistSelection = PlaylistSelectionType.DateDuring;
                            NewInfo.PlaylistSelectionArg = txtVideoDate.Text;
                        }
                        else if (rbVideoSelectionAfterDate.Checked && txtVideoDate.Text.Length > 0) {
                            NewInfo.PlaylistSelection = PlaylistSelectionType.DateAfter;
                            NewInfo.PlaylistSelectionArg = txtVideoDate.Text;
                        }
                    }

                    if (rbVideo.Checked) {
                        NewInfo.VideoQuality = (VideoQualityType)cbQuality.SelectedIndex;
                        NewInfo.VideoFormat = (VideoFormatType)cbFormat.SelectedIndex;
                        NewInfo.Type = DownloadType.Video;
                        NewInfo.SkipAudioForVideos = !chkDownloadSound.Checked;
                        NewInfo.DownloadURL = txtUrl.Text;

                        Config.Settings.Saved.downloadType = (int)DownloadType.Video;
                        Config.Settings.Saved.videoQuality = cbQuality.SelectedIndex;
                        Config.Settings.Saved.VideoFormat = cbFormat.SelectedIndex;
                        Config.Settings.Downloads.VideoDownloadSound = chkDownloadSound.Checked;
                    }
                    else if (rbAudio.Checked) {
                        NewInfo.Type = DownloadType.Audio;
                        if (chkDownloadSound.Checked) {
                            NewInfo.AudioVBRQuality = (AudioVBRQualityType)cbQuality.SelectedIndex;
                        }
                        else {
                            NewInfo.AudioCBRQuality = (AudioCBRQualityType)cbQuality.SelectedIndex;
                        }
                        NewInfo.UseVBR = chkDownloadSound.Checked;
                        NewInfo.AudioFormat = (AudioFormatType)cbFormat.SelectedIndex;
                        NewInfo.DownloadURL = txtUrl.Text;


                        Config.Settings.Saved.downloadType = (int)DownloadType.Audio;
                        Config.Settings.Saved.audioQuality = cbQuality.SelectedIndex;
                        Config.Settings.Saved.AudioFormat = cbFormat.SelectedIndex;
                        Config.Settings.Downloads.AudioDownloadAsVBR = chkDownloadSound.Checked;
                    }
                    else {
                        throw new Exception("Video, Audio, or Custom was not selected in the form, please select an actual download option to proceed.");
                    }
                }
                else {
                    NewInfo.Type = DownloadType.Custom;
                    NewInfo.DownloadArguments = cbCustomArguments.Text;
                    NewInfo.DownloadURL = txtUrl.Text;
                    Config.Settings.Saved.downloadType = (int)DownloadType.Custom;
                    if (!cbCustomArguments.Items.Contains(cbCustomArguments.Text) && !string.IsNullOrWhiteSpace(cbCustomArguments.Text)) {
                        cbCustomArguments.Items.Add(cbCustomArguments.Text);
                    }
                }

                if (chkDebugDontDownload.Checked) {
                    NewInfo.Dispose();
                }
                else {
                    frmDownloader Downloader = new(NewInfo);
                    Downloader.Show();
                }

                if (Config.Settings.General.ClearURLOnDownload) {
                    txtUrl.Clear();
                }
                if (Config.Settings.General.ClearClipboardOnDownload) {
                    Clipboard.Clear();
                }
            }
            catch (Exception ex) {
                ErrorLog.Report(ex);
            }
        }
        #endregion

        #region converter
        private void btnConvertInput_Click(object sender, EventArgs e) {
            using OpenFileDialog ofd = new();
            ofd.Title = Program.lang.dlgConvertSelectFileToConvert;
            ofd.AutoUpgradeEnabled = true;
            string AllFormats = Formats.JoinFormats(new[] {
                    Formats.AllFiles,
                    Formats.VideoFormats,
                    Formats.AudioFormats,
                    !string.IsNullOrWhiteSpace(Formats.CustomFormats) ? Formats.CustomFormats : ""
                });

            ofd.Filter = AllFormats;

            if (ofd.ShowDialog() == DialogResult.OK) {
                if (!string.IsNullOrEmpty(txtConvertOutput.Text))
                    btnConvert.Enabled = true;

                txtConvertInput.Text = ofd.FileName;
                btnConvertOutput.Enabled = true;

                string fileWithoutExt = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
                using SaveFileDialog sfd = new();
                sfd.Title = Program.lang.dlgSaveOutputFileAs;
                sfd.FileName = fileWithoutExt;
                if (rbConvertVideo.Checked) {
                    sfd.Filter = Formats.JoinFormats(new[] {
                                Formats.VideoFormats,
                                !string.IsNullOrWhiteSpace(Formats.CustomFormats) ? Formats.CustomFormats : "",
                                Formats.AllFiles
                            });
                    sfd.FilterIndex = Config.Settings.Saved.convertSaveVideoIndex;
                }
                else if (rbConvertAudio.Checked) {
                    sfd.Filter = Formats.JoinFormats(new[] {
                                Formats.AudioFormats,
                                !string.IsNullOrWhiteSpace(Formats.CustomFormats) ? Formats.CustomFormats : "",
                                Formats.AllFiles
                            });
                    sfd.FilterIndex = Config.Settings.Saved.convertSaveAudioIndex;
                }
                else {
                    sfd.Filter = AllFormats;
                    sfd.FilterIndex = Config.Settings.Saved.convertSaveUnknownIndex;
                }
                if (sfd.ShowDialog() == DialogResult.OK) {
                    txtConvertOutput.Text = sfd.FileName;
                    btnConvert.Enabled = true;
                    if (rbConvertVideo.Checked) {
                        Config.Settings.Saved.convertSaveVideoIndex = sfd.FilterIndex;
                    }
                    else if (rbConvertAudio.Checked) {
                        Config.Settings.Saved.convertSaveAudioIndex = sfd.FilterIndex;
                    }
                    else {
                        Config.Settings.Saved.convertSaveUnknownIndex = sfd.FilterIndex;
                    }
                }
            }
        }

        private void btnConvertOutput_Click(object sender, EventArgs e) {
            using SaveFileDialog sfd = new();
            sfd.Title = Program.lang.dlgSaveOutputFileAs;
            sfd.FileName = System.IO.Path.GetFileNameWithoutExtension(txtConvertInput.Text);
            if (rbConvertVideo.Checked) {
                sfd.Filter = Formats.JoinFormats(new[] {
                        Formats.VideoFormats,
                        !string.IsNullOrWhiteSpace(Formats.CustomFormats) ? Formats.CustomFormats : ""
                    });
                sfd.FilterIndex = Config.Settings.Saved.convertSaveVideoIndex;
            }
            else if (rbConvertAudio.Checked) {
                sfd.Filter = Formats.JoinFormats(new[] {
                        Formats.AudioFormats,
                        !string.IsNullOrWhiteSpace(Formats.CustomFormats) ? Formats.CustomFormats : ""
                    });
                sfd.FilterIndex = Config.Settings.Saved.convertSaveAudioIndex;
            }
            else {
                sfd.Filter = Formats.JoinFormats(new[] {
                        Formats.AllFiles,
                        Formats.VideoFormats,
                        Formats.AudioFormats,
                        !string.IsNullOrWhiteSpace(Formats.CustomFormats) ? Formats.CustomFormats : ""
                    });
                sfd.FilterIndex = Config.Settings.Saved.convertSaveUnknownIndex;
            }

            if (sfd.ShowDialog() == DialogResult.OK) {
                txtConvertOutput.Text = sfd.FileName;
                btnConvert.Enabled = true;
                if (rbConvertVideo.Checked) {
                    Config.Settings.Saved.convertSaveVideoIndex = sfd.FilterIndex;
                }
                else if (rbConvertAudio.Checked) {
                    Config.Settings.Saved.convertSaveAudioIndex = sfd.FilterIndex;
                }
                else {
                    Config.Settings.Saved.convertSaveUnknownIndex = sfd.FilterIndex;
                }
            }
        }

        private void btnConvert_Click(object sender, EventArgs e) {
            btnConvert.Enabled = false;
            btnConvertInput.Enabled = false;
            btnConvertOutput.Enabled = false;

            ConvertInfo NewConversion = new();

            if (rbConvertVideo.Checked)
                NewConversion.Type = ConversionType.Video;
            else if (rbConvertAudio.Checked)
                NewConversion.Type = ConversionType.Audio;
            else if (rbConvertCustom.Checked)
                NewConversion.Type = ConversionType.Custom;
            else if (rbConvertAuto.Checked)
                NewConversion.Type = Convert.GetFiletype(txtConvertOutput.Text);
            else
                NewConversion.Type = ConversionType.FfmpegDefault;

            NewConversion.InputFile = txtConvertInput.Text;
            NewConversion.OutputFile = txtConvertOutput.Text;

            btnConvert.Enabled = true;
            btnConvertInput.Enabled = true;
            btnConvertOutput.Enabled = true;

            frmConverter Converter = new(NewConversion);
            Converter.Show();
        }

        private void convertFromTray(ConversionType conversionType = ConversionType.Unspecified) {
            // -1 = automatic
            // 0 = video
            // 1 = audio
            // 2 = custom
            // 6 = ffmpeg auto

            using OpenFileDialog ofd = new();
            using SaveFileDialog sfd = new();
            ofd.Title = "Browse for file to convert";
            if (ofd.ShowDialog() == DialogResult.OK) {
                string fileWithoutExt = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
                btnConvertOutput.Enabled = true;

                sfd.Title = "Save ouput to...";
                sfd.FileName = fileWithoutExt;
                sfd.Filter = conversionType switch {
                    ConversionType.Video => Formats.VideoFormats,
                    ConversionType.Audio => Formats.AudioFormats,
                    _ => "All File Formats (*.*)|*.*"
                };

                if (sfd.ShowDialog() == DialogResult.OK) {
                    frmConverter Converter = new(new() {
                        InputFile = ofd.FileName,
                        OutputFile = sfd.FileName,
                        Type = conversionType switch {
                            ConversionType.Video => ConversionType.Video,
                            ConversionType.Audio => ConversionType.Audio,
                            ConversionType.Custom => ConversionType.Custom,
                            _ => ConversionType.FfmpegDefault,
                        }
                    });
                    Converter.Show();
                    //Convert.convertFile(inputFile, outputFile, conversionType);
                }
            }

        }
        #endregion

        #region merger
        private void btnBrwsMergeInput1_Click(object sender, EventArgs e) {
            using OpenFileDialog ofd = new() {
                Filter = Formats.JoinFormats(new[] {
                    Formats.AllFiles,
                    Formats.VideoFormats,
                    Formats.AudioFormats,
                    !string.IsNullOrWhiteSpace(Formats.CustomFormats) ? Formats.CustomFormats : ""
                }),
                Title = Program.lang.dlgMergeSelectFileToMerge
            };

            if (ofd.ShowDialog() == DialogResult.OK) {
                txtMergeInput1.Text = ofd.FileName;
                btnBrwsMergeInput2.Enabled = true;
                txtMergeOutput.Text = System.IO.Path.GetDirectoryName(ofd.FileName) + "\\" + System.IO.Path.GetFileNameWithoutExtension(ofd.FileName) + "-merged" + System.IO.Path.GetExtension(ofd.FileName);
            }
        }
        private void btnBrwsMergeInput2_Click(object sender, EventArgs e) {
            using OpenFileDialog ofd = new() {
                Filter = Formats.JoinFormats(new[] {
                    Formats.AllFiles,
                    Formats.VideoFormats,
                    Formats.AudioFormats,
                    !string.IsNullOrWhiteSpace(Formats.CustomFormats) ? Formats.CustomFormats : ""
                }),
                Title = Program.lang.dlgMergeSelectFileToMerge
            };

            if (ofd.ShowDialog() == DialogResult.OK) {
                txtMergeInput2.Text = ofd.FileName;
                btnBrwsMergeOutput.Enabled = true;
                if (!string.IsNullOrEmpty(txtMergeOutput.Text)) {
                    btnMerge.Enabled = true;
                }
            }
        }
        private void btnBrwsMergeOutput_Click(object sender, EventArgs e) {
            using SaveFileDialog sfd = new() {
                Filter = Formats.JoinFormats(new[] {
                    Formats.AllFiles,
                    Formats.VideoFormats,
                    Formats.AudioFormats,
                    !string.IsNullOrWhiteSpace(Formats.CustomFormats) ? Formats.CustomFormats : ""
                }),
                Title = Program.lang.dlgSaveOutputFileAs
            };

            if (sfd.ShowDialog() == DialogResult.OK) {
                txtMergeOutput.Text = sfd.FileName;
                btnMerge.Enabled = true;
            }
        }

        private void btnMerge_Click(object sender, EventArgs e) {
            Convert.mergeFiles(txtMergeInput1.Text, txtMergeInput2.Text, txtMergeOutput.Text, chkMergeAudioTracks.Checked, chkMergeDeleteInputFiles.Checked);
        }
        #endregion

        #region debug
        private void btnDebugForceUpdateCheck_Click(object sender, EventArgs e) {
            UpdateChecker.CheckForUpdate(true);
        }
        private void btnDebugForceAvailableUpdate_Click(object sender, EventArgs e) {
            UpdateChecker.UpdateDebug.UpdateAvailable();
        }
        private void btnDebugDownloadArgs_Click(object sender, EventArgs e) {
            if (!Clipboard.ContainsText()) { return; }
            frmDownloader Downloader = new(new() {
                VideoQuality = (VideoQualityType)Config.Settings.Saved.videoQuality,
                Type = DownloadType.Video,
                DownloadURL = Clipboard.GetText(),
                BatchDownload = true
            }) {
                Debugging = true
            };
            Downloader.Show();
        }
        private void btnDebugRotateQualityFormat_Click(object sender, EventArgs e) {
            Point s = lbQuality.Location;
            Point t = lbFormat.Location;
            Point u = cbQuality.Location;
            Point v = cbFormat.Location;

            lbFormat.Location = s;
            lbQuality.Location = t;
            cbFormat.Location = u;
            cbQuality.Location = v;
        }
        private void btnDebugThrowException_Click(object sender, EventArgs e) {
            try {
                throw new Exception("An exception has been thrown.");
            }
            catch (Exception ex) {
                ErrorLog.Report(ex, false);
            }
        }
        private void btnYtdlVersion_Click(object sender, EventArgs e) {
            MessageBox.Show(Program.verif.YoutubeDlVersion);
        }
        private void btnDebugCheckVerification_Click(object sender, EventArgs e) {
            MessageBox.Show(
                $"Youtube-DL Path: {{{Program.verif.YoutubeDlPath}}}\r\nYoutube-DL Version: {{{Program.verif.YoutubeDlVersion}}}\r\n\r\n" +
                $"FFmpeg Path: {{{Program.verif.FFmpegPath}}}\r\n\r\n" +
                $"AtomicParlsey Path: {{{Program.verif.AtomicParsleyPath}}}"
            );
        }
        #endregion

    }
}
