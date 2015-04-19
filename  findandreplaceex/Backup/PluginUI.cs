/*
 * Created by IAP.
 * User: Itzik Arzoni (itzikiap@nana.co.il)
 * Date: 13/12/2005
 * Time: 21:43
 *
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using WeifenLuo.WinFormsUI;
using ScintillaNet;
using System.Windows.Forms;
using System.Collections;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using PluginCore;
using PluginCore.Managers;
using System.Drawing;
using FlashDevelop;


namespace FindReplaceEx
{
	/// <summary>
	/// Description of PluginUI.
	/// </summary>
	public class PluginUI : System.Windows.Forms.DockPanelControl
	{
        private System.ComponentModel.IContainer components;
		// reference to the plugin interface
		private PluginMain plugin;
		private string lastPath;
        private bool replaceShown;
        private TextBox findTxt;
        private ToolTip toolTip;
        private TabControl tabControl;
        private TabPage optionsPage;
        private CheckBox autoFeedChk;
        private CheckBox autoChk;
        private CheckBox openFilesChk;
        private TabPage replacePage;
        private Label resultsLbl;
        private Button switchFindReplaceBtn;
        private TextBox replaceTxt;
        private Button replaceBtn;
        private Button copyFindReplaceBtn;
        private Button button1;
        private Button ofrBtn;
        private TabPage filterPage;
        private ComboBox filterTxt;
        private Button regexHelpBtn;
        private TabPage foldersPage;
        private TextBox fileMaskTxt;
        private CheckBox searchSubfoldersChk;
        private Button browseBtn;
        private ComboBox folderTxt;
        private CheckBox folderFilesChk;
        private RadioButton checkNoneRdo;
        private RadioButton checkcCustomeRdo;
        private RadioButton checkFileRdo;
        private RadioButton checkSelectonRdo;
        private RadioButton checkFilterRdo;
        private GroupBox filterGroup;
        private RadioButton checkAllRdo;
        private ColumnHeader at;
        private ListView resultsLst;
        private ColumnHeader columnLineNum;
        private ColumnHeader columnFileName;
        private ColumnHeader columnLineText;
        private FolderBrowserDialog fileBrowserDlg;
        private Button findBtn;
        private CheckBox regexpChk;
        private CheckBox wholeWordChk;
        private CheckBox matchCaseChk;
        private GroupBox findGroup;
        private ColumnHeader result;
        private ColumnHeader filename;
        private ColumnHeader mark;
        private TabPage operationsPage;
        private Button deleteBtn;
        private Button bookmarkBtn;
        private Button clearFilterBtn;
        private CheckBox regExReplaceChk;
        private Button CopyResultsBtn;
		private string state;
//		private bool classPathRoot;
		
		public PluginUI(PluginMain pluginMain)
		{
			InitializeComponent();
			
			// reference to the plugin interface
			this.plugin = pluginMain;
			toolTip.Active = true;
			state = "<>";
			// switchFindReplaceBtn.Image = plugin.MainForm.GetSystemImage(10);
			
			
			//resultsPanel = plugin.MainForm.FindPlugin("24df7cd8-e5f0-4171-86eb-7b2a577703ba");
		}
		
		#region Windows Forms Designer generated code
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.findTxt = new System.Windows.Forms.TextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.checkNoneRdo = new System.Windows.Forms.RadioButton();
            this.checkcCustomeRdo = new System.Windows.Forms.RadioButton();
            this.checkFileRdo = new System.Windows.Forms.RadioButton();
            this.checkSelectonRdo = new System.Windows.Forms.RadioButton();
            this.checkFilterRdo = new System.Windows.Forms.RadioButton();
            this.folderFilesChk = new System.Windows.Forms.CheckBox();
            this.browseBtn = new System.Windows.Forms.Button();
            this.searchSubfoldersChk = new System.Windows.Forms.CheckBox();
            this.fileMaskTxt = new System.Windows.Forms.TextBox();
            this.openFilesChk = new System.Windows.Forms.CheckBox();
            this.autoChk = new System.Windows.Forms.CheckBox();
            this.autoFeedChk = new System.Windows.Forms.CheckBox();
            this.checkAllRdo = new System.Windows.Forms.RadioButton();
            this.findBtn = new System.Windows.Forms.Button();
            this.regexHelpBtn = new System.Windows.Forms.Button();
            this.regexpChk = new System.Windows.Forms.CheckBox();
            this.wholeWordChk = new System.Windows.Forms.CheckBox();
            this.matchCaseChk = new System.Windows.Forms.CheckBox();
            this.ofrBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.copyFindReplaceBtn = new System.Windows.Forms.Button();
            this.replaceBtn = new System.Windows.Forms.Button();
            this.switchFindReplaceBtn = new System.Windows.Forms.Button();
            this.bookmarkBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.regExReplaceChk = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.optionsPage = new System.Windows.Forms.TabPage();
            this.replacePage = new System.Windows.Forms.TabPage();
            this.replaceTxt = new System.Windows.Forms.TextBox();
            this.filterPage = new System.Windows.Forms.TabPage();
            this.filterTxt = new System.Windows.Forms.ComboBox();
            this.clearFilterBtn = new System.Windows.Forms.Button();
            this.foldersPage = new System.Windows.Forms.TabPage();
            this.folderTxt = new System.Windows.Forms.ComboBox();
            this.operationsPage = new System.Windows.Forms.TabPage();
            this.resultsLbl = new System.Windows.Forms.Label();
            this.filterGroup = new System.Windows.Forms.GroupBox();
            this.at = new System.Windows.Forms.ColumnHeader();
            this.resultsLst = new System.Windows.Forms.ListView();
            this.mark = new System.Windows.Forms.ColumnHeader();
            this.result = new System.Windows.Forms.ColumnHeader();
            this.filename = new System.Windows.Forms.ColumnHeader();
            this.columnLineNum = new System.Windows.Forms.ColumnHeader();
            this.columnFileName = new System.Windows.Forms.ColumnHeader();
            this.columnLineText = new System.Windows.Forms.ColumnHeader();
            this.fileBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.findGroup = new System.Windows.Forms.GroupBox();
            this.CopyResultsBtn = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.optionsPage.SuspendLayout();
            this.replacePage.SuspendLayout();
            this.filterPage.SuspendLayout();
            this.foldersPage.SuspendLayout();
            this.operationsPage.SuspendLayout();
            this.filterGroup.SuspendLayout();
            this.findGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // findTxt
            // 
            this.findTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.findTxt.Location = new System.Drawing.Point(312, 4);
            this.findTxt.Name = "findTxt";
            this.findTxt.Size = new System.Drawing.Size(476, 20);
            this.findTxt.TabIndex = 0;
            this.findTxt.WordWrap = false;
            this.findTxt.TextChanged += new System.EventHandler(this.FindTxtTextChanged);
            // 
            // checkNoneRdo
            // 
            this.checkNoneRdo.AutoSize = true;
            this.checkNoneRdo.BackColor = System.Drawing.Color.Transparent;
            this.checkNoneRdo.Location = new System.Drawing.Point(261, 13);
            this.checkNoneRdo.Margin = new System.Windows.Forms.Padding(0);
            this.checkNoneRdo.Name = "checkNoneRdo";
            this.checkNoneRdo.Size = new System.Drawing.Size(51, 17);
            this.checkNoneRdo.TabIndex = 3;
            this.checkNoneRdo.Text = "None";
            this.toolTip.SetToolTip(this.checkNoneRdo, "Uncheck all the entries to not replace");
            this.checkNoneRdo.UseVisualStyleBackColor = false;
            this.checkNoneRdo.CheckedChanged += new System.EventHandler(this.CheckRdoCheckedChanged);
            // 
            // checkcCustomeRdo
            // 
            this.checkcCustomeRdo.AutoSize = true;
            this.checkcCustomeRdo.BackColor = System.Drawing.Color.Transparent;
            this.checkcCustomeRdo.Location = new System.Drawing.Point(159, 13);
            this.checkcCustomeRdo.Margin = new System.Windows.Forms.Padding(0);
            this.checkcCustomeRdo.Name = "checkcCustomeRdo";
            this.checkcCustomeRdo.Size = new System.Drawing.Size(66, 17);
            this.checkcCustomeRdo.TabIndex = 6;
            this.checkcCustomeRdo.Text = "Custome";
            this.toolTip.SetToolTip(this.checkcCustomeRdo, "Default for manually checked entries.");
            this.checkcCustomeRdo.UseVisualStyleBackColor = false;
            this.checkcCustomeRdo.CheckedChanged += new System.EventHandler(this.CheckRdoCheckedChanged);
            // 
            // checkFileRdo
            // 
            this.checkFileRdo.AutoSize = true;
            this.checkFileRdo.BackColor = System.Drawing.Color.Transparent;
            this.checkFileRdo.Checked = true;
            this.checkFileRdo.Location = new System.Drawing.Point(2, 13);
            this.checkFileRdo.Margin = new System.Windows.Forms.Padding(0);
            this.checkFileRdo.Name = "checkFileRdo";
            this.checkFileRdo.Size = new System.Drawing.Size(41, 17);
            this.checkFileRdo.TabIndex = 4;
            this.checkFileRdo.TabStop = true;
            this.checkFileRdo.Text = "File";
            this.toolTip.SetToolTip(this.checkFileRdo, "Check all the entries of the current file. (Same as All if \"search all opened fil" +
                    "es\" is unchecked)");
            this.checkFileRdo.UseVisualStyleBackColor = false;
            this.checkFileRdo.CheckedChanged += new System.EventHandler(this.CheckRdoCheckedChanged);
            // 
            // checkSelectonRdo
            // 
            this.checkSelectonRdo.AutoSize = true;
            this.checkSelectonRdo.BackColor = System.Drawing.Color.Transparent;
            this.checkSelectonRdo.Location = new System.Drawing.Point(43, 13);
            this.checkSelectonRdo.Margin = new System.Windows.Forms.Padding(0);
            this.checkSelectonRdo.Name = "checkSelectonRdo";
            this.checkSelectonRdo.Size = new System.Drawing.Size(69, 17);
            this.checkSelectonRdo.TabIndex = 5;
            this.checkSelectonRdo.Text = "Selection";
            this.toolTip.SetToolTip(this.checkSelectonRdo, "Check all the checkboxes that inside the selection.");
            this.checkSelectonRdo.UseVisualStyleBackColor = false;
            this.checkSelectonRdo.CheckedChanged += new System.EventHandler(this.CheckRdoCheckedChanged);
            // 
            // checkFilterRdo
            // 
            this.checkFilterRdo.AutoSize = true;
            this.checkFilterRdo.BackColor = System.Drawing.Color.Transparent;
            this.checkFilterRdo.Location = new System.Drawing.Point(112, 13);
            this.checkFilterRdo.Margin = new System.Windows.Forms.Padding(0);
            this.checkFilterRdo.Name = "checkFilterRdo";
            this.checkFilterRdo.Size = new System.Drawing.Size(47, 17);
            this.checkFilterRdo.TabIndex = 6;
            this.checkFilterRdo.Text = "Filter";
            this.toolTip.SetToolTip(this.checkFilterRdo, "Check the entries that match the filter string");
            this.checkFilterRdo.UseVisualStyleBackColor = false;
            this.checkFilterRdo.CheckedChanged += new System.EventHandler(this.CheckRdoCheckedChanged);
            // 
            // folderFilesChk
            // 
            this.folderFilesChk.Location = new System.Drawing.Point(8, 32);
            this.folderFilesChk.Name = "folderFilesChk";
            this.folderFilesChk.Size = new System.Drawing.Size(108, 24);
            this.folderFilesChk.TabIndex = 9;
            this.folderFilesChk.Text = "All Files in Folder";
            this.toolTip.SetToolTip(this.folderFilesChk, "Check this to set the next search to be in alll files in the above directory.");
            this.folderFilesChk.CheckedChanged += new System.EventHandler(this.FolderFilesChkCheckedChanged);
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(232, 32);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(66, 23);
            this.browseBtn.TabIndex = 1;
            this.browseBtn.Text = "Browse...";
            this.toolTip.SetToolTip(this.browseBtn, "Browse for a folder to search in.");
            this.browseBtn.Click += new System.EventHandler(this.BrowseBtnClick);
            // 
            // searchSubfoldersChk
            // 
            this.searchSubfoldersChk.Checked = true;
            this.searchSubfoldersChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.searchSubfoldersChk.Location = new System.Drawing.Point(104, 32);
            this.searchSubfoldersChk.Name = "searchSubfoldersChk";
            this.searchSubfoldersChk.Size = new System.Drawing.Size(80, 24);
            this.searchSubfoldersChk.TabIndex = 9;
            this.searchSubfoldersChk.Text = "Subfolders";
            this.toolTip.SetToolTip(this.searchSubfoldersChk, "Also search in subfolders.");
            this.searchSubfoldersChk.CheckedChanged += new System.EventHandler(this.FolderFilesChkCheckedChanged);
            // 
            // fileMaskTxt
            // 
            this.fileMaskTxt.Location = new System.Drawing.Point(177, 33);
            this.fileMaskTxt.Name = "fileMaskTxt";
            this.fileMaskTxt.Size = new System.Drawing.Size(48, 20);
            this.fileMaskTxt.TabIndex = 10;
            this.fileMaskTxt.Text = "*.as";
            this.toolTip.SetToolTip(this.fileMaskTxt, "Specify the file mask to search in.");
            // 
            // openFilesChk
            // 
            this.openFilesChk.Checked = true;
            this.openFilesChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.openFilesChk.Location = new System.Drawing.Point(8, 8);
            this.openFilesChk.Name = "openFilesChk";
            this.openFilesChk.Size = new System.Drawing.Size(142, 24);
            this.openFilesChk.TabIndex = 9;
            this.openFilesChk.Text = "All Opened Files";
            this.toolTip.SetToolTip(this.openFilesChk, "Show the reslts from all opened files.");
            this.openFilesChk.CheckedChanged += new System.EventHandler(this.OptionsChkCheckedChanged);
            // 
            // autoChk
            // 
            this.autoChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoChk.Checked = true;
            this.autoChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoChk.Location = new System.Drawing.Point(161, 28);
            this.autoChk.Name = "autoChk";
            this.autoChk.Size = new System.Drawing.Size(135, 16);
            this.autoChk.TabIndex = 4;
            this.autoChk.Tag = "";
            this.autoChk.Text = "Automatic find";
            this.toolTip.SetToolTip(this.autoChk, "List results immediately  while typing in the find box.");
            // 
            // autoFeedChk
            // 
            this.autoFeedChk.Checked = true;
            this.autoFeedChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoFeedChk.Location = new System.Drawing.Point(161, 8);
            this.autoFeedChk.Name = "autoFeedChk";
            this.autoFeedChk.Size = new System.Drawing.Size(135, 18);
            this.autoFeedChk.TabIndex = 21;
            this.autoFeedChk.Tag = "";
            this.autoFeedChk.Text = "Update as you type";
            this.toolTip.SetToolTip(this.autoFeedChk, "Update the find box when typing in the editor");
            // 
            // checkAllRdo
            // 
            this.checkAllRdo.AutoSize = true;
            this.checkAllRdo.BackColor = System.Drawing.Color.Transparent;
            this.checkAllRdo.Location = new System.Drawing.Point(225, 13);
            this.checkAllRdo.Margin = new System.Windows.Forms.Padding(0);
            this.checkAllRdo.Name = "checkAllRdo";
            this.checkAllRdo.Size = new System.Drawing.Size(36, 17);
            this.checkAllRdo.TabIndex = 2;
            this.checkAllRdo.Text = "All";
            this.toolTip.SetToolTip(this.checkAllRdo, "Check all the entries to replace");
            this.checkAllRdo.UseVisualStyleBackColor = false;
            this.checkAllRdo.CheckedChanged += new System.EventHandler(this.CheckRdoCheckedChanged);
            // 
            // findBtn
            // 
            this.findBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.findBtn.Location = new System.Drawing.Point(794, 2);
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(56, 22);
            this.findBtn.TabIndex = 1;
            this.findBtn.Text = "Find";
            this.toolTip.SetToolTip(this.findBtn, "Find the wanted phrase");
            this.findBtn.Click += new System.EventHandler(this.FindBtnClick);
            // 
            // regexHelpBtn
            // 
            this.regexHelpBtn.Location = new System.Drawing.Point(282, 8);
            this.regexHelpBtn.Name = "regexHelpBtn";
            this.regexHelpBtn.Size = new System.Drawing.Size(19, 21);
            this.regexHelpBtn.TabIndex = 7;
            this.regexHelpBtn.Text = "?";
            this.toolTip.SetToolTip(this.regexHelpBtn, "Help about regular expressions");
            this.regexHelpBtn.Click += new System.EventHandler(this.RegexHelpBtnClick);
            // 
            // regexpChk
            // 
            this.regexpChk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.regexpChk.Location = new System.Drawing.Point(178, 12);
            this.regexpChk.Name = "regexpChk";
            this.regexpChk.Size = new System.Drawing.Size(54, 24);
            this.regexpChk.TabIndex = 4;
            this.regexpChk.Tag = "";
            this.regexpChk.Text = "RegEx";
            this.toolTip.SetToolTip(this.regexpChk, "Threat the find text as Regular Expression");
            this.regexpChk.CheckedChanged += new System.EventHandler(this.regexpChk_CheckedChanged);
            // 
            // wholeWordChk
            // 
            this.wholeWordChk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.wholeWordChk.Location = new System.Drawing.Point(92, 12);
            this.wholeWordChk.Name = "wholeWordChk";
            this.wholeWordChk.Size = new System.Drawing.Size(84, 24);
            this.wholeWordChk.TabIndex = 3;
            this.wholeWordChk.Tag = "";
            this.wholeWordChk.Text = "Whole Word";
            this.toolTip.SetToolTip(this.wholeWordChk, "Search for whole word only");
            // 
            // matchCaseChk
            // 
            this.matchCaseChk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.matchCaseChk.Location = new System.Drawing.Point(4, 12);
            this.matchCaseChk.Name = "matchCaseChk";
            this.matchCaseChk.Size = new System.Drawing.Size(88, 24);
            this.matchCaseChk.TabIndex = 2;
            this.matchCaseChk.Tag = "";
            this.matchCaseChk.Text = "Match Case";
            this.toolTip.SetToolTip(this.matchCaseChk, "Ignore the case OF cHaraCtERs");
            // 
            // ofrBtn
            // 
            this.ofrBtn.BackColor = System.Drawing.Color.Silver;
            this.ofrBtn.Location = new System.Drawing.Point(240, 8);
            this.ofrBtn.Name = "ofrBtn";
            this.ofrBtn.Size = new System.Drawing.Size(64, 32);
            this.ofrBtn.TabIndex = 7;
            this.ofrBtn.Text = "Open Files && Search ";
            this.toolTip.SetToolTip(this.ofrBtn, "Open all the files in the results list and redo he search");
            this.ofrBtn.UseVisualStyleBackColor = false;
            this.ofrBtn.Click += new System.EventHandler(this.OfrBtnClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(96, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 27);
            this.button1.TabIndex = 7;
            this.button1.Text = "Clear";
            this.toolTip.SetToolTip(this.button1, "Copies the text from the find box");
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // copyFindReplaceBtn
            // 
            this.copyFindReplaceBtn.Location = new System.Drawing.Point(56, 32);
            this.copyFindReplaceBtn.Name = "copyFindReplaceBtn";
            this.copyFindReplaceBtn.Size = new System.Drawing.Size(40, 27);
            this.copyFindReplaceBtn.TabIndex = 7;
            this.copyFindReplaceBtn.Text = "Copy";
            this.toolTip.SetToolTip(this.copyFindReplaceBtn, "Copies the text from the find box");
            this.copyFindReplaceBtn.Click += new System.EventHandler(this.copyFindReplaceBtnClick);
            // 
            // replaceBtn
            // 
            this.replaceBtn.Location = new System.Drawing.Point(242, 8);
            this.replaceBtn.Name = "replaceBtn";
            this.replaceBtn.Size = new System.Drawing.Size(59, 23);
            this.replaceBtn.TabIndex = 1;
            this.replaceBtn.Text = "Replace";
            this.toolTip.SetToolTip(this.replaceBtn, "Replace the selected text in all the checked entries");
            this.replaceBtn.Click += new System.EventHandler(this.ReplaceBtnClick);
            // 
            // switchFindReplaceBtn
            // 
            this.switchFindReplaceBtn.Location = new System.Drawing.Point(8, 32);
            this.switchFindReplaceBtn.Name = "switchFindReplaceBtn";
            this.switchFindReplaceBtn.Size = new System.Drawing.Size(48, 27);
            this.switchFindReplaceBtn.TabIndex = 7;
            this.switchFindReplaceBtn.Text = "Switch";
            this.toolTip.SetToolTip(this.switchFindReplaceBtn, "Switches the text between find and replace");
            this.switchFindReplaceBtn.Click += new System.EventHandler(this.SwtchFindReplaceBtnClick);
            // 
            // bookmarkBtn
            // 
            this.bookmarkBtn.Location = new System.Drawing.Point(8, 7);
            this.bookmarkBtn.Name = "bookmarkBtn";
            this.bookmarkBtn.Size = new System.Drawing.Size(75, 23);
            this.bookmarkBtn.TabIndex = 0;
            this.bookmarkBtn.Text = "Bookmark";
            this.toolTip.SetToolTip(this.bookmarkBtn, "Bookmark all the selected items");
            this.bookmarkBtn.UseVisualStyleBackColor = true;
            this.bookmarkBtn.Click += new System.EventHandler(this.bookmarkBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(89, 7);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(75, 23);
            this.deleteBtn.TabIndex = 1;
            this.deleteBtn.Text = "Delete";
            this.toolTip.SetToolTip(this.deleteBtn, "Delete all selected line");
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // regExReplaceChk
            // 
            this.regExReplaceChk.AutoSize = true;
            this.regExReplaceChk.Location = new System.Drawing.Point(138, 38);
            this.regExReplaceChk.Name = "regExReplaceChk";
            this.regExReplaceChk.Size = new System.Drawing.Size(96, 17);
            this.regExReplaceChk.TabIndex = 8;
            this.regExReplaceChk.Text = "RegEx replace";
            this.toolTip.SetToolTip(this.regExReplaceChk, "If checked, you can use searched groups from the match in your replace. \\n Write " +
                    "$1 to insert the text from the first group, and so on.");
            this.regExReplaceChk.UseVisualStyleBackColor = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.optionsPage);
            this.tabControl.Controls.Add(this.replacePage);
            this.tabControl.Controls.Add(this.filterPage);
            this.tabControl.Controls.Add(this.foldersPage);
            this.tabControl.Controls.Add(this.operationsPage);
            this.tabControl.Location = new System.Drawing.Point(0, 43);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(312, 90);
            this.tabControl.TabIndex = 5;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControlSelectedIndexChanged);
            // 
            // optionsPage
            // 
            this.optionsPage.Controls.Add(this.autoFeedChk);
            this.optionsPage.Controls.Add(this.autoChk);
            this.optionsPage.Controls.Add(this.openFilesChk);
            this.optionsPage.Location = new System.Drawing.Point(4, 22);
            this.optionsPage.Name = "optionsPage";
            this.optionsPage.Size = new System.Drawing.Size(304, 64);
            this.optionsPage.TabIndex = 2;
            this.optionsPage.Text = "Options";
            this.optionsPage.UseVisualStyleBackColor = true;
            // 
            // replacePage
            // 
            this.replacePage.Controls.Add(this.regExReplaceChk);
            this.replacePage.Controls.Add(this.switchFindReplaceBtn);
            this.replacePage.Controls.Add(this.replaceTxt);
            this.replacePage.Controls.Add(this.replaceBtn);
            this.replacePage.Controls.Add(this.copyFindReplaceBtn);
            this.replacePage.Controls.Add(this.button1);
            this.replacePage.Controls.Add(this.ofrBtn);
            this.replacePage.Location = new System.Drawing.Point(4, 22);
            this.replacePage.Name = "replacePage";
            this.replacePage.Size = new System.Drawing.Size(304, 64);
            this.replacePage.TabIndex = 0;
            this.replacePage.Text = "Replace";
            this.replacePage.UseVisualStyleBackColor = true;
            // 
            // replaceTxt
            // 
            this.replaceTxt.Location = new System.Drawing.Point(4, 8);
            this.replaceTxt.Name = "replaceTxt";
            this.replaceTxt.Size = new System.Drawing.Size(238, 20);
            this.replaceTxt.TabIndex = 0;
            this.replaceTxt.Text = "@FIND";
            // 
            // filterPage
            // 
            this.filterPage.Controls.Add(this.filterTxt);
            this.filterPage.Controls.Add(this.clearFilterBtn);
            this.filterPage.Controls.Add(this.regexHelpBtn);
            this.filterPage.Location = new System.Drawing.Point(4, 22);
            this.filterPage.Name = "filterPage";
            this.filterPage.Size = new System.Drawing.Size(304, 64);
            this.filterPage.TabIndex = 2;
            this.filterPage.Text = "Filter";
            this.filterPage.UseVisualStyleBackColor = true;
            // 
            // filterTxt
            // 
            this.filterTxt.Items.AddRange(new object[] {
            "",
            "(import|new)\\s*[\\w\\.]*@FIND[\\.;]",
            "(function|var)\\s*\\w*\\s*:\\s*@FIND\\s*[;\\(]"});
            this.filterTxt.Location = new System.Drawing.Point(8, 8);
            this.filterTxt.Name = "filterTxt";
            this.filterTxt.Size = new System.Drawing.Size(243, 21);
            this.filterTxt.TabIndex = 15;
            this.filterTxt.TextChanged += new System.EventHandler(this.FilterTxtTextChanged);
            // 
            // clearFilterBtn
            // 
            this.clearFilterBtn.Location = new System.Drawing.Point(257, 8);
            this.clearFilterBtn.Name = "clearFilterBtn";
            this.clearFilterBtn.Size = new System.Drawing.Size(19, 21);
            this.clearFilterBtn.TabIndex = 7;
            this.clearFilterBtn.Text = "X";
            this.clearFilterBtn.Click += new System.EventHandler(this.clearFilterBtn_Click);
            // 
            // foldersPage
            // 
            this.foldersPage.Controls.Add(this.fileMaskTxt);
            this.foldersPage.Controls.Add(this.searchSubfoldersChk);
            this.foldersPage.Controls.Add(this.browseBtn);
            this.foldersPage.Controls.Add(this.folderTxt);
            this.foldersPage.Controls.Add(this.folderFilesChk);
            this.foldersPage.Location = new System.Drawing.Point(4, 22);
            this.foldersPage.Name = "foldersPage";
            this.foldersPage.Size = new System.Drawing.Size(304, 64);
            this.foldersPage.TabIndex = 1;
            this.foldersPage.Text = "Folders";
            this.foldersPage.UseVisualStyleBackColor = true;
            // 
            // folderTxt
            // 
            this.folderTxt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.folderTxt.Location = new System.Drawing.Point(4, 8);
            this.folderTxt.Name = "folderTxt";
            this.folderTxt.Size = new System.Drawing.Size(296, 21);
            this.folderTxt.TabIndex = 2;
            this.folderTxt.SelectedIndexChanged += new System.EventHandler(this.FolderTxtSelectedIndexChanged);
            // 
            // operationsPage
            // 
            this.operationsPage.Controls.Add(this.CopyResultsBtn);
            this.operationsPage.Controls.Add(this.deleteBtn);
            this.operationsPage.Controls.Add(this.bookmarkBtn);
            this.operationsPage.Location = new System.Drawing.Point(4, 22);
            this.operationsPage.Name = "operationsPage";
            this.operationsPage.Padding = new System.Windows.Forms.Padding(3);
            this.operationsPage.Size = new System.Drawing.Size(304, 64);
            this.operationsPage.TabIndex = 3;
            this.operationsPage.Text = "Operations";
            this.operationsPage.UseVisualStyleBackColor = true;
            // 
            // resultsLbl
            // 
            this.resultsLbl.AutoSize = true;
            this.resultsLbl.Location = new System.Drawing.Point(38, 0);
            this.resultsLbl.Name = "resultsLbl";
            this.resultsLbl.Size = new System.Drawing.Size(19, 13);
            this.resultsLbl.TabIndex = 8;
            this.resultsLbl.Text = "----";
            // 
            // filterGroup
            // 
            this.filterGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.filterGroup.Controls.Add(this.resultsLbl);
            this.filterGroup.Controls.Add(this.checkFilterRdo);
            this.filterGroup.Controls.Add(this.checkSelectonRdo);
            this.filterGroup.Controls.Add(this.checkFileRdo);
            this.filterGroup.Controls.Add(this.checkcCustomeRdo);
            this.filterGroup.Controls.Add(this.checkAllRdo);
            this.filterGroup.Controls.Add(this.checkNoneRdo);
            this.filterGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.filterGroup.Location = new System.Drawing.Point(0, 278);
            this.filterGroup.Name = "filterGroup";
            this.filterGroup.Size = new System.Drawing.Size(312, 43);
            this.filterGroup.TabIndex = 11;
            this.filterGroup.TabStop = false;
            this.filterGroup.Text = "Filter";
            // 
            // at
            // 
            this.at.Text = "@";
            this.at.Width = 51;
            // 
            // resultsLst
            // 
            this.resultsLst.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.resultsLst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resultsLst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mark,
            this.at,
            this.result,
            this.filename});
            this.resultsLst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.resultsLst.FullRowSelect = true;
            this.resultsLst.GridLines = true;
            this.resultsLst.HideSelection = false;
            this.resultsLst.LabelWrap = false;
            this.resultsLst.Location = new System.Drawing.Point(314, 27);
            this.resultsLst.Name = "resultsLst";
            this.resultsLst.ShowGroups = false;
            this.resultsLst.Size = new System.Drawing.Size(540, 291);
            this.resultsLst.TabIndex = 7;
            this.resultsLst.UseCompatibleStateImageBehavior = false;
            this.resultsLst.View = System.Windows.Forms.View.Details;
            this.resultsLst.SelectedIndexChanged += new System.EventHandler(this.resultsLst_SelectedIndexChanged);
            this.resultsLst.DoubleClick += new System.EventHandler(this.ResultsLstDoubleClick);
            this.resultsLst.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ResultsLstItemCheck);
            this.resultsLst.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ResultsLstMouseMove);
            this.resultsLst.MouseLeave += new System.EventHandler(this.resultsLst_MouseLeave);
            this.resultsLst.Click += new System.EventHandler(this.ResultsLstClick);
            // 
            // mark
            // 
            this.mark.Text = "";
            this.mark.Width = 30;
            // 
            // result
            // 
            this.result.Text = "Result Line";
            this.result.Width = 260;
            // 
            // filename
            // 
            this.filename.Text = "File Name";
            // 
            // columnLineNum
            // 
            this.columnLineNum.Text = "@";
            this.columnLineNum.Width = 35;
            // 
            // columnFileName
            // 
            this.columnFileName.Text = "File Name";
            this.columnFileName.Width = 87;
            // 
            // columnLineText
            // 
            this.columnLineText.Text = "Line Text";
            this.columnLineText.Width = 351;
            // 
            // findGroup
            // 
            this.findGroup.Controls.Add(this.matchCaseChk);
            this.findGroup.Controls.Add(this.wholeWordChk);
            this.findGroup.Controls.Add(this.regexpChk);
            this.findGroup.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.findGroup.Location = new System.Drawing.Point(0, 0);
            this.findGroup.Name = "findGroup";
            this.findGroup.Size = new System.Drawing.Size(312, 41);
            this.findGroup.TabIndex = 4;
            this.findGroup.TabStop = false;
            this.findGroup.Text = "Find";
            // 
            // CopyResultsBtn
            // 
            this.CopyResultsBtn.Location = new System.Drawing.Point(8, 35);
            this.CopyResultsBtn.Name = "CopyResultsBtn";
            this.CopyResultsBtn.Size = new System.Drawing.Size(107, 23);
            this.CopyResultsBtn.TabIndex = 1;
            this.CopyResultsBtn.Text = "Copy To Results";
            this.CopyResultsBtn.UseVisualStyleBackColor = true;
            this.CopyResultsBtn.Click += new System.EventHandler(this.CopyResultsBtn_Click);
            // 
            // PluginUI
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.findGroup);
            this.Controls.Add(this.findBtn);
            this.Controls.Add(this.filterGroup);
            this.Controls.Add(this.findTxt);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.resultsLst);
            this.Name = "PluginUI";
            this.Size = new System.Drawing.Size(854, 322);
            this.tabControl.ResumeLayout(false);
            this.optionsPage.ResumeLayout(false);
            this.replacePage.ResumeLayout(false);
            this.replacePage.PerformLayout();
            this.filterPage.ResumeLayout(false);
            this.foldersPage.ResumeLayout(false);
            this.foldersPage.PerformLayout();
            this.operationsPage.ResumeLayout(false);
            this.filterGroup.ResumeLayout(false);
            this.filterGroup.PerformLayout();
            this.findGroup.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		
		#region settings and updates
        /// <summary>
        /// udate the selected settings
        /// </summary>
        /// <param name="settingsObject"></param>
		public void UpdateSettings(Settings settingsObject)
		{
			autoFeedChk.Checked = settingsObject.FeedAsYouType;

            autoChk.Checked = settingsObject.FindAsYouType;
			//resizeToFit = resize;
			ChangeFilterPresets(settingsObject.FilterPresets);

            resultsLst.ShowGroups = settingsObject.GroupByFile;
		}
		
        /// <summary>
        /// update the class paths list for the find in folder
        /// </summary>
        /// <param name="classPaths">new class paths</param>
		public void UpdateFolderClassPaths(string[] classPaths)
		{
			string[] presets = classPaths;
			folderTxt.BeginUpdate();
			folderTxt.Items.Clear();
			foreach (string itemTxt in presets)
			{
				folderTxt.Items.Add(itemTxt);
			}
			folderTxt.Text = presets[0];
			lastPath = presets[0];
			folderTxt.EndUpdate();
		}
		
        /// <summary>
        /// show or hide the folder tab
        /// </summary>
        /// <param name="flag">show or hide</param>
		private void ShowFolderMode(bool flag)
		{
			if (flag)
			{
				ShowReplaceMode(false);
				plugin.UpdateProjectClassPaths();
				folderFilesChk.Checked = true;
			}
			else
			{
				folderFilesChk.Checked = false;
			}
		}
		
        /// <summary>
        /// focus the find text box
        /// </summary>
		public void EnableFocus()
		{
			EnableFocus(false);
		}
		
        /// <summary>
        /// focus in the find or the replace input box
        /// </summary>
        /// <param name="replace">if true - focus on the replace</param>
		public void EnableFocus(bool replace)
		{
			this.plugin.Panel.Show();
			
			if (!replace)
			{
				findTxt.Focus();
			}
			else
			{
				ShowReplace = true;
				replaceTxt.Focus();
			}
		}
		
        /// <summary>
        /// save the status of the panel
        /// </summary>
		private void SaveState()
		{
			if (state.IndexOf("<>") == 0)
			{
				string pState = "";
				if (autoChk.Checked)
					pState += "A";
				if (autoFeedChk.Checked)
					pState += "F";
				if (MatchCase)
					pState += "I";
				if (WholeWord)
					pState += "W";
				if (RegExp)
					pState += "R";
				if (openFilesChk.Checked)
					pState += "O";
				state = pState;
			}
		}
		
        /// <summary>
        /// restore the status of the panel, after some operations that changed it
        /// </summary>
		private void RestoreState()
		{
			autoChk.Checked = state.IndexOf("A") > -1;
			autoFeedChk.Checked = state.IndexOf("F") > -1;
			MatchCase = state.IndexOf("I") > -1;
			WholeWord = state.IndexOf("W") > -1;
			RegExp = state.IndexOf("R") > -1;
			openFilesChk.Checked = state.IndexOf("O") > -1;
			state = "<>";
		}

        /// <summary>
        /// Stops the parse timer if not enabled.
        /// </summary>
        public void Terminate()
        {
        }

		#endregion
		
		#region Find Code
        /// <summary>
        /// set the text in the find box
        /// </summary>
        /// <param name="newText">new text</param>
		public void SetFindText(string newText)
		{
			SetFindText(newText, false);
		}
		
        /// <summary>
        /// Set the text in the find box, no matter what are the settings
        /// </summary>
        /// <param name="newText">new text</param>
        /// <param name="force">true to force change it</param>
		public void SetFindText(string newText, bool force)
		{
			if ((autoFeedChk.Checked) || force)
			{
				if (ShowReplace)
				{
					replaceTxt.Text = newText;
				}
				else
				{
					findTxt.Text = newText;
				}
			}
		}
		
		///<summary>
		///lists all the results in the list box
		///given a results object
		///</summary>
		public void ListAllResults(FindResults results)
		{
			if (state.IndexOf("<>") == 0)
			{
				resultsLst.BeginUpdate();
				resultsLst.Items.Clear();
                resultsLst.Groups.Clear();
				FindMatch match = results.FirstResult();
                String file = "";
                ListViewGroup gr = null;
				while (match != null)
				{
                    if (file != match.FileName)
                    {
                        file = match.FileName;
                        gr = new ListViewGroup(file, HorizontalAlignment.Left);

                        gr.Name = file;
                        gr.Header = file;
                        this.resultsLst.Groups.Add(gr);
                    }

                    AddMatchToGroup(gr, match);

					match = results.NextResult();
				}
//				if (resultsLst.Items.Count > 0)
//					resultsLst.EnsureVisible(resultsLst.Items.Count-1);
				CheckListItems();
				resultsLst.EndUpdate();
			}
		}
		
		///<summary>
		/// Finds a text in open document, or all open documents and list it.
        /// using text in find input box
		/// </summary>
		public void ListAllFindText()
		{
			ListAllFindText(findTxt.Text);
		}
		
        /// <summary>
        /// Finds a text in open document, or all open documents and list it
        /// </summary>
        /// <param name="Text">text to find</param>
		public void ListAllFindText(string Text)
		{
			ListAllFindText(Text, (plugin.Settings as Settings).IgnoreBelow);
		}
		
        /// <summary>
        /// Finds a text in open document, or all open documents and list it
        /// </summary>
        /// <param name="Text">text to find</param>
        /// <param name="minChars">characters threshold</param>
		public void ListAllFindText(string Text, int minChars)
		{
			if (Text.Length >= minChars)
			{
				resultsLst.Tag = folderFilesChk.Checked ? "V": "X";
				DefaultReplaceCheck();
				FindResults results;
				if (folderFilesChk.Checked)
				{
					results = plugin.GetFindInFolderResultsList(Text, folderTxt.Text, fileMaskTxt.Text, searchSubfoldersChk.Checked);
					folderFilesChk.Checked = false;
				}
				else if (openFilesChk.Checked)
				{
					results = plugin.GetAllDocumentsResultsList(Text);
				}
				else
				{
					results = plugin.GetResultsList(Text);
				}
				resultsLst.Columns[2].Text = Text;
				ListAllResults(results);
			}
		}

        /// <summary>
        /// adds a match item to a list group
        /// </summary>
        /// <param name="gr">a group</param>
        /// <param name="match">the match to add to the group</param>
        private void AddMatchToGroup(ListViewGroup gr, FindMatch match)
        {
            ListViewItem item = getListItemFromMatch(match);
            item.Group = gr;
            gr.Items.Add(item);
            AddItemToList(item);
        }

        /// <summary>
        /// Add a list view item to the list
        /// </summary>
        /// <param name="item">A list view item to add</param>
        private void AddItemToList(ListViewItem item)
        {
            this.resultsLst.Items.Add(item);
        }

		/// <summary>
		/// Add a match item to the list
		/// </summary>
		/// <param name="m">A match item</param>
		public void AddMatchToList(FindMatch m)
		{
			AddItemToList(getListItemFromMatch(m));
		}

        /// <summary>
        /// create a list item that represnts a match
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        private ListViewItem getListItemFromMatch(FindMatch m)
        {
            string first = " ";
            if (m.FileName == plugin.CurFile)
                first = ">";
            ListViewItem item = new ListViewItem(first, 0);
            item.Tag = m;
            item.SubItems.Add("" + (m.Line + 1));
            item.SubItems.Add(m.LineText.Trim());
            item.SubItems.Add(m.FileName.Substring(m.FileName.LastIndexOf("\\") + 1));
            return item;
        }

		/// <summary>
		/// Sets the flag of "find as you type"
		/// </summary>
		/// <param name="val">New value</param>
		public void SetFindAsYouType(bool val)
		{
			autoChk.Checked = val;
		}
		
		#endregion
		
		#region Replace code
        /// <summary>
        /// check the list items that need to be checked according to the settings
        /// </summary>
		private void CheckListItems()
		{
			if (state.IndexOf("<>") == 0)
			{
				try
				{
					string curFile = plugin.CurFile;
					string filterText = filterTxt.Tag as string;
					foreach (ListViewItem item in resultsLst.Items)
					{
						FindMatch m = item.Tag as FindMatch;
						if (checkAllRdo.Checked)
						{
							item.Checked = true;
						}
						else if (checkNoneRdo.Checked)
						{
							item.Checked = false;
						}
						else if (checkFileRdo.Checked)
						{
							item.Checked = (m.FileName == curFile);
						}
						else if (checkSelectonRdo.Checked)
						{
							int selStaert = m.Scintilla.SelectionStart;
							int selEnd = m.Scintilla.SelectionEnd;
							bool inRange = m.Position > selStaert & m.Position < selEnd;
							item.Checked = (m.FileName == curFile) & inRange;
						}
						else if (checkFilterRdo.Checked)
						{
							item.Checked = IsMatchInItem(item, 2, filterText);
							
						}
                        HilightItem(item, item.Checked);
					}
					UpdateStatusBar();
				}
				catch
				{
					checkNoneRdo.Checked = true;
				}
			}
		}
		
        /// <summary>
        /// called when a selection was changed
        /// </summary>
		public void SelectionChanged()
		{
			SelectionChanged(true);
		}
		
        /// <summary>
        /// Called when a selection is changed in the scientilla
        /// </summary>
        /// <param name="flag">Is there or isn't there a selection</param>
		public void SelectionChanged(bool flag)
		{
			if (flag)
			{
				checkSelectonRdo.Checked = true;
			}
			else
			{
				DefaultReplaceCheck();
			}
			CheckListItems();
		}
		
        /// <summary>
        /// Goes thrugh all the entries and if they are checked, it replaces the text
        /// </summary>
        /// <param name="replaceText">the text to replace</param>
		private void ReplaceSelectedEntries(string replaceText)
		{
            ITabbedDocument document = PluginBase.MainForm.CurrentDocument;
            ScintillaControl doc = document.SciControl;

			SaveState();
			autoFeedChk.Checked = false;
			autoChk.Checked = false;
			string workingFile = "";
			if (replaceShown && replaceText != "")
			{
                document = PluginBase.MainForm.CurrentDocument;
                doc = document.SciControl;
				doc.BeginUndoAction();
				int numOfEntries = resultsLst.Items.Count;
				for(int i= numOfEntries-1; i >= 0; i--)
				{
					ListViewItem item = resultsLst.Items[i];
					if (item.Checked)
					{
						FindMatch m = item.Tag as FindMatch;
						string fileName = m.FileName;

                        // switch to the next file
						if (fileName != workingFile) {
							doc.EndUndoAction();
							plugin.MainForm.OpenEditableDocument(fileName);
							workingFile = fileName;
                            document = PluginBase.MainForm.CurrentDocument;
                            doc = document.SciControl;
							doc.BeginUndoAction();
						}
						doc.MBSafeSetSel(m.Position, m.Text);
                        string rep = replaceText.Clone() as string;
                        if (regExReplaceChk.Checked) rep = ExpandReplaceGroups(rep, m);
						doc.ReplaceSel(rep);
					}
				}
				doc.EndUndoAction();
				
			}
			RestoreState();
			ShowOfr();
		}

        /// <summary>
        /// Replace regular expressions groups in replacement text
        /// </summary>
        /// <param name="escapedText">Text to expand</param>
        /// <param name="match">Search result (for reinjecting groups)</param>
        public string ExpandReplaceGroups(string text, FindMatch match)
        {
            if (text.IndexOf('$') < 0) return match.Text;
            for (int i = 0; i < match.Groups.Count; i++)
                text = text.Replace("$" + i, match.Groups[i].Value);
            return text;
        }
		
        /// <summary>
        /// Open all files found in "Find in files" and make the search again
        /// </summary>
		private void OpenAndResearch()
		{
			SaveState();
			string findText = findTxt.Text;
			string workingFile = "";
			int numOfEntries = resultsLst.Items.Count;
			for(int i= numOfEntries-1; i >= 0; i--)
			{
				ListViewItem item = resultsLst.Items[i];
				if (item.Checked)
				{
					FindMatch m = item.Tag as FindMatch;
					string fileName = m.FileName;
					if (fileName != workingFile) {
						plugin.MainForm.OpenEditableDocument(fileName);
						workingFile = fileName;
					}
				}
			}
			RestoreState();
			ListAllFindText(findText);
			ShowOfr();
		}
		
        /// <summary>
        /// Shows the Open and replace button instead of the normal replace
        /// </summary>
		private void ShowOfr()
		{
			string fif = "" + resultsLst.Tag;
			bool vis = (fif.IndexOf("V") != 0);
			replaceBtn.Visible = vis;
			ofrBtn.Visible = !vis;
		}

        /// <summary>
        /// Hides the checkboxes
        /// </summary>
        private void HideCheckboxes()
        {
			resultsLst.BeginUpdate();
            resultsLst.Visible = false;
				resultsLst.CheckBoxes = false;
				resultsLst.MultiSelect = false;
            resultsLst.Visible = true;
            resultsLst.EndUpdate();
        }

        /// <summary>
        /// Shows the checkboxes in the list
        /// </summary>
        private void ShowCheckboxes()
        {
			resultsLst.BeginUpdate();
            resultsLst.Visible = false;
				resultsLst.CheckBoxes = true;
				resultsLst.MultiSelect = true;
			CheckListItems();
            resultsLst.Visible = true;
            resultsLst.EndUpdate();
        }

        /// <summary>
        /// Shows or hide the replace tab
        /// </summary>
        /// <param name="flag">true - shows the replace tab</param>
		private void ShowReplaceMode(bool flag)
		{
			DefaultReplaceCheck();
			if (flag)
			{
                ShowCheckboxes();
				ShowOfr();
			}
			replaceShown = flag;
		}
		#endregion
		
		#region filter code
        /// <summary>
        /// Updates the status bar with the search results
        /// </summary>
		private void UpdateStatusBar()
		{
			this.resultsLbl.Text = "Results: "+resultsLst.Items.Count+". Selected: "+resultsLst.CheckedItems.Count;
		}
		
        /// <summary>
        /// Highlight the items in the list that match the filter
        /// </summary>
        /// <param name="filterText"></param>
		private void HilightFilteredList(string filterText)
		{
			filterTxt.Tag = "";
			DefaultReplaceCheck();
			if (filterText.Length > 0)
			{
				
				try
				{
					Regex.IsMatch("test pattern", filterTxt.Text);
					filterTxt.Tag = Regex.Replace(filterTxt.Text, "@FIND", findTxt.Text);
					if (!checkFilterRdo.Checked)
						checkFilterRdo.Checked = true;
				}
				catch
				{
					filterTxt.Tag = Regex.Unescape(filterText);
					checkNoneRdo.Checked = true;
				}
				CheckListItems();
			}
			else
			{
				
			}
		}
		
        /// <summary>
        /// Highlight an item
        /// </summary>
        /// <param name="item">List view item to highlight</param>
        /// <param name="isHilight">true - to highlight</param>
		private void HilightItem(ListViewItem item, bool isHilight)
		{
			Font font = item.Font;
			if (isHilight)
			{
				item.Font = new Font(font, FontStyle.Regular);
                item.BackColor = Color.Lavender;
			}
			else
			{
				item.Font = new Font(font, FontStyle.Regular);
                item.BackColor = Color.White;
			}
		}
		
        /// <summary>
        /// Return true if the item match the filter pattern, entered in the filter input box
        /// </summary>
        /// <param name="item">a list view item</param>
        /// <param name="index">index of subitem (column)</param>
        /// <param name="pattern">pattern to match</param>
        /// <returns></returns>
		private bool IsMatchInItem(ListViewItem item, int index, string pattern)
		{
			if (pattern.Length > 0)
			{
				bool ret = Regex.IsMatch(item.SubItems[index].Text, pattern, RegexOptions.IgnoreCase);
				return ret;
			}
			else
				return false;
		}
		
		/// <summary>
		/// Change the presets for the filter combo box
		/// </summary>
		/// <param name="newPresets"></param>
		private void ChangeFilterPresets(string[] newPresets)
		{
            if (newPresets != null)
            {
                string[] presets = newPresets;
                filterTxt.BeginUpdate();
                filterTxt.Items.Clear();
                foreach (string itemTxt in presets)
                {
                    filterTxt.Items.Add(itemTxt);
                }
                filterTxt.EndUpdate();
            }
		}
		
        /// <summary>
        /// check the default filter mode, is "filter" if there is a pattern entered of "file" if no
        /// </summary>
		private void DefaultReplaceCheck()
		{
			
			if (!replaceShown)// && !openFilesChk.Checked)
			{
				FilterRadioCheck();
			}
			else
			{
				checkFileRdo.Checked = true;
			}
			CheckListItems();
		}
		
        /// <summary>
        /// Check the filter radio. 
        /// If the RegEx is not valid it check the "file" mode
        /// </summary>
		private void FilterRadioCheck()
		{

            ScintillaControl sci =plugin.CurSciControl;
            if (sci != null)
            {
                if (sci.SelectionStart != sci.SelectionEnd)
                {
                    checkSelectonRdo.Checked = true;
                }
                else if (filterTxt.Text.Length > 0)
                {
                    checkFilterRdo.Checked = true;
                }
                else
                {
                    checkFileRdo.Checked = true;
                }
            }
		}
		#endregion

        #region operation code

        /// <summary>
        /// switch to operation mode, show the checkboxes
        /// </summary>
        /// <param name="p">is in operation</param>
        private void ShowOperationMode(bool p)
        {
            if (p)
            {
                ShowCheckboxes();
            }
        }


        /// <summary>
        /// adds bookmarks to all selected items
        /// </summary>
        private void BookmarkSearchResults()
        {
            ITabbedDocument document = PluginBase.MainForm.CurrentDocument;
            ScintillaControl doc = document.SciControl;

			SaveState();
    		string workingFile = "";
			doc.BeginUndoAction();
			int numOfEntries = resultsLst.Items.Count;
			for(int i= numOfEntries-1; i >= 0; i--)
			{
				ListViewItem item = resultsLst.Items[i];
				if (item.Checked)
				{
					FindMatch m = item.Tag as FindMatch;
					string fileName = m.FileName;
					if (fileName != workingFile) {
						doc.EndUndoAction();
						plugin.MainForm.OpenEditableDocument(fileName);
						workingFile = fileName;
                        document = PluginBase.MainForm.CurrentDocument;
                        doc = document.SciControl;
						doc.BeginUndoAction();
					}

                    doc.MarkerAdd(m.Line, 0);
				}
			}

            RestoreState();
            
            ShowReplace = false;
        }

        private void CopyToResultsPanel()
        {
            Globals.MainForm.CallCommand("PluginCommand", "ResultsPanel.ClearResults");
            foreach (ListViewItem item in resultsLst.Items)
            {
                FindMatch m = item.Tag as FindMatch;
                int column = m.Column;
                TraceManager.Add(m.FileName + ":" + (m.Line+1).ToString() + ": characters " + m.Column + "-" + (m.Column + m.Text.Length) + " : " + m.LineText.Trim(), (Int32)TraceType.Info);
            }
            Globals.MainForm.CallCommand("PluginCommand", "ResultsPanel.ShowResults");

            ShowReplace = false;
        }

        /// <summary>
        /// Deletes all the selected (checked) results
        /// </summary>
        private void DeleteResultsLines()
        {
            ITabbedDocument document = PluginBase.MainForm.CurrentDocument;
            ScintillaControl doc = document.SciControl;

			SaveState();
    		string workingFile = "";
			doc.BeginUndoAction();
			int numOfEntries = resultsLst.Items.Count;
			for(int i= numOfEntries-1; i >= 0; i--)
			{
				ListViewItem item = resultsLst.Items[i];
				if (item.Checked)
				{
					FindMatch m = item.Tag as FindMatch;
					string fileName = m.FileName;
					if (fileName != workingFile) {
						doc.EndUndoAction();
						plugin.MainForm.OpenEditableDocument(fileName);
						workingFile = fileName;
                        document = PluginBase.MainForm.CurrentDocument;
                        doc = document.SciControl;
						doc.BeginUndoAction();
					}
                    doc.SetSel(m.Position, m.Position);
                    doc.LineDelete();
				}
			}

			doc.EndUndoAction();
            RestoreState();
            ShowReplace = false;
        }
        #endregion


        #region options properties
        /// <summary>
        /// Is the mach case sensitive
        /// </summary>
        public bool MatchCase
		{
			get {return matchCaseChk.Checked; }
			set {matchCaseChk.Checked = value;}
		}
        /// <summary>
        /// Select to match only whole word
        /// </summary>
		public bool WholeWord
		{
			get {return wholeWordChk.Checked; }
			set {wholeWordChk.Checked = value; }
		}
        /// <summary>
        /// Check as Regular expression or normal text
        /// </summary>
		public bool RegExp
		{
			get {return regexpChk.Checked; }
			set {regexpChk.Checked = value; }
		}
        /// <summary>
        /// Shows the replace tab
        /// </summary>
		public bool ShowReplace
		{
			get {return replaceShown; }
			set
			{
				if (value)
				{
					tabControl.SelectedTab = replacePage;
				}
				else
				{
					tabControl.SelectedIndex = 0;
				}
				replaceShown = value;
			}
		}
        /// <summary>
        /// Change the search path for "Find in Files"
        /// </summary>
		public string SearchPath
		{
			get {return folderTxt.Text; }
			set { folderTxt.Text = value; }
		}
		#endregion
		
		#region Controlls Events
		private void FindBtnClick(object sender, System.EventArgs e)
		{
			ListAllFindText(findTxt.Text, 1);
			//CheckListItems();
		}
		
		private void ResultsLstDoubleClick(object sender, System.EventArgs e)
		{
			
			ListViewItem item = this.resultsLst.SelectedItems[0];
			if (item == null) return;
			FindMatch m = (FindMatch)item.Tag;
			int position = m.Position;
			
			plugin.GotoPosAndFocus(m.FileName, position, m.Text.Length);
		}
		
		private void FindTxtTextChanged(object sender, System.EventArgs e)
		{
			if(autoChk.Checked)
			{
				ListAllFindText(findTxt.Text);
			}
		}
		
		private void OptionsChkCheckedChanged(object sender, System.EventArgs e)
		{
			ListAllFindText();
		}
		
	
		private void ReplaceBtnClick(object sender, System.EventArgs e)
		{
			string find = findTxt.Text;
			string replace = replaceTxt.Text;
			string curFile = plugin.CurFile;
			int curPosition = plugin.CurPosition;
			replace = Regex.Replace(replace, "@FIND", find);
			ReplaceSelectedEntries(replace);
			//ListAllFindText(replace);
			//replaceTxt.Text = "@FIND";
//			if (plugin.HideReplace)
//				ShowReplace = false;
			if ((plugin.Settings as Settings).AutoHideReplace) {
				ShowReplace = false;
			}
			plugin.GotoPosAndFocus(curFile, curPosition, 0);
		}
		
		private void CheckRdoCheckedChanged(object sender, System.EventArgs e)
		{
			CheckListItems();
		}
		
		private void ResultsLstClick(object sender, System.EventArgs e)
		{
			if (ShowReplace)
			{
				checkcCustomeRdo.Checked = true;
			}
		}
		
		private void ResultsLstItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			ListViewItem item = resultsLst.Items[e.Index];
			HilightItem(item, (e.NewValue == CheckState.Checked));
		}
		
		private void FilterTxtTextChanged(object sender, System.EventArgs e)
		{
			HilightFilteredList(filterTxt.Text);
		}
		
		private void SwtchFindReplaceBtnClick(object sender, System.EventArgs e)
		{
			string tempTxt = replaceTxt.Text;
			replaceTxt.Text = findTxt.Text;
			findTxt.Text = tempTxt;
		}
		
		private void FilterBtnClick(object sender, System.EventArgs e)
		{
			HilightFilteredList(filterTxt.Text);
		}
		
		private void RegexHelpBtnClick(object sender, System.EventArgs e)
		{
			MessageBox.Show("\\t Matches a tab \\u0009.\n\\e Matches an escape \\u001B.\n\\040 Matches an ASCII character as octal (up to three digits); numbers with no leading zero are backreferences \n\\x20 Matches an ASCII character using hexadecimal representation.\n\\cC Matches an ASCII control character; for example, \\cC is control-C.\n\\ When followed by a character that is not recognized as an escaped character, matches that character. For example, \\*.\n---------------------\n"+
			                ". Matches any character except \\n.\n[aeiou] Matches any single character included in the specified set of characters.\n[^aeiou] Matches any single character not in the specified set of characters. [0-9a-fA-F] Use of a hyphen (–) allows specification of contiguous character ranges.\n\\w Matches any word character.equivalent to [a-zA-Z_0-9].\n\\W Matches any nonword character. equivalent to [^a-zA-Z_0-9].\n\\s Matches any white-space character. Equivalent to [ \\f\\n\\r\\t\\v].\n\\S Matches any non-white-space character. Equivalent to [^ \\f\\n\\r\\t\\v].\n\\d Matches any decimal digit.\n\\D Matches any nondigit.\n---------------------\n"+
			                "\\A Specifies that the match must occur at the beginning of the string\n\\Z Specifies that the match must occur at the end of the string or before \n at the end of the string\n\\z Specifies that the match must occur at the end of the string\n\\b Specifies that the match must occur on word boundaries — that is, at the first or last characters in words separated by any nonalphanumeric characters.\n\\B Specifies that the match must not occur on a \\b boundary.\n---------------------\n"+
			                "* Specifies zero or more matches; Equivalent to {0,}.\\+ Specifies one or more matches; Equivalent to {1,}.\n? Specifies zero or one matches; Equivalent to {0,1}. \n{n} Specifies exactly n matches;\n{n,} Specifies at least n matches;\n{n,m} Specifies at least n, but no more than m, matches.\n---------------------\n"+
			                "| Matches any one of the terms separated by the | (vertical bar) character; The leftmost successful match wins.\n(?=   ) Zero-width positive lookahead assertion. Continues match only if the subexpression matches at this position on the right. \n(?!   ) Zero-width negative lookahead assertion. Continues match only if the subexpression does not match at this position on the right. \n(?<=   ) Zero-width positive lookbehind assertion. Continues match only if the subexpression matches at this position on the left. For example, \n(?<!   ) Zero-width negative lookbehind assertion. Continues match only if the subexpression does not match at the position on the left."+
			                
			                "","Regular Expression Quick Refference");
			
		}
		
		private void BrowseBtnClick(object sender, System.EventArgs e)
		{
			fileBrowserDlg.SelectedPath = folderTxt.Text;
			if (fileBrowserDlg.ShowDialog(this) == DialogResult.OK)
				folderTxt.Text = fileBrowserDlg.SelectedPath;
		}
		
		private void FolderFilesChkCheckedChanged(object sender, System.EventArgs e)
		{
			if (folderFilesChk.Checked) 
			{
				SaveState();
			}
			else
			{
				RestoreState();
			}
			autoChk.Checked = !folderFilesChk.Checked;
		}
		
		private void FolderTxtSelectedIndexChanged(object sender, System.EventArgs e)
		{
			lastPath = folderTxt.Text;
		}
		
		private void TabControlSelectedIndexChanged(object sender, System.EventArgs e)
		{
			TabPage selected = tabControl.SelectedTab;
            HideCheckboxes();
			ShowReplaceMode((selected.Name == "replacePage"));
            ShowOperationMode((selected.Name == "operationsPage"));
			ShowFolderMode((selected.Name == "foldersPage"));
		}
		
		void copyFindReplaceBtnClick(object sender, System.EventArgs e)
		{
			replaceTxt.Text = findTxt.Text;
		}
		void Button1Click(object sender, System.EventArgs e)
		{
			replaceTxt.Text = "@FIND";
		}
		
		void OfrBtnClick(object sender, System.EventArgs e)
		{
			OpenAndResearch();
		}
		
		void ResultsLstMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// create tooltip
			if (toolTip == null) {
				toolTip = new ToolTip();
				toolTip.ShowAlways = true;
				toolTip.AutoPopDelay = 10000;
			}
			// display entry details (filename, line, description)
			ListViewItem item = resultsLst.GetItemAt(e.X, e.Y);
			if (item == null) {
				toolTip.SetToolTip(resultsLst, "");
				return;
			}
			FindMatch m = (item.Tag) as FindMatch;
			ScintillaControl sci = m.Scintilla;
			int line =  m.Line;
			string tooltipText = String.Format("{1}    {0}:\n",item.SubItems[1].Text,item.SubItems[3].Text);
			if (sci != null)
			{
                if (m.FileName == plugin.CurFile && m.FileName.Contains(".as"))
                {
                    ASCompletion.Completion.ASResult res = ASCompletion.Context.ASContext.Context.GetDeclarationAtLine(line);
                    tooltipText += String.Format("In       {0}:\n", res.Member);
                }



				string prev = sci.GetLine(line-1).Trim();
				string next = sci.GetLine(line+1).Trim();
				tooltipText += String.Format("\n   {1}\n        {0}\n   {2} ", item.SubItems[2].Text, prev, next);
			}
			else
			{
				tooltipText += item.SubItems[2].Text;
			}
			toolTip.SetToolTip(resultsLst,tooltipText);
		}

        private void bookmarkBtn_Click(object sender, EventArgs e)
        {
            BookmarkSearchResults();
        }

        private void CopyResultsBtn_Click(object sender, EventArgs e)
        {
            CopyToResultsPanel();
        }


        private void deleteBtn_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Are you sure you want delete lines?", "Delete confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{
                DeleteResultsLines();
            //}
        }
        private void clearFilterBtn_Click(object sender, EventArgs e)
        {
            filterTxt.Text = "";
        }


		#endregion

        private void regexpChk_CheckedChanged(object sender, EventArgs e)
        {
            regExReplaceChk.Enabled = regexpChk.Checked;
        }

        private void resultsLst_MouseLeave(object sender, EventArgs e)
        {
            // needs research... if I want to change the context of the current file while running
            //ASCompletion.Context.ASContext.Context.CurrentFile = plugin.CurFile;
        }

        private void resultsLst_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

	}
}
