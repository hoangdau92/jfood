﻿using CS.Portal.Common;
using CS.Portal.Core.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS.Portal.Core.DAO
{
    public class CSF_Logs_DAO
    {
        CSF_MVCEntities MyContext = null;
        public CSF_Logs_DAO()
        {
            MyContext = new CSF_MVCEntities();
        }

        public List<CSF_Logs_LayTatCa_Result> Search(string keyWord)
        {
            try
            {
                List<CSF_Logs_LayTatCa_Result> lData = MyContext.CSF_Logs_LayTatCa(keyWord).ToList();
                return lData;
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                throw;
            }
        }
        public List<CSF_Logs_TheoTieuChi_Result> LayTheoTieuChi(string keyWord, string ngaybd, string ngaykt)
        {
            try
            {
                List<CSF_Logs_TheoTieuChi_Result> lData = MyContext.CSF_Logs_TheoTieuChi(keyWord, ngaybd,ngaykt).ToList();
                return lData;
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                throw;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var obj = MyContext.CSF_Logs.Find(id);
                MyContext.CSF_Logs.Remove(obj);
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
