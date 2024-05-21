﻿using System;
using System.ComponentModel.DataAnnotations;

namespace StudyNow.Web.Models
{
    public class SubjectViewModel
    {
        public Guid SubjectId { get; set; }

        [Required(ErrorMessage = "Необхідно ввести назву навчального предмета.")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Необхідно ввести опис навчального предмета.")]
        [StringLength(500)]
        public string Description { get; set; }
    }
}