using System;
using System.Collections.Generic;

namespace ShoppingBird.Fly.Models
{
    public class TypesModel
    {
        public TypesModel()
        {
            GenericModelsList = new List<Type>();
        }
        public List<Type> GenericModelsList { get; set; }
    }
}
