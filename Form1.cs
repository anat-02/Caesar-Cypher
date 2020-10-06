using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISSProject
{
    public partial class Form1 : Form
    {

        Dictionary<char, double> freq = new Dictionary<char, double>();
        Dictionary<char, double>[] possible_freq = new  Dictionary<char, double>[25];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DictionaryInit();
        }

        private void btn_Encrypt_Click(object sender, EventArgs e)
        {
            string plaintext = tb_PlainText.Text;
            plaintext = plaintext.Replace(" ", string.Empty); //remove spaces
            int key = int.Parse(tb_Key.Text) % 26;
            
            string output = "";
            int decOutput = 0;
            for(int i=0; i<plaintext.Length; i++)
            {
                if(char.IsUpper(plaintext[i]))
                {
                    //convert the character to it's decimal equivalent
                    int letter = plaintext[i];
                    decOutput = ((letter - 65) + key) % 26;
                    char ch = (char)(decOutput + 65);
                    output += ch;
                }
                else
                {
                    int letter = plaintext[i];
                    decOutput = ((letter - 97) + key) % 26;
                    char ch = (char)(decOutput + 97);
                    output += ch;
                }
            }
            tb_CipherText.Text = output;
        }

        private void btn_Decrypt_Click(object sender, EventArgs e)
        {
            string ciphertext = tb_CipherText.Text;
            ciphertext = ciphertext.Replace(" ", string.Empty); //remove spaces
            int key = int.Parse(tb_Key.Text) % 26; //to prevent negative postions
            key = 26 - key;

            string output = "";
            int decOutput = 0;
            for (int i = 0; i < ciphertext.Length; i++)
            {
                if (char.IsUpper(ciphertext[i]))
                {
                    //convert the character to it's decimal equivalent
                    int letter = ciphertext[i];
                    decOutput = ((letter - 65) + key) % 26;
                    char ch = (char)(decOutput + 65);
                    output += ch;
                }
                else
                {
                    int letter = ciphertext[i];
                    decOutput = ((letter - 97) + key) % 26;
                    char ch = (char)(decOutput + 97);
                    output += ch;
                }
            }
            tb_PlainText.Text = output;
        }

        private void btn_BruteForce_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string ciphertext = tb_CipherText.Text;
            ciphertext = ciphertext.Replace(" ", string.Empty); //remove spaces
            string[] possibles = new string[25];
            string output = "";
            int decOutput = 0;
            for (int i = 1; i < 26; i++)
            {
                output = "";
                for (int j = 0; j < ciphertext.Length; j++)
                {
                    if (char.IsUpper(ciphertext[j]))
                    {                   
                        int letter = ciphertext[j];
                        decOutput = ((letter - 65) + i) % 26;
                        char ch = (char)(decOutput + 65);
                        output += ch;
                        possibles[i - 1] = output;
                    }
                    else
                    {
                        int letter = ciphertext[j];
                        decOutput = ((letter - 97) + i) % 26;
                        char ch = (char)(decOutput + 97);
                        output += ch;
                        possibles[i - 1] = output;
                    }
                }
            }

            stopwatch.Stop();
            tb_Time.Text = (stopwatch.Elapsed.TotalMilliseconds).ToString();
        }

        private void btn_LFA_Click(object sender, EventArgs e)
        {
            ResetFreq();
            rtb_LFA.Text = "";
            string ciphertext = tb_CipherText.Text.ToLower();
            ciphertext = ciphertext.Replace(" ", string.Empty); //remove spaces
            string[] possibles = new string[25];
            double[] possibles_dist = new double[25];
            double current_val = 0;
            string output = "";
            int decOutput = 0;
            for (int i = 1; i < 26; i++)
            {
                output = "";
                for (int j = 0; j < ciphertext.Length; j++)
                {

                    int letter = ciphertext[j];
                    decOutput = ((letter - 97) + i) % 26;
                    char ch = (char)(decOutput + 97);
                    output += ch;
                    possible_freq[i - 1].TryGetValue(ch, out current_val);
                    possible_freq[i - 1][ch] = current_val + 1;
                    possibles[i - 1] = output;

                }
            }
            Calc_dist(possibles_dist);
            int[] orgPos = new int[25];
            for (int i = 0; i < 25; i++)
            {
                orgPos[i] = i;
            }
            OrderDist(possibles_dist, orgPos);
            int show_amount = 0;
            if (int.TryParse(tb_LFAAmountSel.Text, out show_amount)) { }
            else show_amount = 25;
            if (show_amount < 0)
            {
                show_amount *= -1;
            }
            else if (show_amount > 26)
            {
                show_amount = show_amount % 26;
            }
                
            for (int i = 0; i < show_amount; i++)
            {
                rtb_LFA.Text += possibles[orgPos[i]] + "  Key: " + (26 - orgPos[i] - 1) + "  Distance: " + possibles_dist[i] + "\n\n";
            }

        }

        private void OrderDist(double[] possibles_dist, int[] pos)
        {
            for(int i = 0; i <25; i++)
            {
                for(int j = 0; j < 25 - i - 1; j++)
                {
                    if(possibles_dist[j] > possibles_dist[j + 1])
                    {
                        double temp = possibles_dist[j];
                        possibles_dist[j] = possibles_dist[j + 1];
                        possibles_dist[j + 1] = temp;
                        int temp1 = pos[j];
                        pos[j] = pos[j + 1];
                        pos[j + 1] = temp1;
                    }
                }
            }
            
        }

        private void Calc_dist(double[] possibles_dist)
        {
            for(int i = 0; i< 25; i++)
            {
                possibles_dist[i] =Math.Sqrt( 
                                    Math.Pow((possible_freq[i]['e'] - freq['e']), 2)
                                  + Math.Pow((possible_freq[i]['t'] - freq['t']), 2)
                                  + Math.Pow((possible_freq[i]['a'] - freq['a']), 2)
                                  + Math.Pow((possible_freq[i]['o'] - freq['o']), 2)
                                  + Math.Pow((possible_freq[i]['i'] - freq['i']), 2)
                                  + Math.Pow((possible_freq[i]['n'] - freq['n']), 2)
                                  + Math.Pow((possible_freq[i]['s'] - freq['s']), 2)
                                  + Math.Pow((possible_freq[i]['h'] - freq['h']), 2)
                                  + Math.Pow((possible_freq[i]['r'] - freq['r']), 2)
                                  + Math.Pow((possible_freq[i]['d'] - freq['d']), 2)
                                  + Math.Pow((possible_freq[i]['l'] - freq['l']), 2)
                                  + Math.Pow((possible_freq[i]['c'] - freq['c']), 2)
                                  + Math.Pow((possible_freq[i]['u'] - freq['u']), 2)
                                  + Math.Pow((possible_freq[i]['m'] - freq['m']), 2)
                                  + Math.Pow((possible_freq[i]['w'] - freq['w']), 2)
                                  + Math.Pow((possible_freq[i]['f'] - freq['f']), 2)
                                  + Math.Pow((possible_freq[i]['g'] - freq['g']), 2)
                                  + Math.Pow((possible_freq[i]['y'] - freq['y']), 2)
                                  + Math.Pow((possible_freq[i]['p'] - freq['p']), 2)
                                  + Math.Pow((possible_freq[i]['b'] - freq['b']), 2)
                                  + Math.Pow((possible_freq[i]['v'] - freq['v']), 2)
                                  + Math.Pow((possible_freq[i]['k'] - freq['k']), 2)
                                  + Math.Pow((possible_freq[i]['j'] - freq['j']), 2)
                                  + Math.Pow((possible_freq[i]['x'] - freq['x']), 2)
                                  + Math.Pow((possible_freq[i]['q'] - freq['q']), 2)
                                  + Math.Pow((possible_freq[i]['z'] - freq['z']), 2)
                                  );
                possibles_dist[i] = Math.Round(possibles_dist[i], 2);
            }


        }

        private void DictionaryInit()
        { 
            freq.Add('e', 12.7020);
            freq.Add('t', 9.0560);
            freq.Add('a', 8.167);
            freq.Add('o', 7.507);
            freq.Add('i', 6.966);
            freq.Add('n', 6.749);
            freq.Add('s', 6.3270);
            freq.Add('h', 6.094);
            freq.Add('r', 5.987);
            freq.Add('d', 4.253);
            freq.Add('l', 4.025);
            freq.Add('c', 2.782);
            freq.Add('u', 2.758);
            freq.Add('m', 2.406);
            freq.Add('w', 2.36);
            freq.Add('f', 2.228);
            freq.Add('g', 2.015);
            freq.Add('y', 1.974);
            freq.Add('p', 1.929);
            freq.Add('b', 1.492);
            freq.Add('v', 0.978);
            freq.Add('k', 0.772);
            freq.Add('j', 0.153);
            freq.Add('x', 0.15);
            freq.Add('q', 0.095);
            freq.Add('z', 0.074);
            for(int i = 0; i < 25; i++)
            {
                possible_freq[i] = new Dictionary<char, double>();
                possible_freq[i].Add('e', 0);
                possible_freq[i].Add('t', 0);
                possible_freq[i].Add('a', 0);
                possible_freq[i].Add('o', 0);
                possible_freq[i].Add('i', 0);
                possible_freq[i].Add('n', 0);
                possible_freq[i].Add('s', 0);
                possible_freq[i].Add('h', 0);
                possible_freq[i].Add('r', 0);
                possible_freq[i].Add('d', 0);
                possible_freq[i].Add('l', 0);
                possible_freq[i].Add('c', 0);
                possible_freq[i].Add('u', 0);
                possible_freq[i].Add('m', 0);
                possible_freq[i].Add('w', 0);
                possible_freq[i].Add('f', 0);
                possible_freq[i].Add('g', 0);
                possible_freq[i].Add('y', 0);
                possible_freq[i].Add('p', 0);
                possible_freq[i].Add('b', 0);
                possible_freq[i].Add('v', 0);
                possible_freq[i].Add('k', 0);
                possible_freq[i].Add('j', 0);
                possible_freq[i].Add('x', 0);
                possible_freq[i].Add('q', 0);
                possible_freq[i].Add('z', 0);

            }
        }

        private void ResetFreq()
        {
            for (int i = 0; i < 25; i++)
            {
                possible_freq[i]['e'] = 0;
                possible_freq[i]['t'] = 0;
                possible_freq[i]['a'] = 0;
                possible_freq[i]['o'] = 0;
                possible_freq[i]['i'] = 0;
                possible_freq[i]['n'] = 0;
                possible_freq[i]['s'] = 0;
                possible_freq[i]['h'] = 0;
                possible_freq[i]['r'] = 0;
                possible_freq[i]['d'] = 0;
                possible_freq[i]['l'] = 0;
                possible_freq[i]['c'] = 0;
                possible_freq[i]['u'] = 0;
                possible_freq[i]['m'] = 0;
                possible_freq[i]['w'] = 0;
                possible_freq[i]['f'] = 0;
                possible_freq[i]['g'] = 0;
                possible_freq[i]['y'] = 0;
                possible_freq[i]['p'] = 0;
                possible_freq[i]['b'] = 0;
                possible_freq[i]['v'] = 0;
                possible_freq[i]['k'] = 0;
                possible_freq[i]['j'] = 0;
                possible_freq[i]['x'] = 0;
                possible_freq[i]['q'] = 0;
                possible_freq[i]['z'] = 0;
                
            }

        }

        
    }
}
