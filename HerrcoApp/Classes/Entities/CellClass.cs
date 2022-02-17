using System;
namespace HerrcoApp.Classes.Entities
{
    public class CellClass
    {
        public CellClass(int columnId, int rowId, object value)
        {
            ColumnId = columnId;
            RowId = rowId;
            Value = value;
        }

        public int ColumnId { get; set; }
        public int RowId { get; set; }
        public object Value { get; set; }

    }
}
