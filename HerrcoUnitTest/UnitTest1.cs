using System;
using Xunit;
using HerrcoApp;
using HerrcoApp.Classes.BusinessLogic;
using System.Collections.Generic;
using HerrcoApp.Classes.Entities;
using System.IO;
using Newtonsoft.Json;

namespace HerrcoUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void GetListAdditions()
        {
            // Setup
            int expected = 3;

            // Action
            List<string> list1 = new List<string>();
            list1.Add("Robert");
            list1.Add("Carl");
            list1.Add("Andy");
            list1.Add("Shara");

            List<string> list2 = new List<string>();
            list2.Add("Robert");
            list2.Add("Andy");
            list2.Add("Jack");
            list2.Add("Amy");
            list2.Add("Mark");

            ChangeDiscoveryClass cdc = new ChangeDiscoveryClass();
            int actual = cdc.GetListAdditions(list1, list2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNumRecordsDeleted()
        {
            // Setup
            int expected = 3;

            // Action
            List<string> list1 = new List<string>();
            list1.Add("Robert");
            list1.Add("Carl");
            list1.Add("Andy");
            list1.Add("Shara");
            list1.Add("Jack");
            list1.Add("Amy");
            list1.Add("Mark");

            List<string> list2 = new List<string>();
            list2.Add("Robert");
            list2.Add("Carl");
            list2.Add("Amy");
            list2.Add("Mark");
            list2.Add("Pui");
            list2.Add("Paul");

            ChangeDiscoveryClass cdc = new ChangeDiscoveryClass();
            int actual = cdc.GetListDeletions(list1, list2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetUpdatedRecordsIds()
        {
            // Setup
            int expectedChg = 1;
            string expectedhangeStr =
                "ProductId: 08253efd-dc28-4d95-8e2f-ccbcb5070815 - " +
                "Old ProductDescription: Hand Soap-1914, " +
                "New ProductDescription: Loction-2001";

            // Action
            SpreadSheetClass ss1 = getSpreadSheet1();
            SpreadSheetClass ss2 = getSpreadSheet2();

            ChangeDiscoveryClass cdc = new ChangeDiscoveryClass();

            List<RecordChangesClass> changList =
                cdc.GetUpdatedRecordsInfo(ss1, ss2);

            int actualNumUpDts = changList.Count;
            string actualChg = changList[0].ChangeString;

            // Assert
            Assert.Equal(expectedChg, actualNumUpDts);
            Assert.Equal(expectedhangeStr, actualChg);
        }

        private SpreadSheetClass getSpreadSheet1()
        {
            SpreadSheetClass ss1 = new SpreadSheetClass("Spread 1");
            ss1.Id = 0;
            ss1.Name = "Sheet1";
            List<CellClass> cells = new List<CellClass>();
            cells.Add(new CellClass(0, 0, "08253efd-dc28-4d95-8e2f-ccbcb5070815"));
            cells.Add(new CellClass(1, 0, "P001018"));
            cells.Add(new CellClass(2, 0, "Hand Soap-1914"));
            cells.Add(new CellClass(3, 0, "WH6-0"));
            RowClass row1 = new RowClass(0, cells);
            List<RowClass> rows = new List<RowClass>();
            rows.Add(row1);
            ss1.Rows = rows;
            List<ColumnClass> columns = new List<ColumnClass>();
            ColumnClass col1 = new ColumnClass(0, "id");
            columns.Add(col1);
            ColumnClass col2 = new ColumnClass(0, "PalletId");
            columns.Add(col2);
            ColumnClass col3 = new ColumnClass(0, "ProductDescription");
            columns.Add(col3);
            ColumnClass col4 = new ColumnClass(0, "LocationId");
            columns.Add(col4);
            ss1.Columns = columns;

            return ss1;
        }

        private SpreadSheetClass getSpreadSheet2()
        {
            SpreadSheetClass ss1 = new SpreadSheetClass("Spread 2");
            ss1.Id = 0;
            ss1.Name = "Sheet1";
            List<CellClass> cells = new List<CellClass>();
            cells.Add(new CellClass(0, 0, "08253efd-dc28-4d95-8e2f-ccbcb5070815"));
            cells.Add(new CellClass(1, 0, "P001018"));
            cells.Add(new CellClass(2, 0, "Loction-2001"));
            cells.Add(new CellClass(3, 0, "WH6-0"));
            RowClass row1 = new RowClass(0, cells);
            List<RowClass> rows = new List<RowClass>();
            rows.Add(row1);
            ss1.Rows = rows;
            List<ColumnClass> columns = new List<ColumnClass>();
            ColumnClass col1 = new ColumnClass(0, "id");
            columns.Add(col1);
            ColumnClass col2 = new ColumnClass(0, "PalletId");
            columns.Add(col2);
            ColumnClass col3 = new ColumnClass(0, "ProductDescription");
            columns.Add(col3);
            ColumnClass col4 = new ColumnClass(0, "LocationId");
            columns.Add(col4);
            ss1.Columns = columns;

            return ss1;
        }

    }
}
