using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.DataLayer;
using ProjectManager.EntityModel;

namespace ProjectManager.BusinessLayer
{
    public class ProjectManagerBO
    {
        //Create a new instance of Task
        ProjectManagerDAL TaskManagerDL = new ProjectManagerDAL();
        public List<TaskData> GetAllTasks()
        {
            return TaskManagerDL.GetAllTasks();
        }

        public TaskData GetTask(int ID)
        {
            return TaskManagerDL.GetTask(ID);
        }
        public void AddTask(TaskData Task)
        {
            TaskManagerDL.AddTask(Task);
        }
        public void DeleteTask(int TaskID)
        {
            TaskManagerDL.DeleteTask(TaskID);
        }
        public void EditTask(int ID,TaskData Task)
        {
            TaskManagerDL.UpdateTask(ID,Task);
        }
        public void AddProject(ProjectData Project)
        {
            TaskManagerDL.AddProject(Project);
        }
        public void EditProject(int ID,ProjectData Project)
        {
            TaskManagerDL.EditProject(ID, Project);
        }
        public List<ProjectData> GetAllProjects()
        {
            return TaskManagerDL.GetAllProjects();
        }
        public void DeleteProject(int ID)
        {
            TaskManagerDL.DeleteProject(ID);
        }
        public void AddUser(UserData User)
        {
            TaskManagerDL.AddUser(User);
        }
        public void EditUser(int ID,UserData User)
        {
            TaskManagerDL.EditUser(ID, User);
        }
        public List<UserData> GetAllUsers()
        {
            return TaskManagerDL.GetAllUsers();
        }
        public void DeleteUser(int ID)
        {
            TaskManagerDL.DeleteUser(ID);
        }
        public List<ProjectData> GetProject(string Project)
        {
            return TaskManagerDL.GetProject(Project);
        }
        public List<UserData> GetUser(string EmployeeID)
        {
            return TaskManagerDL.GetUser(EmployeeID);
        }
        public List<ParentTaskData> GetParentTask(string Task)
        {
            return TaskManagerDL.GetParentTask(Task);
        }
    }
}
