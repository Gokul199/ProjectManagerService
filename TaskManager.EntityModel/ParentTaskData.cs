using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.EntityModel
{    
    [Table("ParentTaskData")]
   public class ParentTaskData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int ParentID { get; set; }
        public string ParentTask { get; set; }
    }
}
