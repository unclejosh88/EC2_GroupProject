using JPS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JPS.ViewModels
{
    public class DeductBnsViewModel
    {

        public int ID { get; set; }

        [Required]
        public string CardNum { get; set; }

        [Required]
        public float Amt { get; set; }

        [Required]
        public Bill bills { get; set; }


    }
}
