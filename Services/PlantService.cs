
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PIT.Models;


namespace PIT.Services
{
    public class PlantService
    {
        private readonly List<Plant> _plants = new();

        public PlantService()
        {
            
            _plants.Add(new Plant
            {
                Id = 1,
                Name = "Lírio-da-paz",
                ScientificName = "Spathiphyllum",
                Health = 75,
                LastWatered = DateTime.Now.AddDays(-2),
                NextWatering = DateTime.Now.AddDays(2)
            });
            _plants.Add(new Plant
            {
                Id = 2,
                Name = "Monstera",
                ScientificName = "Monstera deliciosa",
                Health = 90,
                LastWatered = DateTime.Now.AddDays(-3),
                NextWatering = DateTime.Now.AddDays(4)
            });
            _plants.Add(new Plant
            {
                Id = 3,
                Name = "Figueira-lira",
                ScientificName = "Ficus lyrata",
                Health = 60,
                LastWatered = DateTime.Now.AddDays(-1),
                NextWatering = DateTime.Now.AddDays(6)
            });
        }

        public Task<List<Plant>> GetAllAsync() => Task.FromResult(_plants.ToList());

        public Task<Plant?> GetByIdAsync(int id) => Task.FromResult(_plants.FirstOrDefault(p => p.Id == id));

        public Task AddAsync(Plant plant)
        {
            plant.Id = _plants.Count == 0 ? 1 : _plants.Max(p => p.Id) + 1;
            if (plant.NextWatering == null)
                plant.NextWatering = plant.LastWatered.AddDays(3); 
            _plants.Add(plant);
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Plant plant)
        {
            var existing = _plants.FirstOrDefault(p => p.Id == plant.Id);
            if (existing == null) return Task.CompletedTask;
            existing.Name = plant.Name;
            existing.ScientificName = plant.ScientificName;
            existing.Health = plant.Health;
            existing.LastWatered = plant.LastWatered;
            existing.NextWatering = plant.NextWatering;
            existing.ImageUrl = plant.ImageUrl;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var p = _plants.FirstOrDefault(x => x.Id == id);
            if (p != null) _plants.Remove(p);
            return Task.CompletedTask;
        }
    }
}
