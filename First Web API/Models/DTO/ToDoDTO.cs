using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace First_Web_API.Models.DTO
{
    public class ToDoDTO
    {
        public int ID { get; set; }
        public string Value { get; set; }
        public bool Completed { get; set; }
    }
}