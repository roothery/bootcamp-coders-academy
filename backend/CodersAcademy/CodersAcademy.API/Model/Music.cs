﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CodersAcademy.API.Model
{
    public class Music
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public int Duration { get; set; }

        [JsonIgnore]
        public Album Album { get; set; }
    }
}
