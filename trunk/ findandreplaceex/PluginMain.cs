/*
 * Advanced Find and Replace Plugin for FlashDevelop3
 * Author: Itzik Arzoni IAP (itzikiap@gmail.com)
 * 
 */

using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Collections;
//using System.Threading;
using System.Drawing;
using System.IO;
using WeifenLuo.WinFormsUI;
using WeifenLuo.WinFormsUI.Docking;
using PluginCore;
using PluginCore.Controls;
using ScintillaNet;
using PluginCore.Localization;
using PluginCore.Helpers;
using PluginCore.Managers;
using PluginCore.Utilities;
using ASCompletion.Context;
using ASCompletion.Model;
using System.Collections.Generic;

namespace FindReplaceEx
{
	public class PluginMain : IPlugin
	{

        private Timer typingTimer;
		private string pluginName = "FindReplaceEx";
		private string pluginGuid = "0a84cd4e-64d8-4669-a082-8238aee69658";
		private string pluginAuth = "Itzik Arzoni";
		private string pluginHelp = "http://www.flashdevelop.org/community/viewtopic.php?t=485";
		private string pluginDesc = "Find and Replace plugin Expanded";
		private EventType eventMask = EventType.UIRefresh | EventType.ApplySettings | EventType.Keys;
		private DockContent pluginPanel;
		private PluginUI pluginUI;
        private String settingFilename;
        private Image pluginImage;
        private Settings settingObject;

        private string[] classPaths;
		
		private FindResults results;

		#region RequiredPluginVariables

		public string Name
		{
			get { return this.pluginName; }
		}

		public string Guid
		{
			get { return this.pluginGuid; }
		}

		public string Author
		{
			get { return this.pluginAuth; }
		}

		public string Description
		{
			get { return this.pluginDesc; }
		}

		public string Help
		{
			get { return this.pluginHelp; }
		}

		public EventType EventMask
		{
			get { return this.eventMask; }
		}

		[Browsable(false)]
		public DockContent Panel
		{
			get { return this.pluginPanel; }
		}
		
		#endregion

		#region extra properties
		public IMainForm MainForm
		{
			get { return PluginBase.MainForm; }
		}

		[Browsable(false)]
		public PluginUI PluginUI
		{
			get { return this.pluginUI; }
		}

        /// <summary>
        /// a reference to the currently active acientilla control
        /// </summary>
        public ScintillaControl CurSciControl
        {
            get
            {
                // current active document
                ITabbedDocument doc = MainForm.CurrentDocument;
                ScintillaControl sci = doc.SciControl;
                return sci;
            }
        }



		#endregion


        #region Required Methods

        /// <summary>
        /// Initializes the plugin
        /// </summary>
        public void Initialize()
        {
            this.InitBasics();
            this.LoadSettings();
            this.AddEventHandlers();
            this.CreateMenuItem();
            this.CreatePluginPanel();

            this.typingTimer = new Timer();
            this.typingTimer.Enabled = false;
            this.typingTimer.Tick += delegate { this.TypingTimerTick(); };
        }

        /// <summary>
        /// Disposes the plugin
        /// </summary>
        public void Dispose()
        {
            this.SaveSettings();
            this.pluginUI.Terminate();
        }

        /// <summary>
        /// Handles the incoming events
        /// </summary>
        public void HandleEvent(Object sender, NotifyEvent e, HandlingPriority prority)
        {
            ITabbedDocument document = PluginBase.MainForm.CurrentDocument;
            ScintillaControl doc = null;
            if (document != null)
            {
                doc = document.SciControl;
            }

            switch (e.Type)
            {
 
                case EventType.ApplySettings:
                    UpdateSettings();
                    break;

  				case EventType.UIRefresh:
                    try
                    {
                        if (pluginPanel.Visible && !(MainForm == null))
                        {
                            if (doc.SelectionStart == doc.SelectionEnd)
                            {
                                if (settingObject.FeedOnCaret)
                                {
                                    typingTimer.Stop();
                                    typingTimer.Start();
                                }
                                pluginUI.SelectionChanged(false);
                            }
                            else
                            {
                                pluginUI.SelectionChanged();
                            }
                        }
                    }
                    catch
                    {
                        // ignore any error
                    }

					break;
				case EventType.Keys:
					Keys key = ((KeyEvent)e).Value;
                    if (key == settingObject.ReplaceShortcut)
					{
						pluginUI.EnableFocus(true);
						e.Handled = false;
					}
					else if (key == settingObject.FindShortcut)
					{
						pluginUI.EnableFocus();
						e.Handled = true;
					}
					break;

          }
        }

        private void UpdateSettings()
        {
            this.pluginUI.UpdateSettings(settingObject);

            this.typingTimer.Interval = settingObject.TypingTimerInterval;
        }

        #endregion

        #region Custom Methods

        /// <summary>
        /// Initializes important variables
        /// </summary>
        public void InitBasics()
        {
            this.pluginDesc = TextHelper.GetString("Info.Description");
            String dataPath = Path.Combine(PathHelper.DataDir, "FindReplaceEx");
            if (!Directory.Exists(dataPath)) Directory.CreateDirectory(dataPath);
            this.settingFilename = Path.Combine(dataPath, "Settings.fdb");
            this.pluginImage = PluginBase.MainForm.FindImage("484|12|4|-1");
        }

        /// <summary>
        /// Adds the required event handlers
        /// </summary> 
        public void AddEventHandlers()
        {
            EventManager.AddEventHandler(this, eventMask);
        }

        /// <summary>
        /// Creates a plugin panel for the plugin
        /// </summary>
        public void CreatePluginPanel()
        {
            this.pluginUI = new PluginUI(this);
            this.pluginUI.Text = "F&R Ex";
            this.pluginPanel = PluginBase.MainForm.CreateDockablePanel(this.pluginUI, this.pluginGuid, this.pluginImage, DockState.DockBottomAutoHide);
        }

        /// <summary>
        /// Creates a menu item for the plugin and adds a ignored key
        /// </summary>
        public void CreateMenuItem()
        {
            //String title = TextHelper.GetString("Label.ViewMenuItem");
            String title = "Find And Replace Expanded";
            ToolStripMenuItem viewMenu = (ToolStripMenuItem)PluginBase.MainForm.FindMenuItem("ViewMenu");
            viewMenu.DropDownItems.Add(new ToolStripMenuItem(title, this.pluginImage, new EventHandler(this.OpenPanel)));
        }

        /// <summary>
        /// Loads the plugin settings
        /// </summary>
        public void LoadSettings()
        {
            this.settingObject = new Settings();
            if (!File.Exists(this.settingFilename)) this.SaveSettings();
            else
            {
                Object obj = ObjectSerializer.Deserialize(this.settingFilename, this.settingObject);
                this.settingObject = (Settings)obj;
            }
        }

        /// <summary>
        /// Saves the plugin settings
        /// </summary>
        public void SaveSettings()
        {
            ObjectSerializer.Serialize(this.settingFilename, this.settingObject);
        }

        /// <summary>
        /// Opens the plugin panel if closed
        /// </summary>
        public void OpenPanel(Object sender, System.EventArgs e)
        {
            this.pluginPanel.Show();
        }

        #endregion

		
		#region sync project explorer code
		
        /// <summary>
        /// Updates the class paths from ther project explorer to use in "Find In Files"
        /// </summary>
        public void UpdateProjectClassPaths()
		{
            List<PathModel> classPath = ASContext.Context.Classpath;

            string[] paths = new string[classPath.Count];
            int i = 0;

            foreach (PathModel path in classPath)
            {
                paths.SetValue(path.Path, i++);
            }
/*	        localClassPaths = (projectInfo["classpaths"]) as string[];
	        string[] globalPaths = globalClassPaths.Split(';');
	        classPaths = new string[localClassPaths.Length + globalPaths.Length];
	        localClassPaths.CopyTo(classPaths, 0);
	        globalPaths.CopyTo(classPaths,localClassPaths.Length);*/
	        pluginUI.UpdateFolderClassPaths(paths);
		}
		
		#endregion
		
		#region Find and Replace commands

        /// <summary>
        /// Event that happens several milliseconds after typing was stopped
        /// It update the find input box
        /// </summary>
        private void TypingTimerTick()
        {
            typingTimer.Stop();
            SetFindTextInDocument();
        }

        /// <summary>
        /// update the find input box according to the word that is under the cursor
        /// </summary>
		public void SetFindTextInDocument()
		{
            // current active document
            ITabbedDocument doc = MainForm.CurrentDocument;
            if (doc != null)
            {
                ScintillaControl Sci = doc.SciControl;
                string text = Sci.GetWordFromPosition(Sci.CurrentPos + 1);
                SetFindTextInDocument(text);
            }
		}
		
        /// <summary>
        /// updates the find input box according to a desired text
        /// </summary>
        /// <param name="Text">Text to find</param>
		public void SetFindTextInDocument(string Text)
		{
			if (Text != null)
				pluginUI.SetFindText(Text);
		}
		
        /// <summary>
        /// Initiate a search for a text
        /// </summary>
        /// <param name="text">Text to find</param>
		public void SearchTextInDocument(string text)
		{
			if (text.Length > 1)
			{
				SetFindTextInDocument(text);
			}
			else
			{
				SetFindTextInDocument();
			}
			pluginUI.ListAllFindText();
		}
		
        /// <summary>
        /// Get the options to add to the regexp search according to user selection
        /// </summary>
        /// <returns>Regexp options with the current choice</returns>
		private RegexOptions GetRegexOptions()
		{
			RegexOptions options = RegexOptions.None;
			if (!pluginUI.MatchCase)
				options = options | RegexOptions.IgnoreCase;
			return options;
		}
		
        /// <summary>
        /// gets a search string that is safe to searchs
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
		private string getSafeSearch(string input)
		{
			if (!pluginUI.RegExp)
			{
				input = Regex.Escape(input);
			}
			if (pluginUI.WholeWord)
			{
				input  = "(?<!\\w)"+input+"(?!\\w)";
			}
			return input;
		}
				
        /// <summary>
        /// gets a collection of results based on input text
        /// </summary>
        /// <param name="findText">Text to find</param>
        /// <returns>results</returns>
		public FindResults GetResultsList(string findText)
		{
			return GetResultsList(CurSciControl, findText);
		}

        /// <summary>
        /// gets a collection of results based on input text in a specific scientilla control
        /// </summary>
        /// <param name="sci">Scientilla control to perform the search</param>
        /// <param name="findText">text to find</param>
        /// <returns>results</returns>
		public FindResults GetResultsList(ScintillaControl sci, string findText)
		{
			results = new FindResults();
			AddToResultsList(sci, findText);
			//SendResults(results, "resultsListUpdate");
			return 	results;
		}
		
        /// <summary>
        /// gets a results list from all open docuents to the wanted text
        /// </summary>
        /// <param name="findText">text to find</param>
        /// <returns>results</returns>
		public FindResults GetAllDocumentsResultsList(string findText)
		{
			results = new FindResults();
			foreach (ITabbedDocument document in MainForm.Documents)
			{
				if (document.Controls.Count == 0) continue;
                ScintillaControl sci = document.SciControl;

                if (sci == null) continue;
				AddToResultsList(sci , findText);
			}
			//SendResults(results, "resultsListUpdate");
			return results;
		}
		
        /// <summary>
        /// Initiate a find in folders search
        /// </summary>
        /// <param name="pattern">text to find in a form of regexp expression</param>
        /// <param name="folder">folder to search</param>
        /// <param name="recursive">set true to search subfolders</param>
        /// <returns>results</returns>
		public FindResults GetFindInFolderResultsList(string pattern, string folder, bool recursive)
		{
			return GetFindInFolderResultsList(pattern, folder, "*.as", recursive);
		}

        /// <summary>
        /// Initiate a find in folders search with different file mask
        /// </summary>
        /// <param name="pattern">text to find in a form of regexp expression</param>
        /// <param name="folder">folder to search</param>
        /// <param name="mask">mask of files to search</param>
        /// <param name="recursive">set true to search subfolders</param>
        /// <returns>results</returns>
		public FindResults GetFindInFolderResultsList(string pattern, string folder, string mask, bool recursive)
		{
			results = FindInFiles.GetSearchResults(folder, pattern, mask, recursive, pluginUI.RegExp, pluginUI.WholeWord, pluginUI.MatchCase);
			//SendResults(results, "resultsListUpdate");
			return results;
		}
		
        /// <summary>
        /// perform a search 
        /// </summary>
        /// <param name="sci"></param>
        /// <param name="findText"></param>
        /// <returns></returns>
		private FindResults AddToResultsList(ScintillaControl sci, string findText)
		{
			try
			{
				string inText = sci.Text;
				findText = getSafeSearch(findText);
				MatchCollection searchResults = Regex.Matches(inText, findText, GetRegexOptions());
				results.AddResults(sci, searchResults);
			} 
			catch
			{
				//MessageBox.Show("error in addToResultsList");
				//MainForm.AddTraceLogEntry("Error searching in file", 5);
			}
			return results;
		}
	
        /// <summary>
        /// focus the scintilla control and move carret to position
        /// </summary>
        /// <param name="position">position count in chars from the beginning of document</param>
		public void GotoPosAndFocus(int position)
		{
			try{
                ITabbedDocument document = PluginBase.MainForm.CurrentDocument;

				GotoPosAndFocus(document.SciControl, position, 0);
			}
			catch{
			}
			
		}
		
        /// <summary>
        /// focus on a file, open it if needed and position the carret
        /// </summary>
        /// <param name="fileName">file to open</param>
        /// <param name="position">position in file</param>
        /// <param name="length"></param>
		public void GotoPosAndFocus(string fileName, int position, int length)
		{
			MainForm.OpenEditableDocument(fileName);
			GotoPosAndFocus(position);
		}
		
        /// <summary>
        /// focus a needed scientilla control and position the carret
        /// </summary>
        /// <param name="sci">a scientilla control to focus</param>
        /// <param name="position">position of the carret in the text</param>
        /// <param name="length"></param>
		public void GotoPosAndFocus(ScintillaNet.ScintillaControl sci, int position, int length)
		{
			// don't correct to multi-byte safe position (assumed correct)
			int line = sci.LineFromPosition(position);
			//sci.EnsureVisible(line);
			sci.ExpandAllFolds();

            sci.SetSel(position, position + length);
           // sci.EnsureVisible(line);

			int top = sci.FirstVisibleLine;
			int middle = top + sci.LinesOnScreen/2;
			sci.LineScroll(0, line-middle);

		}
		

		#endregion		
		
		#region settings getters	
		public string CurFile
		{
			get {return MainForm.CurrentDocument.FileName; }
		}
		
		public int CurPosition
		{
			get {
                ITabbedDocument document = PluginBase.MainForm.CurrentDocument;
                return document.SciControl.CurrentPos;
            }
		}
			
		public string[] ClassPaths
		{
			get {return classPaths;}
		}
		#endregion


        #region IPlugin Members


        public object Settings
        {
            get { return settingObject; }
        }

        #endregion
    }
}
