using System.ComponentModel.DataAnnotations;

namespace ClientService.Domain.Enums
{
    public enum MaritalStatus
    {
        [Display(Name = "Anulled")]
        Anulled,

        [Display(Name = "Live-in")]
        Livein,

        [Display(Name = "Married")]
        Married,

        [Display(Name = "Separated")]
        Seprated,

        [Display(Name = "Single")]
        Single,

        [Display(Name = "Widowed")]
        Widowed
    }
}
