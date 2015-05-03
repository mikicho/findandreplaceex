using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using PluginCore.Localization;
using System.Windows.Forms;

namespace FindReplaceEx
{
    [Serializable]
    public class Settings 
    {

        //public const string[] DEFAULT_FILTER_PRESETS = ["(import|new)\\s*[\\w\\.]*@FIND[\\.;],(function|var)\\s*\\w*\\s*:\\s*@FIND\\s*[;\\(]"];

        private bool findAsYouType = true;
        private bool feedWordAsYouType = true;
        private bool feedWordOnCaretMovement = true;
        private bool autoHideReplace = true;
        private bool groupByFile = true;
        private int ignoreCharactersBelow = 3;
        private int typingTimerInterval = 500;
        private int searchHistoryLimit = 10;
        private bool resizeOptionsTab = true;
        private bool resizeReplaceTab = false;
        private bool resizeFilterTab = false;
        private bool resizeFoldersTab = true;
        private bool resizeOperationsTab = true;
        private string[] filterPresets = null;

        [DisplayName("Find As You Type")]
        [Category("Settings")]
        [Description("Instantly make a search when you type in the find input. Also search when the input is change via \"FeedAsYouType\"."), DefaultValue(true)]
        public bool FindAsYouType
        {
            get { return findAsYouType; }
            set { findAsYouType = value; }
        }

        [DisplayName("Feed As You Type")]
        [Category("Settings")]
        [Description("Feeds the Find input while you type text in the editor."), DefaultValue(true)]
        public bool FeedAsYouType
        {
            get { return feedWordAsYouType; }
            set { feedWordAsYouType = value; }
        }

        [DisplayName("Feed As You Move")]
        [Category("Settings")]
        [Description("Feeds the Find input while you move the carret in the editor."), DefaultValue(true)]
        public bool FeedOnCaret
        {
            get { return feedWordOnCaretMovement; }
            set { feedWordOnCaretMovement = value; }
        }

        [DisplayName("Auto Hide Replace")]
        [Category("Settings")]
        [Description("Hides the Replace tab after successful replace."), DefaultValue(true)]
        public bool AutoHideReplace
        {
            get { return autoHideReplace; }
            set { autoHideReplace = value; }
        }

        
        [DisplayName("Group By File")]
        [Category("Settings")]
        [Description("Group all the results from the same file under a title."), DefaultValue(true)]
        public bool GroupByFile
        {
            get { return groupByFile; }
            set { groupByFile = value; }
        }
        



        [DisplayName("Ignore Below")]
        [Category("Settings")]
        [Description("When FindAsYouType is on, set the minimum characters to activate the find."), DefaultValue(3)]
        public int IgnoreBelow
        {
            get { return ignoreCharactersBelow; }
            set { ignoreCharactersBelow = value; }
        }

        [DisplayName("Typing Timer Interval")]
        [Category("Settings")]
        [Description("When FeedAsYouMove is true, sets the delay until the panel is refreshed. This setting is to prevent overload of searches."), DefaultValue("500")]
        public int TypingTimerInterval
        {
            get { return typingTimerInterval; }
            set { typingTimerInterval  = value; }
        }

        [DisplayName("Filter Presets")]
        [Category("Settings")]
        [Description("Write you favorite regex filters here"), DefaultValue(null)]
        public string[] FilterPresets
        {
            get { return filterPresets; }
            set { filterPresets = value; }
        }

        [DisplayName("Search History Limit")]
        [Category("Settings")]
        [Description("Determine how much history will be saved in find combo box"), DefaultValue(10)]
        public int SearchHistoryLimit
        {
            get { return searchHistoryLimit; }
            set { searchHistoryLimit = value; }
        }

        [DisplayName("Options Tab Open")]
        [Category("Resize Result List")]
        [Description("Resize result list if the plugin lost focus when Options tab open"), DefaultValue(true)]
        public bool ResizeOptionsTab
        {
            get { return resizeOptionsTab; }
            set { resizeOptionsTab = value; }
        }

        [DisplayName("Replace Tab Open")]
        [Category("Resize Result List")]
        [Description("Resize result list if the plugin lost focus when Replace tab open"), DefaultValue(false)]
        public bool ResizeReplaceTab
        {
            get { return resizeReplaceTab; }
            set { resizeReplaceTab = value; }
        }

        [DisplayName("Filter Tab Open")]
        [Category("Resize Result List")]
        [Description("Resize result list if the plugin lost focus when Filter tab open"), DefaultValue(false)]
        public bool ResizeFilterTab
        {
            get { return resizeFilterTab; }
            set { resizeFilterTab = value; }
        }

        [DisplayName("Folders Tab Open")]
        [Category("Resize Result List")]
        [Description("Resize result list if the plugin lost focus when Folders tab open"), DefaultValue(true)]
        public bool ResizeFoldersTab
        {
            get { return resizeFoldersTab; }
            set { resizeFoldersTab = value; }
        }

        [DisplayName("Operations Tab Open")]
        [Category("Resize Result List")]
        [Description("Resize result list if the plugin lost focus when Operations tab open"), DefaultValue(true)]
        public bool ResizeOperationsTab
        {
            get { return resizeOperationsTab; }
            set { resizeOperationsTab = value; }
        }

    }

}
