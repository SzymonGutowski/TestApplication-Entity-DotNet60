using System.ComponentModel.DataAnnotations;

namespace TestApplication
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Character { get; set; }
        public int? Age { get; set; }

    }
}
