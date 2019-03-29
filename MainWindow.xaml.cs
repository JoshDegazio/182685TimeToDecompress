/* Josh Degazio
 * March 29th, 2019
 * Program that outputs a given amount of symbols, also given the symbol and amount of lines.
 */
using System;
using System.Linq;
using System.Windows;

namespace _182685TimeToDecompress
{
    public partial class MainWindow : Window
    {
        //Initialize global variables
        //strings
        string inputText;
        string output;
        //arrays
        string[] inputLines;
        string[] symbol;
        //integers
        int[] symbolAmount;
        int linesAmount;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Reset output
            output = "";
            //Read input text
            inputText = inpt_Box.Text;

            //Split and clean data
            while (inputText.Contains('\r'))
            {
                int index = inputText.IndexOf('\r');
                inputText = inputText.Remove(index, 1);
            }

            inputLines = inputText.Split('\n');

            //Get top inputted value, which is supposed to be how many lines will be inputted
            int.TryParse(inputLines[0], out linesAmount);

            //Set array lengths
            symbolAmount = new int[linesAmount];
            symbol = new string[linesAmount];

            LoopToCreateSymbols();

            outpt_Block.Text = output;
        }

        private void LoopToCreateSymbols()
        {
            for (int x = 0; x < linesAmount; x++)
            {
                //If the string has 2 digits
                if (char.IsDigit(inputLines[x + 1].Substring(0, 2)[1]))
                {
                    //Set them to the amount of symbols that will be printed
                    int.TryParse(inputLines[x + 1].Substring(0, 2), out symbolAmount[x]);
                }
                //If the string has 1 digit
                else if (char.IsDigit(inputLines[x + 1].Substring(0, 1)[0]))
                {
                    //Set them to the amount of symbols that will be printed
                    int.TryParse(inputLines[x + 1].Substring(0, 1), out symbolAmount[x]);
                }
                //If the program received unexpected input
                else
                {
                    //Bamboozle em
                    MessageBox.Show("HAH");
                }


                for (int z = 0; z <= inputLines[x + 1].Length + 1; z++)
                {
                    //check if two digits are possible
                    if (inputLines[x + 1].Length > 1)
                    {
                        //remove two digits
                        if (char.IsDigit(inputLines[x + 1].Substring(0, 2)[1]))
                        {
                            inputLines[x + 1] = inputLines[x + 1].Remove(0, 2);
                        }
                        //remove one digit
                        else if (char.IsDigit(inputLines[x + 1].Substring(0, 1)[0]))
                        {
                            inputLines[x + 1] = inputLines[x + 1].Remove(0, 1);
                        }
                        //remove a space
                        else if (inputLines[x + 1][0] == ' ')
                        {
                            inputLines[x + 1] = inputLines[x + 1].Remove(inputLines[x + 1].IndexOf(' '), 1);
                        }
                        //set the symbol
                        else if (!char.IsDigit(inputLines[x + 1].Substring(0, 1)[0]))
                        {
                            symbol[x] = inputLines[x + 1].Substring(0, 1);
                        }
                    }
                    //otherwise, only one character is in the string
                    else
                    {
                        //remove one digit
                        if (char.IsDigit(inputLines[x + 1].Substring(0, 1)[0]))
                        {
                            inputLines[x + 1] = inputLines[x + 1].Remove(0, 1);
                        }
                        //remove a space
                        else if (inputLines[x + 1][0] == ' ')
                        {
                            inputLines[x + 1] = inputLines[x + 1].Remove(inputLines[x + 1].IndexOf(' '), 1);
                        }
                        //set symbol
                        else if (!char.IsDigit(inputLines[x + 1].Substring(0, 1)[0]))
                        {
                            symbol[x] = inputLines[x + 1].Substring(0, 1);
                        }
                    }
                }
            }

            //print symbols
            //for every symbol that exists
            for (int a = 0; a < linesAmount; a++)
            {
                //for every time it should be printed
                for (int b = 0; b < symbolAmount[a]; b++)
                {
                    //print the symbol
                    output += symbol[a];
                }
                //new line
                output += Environment.NewLine;
            }
        }
    }
}
