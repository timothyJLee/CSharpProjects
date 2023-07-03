using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeeTProgram5RollingDice2
{
    class PlayersClass
    {
        // PART 1:  PRIVATE INSTANCE VARIABLES: *(AKA:  Backing Fields)

        private bool _playerTurnBool;

        private string _playerNameString;

        private int _dice1NumberInteger;
        private int _dice2NumberInteger;
        private string _dice1ArtString;
        private string _dice2ArtString;

        private int _rollScoreInteger;
        private int _turnScoreInteger;

        // Accumulators(not static though)

        private int _accumulatedGamePoints;

        // Constant Values

        // Tried to make constant but didn't work
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
