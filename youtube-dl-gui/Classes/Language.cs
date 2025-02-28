﻿using System;
using System.IO;

namespace youtube_dl_gui {

    /// <summary>
    /// Controls the language strings of the program. Most, if not all, strings get their text from here.
    /// </summary>
    public class Language {

        #region GetSetRadio (AKA Properties)

        #region Language identifier
        public bool UsingInternalEnglish { get; private set; }
        public string CurrentLanguageLong { get; private set; }
        public string CurrentLanguageShort { get; private set; }
        public string CurrentLanguageHint { get; private set; }
        public string CurrentLanguageVersion { get; private set; }
        #endregion

        #region Generics
        public string GenericInputBest { get; private set; }
        public string GenericInputWorst { get; private set; }
        public string GenericCancel { get; private set; }
        public string GenericSkip { get; private set; }
        public string GenericSound { get; private set; }
        public string GenericVideo { get; private set; }
        public string GenericAudio { get; private set; }
        public string GenericCustom { get; private set; }
        public string GenericRetry { get; private set; }
        public string GenericStart { get; private set; }
        public string GenericStop { get; private set; }
        public string GenericExit { get; private set; }
        public string GenericOk { get; private set; }
        public string GenericSave { get; private set; }
        #endregion

        #region Dialogs
        public string dlgFirstTimeInitialMessage { get; private set; }
        public string dlgFirstTimeDownloadFolder { get; private set; }

        public string dlgMainArgsTxtDoesntExist { get; private set; }
        public string dlgMainArgsTxtIsEmpty { get; private set; }
        public string dlgMainArgsNoneSaved { get; private set; }
        public string dlgConvertSelectFileToConvert { get; private set; }
        public string dlgMergeSelectFileToMerge { get; private set; }
        public string dlgSaveOutputFileAs { get; private set; }
        public string dlgLanguageHashNoMatch { get; private set; }

        public string dlgFindDownloadFolder { get; private set; }
        public string dlgUpdateFailedToCheck { get; private set; }
        public string dlgUpdateNoUpdateAvailable { get; private set; }
        public string dlgUpdateNoBetaUpdateAvailable { get; private set; }
        public string dlgUpdateNoValidYoutubeDl { get; private set; }
        public string dlgUpdatedYoutubeDl { get; private set; }
        public string dlgUpdaterHashNoMatch { get; private set; }
        public string dlgUpateYoutubeDlNoUpdateRequired { get; private set; }
        #endregion

        #region frmAbout
        public string frmAbout { get; private set; }
        public string lbAboutBody { get; private set; }
        public string llbCheckForUpdates { get; private set; }
        #endregion

        #region frmAuthentication
        public string frmAuthentication { get; private set; }
        public string lbAuthNotice { get; private set; }
        public string lbAuthUsername { get; private set; }
        public string lbAuthPassword { get; private set; }
        public string lbAuth2Factor { get; private set; }
        public string lbAuthVideoPassword { get; private set; }
        public string chkAuthUseNetrc { get; private set; }
        public string lbAuthNoSave { get; private set; }
        public string btnAuthBeginDownload { get; private set; }
        #endregion

        #region frmBatchDownloader
        public string frmBatchDownload { get; private set; }
        public string lbBatchDownloadLink { get; private set; }
        public string lbBatchDownloadType { get; private set; }
        public string lbBatchDownloadVideoSpecificArgument { get; private set; }
        public string btnBatchDownloadAdd { get; private set; }
        public string btnBatchDownloadRemoveSelected { get; private set; }
        public string sbBatchDownloadLoadArgs { get; private set; }
        public string mBatchDownloaderLoadArgsFromSettings { get; private set; }
        public string mBatchDownloaderLoadArgsFromArgsTxt { get; private set; }
        public string mBatchDownloaderLoadArgsFromFile { get; private set; }
        public string sbBatchDownloaderIdle { get; private set; }
        public string sbBatchDownloaderDownloading { get; private set; }
        public string sbBatchDownloaderFinished { get; private set; }
        public string sbBatchDownloaderAborted { get; private set; }
        #endregion

        #region frmConverter
        public string frmConverter { get; private set; }
        public string frmConverterComplete { get; private set; }
        public string frmConverterError { get; private set; }
        public string chkConverterCloseAfterConversion { get; private set; }
        public string btnConverterAbortBatchConversions { get; private set; }
        #endregion

        #region frmDownloader
        public string frmDownloader { get; private set; }
        public string frmDownloaderComplete { get; private set; }
        public string frmDownloaderError { get; private set; }
        public string chkDownloaderCloseAfterDownload { get; private set; }
        public string btnDownloaderAbortBatch { get; private set; }
        #endregion

        #region frmDownloadLanguage
        public string frmDownloadLanguage { get; private set; }
        #endregion

        #region frmException
        public string frmException { get; private set; }
        public string lbExceptionHeader { get; private set; }
        public string lbExceptionDescription { get; private set; }
        public string rtbExceptionDetails { get; private set; }
        public string btnExceptionGithub { get; private set; }
        #endregion

        #region frmLanguage
        public string frmLanguage { get; private set; }
        public string btnLanguageRefresh { get; private set; }
        public string btnLanguageDownload { get; private set; }
        #endregion

        #region frmMain
        public string mSettings { get; private set; }
        public string mTools { get; private set; }
        public string mBatchDownload { get; private set; }
        public string mDownloadSubtitles { get; private set; }
        public string mMiscTools { get; private set; }
        public string mHelp { get; private set; }
        public string mLanguage { get; private set; }
        public string mSupportedSites { get; private set; }
        public string mAbout { get; private set; }

        public string tabDownload { get; private set; }
        public string tabConvert { get; private set; }
        public string tabMerge { get; private set; }

        public string lbURL { get; private set; }
        public string txtUrlHint { get; private set; }
        public string gbDownloadType { get; private set; }
        public string lbQuality { get; private set; }
        public string lbFormat { get; private set; }
        public string chkDownloadSound { get; private set; }
        public string chkUseSelection { get; private set; }
        public string rbVideoSelectionPlaylistIndex { get; private set; }
        public string rbVideoSelectionPlaylistItems { get; private set; }
        public string rbVideoSelectionBeforeDate { get; private set; }
        public string rbVideoSelectionOnDate { get; private set; }
        public string rbVideoSelectionAfterDate { get; private set; }
        public string txtPlaylistStartHint { get; private set; }
        public string txtPlaylistEndHint { get; private set; }
        public string txtPlaylistItemsHint { get; private set; }
        public string txtVideoDateHint { get; private set; }
        public string lbCustomArguments { get; private set; }
        public string txtArgsHint { get; private set; }
        public string sbDownload { get; private set; }
        public string mDownloadWithAuthentication { get; private set; }
        public string mBatchDownloadFromFile { get; private set; }
        public string msgBatchDownloadFromFile { get; private set; }
        public string lbDownloadStatusStarted { get; private set; }
        public string lbDownloadStatusError { get; private set; }

        public string lbConvertInput { get; private set; }
        public string lbConvertOutput { get; private set; }
        public string rbConvertAuto { get; private set; }
        public string rbConvertAutoFFmpeg { get; private set; }
        public string btnConvert { get; private set; }
        public string lbConvertStarted { get; private set; }
        public string lbConvertFailed { get; private set; }

        public string lbMergeInput1 { get; private set; }
        public string lbMergeInput2 { get; private set; }
        public string lbMergeOutput { get; private set; }
        public string chkMergeAudioTracks { get; private set; }
        public string chkMergeDeleteInputFiles { get; private set; }
        public string btnMerge { get; private set; }

        public string cmTrayShowForm { get; private set; }
        public string cmTrayDownloader { get; private set; }
        public string cmTrayDownloadClipboard { get; private set; }
        public string cmTrayDownloadBestVideo { get; private set; }
        public string cmTrayDownloadBestAudio { get; private set; }
        public string cmTrayDownloadCustom { get; private set; }
        public string cmTrayDownloadCustomTxtBox { get; private set; }
        public string cmTrayDownloadCustomTxt { get; private set; }
        public string cmTrayDownloadCustomSettings { get; private set; }
        public string cmTrayConverter { get; private set; }
        public string cmTrayConvertTo { get; private set; }
        public string cmTrayConvertVideo { get; private set; }
        public string cmTrayConvertAudio { get; private set; }
        public string cmTrayConvertCustom { get; private set; }
        public string cmTrayConvertAutomatic { get; private set; }
        public string cmTrayConvertAutoFFmpeg { get; private set; }
        public string cmTrayExit { get; private set; }
        #endregion

        #region frmSettings

        #region frmSettings form
        public string frmSettings { get; private set; }
        public string btnSettingsRedownloadYoutubeDl { get; private set; }

        public string tabSettingsGeneral { get; private set; }
        public string tabSettingsDownloads { get; private set; }
        public string tabSettingsConverter { get; private set; }
        public string tabSettingsExtensions { get; private set; }
        public string tabSettingsErrors { get; private set; }
        public string tabSettingsPortable { get; private set; }

        public string lbSettingsGeneralYoutubeDlPath { get; private set; }
        public string chkSettingsGeneralUseStaticYoutubeDl { get; private set; }
        public string ofdTitleYoutubeDl { get; private set; }
        public string ofdFilterYoutubeDl { get; private set; }
        public string lbSettingsGeneralFFmpegDirectory { get; private set; }
        public string chkSettingsGeneralUseStaticFFmpeg { get; private set; }
        public string ofdTitleFFmpeg { get; private set; }
        public string ofdFilterFFmpeg { get; private set; }
        public string chkSettingsGeneralCheckForUpdatesOnLaunch { get; private set; }
        public string chkSettingsGeneralCheckForBetaUpdates { get; private set; }
        public string chkSettingsGeneralDeleteUpdaterAfterUpdating { get; private set; }
        public string chkDeleteOldVersionAfterUpdating { get; private set; }
        public string chkSettingsGeneralHoverOverUrlToPasteClipboard { get; private set; }
        public string chkSettingsGeneralClearUrlOnDownload { get; private set; }
        public string chkSettingsGeneralClearClipboardOnDownload { get; private set; }
        public string gbSettingsGeneralCustomArguments { get; private set; }
        public string rbSettingsGeneralCustomArgumentsDontSave { get; private set; }
        public string rbSettingsGeneralCustomArgumentsSaveAsArgsText { get; private set; }
        public string rbSettingsGeneralCustomArgumentsSaveInSettings { get; private set; }

        public string lbSettingsDownloadsDownloadPath { get; private set; }
        public string lbSettingsDownloadsFileNameSchema { get; private set; }
        public string tabDownloadsGeneral { get; private set; }
        public string tabDownloadsSorting { get; private set; }
        public string tabDownloadsFixes { get; private set; }
        public string tabDownloadsConnection { get; private set; }
        public string tabDownloadsUpdating { get; private set; }
        public string chkSettingsDownloadsSaveFormatQuality { get; private set; }
        public string chkSettingsDownloadsDownloadSubtitles { get; private set; }
        public string chkSettingsDownloadsEmbedSubtitles { get; private set; }
        public string chkSettingsDownloadsSaveVideoInfo { get; private set; }
        public string chkSettingsDownloadsWriteMetadataToFile { get; private set; }
        public string chkSettingsDownloadsSaveDescription { get; private set; }
        public string chkSettingsDownloadsKeepOriginalFiles { get; private set; }
        public string chkSettingsDownloadsSaveAnnotations { get; private set; }
        public string chkSettingsDownloadsSaveThumbnails { get; private set; }
        public string chkSettingsDownloadsEmbedThumbnails { get; private set; }
        public string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing { get; private set; }
        public string chkSettingsDownloadsSeparateDownloadsToDifferentFolders { get; private set; }
        public string chkSettingsDownloadsSeparateIntoWebsiteUrl { get; private set; }
        public string chkSettingsDownloadsFixVReddIt { get; private set; }
        public string chkSettingsDownloadsPreferFFmpeg { get; private set; }
        public string chkSettingsDownloadsLimitDownload { get; private set; }
        public string lbSettingsDownloadsRetryAttempts { get; private set; }
        public string chkSettingsDownloadsForceIpv4 { get; private set; }
        public string chkSettingsDownloadsForceIpv6 { get; private set; }
        public string chkSettingsDownloadsUseProxy { get; private set; }
        public string chkSettingsDownloadsUseYoutubeDlsUpdater { get; private set; }
        public string lbSettingsDownloadsUpdatingYtdlType { get; private set; }
        public string cbSettingsDownloadsUpdatingYtdlTypeHint { get; private set; }
        public string llbSettingsDownloadsYtdlTypeViewRepo { get; private set; }
        public string llbSettingsDownloadsYtdlTypeViewRepoHint { get; private set; }
        public string chkSettingsDownloadsSeparateBatchDownloads { get; private set; }
        public string chkSettingsDownloadsAddDateToBatchDownloadFolders { get; private set; }

        public string chkSettingsConverterClearOutputAfterConverting { get; private set; }
        public string chkSettingsConverterDetectOutputFileType { get; private set; }
        public string chkSettingsConverterClearInputAfterConverting { get; private set; }
        public string chkSettingsConverterHideFFmpegCompileInfo { get; private set; }
        public string tcSettingsConverterVideo { get; private set; }
        public string tcSettingsConverterAudio { get; private set; }
        public string tcSettingsConverterCustom { get; private set; }
        public string lbSettingsConverterVideoBitrate { get; private set; }
        public string lbSettingsConverterVideoPreset { get; private set; }
        public string lbSettingsConverterVideoProfile { get; private set; }
        public string lbSettingsConverterVideoCRF { get; private set; }
        public string chkSettingsConverterVideoFastStart { get; private set; }
        public string lbSettingsConverterAudioBitrate { get; private set; }
        public string lbSettingsConverterCustomHeader { get; private set; }

        public string lbSettingsExtensionsHeader { get; private set; }
        public string lbSettingsExtensionsExtensionFullName { get; private set; }
        public string txtSettingsExtensionsExtensionFullName { get; private set; }
        public string lbSettingsExtensionsExtensionShort { get; private set; }
        public string txtSettingsExtensionsExtensionShort { get; private set; }
        public string btnSettingsExtensionsAdd { get; private set; }
        public string lbSettingsExtensionsFileName { get; private set; }
        public string btnSettingsExtensionsRemoveSelected { get; private set; }

        public string chkSettingsErrorsShowDetailedErrors { get; private set; }
        public string chkSettingsErrorsSaveErrorsAsErrorLog { get; private set; }
        public string chkSettingsErrorsSuppressErrors { get; private set; }

        public string lbSettingsPortableInformation { get; private set; }
        public string chkSettingsPortableToggleIni { get; private set; }
        #endregion

        #region tipSettings
        public string btnSettingsRedownloadYoutubeDlHint { get; private set; }
        public string btnSettingsCancelHint { get; private set; }
        public string btnSettingsSaveHint { get; private set; }

        public string lbSettingsGeneralYoutubeDlPathHint { get; private set; }
        public string chkSettingsGeneralUseStaticYoutubeDlHint { get; private set; }
        public string txtSettingsGeneralYoutubeDlPathHint { get; private set; }
        public string btnSettingsGeneralBrowseYoutubeDlHint { get; private set; }
        public string lbSettingsGeneralFFmpegDirectoryHint { get; private set; }
        public string chkSettingsGeneralUseStaticFFmpegHint { get; private set; }
        public string txtSettingsGeneralFFmpegPathHint { get; private set; }
        public string btnSettingsGeneralBrowseFFmpegHint { get; private set; }
        public string chkSettingsGeneralCheckForUpdatesOnLaunchHint { get; private set; }
        public string chkSettingsGeneralCheckForBetaUpdatesHint { get; private set; }
        public string chkSettingsGeneralDeleteUpdaterAfterUpdatingHint { get; private set; }
        public string chkDeleteOldVersionAfterUpdatingHint { get; private set; }
        public string chkSettingsGeneralHoverOverUrlToPasteClipboardHint { get; private set; }
        public string chkSettingsGeneralClearUrlOnDownloadHint { get; private set; }
        public string chkSettingsGeneralClearClipboardOnDownloadHint { get; private set; }
        public string gbSettingsGeneralCustomArgumentsHint { get; private set; }
        public string rbSettingsGeneralCustomArgumentsDontSaveHint { get; private set; }
        public string rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint { get; private set; }
        public string rbSettingsGeneralCustomArgumentsSaveInSettingsHint { get; private set; }

        public string lbSettingsDownloadsDownloadPathHint { get; private set; }
        public string chkSettingsDownloadsDownloadPathUseRelativePathHint { get; private set; }
        public string txtSettingsDownloadsSavePathHint { get; private set; }
        public string btnSettingsDownloadsBrowseSavePathHint { get; private set; }
        public string llSettingsDownloadsSchemaHelpHint { get; private set; }
        public string lbSettingsDownloadsFileNameSchemaHint { get; private set; }
        public string txtSettingsDownloadsFileNameSchemaHint { get; private set; }
        public string chkSettingsDownloadsSaveFormatQualityHint { get; private set; }
        public string chkSettingsDownloadsDownloadSubtitlesHint { get; private set; }
        public string chkSettingsDownloadsEmbedSubtitlesHint { get; private set; }
        public string chkSettingsDownloadsSaveVideoInfoHint { get; private set; }
        public string chkSettingsDownloadsWriteMetadataToFileHint { get; private set; }
        public string chkSettingsDownloadsSaveDescriptionHint { get; private set; }
        public string chkSettingsDownloadsKeepOriginalFilesHint { get; private set; }
        public string chkSettingsDownloadsSaveAnnotationsHint { get; private set; }
        public string chkSettingsDownloadsSaveThumbnailsHint { get; private set; }
        public string chkSettingsDownloadsEmbedThumbnailsHint { get; private set; }
        public string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint { get; private set; }
        public string chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint { get; private set; }
        public string chkSettingsDownloadsSeparateIntoWebsiteUrlHint { get; private set; }
        public string chkSettingsDownloadsFixVReddItHint { get; private set; }
        public string chkSettingsDownloadsPreferFFmpegHint { get; private set; }
        public string chkSettingsDownloadsLimitDownloadHint { get; private set; }
        public string numSettingsDownloadsLimitDownloadHint { get; private set; }
        public string cbSettingsDownloadsLimitDownloadHint { get; private set; }
        public string lbSettingsDownloadsRetryAttemptsHint { get; private set; }
        public string numSettingsDownloadsRetryAttemptsHint { get; private set; }
        public string chkSettingsDownloadsForceIpv4Hint { get; private set; }
        public string chkSettingsDownloadsForceIpv6Hint { get; private set; }
        public string chkSettingsDownloadsUseProxyHint { get; private set; }
        public string cbSettingsDownloadsProxyTypeHint { get; private set; }
        public string txtSettingsDownloadsProxyIpHint { get; private set; }
        public string txtSettingsDownloadsProxyPortHint { get; private set; }
        public string chksettingsDownloadsUseYoutubeDlsUpdaterHint { get; private set; }
        public string chkSettingsDownloadsSeparateBatchDownloadsHint { get; private set; }
        public string chkSettingsDownloadsAddDateToBatchDownloadFoldersHint { get; private set; }

        public string chkSettingsConverterClearOutputAfterConvertingHint { get; private set; }
        public string chkSettingsConverterDetectOutputFileTypeHint { get; private set; }
        public string chkSettingsConverterClearInputAfterConvertingHint { get; private set; }
        public string chkSettingsConverterHideFFmpegCompileInfoHint { get; private set; }
        public string lbSettingsConverterVideoBitrateHint { get; private set; }
        public string lbSettingsConverterVideoPresetHint { get; private set; }
        public string lbSettingsConverterVideoProfileHint { get; private set; }
        public string lbSettingsConverterVideoCRFHint { get; private set; }
        public string chkSettingsConverterVideoFastStartHint { get; private set; }
        public string lbSettingsConverterAudioBitrateHint { get; private set; }
        public string txtSettingsConverterCustomArgumentsHint { get; private set; }

        public string chkSettingsErrorsShowDetailedErrorsHint { get; private set; }
        public string chkSettingsErrorsSaveErrorsAsErrorLogHint { get; private set; }
        public string chkSettingsErrorsSuppressErrorsHint { get; private set; }
        #endregion

        #endregion

        #region frmSubtitles
        public string frmSubtitles { get; private set; }
        public string lbSubtitlesHeader { get; private set; }
        public string lbSubtitlesUrl { get; private set; }
        public string lbSubtitlesLanguages { get; private set; }
        public string btnSubtitlesAddLanguage { get; private set; }
        public string btnSubtitlesClearLanguages { get; private set; }
        public string btnSubtitlesDownload { get; private set; }
        #endregion

        #region frmTools
        public string frmTools { get; private set; }
        public string btnMiscToolsRemoveAudio { get; private set; }
        public string btnMiscToolsExtractAudio { get; private set; }
        public string btnMiscToolsVideoToGif { get; private set; }
        #endregion

        #region frmUpdateAvailable
        public string frmUpdateAvailable { get; private set; }
        public string lbUpdateAvailableHeader { get; private set; }
        public string lbUpdateAvailableUpdateVersion { get; private set; }
        public string lbUpdateAvailableCurrentVersion { get; private set; }
        public string lbUpdateAvailableChangelog { get; private set; }
        public string btnUpdateAvailableSkipVersion { get; private set; }
        public string btnUpdateAvailableUpdate { get; private set; }
        #endregion

        //////////////// Language class \\\\\\\\\\\\\\\\
        #region Instance manager
        public string LoadedFile { get; private set; }
        #endregion

        #endregion

        #region Internal English
        /// <summary>
        /// Contains all English strings internally.
        /// </summary>
        public static class InternalEnglish {
            // Language identifier
            public const string CurrentLanguageLong = "English (Internal)";
            public const string CurrentLanguageShort = "en-i";
            public const string CurrentLanguageHint = "Click here to change";
            public const string CurrentLanguageVersion = "1";

            // Generics
            public const string GenericInputBest = "best";
            public const string GenericInputWorst = "worst";
            public const string GenericCancel = "Cancel";
            public const string GenericSkip = "Skip";
            public const string GenericSound = "Sound";
            public const string GenericVideo = "Video";
            public const string GenericAudio = "Audio";
            public const string GenericCustom = "Custom";
            public const string GenericRetry = "Retry";
            public const string GenericStart = "Start";
            public const string GenericStop = "Stop";
            public const string GenericExit = "Exit";
            public const string GenericOk = "OK";
            public const string GenericSave = "Save";

            #region Dialogs
            public const string dlgFirstTimeInitialMessage = "youtube-dl-gui is a visual extension to youtube-dl and is not affiliated with the developers of youtube-dl in any way.\n\nThis program (and I) does not condone piracy or illegally downloading of any video you do not own the rights to or is not in public domain.\n\nAny help regarding any problems when downloading anything illegal (in my jurisdiction) will be ignored. This message will not appear again.\n\nHave you read the above?";
            public const string dlgFirstTimeDownloadFolder = "Downloads are saved to your downloads folder by default, would you like to specify a different location now?\n(You can change this in the settings at any time)";
            public const string dlgFindDownloadFolder = "Select a directory to save downloads to...";
            public const string dlgMainArgsTxtDoesntExist = "args.txt does not exist, create it and put in arguments to use this command";
            public const string dlgMainArgsTxtIsEmpty = "args.txt is empty, save arguments to the file to use this command";
            public const string dlgMainArgsNoneSaved = "No arguments are saved in the application settings, save arguments to the settings to use this command";
            public const string dlgConvertSelectFileToConvert = "Select a file to convert...";
            public const string dlgMergeSelectFileToMerge = "Select a file to merge...";
            public const string dlgSaveOutputFileAs = "Save the output file as...";
            public const string dlgLanguageHashNoMatch = "The langauge file hash doesn't match. This isn't very important since it's not important to the runtime of the program, but your language may be wrong.";
            public const string dlgUpdateFailedToCheck = "The update check has failed. Would you like to manually check?";
            public const string dlgUpdateNoUpdateAvailable = "No updates available.\r\n\r\nCurrent version: {0}\r\nLatest version: {1}";
            public const string dlgUpdateNoBetaUpdateAvailable = "No beta updates available.\r\n\r\nCurrent beta version: {0}\r\nNewest beta version: {1}";
            public const string dlgUpdateNoValidYoutubeDl = "Could not find a valid youtube-dl to download or update.";
            public const string dlgUpdatedYoutubeDl = "Youtube-dl has been updated.";
            public const string dlgUpateYoutubeDlNoUpdateRequired = "Youtube-dl does not require an update at this moment.\r\n\r\nCurrent version: {0}\r\nLatest release: {1}";
            public const string dlgUpdaterHashNoMatch = "The hash of the updater does not match the internally known hash. It might still work but yknow. Update anyways?";
            #endregion

            #region frmAbout
            public const string frmAbout = "About";
            public const string lbAboutBody = "youtube-dl by {0}\nyoutube-dl-gui by {1}\ndebug date {2}";
            public const string llbCheckForUpdates = "Check for updates";
            #endregion

            #region frmAuthentication
            public const string frmAuthentication = "Authentication";

            public const string lbAuthNotice = "Enter your authentication information:";

            public const string lbAuthUsername = "Username";
            public const string lbAuthPassword = "Password";
            public const string lbAuth2Factor = "2-Factor";
            public const string lbAuthVideoPassword = "Video password";
            public const string chkAuthUseNetrc = "Use .netrc for authentication";

            public const string lbAuthNoSave = "Your information will not be saved for security reasons.";

            public const string btnAuthBeginDownload = "Begin download";
            #endregion

            #region frmBatchDownloader
            // frmBatch
            public const string frmBatchDownload = "Batch downloader";
            public const string lbBatchDownloadLink = "Download link";
            public const string lbBatchDownloadType = "Download type";
            public const string lbBatchDownloadVideoSpecificArgument = "Video-specific argument";
            public const string btnBatchDownloadAdd = "Add";
            public const string sbBatchDownloadLoadArgs = "Load args";
            public const string mBatchDownloaderLoadArgsFromSettings = "Load args from settings";
            public const string mBatchDownloaderLoadArgsFromArgsTxt = "Load args from ./args.txt";
            public const string mBatchDownloaderLoadArgsFromFile = "Load args from file...";
            public const string btnBatchDownloadRemoveSelected = "Remove selected";
            public const string sbBatchDownloaderIdle = "Waiting for batch download start";
            public const string sbBatchDownloaderDownloading = "Batch download in progress...";
            public const string sbBatchDownloaderFinished = "Batch download finished. Add more items to start another batch, or exit";
            public const string sbBatchDownloaderAborted = "The batch process has been aborted";
            #endregion

            #region frmConverter
            public const string frmConverter = "Converting";
            public const string frmConverterComplete = "Conversion finished";
            public const string frmConverterError = "Error converting";
            public const string chkConverterCloseAfterConversion = "Close after converting";
            public const string btnConverterAbortBatchConversions = "Abort batch conversions";
            #endregion

            #region frmDownloader
            public const string frmDownloader = "Downloading";
            public const string frmDownloaderComplete = "Download finished";
            public const string frmDownloaderError = "Error downloading";
            public const string chkDownloaderCloseAfterDownload = "Close after download";
            public const string btnDownloaderAbortBatch = "Abort batch download";
            #endregion

            // frmDownloadLanguage
            public const string frmDownloadLanguage = "Download a language file...";

            #region frmException
            // frmException
            public const string frmException = "An exception occured";
            public const string lbExceptionHeader = "An exception has occured";
            public const string lbExceptionDescription = "Below is the error that occured. Feel free to open a new issue and report it.";
            public const string rtbExceptionDetails = "Feel free to copy + paste this entire text wall into a new issue on Github";
            public const string btnExceptionGithub = "Open Github";
            #endregion

            #region frmLanguage
            public const string frmLanguage = "Language select";
            public const string btnLanguageRefresh = "Refresh";
            public const string btnLanguageDownload = "Download...";
            #endregion

            #region frmMain
            // frmMain
            public const string frmMain = "youtube-dl-gui";
            // frmMain / menu
            public const string mSettings = "Settings";
            public const string mTools = "Tools";
            public const string mBatchDownload = "Batch download";
            public const string mDownloadSubtitles = "Download subtitles";
            public const string mMiscTools = "Misc tools";
            public const string mHelp = "Help";
            public const string mLanguage = "Language";
            public const string mSupportedSites = "Supported sites";
            public const string mAbout = "About";
            // frmMain / tcMain
            public const string tabDownload = "Download";
            public const string tabConvert = "Convert";
            public const string tabMerge = "Merge";
            // frmMain / tcMain / Download
            public const string lbURL = "URL";
            public const string txtUrlHint = "Video URL";
            public const string gbDownloadType = "Download type";
            public const string rbVideo = "Video";
            public const string rbAudio = "Audio";
            public const string rbCustom = "Custom";
            public const string lbQuality = "Quality";
            public const string lbFormat = "Format";
            public const string chkDownloadSound = "Sound";
            public const string chkUseSelection = "Video Selection";
            public const string rbVideoSelectionPlaylistIndex = "Playlist index";
            public const string rbVideoSelectionPlaylistItems = "Playlist items";
            public const string rbVideoSelectionBeforeDate = "Before date";
            public const string rbVideoSelectionOnDate = "On date";
            public const string rbVideoSelectionAfterDate = "After date";
            public const string txtPlaylistStartHint = "Start index";
            public const string txtPlaylistEndHint = "End index";
            public const string txtPlaylistItemsHint = "Video indexes (separated by commas)";
            public const string txtVideoDateHint = "Date (YYYYMMDD)";
            public const string lbCustomArguments = "Custom arguments";
            public const string txtArgsHint = "Custom youtube-dl arguments";
            public const string sbDownload = "Download";
            public const string mDownloadWithAuthentication = "Download with authentication...";
            public const string msgBatchDownloadFromFile = "Create a text file and put all the video links you want to download into it, separated as one per line.\nDo you want to skip seeing this message when batch downloading using this option?";
            public const string mBatchDownloadFromFile = "Batch download from file...";
            public const string lbDownloadStatusStarted = "Download started";
            public const string lbDownloadStatusError = "Error downloading";
            // frmMain / tcMain / Convert
            public const string lbConvertInput = "Input";
            public const string lbConvertOutput = "Output";
            public const string rbConvertVideo = "Video";
            public const string rbConvertAudio = "Audio";
            public const string rbConvertCustom = "Custom";
            public const string rbConvertAuto = "Automatic";
            public const string rbConvertAutoFFmpeg = "Auto ffmpeg";
            public const string btnConvert = "Convert";
            public const string lbConvertStarted = "Conversion started";
            public const string lbConvertFailed = "Conversion failed";
            // frmMain / tcMain / Merge
            public const string lbMergeInput1 = "Input 1";
            public const string lbMergeInput2 = "Input 2";
            public const string lbMergeOutput = "Output";
            public const string chkMergeAudioTracks = "Merge audio tracks";
            public const string chkMergeDeleteInputFiles = "Delete input files";
            public const string btnMerge = "Merge";
            // frmMain / tcMain / cmTray
            public const string cmTrayShowForm = "Show form";
            public const string cmTrayDownloader = "Downloader...";
            public const string cmTrayDownloadClipboard = "From clipboard...";
            public const string cmTrayDownloadBestVideo = "Download best video";
            public const string cmTrayDownloadBestAudio = "Download best audio";
            public const string cmTrayDownloadCustom = "Download custom...";
            public const string cmTrayDownloadCustomTxtBox = "From form textbox";
            public const string cmTrayDownloadCustomTxt = "From ./args.txt";
            public const string cmTrayDownloadCustomSettings = "From settings";
            public const string cmTrayConverter = "Converter...";
            public const string cmTrayConvertTo = "Conver to...";
            public const string cmTrayConvertVideo = "Video";
            public const string cmTrayConvertAudio = "Audio";
            public const string cmTrayConvertCustom = "Custom";
            public const string cmTrayConvertAutomatic = "Automatic";
            public const string cmTrayConvertAutoFFmpeg = "Auto ffmpeg";
            public const string cmTrayExit = "Exit";
            #endregion

            #region frmSettings

            // frmSettings
            public const string frmSettings = "youtube-dl-gui settings";
            public const string btnSettingsRedownloadYoutubeDl = "(re)download youtube-dl";
            public const string btnSettingsRedownloadYoutubeDlHint = "Redownloads youtube-dl if one is already present, otherwise, updates youtube-dl";
            public const string btnSettingsCancelHint = "Discard any changed settings";
            public const string btnSettingsSaveHint = "Save all configured settings";
            // frmSettings / tcMain
            public const string tabSettingsGeneral = "General";
            public const string tabSettingsDownloads = "Downloads";
            public const string tabSettingsConverter = "Converter";
            public const string tabSettingsExtensions = "Extensions";
            public const string tabSettingsErrors = "Errors";
            public const string tabSettingsPortable = "Portable";
            #region tabGeneral
            //frmSettings / tcMain / tabGeneral
            public const string lbSettingsGeneralYoutubeDlPath = "youtube-dl path";
            public const string chkSettingsGeneralUseStaticYoutubeDl = "Use static youtube-dl";
            public const string txtSettingsGeneralYoutubeDlPathHint = "The path of youtube-dl where it won't be moved";
            public const string btnSettingsGeneralBrowseYoutubeDlHint = "Browse for a new folder where you'll store youtube-dl";
            public const string ofdTitleYoutubeDl = "Select youtube-dl";
            public const string ofdFilterYoutubeDl = "youtube-dl executable";
            public const string lbSettingsGeneralFFmpegDirectory = "ffmpeg directory";
            public const string chkSettingsGeneralUseStaticFFmpeg = "Use static ffmpeg";
            public const string txtSettingsGeneralFFmpegPathHint = "The path of ffmpeg where it won't be moved";
            public const string btnSettingsGeneralBrowseFFmpegHint = "Browse for a new folder where you'll store ffmpeg";
            public const string ofdTitleFFmpeg = "Select ffmpeg.exe and ffprobe.exe";
            public const string ofdFilterFFmpeg = "ffmpeg and ffprobe executable";

            public const string chkSettingsGeneralCheckForUpdatesOnLaunch = "Check for updates on launch";
            public const string chkSettingsGeneralCheckForBetaUpdates = "Check for beta updates";
            public const string chkSettingsGeneralDeleteUpdaterAfterUpdating = "Delete updater after updating";
            public const string chkDeleteOldVersionAfterUpdating = "Delete old version after updating";
            public const string chkSettingsGeneralHoverOverUrlToPasteClipboard = "Hover over URL to paste clipboard";
            public const string chkSettingsGeneralClearUrlOnDownload = "Clear URL on download";
            public const string chkSettingsGeneralClearClipboardOnDownload = "Clear clipboard on download";
            public const string gbSettingsGeneralCustomArguments = "Custom arguments (saves on download)";
            public const string rbSettingsGeneralCustomArgumentsDontSave = "Don't save";
            public const string rbSettingsGeneralCustomArgumentsSaveAsArgsText = "Save as ./args.txt";
            public const string rbSettingsGeneralCustomArgumentsSaveInSettings = "Save in settings";

            public const string lbSettingsGeneralYoutubeDlPathHint = "Static youtube-dl directory\n\n" +
                                                                               "Static youtube-dl means youtube-dl will always be located in that one directory.";
            public const string chkSettingsGeneralUseStaticYoutubeDlHint = "Use a static placed youtube-dl.exe file";
            public const string lbSettingsGeneralFFmpegDirectoryHint = "Static ffmpeg directory\n\n" +
                                                                                 "Static ffmpeg means ffmpeg will always be located in that one directory.";
            public const string chkSettingsGeneralUseStaticFFmpegHint = "Use a static placed ffmpeg.exe and ffprobe.exe files";
            public const string chkSettingsGeneralCheckForUpdatesOnLaunchHint = "Check for updates on launch of youtube-dl-gui";
            public const string chkSettingsGeneralCheckForBetaUpdatesHint = "Checks for beta updates instead of regular updates";
            public const string chkSettingsGeneralDeleteUpdaterAfterUpdatingHint = "Deletes the youtube-dl-gui updater when it successfully updates.";
            public const string chkDeleteOldVersionAfterUpdatingHint = "Deletes the old version of youtube-dl-gui when it successfully updates.";
            public const string chkSettingsGeneralHoverOverUrlToPasteClipboardHint = "Hover over the URL textbox to paste the URL from the clipboard";
            public const string chkSettingsGeneralClearUrlOnDownloadHint = "Clears the URL from the textbox on video download";
            public const string chkSettingsGeneralClearClipboardOnDownloadHint = "Clears the clipboard on video download";
            public const string gbSettingsGeneralCustomArgumentsHint = "Controls how custom arguments for youtube-dl will be saved";
            public const string rbSettingsGeneralCustomArgumentsDontSaveHint = "Doesn't save any custom arguments";
            public const string rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = "Saves custom arguments as args.txt in youtube-dl-gui's directory";
            public const string rbSettingsGeneralCustomArgumentsSaveInSettingsHint = "Saves custom arguments in the application settings";
            #endregion
            #region tabDownloads
            // frmSettings / tcMain / tabDownloads
            public const string lbSettingsDownloadsDownloadPath = "download path";
            public const string chkSettingsDownloadsDownloadPathUseRelativePathHint = "Save to the program's relative path\r\n\r\nIf checked, the program will check the save path and use the current directory as the base path.\r\nSaving anywhere outside of the current directory will not set the flag and will set it to wherever you selected.";
            public const string txtSettingsDownloadsSavePathHint = "where your downloads will be saved to";
            public const string btnSettingsDownloadsBrowseSavePathHint = "browse for a new save folder";
            public const string lbSettingsDownloadsFileNameSchema = "file name schema";

            public const string tabDownloadsGeneral = "General";
            public const string tabDownloadsSorting = "Sorting";
            public const string tabdownloadsFixes = "Fixes";
            public const string tabDownloadsConnection = "Connection";
            public const string tabDownloadsUpdating = "Updating";

            public const string chkSettingsDownloadsSaveFormatQuality = "Save quality, format, && args on download";
            public const string chkSettingsDownloadsDownloadSubtitles = "Download subtitles";
            public const string chkSettingsDownloadsEmbedSubtitles = "Embed subtitles into file";
            public const string chkSettingsDownloadsSaveVideoInfo = "Save video info";
            public const string chkSettingsDownloadsWriteMetadataToFile = "Write metadata to file";
            public const string chkSettingsDownloadsSaveDescription = "Save description";
            public const string chkSettingsDownloadsKeepOriginalFiles = "Keep original files";
            public const string chkSettingsDownloadsSaveAnnotations = "Save annotations";
            public const string chkSettingsDownloadsSaveThumbnails = "Save thumbnails";
            public const string chkSettingsDownloadsEmbedThumbnails = "Embed thumbnail into file";
            public const string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = "Automatically delete youtube-dl when closing";
            public const string chkSettingsDownloadsSeparateDownloadsToDifferentFolders = "Separate downloads to different folders";
            public const string chkSettingsDownloadsSeparateIntoWebsiteUrl = "Separate into website url";
            public const string chkSettingsDownloadsFixVReddIt = "Fix v.redd.it";
            public const string chkSettingsDownloadsPreferFFmpeg = "Prefer ffmpeg for downloads";
            public const string chkSettingsDownloadsLimitDownload = "Limit download";
            public const string lbSettingsDownloadsRetryAttempts = "Retry attempts";
            public const string chkSettingsDownloadsForceIpv4 = "Force IPv4";
            public const string chkSettingsDownloadsForceIpv6 = "Force IPv6";
            public const string chkSettingsDownloadsUseProxy = "Use a proxy";
            public const string chksettingsDownloadsUseYoutubeDlsUpdater = "Use youtube-dl's internal updater";
            public const string lbSettingsDownloadsUpdatingYtdlType = "Youtube-DL fork";
            public const string llbSettingsDownloadsYtdlTypeViewRepo = "View source repo";
            public const string chkSettingsDownloadsSeparateBatchDownloads = "Separate Batch Downloads";
            public const string chkSettingsDownloadsAddDateToBatchDownloadFolders = "Include Date onto Download Folders";

            public const string lbSettingsDownloadsDownloadPathHint = "The path of the folder where files will be downloaded to";
            public const string lbSettingsDownloadsFileNameSchemaHint = "The file name schema\n\n" +
                                                                                  "This basically replaces sequences with video information for a custom file name.";
            public const string llSettingsDownloadsSchemaHelpHint = "Click here to view supported arguments";
            public const string txtSettingsDownloadsFileNameSchemaHint = "The file name schema that will be used by youtube-dl";

            public const string chkSettingsDownloadsSaveFormatQualityHint = "Saves the quality selection, format selection, and custom arguments on download on the main form";
            public const string chkSettingsDownloadsDownloadSubtitlesHint = "Download all available subtitles for the video\nIf no subtitles are available, nothing will download";
            public const string chkSettingsDownloadsEmbedSubtitlesHint = "Embeds downloaded subtitles into the output file\nOnly works for mp4, webm, and mkv videos";
            public const string chkSettingsDownloadsSaveVideoInfoHint = "Saves the video's info into a .info.json file";
            public const string chkSettingsDownloadsWriteMetadataToFileHint = "Writes the video's metadata to the output file";
            public const string chkSettingsDownloadsSaveDescriptionHint = "Saves the video's description to a .description file";
            public const string chkSettingsDownloadsKeepOriginalFilesHint = "Keeps the original files of the download\nBy default, youtube-dl will delete them after merging";
            public const string chkSettingsDownloadsSaveAnnotationsHint = "Saves the video's annotations to a .annotations.xml file";
            public const string chkSettingsDownloadsSaveThumbnailsHint = "Saves the video's thumbnail";
            public const string chkSettingsDownloadsEmbedThumbnailsHint = "Embeds downloaded thumbnails into the output file as cover art\nRequires AtomicParsley (https://github.com/wez/atomicparsley), or youtube-dl will result in an error";
            public const string chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = "Automatically delete youtube-dl.exe when closing youtube-dl-gui";
            public const string chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint = "Separates downloads into their own folder based on the download type\n\n" + "Videos would be <download directory>\\Video\n" + "Audio would be <download directory>\\Audio\n" + "Custom would be <download directory>\\Custom";
            public const string chkSettingsDownloadsSeparateIntoWebsiteUrlHint = "Downloaded files will be saved to the download path with the URL of the website appended at the end\n" + "Ex: C:\\Users\\YourName\\Videos\\youtube.com\\Video.mp4";
            public const string chkSettingsDownloadsFixVReddItHint = "Fixes visual corruptions on v.redd.it/reddit.com links using ffmpeg's HTTP Live Streaming (HLS)\n\n" + "Recommended to stay on.\n" + "This requires FFMPEG to be installed and available, it will fallback to youtube-dl's default.";
            public const string chkSettingsDownloadsPreferFFmpegHint = "Prefer's ffmpeg's hls over youtube-dl's own. This may fix some sites, and break others.";
            public const string chkSettingsDownloadsLimitDownloadHint = "Limits the downloads to the specified speed";
            public const string numSettingsDownloadsLimitDownloadHint = "The speed that the download will be throttled to\nSet the number to 0 to disable limiting";
            public const string cbSettingsDownloadsLimitDownloadHint = "The *byte size limit";
            public const string lbSettingsDownloadsRetryAttemptsHint = "Retry downloading the specified amount of times if it fails";
            public const string numSettingsDownloadsRetryAttemptsHint = "The maximum amount of retries allowed";
            public const string chkSettingsDownloadsForceIpv4Hint = "Force the connection to tunnel through IPv4";
            public const string chkSettingsDownloadsForceIpv6Hint = "Force the connection to tunnel through IPv6";
            public const string chkSettingsDownloadsUseProxyHint = "Download using a proxy";
            public const string cbSettingsDownloadsProxyTypeHint = "The proxy protocol that will be used";
            public const string txtSettingsDownloadsProxyIpHint = "The proxy IP that will be used";
            public const string txtSettingsDownloadsProxyPortHint = "The proxy port that will be used";
            public const string chksettingsDownloadsUseYoutubeDlsUpdaterHint = "Use youtube-dl's internal updater instead of this application's updater";
            public const string cbSettingsDownloadsUpdatingYtdlTypeHint = "The youtube-dl repo that will be targetted";
            public const string llbSettingsDownloadsYtdlTypeViewRepoHint = "Go to the repository page of the selected fork";
            public const string chkSettingsDownloadsSeparateBatchDownloadsHint = "Batch downloads are separated into a new folder in the designated download path";
            public const string chkSettingsDownloadsAddDateToBatchDownloadFoldersHint = "Batch downloads are further separated into a new folder that is the date and time the batch started";

            #endregion
            #region tabConverter
            // frmSettings / tcMain / tabConverter
            public const string chkSettingsConverterClearOutputAfterConverting = "Clear output after converting";
            public const string chkSettingsConverterDetectOutputFileType = "Detect output filetype";
            public const string chkSettingsConverterClearInputAfterConverting = "Clear input after converting";
            public const string chkSettingsConverterHideFFmpegCompileInfo = "Hide ffmpeg compile info";
            public const string tcSettingsConverterVideo = "Video";
            public const string tcSettingsConverterAudio = "Audio";
            public const string tcSettingsConverterCustom = "Custom";
            public const string lbSettingsConverterVideoBitrate = "Bitrate";
            public const string lbSettingsConverterVideoPreset = "Preset";
            public const string lbSettingsConverterVideoProfile = "Profile";
            public const string lbSettingsConverterVideoCRF = "CRF";
            public const string chkSettingsConverterVideoFastStart = "faststart";
            public const string lbSettingsConverterAudioBitrate = "Bitrate";
            public const string lbSettingsConverterCustomHeader = "Don't pass input or output directories/fies,\nit's automatically handled by the program";

            public const string chkSettingsConverterClearOutputAfterConvertingHint = "Clears the output file after a successful conversion";
            public const string chkSettingsConverterDetectOutputFileTypeHint = "If Automatic is checked on converting, this will attempt to detect the output file type.\n\n" + "Disable this if you want a simple conversion. The quality may suffer as a result.";
            public const string chkSettingsConverterClearInputAfterConvertingHint = "Clears the input file after a successful conversion";
            public const string chkSettingsConverterHideFFmpegCompileInfoHint = "Enabling this will hide some compilation information of ffmpeg.";
            public const string lbSettingsConverterVideoBitrateHint = "The bitrate of the video\n" +
                                                                "A bitrate is how many bits per second are streamed to the player\n\n" +
                                                                "higher = better, at the cost of file size\n\n" +
                                                                "If you were to input \"10,000\" as the bitrate, it would be interpreted as \"10,000,000\" bits per second.";
            public const string lbSettingsConverterVideoPresetHint = "The video preset of the conversion\n\n" +
                                                                                "ultrafast = fastest, but lower quality\n" +
                                                                                "veryslow = slowest, but higher quality";
            public const string lbSettingsConverterVideoProfileHint = "The encoder profile to be used during conversion. It affects the compression of the video.\n" +
                                                                                "It's generally a good idea to stick with the main profile";
            public const string lbSettingsConverterVideoCRFHint = "CRF is constant rate factor.\n\n" +
                                                                             "Lower = Higher quality";
            public const string chkSettingsConverterVideoFastStartHint = "Faststart moves the metadata to the front of the file.\n\n" +
                                                                                   "Enabling this allows videos to be played before they are fully downloaded.";
            public const string lbSettingsConverterAudioBitrateHint = "The bitrate of the audio\nA bitrate is how many bits are streamed to the player\n\nHigher = better, at the cost of size\n\nIf you were to put \"256\", it would be interpreted as \"256,000\" bits per second.";
            public const string txtSettingsConverterCustomArgumentsHint = "Custom arguments that will be passed through ffmpeg instead of built-in arguments";
            #endregion
            #region tabExtensions
            // frmSettings / tcMain / tabExtensions
            public const string lbSettingsExtensionsHeader = "This allows you to input your own extensions\nto be used with this application";
            public const string lbSettingsExtensionsExtensionFullName = "Extension full name";
            public const string txtSettingsExtensionsExtensionFullName = "Example extension";
            public const string lbSettingsExtensionsExtensionShort = "Extension short";
            public const string txtSettingsExtensionsExtensionShort = "ext";
            public const string btnSettingsExtensionsAdd = "Add";
            public const string lbSettingsExtensionsFileName = "FileName";
            public const string btnSettingsExtensionsRemoveSelected = "Remove selected";
            #endregion
            #region tabErrors
            // frmSettings / tcMain / tabErrors
            public const string chkSettingsErrorsShowDetailedErrors = "Show detailed errors";
            public const string chkSettingsErrorsSaveErrorsAsErrorLog = "Save errors as ./error.log";
            public const string chkSettingsErrorsSuppressErrors = "Suppress errors";
            public const string chkSettingsErrorsShowDetailedErrorsHint = "Shows more details in errors";
            public const string chkSettingsErrorsSaveErrorsAsErrorLogHint = "Saves the latest error as error.log in the exeucting directory of youtube-dl-gui";
            public const string chkSettingsErrorsSuppressErrorsHint = "This will silence any errors and will not save any error.log files.\n\n" +
                                                                                "This basically overrides all error settings. Use at your own risk.";
            #endregion
            #region tabSettingsPortable
            public const string lbSettingsPortableInformation = "You can toggle the use of a portable ini file here.\r\n\r\nIf enabled, the program will contain all your settings in the \"settings.ini\" file located in the same directory as youtube-dl-gui.\r\n\r\nThis is useful if you want to use this program with your settings on other systems, which is fine.\r\n\r\nToggling the ini file will transfer your current settings.\r\n\r\n";
            public const string chkSettingsPortableToggleIni = "Toggle portable ini";
            #endregion

            #endregion

            #region frmSubtitles
            // frmSubtitles
            public const string frmSubtitles = "Download subtitles";
            public const string lbSubtitlesHeader = "This only downloads subtitles";
            public const string lbSubtitlesUrl = "URL";
            public const string lbSubtitlesLanguages = "Language(s)";
            public const string btnSubtitlesAddLanguage = "Add";
            public const string btnSubtitlesClearLanguages = "Clear";
            public const string btnSubtitlesDownload = "Download subtitles";
            #endregion

            #region frmTools
            // frmTools
            public const string frmTools = "Misc tools";
            public const string btnMiscToolsRemoveAudio = "Remove audio...";
            public const string btnMiscToolsExtractAudio = "Extract audio...";
            public const string btnMiscToolsVideoToGif = "Video to gif...";
            #endregion

            #region frmUpdateAvailable
            public const string frmUpdateAvailable = "Update available";
            public const string lbUpdateAvailableHeader = "An update is available";
            public const string lbUpdateAvailableUpdateVersion = "Update version:";
            public const string lbUpdateAvailableCurrentVersion = "Current version:";
            public const string lbUpdateAvailableChangelog = "Changelog:";
            public const string btnUpdateAvailableSkipVersion = "Skip version";
            public const string btnUpdateAvailableUpdate = "Update";
            #endregion
        }

        /// <summary>
        /// Loads all the internal English strings to the instance.
        /// </summary>
        public void LoadInternalEnglish() {
            if (!Properties.Settings.Default.SkipInternalEnglish) {
                LoadedFile = null;

                // Langauge identifier
                CurrentLanguageLong = InternalEnglish.CurrentLanguageLong;
                CurrentLanguageShort = InternalEnglish.CurrentLanguageShort;
                CurrentLanguageHint = InternalEnglish.CurrentLanguageHint;

                // Generics
                GenericInputBest = InternalEnglish.GenericInputBest;
                GenericInputWorst = InternalEnglish.GenericInputWorst;
                GenericCancel = InternalEnglish.GenericCancel;
                GenericSkip = InternalEnglish.GenericSkip;
                GenericSound = InternalEnglish.GenericSound;
                GenericVideo = InternalEnglish.GenericVideo;
                GenericAudio = InternalEnglish.GenericAudio;
                GenericCustom = InternalEnglish.GenericCustom;
                GenericRetry = InternalEnglish.GenericRetry;
                GenericStart = InternalEnglish.GenericStart;
                GenericStop = InternalEnglish.GenericStop;
                GenericExit = InternalEnglish.GenericExit;
                GenericOk = InternalEnglish.GenericOk;
                GenericSave = InternalEnglish.GenericSave;

                // Dialogs
                dlgFirstTimeInitialMessage = InternalEnglish.dlgFirstTimeInitialMessage;
                dlgFirstTimeDownloadFolder = InternalEnglish.dlgFirstTimeDownloadFolder;
                dlgFindDownloadFolder = InternalEnglish.dlgFindDownloadFolder;
                dlgMainArgsTxtDoesntExist = InternalEnglish.dlgMainArgsTxtDoesntExist;
                dlgMainArgsTxtIsEmpty = InternalEnglish.dlgMainArgsTxtIsEmpty;
                dlgMainArgsNoneSaved = InternalEnglish.dlgMainArgsNoneSaved;
                dlgConvertSelectFileToConvert = InternalEnglish.dlgConvertSelectFileToConvert;
                dlgMergeSelectFileToMerge = InternalEnglish.dlgMergeSelectFileToMerge;
                dlgSaveOutputFileAs = InternalEnglish.dlgSaveOutputFileAs;
                dlgLanguageHashNoMatch = InternalEnglish.dlgLanguageHashNoMatch;
                dlgUpdateFailedToCheck = InternalEnglish.dlgUpdateFailedToCheck;
                dlgUpdateNoUpdateAvailable = InternalEnglish.dlgUpdateNoUpdateAvailable;
                dlgUpdateNoBetaUpdateAvailable = InternalEnglish.dlgUpdateNoBetaUpdateAvailable;
                dlgUpdateNoValidYoutubeDl = InternalEnglish.dlgUpdateNoValidYoutubeDl;
                dlgUpdatedYoutubeDl = InternalEnglish.dlgUpdatedYoutubeDl;
                dlgUpateYoutubeDlNoUpdateRequired = InternalEnglish.dlgUpateYoutubeDlNoUpdateRequired;
                dlgUpdaterHashNoMatch = InternalEnglish.dlgUpdaterHashNoMatch;
                GenericSave = InternalEnglish.GenericSave;
                GenericSave = InternalEnglish.GenericSave;

                // frmAbout
                frmAbout = InternalEnglish.frmAbout;
                lbAboutBody = InternalEnglish.lbAboutBody;
                llbCheckForUpdates = InternalEnglish.llbCheckForUpdates;

                // frmAuthentication
                frmAuthentication = InternalEnglish.frmAuthentication;
                lbAuthNotice = InternalEnglish.lbAuthNotice;
                lbAuthUsername = InternalEnglish.lbAuthUsername;
                lbAuthPassword = InternalEnglish.lbAuthPassword;
                lbAuth2Factor = InternalEnglish.lbAuth2Factor;
                lbAuthVideoPassword = InternalEnglish.lbAuthVideoPassword;
                chkAuthUseNetrc = InternalEnglish.chkAuthUseNetrc;
                lbAuthNoSave = InternalEnglish.lbAuthNoSave;
                btnAuthBeginDownload = InternalEnglish.btnAuthBeginDownload;

                // frmBatch
                frmBatchDownload = InternalEnglish.frmBatchDownload;
                lbBatchDownloadLink = InternalEnglish.lbBatchDownloadLink;
                lbBatchDownloadType = InternalEnglish.lbBatchDownloadType;
                lbBatchDownloadVideoSpecificArgument = InternalEnglish.lbBatchDownloadVideoSpecificArgument;
                btnBatchDownloadAdd = InternalEnglish.btnBatchDownloadAdd;
                sbBatchDownloadLoadArgs = InternalEnglish.sbBatchDownloadLoadArgs;
                mBatchDownloaderLoadArgsFromSettings = InternalEnglish.mBatchDownloaderLoadArgsFromSettings;
                mBatchDownloaderLoadArgsFromArgsTxt = InternalEnglish.mBatchDownloaderLoadArgsFromArgsTxt;
                mBatchDownloaderLoadArgsFromFile = InternalEnglish.mBatchDownloaderLoadArgsFromFile;
                btnBatchDownloadRemoveSelected = InternalEnglish.btnBatchDownloadRemoveSelected;
                sbBatchDownloaderIdle = InternalEnglish.sbBatchDownloaderIdle;
                sbBatchDownloaderDownloading = InternalEnglish.sbBatchDownloaderDownloading;
                sbBatchDownloaderFinished = InternalEnglish.sbBatchDownloaderFinished;
                sbBatchDownloaderAborted = InternalEnglish.sbBatchDownloaderAborted;

                // frmConverter
                frmConverter = InternalEnglish.frmConverter;
                frmConverterComplete = InternalEnglish.frmConverterComplete;
                frmConverterError = InternalEnglish.frmConverterError;
                chkConverterCloseAfterConversion = InternalEnglish.chkConverterCloseAfterConversion;
                btnConverterAbortBatchConversions = InternalEnglish.btnConverterAbortBatchConversions;

                // frmDownloader
                frmDownloader = InternalEnglish.frmDownloader;
                frmDownloaderComplete = InternalEnglish.frmDownloaderComplete;
                frmDownloaderError = InternalEnglish.frmDownloaderError;
                chkDownloaderCloseAfterDownload = InternalEnglish.chkDownloaderCloseAfterDownload;
                btnDownloaderAbortBatch = InternalEnglish.btnDownloaderAbortBatch;

                // frmDownloadLanguage
                frmDownloadLanguage = InternalEnglish.frmDownloadLanguage;

                // frmException
                frmException = InternalEnglish.frmException;
                lbExceptionHeader = InternalEnglish.lbExceptionHeader;
                lbExceptionDescription = InternalEnglish.lbExceptionDescription;
                rtbExceptionDetails = InternalEnglish.rtbExceptionDetails;
                btnExceptionGithub = InternalEnglish.btnExceptionGithub;

                // frmLanguage
                frmLanguage = InternalEnglish.frmLanguage;
                btnLanguageRefresh = InternalEnglish.btnLanguageRefresh;
                btnLanguageDownload = InternalEnglish.btnLanguageDownload;

                // frmMain
                mSettings = InternalEnglish.mSettings;
                mTools = InternalEnglish.mTools;
                mBatchDownload = InternalEnglish.mBatchDownload;
                mDownloadSubtitles = InternalEnglish.mDownloadSubtitles;
                mMiscTools = InternalEnglish.mMiscTools;
                mHelp = InternalEnglish.mHelp;
                mLanguage = InternalEnglish.mLanguage;
                mSupportedSites = InternalEnglish.mSupportedSites;
                mAbout = InternalEnglish.mAbout;

                tabDownload = InternalEnglish.tabDownload;
                tabConvert = InternalEnglish.tabConvert;
                tabMerge = InternalEnglish.tabMerge;

                lbURL = InternalEnglish.lbURL;
                txtUrlHint = InternalEnglish.txtUrlHint;
                gbDownloadType = InternalEnglish.gbDownloadType;
                lbQuality = InternalEnglish.lbQuality;
                lbFormat = InternalEnglish.lbFormat;
                chkDownloadSound = InternalEnglish.chkDownloadSound;
                chkUseSelection = InternalEnglish.chkUseSelection;
                rbVideoSelectionPlaylistIndex = InternalEnglish.rbVideoSelectionPlaylistIndex;
                rbVideoSelectionPlaylistItems = InternalEnglish.rbVideoSelectionPlaylistItems;
                rbVideoSelectionBeforeDate = InternalEnglish.rbVideoSelectionBeforeDate;
                rbVideoSelectionOnDate = InternalEnglish.rbVideoSelectionOnDate;
                rbVideoSelectionAfterDate = InternalEnglish.rbVideoSelectionAfterDate;
                txtPlaylistStartHint = InternalEnglish.txtPlaylistStartHint;
                txtPlaylistEndHint = InternalEnglish.txtPlaylistEndHint;
                txtPlaylistItemsHint = InternalEnglish.txtPlaylistItemsHint;
                txtVideoDateHint = InternalEnglish.txtVideoDateHint;
                lbCustomArguments = InternalEnglish.lbCustomArguments;
                txtArgsHint = InternalEnglish.txtArgsHint;
                sbDownload = InternalEnglish.sbDownload;
                mDownloadWithAuthentication = InternalEnglish.mDownloadWithAuthentication;
                msgBatchDownloadFromFile = InternalEnglish.msgBatchDownloadFromFile;
                mBatchDownloadFromFile = InternalEnglish.mBatchDownloadFromFile;
                lbDownloadStatusStarted = InternalEnglish.lbDownloadStatusStarted;
                lbDownloadStatusError = InternalEnglish.lbDownloadStatusError;

                lbConvertInput = InternalEnglish.lbConvertInput;
                lbConvertOutput = InternalEnglish.lbConvertOutput;
                rbConvertAuto = InternalEnglish.rbConvertAuto;
                rbConvertAutoFFmpeg = InternalEnglish.rbConvertAutoFFmpeg;
                btnConvert = InternalEnglish.btnConvert;
                lbConvertStarted = InternalEnglish.lbConvertStarted;
                lbConvertFailed = InternalEnglish.lbConvertFailed;

                lbMergeInput1 = InternalEnglish.lbMergeInput1;
                lbMergeInput2 = InternalEnglish.lbMergeInput2;
                lbMergeOutput = InternalEnglish.lbMergeOutput;
                chkMergeAudioTracks = InternalEnglish.chkMergeAudioTracks;
                chkMergeDeleteInputFiles = InternalEnglish.chkMergeDeleteInputFiles;
                btnMerge = InternalEnglish.btnMerge;

                cmTrayShowForm = InternalEnglish.cmTrayShowForm;
                cmTrayDownloader = InternalEnglish.cmTrayDownloader;
                cmTrayDownloadClipboard = InternalEnglish.cmTrayDownloadClipboard;
                cmTrayDownloadBestVideo = InternalEnglish.cmTrayDownloadBestVideo;
                cmTrayDownloadBestAudio = InternalEnglish.cmTrayDownloadBestAudio;
                cmTrayDownloadCustom = InternalEnglish.cmTrayDownloadCustom;
                cmTrayDownloadCustomTxtBox = InternalEnglish.cmTrayDownloadCustomTxtBox;
                cmTrayDownloadCustomTxt = InternalEnglish.cmTrayDownloadCustomTxt;
                cmTrayDownloadCustomSettings = InternalEnglish.cmTrayDownloadCustomSettings;
                cmTrayConverter = InternalEnglish.cmTrayConverter;
                cmTrayConvertTo = InternalEnglish.cmTrayConvertTo;
                cmTrayConvertVideo = InternalEnglish.cmTrayConvertVideo;
                cmTrayConvertAudio = InternalEnglish.cmTrayConvertAudio;
                cmTrayConvertCustom = InternalEnglish.cmTrayConvertCustom;
                cmTrayConvertAutomatic = InternalEnglish.cmTrayConvertAutomatic;
                cmTrayConvertAutoFFmpeg = InternalEnglish.cmTrayConvertAutoFFmpeg;
                cmTrayExit = InternalEnglish.cmTrayExit;

                // frmSettings
                frmSettings = InternalEnglish.frmSettings;
                btnSettingsRedownloadYoutubeDl = InternalEnglish.btnSettingsRedownloadYoutubeDl;

                tabSettingsGeneral = InternalEnglish.tabSettingsGeneral;
                tabSettingsDownloads = InternalEnglish.tabSettingsDownloads;
                tabSettingsConverter = InternalEnglish.tabSettingsConverter;
                tabSettingsExtensions = InternalEnglish.tabSettingsExtensions;
                tabSettingsErrors = InternalEnglish.tabSettingsErrors;
                tabSettingsPortable = InternalEnglish.tabSettingsPortable;

                lbSettingsGeneralYoutubeDlPath = InternalEnglish.lbSettingsGeneralYoutubeDlPath;
                chkSettingsGeneralUseStaticYoutubeDl = InternalEnglish.chkSettingsGeneralUseStaticYoutubeDl;
                ofdTitleYoutubeDl = InternalEnglish.ofdTitleYoutubeDl;
                ofdFilterYoutubeDl = InternalEnglish.ofdFilterYoutubeDl;
                lbSettingsGeneralFFmpegDirectory = InternalEnglish.lbSettingsGeneralFFmpegDirectory;
                chkSettingsGeneralUseStaticFFmpeg = InternalEnglish.chkSettingsGeneralUseStaticFFmpeg;
                ofdTitleFFmpeg = InternalEnglish.ofdTitleFFmpeg;
                ofdFilterFFmpeg = InternalEnglish.ofdFilterFFmpeg;
                chkSettingsGeneralCheckForUpdatesOnLaunch = InternalEnglish.chkSettingsGeneralCheckForUpdatesOnLaunch;
                chkSettingsGeneralCheckForBetaUpdates = InternalEnglish.chkSettingsGeneralCheckForBetaUpdates;
                chkSettingsGeneralDeleteUpdaterAfterUpdating = InternalEnglish.chkSettingsGeneralDeleteUpdaterAfterUpdating;
                chkDeleteOldVersionAfterUpdating = InternalEnglish.chkDeleteOldVersionAfterUpdating;
                chkSettingsGeneralHoverOverUrlToPasteClipboard = InternalEnglish.chkSettingsGeneralHoverOverUrlToPasteClipboard;
                chkSettingsGeneralClearUrlOnDownload = InternalEnglish.chkSettingsGeneralClearUrlOnDownload;
                chkSettingsGeneralClearClipboardOnDownload = InternalEnglish.chkSettingsGeneralClearClipboardOnDownload;
                gbSettingsGeneralCustomArguments = InternalEnglish.gbSettingsGeneralCustomArguments;
                rbSettingsGeneralCustomArgumentsDontSave = InternalEnglish.rbSettingsGeneralCustomArgumentsDontSave;
                rbSettingsGeneralCustomArgumentsSaveAsArgsText = InternalEnglish.rbSettingsGeneralCustomArgumentsSaveAsArgsText;
                rbSettingsGeneralCustomArgumentsSaveInSettings = InternalEnglish.rbSettingsGeneralCustomArgumentsSaveInSettings;

                lbSettingsDownloadsDownloadPath = InternalEnglish.lbSettingsDownloadsDownloadPath;
                lbSettingsDownloadsFileNameSchema = InternalEnglish.lbSettingsDownloadsFileNameSchema;
                tabDownloadsGeneral = InternalEnglish.tabDownloadsGeneral;
                tabDownloadsSorting = InternalEnglish.tabDownloadsSorting;
                tabDownloadsFixes = InternalEnglish.tabdownloadsFixes;
                tabDownloadsConnection = InternalEnglish.tabDownloadsConnection;
                tabDownloadsUpdating = InternalEnglish.tabDownloadsUpdating;

                chkSettingsDownloadsSaveFormatQuality = InternalEnglish.chkSettingsDownloadsSaveFormatQuality;
                chkSettingsDownloadsDownloadSubtitles = InternalEnglish.chkSettingsDownloadsDownloadSubtitles;
                chkSettingsDownloadsEmbedSubtitles = InternalEnglish.chkSettingsDownloadsEmbedSubtitles;
                chkSettingsDownloadsSaveVideoInfo = InternalEnglish.chkSettingsDownloadsSaveVideoInfo;
                chkSettingsDownloadsWriteMetadataToFile = InternalEnglish.chkSettingsDownloadsWriteMetadataToFile;
                chkSettingsDownloadsSaveDescription = InternalEnglish.chkSettingsDownloadsSaveDescription;
                chkSettingsDownloadsKeepOriginalFiles = InternalEnglish.chkSettingsDownloadsKeepOriginalFiles;
                chkSettingsDownloadsSaveAnnotations = InternalEnglish.chkSettingsDownloadsSaveAnnotations;
                chkSettingsDownloadsSaveThumbnails = InternalEnglish.chkSettingsDownloadsSaveThumbnails;
                chkSettingsDownloadsEmbedThumbnails = InternalEnglish.chkSettingsDownloadsEmbedThumbnails;
                chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = InternalEnglish.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing;
                chkSettingsDownloadsSeparateDownloadsToDifferentFolders = InternalEnglish.chkSettingsDownloadsSeparateDownloadsToDifferentFolders;
                chkSettingsDownloadsSeparateIntoWebsiteUrl = InternalEnglish.chkSettingsDownloadsSeparateIntoWebsiteUrl;
                chkSettingsDownloadsFixVReddIt = InternalEnglish.chkSettingsDownloadsFixVReddIt;
                chkSettingsDownloadsPreferFFmpeg = InternalEnglish.chkSettingsDownloadsPreferFFmpeg;
                chkSettingsDownloadsLimitDownload = InternalEnglish.chkSettingsDownloadsLimitDownload;
                lbSettingsDownloadsRetryAttempts = InternalEnglish.lbSettingsDownloadsRetryAttempts;
                chkSettingsDownloadsForceIpv4 = InternalEnglish.chkSettingsDownloadsForceIpv4;
                chkSettingsDownloadsForceIpv6 = InternalEnglish.chkSettingsDownloadsForceIpv6;
                chkSettingsDownloadsUseProxy = InternalEnglish.chkSettingsDownloadsUseProxy;
                chkSettingsDownloadsUseYoutubeDlsUpdater = InternalEnglish.chksettingsDownloadsUseYoutubeDlsUpdater;
                lbSettingsDownloadsUpdatingYtdlType = InternalEnglish.lbSettingsDownloadsUpdatingYtdlType;
                llbSettingsDownloadsYtdlTypeViewRepo = InternalEnglish.llbSettingsDownloadsYtdlTypeViewRepo;
                chkSettingsDownloadsSeparateBatchDownloads = InternalEnglish.chkSettingsDownloadsSeparateBatchDownloads;
                chkSettingsDownloadsAddDateToBatchDownloadFolders = InternalEnglish.chkSettingsDownloadsAddDateToBatchDownloadFolders;

                chkSettingsConverterClearOutputAfterConverting = InternalEnglish.chkSettingsConverterClearOutputAfterConverting;
                chkSettingsConverterDetectOutputFileType = InternalEnglish.chkSettingsConverterDetectOutputFileType;
                chkSettingsConverterClearInputAfterConverting = InternalEnglish.chkSettingsConverterClearInputAfterConverting;
                chkSettingsConverterHideFFmpegCompileInfo = InternalEnglish.chkSettingsConverterHideFFmpegCompileInfo;
                tcSettingsConverterVideo = InternalEnglish.tcSettingsConverterVideo;
                tcSettingsConverterAudio = InternalEnglish.tcSettingsConverterAudio;
                tcSettingsConverterCustom = InternalEnglish.tcSettingsConverterCustom;
                lbSettingsConverterVideoBitrate = InternalEnglish.lbSettingsConverterVideoBitrate;
                lbSettingsConverterVideoPreset = InternalEnglish.lbSettingsConverterVideoPreset;
                lbSettingsConverterVideoProfile = InternalEnglish.lbSettingsConverterVideoProfile;
                lbSettingsConverterVideoCRF = InternalEnglish.lbSettingsConverterVideoCRF;
                chkSettingsConverterVideoFastStart = InternalEnglish.chkSettingsConverterVideoFastStart;
                lbSettingsConverterAudioBitrate = InternalEnglish.lbSettingsConverterAudioBitrate;
                lbSettingsConverterCustomHeader = InternalEnglish.lbSettingsConverterCustomHeader;

                lbSettingsExtensionsHeader = InternalEnglish.lbSettingsExtensionsHeader;
                lbSettingsExtensionsExtensionFullName = InternalEnglish.lbSettingsExtensionsExtensionFullName;
                txtSettingsExtensionsExtensionFullName = InternalEnglish.txtSettingsExtensionsExtensionFullName;
                lbSettingsExtensionsExtensionShort = InternalEnglish.lbSettingsExtensionsExtensionShort;
                txtSettingsExtensionsExtensionShort = InternalEnglish.txtSettingsExtensionsExtensionShort;
                btnSettingsExtensionsAdd = InternalEnglish.btnSettingsExtensionsAdd;
                lbSettingsExtensionsFileName = InternalEnglish.lbSettingsExtensionsFileName;
                btnSettingsExtensionsRemoveSelected = InternalEnglish.btnSettingsExtensionsRemoveSelected;

                chkSettingsErrorsShowDetailedErrors = InternalEnglish.chkSettingsErrorsShowDetailedErrors;
                chkSettingsErrorsSaveErrorsAsErrorLog = InternalEnglish.chkSettingsErrorsSaveErrorsAsErrorLog;
                chkSettingsErrorsSuppressErrors = InternalEnglish.chkSettingsErrorsSuppressErrors;

                lbSettingsPortableInformation = InternalEnglish.lbSettingsPortableInformation;
                chkSettingsPortableToggleIni = InternalEnglish.chkSettingsPortableToggleIni;

                // frmSettings tipSettings
                btnSettingsRedownloadYoutubeDlHint = InternalEnglish.btnSettingsRedownloadYoutubeDlHint;
                btnSettingsCancelHint = InternalEnglish.btnSettingsCancelHint;
                btnSettingsSaveHint = InternalEnglish.btnSettingsSaveHint;

                lbSettingsGeneralYoutubeDlPathHint = InternalEnglish.lbSettingsGeneralYoutubeDlPathHint;
                chkSettingsGeneralUseStaticYoutubeDlHint = InternalEnglish.chkSettingsGeneralUseStaticYoutubeDlHint;
                txtSettingsGeneralYoutubeDlPathHint = InternalEnglish.txtSettingsGeneralYoutubeDlPathHint;
                btnSettingsGeneralBrowseYoutubeDlHint = InternalEnglish.btnSettingsGeneralBrowseYoutubeDlHint;
                lbSettingsGeneralFFmpegDirectoryHint = InternalEnglish.lbSettingsGeneralFFmpegDirectoryHint;
                chkSettingsGeneralUseStaticFFmpegHint = InternalEnglish.chkSettingsGeneralUseStaticFFmpegHint;
                txtSettingsGeneralFFmpegPathHint = InternalEnglish.txtSettingsGeneralFFmpegPathHint;
                btnSettingsGeneralBrowseFFmpegHint = InternalEnglish.btnSettingsGeneralBrowseFFmpegHint;
                chkSettingsGeneralCheckForUpdatesOnLaunchHint = InternalEnglish.chkSettingsGeneralCheckForUpdatesOnLaunchHint;
                chkSettingsGeneralCheckForBetaUpdatesHint = InternalEnglish.chkSettingsGeneralCheckForBetaUpdatesHint;
                chkSettingsGeneralDeleteUpdaterAfterUpdatingHint = InternalEnglish.chkSettingsGeneralDeleteUpdaterAfterUpdatingHint;
                chkDeleteOldVersionAfterUpdatingHint = InternalEnglish.chkDeleteOldVersionAfterUpdatingHint;
                chkSettingsGeneralHoverOverUrlToPasteClipboardHint = InternalEnglish.chkSettingsGeneralHoverOverUrlToPasteClipboardHint;
                chkSettingsGeneralClearUrlOnDownloadHint = InternalEnglish.chkSettingsGeneralClearUrlOnDownloadHint;
                chkSettingsGeneralClearClipboardOnDownloadHint = InternalEnglish.chkSettingsGeneralClearClipboardOnDownloadHint;
                gbSettingsGeneralCustomArgumentsHint = InternalEnglish.gbSettingsGeneralCustomArgumentsHint;
                rbSettingsGeneralCustomArgumentsDontSaveHint = InternalEnglish.rbSettingsGeneralCustomArgumentsDontSaveHint;
                rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = InternalEnglish.rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint;
                rbSettingsGeneralCustomArgumentsSaveInSettingsHint = InternalEnglish.rbSettingsGeneralCustomArgumentsSaveInSettingsHint;

                lbSettingsDownloadsDownloadPathHint = InternalEnglish.lbSettingsDownloadsDownloadPathHint;
                chkSettingsDownloadsDownloadPathUseRelativePathHint = InternalEnglish.chkSettingsDownloadsDownloadPathUseRelativePathHint;
                txtSettingsDownloadsSavePathHint = InternalEnglish.txtSettingsDownloadsSavePathHint;
                btnSettingsDownloadsBrowseSavePathHint = InternalEnglish.btnSettingsDownloadsBrowseSavePathHint;
                llSettingsDownloadsSchemaHelpHint = InternalEnglish.llSettingsDownloadsSchemaHelpHint;
                lbSettingsDownloadsFileNameSchemaHint = InternalEnglish.lbSettingsDownloadsFileNameSchemaHint;
                txtSettingsDownloadsFileNameSchemaHint = InternalEnglish.txtSettingsDownloadsFileNameSchemaHint;

                chkSettingsDownloadsSaveFormatQualityHint = InternalEnglish.chkSettingsDownloadsSaveFormatQualityHint;
                chkSettingsDownloadsDownloadSubtitlesHint = InternalEnglish.chkSettingsDownloadsDownloadSubtitlesHint;
                chkSettingsDownloadsEmbedSubtitlesHint = InternalEnglish.chkSettingsDownloadsEmbedSubtitlesHint;
                chkSettingsDownloadsSaveVideoInfoHint = InternalEnglish.chkSettingsDownloadsSaveVideoInfoHint;
                chkSettingsDownloadsWriteMetadataToFileHint = InternalEnglish.chkSettingsDownloadsWriteMetadataToFileHint;
                chkSettingsDownloadsSaveDescriptionHint = InternalEnglish.chkSettingsDownloadsSaveDescriptionHint;
                chkSettingsDownloadsKeepOriginalFilesHint = InternalEnglish.chkSettingsDownloadsKeepOriginalFilesHint;
                chkSettingsDownloadsSaveAnnotationsHint = InternalEnglish.chkSettingsDownloadsSaveAnnotationsHint;
                chkSettingsDownloadsSaveThumbnailsHint = InternalEnglish.chkSettingsDownloadsSaveThumbnailsHint;
                chkSettingsDownloadsEmbedThumbnailsHint = InternalEnglish.chkSettingsDownloadsEmbedThumbnailsHint;
                chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = InternalEnglish.chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint;
                chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint = InternalEnglish.chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint;
                chkSettingsDownloadsSeparateIntoWebsiteUrlHint = InternalEnglish.chkSettingsDownloadsSeparateIntoWebsiteUrlHint;
                chkSettingsDownloadsFixVReddItHint = InternalEnglish.chkSettingsDownloadsFixVReddItHint;
                chkSettingsDownloadsPreferFFmpegHint = InternalEnglish.chkSettingsDownloadsPreferFFmpegHint;
                chkSettingsDownloadsLimitDownloadHint = InternalEnglish.chkSettingsDownloadsLimitDownloadHint;
                numSettingsDownloadsLimitDownloadHint = InternalEnglish.numSettingsDownloadsLimitDownloadHint;
                cbSettingsDownloadsLimitDownloadHint = InternalEnglish.cbSettingsDownloadsLimitDownloadHint;
                lbSettingsDownloadsRetryAttemptsHint = InternalEnglish.lbSettingsDownloadsRetryAttemptsHint;
                numSettingsDownloadsRetryAttemptsHint = InternalEnglish.numSettingsDownloadsRetryAttemptsHint;
                chkSettingsDownloadsForceIpv4Hint = InternalEnglish.chkSettingsDownloadsForceIpv4Hint;
                chkSettingsDownloadsForceIpv6Hint = InternalEnglish.chkSettingsDownloadsForceIpv6Hint;
                chkSettingsDownloadsUseProxyHint = InternalEnglish.chkSettingsDownloadsUseProxyHint;
                cbSettingsDownloadsProxyTypeHint = InternalEnglish.cbSettingsDownloadsProxyTypeHint;
                txtSettingsDownloadsProxyIpHint = InternalEnglish.txtSettingsDownloadsProxyIpHint;
                txtSettingsDownloadsProxyPortHint = InternalEnglish.txtSettingsDownloadsProxyPortHint;
                chksettingsDownloadsUseYoutubeDlsUpdaterHint = InternalEnglish.chksettingsDownloadsUseYoutubeDlsUpdaterHint;
                cbSettingsDownloadsUpdatingYtdlTypeHint = InternalEnglish.cbSettingsDownloadsUpdatingYtdlTypeHint;
                llbSettingsDownloadsYtdlTypeViewRepoHint = InternalEnglish.llbSettingsDownloadsYtdlTypeViewRepoHint;
                chkSettingsDownloadsSeparateBatchDownloadsHint = InternalEnglish.chkSettingsDownloadsSeparateBatchDownloadsHint;
                chkSettingsDownloadsAddDateToBatchDownloadFoldersHint = InternalEnglish.chkSettingsDownloadsAddDateToBatchDownloadFoldersHint;

                chkSettingsConverterClearOutputAfterConvertingHint = InternalEnglish.chkSettingsConverterClearOutputAfterConvertingHint;
                chkSettingsConverterDetectOutputFileTypeHint = InternalEnglish.chkSettingsConverterDetectOutputFileTypeHint;
                chkSettingsConverterClearInputAfterConvertingHint = InternalEnglish.chkSettingsConverterClearInputAfterConvertingHint;
                chkSettingsConverterHideFFmpegCompileInfoHint = InternalEnglish.chkSettingsConverterHideFFmpegCompileInfoHint;
                lbSettingsConverterVideoBitrateHint = InternalEnglish.lbSettingsConverterVideoBitrateHint;
                lbSettingsConverterVideoPresetHint = InternalEnglish.lbSettingsConverterVideoPresetHint;
                lbSettingsConverterVideoProfileHint = InternalEnglish.lbSettingsConverterVideoProfileHint;
                lbSettingsConverterVideoCRFHint = InternalEnglish.lbSettingsConverterVideoCRFHint;
                chkSettingsConverterVideoFastStartHint = InternalEnglish.chkSettingsConverterVideoFastStartHint;
                lbSettingsConverterAudioBitrateHint = InternalEnglish.lbSettingsConverterAudioBitrateHint;
                txtSettingsConverterCustomArgumentsHint = InternalEnglish.txtSettingsConverterCustomArgumentsHint;

                //lbSettingsExtensionsHeader = InternalEnglish.lbSettingsExtensionsHeader;
                //lbSettingsExtensionsExtensionFullName = InternalEnglish.lbSettingsExtensionsExtensionFullName;
                //lbSettingsExtensionsExtensionShort = InternalEnglish.lbSettingsExtensionsExtensionShort;
                //btnSettingsExtensionsAdd = InternalEnglish.btnSettingsExtensionsAdd;
                //btnSettingsExtensionsRemoveSelected = InternalEnglish.btnSettingsExtensionsRemoveSelected;

                chkSettingsErrorsShowDetailedErrorsHint = InternalEnglish.chkSettingsErrorsShowDetailedErrorsHint;
                chkSettingsErrorsSaveErrorsAsErrorLogHint = InternalEnglish.chkSettingsErrorsSaveErrorsAsErrorLogHint;
                chkSettingsErrorsSuppressErrorsHint = InternalEnglish.chkSettingsErrorsSuppressErrorsHint;


                // frmSubtitles
                frmSubtitles = InternalEnglish.frmSubtitles;
                lbSubtitlesHeader = InternalEnglish.lbSubtitlesHeader;
                lbSubtitlesUrl = InternalEnglish.lbSubtitlesUrl;
                lbSubtitlesLanguages = InternalEnglish.lbSubtitlesLanguages;
                btnSubtitlesAddLanguage = InternalEnglish.btnSubtitlesAddLanguage;
                btnSubtitlesClearLanguages = InternalEnglish.btnSubtitlesClearLanguages;
                btnSubtitlesDownload = InternalEnglish.btnSubtitlesDownload;

                // frmTools
                frmTools = InternalEnglish.frmTools;
                btnMiscToolsRemoveAudio = InternalEnglish.btnMiscToolsRemoveAudio;
                btnMiscToolsExtractAudio = InternalEnglish.btnMiscToolsExtractAudio;
                btnMiscToolsVideoToGif = InternalEnglish.btnMiscToolsVideoToGif;

                // frmUpdateAvailable
                frmUpdateAvailable = InternalEnglish.frmUpdateAvailable;
                lbUpdateAvailableHeader = InternalEnglish.lbUpdateAvailableHeader;
                lbUpdateAvailableUpdateVersion = InternalEnglish.lbUpdateAvailableUpdateVersion;
                lbUpdateAvailableCurrentVersion = InternalEnglish.lbUpdateAvailableCurrentVersion;
                lbUpdateAvailableChangelog = InternalEnglish.lbUpdateAvailableChangelog;
                btnUpdateAvailableSkipVersion = InternalEnglish.btnUpdateAvailableSkipVersion;
                btnUpdateAvailableUpdate = InternalEnglish.btnUpdateAvailableUpdate;
            }
        }

        /// <summary>
        /// Resets the control names to their internal names.
        /// </summary>
        public void ResetControlNames() {
            LoadedFile = null;

            // Langauge identifier
            CurrentLanguageLong = "CurrentLanguageLong";
            CurrentLanguageShort = "CurrentLanguageShort";
            CurrentLanguageHint = "CurrentLanguageHint";

            // Generics
            GenericInputBest = "GenericInputBest";
            GenericInputWorst = "GenericInputWorst";
            GenericCancel = "GenericCancel";
            GenericSkip = "GenericSkip";
            GenericSound = "GenericSound";
            GenericVideo = "GenericVideo";
            GenericAudio = "GenericAudio";
            GenericCustom = "GenericCustom";
            GenericRetry = "GenericRetry";
            GenericStart = "GenericStart";
            GenericStop = "GenericStop";
            GenericExit = "GenericExit";
            GenericOk = "GenericOk";
            GenericSave = "GenericSave";

            // Dialogs
            dlgFirstTimeInitialMessage = "dlgFirstTimeInitialMessage";
            dlgFirstTimeDownloadFolder = "dlgFirstTimeDownloadFolder";
            dlgFindDownloadFolder = "dlgFindDownloadFolder";
            dlgMainArgsTxtDoesntExist = "dlgMainArgsTxtDoesntExist";
            dlgMainArgsTxtIsEmpty = "dlgMainArgsTxtIsEmpty";
            dlgMainArgsNoneSaved = "dlgMainArgsNoneSaved";
            dlgConvertSelectFileToConvert = "dlgConvertSelectFileToConvert";
            dlgMergeSelectFileToMerge = "dlgMergeSelectFileToMerge";
            dlgSaveOutputFileAs = "dlgSaveOutputFileAs";
            dlgLanguageHashNoMatch = "dlgLanguageHashNoMatch";
            dlgUpdateFailedToCheck = "dlgUpdateFailedToCheck";
            dlgUpdateNoUpdateAvailable = "dlgUpdateNoUpdateAvailable";
            dlgUpdateNoBetaUpdateAvailable = "dlgUpdateNoBetaUpdateAvailable";
            dlgUpdateNoValidYoutubeDl = "dlgUpdateNoValidYoutubeDl";
            dlgUpdatedYoutubeDl = "dlgUpdatedYoutubeDl";
            dlgUpateYoutubeDlNoUpdateRequired = "dlgUpateYoutubeDlNoUpdateRequired";
            dlgUpdaterHashNoMatch = "dlgUpdaterHashNoMatch";

            // frmAbout
            frmAbout = "frmAbout";
            lbAboutBody = "lbAboutBody";
            llbCheckForUpdates = "llbCheckForUpdates";

            // frmAuthentication
            frmAuthentication = "frmAuthentication";
            lbAuthNotice = "lbAuthNotice";
            lbAuthUsername = "lbAuthUsername";
            lbAuthPassword = "lbAuthPassword";
            lbAuth2Factor = "lbAuth2Factor";
            lbAuthVideoPassword = "lbAuthVideoPassword";
            chkAuthUseNetrc = "chkAuthUseNetrc";
            lbAuthNoSave = "lbAuthNoSave";
            btnAuthBeginDownload = "btnAuthBeginDownload";

            // frmBatch
            frmBatchDownload = "frmBatchDownload";
            lbBatchDownloadLink = "lbBatchDownloadLink";
            lbBatchDownloadType = "lbBatchDownloadType";
            lbBatchDownloadVideoSpecificArgument = "lbBatchDownloadVideoSpecificArgument";
            btnBatchDownloadAdd = "btnBatchDownloadAdd";
            sbBatchDownloadLoadArgs = "sbBatchDownloadLoadArgs";
            mBatchDownloaderLoadArgsFromSettings = "mBatchDownloaderLoadArgsFromSettings";
            mBatchDownloaderLoadArgsFromArgsTxt = "mBatchDownloaderLoadArgsFromArgsTxt";
            mBatchDownloaderLoadArgsFromFile = "mBatchDownloaderLoadArgsFromFile";
            btnBatchDownloadRemoveSelected = "btnBatchDownloadRemoveSelected";
            sbBatchDownloaderIdle = "sbBatchDownloaderIdle";
            sbBatchDownloaderDownloading = "sbBatchDownloaderDownloading";
            sbBatchDownloaderFinished = "sbBatchDownloaderFinished";
            sbBatchDownloaderAborted = "sbBatchDownloaderAborted";

            // frmConverter
            frmConverter = "frmConverter";
            frmConverterComplete = "frmConverterComplete";
            frmConverterError = "frmConverterError";
            chkConverterCloseAfterConversion = "chkConverterCloseAfterConversion";
            btnConverterAbortBatchConversions = "btnConverterAbortBatchConversions";

            // frmDownloader
            frmDownloader = "frmDownloader";
            frmDownloaderComplete = "frmDownloaderComplete";
            frmDownloaderError = "frmDownloaderError";
            chkDownloaderCloseAfterDownload = "chkDownloaderCloseAfterDownload";
            btnDownloaderAbortBatch = "btnDownloaderAbortBatch";

            // frmDownloadLanuage
            frmDownloadLanguage = "frmDownloadLanguage";

            // frmException
            frmException = "frmException";
            lbExceptionHeader = "lbExceptionHeader";
            lbExceptionDescription = "lbExceptionDescription";
            rtbExceptionDetails = "rtbExceptionDetails";
            btnExceptionGithub = "btnExceptionGithub";

            // frmLanguage
            frmLanguage = "frmLanguage";
            btnLanguageRefresh = "btnLanguageRefresh";
            btnLanguageDownload = "btnLanguageDownload";

            // frmMain
            mSettings = "mSettings";
            mTools = "mTools";
            mBatchDownload = "mBatchDownload";
            mDownloadSubtitles = "mDownloadSubtitles";
            mMiscTools = "mMiscTools";
            mHelp = "mHelp";
            mLanguage = "mLanguage";
            mSupportedSites = "mSupportedSites";
            mAbout = "mAbout";

            tabDownload = "tabDownload";
            tabConvert = "tabConvert";
            tabMerge = "tabMerge";

            lbURL = "lbURL";
            txtUrlHint = "txtUrlHint";
            gbDownloadType = "gbDownloadType";
            lbQuality = "lbQuality";
            lbFormat = "lbFormat";
            chkDownloadSound = "chkDownloadSound";
            chkUseSelection = "chkUseSelection";
            rbVideoSelectionPlaylistIndex = "rbVideoSelectionPlaylistIndex";
            rbVideoSelectionPlaylistItems = "rbVideoSelectionPlaylistItems";
            rbVideoSelectionBeforeDate = "rbVideoSelectionBeforeDate";
            rbVideoSelectionOnDate = "rbVideoSelectionOnDate";
            rbVideoSelectionAfterDate = "rbVideoSelectionAfterDate";
            txtPlaylistStartHint = "txtPlaylistStartHint";
            txtPlaylistEndHint = "txtPlaylistEndHint";
            txtPlaylistItemsHint = "txtPlaylistItemsHint";
            txtVideoDateHint = "txtVideoDateHint";
            lbCustomArguments = "lbCustomArguments";
            txtArgsHint = "txtArgsHint";
            sbDownload = "sbDownload";
            mDownloadWithAuthentication = "mDownloadWithAuthentication";
            msgBatchDownloadFromFile = "msgBatchDownloadFromFile";
            mBatchDownloadFromFile = "mBatchDownloadFromFile";
            lbDownloadStatusStarted = "lbDownloadStatusStarted";
            lbDownloadStatusError = "lbDownloadStatusError";

            lbConvertInput = "lbConvertInput";
            lbConvertOutput = "lbConvertOutput";
            rbConvertAuto = "rbConvertAuto";
            rbConvertAutoFFmpeg = "rbConvertAutoFFmpeg";
            btnConvert = "btnConvert";
            lbConvertStarted = "lbConvertStarted";
            lbConvertFailed = "lbConvertFailed";

            lbMergeInput1 = "lbMergeInput1";
            lbMergeInput2 = "lbMergeInput2";
            lbMergeOutput = "lbMergeOutput";
            chkMergeAudioTracks = "chkMergeAudioTracks";
            chkMergeDeleteInputFiles = "chkMergeDeleteInputFiles";
            btnMerge = "btnMerge";

            cmTrayShowForm = "cmTrayShowForm";
            cmTrayDownloader = "cmTrayDownloader";
            cmTrayDownloadClipboard = "cmTrayDownloadClipboard";
            cmTrayDownloadBestVideo = "cmTrayDownloadBestVideo";
            cmTrayDownloadBestAudio = "cmTrayDownloadBestAudio";
            cmTrayDownloadCustom = "cmTrayDownloadCustom";
            cmTrayDownloadCustomTxtBox = "cmTrayDownloadCustomTxtBox";
            cmTrayDownloadCustomTxt = "cmTrayDownloadCustomTxt";
            cmTrayDownloadCustomSettings = "cmTrayDownloadCustomSettings";
            cmTrayConverter = "cmTrayConverter";
            cmTrayConvertTo = "cmTrayConvertTo";
            cmTrayConvertVideo = "cmTrayConvertVideo";
            cmTrayConvertAudio = "cmTrayConvertAudio";
            cmTrayConvertCustom = "cmTrayConvertCustom";
            cmTrayConvertAutomatic = "cmTrayConvertAutomatic";
            cmTrayConvertAutoFFmpeg = "cmTrayConvertAutoFFmpeg";
            cmTrayExit = "cmTrayExit";

            // frmSettings
            frmSettings = "frmSettings";
            btnSettingsRedownloadYoutubeDl = "btnSettingsRedownloadYoutubeDl";

            tabSettingsGeneral = "tabSettingsGeneral";
            tabSettingsDownloads = "tabSettingsDownloads";
            tabSettingsConverter = "tabSettingsConverter";
            tabSettingsExtensions = "tabSettingsExtensions";
            tabSettingsErrors = "tabSettingsErrors";
            tabSettingsPortable = "tabSettingsPortable";

            lbSettingsGeneralYoutubeDlPath = "lbSettingsGeneralYoutubeDlPath";
            chkSettingsGeneralUseStaticYoutubeDl = "chkSettingsGeneralUseStaticYoutubeDl";
            ofdTitleYoutubeDl = "ofdTitleYoutubeDl";
            ofdFilterYoutubeDl = "ofdFilterYoutubeDl";
            lbSettingsGeneralFFmpegDirectory = "lbSettingsGeneralFFmpegDirectory";
            chkSettingsGeneralUseStaticFFmpeg = "chkSettingsGeneralUseStaticFFmpeg";
            ofdTitleFFmpeg = "ofdTitleFFmpeg";
            ofdFilterFFmpeg = "ofdFilterFFmpeg";
            chkSettingsGeneralCheckForUpdatesOnLaunch = "chkSettingsGeneralCheckForUpdatesOnLaunch";
            chkSettingsGeneralCheckForBetaUpdates = "chkSettingsGeneralCheckForBetaUpdates";
            chkSettingsGeneralDeleteUpdaterAfterUpdating = "chkSettingsGeneralDeleteUpdaterAfterUpdating";
            chkDeleteOldVersionAfterUpdating = "chkDeleteOldVersionAfterUpdating";
            chkSettingsGeneralHoverOverUrlToPasteClipboard = "chkSettingsGeneralHoverOverUrlToPasteClipboard";
            chkSettingsGeneralClearUrlOnDownload = "chkSettingsGeneralClearUrlOnDownload";
            chkSettingsGeneralClearClipboardOnDownload = "chkSettingsGeneralClearClipboardOnDownload";
            gbSettingsGeneralCustomArguments = "gbSettingsGeneralCustomArguments";
            rbSettingsGeneralCustomArgumentsDontSave = "rbSettingsGeneralCustomArgumentsDontSave";
            rbSettingsGeneralCustomArgumentsSaveAsArgsText = "rbSettingsGeneralCustomArgumentsSaveAsArgsText";
            rbSettingsGeneralCustomArgumentsSaveInSettings = "rbSettingsGeneralCustomArgumentsSaveInSettings";

            lbSettingsDownloadsDownloadPath = "lbSettingsDownloadsDownloadPath";
            lbSettingsDownloadsFileNameSchema = "lbSettingsDownloadsFileNameSchema";
            tabDownloadsGeneral = "tabDownloadsGeneral";
            tabDownloadsSorting = "tabDownloadsSorting";
            tabDownloadsFixes = "tabdownloadsFixes";
            tabDownloadsConnection = "tabDownloadsConnection";
            tabDownloadsUpdating = "tabDownloadsUpdating";

            chkSettingsDownloadsSaveFormatQuality = "chkSettingsDownloadsSaveFormatQuality";
            chkSettingsDownloadsDownloadSubtitles = "chkSettingsDownloadsDownloadSubtitles";
            chkSettingsDownloadsEmbedSubtitles = "chkSettingsDownloadsEmbedSubtitles";
            chkSettingsDownloadsSaveVideoInfo = "chkSettingsDownloadsSaveVideoInfo";
            chkSettingsDownloadsWriteMetadataToFile = "chkSettingsDownloadsWriteMetadataToFile";
            chkSettingsDownloadsSaveDescription = "chkSettingsDownloadsSaveDescription";
            chkSettingsDownloadsKeepOriginalFiles = "chkSettingsDownloadsKeepOriginalFiles";
            chkSettingsDownloadsSaveAnnotations = "chkSettingsDownloadsSaveAnnotations";
            chkSettingsDownloadsSaveThumbnails = "chkSettingsDownloadsSaveThumbnails";
            chkSettingsDownloadsEmbedThumbnails = "chkSettingsDownloadsEmbedThumbnails";
            chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = "chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing";
            chkSettingsDownloadsSeparateDownloadsToDifferentFolders = "chkSettingsDownloadsSeparateDownloadsToDifferentFolders";
            chkSettingsDownloadsSeparateIntoWebsiteUrl = "chkSettingsDownloadsSeparateIntoWebsiteUrl";
            chkSettingsDownloadsFixVReddIt = "chkSettingsDownloadsFixVReddIt";
            chkSettingsDownloadsPreferFFmpeg = "chkSettingsDownloadsPreferFFmpeg";
            chkSettingsDownloadsLimitDownload = "chkSettingsDownloadsLimitDownload";
            lbSettingsDownloadsRetryAttempts = "lbSettingsDownloadsRetryAttempts";
            chkSettingsDownloadsForceIpv4 = "chkSettingsDownloadsForceIpv4";
            chkSettingsDownloadsForceIpv6 = "chkSettingsDownloadsForceIpv6";
            chkSettingsDownloadsUseProxy = "chkSettingsDownloadsUseProxy";
            chkSettingsDownloadsUseYoutubeDlsUpdater = "chksettingsDownloadsUseYoutubeDlsUpdater";
            lbSettingsDownloadsUpdatingYtdlType = "lbSettingsDownloadsUpdatingYtdlType";
            llbSettingsDownloadsYtdlTypeViewRepo = "llbSettingsDownloadsYtdlTypeViewRepo";
            chkSettingsDownloadsSeparateBatchDownloads = "chkSettingsDownloadsSeparateBatchDownloads";
            chkSettingsDownloadsAddDateToBatchDownloadFolders = "chkSettingsDownloadsAddDateToBatchDownloadFolders";

            chkSettingsConverterClearOutputAfterConverting = "chkSettingsConverterClearOutputAfterConverting";
            chkSettingsConverterDetectOutputFileType = "chkSettingsConverterDetectOutputFileType";
            chkSettingsConverterClearInputAfterConverting = "chkSettingsConverterClearInputAfterConverting";
            chkSettingsConverterHideFFmpegCompileInfo = "chkSettingsConverterHideFFmpegCompileInfo";
            tcSettingsConverterVideo = "tcSettingsConverterVideo";
            tcSettingsConverterAudio = "tcSettingsConverterAudio";
            tcSettingsConverterCustom = "tcSettingsConverterCustom";
            lbSettingsConverterVideoBitrate = "lbSettingsConverterVideoBitrate";
            lbSettingsConverterVideoPreset = "lbSettingsConverterVideoPreset";
            lbSettingsConverterVideoProfile = "lbSettingsConverterVideoProfile";
            lbSettingsConverterVideoCRF = "lbSettingsConverterVideoCRF";
            chkSettingsConverterVideoFastStart = "chkSettingsConverterVideoFastStart";
            lbSettingsConverterAudioBitrate = "lbSettingsConverterAudioBitrate";
            lbSettingsConverterCustomHeader = "lbSettingsConverterCustomHeader";

            lbSettingsExtensionsHeader = "lbSettingsExtensionsHeader";
            lbSettingsExtensionsExtensionFullName = "lbSettingsExtensionsExtensionFullName";
            txtSettingsExtensionsExtensionFullName = "txtSettingsExtensionsExtensionFullName";
            lbSettingsExtensionsExtensionShort = "lbSettingsExtensionsExtensionShort";
            txtSettingsExtensionsExtensionShort = "txtSettingsExtensionsExtensionShort";
            btnSettingsExtensionsAdd = "btnSettingsExtensionsAdd";
            lbSettingsExtensionsFileName = "lbSettingsExtensionsFileName";
            btnSettingsExtensionsRemoveSelected = "btnSettingsExtensionsRemoveSelected";

            chkSettingsErrorsShowDetailedErrors = "chkSettingsErrorsShowDetailedErrors";
            chkSettingsErrorsSaveErrorsAsErrorLog = "chkSettingsErrorsSaveErrorsAsErrorLog";
            chkSettingsErrorsSuppressErrors = "chkSettingsErrorsSuppressErrors";

            lbSettingsPortableInformation = "lbPortableInformation";
            chkSettingsPortableToggleIni = "chkPortableToggleIni";

            // frmSettings tipSettings
            btnSettingsRedownloadYoutubeDlHint = "btnSettingsRedownloadYoutubeDlHint";
            btnSettingsCancelHint = "btnSettingsCancelHint";
            btnSettingsSaveHint = "btnSettingsSaveHint";

            lbSettingsGeneralYoutubeDlPathHint = "lbSettingsGeneralYoutubeDlPathHint";
            chkSettingsGeneralUseStaticYoutubeDlHint = "chkSettingsGeneralUseStaticYoutubeDlHint";
            txtSettingsGeneralYoutubeDlPathHint = "txtSettingsGeneralYoutubeDlPathHint";
            btnSettingsGeneralBrowseYoutubeDlHint = "btnSettingsGeneralBrowseYoutubeDlHint";
            lbSettingsGeneralFFmpegDirectoryHint = "lbSettingsGeneralFFmpegDirectoryHint";
            chkSettingsGeneralUseStaticFFmpegHint = "chkSettingsGeneralUseStaticFFmpegHint";
            txtSettingsGeneralFFmpegPathHint = "txtSettingsGeneralFFmpegPathHint";
            btnSettingsGeneralBrowseFFmpegHint = "btnSettingsGeneralBrowseFFmpegHint";
            chkSettingsGeneralCheckForUpdatesOnLaunchHint = "chkSettingsGeneralCheckForUpdatesOnLaunchHint";
            chkSettingsGeneralCheckForBetaUpdatesHint = "chkSettingsGeneralCheckForBetaUpdatesHint";
            chkSettingsGeneralDeleteUpdaterAfterUpdatingHint = "chkSettingsGeneralDeleteUpdaterAfterUpdatingHint";
            chkDeleteOldVersionAfterUpdatingHint = "chkDeleteOldVersionAfterUpdatingHint";
            chkSettingsGeneralHoverOverUrlToPasteClipboardHint = "chkSettingsGeneralHoverOverUrlToPasteClipboardHint";
            chkSettingsGeneralClearUrlOnDownloadHint = "chkSettingsGeneralClearUrlOnDownloadHint";
            chkSettingsGeneralClearClipboardOnDownloadHint = "chkSettingsGeneralClearClipboardOnDownloadHint";
            gbSettingsGeneralCustomArgumentsHint = "gbSettingsGeneralCustomArgumentsHint";
            rbSettingsGeneralCustomArgumentsDontSaveHint = "rbSettingsGeneralCustomArgumentsDontSaveHint";
            rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = "rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint";
            rbSettingsGeneralCustomArgumentsSaveInSettingsHint = "rbSettingsGeneralCustomArgumentsSaveInSettingsHint";

            lbSettingsDownloadsDownloadPathHint = "lbSettingsDownloadsDownloadPathHint";
            chkSettingsDownloadsDownloadPathUseRelativePathHint = "chkSettingsDownloadsDownloadPathUseRelativePathHint";
            txtSettingsDownloadsSavePathHint = "txtSettingsDownloadsSavePathHint";
            btnSettingsDownloadsBrowseSavePathHint = "btnSettingsDownloadsBrowseSavePathHint";
            llSettingsDownloadsSchemaHelpHint = "llSettingsDownloadsSchemaHelpHint";
            lbSettingsDownloadsFileNameSchemaHint = "lbSettingsDownloadsFileNameSchemaHint";
            txtSettingsDownloadsFileNameSchemaHint = "txtSettingsDownloadsFileNameSchemaHint";

            chkSettingsDownloadsSaveFormatQualityHint = "chkSettingsDownloadsSaveFormatQualityHint";
            chkSettingsDownloadsDownloadSubtitlesHint = "chkSettingsDownloadsDownloadSubtitlesHint";
            chkSettingsDownloadsEmbedSubtitlesHint = "chkSettingsDownloadsEmbedSubtitlesHint";
            chkSettingsDownloadsSaveVideoInfoHint = "chkSettingsDownloadsSaveVideoInfoHint";
            chkSettingsDownloadsWriteMetadataToFileHint = "chkSettingsDownloadsWriteMetadataToFileHint";
            chkSettingsDownloadsSaveDescriptionHint = "chkSettingsDownloadsSaveDescriptionHint";
            chkSettingsDownloadsKeepOriginalFilesHint = "chkSettingsDownloadsKeepOriginalFilesHint";
            chkSettingsDownloadsSaveAnnotationsHint = "chkSettingsDownloadsSaveAnnotationsHint";
            chkSettingsDownloadsSaveThumbnailsHint = "chkSettingsDownloadsSaveThumbnailsHint";
            chkSettingsDownloadsEmbedThumbnailsHint = "chkSettingsDownloadsEmbedThumbnailsHint";
            chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = "chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint";
            chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint = "chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint";
            chkSettingsDownloadsSeparateIntoWebsiteUrlHint = "chkSettingsDownloadsSeparateIntoWebsiteUrlHint";
            chkSettingsDownloadsFixVReddItHint = "chkSettingsDownloadsFixVReddItHint";
            chkSettingsDownloadsPreferFFmpegHint = "chkSettingsDownloadsPreferFFmpeg";
            chkSettingsDownloadsLimitDownloadHint = "chkSettingsDownloadsLimitDownloadHint";
            numSettingsDownloadsLimitDownloadHint = "numSettingsDownloadsLimitDownloadHint";
            cbSettingsDownloadsLimitDownloadHint = "cbSettingsDownloadsLimitDownloadHint";
            lbSettingsDownloadsRetryAttemptsHint = "lbSettingsDownloadsRetryAttemptsHint";
            numSettingsDownloadsRetryAttemptsHint = "numSettingsDownloadsRetryAttemptsHint";
            chkSettingsDownloadsForceIpv4Hint = "chkSettingsDownloadsForceIpv4Hint";
            chkSettingsDownloadsForceIpv6Hint = "chkSettingsDownloadsForceIpv6Hint";
            chkSettingsDownloadsUseProxyHint = "chkSettingsDownloadsUseProxyHint";
            cbSettingsDownloadsProxyTypeHint = "cbSettingsDownloadsProxyTypeHint";
            txtSettingsDownloadsProxyIpHint = "txtSettingsDownloadsProxyIpHint";
            txtSettingsDownloadsProxyPortHint = "txtSettingsDownloadsProxyPortHint";
            chksettingsDownloadsUseYoutubeDlsUpdaterHint = "chksettingsDownloadsUseYoutubeDlsUpdaterHint";
            cbSettingsDownloadsUpdatingYtdlTypeHint = "cbSettingsDownloadsUpdatingYtdlTypeHint";
            llbSettingsDownloadsYtdlTypeViewRepoHint = "llbSettingsDownloadsYtdlTypeViewRepoHint";
            chkSettingsDownloadsSeparateBatchDownloadsHint = "chkSettingsDownloadsSeparateBatchDownloadsHint";
            chkSettingsDownloadsAddDateToBatchDownloadFoldersHint = "chkSettingsDownloadsAddDateToBatchDownloadFoldersHint";

            chkSettingsConverterClearOutputAfterConvertingHint = "chkSettingsConverterClearOutputAfterConvertingHint";
            chkSettingsConverterDetectOutputFileTypeHint = "chkSettingsConverterDetectOutputFileTypeHint";
            chkSettingsConverterClearInputAfterConvertingHint = "chkSettingsConverterClearInputAfterConvertingHint";
            chkSettingsConverterHideFFmpegCompileInfoHint = "chkSettingsConverterHideFFmpegCompileInfoHint";
            lbSettingsConverterVideoBitrateHint = "lbSettingsConverterVideoBitrateHint";
            lbSettingsConverterVideoPresetHint = "lbSettingsConverterVideoPresetHint";
            lbSettingsConverterVideoProfileHint = "lbSettingsConverterVideoProfileHint";
            lbSettingsConverterVideoCRFHint = "lbSettingsConverterVideoCRFHint";
            chkSettingsConverterVideoFastStartHint = "chkSettingsConverterVideoFastStartHint";
            lbSettingsConverterAudioBitrateHint = "lbSettingsConverterAudioBitrateHint";
            txtSettingsConverterCustomArgumentsHint = "txtSettingsConverterCustomArgumentsHint";

            chkSettingsErrorsShowDetailedErrorsHint = "chkSettingsErrorsShowDetailedErrorsHint";
            chkSettingsErrorsSaveErrorsAsErrorLogHint = "chkSettingsErrorsSaveErrorsAsErrorLogHint";
            chkSettingsErrorsSuppressErrorsHint = "chkSettingsErrorsSuppressErrorsHint";


            // frmSubtitles
            frmSubtitles = "frmSubtitles";
            lbSubtitlesHeader = "lbSubtitlesHeader";
            lbSubtitlesUrl = "lbSubtitlesUrl";
            lbSubtitlesLanguages = "lbSubtitlesLanguages";
            btnSubtitlesAddLanguage = "btnSubtitlesAddLanguage";
            btnSubtitlesClearLanguages = "btnSubtitlesClearLanguages";
            btnSubtitlesDownload = "btnSubtitlesDownload";

            // frmTools
            frmTools = "frmTools";
            btnMiscToolsRemoveAudio = "btnMiscToolsRemoveAudio";
            btnMiscToolsExtractAudio = "btnMiscToolsExtractAudio";
            btnMiscToolsVideoToGif = "btnMiscToolsVideoToGif";

            // frmUpdateAvailable
            frmUpdateAvailable = "frmUpdateAvailable";
            lbUpdateAvailableHeader = "lbUpdateAvailableHeader";
            lbUpdateAvailableUpdateVersion = "lbUpdateAvailableUpdateVersion";
            lbUpdateAvailableCurrentVersion = "lbUpdateAvailableCurrentVersion";
            lbUpdateAvailableChangelog = "lbUpdateAvailableChangelog";
            btnUpdateAvailableSkipVersion = "btnUpdateAvailableSkipVersion";
            btnUpdateAvailableUpdate = "btnUpdateAvailableUpdate";
        }
        #endregion

        #region Load Language File
        /// <summary>
        /// Loads the ini file for the Language file, based on the ini structure.
        /// </summary>
        /// <param name="LanguageFile">The string of the location of the language file.</param>
        /// <returns>Returns a boolean based on success.</returns>
        public bool LoadLanguage(string LanguageFile = null) {
            try {
                if (string.IsNullOrWhiteSpace(LanguageFile)) {
                    if (Properties.Settings.Default.SkipInternalEnglish) {
                        ResetControlNames();
                    }
                    else {
                        LoadInternalEnglish();
                    }
                    UsingInternalEnglish = true;
                    return true;
                }
                else {
                    ResetControlNames(); // Load the control IDs for any untranslated & undocumented strings

                    if (!LanguageFile.EndsWith(".ini")) { LanguageFile += ".ini"; }

                    if (File.Exists(LanguageFile)) {
                        using StreamReader ReadLanguageFile = new(LanguageFile);
                        string ReadLine;    // The line of the file
                        while ((ReadLine = ReadLanguageFile.ReadLine()) != null) {
                            if (ReadLine.StartsWith("//") || string.IsNullOrWhiteSpace(ReadLine))
                                continue;
                            else if (ReadLine.StartsWith("[") && ReadLine.Contains("]")) {
                                ReadHeaderValue(ReadLine, out string ReadHeader);

                                if (ReadHeader == null) {
                                    throw new Exception("Unable to read the language ini header\nReadValue returned null.\nProblematic line is \"" + ReadLine + "\"\n\n");
                                }
                                else
                                    CurrentLanguageLong = ReadHeader;
                            }
                            else if (ReadLine.Contains("=")) {
                                GetControlInfo(ReadLine, out string ReadControl, out string ReadValue);

                                switch (ReadControl) {

                                    #region Language File
                                    case "currentlanguageshort":
                                        CurrentLanguageShort = ReadValue;
                                        continue;
                                    case "currentlanguagehint":
                                        CurrentLanguageHint = ReadValue;
                                        continue;
                                    case "currentlanguageversion":
                                        CurrentLanguageVersion = ReadValue;
                                        continue;
                                    #endregion

                                    #region Generics
                                    case "genericinputbest":
                                        GenericInputBest = ReadValue;
                                        continue;
                                    case "genericinputworst":
                                        GenericInputWorst = ReadValue;
                                        continue;
                                    case "genericcancel":
                                        GenericCancel = ReadValue;
                                        continue;
                                    case "genericskip":
                                        GenericSkip = ReadValue;
                                        continue;
                                    case "genericsound":
                                        GenericSound = ReadValue;
                                        continue;
                                    case "genericvideo":
                                        GenericVideo = ReadValue;
                                        continue;
                                    case "genericaudio":
                                        GenericAudio = ReadValue;
                                        continue;
                                    case "genericcustom":
                                        GenericCustom = ReadValue;
                                        continue;
                                    case "genericretry":
                                        GenericRetry = ReadValue;
                                        continue;
                                    case "genericstart":
                                        GenericStart = ReadValue;
                                        continue;
                                    case "genericstop":
                                        GenericStop = ReadValue;
                                        continue;
                                    case "genericexit":
                                        GenericExit = ReadValue;
                                        continue;
                                    case "genericok":
                                        GenericOk = ReadValue;
                                        continue;
                                    case "genericsave":
                                        GenericSave = ReadValue;
                                        continue;
                                    #endregion

                                    #region Dialogs
                                    case "dlgfirsttimeinitialmessage":
                                        dlgFirstTimeInitialMessage = ReadValue;
                                        continue;
                                    case "dlgfirsttimedownloadfolder":
                                        dlgFirstTimeDownloadFolder = ReadValue;
                                        continue;
                                    case "dlgfinddownloadfolder":
                                        dlgFindDownloadFolder = ReadValue;
                                        continue;
                                    case "dlgmainargstxtdoesntexist":
                                        dlgMainArgsTxtDoesntExist = ReadValue;
                                        continue;
                                    case "dlgmainargstxtisempty":
                                        dlgMainArgsTxtIsEmpty = ReadValue;
                                        continue;
                                    case "dlgmainargsnonesaved":
                                        dlgMainArgsNoneSaved = ReadValue;
                                        continue;
                                    case "dlgconvertselectfiletoconvert":
                                        dlgConvertSelectFileToConvert = ReadValue;
                                        continue;
                                    case "dlgmergeselectfiletomerge":
                                        dlgMergeSelectFileToMerge = ReadValue;
                                        continue;
                                    case "dlgsaveoutputfileas":
                                        dlgSaveOutputFileAs = ReadValue;
                                        continue;
                                    case "dlglanguagehashnomatch":
                                        dlgLanguageHashNoMatch = ReadValue;
                                        continue;
                                    case "dlgupdatefailedtocheck":
                                        dlgUpdateFailedToCheck = ReadValue;
                                        continue;
                                    case "dlgupdatenoupdateavailable":
                                        dlgUpdateNoUpdateAvailable = ReadValue;
                                        continue;
                                    case "dlgupdatenobetaupdateavailable":
                                        dlgUpdateNoBetaUpdateAvailable = ReadValue;
                                        continue;
                                    case "dlgupdatenovalidyoutubedl":
                                        dlgUpdateNoValidYoutubeDl = ReadValue;
                                        continue;
                                    case "dlgupdatedyoutubedl":
                                        dlgUpdatedYoutubeDl = ReadValue;
                                        continue;
                                    case "dlgupateyoutubedlnoupdaterequired":
                                        dlgUpateYoutubeDlNoUpdateRequired = ReadValue;
                                        continue;
                                    case "dlgupdaterhashnomatch":
                                        dlgUpdaterHashNoMatch = ReadValue;
                                        continue;
                                    #endregion

                                    #region frmAbout
                                    case "frmabout":
                                        frmAbout = ReadValue;
                                        continue;
                                    case "lbaboutbody":
                                        lbAboutBody = ReadValue;
                                        continue;
                                    case "llbcheckforupdates":
                                        llbCheckForUpdates = ReadValue;
                                        continue;
                                    #endregion

                                    #region frmAuthentication
                                    case "frmauthentication":
                                        frmAuthentication = ReadValue;
                                        continue;
                                    case "lbauthnotice":
                                        lbAuthNotice = ReadValue;
                                        continue;
                                    case "lbauthusername":
                                        lbAuthUsername = ReadValue;
                                        continue;
                                    case "lbauthpassword":
                                        lbAuthPassword = ReadValue;
                                        continue;
                                    case "lbauth2factor":
                                        lbAuth2Factor = ReadValue;
                                        continue;
                                    case "lbauthvideopassword":
                                        lbAuthVideoPassword = ReadValue;
                                        continue;
                                    case "chkauthusenetrc":
                                        chkAuthUseNetrc = ReadValue;
                                        continue;
                                    case "lbauthnosave":
                                        lbAuthNoSave = ReadValue;
                                        continue;
                                    case "btnauthbegindownload":
                                        btnAuthBeginDownload = ReadValue;
                                        continue;
                                    #endregion

                                    #region frmBatchDownloader
                                    // frmBatchDownloader
                                    case "frmbatchdownload":
                                        frmBatchDownload = ReadValue;
                                        continue;
                                    case "lbbatchdownloadlink":
                                        lbBatchDownloadLink = ReadValue;
                                        continue;
                                    case "lbbatchdownloadtype":
                                        lbBatchDownloadType = ReadValue;
                                        continue;
                                    case "lbbatchdownloadvideospecificargument":
                                        lbBatchDownloadVideoSpecificArgument = ReadValue;
                                        continue;
                                    case "btnbatchdownloadadd":
                                        btnBatchDownloadAdd = ReadValue;
                                        continue;
                                    case "sbbatchdownloadloadargs":
                                        sbBatchDownloadLoadArgs = ReadValue;
                                        continue;
                                    case "mbatchdownloaderloadargsfromsettings":
                                        mBatchDownloaderLoadArgsFromSettings = ReadValue;
                                        continue;
                                    case "mbatchdownloaderloadargsfromargstxt":
                                        mBatchDownloaderLoadArgsFromArgsTxt = ReadValue;
                                        continue;
                                    case "mbatchdownloaderloadargsfromfile":
                                        mBatchDownloaderLoadArgsFromFile = ReadValue;
                                        continue;
                                    case "btnbatchdownloadremoveselected":
                                        btnBatchDownloadRemoveSelected = ReadValue;
                                        continue;
                                    case "sbbatchdownloaderidle":
                                        sbBatchDownloaderIdle = ReadValue;
                                        continue;
                                    case "sbbatchdownloaderdownloading":
                                        sbBatchDownloaderDownloading = ReadValue;
                                        continue;
                                    case "sbbatchdownloaderfinished":
                                        sbBatchDownloaderFinished = ReadValue;
                                        continue;
                                    case "sbbatchdownloaderaborted":
                                        sbBatchDownloaderAborted = ReadValue;
                                        continue;
                                    #endregion

                                    #region frmConverter
                                    case "frmconverter":
                                        frmConverter = ReadValue;
                                        continue;
                                    case "frmconvertercomplete":
                                        frmConverterComplete = ReadValue;
                                        continue;
                                    case "frmconvertererror":
                                        frmConverterError = ReadValue;
                                        continue;
                                    case "chkconvertercloseafterconversion":
                                        chkConverterCloseAfterConversion = ReadValue;
                                        continue;
                                    case "btnconverterabortbatchconversions":
                                        btnConverterAbortBatchConversions = ReadValue;
                                        continue;
                                    #endregion

                                    #region frmDownloader
                                    case "frmdownloader":
                                        frmDownloader = ReadValue;
                                        continue;
                                    case "frmdownloadercomplete":
                                        frmDownloaderComplete = ReadValue;
                                        continue;
                                    case "frmdownloadererror":
                                        frmDownloaderError = ReadValue;
                                        continue;
                                    case "chkdownloadercloseafterdownload":
                                        chkDownloaderCloseAfterDownload = ReadValue;
                                        continue;
                                    case "btndownloaderabortbatch":
                                        btnDownloaderAbortBatch = ReadValue;
                                        continue;
                                    #endregion

                                    #region frmDownloadLanguage
                                    case "frmdownloadlanguage":
                                        frmDownloadLanguage = ReadValue;
                                        continue;
                                    #endregion

                                    #region frmException
                                    case "frmexception":
                                        frmException = ReadValue;
                                        continue;
                                    case "lbexceptionheader":
                                        lbExceptionHeader = ReadValue;
                                        continue;
                                    case "lbexceptiondescription":
                                        lbExceptionDescription = ReadValue;
                                        continue;
                                    case "rtbexceptiondetails":
                                        rtbExceptionDetails = ReadValue;
                                        continue;
                                    case "btnexceptiongithub":
                                        btnExceptionGithub = ReadValue;
                                        continue;
                                    #endregion

                                    #region frmLanguage
                                    case "frmlanguage":
                                        frmLanguage = ReadValue;
                                        continue;
                                    case "btnlanguagerefresh":
                                        btnLanguageRefresh = ReadValue;
                                        continue;
                                    case "btnlanguagedownload":
                                        btnLanguageDownload = ReadValue;
                                        continue;
                                    #endregion

                                    #region frmMain
                                    // frmMain / menu
                                    case "msettings":
                                        mSettings = ReadValue;
                                        continue;
                                    case "mtools":
                                        mTools = ReadValue;
                                        continue;
                                    case "mbatchdownload":
                                        mBatchDownload = ReadValue;
                                        continue;
                                    case "mdownloadsubtitles":
                                        mDownloadSubtitles = ReadValue;
                                        continue;
                                    case "mmisctools":
                                        mMiscTools = ReadValue;
                                        continue;
                                    case "mhelp":
                                        mHelp = ReadValue;
                                        continue;
                                    case "mlanguage":
                                        mLanguage = ReadValue;
                                        continue;
                                    case "msupportedsites":
                                        mSupportedSites = ReadValue;
                                        continue;
                                    case "mabout":
                                        mAbout = ReadValue;
                                        continue;

                                    // frmMain / tcMain
                                    case "tabdownload":
                                        tabDownload = ReadValue;
                                        continue;
                                    case "tabconvert":
                                        tabConvert = ReadValue;
                                        continue;
                                    case "tabmerge":
                                        tabMerge = ReadValue;
                                        continue;

                                    // frmMain / tcMain / Download
                                    case "lburl":
                                        lbURL = ReadValue;
                                        continue;
                                    case "txturlhint":
                                        txtUrlHint = ReadValue;
                                        continue;
                                    case "gbdownloadtype":
                                        gbDownloadType = ReadValue;
                                        continue;
                                    case "lbquality":
                                        lbQuality = ReadValue;
                                        continue;
                                    case "lbformat":
                                        lbFormat = ReadValue;
                                        continue;
                                    case "chkdownloadsound":
                                        chkDownloadSound = ReadValue;
                                        continue;
                                    case "chkuseselection":
                                        chkUseSelection = ReadValue;
                                        continue;
                                    case "rbvideoselectionplaylistindex":
                                        rbVideoSelectionPlaylistIndex = ReadValue;
                                        continue;
                                    case "rbvideoselectionplaylistitems":
                                        rbVideoSelectionPlaylistItems = ReadValue;
                                        continue;
                                    case "rbvideoselectionbeforedate":
                                        rbVideoSelectionBeforeDate = ReadValue;
                                        continue;
                                    case "rbvideoselectionondate":
                                        rbVideoSelectionOnDate = ReadValue;
                                        continue;
                                    case "rbvideoselectionafterdate":
                                        rbVideoSelectionAfterDate = ReadValue;
                                        continue;
                                    case "txtplayliststarthint":
                                        txtPlaylistStartHint = ReadValue;
                                        continue;
                                    case "txtplaylistendhint":
                                        txtPlaylistEndHint = ReadValue;
                                        continue;
                                    case "txtplaylistitemshint":
                                        lbDownloadStatusStarted = ReadValue;
                                        continue;
                                    case "txtvideodatehint":
                                        txtVideoDateHint = ReadValue;
                                        continue;
                                    case "lbcustomarguments":
                                        lbCustomArguments = ReadValue;
                                        continue;
                                    case "txtargshint":
                                        txtArgsHint = ReadValue;
                                        continue;
                                    case "sbdownload":
                                        sbDownload = ReadValue;
                                        continue;
                                    case "mdownloadwithauthentication":
                                        mDownloadWithAuthentication = ReadValue;
                                        continue;
                                    case "mbatchdownloadfromfile":
                                        mBatchDownloadFromFile = ReadValue;
                                        continue;
                                    case "msgbatchdownloadfromfile":
                                        msgBatchDownloadFromFile = ReadValue;
                                        continue;
                                    case "lbdownloadstatusstarted":
                                        lbDownloadStatusStarted = ReadValue;
                                        continue;
                                    case "lbdownloadstatuserror":
                                        lbDownloadStatusError = ReadValue;
                                        continue;

                                    // frmMain / tcMain / Convert
                                    case "lbconvertinput":
                                        lbConvertInput = ReadValue;
                                        continue;
                                    case "lbconvertoutput":
                                        lbConvertOutput = ReadValue;
                                        continue;
                                    case "rbconvertauto":
                                        rbConvertAuto = ReadValue;
                                        continue;
                                    case "rbconvertautoffmpeg":
                                        rbConvertAutoFFmpeg = ReadValue;
                                        continue;
                                    case "btnconvert":
                                        btnConvert = ReadValue;
                                        continue;
                                    case "lbconvertstarted":
                                        lbConvertStarted = ReadValue;
                                        continue;
                                    case "lbconvertfailed":
                                        lbConvertFailed = ReadValue;
                                        continue;

                                    // frmMain / tcMain / Merge
                                    case "lbmergeinput1":
                                        lbMergeInput1 = ReadValue;
                                        continue;
                                    case "lbmergeinput2":
                                        lbMergeInput2 = ReadValue;
                                        continue;
                                    case "lbmergeoutput":
                                        lbMergeOutput = ReadValue;
                                        continue;
                                    case "chkmergeaudiotracks":
                                        chkMergeAudioTracks = ReadValue;
                                        continue;
                                    case "chkmergedeleteinputfiles":
                                        chkMergeDeleteInputFiles = ReadValue;
                                        continue;
                                    case "btnmerge":
                                        btnMerge = ReadValue;
                                        continue;

                                    // frmMain / tcMain / cmTray
                                    case "cmTrayShowForm":
                                        cmTrayShowForm = ReadValue;
                                        continue;
                                    case "cmtraydownloader":
                                        cmTrayDownloader = ReadValue;
                                        continue;
                                    case "cmtraydownloadclipboard":
                                        cmTrayDownloadClipboard = ReadValue;
                                        continue;
                                    case "cmtraydownloadbestvideo":
                                        cmTrayDownloadBestVideo = ReadValue;
                                        continue;
                                    case "cmtraydownloadbestaudio":
                                        cmTrayDownloadBestAudio = ReadValue;
                                        continue;
                                    case "cmtraydownloadcustom":
                                        cmTrayDownloadCustom = ReadValue;
                                        continue;
                                    case "cmtraydownloadcustomtxtbox":
                                        cmTrayDownloadCustomTxtBox = ReadValue;
                                        continue;
                                    case "cmtraydownloadcustomtxt":
                                        cmTrayDownloadCustomTxt = ReadValue;
                                        continue;
                                    case "cmtraydownloadcustomsettings":
                                        cmTrayDownloadCustomSettings = ReadValue;
                                        continue;
                                    case "cmtrayconverter":
                                        cmTrayConverter = ReadValue;
                                        continue;
                                    case "cmtrayconvertto":
                                        cmTrayConvertTo = ReadValue;
                                        continue;
                                    case "cmtrayconvertvideo":
                                        cmTrayConvertVideo = ReadValue;
                                        continue;
                                    case "cmtrayconvertaudio":
                                        cmTrayConvertAudio = ReadValue;
                                        continue;
                                    case "cmtrayconvertcustom":
                                        cmTrayConvertCustom = ReadValue;
                                        continue;
                                    case "cmtrayconvertautomatic":
                                        cmTrayConvertAutomatic = ReadValue;
                                        continue;
                                    case "cmtrayconvertautoffmpeg":
                                        cmTrayConvertAutoFFmpeg = ReadValue;
                                        continue;
                                    case "cmtrayexit":
                                        cmTrayExit = ReadValue;
                                        continue;
                                    #endregion

                                    #region frmSettings
                                    // frmSettings
                                    case "frmsettings":
                                        frmSettings = ReadValue;
                                        continue;
                                    case "btnsettingsredownloadyoutubedl":
                                        btnSettingsRedownloadYoutubeDl = ReadValue;
                                        continue;
                                    case "btnsettingsredownloadyoutubedlhint":
                                        btnSettingsRedownloadYoutubeDlHint = ReadValue;
                                        continue;
                                    case "btnsettingscancelhint":
                                        btnSettingsCancelHint = ReadValue;
                                        continue;
                                    case "btnsettingssavehint":
                                        btnSettingsSaveHint = ReadValue;
                                        continue;

                                    // frmSettings / tcMain
                                    case "tabsettingsgeneral":
                                        tabSettingsGeneral = ReadValue;
                                        continue;
                                    case "tabsettingsdownloads":
                                        tabSettingsDownloads = ReadValue;
                                        continue;
                                    case "tabsettingsconverter":
                                        tabSettingsConverter = ReadValue;
                                        continue;
                                    case "tabsettingsextensions":
                                        tabSettingsExtensions = ReadValue;
                                        continue;
                                    case "tabsettingserrors":
                                        tabSettingsErrors = ReadValue;
                                        continue;

                                    case "tabsettingsportable":
                                        tabSettingsPortable = ReadValue;
                                        continue;

                                    //frmSettings / tcMain / tabGeneral
                                    case "lbsettingsgeneralyoutubedlpath":
                                        lbSettingsGeneralYoutubeDlPath = ReadValue;
                                        continue;
                                    case "chksettingsgeneralusestaticyoutubedl":
                                        chkSettingsGeneralUseStaticYoutubeDl = ReadValue;
                                        continue;
                                    case "ofdtitleYoutubedl":
                                        ofdTitleYoutubeDl = ReadValue;
                                        continue;
                                    case "ofdfilteryoutubedl":
                                        ofdFilterYoutubeDl = ReadValue;
                                        continue;
                                    case "lbsettingsgeneralffmpegdirectory":
                                        lbSettingsGeneralFFmpegDirectory = ReadValue;
                                        continue;
                                    case "chksettingsgeneralusestaticffmpeg":
                                        chkSettingsGeneralUseStaticFFmpeg = ReadValue;
                                        continue;
                                    case "ofdtitleffmpeg":
                                        ofdTitleFFmpeg = ReadValue;
                                        continue;
                                    case "ofdfilterffmpeg":
                                        ofdFilterFFmpeg = ReadValue;
                                        continue;
                                    case "chksettingsgeneralcheckforupdatesonlaunch":
                                        chkSettingsGeneralCheckForUpdatesOnLaunch = ReadValue;
                                        continue;
                                    case "chksettingsgeneralcheckforbetaupdates":
                                        chkSettingsGeneralCheckForBetaUpdates = ReadValue;
                                        continue;
                                    case "chksettingsgeneraldeleteupdaterafterupdating":
                                        chkSettingsGeneralDeleteUpdaterAfterUpdating = ReadValue;
                                        continue;
                                    case "chkdeleteoldversionafterupdating":
                                        chkDeleteOldVersionAfterUpdating = ReadValue;
                                        continue;
                                    case "chksettingsgeneralhoveroverurltopasteclipboard":
                                        chkSettingsGeneralHoverOverUrlToPasteClipboard = ReadValue;
                                        continue;
                                    case "chksettingsgeneralclearurlondownload":
                                        chkSettingsGeneralClearUrlOnDownload = ReadValue;
                                        continue;
                                    case "chksettingsgeneralclearclipboardondownload":
                                        chkSettingsGeneralClearClipboardOnDownload = ReadValue;
                                        continue;
                                    case "gbsettingsgeneralcustomarguments":
                                        gbSettingsGeneralCustomArguments = ReadValue;
                                        continue;
                                    case "rbsettingsgeneralcustomargumentsdontsave":
                                        rbSettingsGeneralCustomArgumentsDontSave = ReadValue;
                                        continue;
                                    case "rbsettingsgeneralcustomargumentssaveasargstext":
                                        rbSettingsGeneralCustomArgumentsSaveAsArgsText = ReadValue;
                                        continue;
                                    case "rbsettingsgeneralcustomargumentssaveinsettings":
                                        rbSettingsGeneralCustomArgumentsSaveInSettings = ReadValue;
                                        continue;
                                    case "lbsettingsgeneralyoutubedlpathhint":
                                        lbSettingsGeneralYoutubeDlPathHint = ReadValue;
                                        continue;
                                    case "chksettingsgeneralusestaticyoutubedlhint":
                                        chkSettingsGeneralUseStaticYoutubeDlHint = ReadValue;
                                        continue;
                                    case "txtsettingsgeneralyoutubedlpathhint":
                                        txtSettingsGeneralYoutubeDlPathHint = ReadValue;
                                        continue;
                                    case "btnsettingsgeneralbrowseyoutubedlhint":
                                        btnSettingsGeneralBrowseYoutubeDlHint = ReadValue;
                                        continue;
                                    case "lbsettingsgeneralffmpegdirectoryhint":
                                        lbSettingsGeneralFFmpegDirectoryHint = ReadValue;
                                        continue;
                                    case "chksettingsgeneralusestaticffmpeghint":
                                        chkSettingsGeneralUseStaticFFmpegHint = ReadValue;
                                        continue;
                                    case "txtsettingsgeneralffmpegpathhint":
                                        txtSettingsGeneralFFmpegPathHint = ReadValue;
                                        continue;
                                    case "btnsettingsgeneralbrowseffmpeghint":
                                        btnSettingsGeneralBrowseFFmpegHint = ReadValue;
                                        continue;
                                    case "chksettingsgeneralcheckforupdatesonlaunchhint":
                                        chkSettingsGeneralCheckForUpdatesOnLaunchHint = ReadValue;
                                        continue;
                                    case "chksettingsgeneralcheckforbetaupdateshint":
                                        chkSettingsGeneralCheckForBetaUpdatesHint = ReadValue;
                                        continue;
                                    case "chksettingsgeneraldeleteupdaterafterupdatinghint":
                                        chkSettingsGeneralDeleteUpdaterAfterUpdatingHint = ReadValue;
                                        continue;
                                    case "chkdeleteoldversionafterupdatinghint":
                                        chkDeleteOldVersionAfterUpdatingHint = ReadValue;
                                        continue;
                                    case "chksettingsgeneralhoveroverurltopasteclipboardhint":
                                        chkSettingsGeneralHoverOverUrlToPasteClipboardHint = ReadValue;
                                        continue;
                                    case "chksettingsgeneralclearurlondownloadhint":
                                        chkSettingsGeneralClearUrlOnDownloadHint = ReadValue;
                                        continue;
                                    case "chksettingsgeneralclearclipboardondownloadhint":
                                        chkSettingsGeneralClearClipboardOnDownloadHint = ReadValue;
                                        continue;
                                    case "gbsettingsgeneralcustomargumentshint":
                                        gbSettingsGeneralCustomArgumentsHint = ReadValue;
                                        continue;
                                    case "rbsettingsgeneralcustomargumentsdontsavehint":
                                        rbSettingsGeneralCustomArgumentsDontSaveHint = ReadValue;
                                        continue;
                                    case "rbsettingsgeneralcustomargumentssaveasargstexthint":
                                        rbSettingsGeneralCustomArgumentsSaveAsArgsTextHint = ReadValue;
                                        continue;
                                    case "rbsettingsgeneralcustomargumentssaveinsettingshint":
                                        rbSettingsGeneralCustomArgumentsSaveInSettingsHint = ReadValue;
                                        continue;

                                    // frmSettings / tcMain / tabDownloads
                                    case "lbsettingsdownloadsdownloadpath":
                                        lbSettingsDownloadsDownloadPath = ReadValue;
                                        continue;
                                    case "lbsettingsdownloadsfilenameschema":
                                        lbSettingsDownloadsFileNameSchema = ReadValue;
                                        continue;
                                    case "tabdownloadsgeneral":
                                        tabDownloadsGeneral = ReadValue;
                                        continue;
                                    case "tabdownloadssorting":
                                        tabDownloadsSorting = ReadValue;
                                        continue;
                                    case "tabdownloadsfixes":
                                        tabDownloadsFixes = ReadValue;
                                        continue;
                                    case "tabdownloadsconnection":
                                        tabDownloadsConnection = ReadValue;
                                        continue;
                                    case "tabdownloadsupdating":
                                        tabDownloadsUpdating = ReadValue;
                                        continue;
                                    case "chksettingsdownloadssaveformatquality":
                                        chkSettingsDownloadsSaveFormatQuality = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsdownloadsubtitles":
                                        chkSettingsDownloadsDownloadSubtitles = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsembedsubtitles":
                                        chkSettingsDownloadsEmbedSubtitles = ReadValue;
                                        continue;
                                    case "chksettingsdownloadssavevideoinfo":
                                        chkSettingsDownloadsSaveVideoInfo = ReadValue;
                                        continue;
                                    case "chksettingsdownloadswritemetadatatofile":
                                        chkSettingsDownloadsWriteMetadataToFile = ReadValue;
                                        continue;
                                    case "chksettingsdownloadssavedescription":
                                        chkSettingsDownloadsSaveDescription = ReadValue;
                                        continue;
                                    case "chksettingsdownloadskeeporiginalfiles":
                                        chkSettingsDownloadsKeepOriginalFiles = ReadValue;
                                        continue;
                                    case "chksettingsdownloadssaveannotations":
                                        chkSettingsDownloadsSaveAnnotations = ReadValue;
                                        continue;
                                    case "chksettingsdownloadssavethumbnails":
                                        chkSettingsDownloadsSaveThumbnails = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsembedthumbnails":
                                        chkSettingsDownloadsEmbedThumbnails = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsautomaticallydeleteyoutubedlwhenclosing":
                                        chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosing = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsseparatedownloadstodifferentfolders":
                                        chkSettingsDownloadsSeparateDownloadsToDifferentFolders = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsseparateintowebsiteurl":
                                        chkSettingsDownloadsSeparateIntoWebsiteUrl = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsfixvreddit":
                                        chkSettingsDownloadsFixVReddIt = ReadValue;
                                        continue;
                                    case "chksettingsdownloadspreferffmpeg":
                                        chkSettingsDownloadsPreferFFmpeg = ReadValue;
                                        continue;
                                    case "chksettingsdownloadslimitdownload":
                                        chkSettingsDownloadsLimitDownload = ReadValue;
                                        continue;
                                    case "lbsettingsdownloadsretryattempts":
                                        lbSettingsDownloadsRetryAttempts = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsforceipv4":
                                        chkSettingsDownloadsForceIpv4 = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsforceipv6":
                                        chkSettingsDownloadsForceIpv6 = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsuseproxy":
                                        chkSettingsDownloadsUseProxy = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsuseyoutubedlsupdater":
                                        chkSettingsDownloadsUseYoutubeDlsUpdater = ReadValue;
                                        continue;
                                    case "lbsettingsdownloadsupdatingytdltype":
                                        lbSettingsDownloadsUpdatingYtdlType = ReadValue;
                                        continue;
                                    case "llbsettingsdownloadsytdltypeviewrepo":
                                        llbSettingsDownloadsYtdlTypeViewRepo = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsseparatebatchdownloads":
                                        chkSettingsDownloadsSeparateBatchDownloads = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsadddatetobatchdownloadfolders":
                                        chkSettingsDownloadsAddDateToBatchDownloadFolders = ReadValue;
                                        continue;
                                    case "lbsettingsdownloadsdownloadpathhint":
                                        lbSettingsDownloadsDownloadPathHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsdownloadpathuserelativepathhint":
                                        chkSettingsDownloadsDownloadPathUseRelativePathHint = ReadValue;
                                        continue;
                                    case "txtsettingsdownloadssavepathhint":
                                        txtSettingsDownloadsSavePathHint = ReadValue;
                                        continue;
                                    case "btnsettingsdownloadsbrowsesavepathhint":
                                        btnSettingsDownloadsBrowseSavePathHint = ReadValue;
                                        continue;
                                    case "llsettingsdownloadsschemahelphint":
                                        llSettingsDownloadsSchemaHelpHint = ReadValue;
                                        continue;
                                    case "lbsettingsdownloadsfilenameschemahint":
                                        lbSettingsDownloadsFileNameSchemaHint = ReadValue;
                                        continue;
                                    case "txtsettingsdownloadsfilenameschemahint":
                                        txtSettingsDownloadsFileNameSchemaHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadssaveformatqualityhint":
                                        chkSettingsDownloadsSaveFormatQualityHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsdownloadsubtitleshint":
                                        chkSettingsDownloadsDownloadSubtitlesHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsembedsubtitleshint":
                                        chkSettingsDownloadsEmbedSubtitlesHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadssavevideoinfohint":
                                        chkSettingsDownloadsSaveVideoInfoHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadswritemetadatatofilehint":
                                        chkSettingsDownloadsWriteMetadataToFileHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadssavedescriptionhint":
                                        chkSettingsDownloadsSaveDescriptionHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadskeeporiginalfileshint":
                                        chkSettingsDownloadsKeepOriginalFilesHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadssaveannotationshint":
                                        chkSettingsDownloadsSaveAnnotationsHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadssavethumbnailshint":
                                        chkSettingsDownloadsSaveThumbnailsHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsembedthumbnailshint":
                                        chkSettingsDownloadsEmbedThumbnailsHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsautomaticallydeleteyoutubedlwhenclosinghint":
                                        chkSettingsDownloadsAutomaticallyDeleteYoutubeDlWhenClosingHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsseparatedownloadstodifferentfoldershint":
                                        chkSettingsDownloadsSeparateDownloadsToDifferentFoldersHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsseparateintowebsiteurlhint":
                                        chkSettingsDownloadsSeparateIntoWebsiteUrlHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsfixvreddithint":
                                        chkSettingsDownloadsFixVReddItHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadspreferffmpeghint":
                                        chkSettingsDownloadsPreferFFmpegHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadslimitdownloadhint":
                                        chkSettingsDownloadsLimitDownloadHint = ReadValue;
                                        continue;
                                    case "numsettingsdownloadslimitdownloadhint":
                                        numSettingsDownloadsLimitDownloadHint = ReadValue;
                                        continue;
                                    case "cbsettingsdownloadslimitdownloadhint":
                                        cbSettingsDownloadsLimitDownloadHint = ReadValue;
                                        continue;
                                    case "lbsettingsdownloadsretryattemptshint":
                                        lbSettingsDownloadsRetryAttemptsHint = ReadValue;
                                        continue;
                                    case "numsettingsdownloadsretryattemptshint":
                                        numSettingsDownloadsRetryAttemptsHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsforceipv4hint":
                                        chkSettingsDownloadsForceIpv4Hint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsforceipv6hint":
                                        chkSettingsDownloadsForceIpv6Hint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsuseproxyhint":
                                        chkSettingsDownloadsUseProxyHint = ReadValue;
                                        continue;
                                    case "cbsettingsdownloadsproxytypehint":
                                        cbSettingsDownloadsProxyTypeHint = ReadValue;
                                        continue;
                                    case "txtsettingsdownloadsproxyiphint":
                                        txtSettingsDownloadsProxyIpHint = ReadValue;
                                        continue;
                                    case "txtsettingsdownloadsproxyporthint":
                                        txtSettingsDownloadsProxyPortHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsuseyoutubedlsupdaterhint":
                                        chksettingsDownloadsUseYoutubeDlsUpdaterHint = ReadValue;
                                        continue;
                                    case "cbsettingsdownloadsupdatingytdltypehint":
                                        cbSettingsDownloadsUpdatingYtdlTypeHint = ReadValue;
                                        continue;
                                    case "llbsettingsdownloadsytdltypeviewrepohint":
                                        llbSettingsDownloadsYtdlTypeViewRepoHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsseparatebatchdownloadshint":
                                        chkSettingsDownloadsSeparateBatchDownloadsHint = ReadValue;
                                        continue;
                                    case "chksettingsdownloadsadddatetobatchdownloadfoldershint":
                                        chkSettingsDownloadsAddDateToBatchDownloadFoldersHint = ReadValue;
                                        continue;

                                    // frmSettings / tcMain / tabConverter
                                    case "chksettingsconverterclearoutputafterconverting":
                                        chkSettingsConverterClearOutputAfterConverting = ReadValue;
                                        continue;
                                    case "chksettingsconverterdetectoutputfiletype":
                                        chkSettingsConverterDetectOutputFileType = ReadValue;
                                        continue;
                                    case "chksettingsconverterclearinputafterconverting":
                                        chkSettingsConverterClearInputAfterConverting = ReadValue;
                                        continue;
                                    case "chksettingsconverterhideffmpegcompileinfo":
                                        chkSettingsConverterHideFFmpegCompileInfo = ReadValue;
                                        continue;
                                    case "tcsettingsconvertervideo":
                                        tcSettingsConverterVideo = ReadValue;
                                        continue;
                                    case "tcsettingsconverteraudio":
                                        tcSettingsConverterAudio = ReadValue;
                                        continue;
                                    case "tcsettingsconvertercustom":
                                        tcSettingsConverterCustom = ReadValue;
                                        continue;
                                    case "lbsettingsconvertervideobitrate":
                                        lbSettingsConverterVideoBitrate = ReadValue;
                                        continue;
                                    case "lbsettingsconvertervideopreset":
                                        lbSettingsConverterVideoPreset = ReadValue;
                                        continue;
                                    case "lbsettingsconvertervideoprofile":
                                        lbSettingsConverterVideoProfile = ReadValue;
                                        continue;
                                    case "lbsettingsconvertervideocrf":
                                        lbSettingsConverterVideoCRF = ReadValue;
                                        continue;
                                    case "chksettingsconvertervideofaststart":
                                        chkSettingsConverterVideoFastStart = ReadValue;
                                        continue;
                                    case "lbsettingsconverteraudiobitrate":
                                        lbSettingsConverterAudioBitrate = ReadValue;
                                        continue;
                                    case "lbsettingsconvertercustomheader":
                                        lbSettingsConverterCustomHeader = ReadValue;
                                        continue;
                                    case "chksettingsconverterclearoutputafterconvertinghint":
                                        chkSettingsConverterClearOutputAfterConvertingHint = ReadValue;
                                        continue;
                                    case "chksettingsconverterdetectoutputfiletypehint":
                                        chkSettingsConverterDetectOutputFileTypeHint = ReadValue;
                                        continue;
                                    case "chksettingsconverterclearinputafterconvertinghint":
                                        chkSettingsConverterClearInputAfterConvertingHint = ReadValue;
                                        continue;
                                    case "chksettingsconverterhideffmpegcompileinfohint":
                                        chkSettingsConverterHideFFmpegCompileInfoHint = ReadValue;
                                        continue;
                                    case "lbsettingsconvertervideobitratehint":
                                        lbSettingsConverterVideoBitrateHint = ReadValue;
                                        continue;
                                    case "lbsettingsconvertervideopresethint":
                                        lbSettingsConverterVideoPresetHint = ReadValue;
                                        continue;
                                    case "lbsettingsconvertervideoprofilehint":
                                        lbSettingsConverterVideoProfileHint = ReadValue;
                                        continue;
                                    case "lbsettingsconvertervideocrfhint":
                                        lbSettingsConverterVideoCRFHint = ReadValue;
                                        continue;
                                    case "chksettingsconvertervideofaststarthint":
                                        chkSettingsConverterVideoFastStartHint = ReadValue;
                                        continue;
                                    case "lbsettingsconverteraudiobitratehint":
                                        lbSettingsConverterAudioBitrateHint = ReadValue;
                                        continue;
                                    case "txtsettingsconvertercustomargumentshint":
                                        txtSettingsConverterCustomArgumentsHint = ReadValue;
                                        continue;

                                    // frmSettings / tcMain / tabExtensions
                                    case "lbsettingsextensionsheader":
                                        lbSettingsExtensionsHeader = ReadValue;
                                        continue;
                                    case "lbsettingsextensionsextensionfullname":
                                        lbSettingsExtensionsExtensionFullName = ReadValue;
                                        continue;
                                    case "txtsettingsextensionsextensionfullname":
                                        txtSettingsExtensionsExtensionFullName = ReadValue;
                                        continue;
                                    case "lbsettingsextensionsextensionshort":
                                        lbSettingsExtensionsExtensionShort = ReadValue;
                                        continue;
                                    case "txtsettingsextensionsextensionshort":
                                        txtSettingsExtensionsExtensionShort = ReadValue;
                                        continue;
                                    case "btnsettingsextensionsadd":
                                        btnSettingsExtensionsAdd = ReadValue;
                                        continue;
                                    case "lbsettingsextensionsfilename":
                                        lbSettingsExtensionsFileName = ReadValue;
                                        continue;
                                    case "btnsettingsextensionsremoveselected":
                                        btnSettingsExtensionsRemoveSelected = ReadValue;
                                        continue;

                                    // frmSettings / tcMain / tabErrors
                                    case "chksettingserrorsshowdetailederrors":
                                        chkSettingsErrorsShowDetailedErrors = ReadValue;
                                        continue;
                                    case "chksettingserrorssaveerrorsaserrorlog":
                                        chkSettingsErrorsSaveErrorsAsErrorLog = ReadValue;
                                        continue;
                                    case "chksettingserrorssuppresserrors":
                                        chkSettingsErrorsSuppressErrors = ReadValue;
                                        continue;
                                    case "chksettingserrorsshowdetailederrorshint":
                                        chkSettingsErrorsShowDetailedErrorsHint = ReadValue;
                                        continue;
                                    case "chksettingserrorssaveerrorsaserrorloghint":
                                        chkSettingsErrorsSaveErrorsAsErrorLogHint = ReadValue;
                                        continue;
                                    case "chksettingserrorssuppresserrorshint":
                                        chkSettingsErrorsSuppressErrorsHint = ReadValue;
                                        continue;

                                    // frmSettings /tcMain /tabSettingsPortable
                                    case "lbsettingsportableinformation":
                                        lbSettingsPortableInformation = ReadValue;
                                        continue;

                                    case "chksettingsportabletoggleini":
                                        chkSettingsPortableToggleIni = ReadValue;
                                        continue;
                                    #endregion

                                    #region frmSubtitles
                                    case "frmsubtitles":
                                        frmSubtitles = ReadValue;
                                        continue;
                                    case "lbsubtitlesheader":
                                        lbSubtitlesHeader = ReadValue;
                                        continue;
                                    case "lbsubtitlesurl":
                                        lbSubtitlesUrl = ReadValue;
                                        continue;
                                    case "lbsubtitleslanguages":
                                        lbSubtitlesLanguages = ReadValue;
                                        continue;
                                    case "btnsubtitlesaddlanguage":
                                        btnSubtitlesAddLanguage = ReadValue;
                                        continue;
                                    case "btnsubtitlesclearlanguages":
                                        btnSubtitlesClearLanguages = ReadValue;
                                        continue;
                                    case "btnsubtitlesdownload":
                                        btnSubtitlesDownload = ReadValue;
                                        continue;
                                    #endregion

                                    #region frmTools
                                    case "frmtools":
                                        frmTools = ReadValue;
                                        continue;
                                    case "btnmisctoolsremoveaudio":
                                        btnMiscToolsRemoveAudio = ReadValue;
                                        continue;
                                    case "btnmisctoolsextractaudio":
                                        btnMiscToolsExtractAudio = ReadValue;
                                        continue;
                                    case "btnmisctoolsvideotogif":
                                        btnMiscToolsVideoToGif = ReadValue;
                                        continue;
                                    #endregion

                                    #region frmUpdateAvailable
                                    case "frmupdateavailable":
                                        frmUpdateAvailable = ReadValue;
                                        continue;
                                    case "lbupdateavailableheader":
                                        lbUpdateAvailableHeader = ReadValue;
                                        continue;
                                    case "lbupdateavailableupdateversion":
                                        lbUpdateAvailableUpdateVersion = ReadValue;
                                        continue;
                                    case "lbupdateavailablecurrentversion":
                                        lbUpdateAvailableCurrentVersion = ReadValue;
                                        continue;
                                    case "lbupdateavailablechangelog":
                                        lbUpdateAvailableChangelog = ReadValue;
                                        continue;
                                    case "btnupdateavailableskipversion":
                                        btnUpdateAvailableSkipVersion = ReadValue;
                                        continue;
                                    case "btnupdateavailableupdate":
                                        btnUpdateAvailableUpdate = ReadValue;
                                        continue;
                                        #endregion

                                }
                            }
                        }
                        UsingInternalEnglish = false;
                        return true;
                    }
                    else {
                        throw new Exception("LangaugeFile does not exist.");
                    }
                }
            }
            catch (Exception ex) {
                using murrty.frmException error = new(new(ex) {
                    FromLanguage = true
                });
                error.ShowDialog();
                return false;
            }
        }

        /// <summary>
        /// Parses the header value from a string.
        /// </summary>
        /// <param name="Input">The string that may contain a header.</param>
        /// <returns>Returns the absolute header.</returns>
        private void ReadHeaderValue(string Input, out string Header) {
            if (Input.Contains("//"))
                Input = Input[..Input.IndexOf("//")];
            Header = Input[1..Input.IndexOf(']')];
        }

        /// <summary>
        /// Parses the control name and value from a string.
        /// </summary>
        /// <param name="Input">The string that will be parsed. Empty values are permitted.</param>
        /// <param name="Name">The output of the Name of the control to be named, as lowercase.</param>
        /// <param name="Value">The value of the control.</param>
        private void GetControlInfo(string Input, out string Name, out string Value) {
            switch (Input.Split('=').Length) {
                case -1: case 0: {
                    Name = null;
                    Value = null;
                } return;

                case 1: {
                    if (Input.Contains("//"))
                        Input = Input[..Input.IndexOf("//")];
                    Name = Input.Split('=')[0].ToLower().Trim();
                    Value = string.Empty;
                } break;

                default: {
                    if (Input.Contains("//"))
                        Input = Input[..Input.IndexOf("//")];
                    Name = Input.Split('=')[0].ToLower().Trim();
                    Value = Input[(Input.IndexOf('=') + 1)..].Trim();
                } break;
            }
        }
        #endregion

    }
}