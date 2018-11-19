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
        [HttpPost]        
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
        [HttpGet]       
        public ICollection<TaskData> Get()
        {
            return TaskManagerBL.GetAllTasks();                       
        }

        /// <summary>
        /// To get the specific task
        /// </summary>
        /// <returns>Task Table Data</returns>   
        [HttpGet]        
        public TaskData Get(int id)
        {
            return TaskManagerBL.GetTask(id);
        }

        /// <summary>
        /// To edit the Task Details
        /// </summary>
        /// <returns>Success or Error Message</returns>   
        [System.Web.Http.HttpPut]
        [Route("EditTask/{id:int}")]
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
        [Route("DeleteTask/{id:int}")]
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
        [HttpPost]
        [Route("AddProject")]
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
        [Route("EditProject/{id:int}")]
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
        [Route("DeleteProject/{id:int}")]
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
        [HttpGet]
        [Route("GetAllProjects")]
        public ICollection<ProjectData> GetAllProjects()
        {
            return TaskManagerBL.GetAllProjects();
        }
        /// <summary>
        /// To Add Parent Task
        /// </summary>
        /// <returns>Success or Error Message</returns>    
        [HttpPost]
        [Route("AddParent")]
        public HttpResponseMessage AddParent([FromBody]ParentTaskData Parent)
        {
            try
            {
                TaskManagerBL.AddParent(Parent);
                return Request.CreateResponse(HttpStatusCode.OK, "Success");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// To Add Project
        /// </summary>
        /// <returns>Success or Error Message</returns>    
        [HttpPost]
        [Route("AddUser")]
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
        [Route("EditUser/{id:int}")]
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
        [Route("DeleteUser/{id:int}")]
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
        [HttpGet]
        [Route("GetAllUsers")]
        public ICollection<UserData> GetAllUsers()
        {
            return TaskManagerBL.GetAllUsers();
        }
        /// <summary>
        /// To return Specific Project table data
        /// </summary>
        /// <returns>Project Table Data</returns>        
        [Route("GetProject")]
        public ICollection<ProjectData> GetProject(string Project)
        {
            return TaskManagerBL.GetProject(Project);
        }
        /// <summary>
        /// To return Specific User table data
        /// </summary>
        /// <returns>User Table Data</returns>        
        [Route("GetUser")]
        public ICollection<UserData> GetUser(string EmployeeID)
        {
            return TaskManagerBL.GetUser(EmployeeID);
        }
        /// <summary>
        /// To return Specific Parent Task table data
        /// </summary>
        /// <returns>Parent Task Table Data</returns>        
        [Route("GetParentTasks")]
        public ICollection<ParentTaskData> GetParentTasks()
        {
            return TaskManagerBL.GetParentTask();
        }

    }
}
