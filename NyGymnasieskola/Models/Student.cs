using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NyGymnasieskola.Models
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public int PersonNr { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
    }
}
