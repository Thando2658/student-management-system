using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_Portal;

public class Parent
{
    public int ParentId { get; set; }
    public string? ContactDetails { get; set; }
    public string? AddressDetails { get; set; }
    public int UserId { get; set; }//Foreign key
    public virtual User? User { get; set; } //User property is a navigation property
}
