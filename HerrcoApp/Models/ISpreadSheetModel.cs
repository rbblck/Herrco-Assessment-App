using System;
using HerrcoApp.Classes.BusinessLogic;
using HerrcoApp.Classes.Entities;

namespace HerrcoApp.Models
{
    public interface ISpreadSheetModel
    {

        /// <summary>
        /// Get all the required spread sheet tracking information and stores
        /// it into an object to be returned.
        /// </summary>
        /// <returns>SpreadSheetTrackingClass</returns>
        public SpreadSheetTrackingClass GetTrackingInformation();

        /// <summary>
        /// Initailises the stored spead sheet on app start to prepare for the
        /// first ping action in the UI.
        /// </summary>
        /// <returns>void</returns>
        // This method will get the latest spread sheet data from the api server.
        void InitialiseStoredSpreadSheet();

    }
}
