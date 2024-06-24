using BOMJ.Models;
using System;
using System.Collections.Generic;

namespace BOMJ.Models;

public partial class Otdel
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Boss { get; set; } = null!;

    public int? Sotrud { get; set; }

    public virtual ICollection<Sotrud> Sotruds { get; set; } = new List<Sotrud>();
}
