using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using System.Security.Cryptography;

namespace Classes.Globle
{
    public static class EncryptionHelpers
    {

        static Database.ERPEntities DB = new Database.ERPEntities();
        private const string cryptoKey = "cryptoKey";
        private static readonly byte[] IV = new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };
        // login check for ACM
        static string message = "";
        public static string CheckLogin(string TenentId, string User_Id, string Password, string UserType)
        {
           
            int TID = Convert.ToInt32(TenentId);
            int UserTypeID = UserType==""?1:Convert.ToInt32(UserType);
            var obj=DB.ERP_WEB_USER_MST.Single(p => p.TENANT_ID == TID && p.LOGIN_ID == User_Id && p.PASSWORD == Password && p.USER_TYPE == UserTypeID);
            if (obj.ACTIVE_FLAG != "Y")
            {
                message = "Contact Adminisrtrator or support to activate your account!";
              
                //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('');", true);
            }
            if (obj.ACC_LOCK != "N")
            {
                message += " Contact Adminisrtrator or support to Unlock your account!";
               
                //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('');", true);
            }
            if (obj.Till_DT <= DateTime.Now)
            {
                message += " Contact Adminisrtrator or support to renew your account!";
                //ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "myscript", "alert('');", true);
            }
            return message;
        }
        //User Verify in login for ACM
        public static ERP_WEB_USER_MST LoginVerified(string TenentId, string User_Id, string Password, string UserType)
        {
            int TID = Convert.ToInt32(TenentId);
            int UserTypeID = UserType == "" ? 1 : Convert.ToInt32(UserType);
            var UserList = DB.ERP_WEB_USER_MST.SingleOrDefault(p => p.TENANT_ID == TID && p.LOGIN_ID == User_Id && p.PASSWORD == Password && p.USER_TYPE == UserTypeID);
            return UserList;
        }
        

             ////var result1 = (from ur in DB.ERP_WEB_GEN_USER_ROLE_MAP
             ////               join
             ////                   rlist in DB.ERP_WEB_PRIVILAGE_MENU on ur.PRIVILEGE_ID equals rlist.PRIVILEGE_ID into rolelist
             ////               from rlist in rolelist.DefaultIfEmpty()
             ////               join pmm in DB.ERP_WEB_ACM_MODULE_MAP on rlist.PRIVILEGE_ID equals pmm.PRIVILEGE_ID into modulelist
             ////               from pmm in modulelist.DefaultIfEmpty()
             ////               join userr in DB.ERP_WEB_USER_RIGHTS on pmm.PRIVILEGE_ID equals userr.PRIVILEGE_ID

             ////               join menu in DB.ERP_WEB_MENU_MST on pmm.MODULE_ID equals menu.MODULE_ID

             ////               where rlist.PRIVILAGEFOR == 1 && menu.ACTIVE_FLAG == 1
             ////               select new {menu.TENANT_ID, menu.MENU_ID, menu.LINK,menu.MENU_NAME }).ToList().Distinct();


////            ,,,,,PRIVILAGE_MENUID,MODULE_ID,,,,,,,PRINTFLAGE,ALL_FLAG
////LINK,MASTER_ID,MENU_TYPE,MENU_NAME1,MENU_NAME2,MENU_NAME3,URLREWRITE,MENU_LOCATION,MENU_ORDER,DOC_PARENT,AMIGLOBALE,MYPERSONAL,SMALLTEXT,ACTIVETILLDATE,ICONPATH,METATITLE
////METAKEYWORD,METADESCRIPTION,HEADERVISIBLEDATA,HEADERINVISIBLEDATA,FOOTERVISIBLEDATA,FOOTERINVISIBLEDATA,REFID,MYBUSID
            //PRIVILAGEFOR=1 for Role
            //PRIVILAGEFOR=2 for Module
            //PRIVILAGEFOR=3 for User Right

        //bind menu in Master for ACM

        //ROLE To user fine out how 
        // Read ERP_WEB_GEN_USER_ROLE_MAP using session userid and for that role privilage_id+userID locate how many allowed menu in ERP_WEB_PRIVILAGE_MENU source=R1
        ///MODULE To user fine out how 
        // Read ERP_WEB_ACM_MODULE_MAP using session userid and for that role privilage_id+userID locate how many allowed menu in ERP_WEB_PRIVILAGE_MENU source=M2
        // Privilage for Menu to know how many menu allowed to this user
        // USER RIGHT to user fine out how 
        // Read ERP_WEB_USER_RIGHTS using session userid and for that role privilage_id+userID locate how many allowed menu in ERP_WEB_PRIVILAGE_MENU source=U3
        // ERP_WEB_MENU_MST where AMIGLOBAL=Y
        public static List<tempUser> getMenu(int TenentId,int UserID)
        {
            List<tempUser> userlist = new List<tempUser>();
            Database.tempUser obj = new Database.tempUser();
            //for ERP_WEB_GEN_USER_ROLE_MAP
            var result1 = (from  pm in DB.ERP_WEB_PRIVILAGE_MENU 
                           join
                             ur in DB.ERP_WEB_GEN_USER_ROLE_MAP on pm.PRIVILEGE_ID equals ur.PRIVILEGE_ID
                           where ur.ACTIVE_FLAG == "Y" && ur.TENANT_ID == TenentId && pm.PRIVILAGEFOR==1 && ur.USER_ID==UserID && ur.ACTIVE_FROM_DT >= DateTime.Now && ur.ACTIVE_TO_DT<= DateTime.Now
                           select new { ur.TENANT_ID, ur.PRIVILEGE_ID, ur.ROLE_ID, pm.PRIVILAGEFOR, pm.MENU_ID,pm.PRIVILEGE_MENU_ID ,ur.ACTIVE_FLAG, ur.USER_ID, pm.ADD_FLAG, pm.MODIFY_FLAG, pm.DELETE_FLAG, pm.VIEW_FLAG }).ToList();
          Database.ERP_WEB_MENU_MST MenuObj=new Database.ERP_WEB_MENU_MST();
            foreach (var item1 in result1)
            {
                obj = new Database.tempUser();
                MenuObj=DB.ERP_WEB_MENU_MST.Single(p=>p.MENU_ID==item1.MENU_ID && p.TENANT_ID==TenentId);

                obj.TENANT_ID = item1.TENANT_ID;
                obj.PRIVILAGEID = item1.PRIVILEGE_ID;
                obj.PRIVILAGESOURCE = "1";
                obj.MENUID = item1.MENU_ID;
                obj.PRIVILAGE_MENUID = item1.PRIVILEGE_MENU_ID;
               // obj.MODULE_ID = item1.MODULE_ID;
                obj.UserID = item1.USER_ID;
                obj.ROLE_ID = item1.ROLE_ID;
                obj.ADD_FLAG = item1.ADD_FLAG;
                obj.MODIFY_FLAG = item1.MODIFY_FLAG;
                obj.DELETE_FLAG = item1.DELETE_FLAG;
                obj.VIEW_FLAG = item1.VIEW_FLAG;
               // obj.PRINTFLAGE = item1.PRINTFLAGE;
                //obj.ALL_FLAG = item1.ALL_FLAG;
                obj.LINK = MenuObj.LINK;
                obj.MASTER_ID = MenuObj.MASTER_ID;
                obj.MENU_TYPE = MenuObj.MENU_TYPE;
                obj.MENU_NAME1 = MenuObj.MENU_NAME1;
                obj.MENU_NAME2 = MenuObj.MENU_NAME2;
                obj.MENU_NAME3 = MenuObj.MENU_NAME3;
                obj.URLREWRITE = MenuObj.URLREWRITE;
                obj.MENU_LOCATION = MenuObj.MENU_LOCATION;
                obj.MENU_ORDER = MenuObj.MENU_ORDER;
                obj.DOC_PARENT = MenuObj.DOC_PARENT;
                obj.AMIGLOBALE = MenuObj.AMIGLOBALE;
                obj.MYPERSONAL = MenuObj.MYPERSONAL;
                obj.SMALLTEXT = MenuObj.SMALLTEXT;
                obj.ICONPATH = MenuObj.ICONPATH;
                obj.METATITLE = MenuObj.METATITLE;
                obj.METAKEYWORD = MenuObj.METAKEYWORD;
                obj.METADESCRIPTION = MenuObj.METADESCRIPTION;
                obj.HEADERVISIBLEDATA = MenuObj.HEADERVISIBLEDATA;
                obj.HEADERINVISIBLEDATA = MenuObj.HEADERINVISIBLEDATA;
                obj.FOOTERVISIBLEDATA = MenuObj.FOOTERVISIBLEDATA;
                obj.FOOTERINVISIBLEDATA = MenuObj.FOOTERINVISIBLEDATA;
                obj.REFID = MenuObj.REFID;
                obj.MYBUSID = MenuObj.MYBUSID;
                obj.ACTIVETILLDATE = MenuObj.ACTIVETILLDATE;
                obj.ACTIVEMENU = item1.ACTIVE_FLAG=="Y"?true:false;
               // obj.ACTIVEPRIVILAGE = item1.ACTIVEPRIVILAGE;
               // obj.ACTIVEMODULE = item1.ACTIVEMODULE;
                obj.ACTIVEROLE = item1.ACTIVE_FLAG == "Y" ? true : false; ;
                //obj.URADD_FLAG = item1.URADD_FLAG;
                //obj.URMODIFY_FLAG = item1.URMODIFY_FLAG;
                //obj.URDELETE_FLAG = item1.URDELETE_FLAG;
                //obj.URVIEW_FLAG = item1.URVIEW_FLAG;
                //obj.URALL_FLAG = item1.URALL_FLAG;

                
                userlist.Add(obj);
                DB.tempUsers.AddObject(obj);
                DB.SaveChanges();
            }
           
            //for ERP_WEB_ACM_MODULE_MAP
            var result2 = (from Module in DB.ERP_WEB_ACM_MODULE_MAP
                           join
                               pm in DB.ERP_WEB_PRIVILAGE_MENU on Module.PRIVILEGE_ID equals pm.PRIVILEGE_ID
                           where Module.ACTIVE_FLAG == "Y" && Module.TENANT_ID == TenentId
                           select new { Module.TENANT_ID, Module.PRIVILEGE_ID, Module.MODULE_ID, pm.PRIVILAGEFOR,pm.PRIVILEGE_MENU_ID, pm.MENU_ID, Module.ACTIVE_FLAG, Module.UserID, pm.ADD_FLAG, pm.MODIFY_FLAG, pm.DELETE_FLAG, pm.VIEW_FLAG, }).ToList();

            foreach (var item2 in result2)
            {
                obj = new Database.tempUser();
                MenuObj = DB.ERP_WEB_MENU_MST.Single(p => p.MENU_ID == item2.MENU_ID&& p.TENANT_ID==TenentId);
                obj.TENANT_ID = item2.TENANT_ID;
                obj.PRIVILAGEID = item2.PRIVILEGE_ID;
                obj.PRIVILAGESOURCE = "2";
                obj.MENUID = item2.MENU_ID;
                obj.PRIVILAGE_MENUID = item2.PRIVILEGE_MENU_ID;
                 obj.MODULE_ID = item2.MODULE_ID;
                obj.UserID = item2.UserID;
               // obj.ROLE_ID = item2.ROLE_ID;
                obj.ADD_FLAG = item2.ADD_FLAG;
                obj.MODIFY_FLAG = item2.MODIFY_FLAG;
                obj.DELETE_FLAG = item2.DELETE_FLAG;
                obj.VIEW_FLAG = item2.VIEW_FLAG;
                 obj.PRINTFLAGE = item2.PRIVILEGE_ID;
                //obj.ALL_FLAG = item2.ALL_FLAG;
                obj.LINK = MenuObj.LINK;
                obj.MASTER_ID = MenuObj.MASTER_ID;
                obj.MENU_TYPE = MenuObj.MENU_TYPE;
                obj.MENU_NAME1 = MenuObj.MENU_NAME1;
                obj.MENU_NAME2 = MenuObj.MENU_NAME2;
                obj.MENU_NAME3 = MenuObj.MENU_NAME3;
                obj.URLREWRITE = MenuObj.URLREWRITE;
                obj.MENU_LOCATION = MenuObj.MENU_LOCATION;
                obj.MENU_ORDER = MenuObj.MENU_ORDER;
                obj.DOC_PARENT = MenuObj.DOC_PARENT;
                obj.AMIGLOBALE = MenuObj.AMIGLOBALE;
                obj.MYPERSONAL = MenuObj.MYPERSONAL;
                obj.SMALLTEXT = MenuObj.SMALLTEXT;
                obj.ICONPATH = MenuObj.ICONPATH;
                obj.METATITLE = MenuObj.METATITLE;
                obj.METAKEYWORD = MenuObj.METAKEYWORD;
                obj.METADESCRIPTION = MenuObj.METADESCRIPTION;
                obj.HEADERVISIBLEDATA = MenuObj.HEADERVISIBLEDATA;
                obj.HEADERINVISIBLEDATA = MenuObj.HEADERINVISIBLEDATA;
                obj.FOOTERVISIBLEDATA = MenuObj.FOOTERVISIBLEDATA;
                obj.FOOTERINVISIBLEDATA = MenuObj.FOOTERINVISIBLEDATA;
                obj.REFID = MenuObj.REFID;
                obj.MYBUSID = MenuObj.MYBUSID;
                obj.ACTIVETILLDATE = MenuObj.ACTIVETILLDATE;
                obj.ACTIVEMENU = item2.ACTIVE_FLAG == "Y" ? true : false;
                // obj.ACTIVEPRIVILAGE = item2.ACTIVEPRIVILAGE;
                obj.ACTIVEMODULE = item2.ACTIVE_FLAG == "Y" ? true : false; 
               // obj.ACTIVEROLE = 
                //obj.URADD_FLAG = item2.URADD_FLAG;
                //obj.URMODIFY_FLAG = item2.URMODIFY_FLAG;
                //obj.URDELETE_FLAG = item2.URDELETE_FLAG;
                //obj.URVIEW_FLAG = item2.URVIEW_FLAG;
                //obj.URALL_FLAG = item2.URALL_FLAG;

                userlist.Add(obj);
                DB.tempUsers.AddObject(obj);
                DB.SaveChanges();
            }

            //for ERP_WEB_USER_RIGHTS
            var result3 = (from URR in DB.ERP_WEB_USER_RIGHTS
                           join
                               pm in DB.ERP_WEB_PRIVILAGE_MENU on URR.PRIVILEGE_ID equals pm.PRIVILEGE_ID
                           where URR.TENANT_ID == TenentId 
                           select new { URR.TENANT_ID, URR.PRIVILEGE_ID, pm.PRIVILAGEFOR, pm.PRIVILEGE_MENU_ID, pm.MENU_ID, URR.USER_ID, URR.ADD_FLAG, URR.MODIFY_FLAG, URR.DELETE_FLAG, URR.VIEW_FLAG, URR.ALL_FLAG, a=pm.ADD_FLAG , b=pm.MODIFY_FLAG, c=pm.DELETE_FLAG, d=pm.VIEW_FLAG }).ToList();

             foreach (var item3 in result3)
             {
                 obj = new Database.tempUser();
                 MenuObj = DB.ERP_WEB_MENU_MST.Single(p => p.MENU_ID == item3.MENU_ID && p.TENANT_ID == TenentId);
                 obj.TENANT_ID = item3.TENANT_ID;
                 obj.PRIVILAGEID = Convert.ToInt32(item3.PRIVILEGE_ID);
                 obj.PRIVILAGESOURCE = "3";
                 obj.MENUID = item3.MENU_ID;
                 obj.PRIVILAGE_MENUID = item3.PRIVILEGE_MENU_ID;
                // obj.MODULE_ID = item3.MODULE_ID;
                 obj.UserID = item3.USER_ID;
                 // obj.ROLE_ID = item2.ROLE_ID;
                 obj.ADD_FLAG = item3.a;
                 obj.MODIFY_FLAG = item3.b;
                 obj.DELETE_FLAG = item3.c;
                 obj.VIEW_FLAG = item3.d;
                 obj.PRINTFLAGE = item3.PRIVILEGE_ID;
                 //obj.ALL_FLAG = item2.ALL_FLAG;
                 obj.LINK = MenuObj.LINK;
                 obj.MASTER_ID = MenuObj.MASTER_ID;
                 obj.MENU_TYPE = MenuObj.MENU_TYPE;
                 obj.MENU_NAME1 = MenuObj.MENU_NAME1;
                 obj.MENU_NAME2 = MenuObj.MENU_NAME2;
                 obj.MENU_NAME3 = MenuObj.MENU_NAME3;
                 obj.URLREWRITE = MenuObj.URLREWRITE;
                 obj.MENU_LOCATION = MenuObj.MENU_LOCATION;
                 obj.MENU_ORDER = MenuObj.MENU_ORDER;
                 obj.DOC_PARENT = MenuObj.DOC_PARENT;
                 obj.AMIGLOBALE = MenuObj.AMIGLOBALE;
                 obj.MYPERSONAL = MenuObj.MYPERSONAL;
                 obj.SMALLTEXT = MenuObj.SMALLTEXT;
                 obj.ICONPATH = MenuObj.ICONPATH;
                 obj.METATITLE = MenuObj.METATITLE;
                 obj.METAKEYWORD = MenuObj.METAKEYWORD;
                 obj.METADESCRIPTION = MenuObj.METADESCRIPTION;
                 obj.HEADERVISIBLEDATA = MenuObj.HEADERVISIBLEDATA;
                 obj.HEADERINVISIBLEDATA = MenuObj.HEADERINVISIBLEDATA;
                 obj.FOOTERVISIBLEDATA = MenuObj.FOOTERVISIBLEDATA;
                 obj.FOOTERINVISIBLEDATA = MenuObj.FOOTERINVISIBLEDATA;
                 obj.REFID = MenuObj.REFID;
                 obj.MYBUSID = MenuObj.MYBUSID;
                 obj.ACTIVETILLDATE = MenuObj.ACTIVETILLDATE;
                 //obj.ACTIVEMENU = item3.ACTIVE_FLAG == "Y" ? true : false;
                 //obj.ACTIVEPRIVILAGE = item3.ACTIVEPRIVILAGE;
                 //obj.ACTIVEMODULE = item3.ACTIVEMODULE;
                 //obj.ACTIVEROLE = item3.ACTIVE_FLAG == "Y" ? true : false; ;
                 obj.URADD_FLAG = item3.ADD_FLAG;
                 obj.URMODIFY_FLAG = item3.MODIFY_FLAG;
                 obj.URDELETE_FLAG = item3.DELETE_FLAG;
                 obj.URVIEW_FLAG = item3.VIEW_FLAG;
                 obj.URALL_FLAG = item3.ALL_FLAG;

                 userlist.Add(obj);
                 DB.tempUsers.AddObject(obj);
                 DB.SaveChanges();
             }

             var AmiGloble = DB.ERP_WEB_MENU_MST.Where(p=>p.AMIGLOBALE==2);
             foreach (var item4 in AmiGloble)
             {
                 tempUser obj1 = new tempUser();
                 obj1.TENANT_ID = item4.TENANT_ID;
                 obj1.MENUID = item4.MENU_ID;
                 obj1.LINK = item4.LINK;
                 obj1.MENU_NAME1 = item4.MENU_NAME1;
                 obj1.MENU_NAME2 = item4.MENU_NAME2;
                 obj1.MENU_NAME3 = item4.MENU_NAME3;
                 obj1.URLREWRITE = item4.URLREWRITE;
                 obj1.MENU_LOCATION = item4.MENU_LOCATION;
                 obj1.MENU_ORDER = item4.MENU_ORDER;
                 obj1.DOC_PARENT = item4.DOC_PARENT;
                 obj1.AMIGLOBALE = item4.AMIGLOBALE;
                 obj1.MYPERSONAL = item4.MYPERSONAL;
                 obj1.SMALLTEXT = item4.SMALLTEXT;
                 obj1.ICONPATH = item4.ICONPATH;
                 obj1.METATITLE = item4.METATITLE;
                 obj1.METAKEYWORD = item4.METAKEYWORD;
                 obj1.METADESCRIPTION = item4.METADESCRIPTION;
                 obj1.HEADERVISIBLEDATA = item4.HEADERVISIBLEDATA;
                 obj1.HEADERINVISIBLEDATA = item4.HEADERINVISIBLEDATA;
                 obj1.FOOTERVISIBLEDATA = item4.FOOTERVISIBLEDATA;
                 obj1.FOOTERINVISIBLEDATA = item4.FOOTERINVISIBLEDATA;
                 obj1.REFID = item4.REFID;
                 obj1.MYBUSID = item4.MYBUSID;
                 userlist.Add(obj);
                 DB.tempUsers.AddObject(obj);
                 DB.SaveChanges();
                 
             }
             return userlist;
        }
        public static string Encrypt(string s)
        {
            if (s == null || s.Length == 0) return string.Empty;

            string result = string.Empty;

            try
            {
                byte[] buffer = Encoding.ASCII.GetBytes(s);

                TripleDESCryptoServiceProvider des =
                    new TripleDESCryptoServiceProvider();

                MD5CryptoServiceProvider MD5 =
                    new MD5CryptoServiceProvider();

                des.Key =
                    MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                des.IV = IV;
                result = Convert.ToBase64String(
                    des.CreateEncryptor().TransformFinalBlock(
                        buffer, 0, buffer.Length));
            }
            catch
            {
                result = "0";
            }
            if (result.Contains("+"))
            {
                result = result.Replace("+", "~");
            }
            return result;
        }
        public static string Decrypt(string s)
        {
            if (s.Contains("~"))
            {
                s = s.Replace("~", "+");
            }

            if (s == null || s.Length == 0) return string.Empty;

            string result = string.Empty;

            try
            {
                byte[] buffer = Convert.FromBase64String(s);

                TripleDESCryptoServiceProvider des =
                    new TripleDESCryptoServiceProvider();

                MD5CryptoServiceProvider MD5 =
                    new MD5CryptoServiceProvider();

                des.Key =
                    MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));

                des.IV = IV;

                result = Encoding.ASCII.GetString(
                    des.CreateDecryptor().TransformFinalBlock(
                    buffer, 0, buffer.Length));
            }
            catch
            {
                result = "0";
            }

            return result;
        }





    }
}
