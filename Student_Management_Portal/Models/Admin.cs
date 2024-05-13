using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_Portal;

public class Admin
{
    public int AdminId { get; set; }
    public string? UploadCSV { get; set; }
    public int UserId { get; set; }//Foreign key
    public virtual User? User { get; set; } //User property is a navigation property
}
