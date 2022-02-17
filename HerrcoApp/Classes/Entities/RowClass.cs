using System;
using System.Collections.Generic;

namespace HerrcoApp.Classes.Entities
{
    public class RowClass
    {

        public RowClass(int id, List<CellClass> cells)
        {
            Id = id;
            Cells = cells;
        }

        public int Id { get; set; }
        public List<CellClass> Cells { get; set; }

    }
}
