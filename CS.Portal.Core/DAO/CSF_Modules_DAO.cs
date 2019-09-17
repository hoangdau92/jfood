using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using CS.Portal.Common;
using CS.Portal.Core.EF;

namespace CS.Portal.Core.DAO
{
    public class CSF_Modules_DAO
    {
        CSF_MVCEntities MyContext = null;
        public CSF_Modules_DAO()
        {
            MyContext = new CSF_MVCEntities();
        }

        public IQueryable<CSF_Modules> GetAll()
        {
            var modules = from s in MyContext.CSF_Modules select s;
            return modules;
        }

        public IQueryable<CSF_Modules> Search(string strSearchString)
        {
            var modules = from s in MyContext.CSF_Modules select s;
            if (!String.IsNullOrEmpty(strSearchString))
            {
                modules = modules.Where(s => s.Name.Contains(strSearchString));
            }
            return modules;
        }
        public List<CSF_Modules_LayTatCa_Result> Search1(string keyWord)
        {
            try
            {
                List<CSF_Modules_LayTatCa_Result> lData = MyContext.CSF_Modules_LayTatCa(keyWord).ToList();
                return lData;
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                throw;
            }
        }
        public CSF_Modules LayModulesTheoMa(int? id)
        {
            try
            {
                return MyContext.CSF_Modules.SingleOrDefault(x => x.ID == id);
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                throw;
            }
        }

        public bool EditModules(CSF_Modules entity)
        {
            try
            {
                var module = MyContext.CSF_Modules.Find(entity.ID);
                module.Name = entity.Name;
                module.Description = entity.Description;
                MyContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                throw;
            }
        }
        public int Insert(CSF_Modules entity)
        {
            try
            {
                MyContext.CSF_Modules.Add(entity);
                MyContext.SaveChanges();
                return entity.ID;
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                throw;
            }
        }
        public bool CheckDelete(int id)
        {
            try
            {
                var obj = MyContext.CSF_Partials.Where(x => x.ModuleID == id).FirstOrDefault();
                var obj1 = MyContext.CSF_Functions.Where(x => x.ModuleID == id).FirstOrDefault();
                var obj2 = MyContext.CSF_Pages.Where(x => x.ModuleID == id).FirstOrDefault();
                if (obj != null || obj1 != null || obj2 != null)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var obj = MyContext.CSF_Modules.Find(id);
                MyContext.CSF_Modules.Remove(obj);
                MyContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                return false;
            }
        }
    }
}
