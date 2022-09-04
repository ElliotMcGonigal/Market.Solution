using System.Collections.Generic;

namespace Market.Models
{
  public class Sweet
  {
    public Sweet()
    {
      this.JoinEntities = new HashSet<FlavorSweet>();
    }

    public int SweetId { get; set; }
    public string Description { get; set; }
    public virtual ApplicationUser User { get; set; }

    public virtual ICollection<FlavorSweet> JoinEntities { get;}
  }
}