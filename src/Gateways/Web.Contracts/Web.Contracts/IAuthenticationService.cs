﻿namespace Blog.Gateways.Web.Contracts
{
    using System.Threading.Tasks;
    using Blog.Application.Common.Models;

    // Work in progress - it is not yet used.
    public interface IAuthenticationService
    {
        Task<Result> ChangePassword();

        Task<Result> Login(ILoginModelContract model);

        Task Logout();
        
        Task<Result> Register(IRegisterModelContract model);
    }
}