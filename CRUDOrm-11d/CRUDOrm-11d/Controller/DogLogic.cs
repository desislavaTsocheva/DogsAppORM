using CRUDOrm_11d.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOrm_11d.Controller
{
    public class DogLogic
    {
        private DogsContects dogsContext = new DogsContects();
        public Dog Get(int id)
        {
            Dog findDog = dogsContext.Dogs.Find(id);
            if(findDog != null) 
            {
                dogsContext.Entry(findDog).Reference(x => x.Breeds).Load();
            }
            return findDog;
        }
        public List<Dog> GetAll()
        {
            return dogsContext.Dogs.Include("Breed").ToList();
        }
        public void Create(Dog dog)
        {
            dogsContext.Dogs.Add(dog);
            dogsContext.SaveChanges();
        }
        public void Updates(int id,Dog dog)
        {
            Dog findDog = dogsContext.Dogs.Find(id);
            if (findDog == null)
            {
                return;
            }
            findDog.Age = dog.Age;
            findDog.Name = dog.Name;
            findDog.Breeds = dog.Breeds;
            dogsContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Dog findDog = dogsContext.Dogs.Find(id);
            dogsContext.Dogs.Remove(findDog);
            dogsContext.SaveChanges();
        }
    }
}
