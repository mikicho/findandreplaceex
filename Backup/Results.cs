/*
 * results list holder for find operations
 */

using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
//using System.Text.RegularExpressions;
using WeifenLuo.WinFormsUI;
using ScintillaNet;

namespace FindReplaceEx
{
	/// <summary>
	/// Description of Results.
	/// </summary>
	public class FindMatch
	{
		private Match match;
		private string fileName;
		private ScintillaControl scintilla;
		private Int32 position;
        private int column;
		private string text;
		private string lineText;
		private int line;
        private GroupCollection groups;
		
		public FindMatch(ScintillaControl sci, Match m)
		{
			fileName = sci.FileName as string;
			scintilla = sci;
			NewMatch(m);

		}
		
		public FindMatch(string file, int fline, int pos, string ftext, Match m)
		{
			match = m;
			fileName = file;
			line = fline;
			position = pos;
			text = ftext;
			lineText = ftext;
            if (scintilla != null)
            {
                column = scintilla.Column(position);
            }
            else
            {
                column = 0;
            }

		}
		
		private void NewMatch(Match m)
		{
			match = m;
			position = m.Index;			
			line = scintilla.LineFromPosition(position);
            column = scintilla.Column(position);
			text = m.Value;
			lineText = scintilla.GetLine(line);
		}
		
		public int Line {
			get {
				return line;
			}
		}
		public Int32 Position {
			get {
				return position;
			}
		}
        public int Column
        {
            get
            {
                return column;
            }
        }
        /// <summary>
		/// the "find" text iteself
		/// </summary>
		public string Text {
			get {
				return text;
			}
		}
		public string LineText {
			get {
				return lineText;
			}
		}
		public string FileName {
			get {
				return fileName;
			}
		}
        public Match Match
        {
            get
            {
                return match;
            }
            set
            {
                NewMatch(value);
            }
        }

        public GroupCollection Groups
        {
            get
            {
                return match.Groups;
            }
        }

		public ScintillaControl Scintilla {
			get {
				return scintilla;
			}
		}
		
		
	}
	
	public class FindResults
	{
		private ArrayList results;
		private int lastIndex;
		
		
		public FindResults()
		{
			results = new ArrayList();
			lastIndex = 0;
		}
		
		public int AddResults(ScintillaControl sci, MatchCollection r)
		{
			int count = r.Count;
			for (int i=0; i< count; i++)
			{
				Match m = r[i];
				AddResult(sci, r[i]);
			}
			return Count;
		}
		
		public int AddResult(ScintillaControl sci, Match m)
		{
			FindMatch fm = new FindMatch(sci, m);
			return AddResult(fm);
		}
		
		public int AddResult(string file, int fline, int pos, string ftext, Match m)
		{
			FindMatch fm = new FindMatch(file, fline, pos, ftext, m);
			return AddResult(fm);
		}
		
		public int AddResult(FindMatch fm)
		{
			results.Add(fm);
			return Count;
		}
		
		public FindMatch GetResult(int index)
		{
			if (index < 0 || index >= Count)
			{
				return null;
			}
			lastIndex = index;
			FindMatch ret = (FindMatch)results[index];
			return ret;
		}
		
		public FindMatch FirstResult()
		{
			return GetResult(0);
		}
		
		public FindMatch NextResult()
		{
			return GetResult(lastIndex + 1);
		}
		
		public FindMatch PreviousResult()
		{
			return GetResult(lastIndex - 1);
		}
		
		public void Filter(string filterText)
		{
			foreach(FindMatch m in results)
			{
				if (Regex.IsMatch(m.LineText, Regex.Unescape(filterText)))
				    results.Remove(m);
			}
		}
		
		public int Index {
			get {
				return lastIndex; 
			}
			set {
				if (value >= 0 || value < Count)
					lastIndex = value;
			}
		}
		
		public int Count {
			get {
				return results.Count;
			}
		}
	}
}
