/*
 * Solution Template for Wet Chairs
 * 
 * Australian Informatics Olympiad 2015
 * 
 * This file is provided to assist with reading and writing of the input
 * files for the problem. You may modify this file however you wish, or
 * you may choose not to use this file at all.
 */

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
public class SolutionOne {

	/*
     * MAX_C is the largest possible number of chairs, as defined in the
     * problem statement.
     */
	public const int MAX_C = 100000;

	/*
     * C is the total number of chairs. $(N)s is the total number of friends to
     * whom you have to assign seats. $(K)s is the number of friends who are
     * able to sit on either a wet or dry chair
     */
	private static int C;
	private static int N;
	private static int K;

	/*
     * chairs, is a string of the characters 'd' and 'w' representing dry and
     * wet chairs.
     */
	private static string chairs;

	/*
     * Read the next token from the input file.
     * Tokens are separated by whitespace, i.e., spaces, tabs and newlines.
     * If end-of-file is reached then an empty string is returned.
     */
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

	public static void MainWETCHAIRS(string[] args) {
		/* Open the input and output files. */
		StreamReader input_file = new StreamReader("chairsin.txt");
		StreamWriter output_file = new StreamWriter("chairsout.txt");

		/* Read the values of C, N, K from the input file.  */
		C = int.Parse(readToken(input_file));
		N = int.Parse(readToken(input_file));
		K = int.Parse(readToken(input_file));

		/* Read in the string describing the chairs. */
		chairs = readToken(input_file);

		/*
         * TODO: This is where you should compute your solution and store it
         * into the variable answer.
         */
		int answer = solve();

		/* Write the answer to the output file. */
		output_file.WriteLine(answer);

		/* Finally, close the input/output files. */
		input_file.Close();
		output_file.Close();
	}
		

	private static int solve (){
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
