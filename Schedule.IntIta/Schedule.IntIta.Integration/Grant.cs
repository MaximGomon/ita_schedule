using System;

namespace Schedule.IntIta.Integration
{
    public class Grant
    {
        public static int nextID;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        private Grant()
        {
            Id = nextID;
            Name = string.Empty;
            Code = string.Empty;
            nextID++;
        }
        private Grant(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }

        public static Grant Create(string Name, string code)
        {
            return new Grant(nextID++, Name, code);
        }
    }
}
