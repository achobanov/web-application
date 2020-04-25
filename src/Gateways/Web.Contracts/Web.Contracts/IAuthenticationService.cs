﻿namespace Blog.Gateways.Web.Contracts
{
    using System.Threading.Tasks;
    using Blog.Application.Common.Models;

    public interface IAuthenticationService
    {
        Task<Result<string>> Login(ILoginModelContract model);

        Task Logout();
        
        Task<Result> Register(IRegisterModelContract model);
    }
}