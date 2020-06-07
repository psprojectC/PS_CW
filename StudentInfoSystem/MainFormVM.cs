using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace StudentInfoSystem
{
    public class MainFormVM : INotifyPropertyChanged
    {
        private Student _student;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Title
        {
            get { return "Студентска информационна система"; }
        }

        public Student CurrentStudent
        {
            get { return _student; }
            set
            {
                if (_student != value)
                {
                    _student = value;
                    OnPropertyChanged("CurrentStudent");
                }
            }
        }
        private void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
