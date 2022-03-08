using Site01.Database;
using Site01.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Site01.Library.Validation
{
    public class UniqueWordNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Word word = validationContext.ObjectInstance as Word;
     
            var _db = (DatabaseContext)validationContext.GetService(typeof(DatabaseContext));

            // Já existe no banco de dados 1 registro: 
            // - Verificar se nome existe
            // - Verificar se o Id é o mesmo do registro no banco.

            var wordInBD = _db.Words.Where(a => a.WordName == word.WordName && a.Id != word.Id).FirstOrDefault();

            if (wordInBD == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("A palavra '" + word.WordName + "' já está sendo utilizada!");
            }
        }
    }
}