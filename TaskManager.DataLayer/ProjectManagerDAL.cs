using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManager.EntityModel;


namespace ProjectManager.DataLayer
{
    public class ProjectManagerDAL
    {        
        public void AddTask(TaskData Task)            
        {
            int ParentID = 0;
            using (var ct = new ProjectManagerContext())
            {                     
                ParentID = Convert.ToInt32((from r in ct.ParentTaskData where r.ParentTask == Task.ParentTask select ParentID).FirstOrDefault());
                if (ParentID == 0)
                {
                    ParentTaskData parent = new ParentTaskData();
                    parent.ParentTask = Task.ParentTask;
                    ct.ParentTaskData.Add(parent);
                    ct.SaveChanges();
                }
                Task.ParentID = ParentID;
                ct.TaskData.Add(Task);
                ct.SaveChanges();
            }
        }
        public void UpdateTask(int ID,TaskData Task)
        {
            int ParentID = 0;
            using (var ct = new ProjectManagerContext())
            {                
                var UpdTask = ct.TaskData.Where(a => a.TaskID == ID).FirstOrDefault();
                UpdTask.Task = Task.Task;
                UpdTask.ParentID = ParentID;
                UpdTask.ParentTask = Task.ParentTask;
                UpdTask.Priority = Task.Priority;
                UpdTask.StartDate = Task.StartDate;
                UpdTask.EndDate = Task.EndDate;                
                ct.SaveChanges();
            }
        }
        public List<TaskData> GetAllTasks()
        {
            List<TaskData> TaskDetails = new List<TaskData>();
            using (var ct = new ProjectManagerContext())
            {
                TaskDetails = (from r in ct.TaskData where r.Status!="Completed" select r).ToList<TaskData>();
            }
            return TaskDetails;
        }

        public TaskData GetTask(int ID)
        {
            TaskData TaskDetail = new TaskData();
            using (var ct = new ProjectManagerContext())
            {
                TaskDetail = ct.TaskData.Where(a => a.TaskID == ID).FirstOrDefault();
            }
            return TaskDetail;
        }
        public void DeleteTask(int ID)
        {
            using (var ct = new ProjectManagerContext())
            {
                //List<TaskData> DelTask = new List<TaskData>();
                //var DelTask = (from r in ct.TaskData select r).ToList<TaskData>();
                var DelTask = ct.TaskData.Where(a => a.TaskID == ID).FirstOrDefault();
                //if (DelTask != null && DelTask.Count != 0)
                //{
                DelTask.Status = "Completed";
                ct.SaveChanges();
                //}
            }
        }
        
        public void AddProject(ProjectData Project)
        {
            using (var ct = new ProjectManagerContext())
            {
                ct.ProjectData.Add(Project);
                ct.SaveChanges();
            }
        }
        public void EditProject(int ID,ProjectData Project)
        {
            using (var ct = new ProjectManagerContext())
            {
                var UpdProject = ct.ProjectData.Where(a => a.ProjectID == ID).FirstOrDefault();
                UpdProject.Project = Project.Project;
                UpdProject.ProjectStartDate = Project.ProjectStartDate;
                UpdProject.ProjectEndDate = Project.ProjectEndDate;
                UpdProject.ProjectPriority = Project.ProjectPriority;
                UpdProject.ProjectManager = Project.ProjectManager;
                ct.SaveChanges();
            }
        }
        public List<ProjectData> GetAllProjects()
        {
            List<ProjectData> ProjectDetails = new List<ProjectData>();
            using (var ct = new ProjectManagerContext())
            {
                ProjectDetails = (from r in ct.ProjectData select r).ToList<ProjectData>();
            }
            return ProjectDetails;            
        }
        public void DeleteProject(int ID)
        {
            using (var ct = new ProjectManagerContext())
            {
                List<ProjectData> DelProject = new List<ProjectData>();
                DelProject = (from r in ct.ProjectData select r).ToList<ProjectData>();
                if (DelProject != null && DelProject.Count != 0)
                {
                    ct.ProjectData.Remove(DelProject[0]);
                    ct.SaveChanges();
                }
            }
        }
        
        public void AddUser(UserData User)
        {
            using (var ct = new ProjectManagerContext())
            {
                ct.UserData.Add(User);
                ct.SaveChanges();
            }
        }
        public void EditUser(int ID,UserData User)
        {
            using (var ct = new ProjectManagerContext())
            {
                var Upduser= ct.UserData.Where(a => a.ProjectID == ID).FirstOrDefault();
                Upduser.FirstName = User.FirstName;
                Upduser.LastName = User.LastName;
                Upduser.EmployeeID = User.EmployeeID;
                ct.SaveChanges();
            }
        }

        public void DeleteUser(int ID)
        {
            using (var ct = new ProjectManagerContext())
            {
                List<UserData> DelUser = new List<UserData>();
                DelUser = (from r in ct.UserData select r).ToList<UserData>();
                if (DelUser != null && DelUser.Count != 0)
                {
                    ct.UserData.Remove(DelUser[0]);
                    ct.SaveChanges();
                }
            }
        }
        public List<UserData> GetAllUsers()
        {
            List<UserData> UserDetails = new List<UserData>();
            using (var ct = new ProjectManagerContext())
            {
                UserDetails = (from r in ct.UserData select r).ToList<UserData>();
            }
            return UserDetails;
        }
        public List<ProjectData> GetProject(string Project)
        {
            List<ProjectData> Projectmatch =new List<ProjectData>();
            using (var ct = new ProjectManagerContext())
            {
                Projectmatch = ct.ProjectData.Where(a => a.Project.Contains(Project)).ToList<ProjectData>();
            }
            return Projectmatch;
        }
        public List<UserData> GetUser(string Employee)
        {
            List<UserData> UserMatch=new List<UserData>();
            using (var ct = new ProjectManagerContext())
            {
                UserMatch = ct.UserData.Where(a => a.EmployeeID.Contains(Employee.ToString())).ToList<UserData>();
            }
            return UserMatch;
        }
        public List<ParentTaskData> GetParentTask(string Task)
        {
            List<ParentTaskData> TaskMatch = new List<ParentTaskData>();
            using (var ct = new ProjectManagerContext())
            {
                TaskMatch = ct.ParentTaskData.Where(a => a.ParentTask.Contains(Task)).ToList<ParentTaskData>();
            }
            return TaskMatch;
        }
    }
}
