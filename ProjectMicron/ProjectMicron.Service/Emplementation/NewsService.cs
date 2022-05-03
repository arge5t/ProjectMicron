using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProjectMicron.DAL.Interfaces;
using ProjectMicron.Domain.Entity;
using ProjectMicron.Domain.Enum;
using ProjectMicron.Domain.Response;
using ProjectMicron.Domain.ViewModels.New;
using ProjectMicron.Service.Interfaces;

namespace ProjectMicron.Service.Emplementation
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<IBaseResponse<NewsRobotViewModel>> CreateNew(NewsRobotViewModel newsRobotViewModel)
        {
            var baseResponse = new BaseResponse<NewsRobotViewModel>();

            try
            {
                var NewRobot = new NewsRobot()
                {
                    Description = newsRobotViewModel.Description,

                    CreationTime = DateTime.Now,

                    Title = newsRobotViewModel.Title,


                };

                await _newsRepository.Create(NewRobot);
            }
            catch (Exception exception)
            {
                return new BaseResponse<NewsRobotViewModel>()
                {
                    Description = $"[CreateNew]:{exception.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }

            return baseResponse;
        }

        public async Task<IBaseResponse<bool>> DeleteNew(int id)
        {
            var baseResponse = new BaseResponse<bool>()
            {
                Data = true
            };

            try
            {
                var newRobot = await _newsRepository.Get(id);

                if (newRobot == null)
                {
                    baseResponse.Description = "New not found";
                    baseResponse.StatusCode = StatusCode.NewNotFound;
                    baseResponse.Data = false;

                    return baseResponse;
                }

                await _newsRepository.Delete(newRobot);
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception exception)
            {
                return new BaseResponse<bool>()
                {
                    Description = $"[DeleteNew]:{exception.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<NewsRobot>> GetNewByName(string name)
        {
            var baseResponse = new BaseResponse<NewsRobot>();
            try
            {
                var newRobot = await _newsRepository.GetName(name);

                if (newRobot == null)
                {
                    baseResponse.Description = "New not found";
                    baseResponse.StatusCode = StatusCode.NewNotFound;

                    return baseResponse;
                }

                baseResponse.Data = newRobot;
                return baseResponse;
            }
            catch (Exception exception)
            {
                return new BaseResponse<NewsRobot>()
                {
                    Description = $"[GetNew]:{exception.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }


        public async Task<IBaseResponse<NewsRobotViewModel>> GetNew(int id)
        {
            var baseResponse = new BaseResponse<NewsRobotViewModel>();
            try
            {
                var newRobot = await _newsRepository.Get(id);

                if (newRobot == null)
                {
                    baseResponse.Description = "New not found";
                    baseResponse.StatusCode = StatusCode.NewNotFound;

                    return baseResponse;
                }

                var data = new NewsRobotViewModel()
                {
                    Title = newRobot.Title,
                    CreationTime = newRobot.CreationTime,
                    Description = newRobot.Description,
                    

                };

                baseResponse.StatusCode = StatusCode.OK;
                baseResponse.Data = data;
                return baseResponse;
            }
            catch (Exception exception)
            {
                return new BaseResponse<NewsRobotViewModel>()
                {
                    Description = $"[GetNew]:{exception.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<NewsRobot>>> GetNews()
        {
            var baseResponse = new BaseResponse<IEnumerable<NewsRobot>>();

            try
            {
                var news = await _newsRepository.Select();

                if (news.Count == 0)
                {
                    baseResponse.Description = "Found 0 items";
                    baseResponse.StatusCode = StatusCode.OK;
                    return baseResponse;
                }

                baseResponse.Data = news;
                baseResponse.StatusCode = StatusCode.OK;

                return baseResponse;
            }
            catch (Exception exception)
            {
                return new BaseResponse<IEnumerable<NewsRobot>>()
                {
                    Description = $"[GetNews]:{exception.Message}"
                };

            }

        }

        public async Task<BaseResponse<NewsRobot>> Edit(int id, NewsRobotViewModel model)
        {
            var baseResponse = new BaseResponse<NewsRobot>();

            try
            {
                var newRobot = await _newsRepository.Get(id);

                if (newRobot == null)
                {
                    baseResponse.StatusCode = StatusCode.NewNotFound;
                    baseResponse.Description = "New not found ";
                    return baseResponse;
                }

                newRobot.Description = model.Description;
                newRobot.Title = model.Title;
                newRobot.CreationTime = model.CreationTime;

                await _newsRepository.Update(newRobot);

                return baseResponse;
            }
            catch (Exception exception)
            {
                return new BaseResponse<NewsRobot>()
                {
                    Description = $"[Edit]:{exception.Message}",
                    StatusCode = StatusCode.InternalServerError
                };
            }
        }
    }
}
