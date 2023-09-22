using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace api.Models
{
    public class Sample
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string CreatedAt { get; set; }

        //nullable boolean
        public bool? TestBool {get; set;}

        //non-nullable boolean
        public bool SecondTestBool {get;set;}
        public int FavouriteNumber { get; set; }


    }
}