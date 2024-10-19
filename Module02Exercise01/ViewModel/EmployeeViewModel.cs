using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Module02Exercise01.Model;

namespace Module02Exercise01.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private Employee _employee;
        private string _fullName;
        private string _managerName;
        private string _managerDepartment;

        public EmployeeViewModel()
        {
           
            _employee = new Employee
            {
                FirstName = "Fernand",
                LastName = "Layug",
                Position = "Manager",
                Department = "Sales",
                IsActive = true
            };

            LoadEmployeeDataCommand = new Command(async () => await LoadEmployeeDataAsync());

            Employees = new ObservableCollection<Employee>
            {
                new Employee {FirstName="Norman", LastName="Magcalas", Position="Back End Developer", Department="IT", IsActive=true},
                new Employee {FirstName="Ingram", LastName="Manuel", Position="Front End Developer", Department="IT", IsActive=false},
                new Employee {FirstName="Calvin Kent", LastName="Pamandanan", Position="UI/UX Designer", Department="Marketing", IsActive=true}
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
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public string ManagerName
        {
            get => _managerName;
            set
            {
                if (_managerName != value)
                {
                    _managerName = value;
                    OnPropertyChanged(nameof(ManagerName));
                }
            }
        }

        public string ManagerDepartment
        {
            get => _managerDepartment;
            set
            {
                if (_managerDepartment != value)
                {
                    _managerDepartment = value;
                    OnPropertyChanged(nameof(ManagerDepartment));
                }
            }
        }

        public ICommand LoadEmployeeDataCommand { get; }

        private async Task LoadEmployeeDataAsync()
        {
            await Task.Delay(1000);
            FullName = $"{_employee.FirstName} {_employee.LastName}";
            ManagerName = _employee.FullName;
            ManagerDepartment = _employee.Department; 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}