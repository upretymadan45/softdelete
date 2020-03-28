using System;
namespace project.Models{
    public class Employee : ISoftDelete{
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public char RecStatus{ get; set; } = 'A';
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}