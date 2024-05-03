using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Database;
//using Classes;
using System.Data;
//using Repository;

namespace Web.ACM
{
    public partial class ACMMaster : System.Web.UI.MasterPage
    {
        //List<Navigation> ChoiceList = new List<Navigation>();
        // Database.CallEntities DB = new Database.CallEntities();
        int TID = 0;
        int userID = 0;
        int LocationID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            //if (!IsPostBack)
            //{
            //    if (Session["USER"] == null || string.IsNullOrEmpty(Session["USER"].ToString()))//error
            //    {
            //        Response.Redirect("/ACM/SessionTimeOut.aspx");
            //    }
            //    //if (Session["USER"] == null)
            //    //{
            //    //    Response.Redirect("Login.aspx");

            //    //}

            //    TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
            //    userID = ((USER_MST)Session["USER"]).USER_ID;
            //    LocationID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
            //    Session["Previous"] = Session["Current"];
            //    Session["Current"] = Request.RawUrl;
            //    if (Request.QueryString["MID"] != null)
            //    {
            //        string Menuid = Request.QueryString["MID"].ToString();
            //        string MenuName = Classes.GlobleClass.EncryptionHelpers.Decrypt(Menuid);
            //        string[] MenuidQwe = MenuName.Split('~');
            //        int MenuID = Convert.ToInt32(MenuidQwe[1]);

            //        DataTable dtMenu = ClsActivities.GetMenuName(MenuID);

            //        lblpagename.Text = dtMenu.Rows[0]["PageTitle"].ToString();
            //        lblpageid.Text = dtMenu.Rows[0]["NodeID"].ToString();


            //        //   haresh    // ltsMenu.DataSource = DB.tempUser.Where(p => p.ACTIVEMENU == true && p.MENU_TYPE == "Separator" && p.MODULE_ID == MID || p.AMIGLOBALE == 1).OrderBy(a => a.MENU_ORDER);
            //        // ltsMenu.DataBind();

            //    }

            //}

        }
        //    public string SessionLoad1(int TID, int LID, int UID, int EMPID, string LangID)
        //    {
        //        TID = Convert.ToInt32(((USER_MST)Session["USER"]).TenentID);
        //        LID = Convert.ToInt32(((USER_MST)Session["USER"]).LOCATION_ID);
        //        UID = Convert.ToInt32(((USER_MST)Session["USER"]).USER_ID);
        //        EMPID = Convert.ToInt32(((USER_MST)Session["USER"]).EmpID);
        //        LangID = Session["LANGUAGE"].ToString();
        //        string Ref = TID.ToString() + "," + LID.ToString() + "," + UID.ToString() + "," + EMPID.ToString() + "," + LangID;
        //        return Ref;
        //    }



        //    public string getOwnPage()
        //    {
        //        string PageID = "";
        //        if (Request.Url.AbsolutePath.Contains("Employee_Documents.aspx"))
        //        {
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "Employee_Documents.aspx").TableName;
        //        }
        //        else if (Request.Url.AbsolutePath.Contains("tempuser.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "tempuser.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("Acm_Function_Mst.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "Acm_FUNCTION_MST.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("MODULE_MST.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "ACM_MODULE_MST.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("NewCompaniySetup.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "MODULE_MST.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("USER_RIGHTS.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "ACM_USER_RIGHTS.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("ROLE_MST.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "ACM_ROLE_MST.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("MODULE_MAP.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "ACM_MODULE_MAP.aspx").TableName;

        //        else if (Request.Url.AbsolutePath.Contains("CorpDomainMng.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "CorpDomainMng.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("CorporationProduct.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "CorporationProduct.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("Technology.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "Technology.aspx").TableName;
        //        //MODULE_MAP
        //        else if (Request.Url.AbsolutePath.Contains("USER_ROLE.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "ACM_USER_ROLE.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("PRIVILAGE_MENU.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "ACM_PRIVILAGE_MENU.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("Web_User_Mst.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "Web_User_Mst.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("PRIVILEGE_MST.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "ACM_PRIVILEGE_MST.aspx").TableName;
        //        //else if (Request.Url.AbsolutePath.Contains("Forum.aspx"))
        //        //    PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "Forum.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("tbltranssubtype.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "tbltranssubtype.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("tbltranstype.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "tbltranstype.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("TBLSYSTEMS.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "TBLSYSTEMS.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("NewCompaniySetup_Tryel.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "NewCompaniySetup_Tryel.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("BlogForum.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "BlogForum.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("tblGallary.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "tblGallary.aspx").TableName;
        //        else if (Request.Url.AbsolutePath.Contains("tblWebsiteDataEntry.aspx"))
        //            PageID = DB.TBLLabelMSTs.Single(p => p.Active == true && p.PageName == "tblWebsiteDataEntry.aspx").TableName;
        //        //PRIVILEGE_MST
        //        return PageID;

        //    }
        //    public List<Database.TBLLabelDTL> Bindxml(string pagename)
        //    {
        //        DataSet ds = new DataSet();
        //        ds.ReadXml(Server.MapPath("//ACM//xml//" + pagename + ".xml"));
        //        List<Database.TBLLabelDTL> LblList = new List<Database.TBLLabelDTL>();
        //        if (ds != null && ds.HasChanges())
        //        {
        //            //ID,LabelMstID,FieldName,LabelID,Labe  lName,LangID,COUNTRYID,LANGDISP,Active

        //            foreach (DataRow dr in ds.Tables[0].Rows)
        //            {
        //                Database.TBLLabelDTL obj = new Database.TBLLabelDTL();
        //                LblList.Add(new Database.TBLLabelDTL
        //                {
        //                    ID = Convert.ToInt32(dr["ID"]),
        //                    LabelMstID = dr["LabelMstID"].ToString(),
        //                    FieldName = dr["FieldName"].ToString(),
        //                    LabelID = dr["LabelID"].ToString(),
        //                    LabelName = dr["LabelName"].ToString(),
        //                    LangID = Convert.ToInt32(dr["LangID"]),
        //                    COUNTRYID = Convert.ToInt32(dr["COUNTRYID"]),
        //                    LANGDISP = dr["LANGDISP"].ToString(),
        //                    Active = Convert.ToBoolean(dr["Active"])
        //                });
        //            }
        //            //string lang = "en-US";
        //            //int PID = ((AcmMaster)this.Master).getOwnPage();
        //            //List<TBLLabelDTL> List = LblList.Where(p => p.LabelMstID == PID && p.LANGDISP == lang).ToList();

        //        }
        //        return LblList;
        //    }
        //    public void Loadlist<T>(int Showdata, int take, int Skip, int ChoiceID, Label lblShowinfEntry, LinkButton btnPrevious, LinkButton btnNext, ListView Listview1, ListView ListView2, int Totalrec, List<T> List)
        //    {

        //        btnPrevious.Enabled = false;
        //        if (ViewState["Take"] != null && ViewState["Skip"] != null)
        //        {
        //            BindList(Listview1, (List.Take(take).Skip(Skip)).ToList());
        //            ViewState["Take"] = take;
        //            ViewState["Skip"] = Skip;
        //        }
        //        else
        //        {
        //            BindList(Listview1, (List.Take(Showdata).Skip(0)).ToList());
        //            ViewState["Take"] = Showdata;
        //            ViewState["Skip"] = 0;
        //        }
        //        ChoiceList.Clear();
        //        // int ChoiceID=
        //        for (int i = 0; i < 10; i++)
        //        {
        //            ChoiceID++;
        //            Navigation Obj = new Navigation();
        //            Obj.Choice = "";
        //            Obj.ID = ChoiceID;
        //            ChoiceList.Add(Obj);
        //        }
        //        ViewState["NDATA"] = ChoiceList;
        //        Navigation(ListView2);

        //        if (ViewState["Take"] != null && ViewState["Skip"] != null)
        //        {
        //            take = Showdata;
        //            Skip = 0;
        //            BindList(Listview1, (List.Take(take).Skip(Skip)).ToList());
        //            ViewState["Take"] = take;
        //            ViewState["Skip"] = Skip;
        //            btnPrevious.Enabled = false;
        //            ChoiceID = 0;
        //            GetCurrentNavigation(ChoiceID, Showdata, ListView2, Totalrec);
        //            if (take == Totalrec && Skip == (Totalrec - Showdata))
        //                btnNext.Enabled = false;
        //            else
        //                btnNext.Enabled = true;

        //        }
        //        lblShowinfEntry.Text = "Showing " + Skip + " to " + take + " of " + Totalrec + " entries";
        //    }
        //    #region Step5 Navigation
        //    public void Navigation(ListView ListView2)
        //    {
        //        //Navigati0n

        //        if (ViewState["NDATA"] != null)
        //        {
        //            ChoiceList = (List<Navigation>)ViewState["NDATA"];
        //        }
        //        else
        //        {
        //            ChoiceList = new List<Navigation>();
        //        }
        //        ListView2.DataSource = ChoiceList;
        //        ListView2.DataBind();
        //    }
        //    #endregion
        //    #region Step6 GetCurrentNavigation
        //    public void GetCurrentNavigation(int ChoiceID, int Showdata, ListView ListView2, int Totalrec)
        //    {
        //        int lastchoise = 0;
        //        ChoiceID = ChoiceID - 12;
        //        if (ChoiceID <= 0)
        //        {
        //            ChoiceID = 0;
        //        }
        //        ChoiceList.Clear();
        //        for (int i = 0; i < 10; i++)
        //        {
        //            ChoiceID++;
        //            lastchoise = Math.Abs(Totalrec / Showdata) + 2;
        //            if (lastchoise == ChoiceID)
        //                break;
        //            Navigation Obj = new Navigation();
        //            Obj.Choice = "";
        //            Obj.ID = ChoiceID;
        //            ChoiceList.Add(Obj);
        //        }
        //        ViewState["NDATA"] = ChoiceList;
        //        Navigation(ListView2);
        //    }
        //    public void GetCurrentNavigationLast(int ChoiceID, int Showdata, ListView ListView2, int Totalrec)
        //    {
        //        int lastchoise = 0;
        //        ChoiceID = ChoiceID - Showdata;
        //        if (ChoiceID <= 0)
        //        {
        //            ChoiceID = 0;
        //        }
        //        ChoiceList.Clear();
        //        for (int i = 0; i < 5; i++)
        //        {
        //            ChoiceID++;
        //            lastchoise = Math.Abs(Totalrec / Showdata) + 2;
        //            if (lastchoise == ChoiceID)
        //                break;
        //            Navigation Obj = new Navigation();
        //            Obj.Choice = "";
        //            Obj.ID = ChoiceID;
        //            ChoiceList.Add(Obj);
        //        }
        //        ViewState["NDATA"] = ChoiceList;
        //        Navigation(ListView2);
        //    }
        //    #endregion
        //    public void BindList<T>(ListView Listview1, List<T> List)
        //    {

        //        Listview1.DataSource = List;
        //        Listview1.DataBind();

        //    }

        //    internal void GetCurrentNavigation(int ChoiceID, int Showdata, ListView ListView2)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    internal void GetCurrentNavigationLast(int ChoiceID, int Showdata, ListView ListView2)
        //    {
        //        throw new NotImplementedException();
        //    }


        //}
        //}
        //#region Step2
        //[Serializable]
        //public class Navigation
        //{
        //    public string Choice { get; set; }
        //    public int ID { get; set; }

        //}
        //#endregion

    }
}