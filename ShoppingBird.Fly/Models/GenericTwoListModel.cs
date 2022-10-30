using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Fly.Models
{
    public class GenericTwoListModel
    {
        public GenericTwoListModel GetLists<T, TU>()
        {
            T1 = new List<T>();
            U1 = new List<TU>();

            return this;
        }

        public dynamic T1 { get; set; }
        public dynamic U1 { get; set; }
    }
}
