using System.Collections.Generic;
using System;
using Golf.Interfaces;

namespace Golf.Models
{
  public class App : IApp
  {
    public Course ActiveCourse { get; set; }
    public List<Player> Players { get; set; }
    public List<Course> Courses { get; set; }

    public bool gameIsAlive = true;





    public void DisplayCourses()
    {
      List<Course> availCourses = Courses;
      int index = 0;
      foreach(ICourse thisCourse in availCourses)
      {
      Console.WriteLine($"{index+1} {thisCourse.Name}    Holes: {thisCourse.HoleCount}");
      index++;
      }
    }

    public void DisplayPlayerResults()
    {
      int totScore = 0;
      int lowestScore = 0;
      List<Player> availPlayers = Players;
      IPlayer winningPlayer = new Player("");
      foreach(IPlayer thisPlayer in availPlayers)
      {
        Console.Write($"Player: {thisPlayer.Name}\n\r "); 
        for(int i =0; i<thisPlayer.Scores.Count;i++)
        {
          Console.WriteLine($"Hole {i+1}: {thisPlayer.Scores[i]}");
          totScore+=thisPlayer.Scores[i];
        }
        Console.WriteLine($"\n\rTotal Score: {totScore}");
        thisPlayer.FinalScore = totScore;
      }
   /*    foreach(IPlayer winPlayer in availPlayers)
      {
        if(winPlayer.FinalScore < winningPlayer.FinalScore){
        winningPlayer = winPlayer;
        }
      }*/
      for(int i=0; i<Players.Count;i++){
        if(Players[i].FinalScore< lowestScore || lowestScore == 0)
        {
          lowestScore = Players[i].FinalScore;
          winningPlayer = Players[i];
        }
      }
      Console.WriteLine($"\n\r**** {winningPlayer.Name} Wins!! ****\n\r");
    }

    public void Greeting()
    {
      bool validChoice = false;
      //create a menu to opperate in
      Console.WriteLine("**************************");
      Console.WriteLine("***** Console Golf 64 ****");
      Console.WriteLine("1) Display Courses");
      Console.WriteLine("2) Start Game");
      Console.WriteLine("3) Quite Game");
      Console.WriteLine("**************************");
      Console.Write(":");
      while(!validChoice){
      switch(Console.ReadLine())
        {
        case "1":
          validChoice = true;
          DisplayCourses();
          break;
        case "2":
          validChoice = true;
          gameplay();   
          break;
        case "3":
          validChoice = true;
          gameIsAlive = false;
          break;
        default:
          validChoice = false;
          Console.WriteLine("Not a valid choice");
          break;
        }
      }
    }

    public void Run()
    {

      while (gameIsAlive)
      {
        {
          Greeting();
        }

      }

    }

    public void SelectCourse()
    {
      Console.Clear();
      Console.WriteLine("Courses: ");
      DisplayCourses();
      bool isValid = false;
      while(!isValid){
        Console.Write("Selection: ");
        int numCourses = Courses.Count;
       // Console.WriteLine("Debug, course count is " + numCourses);
        string userChoice = Console.ReadLine();
        int tmpChoice = 0;
        if(!Int32.TryParse(userChoice, out tmpChoice)) {
          Console.WriteLine("must be a number");
        }
        else if(tmpChoice <= 0 || tmpChoice > numCourses){
          Console.WriteLine("You picked " + tmpChoice);
          Console.WriteLine("Out of Range, select again ");
        }
        else{
          ActiveCourse = Courses[tmpChoice-1];
          isValid = true;
        }  
      }
    }

    public void SetPlayers()
    {
      // get random NPC's and the player
      // lets get the player first
      string userName = ""; 
      Console.Write("Player Name: ");
      userName = Console.ReadLine();
      Player userPlayer = new Player(userName);
      Players.Add(userPlayer);
      // now lets generate our NPC's
      // Get the number 
      bool isNumber = false;
      int userNum = 0;
      while(!isNumber)
      {
      Console.Write("How maney other players: ");
      string numPlayers = Console.ReadLine();
     
      if(!Int32.TryParse(numPlayers, out userNum ))
      {
        Console.WriteLine("Must be a valid number");
        isNumber = false;
      }
      else if(userNum <= 0)
      {
        Console.WriteLine("You cant have less that 1 player");
        isNumber = false;
      }
      else
      {
        isNumber = true;
      }
      }
      // get the names
      for(int i=0;i<userNum;i++)
      {
        Console.Write($"Player {i+1} Name: ");
        string thisName = Console.ReadLine();
        Player thisNPC = new Player(thisName);
        Players.Add(thisNPC);
        Console.Write($"Loaded {thisNPC.Name}\n\r");
      }

      
    }

    public void Setup()
    {
      // The setup

      SelectCourse();
      SetPlayers();

    }


    public void gameplay()
    {
      Setup();
      Console.WriteLine($"Course: {ActiveCourse.Name}");
      Console.WriteLine("Game Start!");
      for (int i= 0; i< ActiveCourse.HoleCount;i++)
      {
        Console.WriteLine($"Hole {i+1}: ");
        for(int j = 0; j<Players.Count;j++)
        {
          Console.Write($"Enter {Players[j].Name}'s Stroke Count: ");
          string tmpStroke = Console.ReadLine();
          int thisStroke = 0;
          if(!Int32.TryParse(tmpStroke, out thisStroke ))
          {
             Console.WriteLine("Strokes have to be a number, thats a penalty of 10 >=(");
             thisStroke = 10;
          }
          else if(thisStroke <= 0)
          {
            Console.WriteLine("You gotta swing, cant go negative or zero >=( thats a penalty of 10");
            thisStroke = 10;
          }
          else{
            Players[j].Scores.Add(thisStroke);
          }
        }
      }
      Console.WriteLine("\n\r*****Course Over! *****");
      Console.WriteLine("Scores: ");
      DisplayPlayerResults();
    }

    public App()
    {
    Course canyonSprings = new Course("Canyon Springs", 8);
    Course pineValley = new Course("Pine Valley", 5);
    Course kiddieLand = new Course("KiddieLand", 3);

    Courses = new List<Course>();
    Players = new List<Player>();
    Courses.Add(canyonSprings);
    Courses.Add(pineValley);
    Courses.Add(kiddieLand);
    }
  }
}