using S2_Lab02.Crew;
using System.ComponentModel.DataAnnotations;

namespace S2_Lab02
{
    public class CrewMember : IPrototypeCrew
    {
        [Required(ErrorMessage = "Имя должно быть задано")]
        [StringLength(15, ErrorMessage = "Имя слишком длинное")]
        [RegularExpression("([A-Z]{1}[a-z]*)|([А-Я]{1}[а-я]*)", ErrorMessage = "Имя задано неверно.")]
        public string Name { get; set; }
        public int Age { get; set; }
        public int WorkExperience { get; set; }
        [Required(ErrorMessage = "Должность должна быть задана")]
        public string Position { get; set; }

        public IPrototypeCrew Clone()
        {
            return this.MemberwiseClone() as IPrototypeCrew;
        }

        public override string ToString()
        {
            return "----------------------------------------------\n" +
                   "Имя:\t" + Name + "\n" +
                   "Возраст:\t" + Age + "\n" +
                   "Опыт работы:\t" + WorkExperience + "\n" +
                   "Должность:\t" + Position + "\n" +
                   "----------------------------------------------\n";
        }
    }
}