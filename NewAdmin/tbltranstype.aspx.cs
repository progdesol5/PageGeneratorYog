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
public partial class tbltranstype : System.Web.UI.Page
{
    ERPEntities DB = new ERPEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
	 if (!IsPostBack)
        {
		pnlSuccessMsg.Visible = false;
		 FillContractorID();
                int CurrentID = 1;
                if (ViewState["Es"] != null)
                {
                    CurrentID = Convert.ToInt32(ViewState["Es"]);
                }
			BindData();
			
             FirstData();
			if (Request.QueryString.Count > 0)
			{
				int ID = Convert.ToInt32(Request.QueryString["ID"]);
				Database.tbltranstype objtbltranstype = DB.tbltranstype.Single(p=>p.ID == ID);
				//Server Content Recived data Yogesh
				drptransid.SelectedValue = objtbltranstype.transid.ToString();
txtMYSYSNAME.Text = objtbltranstype.MYSYSNAME.ToString();
txtinoutSwitch.Text = objtbltranstype.inoutSwitch.ToString();
txttranstype1.Text = objtbltranstype.transtype1.ToString();
txttranstype2.Text = objtbltranstype.transtype2.ToString();
txttranstype3.Text = objtbltranstype.transtype3.ToString();
txtserialno.Text = objtbltranstype.serialno.ToString();
txtyears.Text = objtbltranstype.years.ToString();
 
			}
        }
    }
	public void BindData()
    {
	        Listview1.DataSource = DB.tbltranstype;
            Listview1.DataBind();
	}
	protected void ListProduct_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                if (e.CommandName == "btnDelete")
                {
                    int ID = Convert.ToInt32(e.CommandArgument);
                    Database.tbltranstype objtbltranstype = DB.tbltranstype.Single(p => p.ID == ID);
                    objtbltranstype.Deleted = false;
                   
                    DB.SaveChanges();
					 DataBind();
                    Response.Redirect("tbltranstypeList.aspx");
                }
				 if (e.CommandName == "btnEdit")
                    {
                        int ID = Convert.ToInt32(Request.QueryString["ID"]);
				        Database.tbltranstype objtbltranstype = DB.tbltranstype.Single(p=>p.ID == ID);
						drptransid.SelectedValue = objtbltranstype.transid.ToString();
txtMYSYSNAME.Text = objtbltranstype.MYSYSNAME.ToString();
txtinoutSwitch.Text = objtbltranstype.inoutSwitch.ToString();
txttranstype1.Text = objtbltranstype.transtype1.ToString();
txttranstype2.Text = objtbltranstype.transtype2.ToString();
txttranstype3.Text = objtbltranstype.transtype3.ToString();
txtserialno.Text = objtbltranstype.serialno.ToString();
txtyears.Text = objtbltranstype.years.ToString();
 
						 ViewState["Edit"] = ID;
					}
					scope.Complete(); //  To commit.
				}
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
		
	protected void btnSave_Click(object sender, EventArgs e)
    {
	 using (TransactionScope scope = new TransactionScope())
            {
                try
                {
						 if (ViewState["Edit"] != null)
                        {
							int ID = Convert.ToInt32(ViewState["Edit"]);
							Database.tbltranstype objtbltranstype = DB.tbltranstype.Single(p => p.ID == ID);
							objtbltranstype.transid = Convert.ToInt32(drptransid.SelectedValue);
objtbltranstype.MYSYSNAME = txtMYSYSNAME.Text;
objtbltranstype.inoutSwitch = txtinoutSwitch.Text;
objtbltranstype.transtype1 = txttranstype1.Text;
objtbltranstype.transtype2 = txttranstype2.Text;
objtbltranstype.transtype3 = txttranstype3.Text;
objtbltranstype.serialno = txtserialno.Text;
objtbltranstype.years = txtyears.Text;
 

					    ViewState["Edit"] = null;
                        btnAdd.Text = "Add New";
                        
						}
						else
						{
							Database.tbltranstype objtbltranstype = new Database.tbltranstype();
							//Server Content Send data Yogesh
							objtbltranstype.transid = Convert.ToInt32(drptransid.SelectedValue);
objtbltranstype.MYSYSNAME = txtMYSYSNAME.Text;
objtbltranstype.inoutSwitch = txtinoutSwitch.Text;
objtbltranstype.transtype1 = txttranstype1.Text;
objtbltranstype.transtype2 = txttranstype2.Text;
objtbltranstype.transtype3 = txttranstype3.Text;
objtbltranstype.serialno = txtserialno.Text;
objtbltranstype.years = txtyears.Text;

							
							DB.tbltranstype.AddObject(objtbltranstype);
						}
						DB.SaveChanges();
						
				scope.Complete(); //  To commit.
				lblMsg.Text = "  Data Edit Successfully";
                pnlSuccessMsg.Visible = true;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
	protected void btnCancel_Click(object sender, EventArgs e)
    {
       Response.Redirect("index.aspx");
    }

	 public void FillContractorID()
        {
			drpswitch1.Items.Insert(0, new ListItem("-- Select --", "0"));drpswitch1.DataSource = DB.0;drpswitch1.DataTextField = "0";drpswitch1.DataValueField = "0";drpswitch1.DataBind();
		}
protected void btnFirst_Click(object sender, EventArgs e)
        {
            FirstData();
        }
        protected void btnNext_Click(object sender, EventArgs e)
        {
            NextData();
        }
        protected void btnPrev_Click(object sender, EventArgs e)
        {
            PrevData();
        }
        protected void btnLast_Click(object sender, EventArgs e)
        {
            LastData();
        }
		 public void FirstData()
        {
            int index = Convert.ToInt32(ViewState["Index"]);
            Listview1.SelectedIndex = 0;
			//code
		}
		 public void NextData()
        {

            if (Listview1.SelectedIndex != Listview1.Items.Count - 1)
            {
                Listview1.SelectedIndex = Listview1.SelectedIndex + 1;
				//code
			}
			
		}
		 public void PrevData()
        {
		 if (Listview1.SelectedIndex == 0)
            {
                lblMsg.Text = "This is first record";
                pnlSuccessMsg.Visible = true;
				//code
            }
            else
            {
                pnlSuccessMsg.Visible = false;
                Listview1.SelectedIndex = Listview1.SelectedIndex - 1;
				//code
			 }
        }
		 public void LastData()
        {
            Listview1.SelectedIndex = Listview1.Items.Count - 1;
			//code
		}
}
}
