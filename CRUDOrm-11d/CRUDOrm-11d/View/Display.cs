using CRUDOrm_11d.Controller;
using CRUDOrm_11d.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDOrm_11d.View
{
    public class Display
    {
        private DogLogic dogLogic = new DogLogic();
        private int closeOperation = 6;

        //private void Input()
        //{
        //    var operation = -1;
        //    do
        //    {
        //        ShowMenu();
        //        operation = int.Parse(Console.ReadLine());
        //        switch (operation)
        //        {
        //            case 1:
        //                ListAll();
        //                break;
        //            case 2:
        //                Add();
        //                break;
        //            case 3:
        //                Update();
        //                break;
        //            case 4:
        //                Fetch();
        //                break;
        //            case 5:
        //                Delete();
        //                break;
        //            default:
        //                break;
        //        }
        //    } while (operation != closeOperation);
        //}
        public Display()
        {
            //Input();
        }
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }

        private void PrintDog(Dog dog)
        {
            Console.WriteLine($"{dog.Id}. {dog.Name} -- Age: {dog.Age} BreedId: {dog.BreedId}");
        }
    }
}
   