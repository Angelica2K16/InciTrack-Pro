using Microsoft.Data.Sqlite;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SkiaSharp.HarfBuzz.SKShaper;
using GV = InciTrack_Pro.Base_Classes.GlobalVariables;

namespace InciTrack_Pro.Helper_Classes
{
    internal class FirstAidRetrieval
    {
        

        public static string GetFirstAids()
        {
            try
            {
                string result = "";

                using (var sqlConn = new SqliteConnection(GV.shesDB))
                {
                    sqlConn.Open();

                    string tableName = "First_Aids";

                    //selecting the max mxID from the Shes db
                    var command = sqlConn.CreateCommand();
                    command.CommandText = $"Select MAX (XL_ID) From {tableName}";
                    var maxValue = command.ExecuteScalar();
                    if (maxValue == DBNull.Value)
                    {
                        maxValue = 0;

                    }

                    //EpplusWork(Convert.ToInt32(maxValue));

                    string fileName = EpplusWork(Convert.ToInt32(maxValue)).excelFileName;
                    int resultFound = EpplusWork(Convert.ToInt32(maxValue)).newFAsFound;


                    if (resultFound > 0)
                    {
                        result = $"First-Aid Retrieval: \nFile name: {fileName} \n\nMessage: \nContained total of {resultFound} new first-aid records and they were added to the database.";
                    }
                    else
                    {
                        result = $"First-Aid Retrieval: \nFile name: {fileName} \n\nMessage: \nDoes not contain any new first-aid records to add to the database.";
                    }
                }

                return result;
            }
            catch(Exception ex)
            {
                return $"An error occurred while importing firstAids :\n{ex.Message}";
            }
        }

        private static (int newFAsFound, string excelFileName) EpplusWork(int maxValue)
        {
            int newHazardsFound = 0;
           // string returnMessage = "";

            ExcelPackage.License.SetNonCommercialPersonal("<Dan-Mar Company - Internal Use>");

            string userName = Environment.UserName;
            string filePath = string.Empty;
            if (userName.Contains("Vince"))
            {
                filePath = @"C:\Users\VinceJ\OneDrive - Austin Powder\Angel Lively's files - First-Aid\Zoho Data Output First-Aid.xlsx";
            }
            else if (userName.Contains("Angel"))
            {
                //filePath = @"C:\Users\AngelC\OneDrive - Austin Powder Holdings Company\Zoho Data Outputs\First-Aid\Zoho Data Output First-Aid.xlsx";
                filePath = @"C:\Users\angelc\OneDrive - Austin Powder\Zoho Data Outputs\First-Aid\Zoho Data Output First-Aid.xlsx";
            }

            FileInfo excelFile = new FileInfo(filePath);

            //string conn = shesDb;

            Console.WriteLine("Performing Excel to SQLite operation...");

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
                //int newFaRecords = WriteToFaSQL(ws, startRow, lastRow);
                //Console.WriteLine($"Update complete. A total of {newFaRecords} records were added to SQLite.");
                //Console.ReadLine();
                newHazardsFound = WriteToFaSQL(ws, startRow, lastRow);
                return (newHazardsFound, excelFile.FullName);
            }

        }

        private static int WriteToFaSQL(ExcelWorksheet ws, int startRow, int lastRow)
        {
            int recordCount = 0;

            // Open Database
           // string dbFile = @"G:\Public\Production Software\Released Applications\SHES\SQL DB\SHES_DataBoard.db";
            //using (SqliteConnection conn = new SqliteConnection($"DataSource={dbFile}"))
            using (SqliteConnection conn = new SqliteConnection(GV.shesDB))
            {
                conn.Open();

                using (var transaction = conn.BeginTransaction())
                {
                    int currentRow = 0;

                    // Loop through the rest of the excel document to get the values to write to SQL
                    try
                    {
                        string query = string.Empty;

                        for (int row = startRow; row <= lastRow; row++)
                        {
                            currentRow = row;

                            int xl_id = Convert.ToInt32(ws.Cells[row, 3].Text);
                            string timestamp = ws.Cells[row, 5].Text;
                            // Have to reformat the date
                            string date = Convert.ToDateTime(timestamp).ToString("yyyy-MM-dd");
                            string time = ws.Cells[row, 6].Text;
                            string reformatTime = Convert.ToDateTime(time).ToString("hh:mm tt");
                            string reportedBy = ws.Cells[row, 4].Text.Replace(", ", " ");
                            string area = ws.Cells[row, 8].Text;
                            string injuryLocation = ws.Cells[row, 9].Text;
                            string injuryDescr = ws.Cells[row, 7].Text + ": " + injuryLocation;
                            string injuryCause = ws.Cells[row, 10].Text;

                            // Write to SQL
                            var command = conn.CreateCommand();
                            command.CommandText = $@"INSERT INTO FIRST_AIDS (
                                                Date,
                                                Time,
                                                Employee_Name,
                                                Area,
                                                Incident_Description,
                                                Cause,
                                                XL_ID
                                            ) VALUES (
                                                @Date,
                                                @Time,
                                                @Employee_Name,
                                                @Area,
                                                @Incident_Description,
                                                @Cause,
                                                @XL_ID
                                            )";

                            command.Parameters.AddWithValue("@Date", date);
                            command.Parameters.AddWithValue("@Time", reformatTime);
                            command.Parameters.AddWithValue("@Employee_Name", reportedBy);
                            command.Parameters.AddWithValue("@Area", area);
                            command.Parameters.AddWithValue("@Incident_Description", injuryDescr);
                            command.Parameters.AddWithValue("@Cause", injuryCause);
                            command.Parameters.AddWithValue("@XL_ID", xl_id);
                            command.ExecuteNonQuery();

                            recordCount++;
                        }
                        transaction.Commit();
                        return recordCount;
                    }
                    catch(Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Import failed on Excel row {currentRow}. No records were added. Error: {ex.Message}",ex);
                    }
                }
            }
        }
    }
}
