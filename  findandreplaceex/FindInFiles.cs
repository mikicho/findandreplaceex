/*
 * FindTool - Find In Files utility
 * Author: Philippe Elsass
 */
using System;
using System.IO;
using System.Collections;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace FindReplaceEx
{
	class FindInFiles
	{
		// already explored pathes
		static ArrayList known;
		static FindResults lastResults;
		// parameters
		static Regex re_pattern;
		static string fileMask;
		static string pattern;
		static bool recursive;


		/// <summary>
		/// Recursively convert classes
		/// </summary>
		/// <param name="path">folder to convert</param>
		static void ExploreFolder(string path)
		{
			known.Add(path);

			// convert classes
			string[] files = Directory.GetFiles(path, fileMask);
			string src;
			Encoding enc;
			int line = 0;
			int position = 0;
			int lineEndChars = 0;
			TextReader sr;
			//lastResults = new FindResults();
			foreach(string file in files)
			{
				line = 0;
				position = 0;
				enc = GetEncoding(file);
				using( sr = new StreamReader(file, enc) )
				{
					
					lineEndChars = getLineEndMode(sr.ReadToEnd());
					sr.Close();
				}
				using( sr = new StreamReader(file, enc) )
				{
					src = sr.ReadLine();
					//findText = getSafeSearch(findText);
					/**
					MatchCollection searchResults = re_pattern.Matches(src);
					ScintillaNet.ScintillaControl sci = new ScintillaNet.ScintillaControl();			
					lastResults.AddResults(sci, searchResults);
					*/
					while (src != null)
					{
						if (re_pattern.IsMatch(src))
						{
							byte[] ba = Encoding.Convert(enc, Encoding.Default, enc.GetBytes(src));
							src = Console.Out.Encoding.GetString(ba);
							Match m = re_pattern.Match(src);
							int pos = position + m.Index;
							lastResults.AddResult(file, line, pos, src, m);
							//Console.WriteLine(file+":"+line+": "+src.TrimEnd());
						}
						position += src.Length+lineEndChars;
						line++;
						src = sr.ReadLine();

					}

					sr.Close();
				}
			}
			if (!recursive)
				return;

			// explore subfolders
			string[] dirs = Directory.GetDirectories(path);
			foreach(string dir in dirs)
			{
				if (!known.Contains(dir)) ExploreFolder(dir);
			}
		}
		
		static int getLineEndMode(string input)
		{
			if (input.IndexOf("\n\r") > -1 || input.IndexOf("\r\n") > -1) 
			{
				return 2;
			}
			else
			{
				return 1;
			}
		}

		/// <summary>
		/// Adapted from FlashDevelop: FileSystem.cs
		/// Detects the file encoding from the file data.
		/// </summary>
		static Encoding GetEncoding(string file)
		{
			byte[] bom = new byte[4];
			System.IO.FileStream fs = new System.IO.FileStream(file, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Read);
			if (fs.CanSeek)
			{
				fs.Read(bom, 0, 4); fs.Close();
				if ((bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf))
				{
					return Encoding.UTF8;
				}
				else if ((bom[0] == 0xff && bom[1] == 0xfe))
				{
					return Encoding.Unicode;
				}
				else if ((bom[0] == 0xfe && bom[1] == 0xff))
				{
					return Encoding.BigEndianUnicode;
				}
				else if ((bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0xfe && bom[3] == 0x76))
				{
					return Encoding.UTF7;
				}
				else
				{
					return Encoding.Default;
				}
			}
			else
			{
				return Encoding.Default;
			}
		}


		/// <summary>
		/// THIS FUNCTION IS COMPLETE!!
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		public static FindResults GetSearchResults(string folder, string input, string mask, bool isRecursive, bool isRegex, bool isWholeWord, bool isIgnoreCase)
		{
			fileMask = mask;
			pattern = input;
			if (!isRegex) pattern = Regex.Escape(pattern);
			if (isWholeWord) pattern = "(?<!\\w)"+pattern+"(?!\\w)";

			// create Regex
			RegexOptions options = RegexOptions.Compiled | RegexOptions.Singleline;
			if (isIgnoreCase) options |= RegexOptions.IgnoreCase;
			re_pattern = new Regex(pattern, options);
			recursive = isRecursive;

			// exploration context
			known = new ArrayList();

			// explore
			try
			{
				lastResults = new FindResults();
				// no path specified, use working directory
				if (folder == "")
				{
					folder = Directory.GetCurrentDirectory();
				}
				known.Add(folder);
				ExploreFolder(folder);
				/*else
				for (int i=skip; i<count-2; i++)
				{
					known.Add(args[i]);
					ExploreFolder(args[i]);
				}*/
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error while doing a find in file operation: "+ex.Message);
				return null;
			}
			return lastResults;
		}
	}
}
