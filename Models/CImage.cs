using System;
using System.Collections.Generic;

namespace MusteriData.Models;

public partial class CImage
{
    public long Id { get; set; }

    public long MusteriId { get; set; }

    public string ImagePath { get; set; }
}
