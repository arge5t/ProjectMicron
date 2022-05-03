using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectMicron.Domain.Entity;
using ProjectMicron.Domain.ViewModels.New;
using ProjectMicron.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectMicron.Controllers
{
    public class NewsRobotController : Controller
    {
        private INewsService _newsService;



        public NewsRobotController(INewsService newService)
        {
            _newsService = newService;

        }

        [HttpGet]
        public async Task<IActionResult> GetNews()
        {

            var response = await _newsService.GetNews();


            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }
            return RedirectToAction("Error");
        }



        [HttpGet]
        public async Task<IActionResult> GetNew(int id)
        {

            var response = await _newsService.GetNew(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("Error");
        }

        /* [Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _newsService.DeleteNew(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return RedirectToAction("GetNews");
            }

            return RedirectToAction("Error");
        }

        [HttpGet]
        /*  [Authorize(Roles = "Admin")]*/
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
            {
                return View();
            }

            var response = await _newsService.GetNew(id);

            if (response.StatusCode == Domain.Enum.StatusCode.OK)
            {
                return View(response.Data);
            }

            return RedirectToAction("GetNews");
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewsRobotViewModel model)
        {

            if (model.Id == 0)
            {
                await _newsService.CreateNew(model);

            }
            else
            {
                await _newsService.Edit(model.Id, model);
            }

            return RedirectToAction("GetNews");
        }


    }
}