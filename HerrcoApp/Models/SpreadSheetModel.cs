using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using HerrcoApp.Classes;
using HerrcoApp.Classes.BusinessLogic;
using HerrcoApp.Classes.Constants;
using HerrcoApp.Classes.Entities;
using Newtonsoft.Json;

namespace HerrcoApp.Models
{
    public class SpreadSheetModel : ISpreadSheetModel
    {
        /// <summary>
        /// Get all the required spread sheet tracking information and stores
        /// it into an object to be returned.
        /// </summary>
        /// <returns>SpreadSheetTrackingClass</returns>
        public SpreadSheetTrackingClass GetTrackingInformation()
        {
            // Init a SpreadSheetTrackingClass object to take all the changes.
            SpreadSheetTrackingClass stc = new SpreadSheetTrackingClass();

            // Get the latest spead sheet from the web api.
            SpreadSheetClass latestSprSht = GetLatestSpreadSheet(
                ConstantsClass.SPREEDSHEET_API_URL, "Latest Sheet");

            // Get the old stored spread sheet from the last ping or app init.
            SpreadSheetClass oldSsObj = GetLastDownloadedSpreadSheet();

            // Update the stored spread sheet with the latest to prepare for
            // future ping actions.
            UpdateLastDownloadedSpreadSheet(latestSprSht);

            // Init a change discovery object to manipulate and store relevant
            // data to the SpreadSheet Tracking Object.
            ChangeDiscoveryClass cdc = new ChangeDiscoveryClass();

            // Variable to store any errors while obtaining the data.
            int errors = 0;

            try
            {
                stc.NumberOfAdditions = cdc.GetNumRecordsAdded(oldSsObj, latestSprSht);
            }
            catch (Exception)
            {
                errors++;
            }

            try
            {
                stc.NumerOfDeletes = cdc.GetNumRecordsDeleted(oldSsObj, latestSprSht);
            }
            catch (Exception)
            {
                errors++;
            }

            try
            {
                stc.UpdateDetails = cdc.GetUpdatedRecordsInfo(oldSsObj, latestSprSht);
            }
            catch (Exception)
            {
                errors++;
            }

            try
            {
                stc.NumberOfUpdates = stc.UpdateDetails.Count;
            }
            catch (Exception)
            {
                errors++;
            }

            stc.NumberOfErrors = errors;

            return stc;
        }

        /// <summary>
        /// Initailises the stored spead sheet on app start to prepare for the
        /// first ping action in the UI.
        /// </summary>
        /// <returns>void</returns>
        public void InitialiseStoredSpreadSheet()
        {
            // Get the latest spread sheet from the api.
            SpreadSheetClass latestSprSht = GetLatestSpreadSheet(
                 ConstantsClass.SPREEDSHEET_API_URL, "Latest Sheet");

            // Update the stored spread sheet.
            UpdateLastDownloadedSpreadSheet(latestSprSht);
        }

        /// <summary>
        /// Update the saved spead sheet to a json file. Returns a boolean to
        /// indicate success.
        /// </summary>
        /// <param name="spreadSheet">TheSpread Sheet Object.</param>
        /// <returns>bool</returns>
        private bool UpdateLastDownloadedSpreadSheet(
          SpreadSheetClass spreadSheet)
        {
            bool saved;

            try
            {
                SaveLatestSpreadSheetJason(spreadSheet);
                saved = true;
            }
            catch (Exception)
            {
                saved = false;
            }

            return saved;
        }

        /// <summary>
        /// Gets the latest spread sheet data returned from the api and converts
        /// it to a SpreadSheet Object (Deserializes it)
        /// </summary>
        /// <param name="url">The url of the source api.</param>
        /// <param name="name">Choosen spreed sheet name (Not used for now)</param>
        /// <returns>SpreadSheetClass</returns>
        private SpreadSheetClass GetLatestSpreadSheet(string url, string name)
        {
            string jsonStr = GetLatestSpreadSheetJsonString(url);

            // Covert to a Deserialized object.
            SpreadSheetClass ssObj = JsonConvert.DeserializeObject<SpreadSheetClass>(jsonStr);

            return ssObj;
        }

        /// <summary>
        /// Retrives the stored spread sheet from a jason file.
        /// </summary>
        /// <returns>SpreadSheetClass</returns>
        private SpreadSheetClass GetLastDownloadedSpreadSheet()
        {
            string oldJsonStr = ReadLastSpreadSheetJason();
            SpreadSheetClass ssObj = JsonConvert.DeserializeObject<SpreadSheetClass>(oldJsonStr);

            return ssObj;
        }

        /// <summary>
        /// Save the spread sheet to file.
        /// </summary>
        /// <param name="spreadSheet">The spread sheet object to be saved.</param>
        /// <returns>void</returns>
        private async void SaveLatestSpreadSheetJason(
            SpreadSheetClass spreadSheet)
        {
            string jsonStr = JsonConvert.SerializeObject(spreadSheet);
            await File.WriteAllTextAsync(
                ConstantsClass.SAVED_SPREEDSHEET_FILE_NAME, jsonStr);
        }

        /// <summary>
        /// reads the spread sheet jason file as a string.
        /// </summary>
        /// <returns>string</returns>
        private string ReadLastSpreadSheetJason()
        {
           string jsonStr = File.ReadAllText(
                    ConstantsClass.SAVED_SPREEDSHEET_FILE_NAME);

            return jsonStr;
        }

        /// <summary>
        /// Get the latest spread sheet data as a jason string from the api as
        /// a Task
        /// </summary>
        /// <param name="url">The api url.</param>
        /// <returns>string</returns>
        private string GetLatestSpreadSheetJsonString(string url)
        {
            string SSJsonStr = "";

            // The Task is run and waited for as info is need for next step/
            Task.Run(async () => {
                SSJsonStr = await AsyncWebDownloadString(url);
            }).Wait();

            return SSJsonStr;
        }

        /// <summary>
        /// The spread sheet download Task.
        /// </summary>
        /// <param name="url">The api url.</param>
        /// <returns>string</returns>
        private async Task<string> AsyncWebDownloadString(string url)
        {
            string result = null;

            // Network error control boolean
            bool hasResult = false;

            var webClient = new WebClient();

            // Loop runs until error free result has been obtained.
            while (!hasResult)
            {
                try
                {
                    result = await webClient.DownloadStringTaskAsync(new Uri(url));
                    hasResult = true;
                }
                catch (Exception e)
                {
                    result = e.Message;
                    hasResult = false;
                }
            }

            return result;
        }
    }
}
