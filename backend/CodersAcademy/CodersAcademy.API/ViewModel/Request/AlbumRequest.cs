using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodersAcademy.API.ViewModel.Request
{
    public class AlbumRequest : IValidatableObject
    {
        [Required]
        public String Name { get; set; }

        [Required]
        public String Band { get; set; }

        [Required]
        public String Description { get; set; }

        [Required]
        public String Backdrop { get; set; }

        [Required]
        public List<MusicRequest> Musics { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var result = new List<ValidationResult>();

            //Somente no C# 9 -> .NET 5
            if (this.Musics is null)
                yield return new ValidationResult("Album must contain at least one music"); //Valida se Music não é nula

            if (this.Musics.Any() == false)
                yield return new ValidationResult("Album must contain at least one music"); // Valida se Music tem pelo menos um item

            //Valida todas as propriedades do objeto Music
            foreach (var item in this.Musics)
            {
                if (Validator.TryValidateObject(item, new ValidationContext(item), result) == false)
                    yield return result.First();
            }
        }
    }
}
