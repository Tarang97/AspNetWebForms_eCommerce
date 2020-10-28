using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Specialized;

public partial class ProductDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["product"] != null)
            {
                int id = 0;
                if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["product"].ToString()), out id))
                {
                    BindProductImages(id);
                    BindProductDetails(id);
                    BindProductCommentRptr(id);
                    DataTable dt = this.GetData("SELECT ISNULL(AVG(Rating), 0) AverageRating, COUNT(Rating) RatingCount FROM tblPrdRating WHERE PrdID = '"+id+"'");
                    Rating1.CurrentRating = Convert.ToInt32(dt.Rows[0]["AverageRating"]);
                    Label1.Text = string.Format("{0} Users have rated. Average Rating {1}", dt.Rows[0]["RatingCount"], dt.Rows[0]["AverageRating"]);
                }
                if (Session["USERNAME"] != null)
                {
                    string USERNAME = Session["USERNAME"].ToString();
                    lblUReview.Text = USERNAME;
                }
                else
                {
                    lblUReview.Text = "Guest";
                }
            }
            else
            {
                Response.Redirect("~/Products.aspx");
            }
        }
    }

    private void BindProductCommentRptr(int id)
    {
        //Int64 PID = Convert.ToInt64(Request.QueryString["product"]);
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblComments A INNER JOIN tblPrdRating AS B ON B.PrdID = A.PID WHERE PID = @CommentPID ORDER BY CommentID DESC", con))
            {
                cmd.Parameters.AddWithValue("@CommentPID", id);
                con.Open();
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrComments.DataSource = dt;
                    rptrComments.DataBind();

                    if (dt.Rows.Count == 0)
                    {
                        lblCommentsError.Text = "There are no Comments for this Product!";
                    }
                }
            }
        }
    }

    private void BindProductDetails(int id)
    {
        //Int64 PID = Convert.ToInt64(Request.QueryString["product"]);
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblProducts WHERE PID = @ProductFName", con))
            {
                cmd.Parameters.AddWithValue("@ProductFName", id);
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtImages = new DataTable();
                    sda.Fill(dtImages);
                    if (dtImages.Rows.Count != 0)
                    {
                        Page.Title = dtImages.Rows[0]["PName"].ToString();
                    }
                    rptrProductDetails.DataSource = dtImages;
                    rptrProductDetails.DataBind();
                }
            }
        }
    }

    private void BindProductImages(int id)
    {
        //Int64 PID = Convert.ToInt64(Request.QueryString["product"]);
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblProductImages WHERE PID = '" + id + "'", con))
            {
                cmd.CommandType = CommandType.Text;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    DataTable dtImages = new DataTable();
                    sda.Fill(dtImages);
                    rptrImages.DataSource = dtImages;
                    rptrImages.DataBind();
                }
            }
        }
    }

    protected string GetActiveClass(int ItemIndex)
    {
        if (ItemIndex == 0)
        {
            return "active";
        }
        else
        {
            return "";
        }
    }

    protected void rptrProductDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //Int64 WID = Convert.ToInt64(Request.QueryString["product"]);
        int id = 0;
        if (Request.QueryString["product"] != null)
        {
            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["product"].ToString()), out id))
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    string BrandID = (e.Item.FindControl("hfBrandID") as HiddenField).Value;
                    string CatID = (e.Item.FindControl("hfCatID") as HiddenField).Value;
                    string SubCatID = (e.Item.FindControl("hfSubCatID") as HiddenField).Value;
                    string GenderID = (e.Item.FindControl("hfGenderID") as HiddenField).Value;

                    DropDownList ddlSize = e.Item.FindControl("ddlSize") as DropDownList;
                    Label lbSize = e.Item.FindControl("lblNone") as Label;

                    String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                    if (Session["USERID"] != null)
                    {
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblProductSizeQuantity WHERE PID=" + id + " and BrandID=" + BrandID +
                                " and CategoryID=" + CatID + " and SubCategoryID=" + SubCatID +
                                " and GenderID=" + GenderID + "", con))
                            {
                                cmd.CommandType = CommandType.Text;
                                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                {
                                    DataTable dtSizes = new DataTable();
                                    sda.Fill(dtSizes);
                                    if (dtSizes.Rows.Count != 0)
                                    {
                                        ddlSize.DataSource = dtSizes;
                                        ddlSize.DataTextField = "SizeName";
                                        ddlSize.DataValueField = "SizeName";
                                        ddlSize.DataBind();
                                    }
                                    else
                                    {
                                        ddlSize.Items.Insert(0, new ListItem("- None -", "None"));
                                    }
                                }
                            }
                        }

                        LinkButton btn = (e.Item.FindControl("lbWishlist") as LinkButton);
                        Label lb = (e.Item.FindControl("lblAlready") as Label);
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            string USERID = Session["USERID"].ToString();
                            SqlCommand cmd = new SqlCommand("SELECT * FROM tblWishlist WHERE Username = @Username AND ProductID = @MOB", con);
                            cmd.Parameters.AddWithValue("@Username", USERID);
                            cmd.Parameters.AddWithValue("@MOB", id);
                            con.Open();
                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            DataTable dtWish = new DataTable();
                            sda.Fill(dtWish);
                            if (dtWish.Rows.Count > 0)
                            {
                                lb.Text = "Product is Already in Wishlist";
                                btn.Visible = false;
                            }
                            else
                            {
                                btn.Visible = true;
                            }
                        }
                    }
                    else
                    {
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblProductSizeQuantity WHERE PID=" + id + " and BrandID=" + BrandID +
                            " and CategoryID=" + CatID + " and SubCategoryID=" + SubCatID +
                            " and GenderID=" + GenderID + "", con))
                            {
                                cmd.CommandType = CommandType.Text;
                                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                                {
                                    DataTable dtSizes = new DataTable();
                                    sda.Fill(dtSizes);
                                    if (dtSizes.Rows.Count != 0)
                                    {
                                        ddlSize.DataSource = dtSizes;
                                        ddlSize.DataTextField = "SizeName";
                                        ddlSize.DataValueField = "SizeName";
                                        ddlSize.DataBind();
                                    }
                                    else
                                    {
                                        ddlSize.Items.Insert(0, new ListItem("- None -", "None"));
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        int id = 0;

        if (Session["EMAIL"] != null)
        {
            if (Request.QueryString["product"] != null)
            {
                if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["product"].ToString()), out id))
                {
                    string SelectedSize = string.Empty;
                    string SelectedQty = string.Empty;
                    string SelectedDlvy = string.Empty;

                    foreach (RepeaterItem item in rptrProductDetails.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            var rbList = item.FindControl("ddlSize") as DropDownList;
                            SelectedSize = rbList.SelectedValue;

                            var Qty = item.FindControl("tbQuantity") as TextBox;
                            SelectedQty = Qty.Text;

                            var Dlvy = item.FindControl("ddlDelivery") as DropDownList;
                            SelectedDlvy = Dlvy.SelectedValue;

                            var None = item.FindControl("lblNone") as Label;
                            None.Text = "";

                            var SizeError = item.FindControl("lblSError") as Label;
                            SizeError.Text = "";
                        }
                    }

                    if (SelectedSize != "" && SelectedQty != "" && SelectedDlvy != "")
                    {
                        string USERID = Session["USERID"].ToString();
                        String myGUID = Guid.NewGuid().ToString();

                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            SqlCommand cmd = new SqlCommand("SELECT * FROM tblCart WHERE Username = @User AND ProductID = @Product", con);
                            cmd.Parameters.AddWithValue("@User", USERID);
                            cmd.Parameters.AddWithValue("@Product", id);
                            con.Open();
                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();
                            sda.Fill(ds);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                {
                                    if (USERID == ds.Tables[0].Rows[0]["Username"].ToString() && id == Convert.ToInt64(ds.Tables[0].Rows[0]["ProductID"]))
                                    {
                                        SqlCommand cmd1 = new SqlCommand("UPDATE tblCart SET Quantity = @Qty, DeliveryOpt = @DlvyOpt WHERE Username = @User AND ProductID = @Product", con);
                                        cmd1.Parameters.AddWithValue("@Qty", SelectedQty);
                                        cmd1.Parameters.AddWithValue("@DlvyOpt", SelectedDlvy);
                                        cmd1.Parameters.AddWithValue("@User", USERID);
                                        cmd1.Parameters.AddWithValue("@Product", id);
                                        cmd1.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        SqlCommand cmd2 = new SqlCommand("INSERT INTO tblCart VALUES(@PID,@User,@SizeName,@Qty,@Dlvy,@UID)", con);
                                        cmd2.Parameters.AddWithValue("@PID", id);
                                        cmd2.Parameters.AddWithValue("@User", USERID);
                                        cmd2.Parameters.AddWithValue("@SizeName", SelectedSize);
                                        cmd2.Parameters.AddWithValue("@Qty", SelectedQty);
                                        cmd2.Parameters.AddWithValue("@Dlvy", SelectedDlvy);
                                        cmd2.Parameters.AddWithValue("@UID", myGUID);
                                        cmd2.ExecuteNonQuery();
                                    }
                                }
                            }
                            else
                            {
                                SqlCommand cmd3 = new SqlCommand("INSERT INTO tblCart VALUES(@PID,@User,@SizeName,@Qty,@Dlvy,@UID)", con);
                                cmd3.Parameters.AddWithValue("@PID", id);
                                cmd3.Parameters.AddWithValue("@User", USERID);
                                cmd3.Parameters.AddWithValue("@SizeName", SelectedSize);
                                cmd3.Parameters.AddWithValue("@Qty", SelectedQty);
                                cmd3.Parameters.AddWithValue("@Dlvy", SelectedDlvy);
                                cmd3.Parameters.AddWithValue("@UID", myGUID);
                                cmd3.ExecuteNonQuery();
                            }
                        }
                        Response.Redirect("ProductDetails.aspx?product=" + Request.QueryString["product"]);
                    }
                    else
                    {
                        foreach (RepeaterItem item in rptrProductDetails.Items)
                        {
                            if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                            {
                                var None = item.FindControl("lblNone") as Label;
                                None.Text = "Quantity is required";

                                var SizeError = item.FindControl("lblSError") as Label;
                                SizeError.Text = "Please select a size";
                            }
                        }
                    }
                }
            }
        }
        else
        {
            Response.Redirect("~/Login.aspx");
        }
    }

    protected void btnSubmitReview_Click(object sender, EventArgs e)
    {
        int id = 0;
        if (Session["EMAIL"] != null)
        {
            if (Request.QueryString["product"] != null)
            {
                if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["product"].ToString()), out id))
                {
                    if (tbRReview.Text != "")
                    {
                        //Int64 PID = Convert.ToInt64(Request.QueryString["product"]);
                        string USERNAME = Session["USERNAME"].ToString();
                        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(CS))
                        {
                            SqlCommand cmd = new SqlCommand("INSERT INTO tblComments VALUES(@PID,@UserName,@UserComment,@DateofComment)", con);
                            cmd.Parameters.AddWithValue("@PID", id);
                            cmd.Parameters.AddWithValue("@UserName", USERNAME);
                            cmd.Parameters.AddWithValue("@UserComment", tbRReview.Text.Trim());
                            cmd.Parameters.AddWithValue("@DateofComment", DateTime.Now);
                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                        Response.Redirect("ProductDetails.aspx?product=" + Request.QueryString["product"]);
                    }
                    else
                    {
                        lblError.Text = "Please fill the Required Fields!";
                    }
                }
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void lbWishlist_Click(object sender, EventArgs e)
    {
        if (Session["USERID"] != null)
        {
            String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
            string USERID = Session["USERID"].ToString();
            LinkButton btn = (LinkButton)(sender);
            string PID = btn.CommandArgument;
            String myGUID = Guid.NewGuid().ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblWishlist VALUES(@User,@PerProduct,@UID)", con);
                cmd.Parameters.AddWithValue("@User", USERID);
                cmd.Parameters.AddWithValue("@PerProduct", PID);
                cmd.Parameters.AddWithValue("@UID", myGUID);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("Wishlist.aspx");
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    private DataTable GetData(string query)
    {
        DataTable dt = new DataTable();
        String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
        using (SqlConnection con = new SqlConnection(CS))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
            }
            return dt;
        }
    }

    //protected void Rating1_Click(object sender, AjaxControlToolkit.RatingEventArgs e)
    //{
    //    int id = 0;
    //    if (Session["EMAIL"] != null)
    //    {
    //        if (Request.QueryString["product"] != null)
    //        {
    //            if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["product"].ToString()), out id))
    //            {
    //                String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    //                using (SqlConnection con = new SqlConnection(CS))
    //                {
    //                    using (SqlCommand cmd = new SqlCommand("INSERT INTO tblPrdRating VALUES(@Rating,@ProductID,@Date)", con))
    //                    {
    //                        cmd.Parameters.AddWithValue("@Rating", e.Value.ToString());
    //                        cmd.Parameters.AddWithValue("@ProductID", id);
    //                        cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
    //                        con.Open();
    //                        cmd.ExecuteNonQuery();
    //                        con.Close();
    //                    }
    //                }
    //                Response.Redirect("ProductDetails.aspx?product=" + Request.QueryString["product"]);
    //            }
    //        }
    //    }
    //    else
    //    {
    //        ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Please Login to Rate this Product');window.location='ProductDetails.aspx?product=" + Request.QueryString["product"] + "';</script>");
    //    }
    //}

    protected void Rating1_Click(object sender, AjaxControlToolkit.RatingEventArgs e)
    {
        int id = 0;
        if (Session["EMAIL"] != null)
        {
            if (Request.QueryString["product"] != null)
            {
                if (int.TryParse(MirrorOfBrands.Crypto.GetdecryptQueryString(Request.QueryString["product"].ToString()), out id))
                {
                    String USERID = Session["USERID"].ToString();
                    String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
                    using (SqlConnection con = new SqlConnection(CS))
                    {
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO tblPrdRating VALUES(@Rating,@ProductID,@Date,@UID)", con))
                        {
                            cmd.Parameters.AddWithValue("@Rating", e.Value.ToString());
                            cmd.Parameters.AddWithValue("@ProductID", id);
                            cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString());
                            cmd.Parameters.AddWithValue("@UID", USERID);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Success", "<script type='text/javascript'>alert('Please Login to Rate this Product');window.location='ProductDetails.aspx?product=" + Request.QueryString["product"] + "';</script>");
        }
    }
}