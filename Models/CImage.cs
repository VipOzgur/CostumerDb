using System;
using System.Collections.Generic;

namespace yeni.Models;

public partial class CImage
{
    public long Id { get; set; }

    public long MusteriId { get; set; }

    public string ImagePath { get; set; }
}
