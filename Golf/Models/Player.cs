using System.Collections.Generic;
using Golf.Interfaces;
using System;

namespace Golf.Models
{
  public class Player : IPlayer
  {

    public string Name { get; set; }
    public List<int> Scores { get; set; }

    public int FinalScore{get; set;}

    public void DisplayFinalScore()
    {
      Console.WriteLine(Name);
      Console.WriteLine("Scores per Hole: ");
      int totCount = 0;
      for(int i = 0; i < Scores.Count; i++)
      {
        Console.WriteLine($"Hole {i+1}: {Scores[i]}");
        totCount += Scores[i];
      }
      Console.WriteLine("Total Score: " + totCount);
    }

    public Player(string myName)
    {
      Name = myName;
      FinalScore = 0;
      Scores = new List<int>();
    }

  }
}