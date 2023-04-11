using System;
using System.Collections.Generic;

namespace Mummies.Models;

public partial class Analysis
{
    public long Id { get; set; }

    public int? Analysistype { get; set; }

    public string? Doneby { get; set; }

    public int? Analysisid { get; set; }

    public DateTime? Date { get; set; }
}
