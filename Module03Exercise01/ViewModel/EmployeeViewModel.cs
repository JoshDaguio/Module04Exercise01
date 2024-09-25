using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Module03Exercise01.Model;

namespace Module03Exercise01.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private Employee _manager;

        private string _fullName;
        private string _position;
        private string _dept;
        public EmployeeViewModel()
        {
            _manager = new Employee { FirstName = "Bruce", LastName = "Wayne", Position = "Manager", Department = "IT", IsActive = true };

            LoadEmployeeDataCommand = new Command(async () => await LoadEmployeeDataAsync());

            Employees = new ObservableCollection<Employee>
            {
                new Employee {FirstName = "Clark", LastName = "Kent", Position="Employee", Department="IT", IsActive=true},
                new Employee {FirstName = "Hal", LastName = "Jordan", Position="Pilot", Department="IT", IsActive=true},
                new Employee {FirstName = "Barry", LastName = "Allen", Position="Forensics", Department="IT", IsActive=true},
            };

        }

        public ObservableCollection<Employee> Employees { get; set; }

        public string FullName
        {
            get => _fullName;
            set
            {
                if (_fullName != value)
                {
                    _fullName = value;
                    OnPropertyChange(nameof(FullName));
                }
            }
        }
        public string ManagerPosition
        {
            get => _position;
            set
            {
                if (_position != value)
                {
                    _position = value;
                    OnPropertyChange(nameof(ManagerPosition));
                }
            }
        }

        public ICommand LoadEmployeeDataCommand { get; }

        private async Task LoadEmployeeDataAsync()
        {
            await Task.Delay(500);
            FullName = $"{_manager.FirstName} {_manager.LastName}";
            ManagerPosition = $"{_manager.Department} {_manager.Position}";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChange(string propertyName)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
