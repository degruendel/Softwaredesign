using System;
using System.Collections.Generic;

namespace SoftwareDesign
{
    class Classroom
    {
        public string name;
        //public bool availability = true;
        public int seats;
        public string building;
        public List<string> equipment = new List<string>();
        public string[] availability = new string[50];
    }
}