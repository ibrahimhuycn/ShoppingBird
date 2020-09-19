using Plugin.Toast.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingBird.Mobile.Models
{
    public class ToastModel
    {
        public string Message { get; set; }

        public MessageType Type { get; set; }
        public ToastLength ToastLength { get; set; }

        public enum MessageType
        {
            Normal,
            Success,
            Warning,
            Error
        }
    }
}
