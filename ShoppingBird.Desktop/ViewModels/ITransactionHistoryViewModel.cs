using ShoppingBird.Desktop.Models;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace ShoppingBird.Desktop.ViewModels
{
    public interface ITransactionHistoryViewModel
    {
        DateTime EndDate { get; set; }
        DateTime StartDate { get; set; }
        BindingList<TransactionHistoryModel> TransactionHistory { get; set; }
        bool IsGetCompleteTransactionHistory { get; set; }
        decimal SumOfTotal { get; set; }

        Task LoadTransactionHistoryAsync();
        void CalculateCurrentTotal();
    }
}