using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_Portal;

public class Student
{
    public int StudentId { get; set; }
    public DateTime DOB { get; set; }
    public string? Sex { get; set; }
    public string? Grade { get; set; }
    public string? StudentNumber { get; set; }
    public string? ProfilePicture { get; set; }
    public int UserId { get; set; }//Foreign key
    public virtual User? User { get; set; } //User property is a navigation property
}
