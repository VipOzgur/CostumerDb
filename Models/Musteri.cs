using System;
using System.Collections.Generic;

namespace MusteriData.Models;

public partial class Musteri
{
    public long Id { get; set; }

    public string AdSoyad { get; set; } = null!;

    public string? UploadDate { get; set; }
}
