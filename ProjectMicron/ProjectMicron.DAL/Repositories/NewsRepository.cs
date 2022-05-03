using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectMicron.DAL.Interfaces;
using ProjectMicron.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using ProjectMicron.DAL;

namespace ProjectMicron.DAL.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly ApplicationDbContext _database;

        public NewsRepository(ApplicationDbContext database)
        {
            _database = database;
        }
        public async Task<bool> Create(NewsRobot model)
        {

            await _database.NewsRobot.AddAsync(model);
            await _database.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(NewsRobot model)
        {
            _database.NewsRobot.Remove(model);
            await _database.SaveChangesAsync();

            return true;
        }

        public async Task<NewsRobot> Get(int id)
        {
            return await _database.NewsRobot
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<NewsRobot> GetName(string title)
        {
            return await _database.NewsRobot.FirstOrDefaultAsync(x => x.Title == title);
        }

        public async Task<List<NewsRobot>> Select()
        {
            return await _database.NewsRobot.ToListAsync();
        }

        public async Task<NewsRobot> Update(NewsRobot model)
        {
            _database.NewsRobot.Update(model);
            await _database.SaveChangesAsync();

            return model;

        }
    }
}

