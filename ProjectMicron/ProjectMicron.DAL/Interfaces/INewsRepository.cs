using System.Threading.Tasks;
using ProjectMicron.Domain.Entity;

namespace ProjectMicron.DAL.Interfaces
{

    public interface INewsRepository : IBaseRepository<NewsRobot>
    {
        Task<NewsRobot> GetName(string title);
    }

}

