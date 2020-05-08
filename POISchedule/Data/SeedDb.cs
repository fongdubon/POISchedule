using POISchedule.Helpers;
using System.Threading.Tasks;

namespace POISchedule.Data
{
    public class SeedDb
    {
        private readonly DataContext dataContext;
        private readonly IUserHelper userHelper;

        public SeedDb(DataContext dataContext,
            IUserHelper userHelper)
        {
            this.dataContext = dataContext;
            this.userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await this.dataContext.Database.EnsureCreatedAsync();
            //crear los roles
            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("User");
            await this.userHelper.CheckRoleAsync("Lender");//Prestador segun Saul
        }
    }
}
