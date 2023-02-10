using System.ComponentModel.DataAnnotations;

namespace CaseProject.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
