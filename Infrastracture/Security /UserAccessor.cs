using System;
using System.Security.Claims;
using Application.Interfaces;
using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Infrastracture.Security;

public class UserAccessor(IHttpContextAccessor httpContextAccessor, AppDbContext appDbContext) : IUserAccessor
{
    public async Task<User> GetUserAsync()
    {
        return await appDbContext.Users.FindAsync(GetUserId())
            ?? throw new UnauthorizedAccessException("No user si logged in");
    }

    public string GetUserId()
    {
        return httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new Exception("User not found");
    }

    public async Task<User> GetUserWithPhotosAsync()
    {
        var userId = GetUserId();

        return await appDbContext.Users
            .Include(x => x.Photos)
            .FirstOrDefaultAsync(x => x.Id == userId)
                ?? throw new UnauthorizedAccessException("No user si logged in");
    }
}
