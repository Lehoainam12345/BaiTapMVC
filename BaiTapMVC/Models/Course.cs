using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaiTapMVC.Models
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        public int Credits { get; set; }

        public virtual ICollection<ClassSection> ClassSections { get; set; }
    }
}