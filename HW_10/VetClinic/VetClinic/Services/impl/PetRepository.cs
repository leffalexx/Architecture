using Microsoft.Data.Sqlite;
using VetClinic.Models;

namespace VetClinic.Services.impl
{
    public class PetRepository : IPetRepository
    {
        private const string connectionString = "data source = clinic.db;";

        public int Create(Pet item)
        {
            using SqliteConnection connection = new SqliteConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            using SqliteCommand command = new SqliteCommand("INSERT INTO Pets(ClientID, Name, Birthday) VALUES(@ClientID, @Name, @Birthday)", connection);
            command.Parameters.AddWithValue("@ClientID", item.ClientId);
            command.Parameters.AddWithValue("@Name", item.Name);
            command.Parameters.AddWithValue("@Birthday", item.Birthday);
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public int Delete(int id)
        {
            using SqliteConnection connection = new SqliteConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            using SqliteCommand command = new SqliteCommand("DELETE FROM pets WHERE PetID=@PetID", connection);
            command.Parameters.AddWithValue("@PetID", id);
            command.Prepare();
            return command.ExecuteNonQuery();
        }

        public IList<Pet> GetAll()
        {
            List<Pet> list = new List<Pet>();
            using SqliteConnection connection = new SqliteConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            using SqliteCommand command =
                new SqliteCommand("SELECT * FROM pets", connection);
            command.Prepare();
            using SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Pet pet = new Pet();
                pet.PetId = reader.GetInt32(0);
                pet.Name = reader.GetString(1);
                pet.Birthday = new DateTime(reader.GetInt64(2));
                list.Add(pet);
            }
            return list;
        }

        public Pet GetById(int id)
        {
            using SqliteConnection connection = new SqliteConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            using SqliteCommand command = new SqliteCommand("SELECT * FROM pets WHERE PetID=@PetID", connection);
            command.Parameters.AddWithValue("@PetID", id);
            command.Prepare();
            SqliteDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                Pet pet = new Pet();
                pet.PetId = reader.GetInt32(0);
                pet.Name = reader.GetString(1);
                pet.Birthday = new DateTime(reader.GetInt64(2));
                return pet;
            }
            return null;
        }

        public int Update(Pet item)
        {
            {
                using SqliteConnection connection = new SqliteConnection();
                connection.ConnectionString = connectionString;
                connection.Open();
                using SqliteCommand command = new SqliteCommand("UPDATE pets SET ClientID = @ClientID, Name = @Name, Birthday = @Birthday WHERE PetID=@PetID", connection);
                command.Parameters.AddWithValue("@PetID", item.PetId);
                command.Parameters.AddWithValue("@Name", item.Name);
                command.Parameters.AddWithValue("@Birthday", item.Birthday.Ticks);
                command.Prepare();
                return command.ExecuteNonQuery();
            }
        }
    }
}
