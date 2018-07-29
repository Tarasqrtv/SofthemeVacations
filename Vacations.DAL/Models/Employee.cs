using System;
using System.Collections.Generic;

namespace Vacations.DAL.Models
{
    public partial class Employee
    {
        public Employee()
        {
            TeamNavigation = new HashSet<Team>();
            Transaction = new HashSet<Transaction>();
            Vacation = new HashSet<Vacation>();
        }

        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthday { get; set; }
        public string WorkEmail { get; set; }
        public string PersonalEmail { get; set; }
        public string TelephoneNumber { get; set; }
        public string Skype { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Guid? EmployeeStatusId { get; set; }
        public Guid? JobTitleId { get; set; }
        public Guid? TeamId { get; set; }
        public int? Balance { get; set; }

        public EmployeeStatus EmployeeStatus { get; set; }
        public JobTitle JobTitle { get; set; }
        public Team Team { get; set; }
        public User User { get; set; }
        public ICollection<Team> TeamNavigation { get; set; }
        public ICollection<Transaction> Transaction { get; set; }
        public ICollection<Vacation> Vacation { get; set; }
    }
}
