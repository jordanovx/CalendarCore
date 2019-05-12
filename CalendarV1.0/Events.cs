﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CalendarV1
{
    public class Events
    {
        [Key]
        public int EventID { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public System.DateTime Start { get; set; }
        public Nullable<System.DateTime> End { get; set; }
        public string ThemeColor { get; set; }
        public bool IsFullDay { get; set; }


    }
}
