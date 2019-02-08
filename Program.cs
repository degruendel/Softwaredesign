﻿using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;

namespace SoftwareDesign
{
    class Program
    {
        public static List<Semester> Semesters = new List<Semester>();
        public static List<Lecturer> Lecturers = new List<Lecturer>();
        public static List<Classroom> Classrooms = new List<Classroom>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            readData();
            createTimetable();
            //Console.WriteLine(semester.name);

            /* int c = Students.Count;
            int d = Lecturers.Count;
            int e = Classrooms.Count;
            foreach (Student i in Students)
            {
                Console.WriteLine(i.name + " " + i.semester);
            }
            Console.WriteLine("Es sind " + c + " Studenten registriert.");
            foreach (Lecturer i in Lecturers)
            {
                Console.WriteLine(i.name);
                foreach (Subject j in i.subjects)
                {
                    Console.WriteLine(j.name);
                }
                foreach (string k in i.presence)
                {
                    Console.WriteLine(k);
                }
            }
            Console.WriteLine("Es sind " + d + " Dozenten registriert.");
            foreach (Classroom i in Classrooms)
            {
                Console.WriteLine(i.name + " " + i.building);
                foreach (Equipment j in i.equipment)
                {
                    Console.WriteLine(j.name);
                }
            }
            Console.WriteLine("Es sind " + e + " Räume registriert."); */
            //Lecturer L = new Lecturer();
            //L.info("Müller");
        }

        private static void createTimetable()
        {
            foreach (Semester s in Semesters)
            {
                List<Classroom> matchsize = Classrooms.FindAll(c => c.seats >= s.students);
                foreach (Classroom c in matchsize)
                {
                    
                    Console.WriteLine("For " + s.name + " Raum: " + c.name + " " + c.seats);
                }
            }
        }
        private static void readData()
        {
            XmlTextReader reader = new XmlTextReader("data.xml");
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "semester":
                            Semester semester = new Semester();
                            Semesters.Add(semester);
                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "name")
                                        semester.name = reader.Value;
                                    if (reader.Name == "students")
                                        semester.students = Int32.Parse(reader.Value);
                                    if (reader.Name.Contains("subject"))
                                    {
                                        Subject subject = new Subject();
                                        subject.name = reader.Value;
                                        semester.subjects.Add(subject);
                                    }
                                }
                            }
                            break;
                        case "lecturer":
                            Lecturer lecturer = new Lecturer();
                            Lecturers.Add(lecturer);
                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "name")
                                        lecturer.name = reader.Value;
                                    if (reader.Name.Contains("subject"))
                                    {
                                        Subject subject = new Subject();
                                        subject.name = reader.Value;
                                        lecturer.subjects.Add(subject);
                                    }
                                    if (reader.Name.Contains("presence"))
                                        lecturer.presence.Add(reader.Value);
                                }
                            }
                            break;
                        case "classroom":
                            Classroom classroom = new Classroom();
                            Classrooms.Add(classroom);
                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "name")
                                        classroom.name = reader.Value;
                                    if (reader.Name == "seats")
                                        classroom.seats = Int32.Parse(reader.Value);
                                    if (reader.Name == "building")
                                        classroom.building = reader.Value;
                                    if (reader.Name.Contains("equipment"))
                                    {
                                        classroom.equipment.Add(reader.Value);
                                    }
                                }
                            }
                            break;
                    }
                }
            }
            reader.Close();
        }
    }
}
