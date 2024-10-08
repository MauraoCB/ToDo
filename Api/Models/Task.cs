﻿using System;
using System.ComponentModel.DataAnnotations;

namespace ToDo_API.Models
{
    public class Task
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Por favor informe o titulo")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Por favor informe descricao")]
        public string Description { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; }
    }
}
