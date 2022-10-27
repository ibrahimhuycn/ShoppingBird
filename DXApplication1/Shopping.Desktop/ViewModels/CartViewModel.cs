using AutoMapper;
using Shopping.Desktop.Helpers;
using Shopping.Desktop.Models;
using ShoppingBird.Fly.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopping.Desktop.ViewModels
{
    public class CartViewModel : NotifyBase, ICartViewModel
    {
        private readonly IItemIO _itemIO;
        private readonly IMapper _mapper;

        public CartViewModel(IItemIO itemIO, IMapper mapper)
        {
            _itemIO = itemIO;
            _mapper = mapper;
            Initialize();
        }


        public List<ItemListAllModel> ItemSearchDatasource { get; set; }
        private void Initialize()
        {
            LoadItemsSearchData();
        }

        private void LoadItemsSearchData()
        {
            var data = _itemIO.GetAllItemDescriptions();
            var mapped = _mapper.Map<List<ItemListAllModel>>(data);
            ItemSearchDatasource.AddRange(mapped);
        }
    }
}
