using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Charansinh.BookStore.Enums
{
    public enum LanguageEnum
    {
        [Display(Name ="Gujarati")]
        Guj,
        [Display(Name = "Hindi")]
        Hin,
        [Display(Name = "Sanskrit")]
        San,
        [Display(Name = "DevNaagari")]
        Dev,
        [Display(Name = "English")]
        Eng,
        [Display(Name = "Marathi")]
        Mar
    }
}
