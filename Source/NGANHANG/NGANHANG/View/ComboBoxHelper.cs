using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

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
                string query = "SELECT TENCN, TENSERVER FROM LINK0.NGANHANG.[dbo].[V_DS_PHANMANH] WHERE TENCN <> N'TRA CỨU'";

                using (SqlConnection connection = new SqlConnection(Program.connstr))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    comboBox.Items.Clear();
                    tenCnTenServerDictionary.Clear();

                    while (reader.Read())
                    {
                        string tenCN = reader["TENCN"].ToString();
                        string tenServer = reader["TENSERVER"].ToString();

                        if (!tenCnTenServerDictionary.ContainsKey(tenCN))
                        {
                            tenCnTenServerDictionary.Add(tenCN, tenServer);
                            comboBox.Items.Add(tenCN);
                        }
                    }
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
                comboBox.Items.Clear();
                foreach (var kvp in tenCnTenServerDictionary)
                {
                    comboBox.Items.Add(kvp.Key);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importing data to ComboBox: " + ex.Message);
            }
        }

        public static string timMaCN(string input)
        {
            string upperCaseString = input.ToUpper();
            string noDiacriticsString = RemoveDiacritics(upperCaseString);
            string noSpacesString = noDiacriticsString.Replace(" ", "");

            return noSpacesString;
        }

        public static string RemoveDiacritics(string input)
        {
            string normalizedString = input.Normalize(NormalizationForm.FormD);
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string noDiacriticsString = regex.Replace(normalizedString, string.Empty)
                                             .Replace('\u0111', 'd')  
                                             .Replace('\u0110', 'D');  
            return noDiacriticsString;
        }

    }
}


