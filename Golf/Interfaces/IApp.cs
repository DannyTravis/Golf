using System.Collections.Generic;
using Golf.Models;

namespace Golf.Interfaces
{
    public interface IApp
    {
                //NOTE don't forget to create a Course model and then within this file declare `using Golf.Models`
        Course ActiveCourse { get; set; } 
        List<Player> Players { get; set; }
        List<Course> Courses { get; set; }


        void Setup(); //NOTE responsible for initializing your data and establishing relationships (ie, adding course instances to the Courses list, etc.).
        void Greeting(); //NOTE may or may not utilize this simple greeting method
        void DisplayCourses(); //NOTE iterate over the Courses list and display the names and details to the user so that they know their course options
        void SelectCourse(); //NOTE gracefully handles bad inputs and assigns the ActiveCourse based on appropriate user selection
        void SetPlayers(); //NOTE responsible for determining number of players and generating a new player instance for each and adding them to the list of players
        void Run(); //NOTE responsible for managing application flow and gameplay
        void DisplayPlayerResults(); //NOTE responsible for determining winner and [STRETCH GOAL] listing out players scores per hole
        void gameplay();
   }
}