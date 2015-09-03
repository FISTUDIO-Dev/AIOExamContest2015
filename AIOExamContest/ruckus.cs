/*
 * Solution Template for Ruckus League
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

public class SolutionTwo {

    /* N is the number of children you have gathered. */
    private static int N;

    /* L is the number of pairs of hands already joined together. */
    private static int L;

    /* K is the number of lollipops you have. */
    private static int K;

    /* M is the minimum size of a team. */
    private static int M;

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
        while (next >= 0 && char.IsWhiteSpace((char)next))
            next = sr.Read();

        /* Read the following token. */
        while (next >= 0 && ! char.IsWhiteSpace((char)next)) {
            ans.Append((char)next);
            next = sr.Read();
        }

        return ans.ToString();
    }

    public static void MainRUCKUS(string[] args) {
        /* Open the input and output files. */
        StreamReader input_file = new StreamReader("ruckusin.txt");
        StreamWriter output_file = new StreamWriter("ruckusout.txt");

        /* Read the values of N, L, K and M from the input file.  */
        N = int.Parse(readToken(input_file));
        L = int.Parse(readToken(input_file));
        K = int.Parse(readToken(input_file));
        M = int.Parse(readToken(input_file));

        /* Read in the hands that are joined. */
        for (int i = 0; i < L; i++) {
            int l;
            int r;
            l = int.Parse(readToken(input_file));
            r = int.Parse(readToken(input_file));
            /*
             * TODO: We do not do anything with the values that are being read
             * in. It is up to you to process or store them.
             */
        }

        /*
         * TODO: This is where you should compute your solution and store it
         * into the variable answer.
         */
        int answer = 0;

        /* Write the answer to the output file. */
        output_file.WriteLine(answer);

        /* Finally, close the input/output files. */
        input_file.Close();
        output_file.Close();
    }
}
