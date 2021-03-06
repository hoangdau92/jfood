﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CS.Portal.Core.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class CSF_MVCEntities : DbContext
    {
        public CSF_MVCEntities()
            : base("name=CSF_MVCEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CSF_Functions> CSF_Functions { get; set; }
        public virtual DbSet<CSF_PagePartial> CSF_PagePartial { get; set; }
        public virtual DbSet<CSF_Pages> CSF_Pages { get; set; }
        public virtual DbSet<CSF_RoleFunction> CSF_RoleFunction { get; set; }
        public virtual DbSet<CSF_Roles> CSF_Roles { get; set; }
        public virtual DbSet<CSF_UserRole> CSF_UserRole { get; set; }
        public virtual DbSet<CSF_Partials> CSF_Partials { get; set; }
        public virtual DbSet<CSF_PageRole> CSF_PageRole { get; set; }
        public virtual DbSet<CSF_Modules> CSF_Modules { get; set; }
        public virtual DbSet<CSF_Users> CSF_Users { get; set; }
        public virtual DbSet<CMS_Categories> CMS_Categories { get; set; }
        public virtual DbSet<CMS_News> CMS_News { get; set; }
        public virtual DbSet<CSF_Logs> CSF_Logs { get; set; }
        public virtual DbSet<CMS_AdImages> CMS_AdImages { get; set; }
        public virtual DbSet<CMS_News_Status> CMS_News_Status { get; set; }
        public virtual DbSet<CMS_Questions> CMS_Questions { get; set; }
        public virtual DbSet<CMS_TypeOfQuestion> CMS_TypeOfQuestion { get; set; }
    
        public virtual int CSF_UserRole_DelByUser(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CSF_UserRole_DelByUser", userIDParameter);
        }
    
        public virtual ObjectResult<CSF_UserRole_GetByUser_Result> CSF_UserRole_GetByUser(Nullable<int> userID)
        {
            var userIDParameter = userID.HasValue ?
                new ObjectParameter("userID", userID) :
                new ObjectParameter("userID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CSF_UserRole_GetByUser_Result>("CSF_UserRole_GetByUser", userIDParameter);
        }
    
        public virtual ObjectResult<CSF_Users_CheckLogin_Result> CSF_Users_CheckLogin(string userName, string password)
        {
            var userNameParameter = userName != null ?
                new ObjectParameter("UserName", userName) :
                new ObjectParameter("UserName", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CSF_Users_CheckLogin_Result>("CSF_Users_CheckLogin", userNameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<CSF_Users_GetAll_Result> CSF_Users_GetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CSF_Users_GetAll_Result>("CSF_Users_GetAll");
        }
    
        public virtual ObjectResult<CSF_Users_GetUsersNotInGroup_Result> CSF_Users_GetUsersNotInGroup(Nullable<int> roleID)
        {
            var roleIDParameter = roleID.HasValue ?
                new ObjectParameter("RoleID", roleID) :
                new ObjectParameter("RoleID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CSF_Users_GetUsersNotInGroup_Result>("CSF_Users_GetUsersNotInGroup", roleIDParameter);
        }
    
        public virtual ObjectResult<CSF_Users_GetUsersInGroup_Result> CSF_Users_GetUsersInGroup(Nullable<int> roleID)
        {
            var roleIDParameter = roleID.HasValue ?
                new ObjectParameter("RoleID", roleID) :
                new ObjectParameter("RoleID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CSF_Users_GetUsersInGroup_Result>("CSF_Users_GetUsersInGroup", roleIDParameter);
        }
    
        public virtual int CSF_UserRole_RemoveUser(Nullable<int> roleID, string listUserID)
        {
            var roleIDParameter = roleID.HasValue ?
                new ObjectParameter("RoleID", roleID) :
                new ObjectParameter("RoleID", typeof(int));
    
            var listUserIDParameter = listUserID != null ?
                new ObjectParameter("listUserID", listUserID) :
                new ObjectParameter("listUserID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CSF_UserRole_RemoveUser", roleIDParameter, listUserIDParameter);
        }
    
        public virtual ObjectResult<CSF_Functions_LayTatCa_Result> CSF_Functions_LayTatCa()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CSF_Functions_LayTatCa_Result>("CSF_Functions_LayTatCa");
        }
    
        public virtual ObjectResult<CSF_RoleFunction_LayTatCa_Result> CSF_RoleFunction_LayTatCa()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CSF_RoleFunction_LayTatCa_Result>("CSF_RoleFunction_LayTatCa");
        }
    
        public virtual ObjectResult<CSF_Pages_LayTatCa_Result> CSF_Pages_LayTatCa()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CSF_Pages_LayTatCa_Result>("CSF_Pages_LayTatCa");
        }
    
        public virtual ObjectResult<CSF_Pages_GetPartial_Result> CSF_Pages_GetPartial(string key, Nullable<short> active)
        {
            var keyParameter = key != null ?
                new ObjectParameter("key", key) :
                new ObjectParameter("key", typeof(string));
    
            var activeParameter = active.HasValue ?
                new ObjectParameter("active", active) :
                new ObjectParameter("active", typeof(short));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CSF_Pages_GetPartial_Result>("CSF_Pages_GetPartial", keyParameter, activeParameter);
        }
    
        public virtual int CSF_Role_Function_Add(Nullable<int> roleID, Nullable<int> moduleID, string value)
        {
            var roleIDParameter = roleID.HasValue ?
                new ObjectParameter("RoleID", roleID) :
                new ObjectParameter("RoleID", typeof(int));
    
            var moduleIDParameter = moduleID.HasValue ?
                new ObjectParameter("ModuleID", moduleID) :
                new ObjectParameter("ModuleID", typeof(int));
    
            var valueParameter = value != null ?
                new ObjectParameter("value", value) :
                new ObjectParameter("value", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CSF_Role_Function_Add", roleIDParameter, moduleIDParameter, valueParameter);
        }
    
        public virtual int CSF_PageRole_Add(Nullable<int> roleID, string value, Nullable<bool> isadmin)
        {
            var roleIDParameter = roleID.HasValue ?
                new ObjectParameter("RoleID", roleID) :
                new ObjectParameter("RoleID", typeof(int));
    
            var valueParameter = value != null ?
                new ObjectParameter("value", value) :
                new ObjectParameter("value", typeof(string));
    
            var isadminParameter = isadmin.HasValue ?
                new ObjectParameter("isadmin", isadmin) :
                new ObjectParameter("isadmin", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CSF_PageRole_Add", roleIDParameter, valueParameter, isadminParameter);
        }
    
        public virtual ObjectResult<CSF_Partials_LayTatCa_Result> CSF_Partials_LayTatCa()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CSF_Partials_LayTatCa_Result>("CSF_Partials_LayTatCa");
        }
    
        public virtual ObjectResult<CSF_Pages_GetPageByRoleID_Result> CSF_Pages_GetPageByRoleID(string roleID)
        {
            var roleIDParameter = roleID != null ?
                new ObjectParameter("RoleID", roleID) :
                new ObjectParameter("RoleID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CSF_Pages_GetPageByRoleID_Result>("CSF_Pages_GetPageByRoleID", roleIDParameter);
        }
    
        public virtual ObjectResult<CMS_Categories_LayTatCa_Result> CMS_Categories_LayTatCa()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CMS_Categories_LayTatCa_Result>("CMS_Categories_LayTatCa");
        }
    
        public virtual ObjectResult<CMS_News_LayTatCa_Result> CMS_News_LayTatCa(Nullable<int> cATEGORIESID, string keyword, Nullable<int> nEWS_STATUS_ID)
        {
            var cATEGORIESIDParameter = cATEGORIESID.HasValue ?
                new ObjectParameter("CATEGORIESID", cATEGORIESID) :
                new ObjectParameter("CATEGORIESID", typeof(int));
    
            var keywordParameter = keyword != null ?
                new ObjectParameter("keyword", keyword) :
                new ObjectParameter("keyword", typeof(string));
    
            var nEWS_STATUS_IDParameter = nEWS_STATUS_ID.HasValue ?
                new ObjectParameter("NEWS_STATUS_ID", nEWS_STATUS_ID) :
                new ObjectParameter("NEWS_STATUS_ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CMS_News_LayTatCa_Result>("CMS_News_LayTatCa", cATEGORIESIDParameter, keywordParameter, nEWS_STATUS_IDParameter);
        }
    
        public virtual ObjectResult<CMS_News_LayCongBoK0CongBo_Result> CMS_News_LayCongBoK0CongBo(Nullable<int> cATEGORIESID, string keyword)
        {
            var cATEGORIESIDParameter = cATEGORIESID.HasValue ?
                new ObjectParameter("CATEGORIESID", cATEGORIESID) :
                new ObjectParameter("CATEGORIESID", typeof(int));
    
            var keywordParameter = keyword != null ?
                new ObjectParameter("keyword", keyword) :
                new ObjectParameter("keyword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CMS_News_LayCongBoK0CongBo_Result>("CMS_News_LayCongBoK0CongBo", cATEGORIESIDParameter, keywordParameter);
        }
    
        public virtual ObjectResult<CSF_Pages_GetPartial_FrontEnd_Result> CSF_Pages_GetPartial_FrontEnd(string key, Nullable<short> active, string username, Nullable<int> idGuestGroup)
        {
            var keyParameter = key != null ?
                new ObjectParameter("key", key) :
                new ObjectParameter("key", typeof(string));
    
            var activeParameter = active.HasValue ?
                new ObjectParameter("active", active) :
                new ObjectParameter("active", typeof(short));
    
            var usernameParameter = username != null ?
                new ObjectParameter("username", username) :
                new ObjectParameter("username", typeof(string));
    
            var idGuestGroupParameter = idGuestGroup.HasValue ?
                new ObjectParameter("idGuestGroup", idGuestGroup) :
                new ObjectParameter("idGuestGroup", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CSF_Pages_GetPartial_FrontEnd_Result>("CSF_Pages_GetPartial_FrontEnd", keyParameter, activeParameter, usernameParameter, idGuestGroupParameter);
        }
    
        public virtual int CSF_Pages_CopyPage(Nullable<int> pageNguon, Nullable<int> pageDich)
        {
            var pageNguonParameter = pageNguon.HasValue ?
                new ObjectParameter("PageNguon", pageNguon) :
                new ObjectParameter("PageNguon", typeof(int));
    
            var pageDichParameter = pageDich.HasValue ?
                new ObjectParameter("PageDich", pageDich) :
                new ObjectParameter("PageDich", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CSF_Pages_CopyPage", pageNguonParameter, pageDichParameter);
        }
    
        public virtual int CMS_News_LayTopTinBaiCongKhaiTheoCateKey(Nullable<int> top, string cateKey)
        {
            var topParameter = top.HasValue ?
                new ObjectParameter("Top", top) :
                new ObjectParameter("Top", typeof(int));
    
            var cateKeyParameter = cateKey != null ?
                new ObjectParameter("CateKey", cateKey) :
                new ObjectParameter("CateKey", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CMS_News_LayTopTinBaiCongKhaiTheoCateKey", topParameter, cateKeyParameter);
        }
    
        public virtual ObjectResult<CSF_Modules_LayTatCa_Result> CSF_Modules_LayTatCa(string keyword)
        {
            var keywordParameter = keyword != null ?
                new ObjectParameter("keyword", keyword) :
                new ObjectParameter("keyword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CSF_Modules_LayTatCa_Result>("CSF_Modules_LayTatCa", keywordParameter);
        }
    
        public virtual ObjectResult<CSF_Logs_LayTatCa_Result> CSF_Logs_LayTatCa(string keyword)
        {
            var keywordParameter = keyword != null ?
                new ObjectParameter("keyword", keyword) :
                new ObjectParameter("keyword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CSF_Logs_LayTatCa_Result>("CSF_Logs_LayTatCa", keywordParameter);
        }
    
        public virtual ObjectResult<CSF_Logs_TheoTieuChi_Result> CSF_Logs_TheoTieuChi(string keyword, string pFromDate, string pToDate)
        {
            var keywordParameter = keyword != null ?
                new ObjectParameter("keyword", keyword) :
                new ObjectParameter("keyword", typeof(string));
    
            var pFromDateParameter = pFromDate != null ?
                new ObjectParameter("pFromDate", pFromDate) :
                new ObjectParameter("pFromDate", typeof(string));
    
            var pToDateParameter = pToDate != null ?
                new ObjectParameter("pToDate", pToDate) :
                new ObjectParameter("pToDate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CSF_Logs_TheoTieuChi_Result>("CSF_Logs_TheoTieuChi", keywordParameter, pFromDateParameter, pToDateParameter);
        }
    
        public virtual ObjectResult<CMS_AdImages_LayTatCa_Result> CMS_AdImages_LayTatCa(string keyword)
        {
            var keywordParameter = keyword != null ?
                new ObjectParameter("keyword", keyword) :
                new ObjectParameter("keyword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CMS_AdImages_LayTatCa_Result>("CMS_AdImages_LayTatCa", keywordParameter);
        }
    
        public virtual ObjectResult<CMS_Questions_LayTatCa_Result> CMS_Questions_LayTatCa(Nullable<int> typeOfQuestionID, string keyWord, Nullable<bool> publish)
        {
            var typeOfQuestionIDParameter = typeOfQuestionID.HasValue ?
                new ObjectParameter("TypeOfQuestionID", typeOfQuestionID) :
                new ObjectParameter("TypeOfQuestionID", typeof(int));
    
            var keyWordParameter = keyWord != null ?
                new ObjectParameter("KeyWord", keyWord) :
                new ObjectParameter("KeyWord", typeof(string));
    
            var publishParameter = publish.HasValue ?
                new ObjectParameter("Publish", publish) :
                new ObjectParameter("Publish", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CMS_Questions_LayTatCa_Result>("CMS_Questions_LayTatCa", typeOfQuestionIDParameter, keyWordParameter, publishParameter);
        }
    
        public virtual ObjectResult<CMS_TypeOfQuestion_LayTatCa_Result> CMS_TypeOfQuestion_LayTatCa(string keyword)
        {
            var keywordParameter = keyword != null ?
                new ObjectParameter("keyword", keyword) :
                new ObjectParameter("keyword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CMS_TypeOfQuestion_LayTatCa_Result>("CMS_TypeOfQuestion_LayTatCa", keywordParameter);
        }
    
        public virtual ObjectResult<CMS_News_LayTinBaiCongKhaiTheoCateKey_Result> CMS_News_LayTinBaiCongKhaiTheoCateKey(string cateKey)
        {
            var cateKeyParameter = cateKey != null ?
                new ObjectParameter("CateKey", cateKey) :
                new ObjectParameter("CateKey", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CMS_News_LayTinBaiCongKhaiTheoCateKey_Result>("CMS_News_LayTinBaiCongKhaiTheoCateKey", cateKeyParameter);
        }
    }
}
