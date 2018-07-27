using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BAL;
using FitnessCenter.BO;
using FitnessCenter.DAL;

namespace FitnessCenter
{
    public partial class POS : System.Web.UI.Page
    {

        public long GroupId
        {
            get
            {
                var obj = ViewState["GroupId"];
                return obj == null ? 0 : (long)obj;

            }
            set
            {
                ViewState["GroupId"] = value;
            }
        }

        public long ItemId
        {
            get
            {
                var obj = ViewState["ItemId"];
                return obj == null ? 0 : (long)obj;

            }
            set
            {
                ViewState["ItemId"] = value;
            }
        }

        public decimal Total
        {
            get
            {
                var obj = ViewState["Total"];
                return obj == null ? 0 : (decimal)obj;
            }
            set
            {
                ViewState["Total"] = value;
            }
        }

        public User LoginUser
        {
            get
            {
                var obj = Session["LoginUser"];
                return obj == null ? null : (User)obj;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            MenuLIVisibility();
            string ctrlname = Page.Request.Params.Get("__EVENTTARGET");
            if (GroupId > 0)
            {
                ItemVisibility(GroupId);
            }
        }

        //protected void btn222_Click(object sender, EventArgs e)
        //{
        //    decimal a = 0, b = 0, c = 0;
        //    txtItem1.Text = "Masala Tea";
        //    txtQty1.Text = "1";
        //    txtRate1.Text = "20";
        //    a = Convert.ToDecimal(txtQty1.Text);
        //    b = Convert.ToDecimal(txtRate1.Text);
        //    Total = a * b;
        //    txtAmount1.Text = Total.ToString();
        //    txtTotal.Text = Total.ToString();

        //}

        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    decimal a = 0, b = 0, c = 0, d = 0;
        //    txtItem2.Text = "Coffe Shot";
        //    txtQTY2.Text = "1";
        //    txtRate2.Text = "20";
        //    a = Convert.ToDecimal(txtQTY2.Text);
        //    b = Convert.ToDecimal(txtRate2.Text);
        //    txtAmount2.Text = (a * b).ToString();
        //    if (txtAmount2.Text == "")
        //        c = 0;
        //    else
        //        c = Convert.ToDecimal(txtAmount1.Text);
        //    d = Convert.ToDecimal(txtAmount2.Text);
        //    txtTotal.Text = (c + d).ToString();
        //}

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("POS.aspx");
        //}

        //protected void Button4_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("POS.aspx");
        //}

        //protected void Button6_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("POS.aspx");
        //}

        protected void txtQty1_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, c = 0, d = 0, f = 0, g = 0;
            a = Convert.ToDecimal(txtRate1.Text);
            b = Convert.ToDecimal(txtQty1.Text);
            txtAmount1.Text = (a * b).ToString();
            c = Convert.ToDecimal(txtAmount1.Text);
            d = Convert.ToDecimal(txtAmount2.Text);
            f = Convert.ToDecimal(txtAmount3.Text);
            g = c + d + f;
            txtTotal.Text = (Total + c).ToString();

        }

        protected void txtQTY2_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, c = 0, d = 0, f = 0, g = 0;
            a = Convert.ToDecimal(txtRate1.Text);
            b = Convert.ToDecimal(txtQty1.Text);
            txtAmount2.Text = (a * b).ToString();
            c = Convert.ToDecimal(txtAmount2.Text);
            d = Convert.ToDecimal(txtAmount1.Text);
            //f = convert.todecimal(txtamount3.text);
            g = c + d;
            txtTotal.Text = g.ToString();
        }

        protected void txtQty3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtReceived_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0;
            a = Convert.ToDecimal(txtTotal.Text);
            b = Convert.ToDecimal(txtReceived.Text);
            if (b < a)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Enter Grater Tha or Equal Too Total');", true);
            }
            else
                txtChange.Text = (b - a).ToString();
        }

        protected void btn1_Click(object sender, EventArgs e)
        {
            txtReceived.Text += "1";
        }

        protected void btn2_Click(object sender, EventArgs e)
        {
            txtReceived.Text += "2";
        }

        protected void btn3_Click(object sender, EventArgs e)
        {
            txtReceived.Text += "3";
        }

        protected void btn4_Click(object sender, EventArgs e)
        {
            txtReceived.Text += "4";
        }

        protected void btn5_Click(object sender, EventArgs e)
        {
            txtReceived.Text += "5";
        }

        protected void btn6_Click(object sender, EventArgs e)
        {
            txtReceived.Text += "6";
        }

        protected void btn7_Click(object sender, EventArgs e)
        {
            txtReceived.Text += "7";
        }

        protected void btn8_Click(object sender, EventArgs e)
        {
            txtReceived.Text += "8";
        }

        protected void btn9_Click(object sender, EventArgs e)
        {
            txtReceived.Text += "9";
        }

        protected void btn0_Click(object sender, EventArgs e)
        {
            txtReceived.Text += "0";
        }

        protected void btnErase_Click(object sender, EventArgs e)
        {
            txtReceived.Text = "";
            txtTotal.Text = "";
            txtChange.Text = "";
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            decimal a = 0, b = 0;
            if (txtTotal.Text == "")
            {
                txtTotal.Text = "0";
            }
            a = Convert.ToDecimal(txtTotal.Text);
            b = Convert.ToDecimal(txtReceived.Text);
            if (b < a)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Enter Grater Tha or Equal Too Total');", true);
            }
            else
                txtChange.Text = (b - a).ToString();
        }

        private void MenuLIVisibility()
        {
            string ltrMenuLIString = string.Empty;
            // var objItem = ItemController.GetGroups(LoginUser.clubId);
            List<GroupMaster> lstGetSuperAdmin = new FitnessCenterEntities().GroupMasters.Where(x => x.isDeleted == false).ToList();
            foreach (var item in lstGetSuperAdmin)
            {

                Button btn = new Button();
                btn.Text = item.name.ToString();
                btn.ID = "btnGrp" + item.ID.ToString();
                btn.Attributes.Add("data-id", item.ID.ToString());
                btn.Click += new EventHandler(button_Click);
                pnlGroups.Controls.Add(btn);
                if (item.ID % 2 == 1)
                    btn.CssClass = " btn btn1";
                else
                    btn.CssClass = "btn btn2";
            }
        }

        protected void button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Error', 'Selected Button Group = " + btn.ID + " ')", true);
            GroupId = Convert.ToInt32(btn.Attributes["data-id"]);
            ItemVisibility(GroupId);
        }

        private void ItemVisibility(long GroupId)
        {
            try
            {
                pnlItems.Controls.Clear();
                string ltrItemLIString = string.Empty;
                List<ItemMaster> lstGetItem = new FitnessCenterEntities().ItemMasters.Where(x => x.isDeleted == false && x.groupId == GroupId).ToList();
                foreach (var items in lstGetItem)
                {
                    Button btnItem = new Button();
                    btnItem.Text = items.name.ToString();
                    btnItem.ID = "btnItem" + items.ID.ToString();
                    btnItem.Attributes.Add("data-id", items.ID.ToString());
                    btnItem.Click += new EventHandler(buttonItem_Click);
                    
                    pnlItems.Controls.Add(btnItem);
                    if (items.ID % 2 == 1)
                        btnItem.CssClass = " btn btn1";
                    else
                        btnItem.CssClass = "btn btn2";
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void buttonItem_Click(object sender, EventArgs e)
        {
            //ItemVisibility();
            Button btnItem = sender as Button;
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Error', 'Selected Button Item = " + btnItem.ID + " ')", true);
            ItemId = Convert.ToInt32(btnItem.Attributes["data-id"]);

            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Error', 'Selected Button = " + ItemId + " ')", true);

            abc();
        }
        private void abc()
        {
            try
            {
                List<ItemMaster> lstGetItem = new FitnessCenterEntities().ItemMasters.Where(x => x.isDeleted == false && x.ID == ItemId).ToList();
                foreach (var item in lstGetItem)
                {

                    decimal a = 0, b = 0;
                    
                    if(txtItem1.Text == "")
                    {
                        txtItem1.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty1.Text = "1";

                        txtRate1.Text = item.mrp.ToString();
                        b = Convert.ToDecimal(txtQty1.Text);
                        txtAmount1.Text = (b * a).ToString();
                    }
                    else if (txtItem2.Text == "" && txtItem1.Text != "")
                    {
                        txtItem2.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty2.Text = "1";

                        txtRate2.Text = item.mrp.ToString();
                        b = Convert.ToDecimal(txtQty2.Text);
                        txtAmount2.Text = (b * a).ToString();
                    }
                    

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}