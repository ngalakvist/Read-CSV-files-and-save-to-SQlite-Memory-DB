using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CompareFiles.DB
{
  internal class TelefonEvent
  {
    [Key]
    public string anvandarid { get; set; }
    public string telefonnummer { get; set; }

    public string mobilnummer { get; set; }


    public string Hash { get; set; }

    public string GetHash()
    {
      var sb = new StringBuilder();
      sb.Append(anvandarid).Append(telefonnummer).Append(mobilnummer);
      var hash = sb.ToString().GetHashCode().ToString();
      SetHash(hash);
      return hash;
    }

    private void SetHash(string value)
    {
      this.Hash = value;
    }

    //public TelefonEvent(string anvandarid, string telefonnummer, string mobilnummer)
    //{
    //  anvandarid = anvandarid;
    //  telefonnummer = telefonnummer;
    //  mobilnummer = mobilnummer;
    //}
  }
}
