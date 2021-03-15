using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace S2_Lab02
{
    public class PlaneIdCheckAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is int id)
            {
                if (id > 0 && id < 1000)
                    return true;
                this.ErrorMessage = "ID не задан, либо задан неправильно";
            }
            return false;
        }
    }
}