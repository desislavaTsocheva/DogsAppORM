using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOrm_11d.Model
{
    public class DogsContects:DbContext
    {
       public DogsContects():base("DogsContects")
       {

       }
       public DbSet<Dog> Dogs { get; set; } //create table dogs
       public DbSet<Breed> Breeds { get; set; }

       
    }
}
