using System.Collections.Generic;

namespace ShoppingBird.Fly.Models
{
    public class GenericThreeListsModel
    {
        public GenericThreeListsModel GetLists<T, TU, TV>() where T : new()
        {
            T1 = new List<T>();
            U1 = new List<TU>();
            V1 = new List<TV>();

            return this;
        }

        public dynamic T1 { get; set; }
        public dynamic U1 { get; set; }
        public dynamic V1 { get; set; }
    }
}
