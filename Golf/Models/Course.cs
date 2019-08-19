using Golf.Interfaces;
using System.Collections.Generic;

namespace Golf.Models
{
  public class Course : ICourse
  {
    public string Name { get; set; }
    public int HoleCount{get; set;}
    public List<Hole> Holes { get; set; }

    public Course(string myName, int myCount)
    {
      Name = myName;
      HoleCount = myCount;
      Holes = new List<Hole>();
    }

  }
}