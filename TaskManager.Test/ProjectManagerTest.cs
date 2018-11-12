using System;
using ProjectManager.EntityModel;
using System.Collections.Generic;
using ProjectManager.API;
using ProjectManager.API.Controllers;
using System.Net.Http;
using System.Web.Http;
using System.Linq;
using NUnit.Framework;

namespace ProjectManager.Test
{
    [TestFixture]
    public class ProjectManagerTest
    {

        [Test,Order(1)]
        public void AddTask()
        {

            TaskData lstTaskData = new TaskData()
            {
                TaskID = 1,
                ParentID = 1,
                ProjectID = 1,
                UserID = 1,
                Task = "First Task",
                ParentTask = "Parent Task 1",
                Priority = 1,
                EmployeeID = "369470",
                StartDate=DateTime.Now,
                EndDate=DateTime.Now.AddDays(10),
                Status="Active"
            };
            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            Assert.AreEqual("OK", controller.AddTask(lstTaskData).StatusCode.ToString());
        }

        [Test,Order(2)]
        public void GetAllTasks()
        {
            List<TaskData> lstTaskData = new List<TaskData>()
            {
                new TaskData()
                {
                    TaskID = 1,
                    ParentID = 1,
                    ProjectID = 1,
                    UserID = 1,
                    Task = "First Task",
                    ParentTask = "Parent Task 1",
                    Priority = 1,
                    EmployeeID = "369470",
                    StartDate=DateTime.Now,
                    EndDate=DateTime.Now.AddDays(10),
                    Status="Active"
                },                
            };

            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            List<TaskData> Respons =controller.Get().ToList();

            Assert.AreEqual(Respons.Count, lstTaskData.Count);
            if (Respons.Count == lstTaskData.Count)
            {
                Assert.AreEqual(Respons[0].TaskID, lstTaskData[0].TaskID);
                Assert.AreEqual(Respons[0].Task, lstTaskData[0].Task);
                Assert.AreEqual(Respons[0].ParentTask, lstTaskData[0].ParentTask);
                Assert.AreEqual(Respons[0].StartDate.Date, lstTaskData[0].StartDate.Date);
                Assert.AreEqual(Respons[0].EndDate.Date, lstTaskData[0].EndDate.Date);
            }
        }

        [Test,Order(3)]
        public void UpdateTask()
        {
            TaskData lstTaskData =            
                new TaskData
                {
                    TaskID = 1,
                    ParentID = 1,
                    ProjectID = 1,
                    UserID = 1,
                    Task = "First Task Updated",
                    ParentTask = "Parent Task Updated",
                    Priority = 1,
                    EmployeeID = "369470",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(10),
                    Status = "Active"
                };

            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            Assert.AreEqual("OK", controller.EditTask(lstTaskData.TaskID, lstTaskData).StatusCode.ToString());

        }
        [Test, Order(13)]
        public void DeleteTask()
        {
            int DeleteID = 1;
            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            Assert.AreEqual("OK", controller.DeleteTask(DeleteID).StatusCode.ToString());

        }

        [Test, Order(4)]
        public void AddProject()
        {
            ProjectData lstProjectData = new ProjectData()
            {
                ProjectID = 1,
                Project = "Test Project",
                ProjectStartDate = DateTime.Now,
                ProjectEndDate = DateTime.Now.AddDays(2),
                ProjectPriority = 10,
                ProjectManager = "Test Manager"
            };
            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            Assert.AreEqual("OK", controller.AddProject(lstProjectData).StatusCode.ToString());
        }
        [Test, Order(5)]
        public void GetAllProjects()
        {
            List<ProjectData> lstProjectData = new List<ProjectData>()
            {
                new ProjectData()
                {
                    ProjectID = 1,
                    Project = "Test Project",
                    ProjectStartDate = DateTime.Now,
                    ProjectEndDate = DateTime.Now.AddDays(2),
                    ProjectPriority = 10,
                    ProjectManager = "Test Manager"
                },
            };

            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            List<ProjectData> Respons = controller.GetAllProjects().ToList();

            Assert.AreEqual(Respons.Count, lstProjectData.Count);
            if (Respons.Count == lstProjectData.Count)
            {
                Assert.AreEqual(Respons[0].ProjectID, lstProjectData[0].ProjectID);
                Assert.AreEqual(Respons[0].Project, lstProjectData[0].Project);              
                Assert.AreEqual(Respons[0].ProjectPriority, lstProjectData[0].ProjectPriority);
                Assert.AreEqual(Respons[0].ProjectManager, lstProjectData[0].ProjectManager);
            }
        }
        [Test, Order(7)]
        public void EditProject()
        {
            ProjectData lstProjectData =new ProjectData
                {
                    ProjectID = 1,
                    Project = "First Project Updated",
                    ProjectStartDate = DateTime.Now,
                    ProjectEndDate = DateTime.Now.AddDays(2),
                    ProjectPriority = 5,
                    ProjectManager = "Test Manager Updated"
                };
            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            Assert.AreEqual("OK", controller.EditProject(lstProjectData.ProjectID, lstProjectData).StatusCode.ToString());
        }
        [Test, Order(6)]
        public void GetProject()
        {
            string Project = string.Empty;
            Project = "Proj";
            List<ProjectData> lstProjectData = new List<ProjectData>()
            {
                new ProjectData()
                {
                    ProjectID = 1,
                    Project = "Test Project",
                    ProjectStartDate = DateTime.Now,
                    ProjectEndDate = DateTime.Now.AddDays(2),
                    ProjectPriority = 10,
                    ProjectManager = "Test Manager"
                },
            };

            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            List<ProjectData> Respons = controller.GetProject(Project).ToList();

            Assert.AreEqual(Respons.Count, lstProjectData.Count);
            if (Respons.Count == lstProjectData.Count)
            {
                Assert.AreEqual(Respons[0].ProjectID, lstProjectData[0].ProjectID);
                Assert.AreEqual(Respons[0].Project, lstProjectData[0].Project);             
                Assert.AreEqual(Respons[0].ProjectPriority, lstProjectData[0].ProjectPriority);
                Assert.AreEqual(Respons[0].ProjectManager, lstProjectData[0].ProjectManager);
            }
        }
        [Test, Order(14)]
        public void DeleteProject()
        {
            int DeleteID = 1;
            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            Assert.AreEqual("OK", controller.DeleteProject(DeleteID).StatusCode.ToString());
        }
        [Test, Order(8)]
        public void AddUser()
        {
            UserData lstUserData = new UserData()
            {
                UserID=1,
                FirstName="User First",
                LastName="User Last",
                EmployeeID="369470",
                ProjectID=1,
                TaskID=1
            };
            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            Assert.AreEqual("OK", controller.AddUser(lstUserData).StatusCode.ToString());
        }
        [Test, Order(9)]
        public void GetAllUsers()
        {
            List<UserData> lstUserData = new List<UserData>()
            {
                new UserData
                {
                    UserID = 1,
                    FirstName = "User First",
                    LastName = "User Last",
                    EmployeeID = "369470",
                    ProjectID = 1,
                    TaskID = 1
                },
            };

            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            List<UserData> Respons = controller.GetAllUsers().ToList();

            Assert.AreEqual(Respons.Count, lstUserData.Count);
            if (Respons.Count == lstUserData.Count)
            {
                Assert.AreEqual(Respons[0].UserID, lstUserData[0].UserID);
                Assert.AreEqual(Respons[0].FirstName, lstUserData[0].FirstName);
                Assert.AreEqual(Respons[0].LastName, lstUserData[0].LastName);
                Assert.AreEqual(Respons[0].EmployeeID, lstUserData[0].EmployeeID);
                Assert.AreEqual(Respons[0].ProjectID, lstUserData[0].ProjectID);
                Assert.AreEqual(Respons[0].TaskID, lstUserData[0].TaskID);
            }
        }
        [Test, Order(10)]
        public void GetUser()
        {
            string Employee = string.Empty;
            Employee = "36";
            List<UserData> lstUserData = new List<UserData>()
            {
                new UserData
                {
                    UserID = 1,
                    FirstName = "User First",
                    LastName = "User Last",
                    EmployeeID = "369470",
                    ProjectID = 1,
                    TaskID = 1
                },
            };

            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            List<UserData> Respons = controller.GetUser(Employee).ToList();

            Assert.AreEqual(Respons.Count, lstUserData.Count);
            if (Respons.Count == lstUserData.Count)
            {
                Assert.AreEqual(Respons[0].UserID, lstUserData[0].UserID);
                Assert.AreEqual(Respons[0].FirstName, lstUserData[0].FirstName);
                Assert.AreEqual(Respons[0].LastName, lstUserData[0].LastName);
                Assert.AreEqual(Respons[0].EmployeeID, lstUserData[0].EmployeeID);
                Assert.AreEqual(Respons[0].ProjectID, lstUserData[0].ProjectID);
                Assert.AreEqual(Respons[0].TaskID, lstUserData[0].TaskID);
            }
        }
        [Test, Order(11)]
        public void EditUser()
        {
            UserData lstUserData = new UserData()
            {
                UserID = 1,
                FirstName = "User First Updated",
                LastName = "User Last Updated",
                EmployeeID = "369471",
                ProjectID = 1,
                TaskID = 1
            };
            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            Assert.AreEqual("OK", controller.EditUser(lstUserData.UserID, lstUserData).StatusCode.ToString());
        }
        [Test, Order(15)]
        public void DeleteUser()
        {
            int DeleteID = 1;
            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            Assert.AreEqual("OK", controller.DeleteUser(DeleteID).StatusCode.ToString());
        }
        [Test, Order(12)]
        public void GetParentTask()
        {
            string ParentTask = string.Empty;
            ParentTask = "Parent";
            List<ParentTaskData> lstParentTask = new List<ParentTaskData>()
            {
                new ParentTaskData
                {
                    ParentID=1,
                    ParentTask="Parent Task 1"
                },
            };
            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            List<ParentTaskData> Respons = controller.GetParentTasks(ParentTask).ToList();

            Assert.AreEqual(Respons.Count, lstParentTask.Count);
            if (Respons.Count == lstParentTask.Count)
            {
                Assert.AreEqual(Respons[0].ParentID, lstParentTask[0].ParentID);
                Assert.AreEqual(Respons[0].ParentTask, lstParentTask[0].ParentTask);
            }
        }


    }
}
