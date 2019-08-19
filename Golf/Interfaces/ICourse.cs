using System.Collections.Generic;
using Golf.Models;


namespace Golf.Interfaces
{
    public interface ICourse
    {
        
        //NOTE don't forget to create a Course model and then within this file declare `using Golf.Models`
        string Name { get; set; }
        //added for convinience
        int HoleCount{get; set;}
        List<Hole> Holes { get; set; }
    }
}