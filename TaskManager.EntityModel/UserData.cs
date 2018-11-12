using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.EntityModel
{
    [Table("UserData")]
    public class UserData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeID { get; set; }
        public int ProjectID { get; set; }
        public int TaskID { get; set; }
    }
}
