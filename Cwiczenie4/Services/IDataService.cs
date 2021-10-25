using System.Collections.Generic;
using Cwiczenie4.Models;

namespace Cwiczenie4.Services
{
    public interface IDataService
    {
        List<Animal> GetAnimals(string orderBy);
        void CreateAnimal(Animal animal);
        void ChangeAnimal(int idAnimal, Animal animal);
        void DeleteAnimal(int idAnimal);
    }
}