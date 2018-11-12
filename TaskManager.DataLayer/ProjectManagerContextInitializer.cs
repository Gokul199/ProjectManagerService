using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.EntityModel;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Data.Entity;


namespace ProjectManager.DataLayer
{
    class ProjectManagerContextInitializer:DropCreateDatabaseAlways<ProjectManagerContext>
    {
        public override void InitializeDatabase(ProjectManagerContext context)
        {
            base.InitializeDatabase(context);
        }
    }
}
