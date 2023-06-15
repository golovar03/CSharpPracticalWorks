using PracticalWork10.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PracticalWork10.ViewModel
{
    internal class TableWindowViewModel : ViewModelBase
    {
        #region Заголовок окна
        /// <summary>заголовок программы</summary>
        private string _title = "Главное окно";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
        #endregion

        #region Статус программы
        /// <summary>статус выполнения программы</summary>
        private string _status = "Ok";

        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
        #endregion

    }
}
