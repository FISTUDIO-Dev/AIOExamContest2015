using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;
namespace AIOExamContest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			String input = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments) + "/test.txt";
			String output = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments) + "/result.txt";

			SolutionOne newSolution = new SolutionOne (input);
			newSolution.generateSolutionText (output);
		}
	}


	class SolutionOne {

		private int C;
		private int N;
		private int K;

		private string chairs;

		private static string readToken(StreamReader sr) {
			StringBuilder ans = new StringBuilder();
			int next;

			/* Skip any initial whitespace. */
			next = sr.Read();
			while (next >= 0 && char.IsWhiteSpace ((char)next))
				next = sr.Read ();

			/* Read the following token. */
			while (next >= 0 && ! char.IsWhiteSpace((char)next)) {
				ans.Append((char)next);
				next = sr.Read();
			}

			return ans.ToString();
		}


		public SolutionOne(String input){
			StreamReader reader = new StreamReader(input);
			C = int.Parse (readToken (reader));
			N = int.Parse (readToken (reader));
			K = int.Parse (readToken (reader));
			chairs = readToken (reader);
			reader.Close ();

		}

		public void generateSolutionText(String output){
			StreamWriter writer = new StreamWriter (output);
			writer.WriteLine (this.solve ().ToString ());
			writer.Close ();
		}

		private int solve(){
			//preliminary
			if (K > N) {
				return 0;
			}
			List<String> seatArray = new List<String> (C);
			foreach (char c in chairs) {
				seatArray.Add (c.ToString());
			}


			List<int> dIndexes = new List<int> ();
			for (int i = 0; i < seatArray.Count; i++) {
				if (seatArray[i] == 'd'.ToString ()) {
					dIndexes.Add (i);
				}
			}

			int minDistance = C;

			foreach (int dIndex in dIndexes) {
				int indexOfFirstD = dIndex;
				int dCount = 0;
				int reachedDIndex = 0;
				for (int i = indexOfFirstD; i < seatArray.Count; i++) {
					if (seatArray [i] == 'd'.ToString ()) {
						dCount++;
						if (dCount >= (N - K)) {
							reachedDIndex = i;
							break;
						}
					}
				}

				int wCount = 0;
				for (int j = indexOfFirstD; j <= reachedDIndex; j++) {
					if (seatArray [j] == 'w'.ToString ()) {
						wCount++;
					}
				}
				if (wCount >= K) {
					int result = reachedDIndex - indexOfFirstD + 1;
					if (result < minDistance) {
						minDistance = result;
						break;
					}
				} else {
					int result = K - wCount + (reachedDIndex - indexOfFirstD + 1);
					if (result < minDistance) {
						minDistance = result;
					}
				}


			}

			return minDistance;
		}


	}

	class SolutionTwo{


		public SolutionTwo(String input){

		}

	}

	class SolutionThree{


	}

}
