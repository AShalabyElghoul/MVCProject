﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.DAL.Models
{
    public class Department:ModelBase
    {

        public string? Name { get; set; }
        public string? Code { get; set; }

        [Display(Name="Date Of Creation")]
        public DateOnly DateOfCreation { get; set; }
    }
}
