using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AboutThatSize.Models
{
    public partial class ConversionHistory
    {
        [Key]
        public int Id { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public float? FromValue { get; set; }
        public float? ToValue { get; set; }
    }
}
