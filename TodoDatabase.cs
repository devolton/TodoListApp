using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace TodoList
{
    public class TodoDatabase
    {
        private static readonly string _databaseName = "TodoDatabase.db";
        private static readonly SqliteConnection _connection;
        private static readonly SqliteCommand _command;


        static TodoDatabase()
        {
            _connection = new SqliteConnection("Data source = " + _databaseName);
            _command = _connection.CreateCommand();

            _connection.Open();

            CreateTable();
        }

        public static void CreateTable()
        {
            _command.CommandText =
                @"
                CREATE TABLE IF NOT EXISTS TodoDatabase(
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    descriptions TEXT NOT NULL,
                    status BOOLEAN,
                    deadlineDate TEXT
                );
            ";
            _command.ExecuteNonQuery();
        }

        public static void AddTask(TaskTest task)
        {
            _command.CommandText =
                "INSERT INTO TodoDatabase(descriptions, status, deadlineDate) " +
                $"VALUES('{task.Description}', {task.IsCompleted}, '{task.DeadliteDate}' )";

            _command.ExecuteNonQuery();
        }

        public static void UpdateTask(TaskTest task)
        {
            _command.CommandText =
                @"
                UPDATE TodoDatabase 
                SET
                    descriptions = $descriptions,
                    status = $status,
                    deadlineDate = $deadlineDate
                WHERE id = $id
            ";
            _command.Parameters.AddWithValue("$id", task.Id);
            _command.Parameters.AddWithValue("$descriptions", task.Description);
            _command.Parameters.AddWithValue("$status", task.IsCompleted);
            _command.Parameters.AddWithValue("$deadlineDate", task.DeadliteDate);

            _command.ExecuteNonQuery();
        }

        public static IEnumerable<TaskTest> GetAllTask()
        {
            _command.CommandText = $"SELECT * FROM TodoDatabase";
            using var reader = _command.ExecuteReader();
            while (reader.Read())
            {
                yield return new TaskTest()
                {
                    Id = reader.GetInt32(0),
                    Description = reader.GetString(1),
                    IsCompleted = reader.GetBoolean(2),
                    DeadliteDate = reader.GetDateTime(3),
                   
                };
            }
            reader.Close();

        }

        public static void RemoveTaskById(int id)
        {
            _command.CommandText = $"DELETE FROM TodoDatabase WHERE id={id}";
            _command.ExecuteReader();
        }
    }

}

