using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PicDB.ViewModel
{
    public abstract class ViewModel : DependencyObject, INotifyPropertyChanged
    {
        /// <summary>
        /// Event if property might change
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
