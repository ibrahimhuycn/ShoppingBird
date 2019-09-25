using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingBird.Fly.Interfaces
{
    public interface ITaxIO
    {
        List<Tax> GetAllTax();
        void SaveTax(Tax e);
    }
}
