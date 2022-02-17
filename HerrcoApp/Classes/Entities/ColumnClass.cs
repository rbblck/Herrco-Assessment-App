using System;
namespace HerrcoApp.Classes.Entities
{
    public class ColumnClass
    {

        public ColumnClass(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

    }
}
