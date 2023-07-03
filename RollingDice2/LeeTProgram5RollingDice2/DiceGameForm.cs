using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LeeTProgram5RollingDice2
{
    public partial class DiceGameForm : Form
    {
        public DiceGameForm()
        {
            InitializeComponent();
        }

        // INPUT FIELDS:

        private string player1NameString;
        private string player2NameString;

        // CONSTANT FIELDS:

        private const int GOAL_SCORE_INTEGER = 0;
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
        private string DIE5_ART_STRING = " ________" + Environment.NewLine +
                                    "|  @      @ |" + Environment.NewLine +
                                    "|      @      |" + Environment.NewLine +
                                    "|  @      @ |" + Environment.NewLine +
                                    "+-------------+";
        private string DIE6_ART_STRING = " ________" + Environment.NewLine +
                                "|  @      @  |" + Environment.NewLine +
                                "|  @      @  |" + Environment.NewLine +
                                "|  @      @  |" + Environment.NewLine +
                                "+-------------+";
    }
}
