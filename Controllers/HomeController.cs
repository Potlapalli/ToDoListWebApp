using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ToDoListWebApp.Models;

namespace TodoListGrid.Controllers
{
    public class HomeController : Controller
    {
        private readonly ToDoListDBEntities _entities;
        public HomeController()
        {
            _entities = new ToDoListDBEntities();
        }


        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }
        public ActionResult ReadItems([DataSourceRequest] DataSourceRequest request)
        {
            var data = _entities.ReadItems().ToList();
            var itemcollection = new List<ItemModel>();
            foreach (var item in data)
            {
                if (item.Status != "Completed")
                {
                    var model = new ItemModel()
                    {
                        Id = (int) item.Id,
                        Name = item.Name,
                        Priority = item.Priority,
                        Status = item.Status
                    };
                    itemcollection.Add(model);
                }
            }
            return Json(itemcollection.ToDataSourceResult(request));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateItem([DataSourceRequest] DataSourceRequest request, ItemModel itemModel)
        {
            try
            {
                if (itemModel != null && ModelState.IsValid)                
                    _entities.CreateItem(itemModel.Name, itemModel.Priority, itemModel.Status);

                return Json(new[] { itemModel }.ToDataSourceResult(new DataSourceRequest(), ModelState));
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult UpdateItem([DataSourceRequest] DataSourceRequest request, ItemModel itemModel)
        {
            try
            {
                if (itemModel != null && ModelState.IsValid)                
                    _entities.UpdateItem(itemModel.Id, itemModel.Name, itemModel.Priority, itemModel.Status);              
                
                return Json(new[] {itemModel}.ToDataSourceResult(new DataSourceRequest(), ModelState));
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }    
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult DeleteItem([DataSourceRequest] DataSourceRequest request, ItemModel itemModel)
        {
            try
            {
                if (itemModel != null && ModelState.IsValid)
                    _entities.DeleteItem(itemModel.Id);

                return Json(new[] { itemModel }.ToDataSourceResult(new DataSourceRequest(), ModelState));
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        public JsonResult ReadStatusList([DataSourceRequest] DataSourceRequest request)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "Not Started",
                    Value = "Not Started"
                },
                new SelectListItem()
                {
                    Text = "In Progress",
                    Value = "In Progress"
                },
                new SelectListItem()
                {
                    Text = "Completed",
                    Value = "Completed"
                }

            };

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ReadPriorityList([DataSourceRequest] DataSourceRequest request)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem()
                {
                    Text = "High",
                    Value = "High"
                },
                new SelectListItem()
                {
                    Text = "Medium",
                    Value = "Medium"
                },
                new SelectListItem()
                {
                    Text = "Low",
                    Value = "Low"
                }

            };

            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}