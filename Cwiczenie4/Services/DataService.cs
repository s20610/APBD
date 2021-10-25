using System.Collections.Generic;
using System.Data.SqlClient;
using Cwiczenie4.Models;
using Cwiczenie4.Services.Exceptions;

namespace Cwiczenie4.Services
{
    public class DataService : IDataService
    {
        private readonly string connectionString = @"Data Source=db-mssql;Initial Catalog=s20610;Integrated Security=True";

        private bool IsExecuted(int rows)
        {
            if (rows >= 1)
                return true;
            return false;
        }

        public void CreateAnimal(Animal animal)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = $"INSERT INTO Animal(Name, Description, Category, Area) VALUES(@name, @description, @category, @area)";
                    command.Parameters.AddWithValue("name", animal.Name);
                    command.Parameters.AddWithValue("description", animal.Description);
                    command.Parameters.AddWithValue("category", animal.Category);
                    command.Parameters.AddWithValue("area", animal.Area);
                    connection.Open();
                    int rowsInserted = command.ExecuteNonQuery();
                    if (!IsExecuted(rowsInserted)) throw new NoExecutedQueryException();
                    connection.Close();
                }
            }
        }

        public void ChangeAnimal(int idAnimal, Animal animal)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "UPDATE Animal SET Name = @name, Description = @description, Category = @category, Area = @area WHERE idAnimal = @idAnimal";
                    command.Parameters.AddWithValue("name", animal.Name);
                    command.Parameters.AddWithValue("description", animal.Description);
                    command.Parameters.AddWithValue("category", animal.Category);
                    command.Parameters.AddWithValue("area", animal.Area);
                    command.Parameters.AddWithValue("idAnimal", idAnimal);
                    connection.Open();
                    int rowsChanged = command.ExecuteNonQuery();
                    if (!IsExecuted(rowsChanged)) throw new NoExecutedQueryException();
                    connection.Close();
                }
            }
        }

        public void DeleteAnimal(int idAnimal)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM Animal WHERE idAnimal = @idAnimal";
                    command.Parameters.AddWithValue("idAnimal", idAnimal);
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (!IsExecuted(rowsAffected)) throw new NoExecutedQueryException();
                    connection.Close();
                }
            }
        }

        public List<Animal> GetAnimals(string orderBy)
        {
            var animals = new List<Animal>();
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    string[] columnsNames = { "name", "description", "category", "area" };
                    bool isMatched = false;

                    if (!string.IsNullOrEmpty(orderBy))
                    {
                        foreach (var columnName in columnsNames)
                            if (orderBy.ToLower().Equals(columnName))
                                isMatched = true;

                        if (isMatched)
                            command.CommandText = $"SELECT * FROM Animal ORDER BY {orderBy} ASC";
                        else throw new NotMatchedColumnNameException();
                    }    
                    else command.CommandText = "SELECT * FROM Animal ORDER BY Name ASC";
                    
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (!reader.HasRows)
                        throw new DataNoRowsException();

                    while (reader.Read())
                        animals.Add(new Animal
                        {
                            IdAnimal = int.Parse(reader["IdAnimal"].ToString()),
                            Name = reader["Name"].ToString(),
                            Description = reader["Description"].ToString(),
                            Category = reader["Category"].ToString(),
                            Area = reader["Area"].ToString()
                        });
                    connection.Close();
                }
            }
            return animals;
        }
    }
}