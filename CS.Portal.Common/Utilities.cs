using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace CS.Portal.Common
{
    public static class Utilities
    {
        public static string sqlDateTimeToString(DateTime myDateTime)
        {
            string sqlFormattedDate = myDateTime.Date.ToString("dd/MM/yyyy");
            return sqlFormattedDate;
        }
        public static string[,] sArray = new string[14, 18];
        //Khởi tạo mảng
        public static void InitArrayToneMarks()
        {
            byte i, j;
            string sString = "aAeEoOuUiIdDyY";
            string LC_a = "áàạảãâấầậẩẫăắằặẳẵ";
            string UC_A = "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ";
            string LC_e = "éèẹẻẽêếềệểễeeeeee";
            string UC_E = "ÉÈẸẺẼÊẾỀỆỂỄEEEEEE";
            string LC_o = "óòọỏõôốồộổỗơớờợởỡ";
            string UC_O = "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ";
            string LC_u = "úùụủũưứừựửữuuuuuu";
            string UC_U = "ÚÙỤỦŨƯỨỪỰỬỮUUUUUU";
            string LC_i = "íìịỉĩiiiiiiiiiiii";
            string UC_I = "ÍÌỊỈĨIIIIIIIIIIII";
            string LC_d = "đdddddddddddddddd";
            string UC_D = "ĐDDDDDDDDDDDDDDDD";
            string LC_y = "ýỳỵỷỹyyyyyyyyyyyy";
            string UC_Y = "ÝỲỴỶỸYYYYYYYYYYYY";
            for (i = 0; i < 14; i++)
                sArray[i, 0] = sString.Substring(i, 1);
            for (j = 1; j < 18; j++)
                for (i = 1; i < 18; i++)
                {
                    sArray[0, i] = LC_a.Substring(i - 1, 1);
                    sArray[1, i] = UC_A.Substring(i - 1, 1);
                    sArray[2, i] = LC_e.Substring(i - 1, 1);
                    sArray[3, i] = UC_E.Substring(i - 1, 1);
                    sArray[4, i] = LC_o.Substring(i - 1, 1);
                    sArray[5, i] = UC_O.Substring(i - 1, 1);
                    sArray[6, i] = LC_u.Substring(i - 1, 1);
                    sArray[7, i] = UC_U.Substring(i - 1, 1);
                    sArray[8, i] = LC_i.Substring(i - 1, 1);
                    sArray[9, i] = UC_I.Substring(i - 1, 1);
                    sArray[10, i] = LC_d.Substring(i - 1, 1);
                    sArray[11, i] = UC_D.Substring(i - 1, 1);
                    sArray[12, i] = LC_y.Substring(i - 1, 1);
                    sArray[13, i] = UC_Y.Substring(i - 1, 1);
                }
        }
        //Hàm loại bỏ dấu
        public static string RemoveToneMarks(string sSource)
        {
            InitArrayToneMarks();
            if (sSource == "") return "";
            byte i, j;
            for (j = 0; j < 14; j++)
            {
                for (i = 1; i < 18; i++)
                {
                    sSource = sSource.Replace(sArray[j, i], sArray[j, 0]);
                }
            }
            return sSource;
        }
        //Ham loai bo dau va ky tu dac biet
        public static string RemoveUrlMarks(string strUrlName)
        {
            try
            {
                string strOldUrl = strUrlName;
                strOldUrl = RemoveToneMarks(strOldUrl);
                strOldUrl = strOldUrl.Replace(" ", "-").Replace("\"", "").Replace(":", "").Replace("<", "-").Replace(">", "-").Replace(";", "-").Replace(",", "-").
                        Replace(".", "-").Replace("/", "-").Replace("'", "").Replace("&", "-").Replace("%", "-").Replace("$", "-").Replace("|", "-").Replace("\\", "-").
                        Replace("#", "-").Replace("@", "-").Replace("!", "-").Replace("`", "-").Replace("~", "-").Replace("+", "-").Replace("*", "-").Replace("?", "-").Replace("--", "-");
                if (strOldUrl.Trim().Length>100)
                {
                    return strOldUrl.Substring(0, 100).ToLower();
                }
                return strOldUrl.ToLower();
            }
            catch
            {
                return strUrlName;
            }
        }

        public static string SiteURL()
        {
            return System.Configuration.ConfigurationManager.AppSettings["SiteURL"].ToString();
        }
        public static string SiteURL_Resources()
        {
            return System.Configuration.ConfigurationManager.AppSettings["UrlImage"].ToString();
        }

        public static string ReturnSubString(int iSize, string strName)
        {
            string strReturn = strName;
            int intIndex = 0;
            if (strName.Trim().Length > iSize)
            {
                intIndex = strName.IndexOf(' ', iSize);
                if (intIndex > 0)
                    strReturn = strName.Substring(0, intIndex) + "...";
            }
            return strReturn;
        }
        public static string UrlContent(string strCategoryKey, string strNewsTitle, string strPageType, string strNewsID)
        {
            if (strNewsTitle.Trim().Length>0)
            {
                strNewsTitle = Utilities.ReturnSubString(100, strNewsTitle);
                return SiteURL() + "/" + strCategoryKey + "/" + RemoveUrlMarks(strNewsTitle) + "/" + strPageType + "-" + strNewsID;    
            }
            else
                return SiteURL() + "/" + strCategoryKey;    
        }

        public static string UrlContent_2(string strCategoryKey, string strNewsTitle, string strNewsID)
        {
            if (strNewsTitle.Trim().Length > 0)
            {
                strNewsTitle = Utilities.ReturnSubString(100, strNewsTitle);
                return SiteURL() + "/" + strCategoryKey + "/" + RemoveUrlMarks(strNewsTitle) + "-" + strNewsID;
            }
            else
                return SiteURL() + "/" + strCategoryKey;
        }

    }
}