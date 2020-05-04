using AboutThatSize.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AboutThatSize.Models
{
    public partial class Item
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public float? Length { get; set; }
        public float? Mass { get; set; }
        public string Category { get; set; }

        public float? GetMass(UnitOfMass unit)
        {
            return unit switch
            {
                UnitOfMass.kg => Mass / 1000,
                UnitOfMass.g => Mass,
                UnitOfMass.lbs => Mass * (float)(1 / 453.592),
                UnitOfMass.ton => (Mass * (float)(1 / 453.592) * (float)(1 / 2000)),
                _ => Mass
            };
        }

        public float? GetLength(UnitOfLength unit)
        {
            return unit switch
            {
                UnitOfLength.cm => Length,
                UnitOfLength.m => Length / 1000,
                UnitOfLength.inch => Length * (float)(1/2.54),
                UnitOfLength.ft => (Length * (float)(1/2.54) * (float)(1/12)),
                UnitOfLength.km => (Length / 1000) * (float)(1/1000),
                UnitOfLength.mi => (Length * (float)(1 / 2.54) * (float)(1 / 12) * (float)(1/5280)),
                _ => Length,
            };
        }
    }
}
