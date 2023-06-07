using PracticalWork10.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalWork10.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        /// <summary>заголовок программы</summary>
        private string _title = "Клиент";
        /// <summary>статус выполнения программы</summary>
        private string _status = "Ok!";

        /// <summary> Задание и вывод заголовка главного окна </summary>
        public string Title 
        { 
            get => _title;
            set=> Set(ref _title, value);
        }

        public string Status
        {
            get => _status;
            set =>  Set(ref _status, value);
        }
    }
}
