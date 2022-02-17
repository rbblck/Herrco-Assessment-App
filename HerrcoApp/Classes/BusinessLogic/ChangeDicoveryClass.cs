using System;
using System.Collections.Generic;
using System.Linq;
using HerrcoApp.Classes.Entities;
using KellermanSoftware.CompareNetObjects;
using Newtonsoft.Json;

namespace HerrcoApp.Classes.BusinessLogic
{
    public class ChangeDiscoveryClass : IChangeDiscoveryClass
    {
        // Hi
        /// <summary>
        /// Returns a data structure containing the required change messages.
        /// </summary>
        /// <param name="oldSs">The Old Spread Sheet Object.</param>
        /// <param name="newSs">The New Spread Sheet Object.</param>
        /// <returns>RecordChangesClass List</returns>
        public List<RecordChangesClass> GetUpdatedRecordsInfo(
            SpreadSheetClass oldSs, SpreadSheetClass newSs)
        {
            // Establish which record ids that are the old (non added record)
            // ids as new records will not have been updated.
            List<string> oldRecordIdList = GetProductIds(oldSs);
            List<string> newRecordIdList = GetProductIds(newSs);

            List<string> nonAddedProdIdsList = new List<string>();

            foreach (string prodId in newRecordIdList)
            {
                if (oldRecordIdList.Contains(prodId))
                {
                    nonAddedProdIdsList.Add(prodId);
                }
            }

            // Now compare the new record values with the old record values and
            // if there is a difference then add the id to the updated record
            // List.
            List<RecordChangesClass> updatedRecords = new List<RecordChangesClass>();

            // Test each record for changes from old to new.
            foreach (string nonAddedProdId in nonAddedProdIdsList)
            {
                // Has been updated control boolean.
                bool isUpdated = false;

                // Change info string.
                string changeStr = $"ProductId: {nonAddedProdId} - ";

                // Records changes class.
                RecordChangesClass recChgObj = new RecordChangesClass();

                // Get the Row object in the old spread sheet.
                RowClass oldRow = GetRowObj(nonAddedProdId, oldSs);

                // Get the cel values except the product id from the old row obj.
                string oldPalletId = (string)oldRow.Cells[1].Value;
                string oldProductDescription = (string)oldRow.Cells[2].Value;
                string oldLocationId = (string)oldRow.Cells[3].Value;

                // Get the Row object in the new spread sheet.
                RowClass newRow = GetRowObj(nonAddedProdId, newSs);

                // Get the cell values except the product id from the new row obj.
                string newPalletId = (string)newRow.Cells[1].Value;
                string newProductDescription = (string)newRow.Cells[2].Value;
                string newLocationId = (string)newRow.Cells[3].Value;

                // Now compare test each cell for a difference.
                if (!oldPalletId.Equals(newPalletId))
                {
                    isUpdated = true;
                    changeStr += $"Old PalletId: {oldPalletId}, New PalletId: " +
                        $"{newPalletId}";
                }

                if (!oldProductDescription.Equals(newProductDescription))
                {
                    isUpdated = true;
                    changeStr += $"Old ProductDescription: {oldProductDescription}, " +
                        $"New ProductDescription: {newProductDescription}";
                }

                if (!oldLocationId.Equals(newLocationId))
                {
                    isUpdated = true;
                    changeStr += $"Old LocationId: {oldLocationId}, " +
                        $"New LocationId: {newLocationId}";
                }

                // If any values were changed, add the change string and the
                // product id to the Record Changed Object and add it to the
                // Record Chenged Object List.
                if (isUpdated)
                {
                    recChgObj.ProductId = nonAddedProdId;
                    recChgObj.ChangeString = changeStr;
                    updatedRecords.Add(recChgObj);
                }
            }

            return updatedRecords;
        }

        /// <summary>
        /// Get the number of records added using product id lists.
        /// </summary>
        /// <param name="oldSs">The Old Spread Sheet Object.</param>
        /// <param name="newSs">The New Spread Sheet Object.</param>
        /// <returns>int</returns>
        public int GetNumRecordsAdded(SpreadSheetClass oldSs, SpreadSheetClass newSs)
        {
            List<string> oldRecordIdList = GetProductIds(oldSs);
            List<string> newRecordIdList = GetProductIds(newSs);

            return GetListAdditions(oldRecordIdList, newRecordIdList);
        }

        /// <summary>
        /// Get the number of records added algorithm. (Unit Tested).
        /// </summary>
        /// <param name="oldSs">The Old Spread Sheet Object.</param>
        /// <param name="newSs">The New Spread Sheet Object.</param>
        /// <returns>int</returns>
        public int GetListAdditions(List<string> oldList, List<string> newList)
        {
            IEnumerable<string> firstDiffSecond = newList.Except(oldList);
            int additions = firstDiffSecond.Count<string>();

            return additions;
        }

        /// <summary>
        /// Get the number of records deleted using product id lists.
        /// </summary>
        /// <param name="oldSs">The Old Spread Sheet Object.</param>
        /// <param name="newSs">The New Spread Sheet Object.</param>
        /// <returns>int</returns>
        public int GetNumRecordsDeleted(SpreadSheetClass oldSs, SpreadSheetClass newSs)
        {
            List<string> oldRecordIdList = GetProductIds(oldSs);
            List<string> newRecordIdList = GetProductIds(newSs);

            return GetListDeletions(oldRecordIdList, newRecordIdList);
        }

        // Get the number of records deleted algorithm. (Unit Tested).
        public int GetListDeletions(List<string> oldList, List<string> newList)
        {
            IEnumerable<string> firstDiffSecond = oldList.Except(newList);
            int deletions = firstDiffSecond.Count<string>();

            return deletions;
        }

        /// <summary>
        /// Creates the updated message list to be returned to the Home View.
        /// </summary>
        /// <param name="trackingClass">The Spread Spread Sheet Tracking
        /// Object.</param>
        /// <returns>Message List</returns>
        public List<string> GetUpdateMessages(
            SpreadSheetTrackingClass trackingClass)
        {
            List<string> updateMsgs = new List<string>();

            foreach (RecordChangesClass recChg in trackingClass.UpdateDetails)
            {
                updateMsgs.Add(recChg.ChangeString);
            }

            if (updateMsgs.Count == 0)
            {
                updateMsgs.Add("No Updates");
            }

            return updateMsgs;
        }

        /// <summary>
        /// Returns a list of all the product ids from a given spread sheet
        /// object.
        /// </summary>
        /// <param name="spreadShetObj">The Spread Sheet Object.</param>
        /// <returns>Returns a list of all the product ids</returns>
        private List<string> GetProductIds(SpreadSheetClass spreadShetObj)
        {
            List<string> productIdList = new List<string>();

            foreach (RowClass row in spreadShetObj.Rows)
            {
                productIdList.Add((string)row.Cells[0].Value);
            }

            return productIdList;
        }

        private string GetProdId(RowClass getRowObj)
        {
            return (string)getRowObj.Cells[0].Value;
        }

        private RowClass GetRowObj(string prodId, SpreadSheetClass ss)
        {
            RowClass rowObj = null;

            foreach (RowClass ssRowObj in ss.Rows)
            {
                string rowProdId = GetProdId(ssRowObj);

                if (rowProdId.Equals(prodId))
                {
                    rowObj = ssRowObj;
                }
            }

            return rowObj;
        }

        /// <summary>
        /// Returns a cell column name for a given column id for possible
        /// future use.
        /// </summary>
        /// <param name="colId">The Cell Id Value.</param>
        /// <param name="ss">The Spread Sheet Object.</param>
        /// <returns>Cell Column Name</returns>
        private string GetCellColumnName(int colId, SpreadSheetClass ss)
        {
            string columeName = null;

            foreach (ColumnClass colObj in ss.Columns)
            {
                if (colObj.Id == colId)
                {
                    columeName = colObj.Name;
                }
            }

            return columeName;
        }
    }
}
