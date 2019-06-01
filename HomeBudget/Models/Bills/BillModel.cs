using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//2) wlidacja danych
namespace HomeBudget.Models.Bills
{
    public class BillModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please fill in amount.")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [RegularExpression(@"^[0-9]+([\.,][0-9]{1,2})?$", ErrorMessage = "Amount need to be in proper format." )]
        public string Amount { get; set; }

        [Required(ErrorMessage = "Please fill in description.")]
        [MaxLength(500, ErrorMessage = "Description length have to be less than 500"), MinLength(3, ErrorMessage = "Description length have to be greater than 3")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        [Required(ErrorMessage = "Date of bill need to be provider.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? BillDate { get; set; }
    }
}
