using System.ComponentModel.DataAnnotations;

namespace ClientService.Domain.Enums
{
    public enum Salutation
    {
        [Display(Name = "Mr")]
        Mr,

        [Display(Name = "Mrs")]
        Mrs,

        [Display(Name = "Ms")]
        Ms,
    }
}
