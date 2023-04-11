using System;
using System.Collections.Generic;

namespace Mummies.Models;

public partial class C14
{
    public long Id { get; set; }

    public string? Description { get; set; }

    public string? Category { get; set; }

    public int? Size { get; set; }

    public int? Agebp { get; set; }

    public int? Calibratedspan { get; set; }

    public int? Tubenumber { get; set; }

    public int? Calibrateddatemin { get; set; }

    public int? Calibrateddateavg { get; set; }

    public string? Foci { get; set; }

    public int? Rack { get; set; }

    public int? Calendardate { get; set; }

    public int? Calibrateddatemax { get; set; }

    public string? C14lab { get; set; }

    public string? Questions { get; set; }

    public string? Location { get; set; }
}
