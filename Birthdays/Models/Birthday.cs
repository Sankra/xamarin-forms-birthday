﻿using System;
using Xamarin.Forms.Internals;

namespace Birthdays.Models {
    [Preserve(AllMembers = true)]
    public class Birthday {
        public Birthday(string name, DateTime birthdate) {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; }
        public DateTime Birthdate { get; }
    }
}
