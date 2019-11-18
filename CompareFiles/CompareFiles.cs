using CsvHelper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.SQLite;
using System.IO;
using System.Linq;

namespace CompareFiles.DB
{
  public class CompareFiles
  {
    public static void getFilesCompares(string file1)
    {

      var list = new List<TelefonEvent>();
      var dict = new Dictionary<string, string>();
      using (var reader = new StreamReader(file1))
      using (var csv = new CsvReader(reader))
      {
        csv.Configuration.Delimiter = ",";
        csv.Configuration.HasHeaderRecord = false;
        csv.Configuration.MissingFieldFound = null;
        list = csv.GetRecords<TelefonEvent>().ToList();
      }

      foreach (var p in list)
      {
        p.GetHash();
      }

      using (var writer = new StreamWriter(@"C:\\Temp\\csv\\mine.csv"))
      using (var csv = new CsvWriter(writer))
      {
        csv.WriteRecords(list);
      }
      using (var db = new CsvDBContext())
      {
        try
        {
          foreach (var p in list)
          {
            db.TelefonEvents.Add(p);
            db.SaveChanges();
          }
        }
        catch (DbEntityValidationException e)
        {
          foreach (var eve in e.EntityValidationErrors)
          {
            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
              eve.Entry.Entity.GetType().Name, eve.Entry.State);
            foreach (var ve in eve.ValidationErrors)
            {
              Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                ve.PropertyName, ve.ErrorMessage);
            }
          }
          throw;
        }
      }
    }

    public static void createSqlLiteDB()

    {
      SQLiteCommand sqlite_cmd;
      //create a new database connection:
      SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=Telefon.sqlite;Version=3;");
      SQLiteDataReader sqlite_datareader;  // Data Reader Object

      // open the connection:
      sqlite_conn.Open();

      // create a new SQL command:
      sqlite_cmd = sqlite_conn.CreateCommand();

      // Let the SQLiteCommand object know our SQL-Query:
      // sqlite_cmd.CommandText = "CREATE TABLE test (id integer primary key, text varchar(100));";

      // Now lets execute the SQL ;D
      sqlite_cmd.ExecuteNonQuery();

      // Lets insert something into our new table:
      sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (, 'Test Text 1');";

      // And execute this again ;D
      sqlite_cmd.ExecuteNonQuery();

      // ...and inserting another line:
      sqlite_cmd.CommandText = "INSERT INTO test (id, text) VALUES (2, 'Test Text 2');";

      // And execute this again ;D
      sqlite_cmd.ExecuteNonQuery();

    }


  }
}
