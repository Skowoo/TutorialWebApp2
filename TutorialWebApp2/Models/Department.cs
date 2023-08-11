using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TutorialWebApp2.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }


        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }


        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }


        public int? InstructorID { get; set; }
        public Instructor Administrator { get; set; }


        [Timestamp] //Concurency token - https://learn.microsoft.com/en-us/aspnet/core/data/ef-rp/concurrency?view=aspnetcore-7.0&tabs=visual-studio
        public byte[] ConcurrencyToken { get; set; }


        public ICollection<Course> Courses { get; set; }
    }
}
