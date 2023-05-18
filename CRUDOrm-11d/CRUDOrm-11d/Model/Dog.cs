using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOrm_11d.Model
{
    public class Dog
    {
       public int Id { get; set; }  
       public string Name { get; set; } 
       public int Age { get; set; }

       //M:1
       public int BreedId { get; set; } //FK

       //Breed e tablicata za vruzka
       public Breed Breeds { get; set; }
    }
}
