using S2_Lab02.Planes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace S2_Lab02
{
    public class Plane
    {
        [PlaneIdCheck]
        public int Id { get; set; }

        [Required(ErrorMessage = "Тип Самолёта должен быть задан.")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Модель самолёта должна быть задана.")]
        public string Model { get; set; }
        public DateTime DateRelease { get; set; }
        public int LoadCapacity { get; set; }
        public int PassengersSeatsAmount { get; set; }
        public List<CrewMember> Crew { get; }

        public Plane()
        {
            Crew = new List<CrewMember>();
        }

       public Plane(PlaneFactory factory, int id)
        {
            Crew = new List<CrewMember>();
            Id = id;
            Type = factory.CreateType();
            Model = factory.CreateModel();
        }
        
        public Plane(List<CrewMember> listCrew)
        {
            Crew = listCrew;
        }

        public override string ToString()
        {
            var crewToString = "";

            foreach (var crewMember in Crew)
            {
                crewToString = crewToString + "--------\r\n" +
                               $"\tИмя: {crewMember.Name}\r\n" +
                               $"\tВозраст: {crewMember.Age}.\r\n" +
                               $"\tСтаж: {crewMember.WorkExperience}.\r\n" +
                               $"\tДолжность: {crewMember.Position}.\r\n" +
                               "--------\r\n";
            }
            return $"\r\n//////Самолёт {Id}//////\r\n" +
                   $"Тип: {Type}\r\n" +
                   $"Модель: {Model}\r\n" +
                   $"Дата выпуска: {DateRelease:dd.MM.yyyy}\r\n" +
                   $"Грузоподъёмность: {LoadCapacity}\r\n" +
                   $"Пассажирские места: {PassengersSeatsAmount}\r\n" +
                   $"\tЭкипаж:\r\n" + crewToString +
                   "\r\n////////////\r\n";
        }
    }
}