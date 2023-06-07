using PracticalWork10.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PracticalWork10.ViewModel
{
    internal class TableViewModel : ViewModelBase
    {
        /// <summary>заголовок программы</summary>
        private string _title = "Главное окно";

        /// <summary>статус выполнения программы</summary>
        private string _status = "Ok";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
    }
}
