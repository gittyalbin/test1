using System.ComponentModel.DataAnnotations.Schema;

namespace test2.Models
{
    [Table("Test")]
    public class Test
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public int Age { get; set; }
    }
}
