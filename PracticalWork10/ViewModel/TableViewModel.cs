using PracticalWork10.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PracticalWork10.ViewModel
{
    internal class TableViewModel : ViewModelBase
    {
        private string _title = "Главное окно";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
    }
}
