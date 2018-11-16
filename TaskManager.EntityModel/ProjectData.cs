using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectManager.EntityModel
{
    [Table("ProjectData")]
    public class ProjectData
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int ProjectID { get; set; }
        public string Project { get; set; }        
        public DateTime ProjectStartDate { get; set; }
        public DateTime ProjectEndDate { get; set;}
        public int ProjectPriority { get; set; }
        public string ProjectManager { get; set; }
        public int NumberOfTasks { get; set;}
        public string Completed { get; set; }

    }
}
