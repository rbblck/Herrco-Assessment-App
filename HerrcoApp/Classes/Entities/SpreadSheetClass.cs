using System;
using System.Collections.Generic;

namespace HerrcoApp.Classes.Entities
{
    public class SpreadSheetClass
    {

        public SpreadSheetClass(string name)
        {
            Id = 0;
            Name = name;
            Rows = new List<RowClass>();
            Columns = new List<ColumnClass>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<RowClass> Rows { get; set; }
        public List<ColumnClass> Columns { get; set; }

    }
}
