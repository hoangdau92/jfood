﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CS.Portal.Core.EF;
using System.Data.Entity;
using CS.Portal.Common;

namespace CS.Portal.Core.DAO
{
    public class CSF_PageRole_DAO
    {
        CSF_MVCEntities MyContext = null;
        public CSF_PageRole_DAO()
        {
            MyContext = new CSF_MVCEntities();
        }

        public int AddPermission(int RoleID, string PageIDs, bool ISADMIN)
        {
            try
            {
                string sql = "";
                if (PageIDs != null && PageIDs != "")
                {
                    string[] FuncIDs = PageIDs.Split(',');
                    foreach (var item in FuncIDs)
                    {
                        sql += "(" + RoleID + "," + item + "),";
                    }
                    sql = sql.Substring(0, sql.Length - 1);
                }
                int result = MyContext.CSF_PageRole_Add(RoleID, sql, ISADMIN);
                return result;
            }
            catch (Exception ex)
            {
                Logs.WriteLog(ex);
                throw;
            }
        }

    }
}
