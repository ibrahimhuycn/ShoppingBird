using System.Collections.Generic;

namespace ShoppingBird.Fly.Models
{
    public class GenericModelAndListModel
    {
        public GenericModelAndListModel GetNewModel<T, TU>() where T : new()
        {
            T1 = new T();
            U1 = new List<TU>();

            return this;
        }

        public dynamic T1 { get; set; }
        public dynamic U1 { get; set; }
    }
}
