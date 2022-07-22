using System.ComponentModel.DataAnnotations.Schema;

namespace EduFlow_Odev2.Data
{
    public class Employee
    {
        
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public int DeptId { get; set; }

    }
}
