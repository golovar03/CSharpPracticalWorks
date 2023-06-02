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
        private string _title = "Главное окно";
        /// <summary> Задание и вывод заголовка главного окна </summary>
        public string Title 
        { 
            get => _title;
            set=> Set(ref _title, value);
        }
    }
}
