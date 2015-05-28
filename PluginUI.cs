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
using WeifenLuo.WinFormsUI.Docking;


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
        private ComboBox findTxt;
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
        private Button clearReplaceTxt;
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
        private RadioButton checkAllRdo;
        private ColumnHeader at;
        private ListView resultsLst;
        private FolderBrowserDialog fileBrowserDlg;
        private CheckBox regexpChk;
        private CheckBox wholeWordChk;
        private CheckBox matchCaseChk;
        private ColumnHeader result;
        private ColumnHeader filename;
        private ColumnHeader mark;
        private TabPage operationsPage;
        private Button deleteBtn;
        private Button bookmarkBtn;
        private Button clearFilterBtn;
        private CheckBox regExReplaceChk;
        private Button CopyResultsBtn;
        private ListViewItem currentItem;
        private bool toolTipShow;
        private Splitter splitter;
        private Panel optionsPanel;
        private bool inReplace;
        private FlowLayoutPanel filterRadioFlow;
        private FlowLayoutPanel findChkFlow;
        private FlowLayoutPanel replacePageFlow;
        private FlowLayoutPanel filterPageFlow;
        private FlowLayoutPanel foldersPageFlow;
        private FlowLayoutPanel operationsPageFlow;
//		private bool classPathRoot;
		
		public PluginUI(PluginMain pluginMain)
		{
			InitializeComponent();
			
			// reference to the plugin interface
			this.plugin = pluginMain;
			toolTip.Active = true;
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
            this.findTxt = new System.Windows.Forms.ComboBox();
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
            this.regexHelpBtn = new System.Windows.Forms.Button();
            this.regexpChk = new System.Windows.Forms.CheckBox();
            this.wholeWordChk = new System.Windows.Forms.CheckBox();
            this.matchCaseChk = new System.Windows.Forms.CheckBox();
            this.ofrBtn = new System.Windows.Forms.Button();
            this.clearReplaceTxt = new System.Windows.Forms.Button();
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
            this.CopyResultsBtn = new System.Windows.Forms.Button();
            this.resultsLbl = new System.Windows.Forms.Label();
            this.at = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.resultsLst = new System.Windows.Forms.ListView();
            this.mark = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.result = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileBrowserDlg = new System.Windows.Forms.FolderBrowserDialog();
            this.splitter = new Splitter();
            this.optionsPanel = new Panel();
            this.filterRadioFlow = new FlowLayoutPanel();
            this.findChkFlow = new FlowLayoutPanel();
            this.replacePageFlow = new FlowLayoutPanel();
            this.filterPageFlow = new FlowLayoutPanel();
            this.foldersPageFlow = new FlowLayoutPanel();
            this.operationsPageFlow = new FlowLayoutPanel();
            this.tabControl.SuspendLayout();
            this.optionsPage.SuspendLayout();
            this.replacePage.SuspendLayout();
            this.filterPage.SuspendLayout();
            this.foldersPage.SuspendLayout();
            this.operationsPage.SuspendLayout();
            this.filterRadioFlow.SuspendLayout();
            this.findChkFlow.SuspendLayout();
            this.replacePageFlow.SuspendLayout();
            this.filterPageFlow.SuspendLayout();
            this.foldersPageFlow.SuspendLayout();
            this.operationsPageFlow.SuspendLayout();
            this.SuspendLayout();
            this.hideLeftSide();
            // 
            // findTxt
            // 
            this.findTxt.Name = "findTxt";
            this.findTxt.Dock = DockStyle.Top;
            this.findTxt.SelectedValueChanged += new System.EventHandler(this.selectedItemFindTxt);
            this.findTxt.TextChanged += new System.EventHandler(this.FindTxtTextChanged);
            this.findTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDownHandler);
            // 
            // resultsLbl
            // 
            this.resultsLbl.Name = "resultsLbl";
            this.resultsLbl.Text = "----";
            this.resultsLbl.AutoSize = true;
            // 
            // checkNoneRdo
            //            
            this.checkNoneRdo.Name = "checkNoneRdo";
            this.checkNoneRdo.Text = "None";
            this.checkNoneRdo.AutoSize = true;
            this.toolTip.SetToolTip(this.checkNoneRdo, "Uncheck all the entries to not replace");
            this.checkNoneRdo.CheckedChanged += new System.EventHandler(this.CheckRdoCheckedChanged);
            // 
            // checkcCustomeRdo
            // 
            this.checkcCustomeRdo.Name = "checkcCustomeRdo";
            this.checkcCustomeRdo.Text = "Custome";
            this.checkcCustomeRdo.AutoSize = true;
            this.toolTip.SetToolTip(this.checkcCustomeRdo, "Default for manually checked entries.");
            this.checkcCustomeRdo.CheckedChanged += new System.EventHandler(this.CheckRdoCheckedChanged);
            // 
            // checkFileRdo
            // 
            this.checkFileRdo.Checked = true;
            this.checkFileRdo.Name = "checkFileRdo";
            this.checkFileRdo.Text = "File";
            this.checkFileRdo.AutoSize = true;
            this.toolTip.SetToolTip(this.checkFileRdo, "Check all the entries of the current file. (Same as All if \"search all opened fil" + "es\" is unchecked)");
            this.checkFileRdo.CheckedChanged += new System.EventHandler(this.CheckRdoCheckedChanged);
            // 
            // checkSelectonRdo
            // 
            this.checkSelectonRdo.Name = "checkSelectonRdo";
            this.checkSelectonRdo.Text = "Selection";
            this.checkSelectonRdo.AutoSize = true;
            this.toolTip.SetToolTip(this.checkSelectonRdo, "Check all the checkboxes that inside the selection.");
            this.checkSelectonRdo.CheckedChanged += new System.EventHandler(this.CheckRdoCheckedChanged);
            // 
            // checkFilterRdo
            // 
            this.checkFilterRdo.Name = "checkFilterRdo";
            this.checkFilterRdo.Text = "Filter";
            this.checkFilterRdo.AutoSize = true;
            this.toolTip.SetToolTip(this.checkFilterRdo, "Check the entries that match the filter string");
            this.checkFilterRdo.CheckedChanged += new System.EventHandler(this.CheckRdoCheckedChanged);
            // 
            // checkAllRdo
            // 
            this.checkAllRdo.Name = "checkAllRdo";
            this.checkAllRdo.Text = "All";
            this.checkAllRdo.AutoSize = true;
            this.toolTip.SetToolTip(this.checkAllRdo, "Check all the entries to replace");
            this.checkAllRdo.CheckedChanged += new System.EventHandler(this.CheckRdoCheckedChanged);
            // 
            // flowLayPan
            //
            this.filterRadioFlow.AutoSize = true;
            this.filterRadioFlow.Controls.Add(this.resultsLbl);
            this.filterRadioFlow.SetFlowBreak(this.resultsLbl, true);
            this.filterRadioFlow.Controls.Add(checkNoneRdo);
            this.filterRadioFlow.Controls.Add(checkcCustomeRdo);
            this.filterRadioFlow.Controls.Add(checkFileRdo);
            this.filterRadioFlow.Controls.Add(checkSelectonRdo);
            this.filterRadioFlow.Controls.Add(checkFilterRdo);
            this.filterRadioFlow.Controls.Add(checkAllRdo);
            this.filterRadioFlow.FlowDirection = FlowDirection.LeftToRight;
            this.filterRadioFlow.Dock = DockStyle.Bottom;
            this.ResumeLayout();
            // 
            // folderFilesChk
            // 
            this.folderFilesChk.Name = "folderFilesChk";
            this.folderFilesChk.Text = "All Files in Folder";
            this.folderFilesChk.ThreeState = true;
            this.folderFilesChk.AutoSize = true;
            this.toolTip.SetToolTip(this.folderFilesChk, "Check this to set the next search to be in alll files in the above directory.");
            this.folderFilesChk.CheckStateChanged += new System.EventHandler(this.FolderFilesChkCheckedStateChanged);
            // 
            // browseBtn
            // 
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Text = "Browse...";
            this.browseBtn.AutoSize = true;
            this.toolTip.SetToolTip(this.browseBtn, "Browse for a folder to search in.");
            this.browseBtn.Click += new System.EventHandler(this.BrowseBtnClick);
            // 
            // searchSubfoldersChk
            // 
            this.searchSubfoldersChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.searchSubfoldersChk.Name = "searchSubfoldersChk";
            this.searchSubfoldersChk.Text = "Subfolders";
            this.searchSubfoldersChk.AutoSize = true;
            this.toolTip.SetToolTip(this.searchSubfoldersChk, "Also search in subfolders.");
            this.searchSubfoldersChk.CheckedChanged += new System.EventHandler(this.FolderFilesChkCheckedStateChanged);
            // 
            // fileMaskTxt
            // 
            this.fileMaskTxt.Name = "fileMaskTxt";
            this.toolTip.SetToolTip(this.fileMaskTxt, "Specify the file mask to search in.");
            // 
            // openFilesChk
            // 
            this.openFilesChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.openFilesChk.Name = "openFilesChk";
            this.openFilesChk.Dock = DockStyle.Top;
            this.openFilesChk.Text = "All Opened Files";
            this.openFilesChk.AutoSize = true;
            this.toolTip.SetToolTip(this.openFilesChk, "Show the reslts from all opened files.");
            this.openFilesChk.CheckedChanged += new System.EventHandler(this.OptionsChkCheckedChanged);
            // 
            // autoChk
            // 
            this.autoChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.autoChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoChk.Name = "autoChk";
            this.autoChk.Dock = DockStyle.Top;
            this.autoChk.Text = "Automatic find";
            this.autoChk.AutoSize = true;
            this.toolTip.SetToolTip(this.autoChk, "List results immediately  while typing in the find box.");
            // 
            // autoFeedChk
            // 
            this.autoFeedChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoFeedChk.Name = "autoFeedChk";
            this.autoFeedChk.Dock = DockStyle.Top;
            this.autoFeedChk.Text = "Update as you type";
            this.autoFeedChk.AutoSize = true;
            this.toolTip.SetToolTip(this.autoFeedChk, "Update the find box when typing in the editor");
            // 
            // regexHelpBtn
            // 
            this.regexHelpBtn.Name = "regexHelpBtn";
            this.regexHelpBtn.Text = "?";
            this.regexHelpBtn.AutoSize = true;
            this.toolTip.SetToolTip(this.regexHelpBtn, "Help about regular expressions");
            this.regexHelpBtn.Click += new System.EventHandler(this.RegexHelpBtnClick);
            // 
            // regexpChk
            // 
            this.regexpChk.Name = "regexpChk";
            this.regexpChk.Text = "RegEx";
            this.regexpChk.AutoSize = true;
            this.toolTip.SetToolTip(this.regexpChk, "Threat the find text as Regular Expression");
            this.regexpChk.CheckedChanged += new System.EventHandler(this.regexpChk_CheckedChanged);
            // 
            // wholeWordChk
            // 
            this.wholeWordChk.Name = "wholeWordChk";
            this.wholeWordChk.Text = "Whole Word";
            this.wholeWordChk.AutoSize = true;
            this.toolTip.SetToolTip(this.wholeWordChk, "Search for whole word only");
            // 
            // matchCaseChk
            // 
            this.matchCaseChk.Name = "matchCaseChk";
            this.matchCaseChk.Text = "Match Case";
            this.matchCaseChk.AutoSize = true;
            this.toolTip.SetToolTip(this.matchCaseChk, "Ignore the case OF cHaraCtERs");
            // 
            // ofrBtn
            // 
            this.ofrBtn.Name = "ofrBtn";
            this.ofrBtn.Text = "Open Files && Search ";
            this.ofrBtn.AutoSize = true;
            this.toolTip.SetToolTip(this.ofrBtn, "Open all the files in the results list and redo he search");
            this.ofrBtn.Click += new System.EventHandler(this.OfrBtnClick);
            // 
            // button1
            // 
            this.clearReplaceTxt.Name = "button1";
            this.clearReplaceTxt.Text = "Clear";
            this.clearReplaceTxt.AutoSize = true;
            this.toolTip.SetToolTip(this.clearReplaceTxt, "Clear the text from the find box");
            this.clearReplaceTxt.Click += new System.EventHandler(this.clearReplaceTxtClick);
            // 
            // copyFindReplaceBtn
            // 
            this.copyFindReplaceBtn.Name = "copyFindReplaceBtn";
            this.copyFindReplaceBtn.Text = "Copy";
            this.copyFindReplaceBtn.AutoSize = true;
            this.toolTip.SetToolTip(this.copyFindReplaceBtn, "Copies the text from the find box");
            this.copyFindReplaceBtn.Click += new System.EventHandler(this.copyFindReplaceBtnClick);
            // 
            // replaceBtn
            // 
            this.replaceBtn.Name = "replaceBtn";
            this.replaceBtn.Text = "Replace";
            this.replaceBtn.AutoSize = true;
            this.toolTip.SetToolTip(this.replaceBtn, "Replace the selected text in all the checked entries");
            this.replaceBtn.Click += new System.EventHandler(this.ReplaceBtnClick);
            // 
            // switchFindReplaceBtn
            // 
            this.switchFindReplaceBtn.Name = "switchFindReplaceBtn";
            this.switchFindReplaceBtn.Text = "Switch";
            this.switchFindReplaceBtn.AutoSize = true;
            this.toolTip.SetToolTip(this.switchFindReplaceBtn, "Switches the text between find and replace");
            this.switchFindReplaceBtn.Click += new System.EventHandler(this.SwtchFindReplaceBtnClick);
            // 
            // bookmarkBtn
            // 
            this.bookmarkBtn.Name = "bookmarkBtn";
            this.bookmarkBtn.Text = "Bookmark";
            this.bookmarkBtn.AutoSize = true;
            this.toolTip.SetToolTip(this.bookmarkBtn, "Bookmark all the selected items");
            this.bookmarkBtn.Click += new System.EventHandler(this.bookmarkBtn_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.AutoSize = true;
            this.toolTip.SetToolTip(this.deleteBtn, "Delete all selected line");
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // regExReplaceChk
            // 
            this.regExReplaceChk.Name = "regExReplaceChk";
            this.regExReplaceChk.Text = "RegEx replace";
            this.regExReplaceChk.AutoSize = true;
            this.toolTip.SetToolTip(this.regExReplaceChk, "If checked, you can use searched groups from the match in your replace. \\n Write " +
        "$1 to insert the text from the first group, and so on.");
            // 
            // replacePageFlow
            // 
            this.replacePageFlow.Controls.Add(this.replaceTxt);
            this.replacePageFlow.Controls.Add(this.replaceBtn);
            this.replacePageFlow.SetFlowBreak(this.replaceBtn, true);
            this.replacePageFlow.Controls.Add(this.switchFindReplaceBtn);
            this.replacePageFlow.Controls.Add(this.copyFindReplaceBtn);
            this.replacePageFlow.Controls.Add(this.clearReplaceTxt);
            this.replacePageFlow.Controls.Add(this.ofrBtn);
            this.replacePageFlow.Controls.Add(this.regExReplaceChk);
            this.replacePageFlow.Dock = DockStyle.Top;
            this.replacePageFlow.AutoSize = true;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.optionsPage);
            this.tabControl.Controls.Add(this.replacePage);
            this.tabControl.Controls.Add(this.filterPage);
            this.tabControl.Controls.Add(this.foldersPage);
            this.tabControl.Controls.Add(this.operationsPage);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Dock = DockStyle.Fill;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.TabControlSelectedIndexChanged);
            // 
            // optionsPage
            // 
            this.optionsPage.Controls.Add(this.autoFeedChk);
            this.optionsPage.Controls.Add(this.autoChk);
            this.optionsPage.Controls.Add(this.openFilesChk);
            this.optionsPage.Name = "optionsPage";
            this.optionsPage.Text = "Options";
            // 
            // replacePage
            // 
            this.replacePage.Controls.Add(this.replacePageFlow);
            this.replacePage.Name = "replacePage";
            this.replacePage.Text = "Replace";
            // 
            // replaceTxt
            // 
            this.replaceTxt.Name = "replaceTxt";
            this.replaceTxt.Text = "@FIND";
            this.replaceTxt.AutoSize = true;
            this.replaceTxt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDownHandler);           
            // 
            // filterPageFlow
            // 
            this.filterPageFlow.Controls.Add(this.filterTxt);
            this.filterPageFlow.SetFlowBreak(this.filterTxt, true);
            this.filterPageFlow.Controls.Add(this.regexHelpBtn);
            this.filterPageFlow.Controls.Add(this.clearFilterBtn);
            this.filterPageFlow.Dock = DockStyle.Top;
            // 
            // filterPage
            // 

            this.filterPage.Controls.Add(this.filterPageFlow);
            this.filterPage.Name = "filterPage";
            this.filterPage.Text = "Filter";
            // 
            // filterTxt
            // 
            this.filterTxt.Items.AddRange(new object[] {
            "",
            "(import|new)\\s*[\\w\\.]*@FIND[\\.;]",
            "(function|var)\\s*\\w*\\s*:\\s*@FIND\\s*[;\\(]"});
            this.filterTxt.Name = "filterTxt";
            this.filterTxt.TextChanged += new System.EventHandler(this.FilterTxtTextChanged);
            // 
            // clearFilterBtn
            // 
            this.clearFilterBtn.Name = "clearFilterBtn";
            this.clearFilterBtn.Text = "X";
            this.clearFilterBtn.AutoSize = true;
            this.clearFilterBtn.Click += new System.EventHandler(this.clearFilterBtn_Click);
            // 
            // foldersPageFlow
            // 
            this.foldersPageFlow.Controls.Add(this.folderTxt);
            this.foldersPageFlow.Controls.Add(this.browseBtn);
            this.foldersPageFlow.SetFlowBreak(this.browseBtn, true);
            this.foldersPageFlow.Controls.Add(this.folderFilesChk);
            this.foldersPageFlow.Controls.Add(this.searchSubfoldersChk);  
            this.foldersPageFlow.Controls.Add(this.fileMaskTxt);              
            this.foldersPageFlow.Name = "foldersPageFlow";
            this.foldersPageFlow.Dock = DockStyle.Top;
            // 
            // foldersPage
            // 
            this.foldersPage.Controls.Add(this.foldersPageFlow);
            this.foldersPage.Name = "foldersPage";
            this.foldersPage.Text = "Folders";
            // 
            // folderTxt
            // 
            this.folderTxt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.folderTxt.Name = "folderTxt";
            this.folderTxt.DrawMode = DrawMode.OwnerDrawFixed;
            this.folderTxt.DrawItem += folderTxt_DrawItem;
            this.folderTxt.DropDownClosed += folderTxt_DropDownClosed;
            this.folderTxt.SelectedIndexChanged += new System.EventHandler(this.FolderTxtSelectedIndexChanged);
            // 
            // operationsPageFlow
            // 
            this.operationsPageFlow.Controls.Add(this.CopyResultsBtn);
            this.operationsPageFlow.Controls.Add(this.deleteBtn);
            this.operationsPageFlow.Controls.Add(this.bookmarkBtn);
            this.operationsPageFlow.Dock = DockStyle.Top;
            this.operationsPageFlow.Name = "operationsPageFlow";
            // 
            // operationsPage
            // 
            this.operationsPage.Controls.Add(this.operationsPageFlow);
            this.operationsPage.Name = "operationsPage";
            this.operationsPage.Text = "Operations";
            // 
            // CopyResultsBtn
            // 
            this.CopyResultsBtn.Name = "CopyResultsBtn";
            this.CopyResultsBtn.Text = "Copy To Results";
            this.CopyResultsBtn.AutoSize = true;
            this.CopyResultsBtn.Click += new System.EventHandler(this.CopyResultsBtn_Click);
            // 
            // at
            // 
            this.at.Text = "@";
            this.at.Width = -1;
            // 
            // splitter
            // 
            this.splitter.SplitterMoved += splitter_SplitterMoved;
            // 
            // resultsLst
            // 
            this.resultsLst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mark,
            this.at,
            this.result,
            this.filename});
            this.resultsLst.FullRowSelect = true;
            this.resultsLst.GridLines = true;
            this.resultsLst.LabelWrap = false;
            this.resultsLst.AutoSize = true;
            this.resultsLst.Dock = DockStyle.Fill;
            this.resultsLst.Name = "resultsLst";
            this.resultsLst.View = System.Windows.Forms.View.Details;
            this.resultsLst.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.ResultsLstItemCheck);
            this.resultsLst.SelectedIndexChanged += new System.EventHandler(this.resultsLst_SelectedIndexChanged);
            this.resultsLst.Click += new System.EventHandler(this.ResultsLstClick);
            this.resultsLst.DoubleClick += new System.EventHandler(this.ResultsLstDoubleClick);
            this.resultsLst.MouseLeave += new System.EventHandler(this.resultsLst_MouseLeave);
            this.resultsLst.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ResultsLstMouseMove);
            this.resultsLst.SizeChanged += new EventHandler(this.ResultsLst_SizeChanged);
            // 
            // mark
            // 
            this.mark.Text = "";
            this.mark.Width = -1;
            // 
            // result
            // 
            this.result.Text = "Result Line";
            this.result.Width = -1;
            // 
            // filename
            // 
            this.filename.Text = "File Name";
            this.filename.Width = -1;
            // 
            // findChkCont
            // 
            this.findChkFlow.Controls.Add(this.matchCaseChk);
            this.findChkFlow.Controls.Add(this.wholeWordChk);
            this.findChkFlow.Controls.Add(this.regexpChk);
            this.findChkFlow.Name = "findChkCont";
            this.findChkFlow.Dock = DockStyle.Top;
            this.findChkFlow.Text = "Find";
            this.findChkFlow.AutoSize = true;
            // 
            // optionsPanel
            // 
            this.optionsPanel.Controls.Add(tabControl);
            this.optionsPanel.Controls.Add(findChkFlow);
            this.optionsPanel.Controls.Add(findTxt);
            this.optionsPanel.Controls.Add(filterRadioFlow);
            this.optionsPanel.Size = new Size(375,200);
            // 
            // PluginUI
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.AddRange(new Control[] { this.resultsLst, this.splitter,this.optionsPanel });
            this.Name = "PluginUI";

            splitter_SplitterMoved(null, null);

            this.tabControl.ResumeLayout(false);
            this.optionsPage.ResumeLayout(false);
            this.replacePage.ResumeLayout(false);
            this.replacePage.PerformLayout();
            this.filterPage.ResumeLayout(false);
            this.foldersPage.ResumeLayout(false);
            this.foldersPage.PerformLayout();
            this.operationsPage.ResumeLayout(false);
            this.filterRadioFlow.ResumeLayout();
            this.findChkFlow.ResumeLayout();
            this.replacePageFlow.ResumeLayout();
            this.filterPageFlow.ResumeLayout();
            this.foldersPageFlow.ResumeLayout();
            this.operationsPageFlow.ResumeLayout();
            this.ResumeLayout(false);           
		}

        private void splitter_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.folderTxt.Width = tabControl.Width - this.browseBtn.Width - 20;
            this.filterTxt.Width = tabControl.Width - 20;
            this.replaceTxt.Width = tabControl.Width - replaceBtn.Width - 20;
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
            if (settingsObject.SearchHistoryLimit == 0)
            {
                settingsObject.SearchHistoryLimit = 10;
                settingsObject.ResizeOptionsTab = true;
                settingsObject.ResizeReplaceTab = false;
                settingsObject.ResizeFilterTab = false;
                settingsObject.ResizeFoldersTab = true;
                settingsObject.ResizeOperationsTab = true;
            }
            findTxt.MaxDropDownItems = settingsObject.SearchHistoryLimit;
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
                if (folderFilesChk.CheckState == CheckState.Unchecked)
                {
                    folderFilesChk.CheckState = CheckState.Checked;
                }
			}
			else if (folderFilesChk.CheckState != CheckState.Indeterminate)
			{               
                    folderFilesChk.CheckState = CheckState.Unchecked;
			}
		}
		
        /// <summary>
        /// handle with focus
        /// </summary>
        public void PluginUI_FocusHandle(object sender, EventArgs e)
        {
            

            if (PluginBase.MainForm.DockPanel.ActiveContent == this.plugin.Panel)
            {
                revealLeftSide();      
                findTxt.Focus();
            }
            else
            {
                if (sender == null)
                {
                    this.plugin.Panel.Show();
                    revealLeftSide();
                    this.ShowReplace = true;
                    this.replaceTxt.Focus();
                }
                else
                {
                    Settings settingsObject = this.plugin.Settings as Settings;
                    if ((tabControl.SelectedTab == optionsPage && settingsObject.ResizeOptionsTab) || (tabControl.SelectedTab == replacePage && settingsObject.ResizeReplaceTab) || (tabControl.SelectedTab == filterPage && settingsObject.ResizeFilterTab) || (tabControl.SelectedTab == foldersPage && settingsObject.ResizeFoldersTab) || (tabControl.SelectedTab == operationsPage && settingsObject.ResizeOperationsTab))
                    {
                        tabControl.SelectedTab = optionsPage;
                        hideLeftSide();
                    }
                }              
            }

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
                this.mark.Width = -1;
                this.at.Width = -1;
                this.filename.Width = -1;
				resultsLst.EndUpdate();
		}

        private void startSearch()
        {
            bool itemExists = false;
            foreach (string cbi in findTxt.Items)
            {
                itemExists = cbi == findTxt.Text;
                if (itemExists) break;
            }
            if (!itemExists)
                findTxt.Items.Add(findTxt.Text);
            ListAllFindText(findTxt.Text, 1);
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
                if ((folderFilesChk.CheckState == CheckState.Checked || folderFilesChk.CheckState == CheckState.Indeterminate) && tabControl.SelectedTab == foldersPage)
				{
					results = plugin.GetFindInFolderResultsList(Text, folderTxt.Text, fileMaskTxt.Text, searchSubfoldersChk.Checked);
                    if (folderFilesChk.CheckState == CheckState.Checked)
                    {
                        folderFilesChk.CheckState = CheckState.Unchecked;
                    }
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
            if (!inReplace)
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

			//autoFeedChk.Checked = false;
			//autoChk.Checked = false;
			string workingFile = "";
            inReplace = true;
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
            inReplace = false;
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

            
            ShowReplace = false;
        }

        private void CopyToResultsPanel()
        {
            Globals.MainForm.CallCommand("PluginCommand", "ResultsPanel.ClearResults");
            foreach (ListViewItem item in resultsLst.Items)
            {
                FindMatch m = item.Tag as FindMatch;
                int column = m.Column;
                if (item.Checked)
                {
                    TraceManager.Add(m.FileName + ":" + (m.Line + 1).ToString() + ": characters " + m.Column + "-" + (m.Column + m.Text.Length) + " : " + m.LineText.Trim(), (Int32)TraceType.Info);
                }
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
		
		private void ResultsLstDoubleClick(object sender, System.EventArgs e)
		{
			
			ListViewItem item = this.resultsLst.SelectedItems[0];
			if (item == null) return;
			FindMatch m = (FindMatch)item.Tag;
			int position = m.Position;
			
			plugin.GotoPosAndFocus(m.FileName, position, m.Text.Length);
		}

        private void keyDownHandler(object sender, KeyEventArgs e)
        {
            if (findTxt.Focused && e.KeyCode == Keys.Enter)
            {
                startSearch();
            }
            else if (replaceTxt.Focused && e.KeyCode == Keys.Enter)
            {
                ReplaceBtnClick(null, null);
            }
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
            ListAllFindText(find, 1);
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
		
		private void FolderFilesChkCheckedStateChanged(object sender, System.EventArgs e)
		{
            switch (folderFilesChk.CheckState)
            {
                case CheckState.Checked: 
                        autoChk.Checked = !folderFilesChk.Checked;
                        break;
                case CheckState.Indeterminate:
                                                
                        break;
                case CheckState.Unchecked:
                        autoChk.Checked = !folderFilesChk.Checked;
                        break;
            }
		}

		private void FolderTxtSelectedIndexChanged(object sender, System.EventArgs e)
		{
			lastPath = folderTxt.Text;
		}

        private void folderTxt_DropDownClosed(object sender, EventArgs e)
        {
            toolTip.Hide(folderTxt);
        }

        private void folderTxt_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) { return; }
            string text = folderTxt.GetItemText(folderTxt.Items[e.Index]);
            e.DrawBackground();
            using (SolidBrush br = new SolidBrush(e.ForeColor))
            { e.Graphics.DrawString(text, e.Font, br, e.Bounds); }
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            { toolTip.Show(text, folderTxt, e.Bounds.Left, e.Bounds.Top); }
            e.DrawFocusRectangle();
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
		void clearReplaceTxtClick(object sender, System.EventArgs e)
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
                toolTip.Hide(resultsLst);
                toolTipShow = false;
                currentItem = null;
				return;
		    }
            if(toolTipShow){
                if (currentItem.Index == item.Index)
                {
                    return;
                }
            }else{
                FindMatch m = (item.Tag) as FindMatch;
                ScintillaControl sci = m.Scintilla;
                int line = m.Line;
                string tooltipText = String.Format("{1}    {0}:\n", item.SubItems[1].Text, item.SubItems[3].Text);
                //if (sci != null)
                try
                {
                    if (m.FileName == plugin.CurFile && m.FileName.Contains(".as"))
                    {
                        ASCompletion.Completion.ASResult res = ASCompletion.Context.ASContext.Context.GetDeclarationAtLine(line);
                        tooltipText += String.Format("In       {0}:\n", res.Member);
                    }
                    string prev = sci.GetLine(line - 1).Trim();
                    string next = sci.GetLine(line + 1).Trim();
                    tooltipText += String.Format("\n   {1}\n        {0}\n   {2} ", item.SubItems[2].Text, prev, next);
                }
                //else
                catch
                {
                    tooltipText += item.SubItems[2].Text;
                }
                toolTip.SetToolTip(resultsLst, tooltipText);
                toolTipShow = true;
                currentItem = item;
            }
		}

        private void ResultsLst_SizeChanged(object sender, EventArgs e)
        {
            ListView resultsList = sender as ListView;
            resultsList.Columns[2].Width = resultsList.Width - resultsList.Columns[0].Width - resultsList.Columns[1].Width - resultsList.Columns[3].Width;
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

        public void DockHandler_DockStateChanged(object sender, EventArgs e)
        {
            DockContentHandler dckContHandler = sender as DockContentHandler;
            switch (dckContHandler.DockState)
            {
                case DockState.DockBottom:
                case DockState.Float:
                case DockState.DockTop:
                    this.optionsPanel.Dock = DockStyle.Left;
                    this.splitter.Dock = DockStyle.Left;
                    break;
                case DockState.DockRight:
                case DockState.DockLeft:
                    this.optionsPanel.Dock = DockStyle.Top;
                    this.splitter.Dock = DockStyle.Top;
                    break;
            }
        }

        #endregion

        private void regexpChk_CheckedChanged(object sender, EventArgs e)
        {
            regExReplaceChk.Enabled = regexpChk.Checked;
        }

        private void resultsLst_MouseLeave(object sender, EventArgs e)
        {
            currentItem = null;
            toolTipShow = false;
            // needs research... if I want to change the context of the current file while running
            //ASCompletion.Context.ASContext.Context.CurrentFile = plugin.CurFile;
        }

        private void selectedItemFindTxt(object sender, EventArgs e)
        {
            ListAllFindText(findTxt.Text, 1);
        }

        private void hideLeftSide()
        {            
            this.optionsPanel.Visible = false;
            this.splitter.Visible = false;
            
        }

        private void revealLeftSide()
        {
            this.optionsPanel.Visible = true;
            this.splitter.Visible = true;
        }

        public void setFilterMaskTxt(string ext)
        {
            this.fileMaskTxt.Text = "*."+ext;
        }

        private void resultsLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

    }
}
