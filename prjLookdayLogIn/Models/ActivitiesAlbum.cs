﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace prjLookdayLogIn.Models;

public partial class ActivitiesAlbum
{
    public int PhotoId { get; set; }

    public byte[] Photo { get; set; }

    public int ActivityId { get; set; }

    public virtual Activity Activity { get; set; }
}