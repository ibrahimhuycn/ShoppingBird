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
        private DateTime _startDate;
        private DateTime _endDate;
        private bool _isGetCompleteTransactionHistory;
        #endregion

        #region Constructor
        public TransactionHistoryViewModel(IInvoiceIO invoiceIO, IMapper mapper)
        {
            TransactionHistory = new BindingList<TransactionHistoryModel>();
            _invoiceIO = invoiceIO;
            _mapper = mapper;

            StartDate = DateTime.Today;
            EndDate = DateTime.Today;
            IsGetCompleteTransactionHistory = false;
        }
        #endregion

        #region Public properties
        public BindingList<TransactionHistoryModel> TransactionHistory { get; set; }
        public DateTime StartDate
        {
            get => _startDate; set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }
        public DateTime EndDate
        {
            get => _endDate; set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }
        public bool IsGetCompleteTransactionHistory
        {
            get => _isGetCompleteTransactionHistory; set
            {
                _isGetCompleteTransactionHistory = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Public Methods
        public async Task LoadTransactionHistoryAsync()
        {
            try
            {
                TransactionHistory.Clear();
                if (IsGetCompleteTransactionHistory)
                {
                    var transactionHistory = await _invoiceIO.GetTransactionHistoryAsync();
                    var mappedTransactionHistory = _mapper.Map<List<TransactionHistoryModel>>(transactionHistory);
                    DisplayTransactionHistory(mappedTransactionHistory);
                }
                else
                {
                    var transactionHistory = await _invoiceIO.GetTransactionHistoryAsync(StartDate, EndDate);
                    var mappedTransactionHistory = _mapper.Map<List<TransactionHistoryModel>>(transactionHistory);
                    DisplayTransactionHistory(mappedTransactionHistory);
                }
            }
            catch (Exception ex)
            {
                Helpers.NotificationHelper.ShowMessage(ex, "Error Loading Transaction History");
            }

        }

        private void DisplayTransactionHistory(List<TransactionHistoryModel> transactionHistory)
        {

            foreach (var item in transactionHistory)
            {
                TransactionHistory.Add(item);
            }
        }
        #endregion
    }
}
