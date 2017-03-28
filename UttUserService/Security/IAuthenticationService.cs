﻿using UttUserService.DB.Entities;

namespace UttUserService.Security
{
    public interface IAuthenticationService
    {
        User AuthenticateUser(string username, string textPpassword);
    }
}