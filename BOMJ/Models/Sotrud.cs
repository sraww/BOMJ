using System;
using System.Collections.Generic;

namespace BOMJ.Models;

public partial class Sotrud
{
    public int Id { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Money { get; set; }

    public int Staj { get; set; }

    public int Idotdel { get; set; }

    public virtual Otdel IdotdelNavigation { get; set; } = null!;
}
