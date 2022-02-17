using System;
using System.Collections.Generic;
using HerrcoApp.Classes.Entities;

namespace HerrcoApp.Classes.BusinessLogic
{
    public interface IChangeDiscoveryClass
    {
        /// <summary>
        /// Returns a data structure containing the required change messages.
        /// </summary>
        /// <param name="oldSs">The Old Spread Sheet Object.</param>
        /// <param name="newSs">The New Spread Sheet Object.</param>
        /// <returns>RecordChangesClass List</returns>
        public List<RecordChangesClass> GetUpdatedRecordsInfo(
            SpreadSheetClass oldSs, SpreadSheetClass newSs);

        /// <summary>
        /// Get the number of records added using product id lists.
        /// </summary>
        /// <param name="oldSs">The Old Spread Sheet Object.</param>
        /// <param name="newSs">The New Spread Sheet Object.</param>
        /// <returns>int</returns>
        public int GetNumRecordsAdded(SpreadSheetClass oldSs, SpreadSheetClass newSs);

        /// <summary>
        /// Get the number of records deleted using product id lists.
        /// </summary>
        /// <param name="oldSs">The Old Spread Sheet Object.</param>
        /// <param name="newSs">The New Spread Sheet Object.</param>
        /// <returns>int</returns>
        public int GetNumRecordsDeleted(SpreadSheetClass oldSs, SpreadSheetClass newSs);

        

    }
}
