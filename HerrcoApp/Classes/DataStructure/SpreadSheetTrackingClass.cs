using System;
using System.Collections.Generic;
using HerrcoApp.Classes.Entities;

namespace HerrcoApp.Classes.BusinessLogic
{
    public class SpreadSheetTrackingClass
    {
        public int NumerOfDeletes { get; set; }
        public int NumberOfAdditions { get; set; }
        public int NumberOfUpdates { get; set; }
        public int NumberOfErrors { get; set; }
        public List<RecordChangesClass> UpdateDetails { get; set; }
    }
}
