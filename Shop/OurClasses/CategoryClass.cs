using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.OurClasses
{

    [Serializable]

    public class CategoryClass
    {
        public static List<CategoryClass> ourCategories= new List<CategoryClass>();
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
