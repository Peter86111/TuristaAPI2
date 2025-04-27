using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TuristaAPI2.Models;

public partial class Utvonal
{
    public int Id { get; set; }

    public string Allomasok { get; set; } = null!;

    public int Tav { get; set; }

    public int Szint { get; set; }

    public int NehezsegId { get; set; }

    public virtual Nehezseg Nehezseg { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Tura>? Turas { get; set; } = new List<Tura>();
}
