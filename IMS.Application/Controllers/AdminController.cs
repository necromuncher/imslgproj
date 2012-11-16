using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMS.Core.Model;
using IMS.Core.Services;
using IMS.Application.Models;

namespace IMS.Application.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private CommonPropModel commonproperty = new CommonPropModel();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllAgent()
        {
            AgentPageModel agentpagemodel = new AgentPageModel();
            agentpagemodel.AllAgents = IMSService.Instance.GetAllAgents();
            commonproperty.pageTitle = "Agents";
            agentpagemodel.commonproperty = commonproperty;
            return View(agentpagemodel);
        }

        public ActionResult GetAllModules()
        {
            ModulePageModel modulepagemodel = new ModulePageModel();
            modulepagemodel.AllModules = IMSService.Instance.GetAllModules();
            commonproperty.pageTitle = "Modules";
            modulepagemodel.commonproperty = commonproperty;
            return View(modulepagemodel);
        }

        public ActionResult GetAllUsers()
        {
            UserPageModel userpagemodel = new UserPageModel();
            userpagemodel.AllUsers = IMSService.Instance.GetAllAppUsers();
            commonproperty.pageTitle = "Users";
            userpagemodel.commonproperty = commonproperty;
            return View(userpagemodel);
        }

        public ActionResult GetAllUserModules(Guid userid)
        {
            UserModulePageModel usermodulepagemodel = new UserModulePageModel();
            ICollection<AppUsersModules> userModules = IMSService.Instance.GetAllAppUsersModules(userid);
            usermodulepagemodel.CurrentAppUsers = IMSService.Instance.GetAppUserByID(userid);
            userModules.OfType<AppUsersModules>()
                .ToList()
                .ForEach(aa =>
                {
                    AppUserPageModule usermodpagemodel = new AppUserPageModule();
                    usermodpagemodel.AllowToAdd = aa.AllowToAdd;
                    usermodpagemodel.AllowToEdit = aa.AllowToEdit;
                    usermodpagemodel.AllowToDelete = aa.AllowToDelete;
                    usermodpagemodel.AllowToPost = aa.AllowToPost;
                    usermodpagemodel.AllowToVoid = aa.AllowToVoid;
                    usermodpagemodel.FK_AppUsers = usermodulepagemodel.CurrentAppUsers.PK_appUsers;
                    usermodpagemodel.FK_MstrModules = aa.FK_MstrModules;
                    usermodpagemodel.ModuleName = IMSService.Instance.GetModuleByID(aa.FK_MstrModules).Name;
                    usermodpagemodel.PK_AppUsersModules = aa.PK_AppUsersModules;
                });

            return View(usermodulepagemodel);
        }

        [HttpPost]
        public ActionResult CreateUser(UserPageModel userpagemodel)
        {
            if (ModelState.IsValid)
            {
                IMSService.Instance.SaveAppUser(new AppUsers()
                {
                    UserCode = userpagemodel.CurrentUser.UserCode,
                    UserName = userpagemodel.CurrentUser.UserName,
                    UserPassword = userpagemodel.CurrentUser.UserPassword,
                    IsAdmin = false,
                    IsActive = true
                });

                if (Request.IsAjaxRequest())
                    return ModelState.IsValid ? Json(new { status = "Success", message = "User is successfully saved." }) : Json(new { status = "error", message = "Could not connect to mail server." });

                return ModelState.IsValid ? Success(userpagemodel) : View(userpagemodel);
            }
            else
            {
                if (Request.IsAjaxRequest())
                    return Json(new { status = "error", message = "All fields are required." });

                return View(userpagemodel);
            }
        }

        [HttpPost]
        public ActionResult CreateAgent(AgentPageModel agentpagemodel)
        {
            if (ModelState.IsValid)
            {
                IMSService.Instance.SaveAgent(new MstrAgency()
                {
                    Name = agentpagemodel.CurrentAgent.Name,
                    Address = agentpagemodel.CurrentAgent.Address,
                    IsActive = agentpagemodel.CurrentAgent.IsActive,
                    PK_MstrAgency = Guid.NewGuid()
                });

                if (Request.IsAjaxRequest())
                    return ModelState.IsValid ? Json(new { status = "Success", message = "Agent is successfully saved." }) : Json(new { status = "error", message = "Could not connect to mail server." });

                return ModelState.IsValid ? Success(agentpagemodel) : View(agentpagemodel);
            }
            else
            {
                if (Request.IsAjaxRequest())
                    return Json(new { status = "error", message = "All fields are required." });

                return View(agentpagemodel);
            }
        }

        [HttpPost]
        public ActionResult DeleteAgent(AgentPageModel agentmodel)
        {
            IMSService.Instance.DeleteAgentByID(agentmodel.CurrentAgent.PK_MstrAgency);
            return RedirectToAction("GetAllAgent", "Admin");
        }

        [HttpPost]
        public ActionResult EditAgent(AgentPageModel agentpagemodel)
        {
            if (ModelState.IsValid)
            {
                IMSService.Instance.SaveAgent(new MstrAgency()
                {
                    Name = agentpagemodel.CurrentAgent.Name,
                    Address = agentpagemodel.CurrentAgent.Address,
                    IsActive = agentpagemodel.CurrentAgent.IsActive,
                    PK_MstrAgency = agentpagemodel.CurrentAgent.PK_MstrAgency
                });

                if (Request.IsAjaxRequest())
                    return ModelState.IsValid ? Json(new { status = "Success", message = "Agent is successfully updated." }) : Json(new { status = "error", message = "Could not connect to mail server." });

                return ModelState.IsValid ? Success(agentpagemodel) : View(agentpagemodel);
            }
            else
            {
                if (Request.IsAjaxRequest())
                    return Json(new { status = "error", message = "All fields are required." });

                return View(agentpagemodel);
            }
        }

        /// <summary>
        /// Success method
        /// </summary>
        /// <typeparam name="TModel">request model</typeparam>
        /// <param name="viewModel">view model</param>
        /// <returns>View Resut if success of not</returns>
        protected ViewResult Success<TModel>(TModel viewModel)
        {
            Success();
            return View(viewModel);
        }

        /// <summary>
        /// Initializing Success method 
        /// </summary>
        protected void Success()
        {
            ViewData["success"] = "";
        }
    }
}
