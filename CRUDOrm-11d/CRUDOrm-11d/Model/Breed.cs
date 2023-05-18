using System.Collections;
using System.Collections.Generic;

namespace CRUDOrm_11d.Model
{
    public class Breed
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Description { get; set; } 
        //1:M
        public ICollection<Dog> Dogs { get; set; }  

    }
}