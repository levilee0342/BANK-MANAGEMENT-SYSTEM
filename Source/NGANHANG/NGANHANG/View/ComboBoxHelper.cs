using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace NGANHANG.View
{
    public static class ComboBoxHelper
    {
        public static Dictionary<string, string> tenCnTenServerDictionary = new Dictionary<string, string>();
        public static string tenCN_Help = "";
        public static bool checkLogin = false;

        public static void PopulateComboBox(ComboBox comboBox)
        {
            try
            {
                // Define your SQL query to select data from the view
                string query = "SELECT TENCN, TENSERVER FROM [dbo].[V_DS_PHANMANH]";

                // Create a new SqlConnection and SqlCommand objects
                using (SqlConnection connection = new SqlConnection(Program.connstr))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Open the connection
                    connection.Open();

                    // Execute the query and get a SqlDataReader
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear existing items in ComboBox
                    comboBox.Items.Clear();

                    // Clear existing dictionary
                    tenCnTenServerDictionary.Clear();

                    // Loop through the result set and add items to ComboBox
                    while (reader.Read())
                    {
                        // Assuming the view column names are TENCN and TENSERVER
                        string tenCN = reader["TENCN"].ToString();
                        string tenServer = reader["TENSERVER"].ToString();

                        // Check if the key already exists in the dictionary
                        if (!tenCnTenServerDictionary.ContainsKey(tenCN))
                        {
                            // Store TENCN and TENSERVER in dictionary
                            tenCnTenServerDictionary.Add(tenCN, tenServer);

                            // Add TENCN to ComboBox
                            comboBox.Items.Add(tenCN);
                        }
                    }

                    // Close the reader
                    reader.Close();
                    checkLogin = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data: " + ex.Message);
            }
        }
        public static void ImportDataDic(ComboBox comboBox)
        {
            try
            {
                // Clear existing items in ComboBox
                comboBox.Items.Clear();

                // Loop through the dictionary and add items to ComboBox
                foreach (var kvp in tenCnTenServerDictionary)
                {
                    // Add TENCN to ComboBox
                    comboBox.Items.Add(kvp.Key);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importing data to ComboBox: " + ex.Message);
            }
        }
    }
}

