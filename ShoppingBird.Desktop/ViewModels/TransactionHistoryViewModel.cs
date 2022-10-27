using AutoMapper;
using ShoppingBird.Desktop.Helpers;
using ShoppingBird.Desktop.Models;
using ShoppingBird.Fly.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.ViewModels
{
    public class TransactionHistoryViewModel : NotifyBase, ITransactionHistoryViewModel
    {
        #region Private Properties
        private readonly IInvoiceIO _invoiceIO;
        private readonly IMapper _mapper;
        private DateTime? _startDate;
        private DateTime? _endDate;
        #endregion

        #region Constructor
        public TransactionHistoryViewModel(IInvoiceIO invoiceIO, IMapper mapper)
        {
            TransactionHistory = new BindingList<TransactionHistoryModel>();
            _invoiceIO = invoiceIO;
            _mapper = mapper;
        }
        #endregion

        #region Public properties
        public BindingList<TransactionHistoryModel> TransactionHistory { get; set; }
        public DateTime? StartDate
        {
            get => _startDate; set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }
        public DateTime? EndDate
        {
            get => _endDate; set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Public Methods
        public async Task LoadTransactionHistoryAsync()
        {
            try
            {
                var transactionHistory = await _invoiceIO.GetTransactionHistoryAsync();
                var mappedTransactionHistory = _mapper.Map<List<TransactionHistoryModel>>(transactionHistory);

                foreach (var item in mappedTransactionHistory)
                {
                    TransactionHistory.Add(item);
                }
            }
            catch (Exception ex)
            {
                Helpers.NotificationHelper.ShowMessage(ex, "Error Loading Transaction History");
            }

        }
        #endregion
    }
}
