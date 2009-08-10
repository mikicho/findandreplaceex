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
        public const Keys DEFAULT_FIND = Keys.Alt | Keys.F;
        public const Keys DEFAULT_REPLACE = Keys.Alt| Keys.R;

        //public const string[] DEFAULT_FILTER_PRESETS = ["(import|new)\\s*[\\w\\.]*@FIND[\\.;],(function|var)\\s*\\w*\\s*:\\s*@FIND\\s*[;\\(]"];

        private Keys findShortcut = DEFAULT_FIND;
        private Keys replaceShortcut = DEFAULT_REPLACE;
        private bool findAsYouType = true;
        private bool feedWordAsYouType = true;
        private bool feedWordOnCaretMovement = true;
        private bool autoHideReplace = true;
        private bool groupByFile = true;
        private int ignoreCharactersBelow = 3;
        private int typingTimerInterval = 500;
        private string[] filterPresets = null;


        [DisplayName("Find Shortcut")]
        [Category("Shortcuts")] 
        [Description("A keybard shortcut to focus on the find input box"), DefaultValue(DEFAULT_FIND)]
        public Keys FindShortcut
        {
            get { return findShortcut; }
            set { findShortcut = value; }
        }

        [DisplayName("Replace Shortcut")]
        [Category("Shortcuts")]
        [Description("A keybard shortcut to focus on the find input box"), DefaultValue(DEFAULT_REPLACE)]
        public Keys ReplaceShortcut
        {
            get { return replaceShortcut; }
            set { replaceShortcut = value; }
        }

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
    }

}
