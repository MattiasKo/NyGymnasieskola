using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace NyGymnasieskola.Models
{
    public partial class Course
    {
        public int StudentId { get; set; }
        public string CourseName { get; set; }
        public int TeacherId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime GradeDate { get; set; }
        public string Grade { get; set; }
    }
}
