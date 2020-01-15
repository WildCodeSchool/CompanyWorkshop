using System;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            Appointment appointment = new Appointment();

            for (int i = 0; i < 5; i++)
            {
                Employee employee = new Employee();
                employee.SetName("John Doe");
                employee.SetAnnualSalary(35000);
                company.HireEmployees(employee);
            }

            company.FireEmployees("John Doe");
        }
    }

    class Company
    {
        private string _name;
        private Employee[] _employees = new Employee[256];

        private int _employeesCount = 0;

        public void HireEmployees(params Employee[] employees)
        {
            foreach (Employee hiredEmployee in employees)
            {
                _employees[_employeesCount] = hiredEmployee;
                _employeesCount = _employeesCount + 1;
            }
        }

        public void FireEmployees(params string[] employeesNames)
        {
            foreach (string name in employeesNames)
            { 
                for (int i=0; i < _employeesCount; i++)
                {
                    Employee currentEmployee = _employees[i];
                    if (currentEmployee != null && currentEmployee.GetName() == name)
                    {
                        _employees[i] = null;
                     
                        for (int j = i + 1; j < _employees.Length - 1; j++)
                        {
                            _employees[j - 1] = _employees[j];
                        }
                    }
                }
            }
        }

        public void ModifySalary(string name, double newAnnualSalary)
        {
            Employee hiredEmployee = GetEmployeeByName(name);
            hiredEmployee.SetAnnualSalary(newAnnualSalary);
        }

        public Employee GetEmployeeByName(string name)
        {
            foreach (Employee hiredEmployee in _employees)
            {
                if (hiredEmployee.GetName() == name)
                {
                    return hiredEmployee;
                }
            }
            return null;
        }

        public Employee[] GetEmployees()
        {
            return _employees;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }
    }

    class Appointment
    {
        private DateTime _dateTime;
        private Employee[] _employees = new Employee[32];
        private int _employeesCount = 0;
        private bool _isHappening;

        public void AddEmployee(Employee employee)
        {
            _employees[_employeesCount] = employee;
            _employeesCount = _employeesCount + 1;
        }

        public void Cancel()
        {
            _isHappening = false;
        }

        public void Accept()
        {
            _isHappening = true;
        }

        public DateTime GetDateTime()
        {
            return _dateTime;
        }

        public void SetDateTime(DateTime dateTime)
        {
            _dateTime = dateTime;
        }

        public bool IsHappening()
        {
            return _isHappening;
        }

        public Employee[] GetEmployees()
        {
            return _employees;
        }
    }

    class Employee
    {
        private string _name;
        private double _annualSalary;

        public void TalkToEmployee(Employee employee)
        {
            Console.WriteLine(_name + " is talking to " + employee.GetName());
        }

        public void YellAtEmployee(Employee employee)
        {
            Console.WriteLine((_name + " is yelling at " + employee.GetName()).ToUpper());
        }

        public double GetMensualSalary()
        {
            return _annualSalary / 12;
        }
        public void SetMensualSalary(double mensualSalary)
        {
            _annualSalary = mensualSalary * 12;
        }

        public double GetAnnualSalary()
        {
            return _annualSalary;
        }

        public void SetAnnualSalary(double annualSalary)
        {
            _annualSalary = annualSalary;
        }

        public string GetName()
        {
            return _name;
        }

        public void SetName(string name)
        {
            _name = name;
        }
    }
}
