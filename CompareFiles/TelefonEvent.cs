using System.ComponentModel.DataAnnotations;

namespace CompareFiles.DB
{
  internal class TelefonEvent
  {
    [Key]
    public string anvandarid { get; set; }
    public string telefonnummer { get; set; }

    public string mobilnummer { get; set; }

   private int Hash { get; set; }

    //public TelefonEvent(string anvandarid, string telefonnummer, string mobilnummer)
    //{
    //  anvandarid = anvandarid;
    //  telefonnummer = telefonnummer;
    //  mobilnummer = mobilnummer;
    //}
  }
}
