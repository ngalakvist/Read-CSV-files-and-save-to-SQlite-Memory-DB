

using System.Data.Entity;

namespace CompareFiles.DB
{
  internal class CsvDBContext : DbContext
  {
    public DbSet<TelefonEvent> TelefonEvents { get; set; }
  }
}