using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMicron.Domain.Entity;
using ProjectMicron.Domain.Response;
using ProjectMicron.Domain.ViewModels.New;

namespace ProjectMicron.Service.Interfaces
{
    public interface INewsService
    {
        Task<IBaseResponse<IEnumerable<NewsRobot>>> GetNews();

        Task<IBaseResponse<NewsRobotViewModel>> GetNew(int id);

        Task<IBaseResponse<NewsRobot>> GetNewByName(string name);

        Task<IBaseResponse<NewsRobotViewModel>> CreateNew(NewsRobotViewModel newsRobotViewModel);

        Task<IBaseResponse<bool>> DeleteNew(int id);

        Task<BaseResponse<NewsRobot>> Edit(int id, NewsRobotViewModel model);


    }
}