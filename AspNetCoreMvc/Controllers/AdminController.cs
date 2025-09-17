using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvc.ActionFilters;
using AspNetCoreMvc.Models;
using AspNetCoreMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMvc.Controllers
{
    [AdminActionFilter]
    [LoginActionFilter]
    public class AdminController : Controller
    {
        SchoolDBContext db = new SchoolDBContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Permisions()
        {    
            return View(db.UserLogin.ToList());
        }

        public IActionResult Permision()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Permision(UserLogin model, int[] menuId, bool[] isRead, bool[] isCreate, bool[] isUpdate, bool[] isDelete)
        {
            var list = new List<UserPermission>();
            for (int i = 0; i < menuId.Length; i++)
            {
                var obj = new UserPermission();
                obj.MenuIid = menuId[i];
                obj.IsRead = isRead[i];
                obj.IsCreate = isCreate[i];
                obj.IsUpdate = isUpdate[i];
                obj.IsDelete = isDelete[i];
                obj.UserId = model.UserId;

                list.Add(obj);
            }
            db.UserLogin.AddAsync(model);
            db.UserPermission.AddRangeAsync(list);
            db.SaveChangesAsync();
            return RedirectToAction("Permisions");
        }

        public IActionResult PermisionEdit(int id)
        {
            VmUserPermission oVmUserPermission = new VmUserPermission();
            oVmUserPermission.UserLogin = db.UserLogin.Where(o => o.UserId == id).FirstOrDefault();
            oVmUserPermission.ListUserPermission = db.UserPermission.Where(o => o.UserId == id).ToList();
            return View(oVmUserPermission);
        }

        [HttpPost]
        public IActionResult PermisionEdit(UserLogin model, int[]permissionId, int[]menuId, bool[] isRead, bool[] isCreate, bool[] isUpdate, bool[] isDelete)
        {
            var list = new List<UserPermission>();
            for (int i = 0; i < menuId.Length; i++)
            {
                var obj = db.UserPermission.Where(o=>o.UserId == permissionId[i]).FirstOrDefault();
                if (obj != null)
                {
                    obj.MenuIid = menuId[i];
                    obj.IsRead = isRead[i];
                    obj.IsCreate = isCreate[i];
                    obj.IsUpdate = isUpdate[i];
                    obj.IsDelete = isDelete[i];
                    obj.UserId = model.UserId;
                }
                list.Add(obj);
            }
            db.UserLogin.Update(model);
            db.UserPermission.UpdateRange(list);
            db.SaveChangesAsync();
            return RedirectToAction("Permisions");
        }

    }
}