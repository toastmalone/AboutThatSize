﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AboutThatSize.Models
{
    public class Unit
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public float Length { get; set; }

        public float Mass { get; set; }

        public string Category { get; set; }
    }
}
