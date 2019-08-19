using System.Collections.Generic;

namespace Golf.Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }
        int FinalScore{get; set;}
        List<int> Scores { get; set; }

        void DisplayFinalScore(); //NOTE responsible for summing up all of the scores in the player's Scores property and displaying the result to the user
    }
}