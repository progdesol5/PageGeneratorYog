using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Linq;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Transactions;
using Database;
namespace NewAdmin
{
public partial class CAT_MST : System.Web.UI.Page
{
    ERPEntities DB = new ERPEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
//	 if (!IsPostBack)
//        {
//		pnlSuccessMsg.Visible = false;
//		 FillContractorID();
//                int CurrentID = 1;
//                if (ViewState["Es"] != null)
//                {
//                    CurrentID = Convert.ToInt32(ViewState["Es"]);
//                }
//			BindData();
			
//             FirstData();
//			if (Request.QueryString.Count > 0)
//			{
//				int ID = Convert.ToInt32(Request.QueryString["ID"]);
//				Database.CAT_MST objCAT_MST = DB.CAT_MST.Single(p=>p.ID == ID);
//				//Server Content Recived data Yogesh
//				drpCATID.SelectedValue = objCAT_MST.CATID.ToString();
//drpPARENT_CATID.SelectedValue = objCAT_MST.PARENT_CATID.ToString();
//txtDefaultPic.Text = objCAT_MST.DefaultPic.ToString();
//txtSHORT_NAME.Text = objCAT_MST.SHORT_NAME.ToString();
//txtCAT_NAME1.Text = objCAT_MST.CAT_NAME1.ToString();
//txtCAT_NAME2.Text = objCAT_MST.CAT_NAME2.ToString();
//txtCAT_NAME3.Text = objCAT_MST.CAT_NAME3.ToString();
//txtCAT_DESCRIPTION.Text = objCAT_MST.CAT_DESCRIPTION.ToString();
//txtCAT_TYPE.Text = objCAT_MST.CAT_TYPE.ToString();
//txtWARRANTY.Text = objCAT_MST.WARRANTY.ToString();
//txtCRUP_ID.Text = objCAT_MST.CRUP_ID.ToString();
//txtActive.Text = objCAT_MST.Active.ToString();
//txtSupplierPercent.Text = objCAT_MST.SupplierPercent.ToString();
//txtswitch1.Text = objCAT_MST.switch1.ToString();
//txtswitch2.Text = objCAT_MST.switch2.ToString();
//txtswitch3.Text = objCAT_MST.switch3.ToString();
//txtDisplaySort.Text = objCAT_MST.DisplaySort.ToString();
//txtAlwaysShow.Text = objCAT_MST.AlwaysShow.ToString();
//txtUploadDate.Text = objCAT_MST.UploadDate.ToString();
//txtUploadby.Text = objCAT_MST.Uploadby.ToString();
//txtSyncDate.Text = objCAT_MST.SyncDate.ToString();
//txtSyncby.Text = objCAT_MST.Syncby.ToString();
//drpSynID.SelectedValue = objCAT_MST.SynID.ToString();
 
			//}
   //     }
    }
//	public void BindData()
//    {
//	        Listview1.DataSource = DB.CAT_MST.OrderBy(p=>p.0);
//            Listview1.DataBind();
//	}
//	protected void ListProduct_ItemCommand(object sender, ListViewCommandEventArgs e)
//        {
//            using (TransactionScope scope = new TransactionScope())
//            {
//                try
//                {
//                if (e.CommandName == "btnDelete")
//                {
//                    int ID = Convert.ToInt32(e.CommandArgument);
//                    Database.CAT_MST objCAT_MST = DB.CAT_MST.Single(p => p.ID == ID);
//                    objCAT_MST.Deleted = false;
                   
//                    DB.SaveChanges();
//					 DataBind();
//                    Response.Redirect("CAT_MSTList.aspx");
//                }
//				 if (e.CommandName == "btnEdit")
//                    {
//                        int ID = Convert.ToInt32(Request.QueryString["ID"]);
//				        Database.CAT_MST objCAT_MST = DB.CAT_MST.Single(p=>p.ID == ID);
//						drpCATID.SelectedValue = objCAT_MST.CATID.ToString();
//drpPARENT_CATID.SelectedValue = objCAT_MST.PARENT_CATID.ToString();
//txtDefaultPic.Text = objCAT_MST.DefaultPic.ToString();
//txtSHORT_NAME.Text = objCAT_MST.SHORT_NAME.ToString();
//txtCAT_NAME1.Text = objCAT_MST.CAT_NAME1.ToString();
//txtCAT_NAME2.Text = objCAT_MST.CAT_NAME2.ToString();
//txtCAT_NAME3.Text = objCAT_MST.CAT_NAME3.ToString();
//txtCAT_DESCRIPTION.Text = objCAT_MST.CAT_DESCRIPTION.ToString();
//txtCAT_TYPE.Text = objCAT_MST.CAT_TYPE.ToString();
//txtWARRANTY.Text = objCAT_MST.WARRANTY.ToString();
//txtCRUP_ID.Text = objCAT_MST.CRUP_ID.ToString();
//txtActive.Text = objCAT_MST.Active.ToString();
//txtSupplierPercent.Text = objCAT_MST.SupplierPercent.ToString();
//txtswitch1.Text = objCAT_MST.switch1.ToString();
//txtswitch2.Text = objCAT_MST.switch2.ToString();
//txtswitch3.Text = objCAT_MST.switch3.ToString();
//txtDisplaySort.Text = objCAT_MST.DisplaySort.ToString();
//txtAlwaysShow.Text = objCAT_MST.AlwaysShow.ToString();
//txtUploadDate.Text = objCAT_MST.UploadDate.ToString();
//txtUploadby.Text = objCAT_MST.Uploadby.ToString();
//txtSyncDate.Text = objCAT_MST.SyncDate.ToString();
//txtSyncby.Text = objCAT_MST.Syncby.ToString();
//drpSynID.SelectedValue = objCAT_MST.SynID.ToString();
 
//						 ViewState["Edit"] = ID;
//					}
//					scope.Complete(); //  To commit.
//				}
//                catch (Exception ex)
//                {
//                    throw;
//                }
//            }
//        }
		
//	protected void btnSave_Click(object sender, EventArgs e)
//    {
//	 using (TransactionScope scope = new TransactionScope())
//            {
//                try
//                {
//						 if (ViewState["Edit"] != null)
//                        {
//							int ID = Convert.ToInt32(ViewState["Edit"]);
//							Database.CAT_MST objCAT_MST = DB.CAT_MST.Single(p => p.ID == ID);
//							objCAT_MST.CATID = Convert.ToInt32(drpCATID.SelectedValue);
//objCAT_MST.PARENT_CATID = Convert.ToInt32(drpPARENT_CATID.SelectedValue);
//objCAT_MST.DefaultPic = txtDefaultPic.Text;
//objCAT_MST.SHORT_NAME = txtSHORT_NAME.Text;
//objCAT_MST.CAT_NAME1 = txtCAT_NAME1.Text;
//objCAT_MST.CAT_NAME2 = txtCAT_NAME2.Text;
//objCAT_MST.CAT_NAME3 = txtCAT_NAME3.Text;
//objCAT_MST.CAT_DESCRIPTION = txtCAT_DESCRIPTION.Text;
//objCAT_MST.CAT_TYPE = txtCAT_TYPE.Text;
//objCAT_MST.WARRANTY = txtWARRANTY.Text;
//objCAT_MST.CRUP_ID = txtCRUP_ID.Text;
//objCAT_MST.Active = txtActive.Text;
//objCAT_MST.SupplierPercent = Convert.ToDecimal(txtSupplierPercent.Text);
//objCAT_MST.switch1 = txtswitch1.Text;
//objCAT_MST.switch2 = txtswitch2.Text;
//objCAT_MST.switch3 = txtswitch3.Text;
//objCAT_MST.DisplaySort = txtDisplaySort.Text;
//objCAT_MST.AlwaysShow = txtAlwaysShow.Text;
//objCAT_MST.UploadDate = Convert.ToDateTime(txtUploadDate.Text);
//objCAT_MST.Uploadby = txtUploadby.Text;
//objCAT_MST.SyncDate = Convert.ToDateTime(txtSyncDate.Text);
//objCAT_MST.Syncby = txtSyncby.Text;
//objCAT_MST.SynID = Convert.ToInt32(drpSynID.SelectedValue);
 

//					    ViewState["Edit"] = null;
//                        btnAdd.Text = "Add New";
                        
//						}
//						else
//						{
//							Database.CAT_MST objCAT_MST = new Database.CAT_MST();
//							//Server Content Send data Yogesh
//							objCAT_MST.CATID = Convert.ToInt32(drpCATID.SelectedValue);
//objCAT_MST.PARENT_CATID = Convert.ToInt32(drpPARENT_CATID.SelectedValue);
//objCAT_MST.DefaultPic = txtDefaultPic.Text;
//objCAT_MST.SHORT_NAME = txtSHORT_NAME.Text;
//objCAT_MST.CAT_NAME1 = txtCAT_NAME1.Text;
//objCAT_MST.CAT_NAME2 = txtCAT_NAME2.Text;
//objCAT_MST.CAT_NAME3 = txtCAT_NAME3.Text;
//objCAT_MST.CAT_DESCRIPTION = txtCAT_DESCRIPTION.Text;
//objCAT_MST.CAT_TYPE = txtCAT_TYPE.Text;
//objCAT_MST.WARRANTY = txtWARRANTY.Text;
//objCAT_MST.CRUP_ID = txtCRUP_ID.Text;
//objCAT_MST.Active = txtActive.Text;
//objCAT_MST.SupplierPercent = Convert.ToDecimal(txtSupplierPercent.Text);
//objCAT_MST.switch1 = txtswitch1.Text;
//objCAT_MST.switch2 = txtswitch2.Text;
//objCAT_MST.switch3 = txtswitch3.Text;
//objCAT_MST.DisplaySort = txtDisplaySort.Text;
//objCAT_MST.AlwaysShow = txtAlwaysShow.Text;
//objCAT_MST.UploadDate = Convert.ToDateTime(txtUploadDate.Text);
//objCAT_MST.Uploadby = txtUploadby.Text;
//objCAT_MST.SyncDate = Convert.ToDateTime(txtSyncDate.Text);
//objCAT_MST.Syncby = txtSyncby.Text;
//objCAT_MST.SynID = Convert.ToInt32(drpSynID.SelectedValue);

							
//							DB.CAT_MST.AddObject(objCAT_MST);
//						}
//						DB.SaveChanges();
						
//				scope.Complete(); //  To commit.
//				lblMsg.Text = "  Data Edit Successfully";
//                pnlSuccessMsg.Visible = true;
//                }
//                catch (Exception ex)
//                {
//                    throw;
//                }
//            }
//        }
//	protected void btnCancel_Click(object sender, EventArgs e)
//    {
//       Response.Redirect("index.aspx");
//    }

//	 public void FillContractorID()
//        {
//			//drpCostAccount.Items.Insert(0, new ListItem("-- Select --", "0"));drpCostAccount.DataSource = DB.0;drpCostAccount.DataTextField = "0";drpCostAccount.DataValueField = "0";drpCostAccount.DataBind();
//		}
//protected void btnFirst_Click(object sender, EventArgs e)
//        {
//            FirstData();
//        }
//        protected void btnNext_Click(object sender, EventArgs e)
//        {
//            NextData();
//        }
//        protected void btnPrev_Click(object sender, EventArgs e)
//        {
//            PrevData();
//        }
//        protected void btnLast_Click(object sender, EventArgs e)
//        {
//            LastData();
//        }
//		 public void FirstData()
//        {
//            int index = Convert.ToInt32(ViewState["Index"]);
//            Listview1.SelectedIndex = 0;
//			//code
//		}
//		 public void NextData()
//        {

//            if (Listview1.SelectedIndex != Listview1.Items.Count - 1)
//            {
//                Listview1.SelectedIndex = Listview1.SelectedIndex + 1;
//				//code
//			}
			
//		}
//		 public void PrevData()
//        {
//		 if (Listview1.SelectedIndex == 0)
//            {
//                lblMsg.Text = "This is first record";
//                pnlSuccessMsg.Visible = true;
//				//code
//            }
//            else
//            {
//                pnlSuccessMsg.Visible = false;
//                Listview1.SelectedIndex = Listview1.SelectedIndex - 1;
//				//code
//			 }
//        }
//		 public void LastData()
//        {
//            Listview1.SelectedIndex = Listview1.Items.Count - 1;
//			//code
	//	}
}
}
