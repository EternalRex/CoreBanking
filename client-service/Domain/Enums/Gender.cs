using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace ClientService.Domain.Enums
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male,

        [Display(Name = "Female")]
        Female,
    }
}
