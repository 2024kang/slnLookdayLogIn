﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace prjLookdayLogIn.Models;

public partial class ActionJoint
{
    public int ActionJointId { get; set; }

    public int UserId { get; set; }

    public int ActivityId { get; set; }

    public int ActionTypeId { get; set; }

    public virtual ActionType ActionType { get; set; }

    public virtual Activity Activity { get; set; }

    public virtual User User { get; set; }
}