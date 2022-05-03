using System.ComponentModel.DataAnnotations;

namespace ProjectMicron.Domain.Enum
{
    public enum TypeNew
    {
        [Display(Name = "Робототехника")]
        Robotics = 0,
        [Display(Name = "Программирование")]
        Programming = 1,
        [Display(Name = "Электроника")]
        Electronics = 2,
        [Display(Name = "Моделирование")]
        Modeling = 3,
       
    }
}
