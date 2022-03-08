using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Site01.Library.Validation;

namespace Site01.Models
{
    public class Word
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo 'Nome' é obrigatório!")]
        [MaxLength(70, ErrorMessage = "O campo 'Nome' deve conter o máximo de 70 caracteres!")]
        [UniqueWordName]
        public string WordName { get; set; }

        // 1 - easy, 2 - medium, 3 - hard
        public byte? WordLevel { get; set; }
    }
}
