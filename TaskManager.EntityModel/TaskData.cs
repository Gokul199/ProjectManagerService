using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.EntityModel
{
    [Table("TaskData")]
    public class TaskData
    {           
        [DatabaseGenerated(DatabaseGeneratedOption.Identity),Key()]
        public int TaskID { get; set; }          
        public int ParentID { get; set; }       
        public int ProjectID { get; set; }        
        public int UserID { get; set; }
        public string Task { get; set; }
        public string ParentTask { get; set; }
        public string EmployeeID { get; set; }
        public int Priority { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Status { get; set; }


    }
}
