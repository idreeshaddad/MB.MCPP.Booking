﻿using MB.MCPP.BK.Utils.Enums;
using System;
namespace MB.MCPP.BK.Dtos.Customers
{
    public class CustomerDto
    { 
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
    }
}