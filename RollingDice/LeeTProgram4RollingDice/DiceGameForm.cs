

///  Timothy lee
///  11/1/12
///  ClassRoomPointOfView:
///   - List boxes, Files (open/close/write/read), random numbers, loops, 
///     accumulations, design of user interface, game play
///  BusinessPointOfView:
///   -This is a Game Program for 2 players at time – it’s a Dice Game
///     
///  DECISIONS: case, if, If-else, try-catch, nested decisions, single line if
///  LOOPS: While loop
///  METHODS: MessageBox.Show(), RandomNumberPicker(), DiceAssigner(), 
///  CalculateScore(), AccumulateScore(), CheckForWin(), WritePlayersLog(), 
///  ClearForNewGame(), ClearTotalsInputs(), ClearTurnTotals()
///  EVENTS: Button_Click , RadioButton_CheckedChanged, Form_Load



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// added classes and stuff
using System.IO;  // reading and writing to log

namespace LeeTProgram4RollingDice
{
    public partial class DiceGameForm : Form
    {
        public DiceGameForm()
        {
            InitializeComponent();
        }

        //

        // INPUT FIELDS:

        private string player1NameString;
        private string player2NameString;

        // CALCULATED FIELDS:

        private bool playerDecisionBoolean = true;
        private string playerString;

        private int dice1NumberInteger;
        private int dice2NumberInteger;

        private int scoreInteger = 0;
        private int turnScoreInteger = 0;
        
        // ACCUMULATED FIELDS:

        private int player1TotalScoreInteger = 0;
        private int player2TotalScoreInteger = 0;
        
        // CONSTANT FIELDS:

        private const int GOAL_SCORE_INTEGER = 50;
        private const int DOUBLE_ONE_BONUS_INTEGER = 25;

        // tried to make these constant but wouldn't work
        private string DIE1_ART_STRING = " ________" + Environment.NewLine +
                                    "|                |" + Environment.NewLine +
                                    "|      @      |" + Environment.NewLine +
                                    "|                |" + Environment.NewLine +
                                    "+-------------+";

        private string DIE2_ART_STRING = " ________" + Environment.NewLine +
                                    "|  @          |" + Environment.NewLine +
                                    "|                |" + Environment.NewLine +
                                    "|          @  |" + Environment.NewLine +
                                    "+-------------+";

        private string DIE3_ART_STRING = " ________" + Environment.NewLine +
                                    "|  @          |" + Environment.NewLine +
                                    "|      @      |" + Environment.NewLine +
                                    "|           @ |" + Environment.NewLine +
                                    "+-------------+";
        private string DIE4_ART_STRING = " ________" + Environment.NewLine +
                                    "|  @      @ |" + Environment.NewLine +
                                    "|                |" + Environment.NewLine +
                                    "|  @      @ |" + Environment.NewLine +
                                    "+-------------+";
        private string DIE5_ART_STRING =" ________" + Environment.NewLine +
                                    "|  @      @ |" + Environment.NewLine +
                                    "|      @      |" + Environment.NewLine +
                                    "|  @      @ |" + Environment.NewLine +
                                    "+-------------+";
        private string DIE6_ART_STRING = " ________" + Environment.NewLine +
                                "|  @      @  |" + Environment.NewLine +
                                "|  @      @  |" + Environment.NewLine +
                                "|  @      @  |" + Environment.NewLine +
                                "+-------------+";


        private void DiceGameForm_Load(object sender, EventArgs e)
        {
            die1DisplayLabel.Text = "";
            die2DisplayLabel.Text = "";
            player1Label.ForeColor = Color.Red;
            //playerNameLabel.Text = "Enter Name:       Player1:" + Environment.NewLine + Environment.NewLine +
                                  // "                           Player2:";
        }

        private void rollDiceButton_Click(object sender, EventArgs e)
        {  // selected player rolling dice
            player1NameString = player1NameTextBox.Text;
            player2NameString = player2NameTextBox.Text;

            CheckForWin();
            RandomDiceNumberPicker();
            DiceAssigner();
            CalculateScore();
            //ClearTurnTotals();
        }

        private void RandomDiceNumberPicker()  // pick a random number for dice
        {
           Random randNum = new Random();
            dice1NumberInteger = randNum.Next(6) + 1;
            dice2NumberInteger = randNum.Next(6) + 1;
        }

        private void DiceAssigner()  // Assign random number to dice using case
        {
            if (twoDiceRadioButton.Checked || oneDieRadioButton.Checked)
            {
                switch (dice1NumberInteger.ToString())
                {
                case "1":
                    {
                        die1DisplayLabel.Text = DIE1_ART_STRING;
                    }
                    break;
                case "2":
                    {
                        die1DisplayLabel.Text = DIE2_ART_STRING;
                    }
                    break;
                case "3":
                    {
                        die1DisplayLabel.Text = DIE3_ART_STRING;
                    }
                    break;
                case "4":
                    {
                        die1DisplayLabel.Text = DIE4_ART_STRING;
                    }
                    break;
                case "5":
                    {
                        die1DisplayLabel.Text = DIE5_ART_STRING;
                    }
                    break;
                case "6":
                    {
                        die1DisplayLabel.Text = DIE6_ART_STRING;
                    }
                    break;
                default:
                    {
                        MessageBox.Show("SOMETHING WENT WRONG", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
            }
        }

            if (twoDiceRadioButton.Checked)  // for one dice
            {
                switch (dice2NumberInteger.ToString())
                {
                    case "1":
                        {
                            die2DisplayLabel.Text = DIE1_ART_STRING;
                        }
                        break;
                    case "2":
                        {
                            die2DisplayLabel.Text = DIE2_ART_STRING;
                        }
                        break;
                    case "3":
                        {
                            die2DisplayLabel.Text = DIE3_ART_STRING;
                        }
                        break;
                    case "4":
                        {
                            die2DisplayLabel.Text = DIE4_ART_STRING;
                        }
                        break;
                    case "5":
                        {
                            die2DisplayLabel.Text = DIE5_ART_STRING;
                        }
                        break;
                    case "6":
                        {
                            die2DisplayLabel.Text = DIE6_ART_STRING;
                        }
                        break;
                    default:
                        {
                            MessageBox.Show("SOMETHING WENT WRONG", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
            }
        }

        private void CalculateScore()  // Calculating a score for that turn
        {
            if (playerDecisionBoolean)  // deciding which player to write in listbox log
            {
                playerString = "Player1: ";
            }
            else
            {
                playerString = "Player2: ";
            }

            if (twoDiceRadioButton.Checked)
            {
                if ((dice1NumberInteger == 1) && (dice2NumberInteger == 1))
                {
                    turnScoreInteger = DOUBLE_ONE_BONUS_INTEGER;  // Double ones

                    gameDisplayListBox.Items.Add(playerString + "Double Ones = " + DOUBLE_ONE_BONUS_INTEGER + "!");
                }
                else
                {
                    if ((dice1NumberInteger == 1) || (dice2NumberInteger == 1))
                    {
                        turnScoreInteger = 0;  // Single ones

                        gameDisplayListBox.Items.Add(playerString + dice1NumberInteger + " " + "+" + " " + dice2NumberInteger +
                                          " = Single 1, no pts, turn over!");

                        // holdButton_Click(sender, e);                        
                        AccumulateScore();
                        accumulatedGamePointsLabel.Text = "Score:  " + player1TotalScoreInteger + " / " + player2TotalScoreInteger;
                        playerDecisionBoolean = !playerDecisionBoolean;
                        
                        if (playerDecisionBoolean)
                        {
                            player1Label.ForeColor = Color.Red;
                            player2Label.ForeColor = Color.Black;
                        }
                        else
                        {
                            player2Label.ForeColor = Color.Red;
                            player1Label.ForeColor = Color.Black;
                        }

                        ClearTurnTotals();
                        die1DisplayLabel.Text = "";
                        die2DisplayLabel.Text = "";
                    }
                    else
                    {
                        if (dice1NumberInteger == dice2NumberInteger)
                        {  // Double Dice
                            dice1NumberInteger = dice1NumberInteger * 2;
                            dice2NumberInteger = dice2NumberInteger * 2;

                            scoreInteger = dice1NumberInteger + dice2NumberInteger;
                            turnScoreInteger += scoreInteger;

                            gameDisplayListBox.Items.Add(playerString + dice1NumberInteger + " " + "+" + " " + dice2NumberInteger +
                                          " = " + turnScoreInteger + "Double Die Number, Double pts!");
                        }
                        else
                        {  // Just a regular turn
                            scoreInteger = dice1NumberInteger + dice2NumberInteger;
                            turnScoreInteger += scoreInteger;

                            gameDisplayListBox.Items.Add(playerString + dice1NumberInteger + " " + "+" + " " + dice2NumberInteger +
                                          " = " + turnScoreInteger);
                        }
                    }
                }
            }
            else
            {
                if (oneDieRadioButton.Checked)  // Same for one die
                {
                    if (dice1NumberInteger == 1)
                    {
                        turnScoreInteger = 0;

                        gameDisplayListBox.Items.Add(playerString + dice1NumberInteger + " = Single 1, no pts, turn over!");

                        // holdButton_Click(sender, e);                        
                        AccumulateScore();
                        playerDecisionBoolean = !playerDecisionBoolean;

                        if (playerDecisionBoolean)
                        {
                            player1Label.ForeColor = Color.Red;
                            player2Label.ForeColor = Color.Black;
                        }
                        else
                        {
                            player2Label.ForeColor = Color.Red;
                            player1Label.ForeColor = Color.Black;
                        }

                        ClearTurnTotals();
                        die1DisplayLabel.Text = "";
                        die2DisplayLabel.Text = "";
                    }
                    else
                    {
                        scoreInteger = dice1NumberInteger;
                        turnScoreInteger = scoreInteger;

                        gameDisplayListBox.Items.Add(playerString + dice1NumberInteger + " = " + turnScoreInteger);
                    }
                }
                else
                {
                    MessageBox.Show("Click Dice Number", "INPUT - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            scoreInteger = 0;
        }

        private void AccumulateScore()  // Accumulating score to final totals
        {
            if (playerDecisionBoolean)
            {
                player1TotalScoreInteger += turnScoreInteger;
            }
            else
            {
                player2TotalScoreInteger += turnScoreInteger;
            }
            accumulatedGamePointsLabel.Text = "Score:  " + player1TotalScoreInteger + " / " + player2TotalScoreInteger;
        }

        private void CheckForWin()  // Checking to see if a player won and writing log
        {
            if (player1TotalScoreInteger > GOAL_SCORE_INTEGER)
            {
                MessageBox.Show("PLAYER 1 HAS WON THE GAME!");
                WritePlayersLog();
            }
            if (player2TotalScoreInteger > GOAL_SCORE_INTEGER)
            {
                MessageBox.Show("PLAYER 2 HAS WON THE GAME!");
                WritePlayersLog();
            }
        }

        private void WritePlayersLog() // Writing in the log file for record keeping
        {
            string outputString;
            string lineString;

            try
            {
                StreamWriter GameLogFile;

                lineString = player1NameTextBox.Text + ": " + player1TotalScoreInteger.ToString() + Environment.NewLine +
                             player2NameTextBox.Text + ": " + player2TotalScoreInteger.ToString();
                // Log for players 1 and 2

                outputString = lineString;

          
                    GameLogFile = File.AppendText("Players.txt");
                    GameLogFile.WriteLine(outputString);        // write string to file (at end)
                    GameLogFile.Close();                    // close the file
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void holdButton_Click(object sender, EventArgs e)
        {  // Ending your turn and accumulating your score
            

            AccumulateScore();
            playerDecisionBoolean = !playerDecisionBoolean;

            if (playerDecisionBoolean)
            {
                player1Label.ForeColor = Color.Red;
                player2Label.ForeColor = Color.Black;
            }
            else
            {
                player2Label.ForeColor = Color.Red;
                player1Label.ForeColor = Color.Black;
            }

            ClearTurnTotals();
            die1DisplayLabel.Text = "";
            die2DisplayLabel.Text = "";
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {  // Starting a new game
            ClearForNewGame();
            player1NameTextBox.Focus();
        }

        private void ClearForNewGame()  // Clearing all the totals and boxes for new game
        {
            ClearTotalsInputs();

            playerDecisionBoolean = true;

            twoDiceRadioButton.Checked = true;
            twoDiceRadioButton.Checked = false;

            gameDisplayListBox.Items.Clear();

            player1NameTextBox.Text = "";
            player2NameTextBox.Text = "";

            accumulatedGamePointsLabel.Text = "";
            die1DisplayLabel.Text = "";
            die2DisplayLabel.Text = "";
        }

        private void ClearTotalsInputs()  // Clearing the Totals
        {
            scoreInteger = 0;
            turnScoreInteger = 0;
            player1TotalScoreInteger = 0;
            player2TotalScoreInteger = 0;

            player1NameString = "";
            player2NameString = "";
        }

        private void ClearTurnTotals()  // Clearing totals for turn
        {
            scoreInteger = 0;
            turnScoreInteger = 0;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {  // Exits the program
            this.Close();
        }

        private void testButton_Click(object sender, EventArgs e)
        {  // Tests the program
            twoDiceRadioButton.Checked = true; ;
            player1NameTextBox.Text = "Dawn'sTime";
            player2NameTextBox.Text = "MyGrade";
        }

        private void gameLogsButton_Click(object sender, EventArgs e)
        {  // reading from the log file and displaying it in the listbox
           // so you can see the records for past games
            ClearForNewGame();
            try
            {
                StreamReader GameLogFile;

                    GameLogFile = File.OpenText("Players.txt");

                    while (!GameLogFile.EndOfStream)      // while NOT at eof
                    {
                        gameDisplayListBox.Items.Add(GameLogFile.ReadLine() + Environment.NewLine + Environment.NewLine);
                    }
                    GameLogFile.Close();
            }
            catch (Exception fileError)
            { 
                MessageBox.Show(fileError.Message);
            }
        }
    }
}
