using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FitnessCenter.BAL;
using FitnessCenter.BO;
using FitnessCenter.DAL;
using System.Drawing;

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
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate1.Text);
            b = Convert.ToDecimal(txtQty1.Text);
            txtAmount1.Text = (a * b).ToString();

            xyz();

        }

        protected void txtQTY2_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate2.Text);
            b = Convert.ToDecimal(txtQty2.Text);
            txtAmount2.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty3_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate3.Text);
            b = Convert.ToDecimal(txtQty3.Text);
            txtAmount3.Text = (a * b).ToString();

            xyz();
        }

        protected void txtReceived_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0;
            a = Convert.ToDecimal(txtTotal.Text);
            if (txtReceived.Text == "")
                b = 0;
            else
                b = Convert.ToDecimal(txtReceived.Text);

            if (b < a)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_msg", "MessageBox('Error','Please Enter Grater Tha or Equal Too Total');", true);
                txtChange.Text = "";
                txtReceived.Text = "";
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
            // var objItem = ItemController.GetGroups(LoginUser.ClubId);
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
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Error', 'Selected Button Group = " + btn.ID + " ')", true);
            GroupId = Convert.ToInt32(btn.Attributes["data-id"]);
            ItemVisibility(GroupId);
            btnBack.Visible = btnForward.Visible = true;
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
            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Error', 'Selected Button Item = " + btnItem.ID + " ')", true);
            ItemId = Convert.ToInt32(btnItem.Attributes["data-id"]);

            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Error', 'Selected Button = " + ItemId + " ')", true);

            abc();
            xyz();
        }
        private void abc()
        {
            try
            {
                List<ItemMaster> lstGetItem = new FitnessCenterEntities().ItemMasters.Where(x => x.isDeleted == false && x.ID == ItemId).ToList();
                foreach (var item in lstGetItem)
                {

                    decimal a = 0, b = 0;

                    if (txtItem1.Text == "")
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

                    else if (txtItem3.Text == "" && txtItem2.Text != "")
                    {
                        txtItem3.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty3.Text = "1";

                        txtRate3.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty3.Text);
                        txtAmount3.Text = (b * a).ToString();
                    }

                    else if (txtItem4.Text == "" && txtItem3.Text != "")
                    {
                        txtItem4.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty4.Text = "1";

                        txtRate4.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty4.Text);
                        txtAmount4.Text = (b * a).ToString();
                    }

                    else if (txtItem5.Text == "" && txtItem4.Text != "")
                    {
                        txtItem5.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty5.Text = "1";

                        txtRate5.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty5.Text);
                        txtAmount5.Text = (b * a).ToString();
                    }
                    else if (txtItem6.Text == "" && txtItem5.Text != "")
                    {
                        txtItem6.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty6.Text = "1";

                        txtRate6.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty6.Text);
                        txtAmount6.Text = (b * a).ToString();
                    }
                    else if (txtItem7.Text == "" && txtItem6.Text != "")
                    {
                        txtItem7.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty7.Text = "1";

                        txtRate7.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty7.Text);
                        txtAmount7.Text = (b * a).ToString();
                    }

                    else if (txtItem8.Text == "" && txtItem7.Text != "")
                    {
                        txtItem8.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty8.Text = "1";

                        txtRate8.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty8.Text);
                        txtAmount8.Text = (b * a).ToString();
                    }

                    else if (txtItem9.Text == "" && txtItem8.Text != "")
                    {
                        txtItem9.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty9.Text = "1";

                        txtRate9.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty9.Text);
                        txtAmount9.Text = (b * a).ToString();
                    }
                    else if (txtItem10.Text == "" && txtItem9.Text != "")
                    {
                        txtItem10.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty10.Text = "1";

                        txtRate10.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty10.Text);
                        txtAmount10.Text = (b * a).ToString();
                    }
                    else if (txtItem11.Text == "" && txtItem10.Text != "")
                    {
                        txtItem11.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty11.Text = "1";

                        txtRate11.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty11.Text);
                        txtAmount11.Text = (b * a).ToString();
                    }
                    else if (txtItem12.Text == "" && txtItem11.Text != "")
                    {
                        txtItem12.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty12.Text = "1";

                        txtRate12.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty12.Text);
                        txtAmount12.Text = (b * a).ToString();
                    }

                    else if (txtItem13.Text == "" && txtItem12.Text != "")
                    {
                        txtItem13.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty13.Text = "1";

                        txtRate13.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty13.Text);
                        txtAmount13.Text = (b * a).ToString();
                    }

                    else if (txtItem14.Text == "" && txtItem13.Text != "")
                    {
                        txtItem14.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty14.Text = "1";

                        txtRate14.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty14.Text);
                        txtAmount14.Text = (b * a).ToString();
                    }

                    else if (txtItem15.Text == "" && txtItem14.Text != "")
                    {
                        txtItem15.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty15.Text = "1";

                        txtRate15.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty15.Text);
                        txtAmount15.Text = (b * a).ToString();
                    }
                    else if (txtItem16.Text == "" && txtItem15.Text != "")
                    {
                        txtItem16.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty16.Text = "1";

                        txtRate16.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty16.Text);
                        txtAmount16.Text = (b * a).ToString();
                    }

                    else if (txtItem17.Text == "" && txtItem16.Text != "")
                    {
                        txtItem17.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty17.Text = "1";

                        txtRate17.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty17.Text);
                        txtAmount17.Text = (b * a).ToString();
                    }
                    else if (txtItem18.Text == "" && txtItem17.Text != "")
                    {
                        txtItem18.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty18.Text = "1";

                        txtRate18.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty18.Text);
                        txtAmount18.Text = (b * a).ToString();
                    }
                    else if (txtItem19.Text == "" && txtItem18.Text != "")
                    {
                        txtItem19.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty19.Text = "1";

                        txtRate19.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty19.Text);
                        txtAmount19.Text = (b * a).ToString();
                    }
                    else if (txtItem20.Text == "" && txtItem19.Text != "")
                    {
                        txtItem20.Text = item.name.ToString();
                        a = item.mrp;
                        txtQty20.Text = "1";

                        txtRate20.Text = a.ToString();
                        b = Convert.ToDecimal(txtQty20.Text);
                        txtAmount20.Text = (b * a).ToString();
                    }
                    else if (txtItem20.Text != "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "err_valid", "MessageBox('Error', 'Limit Over Save This 20 Item Than Add New Item ')", true);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void xyz()
        {
            try
            {
                decimal a1 = 0, a2 = 0, a3 = 0, a4 = 0, a5 = 0, a6 = 0, a7 = 0, a8 = 0, a9 = 0, a10 = 0;
                decimal a11 = 0, a12 = 0, a13 = 0, a14 = 0, a15 = 0, a16 = 0, a17 = 0, a18 = 0, a19 = 0, a20 = 0;
                if (txtAmount1.Text != "")
                    a1 = Convert.ToDecimal(txtAmount1.Text);
                if (txtAmount2.Text != "")
                    a2 = Convert.ToDecimal(txtAmount2.Text);
                if (txtAmount3.Text != "")
                    a3 = Convert.ToDecimal(txtAmount3.Text);
                if (txtAmount4.Text != "")
                    a4 = Convert.ToDecimal(txtAmount4.Text);
                if (txtAmount5.Text != "")
                    a5 = Convert.ToDecimal(txtAmount5.Text);

                if (txtAmount6.Text != "")
                    a6 = Convert.ToDecimal(txtAmount6.Text);
                if (txtAmount7.Text != "")
                    a7 = Convert.ToDecimal(txtAmount7.Text);
                if (txtAmount8.Text != "")
                    a8 = Convert.ToDecimal(txtAmount8.Text);
                if (txtAmount9.Text != "")
                    a9 = Convert.ToDecimal(txtAmount9.Text);
                if (txtAmount10.Text != "")
                    a10 = Convert.ToDecimal(txtAmount10.Text);

                if (txtAmount11.Text != "")
                    a11 = Convert.ToDecimal(txtAmount11.Text);
                if (txtAmount12.Text != "")
                    a12 = Convert.ToDecimal(txtAmount12.Text);
                if (txtAmount13.Text != "")
                    a13 = Convert.ToDecimal(txtAmount13.Text);
                if (txtAmount14.Text != "")
                    a14 = Convert.ToDecimal(txtAmount14.Text);
                if (txtAmount15.Text != "")
                    a15 = Convert.ToDecimal(txtAmount15.Text);

                if (txtAmount16.Text != "")
                    a16 = Convert.ToDecimal(txtAmount16.Text);
                if (txtAmount17.Text != "")
                    a17 = Convert.ToDecimal(txtAmount17.Text);
                if (txtAmount18.Text != "")
                    a18 = Convert.ToDecimal(txtAmount18.Text);
                if (txtAmount19.Text != "")
                    a19 = Convert.ToDecimal(txtAmount19.Text);
                if (txtAmount20.Text != "")
                    a20 = Convert.ToDecimal(txtAmount20.Text);

                txtTotal.Text = (a1 + a2 + a3 + a4 + a5 + a6 + a7 + a8 + a9 + a10 + a11 + a12 + a13 + a14 + a15 + a16 + a17 + a18 + a19 + a20).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtQty4_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate4.Text);
            b = Convert.ToDecimal(txtQty4.Text);
            txtAmount4.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty5_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate5.Text);
            b = Convert.ToDecimal(txtQty5.Text);
            txtAmount5.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty6_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate6.Text);
            b = Convert.ToDecimal(txtQty6.Text);
            txtAmount6.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty7_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate7.Text);
            b = Convert.ToDecimal(txtQty7.Text);
            txtAmount7.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty8_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate8.Text);
            b = Convert.ToDecimal(txtQty8.Text);
            txtAmount8.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty9_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate9.Text);
            b = Convert.ToDecimal(txtQty9.Text);
            txtAmount9.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty10_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate10.Text);
            b = Convert.ToDecimal(txtQty10.Text);
            txtAmount10.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty11_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate11.Text);
            b = Convert.ToDecimal(txtQty11.Text);
            txtAmount11.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty12_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate12.Text);
            b = Convert.ToDecimal(txtQty12.Text);
            txtAmount12.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty13_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate13.Text);
            b = Convert.ToDecimal(txtQty13.Text);
            txtAmount13.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty14_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate14.Text);
            b = Convert.ToDecimal(txtQty14.Text);
            txtAmount14.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty15_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate15.Text);
            b = Convert.ToDecimal(txtQty15.Text);
            txtAmount15.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty16_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate16.Text);
            b = Convert.ToDecimal(txtQty16.Text);
            txtAmount16.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty17_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate17.Text);
            b = Convert.ToDecimal(txtQty17.Text);
            txtAmount17.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty18_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate18.Text);
            b = Convert.ToDecimal(txtQty18.Text);
            txtAmount18.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty19_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate19.Text);
            b = Convert.ToDecimal(txtQty19.Text);
            txtAmount19.Text = (a * b).ToString();

            xyz();
        }

        protected void txtQty20_TextChanged(object sender, EventArgs e)
        {
            decimal a = 0, b = 0, g = 0;
            a = Convert.ToDecimal(txtRate20.Text);
            b = Convert.ToDecimal(txtQty20.Text);
            txtAmount20.Text = (a * b).ToString();

            xyz();
        }


    }
}