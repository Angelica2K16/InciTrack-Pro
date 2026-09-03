using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GV = InciTrack_Pro.Base_Classes.GlobalVariables;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace InciTrack_Pro.Helper_Classes
{
    internal class HazardRetrieval
    {
        public static string GetHazards()
        {
            try
            {
                string result = "";

                using (var sqlConn = new SqliteConnection(GV.shesDB))
                {
                    sqlConn.Open();

                    string tableName = "Hazards";

                    //selecting the max mxID from the Shes db
                    var command = sqlConn.CreateCommand();
                    command.CommandText = $"Select MAX (XL_ID) From {tableName}";
                    var maxValue = command.ExecuteScalar();
                    if (maxValue == DBNull.Value)
                    {
                        maxValue = 0;

                    }

                    string fileName = EpplusWork(Convert.ToInt32(maxValue)).excelFileName;
                    int resultFound = EpplusWork(Convert.ToInt32(maxValue)).newHazardsFound;

                    if (resultFound > 0)
                    {
                        result = $"Hazard Retrieval: \nFile name: {fileName} \n\nMessage: \nContained total of {resultFound} new hazard records and they were added to the database.";
                    }
                    else
                    {
                        result = $"Hazard Retrieval: \nFile name: {fileName} \n\nMessage: \nDoes not contain any new hazards to add to the database.";
                    }

                }

                return result;
            }
            catch(Exception ex)
            {
                return $"An error occurred while importing hazards:\n{ex.Message}";
            }
        }

        private static (int newHazardsFound, string excelFileName )EpplusWork(int maxValue)
        {
            int newHazardsFound = 0;
            //string returnMessage = "";

            ExcelPackage.License.SetNonCommercialPersonal("<Dan-Mar Company - Internal Use>");

            string userName = Environment.UserName;
            string filePath = string.Empty;
            if (userName.Contains("Vince"))
            {
                filePath = @"C:\Users\VinceJ\OneDrive - Austin Powder\Zoho Excel Outputs\HazardReportSubmissions.xlsx";
            }
            else if (userName.Contains("Angel"))
            {
                //filePath = @"C:\Users\AngelC\OneDrive - Austin Powder Holdings Company\Vincent Jackson's files - Zoho Excel Outputs\HazardReportSubmissions.xlsx";
                filePath = @"C:\Users\angelc\OneDrive - Austin Powder\Vincent Jackson's files - Zoho Excel Outputs\HazardReportSubmissions.xlsx";
            }

            FileInfo excelFile = new FileInfo(filePath);

            //string conn = shesDb;

            //Console.WriteLine("Performing Excel to SQLite operation...");

            using (ExcelPackage pkg = new ExcelPackage(excelFile))
            {
                ExcelWorkbook wb = pkg.Workbook;
                ExcelWorksheet ws = wb.Worksheets[0];

                // Initialize start row to 2 - where we will start if there is no MaxID in the database
                int startRow = 2;

                // Start by getting the last row
                int lastRow = ws.Dimension.End.Row;

                if (maxValue != 0)
                {

                    // Find the maxId row
                    for (int row = startRow; row <= lastRow; row++)
                    {
                       
                        int currentId = Convert.ToInt32(ws.Cells[row, 3].Value);
                        if (currentId == maxValue)
                        {
                            // Check to make sure we have new data to add.
                            if (row == lastRow)
                            {

                               //Console.WriteLine($"The excel file '{excelFile.FullName}' does not contain any new data to add to the database.");
                                //Console.ReadLine();
                                return (newHazardsFound, excelFile.FullName);
                            }
                            startRow = row + 1;
                            break;
                        }
                    }
                }

                // Now we can add the new data from the report

                newHazardsFound = WriteToHazardSQL(ws, startRow, lastRow);
                return (newHazardsFound, excelFile.FullName);
                //Console.WriteLine($"Update complete. A total of {newHazardRecords} records were added to SQLite.");
                //Console.ReadLine();
            }

        }

        private static int WriteToHazardSQL(ExcelWorksheet ws, int startRow, int lastRow)
        {
            int recordCount = 0;

            // Open Database
            //string dbFile = @"G:\Public\Production Software\Released Applications\SHES\SQL DB\SHES_DataBoard.db";
            //using (SqliteConnection conn = new SqliteConnection($"DataSource={dbFile}"))
            using (SqliteConnection conn = new SqliteConnection(GV.shesDB))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    int currentRow = 0;

                    try
                    {
                        // Loop through the rest of the excel document to get the values to write to SQL
                        string query = string.Empty;
                        for (int row = startRow; row <= lastRow; row++)
                        {
                            currentRow = row;

                            //set all variables
                            int xl_id = Convert.ToInt32(ws.Cells[row, 3].Text);
                            string timestamp = ws.Cells[row, 5].Text;

                            // Have to reformat the date
                            string date = Convert.ToDateTime(timestamp).ToString("yyyy-MM-dd");
                            string reportedBy = ws.Cells[row, 4].Text;
                            reportedBy = reportedBy.Replace(", ", " ");



                            string area = ws.Cells[row, 6].Text;

                            // Have to convert split string in MS Forms to match database (", ")
                            string injuryCategories = ws.Cells[row, 7].Text;


                            string environmentCategories = ws.Cells[row, 8].Text;

                            string damageCategories = ws.Cells[row, 9].Text;

                            string incidentDescription = ws.Cells[row, 10].Text;

                            // Write to SQL
                            var command = conn.CreateCommand();
                            command.CommandText = $@"INSERT INTO Hazards (    
                                                Date,
                                                Reported_By,
                                                Area,
                                                Injury_Category,
                                                Environment_Category,
                                                Damage_Category,
                                                Incident_Description,
                                                Status,
                                                XL_ID
                                             ) VALUES (    
                                                @Date,
                                                @Reported_By,
                                                @Area,
                                                @Injury_Category,
                                                @Environment_Category,
                                                @Damage_Category,
                                                @Incident_Description,
                                                @Status,
                                                @XL_ID
                                             )";

                            command.Parameters.AddWithValue("@Date", date);
                            command.Parameters.AddWithValue("@Reported_By", reportedBy);
                            command.Parameters.AddWithValue("@Area", area);
                            command.Parameters.AddWithValue("@Injury_Category", injuryCategories);
                            command.Parameters.AddWithValue("@Environment_Category", environmentCategories);
                            command.Parameters.AddWithValue("@Damage_Category", damageCategories);
                            command.Parameters.AddWithValue("@Incident_Description", incidentDescription);
                            command.Parameters.AddWithValue("@Status", "Open");
                            command.Parameters.AddWithValue("@XL_ID", xl_id);
                            command.ExecuteNonQuery();

                            recordCount++;


                        }

                        transaction.Commit();
                        return recordCount;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Import failed on Excel row {currentRow}. No records were added. Error: {ex.Message}",ex);
                    }
                }
                    

            }
            
        }
    }
}
