using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DAL.Context;

public class AgencyContextFactory : IDesignTimeDbContextFactory<AgencyContext>
{
    public AgencyContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AgencyContext>();

        optionsBuilder.UseSqlServer("Data Source=S8IGHT\\SQLEXPRESS;Database=AgencyChatSystem;Trusted_Connection=True;");
        return new AgencyContext(optionsBuilder.Options);
    }
}