using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TuristaAPI2.Models;

public partial class Nehezseg
{
    public int Id { get; set; }

    public string Jelzes { get; set; } = null!;

    public string Leiras { get; set; } = null!;

    [JsonIgnore]
    public virtual ICollection<Utvonal>? Utvonals { get; set; } = new List<Utvonal>();
}
