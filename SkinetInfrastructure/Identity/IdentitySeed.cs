using Microsoft.AspNetCore.Identity;
using SkinetCore.Entities.Identity;

namespace SkinetInfrastructure.Identity
{
    public class IdentitySeed
    {
        public static async Task SeedUser(UserManager<AppUser> userMenager)
        {
            if (!userMenager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "baks",
                    Email = "bakstest@gmail.com",
                    UserName = "viktorp99",
                    Address = new Address
                    {
                        FirstName = "Viktor",
                        LastName = "Petrovski",
                        Street = "Partizanska",
                        City = "Bitola",
                        State = "Macedonia",
                        ZipCode = "7000"
                    }
                };

                await userMenager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
