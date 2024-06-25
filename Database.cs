using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;
using System.Text;
using System.Threading.Tasks;


namespace MedicalGasPlantAutomation.Class
{
   
    class Database    
    {  
        public static int plantCount,kayitsayisi;

         static string path = @"Provider=Microsoft.ACE.OleDb.12.0;Data Source = " + Application.StartupPath + "/DatabaseMGPA.accdb";
        public static DataTable GetDataTable()
        {
            DataTable tablo = new DataTable();
            try
            {
                OleDbConnection connection = new OleDbConnection(path);

                connection.Open();
                OleDbCommand command1 = new OleDbCommand("Select * from veritabani", connection);
                OleDbCommand command2 = new OleDbCommand("Select count(*) from veritabani", connection);
                OleDbDataAdapter register1 = new OleDbDataAdapter(command1);
                OleDbDataAdapter register2 = new OleDbDataAdapter(command2);
                register1.Fill(tablo);
                kayitsayisi = (int)command2.ExecuteScalar();
                plantCount = kayitsayisi; 
                connection.Close();
            }  



            catch (OleDbException ex)
            {
                MessageBox.Show(" " + ex);
            }

            return tablo;
        }
       


    }
    
}
