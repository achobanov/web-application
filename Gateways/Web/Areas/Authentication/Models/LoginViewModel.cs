﻿using System.ComponentModel.DataAnnotations;
using Blog.Gateways.Web.Contracts;
using static Blog.Gateways.Web.Infrastructure.WebConstants.ViewConstants;

namespace Blog.Gateways.Web.Areas.Authentication.Models
{
    public class LoginViewModel : BaseAuthenticationViewModel, ILoginModel
    {
        [Display(Name = Labels.RememberMe)]
        public bool RememberMe { get; set; }
    }
}