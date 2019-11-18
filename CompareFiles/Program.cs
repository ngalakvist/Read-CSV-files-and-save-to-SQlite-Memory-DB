using System;
using System.Collections.Generic;

namespace CompareFiles.DB
{
  partial class Program
  {
    static void Main(string[] args)
    {
      DB.CompareFiles.getFilesCompares(@"C:\\Temp\\csv\\today.csv");
      //CompareFiles.createSqlLiteDB();
      Console.WriteLine("Done");
      Console.ReadKey();
    }

    public string name(List<string> names)
    {
      return "";
    }
  }
}
