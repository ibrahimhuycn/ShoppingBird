using AutoMapper;
using ShoppingBird.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.ViewModels
{
    public class ItemViewModel: NotifyBase
    {
        #region Private Fileds
        private readonly IMapper _mapper;

        #endregion
        #region Constructor
        public ItemViewModel(IMapper mapper)
        {
            _mapper = mapper;
        }
        #endregion
        #region Public Properties

        #endregion
        #region Public Methods

        #endregion
        #region Private Methods

        #endregion
    }
}
