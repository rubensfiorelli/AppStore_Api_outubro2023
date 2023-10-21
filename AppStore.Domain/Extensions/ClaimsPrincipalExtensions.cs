﻿using System.Security.Claims;

namespace AppStore.Domain.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetUserName(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.Name)?.Value;

        public static string GetUserId(this ClaimsPrincipal user)
           => user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }





}
