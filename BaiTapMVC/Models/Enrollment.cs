using System;

namespace BaiTapMVC.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public int ClassSectionId { get; set; }
        public virtual ClassSection ClassSection { get; set; }

        public DateTime EnrollDate { get; set; }
    }
}