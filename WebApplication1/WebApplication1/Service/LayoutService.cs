using WebApplication1.DAL;

namespace WebApplication1.Service
{
    public class LayoutService
    {
        private readonly AppDbContext _dbContext;

        public LayoutService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Dictionary<string,string> GetService()
        {
            return _dbContext.Settings.ToList().ToDictionary(x=>x.Key,x=>x.Value);
        }
    }
}
