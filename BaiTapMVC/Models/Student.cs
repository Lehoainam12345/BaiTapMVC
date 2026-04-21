using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaiTapMVC.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}