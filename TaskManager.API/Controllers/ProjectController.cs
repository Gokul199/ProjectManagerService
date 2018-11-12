using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProjectManager.BusinessLayer;
using ProjectManager.EntityModel;

namespace ProjectManager.API.Controllers
{   
    public class ProjectController : ApiController
    {
        ProjectManagerBO TaskManagerBL = new ProjectManagerBO();
        /// <summary>
        /// To Add a new task
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>        
        public HttpResponseMessage AddTask([FromBody]TaskData task)
        {
            try
            {
                TaskManagerBL.AddTask(task);
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch(Exception ex) 
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }            
        }

        /// <summary>
        /// To return task table data
        /// </summary>
        /// <returns>Task Table Data</returns>        
        public ICollection<TaskData> Get()
        {
            return TaskManagerBL.GetAllTasks();                       
        }

        /// <summary>
        /// To get the specific task
        /// </summary>
        /// <returns>Task Table Data</returns>   
        public TaskData Get(int id)
        {
            return TaskManagerBL.GetTask(id);
        }

        /// <summary>
        /// To edit the Task Details
        /// </summary>
        /// <returns>Success or Error Message</returns>   
        [System.Web.Http.HttpPut]
        public HttpResponseMessage EditTask(int id,[FromBody]TaskData task)
        {
            try
            {
                TaskManagerBL.EditTask(id,task);
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex);
            }
        }
        /// <summary>
        /// To delete specific task data
        /// </summary>
        /// <returns>Success or Error Message</returns>   
        [HttpDelete]
        public HttpResponseMessage DeleteTask(int id)
        {
            try
            {
                TaskManagerBL.DeleteTask(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,ex);
            }
        }
        /// <summary>
        /// To Add Project
        /// </summary>
        /// <returns>Success or Error Message</returns>    
        public HttpResponseMessage AddProject([FromBody]ProjectData Project)
        {
            try
            {
                TaskManagerBL.AddProject(Project);
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        /// <summary>
        /// To edit the Project Details
        /// </summary>
        /// <returns>Success or Error Message</returns>   
        [System.Web.Http.HttpPut]
        public HttpResponseMessage EditProject(int id, [FromBody]ProjectData Project)
        {
            try
            {
                TaskManagerBL.EditProject(id, Project);
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        /// <summary>
        /// To delete specific task data
        /// </summary>
        /// <returns>Success or Error Message</returns>   
        [HttpDelete]
        public HttpResponseMessage DeleteProject(int id)
        {
            try
            {
                TaskManagerBL.DeleteProject(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        /// <summary>
        /// To return Project table data
        /// </summary>
        /// <returns>Project Table Data</returns>        
        public ICollection<ProjectData> GetAllProjects()
        {
            return TaskManagerBL.GetAllProjects();
        }
        
        /// <summary>
        /// To Add Project
        /// </summary>
        /// <returns>Success or Error Message</returns>    
        public HttpResponseMessage AddUser([FromBody]UserData User)
        {
            try
            {
                TaskManagerBL.AddUser(User);
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        /// <summary>
        /// To edit the User Details
        /// </summary>
        /// <returns>Success or Error Message</returns>   
        [System.Web.Http.HttpPut]
        public HttpResponseMessage EditUser(int id, [FromBody]UserData User)
        {
            try
            {
                TaskManagerBL.EditUser(id, User);
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        /// <summary>
        /// To delete specific User data
        /// </summary>
        /// <returns>Success or Error Message</returns>   
        [HttpDelete]
        public HttpResponseMessage DeleteUser(int id)
        {
            try
            {
                TaskManagerBL.DeleteUser(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
        /// <summary>
        /// To return User table data
        /// </summary>
        /// <returns>User Table Data</returns>        
        public ICollection<UserData> GetAllUsers()
        {
            return TaskManagerBL.GetAllUsers();
        }
        /// <summary>
        /// To return Specific Project table data
        /// </summary>
        /// <returns>Project Table Data</returns>        
        public ICollection<ProjectData> GetProject(string Project)
        {
            return TaskManagerBL.GetProject(Project);
        }
        /// <summary>
        /// To return Specific User table data
        /// </summary>
        /// <returns>User Table Data</returns>        
        public ICollection<UserData> GetUser(string EmployeeID)
        {
            return TaskManagerBL.GetUser(EmployeeID);
        }
        /// <summary>
        /// To return Specific Parent Task table data
        /// </summary>
        /// <returns>Parent Task Table Data</returns>        
        public ICollection<ParentTaskData> GetParentTasks(string Task)
        {
            return TaskManagerBL.GetParentTask(Task);
        }

    }
}
