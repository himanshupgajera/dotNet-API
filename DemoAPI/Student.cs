using System.Reflection;

namespace DemoAPI
{
    public class Student
    {
        public long Id { get; set; }

        public required string Name { get; set; }

        public required string RollNumber { get; set; }

        public required string Standard { get; set; }
    }
}
