using CRUDEmploye.Models.Entities;
using CRUDEmploye.Utilities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDEmploye.Models.DAL
{
    public class DAL_Impl : IDAL
    {
        public void Add(Employe employe)
        {
            using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
            {
                string strMySQL = "INSERT INTO Employe (Name, Position, Office, Age, Salary) VALUES (@Name, @Position, @Office, @Age, @Salary)";
                MySqlCommand command = new MySqlCommand(strMySQL, mySqlConnection);
                command.Parameters.AddWithValue("@Name", employe.Name);
                command.Parameters.AddWithValue("@Position", employe.Position);
                command.Parameters.AddWithValue("@Office", employe.Office);
                command.Parameters.AddWithValue("@Age", employe.Age);
                command.Parameters.AddWithValue("@Salary", employe.Salary);
                DataBaseAccesUtilities.NonQueryRequest(command);
            }
        }

        public void Delete(int Id)
        {
            using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
            {
                string strMySQL = "DELETE FROM Employe WHERE EmployeID=@Id";
                MySqlCommand command = new MySqlCommand(strMySQL, mySqlConnection);
                command.Parameters.AddWithValue("@Id", Id);
                DataBaseAccesUtilities.NonQueryRequest(command);
            }
        }

        public Employe GetEntityFromDataRow(DataRow dataRow)
        {
            Employe employe = new Employe();

            employe.EmployeID = (int)dataRow["EmployeID"];
            employe.Name = (string)dataRow["Name"];
            employe.Position = (string)dataRow["Position"];
            employe.Office = (string)dataRow["Office"];
            employe.Salary = (int)dataRow["Salary"];
            employe.Age = (int)dataRow["Age"];

            return employe;
        }

        public List<Employe> GetListFromDataTable(DataTable dataTable)
        {
            List<Employe> employes = new List<Employe>();

            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    employes.Add(GetEntityFromDataRow(row));
                }
            }

            return employes;
        }

        public List<Employe> SelectAll()
        {
            DataTable table;
            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                connection.Open();
                string strMysql = "SELECT * FROM Employe";
                MySqlCommand command = new MySqlCommand(strMysql, connection);
                table = DataBaseAccesUtilities.SelectRequest(command);
            }

            return GetListFromDataTable(table);
        }

        public Employe SelectById(int Id)
        {
            using (MySqlConnection connection = DbConnection.GetConnection())
            {
                connection.Open();
                string strMysql = "SELECT * FROM Employe WHERE EmployeID=@Id";
                MySqlCommand command = new MySqlCommand(strMysql, connection);
                command.Parameters.AddWithValue("@Id", Id);

                DataTable table = DataBaseAccesUtilities.SelectRequest(command);

                if (table != null)
                {
                    return GetEntityFromDataRow(table.Rows[0]);
                }
                else
                {
                    return null;
                }
            }
        }

        public void Update(int Id, Employe employe)
        {
            using (MySqlConnection mySqlConnection = DbConnection.GetConnection())
            {
                string strMySQL = "UPDATE Employe SET Name=@Name, Position=@Position, Office=@Office, Age=@Age, Salary=@Salary WHERE EmployeID=@Id";
                MySqlCommand command = new MySqlCommand(strMySQL, mySqlConnection);
                command.Parameters.AddWithValue("@Name", employe.Name);
                command.Parameters.AddWithValue("@Position", employe.Position);
                command.Parameters.AddWithValue("@Office", employe.Office);
                command.Parameters.AddWithValue("@Age", employe.Age);
                command.Parameters.AddWithValue("@Salary", employe.Salary);
                command.Parameters.AddWithValue("@Id", Id);
                DataBaseAccesUtilities.NonQueryRequest(command);
            }
        }
    }
}
