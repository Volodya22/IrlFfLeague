using System.Threading.Tasks;
using IrlFfLeague.DataLayer;
using IrlFfLeague.Services;
using Microsoft.EntityFrameworkCore;
using Quartz;

namespace IrlFfLeague.Web.Jobs
{
    public class UpdateDataJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                using (var model = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
                {
                    ParsingService.UpdateData(model);
                }
            });
        }
    }
}
