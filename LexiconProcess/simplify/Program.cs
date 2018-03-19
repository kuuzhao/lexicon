using System;
using System.IO;
using System.Collections.Generic;

namespace simplify
{
	class MainClass
	{
		public static bool LoadAllChars(string path, HashSet<char> allChars)
		{
			try
			{    
				using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
				{
					// This is an arbitrary size for this example.

					while (sr.Peek() >= 0)
					{
						string str = sr.ReadLine();
						foreach (char c in str)
							allChars.Add(c);
					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("The process failed: {0}", e.ToString());
				return false;
			}

			return true;
		}

		public static void FilterLexicon(string lexiconPath, HashSet<char> allChars)
		{
			try
			{
				using (StreamReader sr = new StreamReader(lexiconPath, System.Text.Encoding.UTF8))
				{
					// This is an arbitrary size for this example.

					while (sr.Peek() >= 0)
					{
						string line = sr.ReadLine();
						string[] splits = line.Split(' ');
						if (splits.Length > 1)
						{
							string word = splits[0];
							bool hasIllegleChar = false;
							foreach (char c in word)
							{
								if (!allChars.Contains(c))
								{
									hasIllegleChar = true;
									break;
								}
							}

							if (!hasIllegleChar)
								Console.WriteLine(line);
						}

					}
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("The process failed: {0}", e.ToString());
			}
		}

		public static void Main(string[] args)
		{
			string allCharsPath = args [0];
			string lexiconPath = args [1];

			HashSet<char> allChars = new HashSet<char>();
			if (!LoadAllChars(allCharsPath, allChars))
				return;

			FilterLexicon(lexiconPath, allChars);
		}
	}
}
