﻿using System;

namespace Birthdays.Models {
    public class Person {
        public Person(string name, DateTime date, int id) {
            Name = name;
            Birthday = date.ToShortDateString();
            Age = GetAge(date);
            Id = id;
        }

        public string Name { get; }
        public string Birthday { get; }
        public uint Age { get; }
        public int Id { get; }

        static uint GetAge(DateTime birthDate) {
            var now = DateTime.Now;
            int age = now.Year - birthDate.Year;
            if (now.Month < birthDate.Month || (now.Month == birthDate.Month && now.Day < birthDate.Day)) {
                age--;
            }

            return (uint)age;
        }
    }
}
