using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BaiTapMVC.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        [Required]
        public string FullName { get; set; }

        public string Department { get; set; }

        public virtual ICollection<ClassSection> ClassSections { get; set; }
    }
}