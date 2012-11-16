using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMS.Core.Model;
using IMS.Core.Services;
using IMS.Application.Models;
using System.IO;

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

        [HttpGet]
        public ActionResult GetAllDealer()
        {
            DealerPageModel dealerpagemodel = new DealerPageModel();
            dealerpagemodel.AllMstrDealers = IMSService.Instance.GetAllDealer();
            commonproperty.pageTitle = "Dealers";
            dealerpagemodel.commonproperty = commonproperty;
            return View(dealerpagemodel);
        }

        [HttpGet]
        public ActionResult GetAllBranches()
        {
            BranchesPageModel branchespagemodel = new BranchesPageModel();
            branchespagemodel.AllBranches = IMSService.Instance.GetAllBranches();
            commonproperty.pageTitle = "Branches";
            branchespagemodel.commonproperty = commonproperty;
            return View(branchespagemodel);
        }

        public ActionResult GetAllModule()
        {
            ModulePageModel modulepagemodel = new ModulePageModel();
            modulepagemodel.AllModules = IMSService.Instance.GetAllModules();
            commonproperty.pageTitle = "Modules";
            modulepagemodel.commonproperty = commonproperty;
            return View(modulepagemodel);
        }

        public ActionResult GetAllUser()
        {
            UserPageModel userpagemodel = new UserPageModel();
            userpagemodel.AllUsers = IMSService.Instance.GetAllAppUsers();
            commonproperty.pageTitle = "Users";
            userpagemodel.commonproperty = commonproperty;
            return View(userpagemodel);
        }

        public ActionResult GetAllFPS()
        {
            FPSPageModel fpspagemodel = new FPSPageModel();
            fpspagemodel.AllFPS = IMSService.Instance.GetAllFPS();
            commonproperty.pageTitle = "FPS";
            fpspagemodel.commonproperty = commonproperty;
            return View(fpspagemodel);
        }

        public ActionResult GetAllItem()
        {
            ItemPageModel itempagemodel = new ItemPageModel();
            itempagemodel.AllItems = IMSService.Instance.GetAllItems();
            commonproperty.pageTitle = "Items";
            itempagemodel.commonproperty = commonproperty;
            return View(itempagemodel);
        }

        public ActionResult GetAllUserModule(Guid userid)
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
            if (ModelState.IsValid)
            {
                IMSService.Instance.DeleteAgentByID(new Guid(agentmodel.PkeyForView));

                if (Request.IsAjaxRequest())
                    return ModelState.IsValid ? Json(new { status = "Success", message = "Agent is successfully deleted." }) : Json(new { status = "error", message = "Could not connect to mail server." });

                return ModelState.IsValid ? Success(agentmodel) : View(agentmodel);
            }
            else
            {
                if (Request.IsAjaxRequest())
                    return Json(new { status = "error", message = "All fields are required." });

                return View(agentmodel);
            }
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
                    PK_MstrAgency = new Guid(agentpagemodel.PkeyForView)
                });

                if (Request.IsAjaxRequest())
                    return ModelState.IsValid ? Json(new { status = "Success", message = "Agent is successfully updated." }) : Json(new { status = "error", message = "Could not connect to mail server." }, JsonRequestBehavior.AllowGet);

                return ModelState.IsValid ? Success(agentpagemodel) : View(agentpagemodel);
            }
            else
            {
                if (Request.IsAjaxRequest())
                    return Json(new { status = "error", message = "All fields are required." });

                return View(agentpagemodel);
            }
        }

        public ActionResult MasterFile()
        {
            return View();
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

        public ActionResult FileUpload()
        {
            return View();
        }

        private string StorageRoot
        {
            get { return Path.Combine(Server.MapPath("~/Files")); }
        }

        //DONT USE THIS IF YOU NEED TO ALLOW LARGE FILES UPLOADS
        [HttpGet]
        public void Delete(string id)
        {
            var filename = id;
            var filePath = Path.Combine(Server.MapPath("~/Files"), filename);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }
        }

        //DONT USE THIS IF YOU NEED TO ALLOW LARGE FILES UPLOADS
        [HttpGet]
        public void Download(string id)
        {
            var filename = id;
            var filePath = Path.Combine(Server.MapPath("~/Files"), filename);

            var context = HttpContext;

            if (System.IO.File.Exists(filePath))
            {
                context.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + filename + "\"");
                context.Response.ContentType = "application/octet-stream";
                context.Response.ClearContent();
                context.Response.WriteFile(filePath);
            }
            else
                context.Response.StatusCode = 404;
        }

        //DONT USE THIS IF YOU NEED TO ALLOW LARGE FILES UPLOADS
        [HttpPost]
        public ActionResult UploadFiles()
        {
            var r = new List<ViewDataUploadFilesResult>();

            foreach (string file in Request.Files)
            {
                var statuses = new List<ViewDataUploadFilesResult>();
                var headers = Request.Headers;

                if (string.IsNullOrEmpty(headers["X-File-Name"]))
                {
                    UploadWholeFile(Request, statuses);
                }
                else
                {
                    UploadPartialFile(headers["X-File-Name"], Request, statuses);
                }

                JsonResult result = Json(statuses);
                result.ContentType = "text/plain";

                return result;
            }

            return Json(r);
        }

        private string EncodeFile(string fileName)
        {
            return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName));
        }

        //DONT USE THIS IF YOU NEED TO ALLOW LARGE FILES UPLOADS
        //Credit to i-e-b and his ASP.Net uploader for the bulk of the upload helper methods - https://github.com/i-e-b/jQueryFileUpload.Net
        private void UploadPartialFile(string fileName, HttpRequestBase request, List<ViewDataUploadFilesResult> statuses)
        {
            if (request.Files.Count != 1) throw new HttpRequestValidationException("Attempt to upload chunked file containing more than one fragment per request");
            var file = request.Files[0];
            var inputStream = file.InputStream;

            var fullName = Path.Combine(StorageRoot, Path.GetFileName(fileName));

            using (var fs = new FileStream(fullName, FileMode.Append, FileAccess.Write))
            {
                var buffer = new byte[1024];

                var l = inputStream.Read(buffer, 0, 1024);
                while (l > 0)
                {
                    fs.Write(buffer, 0, l);
                    l = inputStream.Read(buffer, 0, 1024);
                }
                fs.Flush();
                fs.Close();
            }
            statuses.Add(new ViewDataUploadFilesResult()
            {
                name = fileName,
                size = file.ContentLength,
                type = file.ContentType,
                url = "/Home/Download/" + fileName,
                delete_url = "/Home/Delete/" + fileName,
                thumbnail_url = @"data:image/png;base64," + EncodeFile(fullName),
                delete_type = "GET",
            });
        }

        //DONT USE THIS IF YOU NEED TO ALLOW LARGE FILES UPLOADS
        //Credit to i-e-b and his ASP.Net uploader for the bulk of the upload helper methods - https://github.com/i-e-b/jQueryFileUpload.Net
        private void UploadWholeFile(HttpRequestBase request, List<ViewDataUploadFilesResult> statuses)
        {
            for (int i = 0; i < request.Files.Count; i++)
            {
                var file = request.Files[i];

                var fullPath = Path.Combine(StorageRoot, Path.GetFileName(file.FileName));

                file.SaveAs(fullPath);

                statuses.Add(new ViewDataUploadFilesResult()
                {
                    name = file.FileName,
                    size = file.ContentLength,
                    type = file.ContentType,
                    url = "/Home/Download/" + file.FileName,
                    delete_url = "/Home/Delete/" + file.FileName,
                    thumbnail_url = @"data:image/png;base64," + EncodeFile(fullPath),
                    delete_type = "GET",
                });
            }
        }

    }

    public class ViewDataUploadFilesResult
    {
        public string name { get; set; }
        public int size { get; set; }
        public string type { get; set; }
        public string url { get; set; }
        public string delete_url { get; set; }
        public string thumbnail_url { get; set; }
        public string delete_type { get; set; }
    }
}
