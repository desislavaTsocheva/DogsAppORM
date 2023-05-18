using CRUDOrm_11d.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOrm_11d.Controller
{
    public class BreedsLogic
    {
        private DogsContects dogContext = new DogsContects();

        public List<Breed> GetAllBreeds()
        {
            return dogContext.Breeds.Include("Breed").ToList();
        }
        public string GetBreedById(int id)
        {
            return dogContext.Breeds.Find(id).Name;
        }

    }
}
