using System.Collections.Generic;

namespace BaiTapMVC.Models
{
    public class ClassSection
    {
        public int ClassSectionId { get; set; }

        public string Semester { get; set; }

        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        public int TeacherId { get; set; }
        public virtual Teacher Teacher { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}