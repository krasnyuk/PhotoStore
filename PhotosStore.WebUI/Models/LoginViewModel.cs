﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhotosStore.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Введите логин")]
        
        public string UserName { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        public string Password { get; set; }
    }
}