using Microsoft.Extensions.Configuration;

namespace BusinessLayer
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup()
        {
            
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            DataAccessLayer.DBTools.DBConfig.ConnectionString = Configuration.GetSection("DBConfig").GetValue<string>("ConnectionString");
                
              
        }
       
    }
}
