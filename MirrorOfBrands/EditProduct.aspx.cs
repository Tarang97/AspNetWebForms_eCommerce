using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EditProduct : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(Request.QueryString["pid"] != null)
            {
                BindBrands();
                BindCategory();
                BindGender();
                ddlSubCategory.Enabled = false;
                ddlGender.Enabled = false;

                Int64 PID = Convert.ToInt64(Request.QueryString["pid"]);
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblProducts WHERE PID = @Product", con);
                    cmd.Parameters.AddWithValue("@Product", PID);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection | CommandBehavior.SingleResult | CommandBehavior.SingleRow);
                    while (sdr.Read())
                    {
                        txtPName.Text = sdr.GetString(1);
                        txtPPrice.Text = (sdr["PPrice"].ToString());
                        txtSelPrice.Text = (sdr["PSelPrice"].ToString());
                        txtDesc.Text = sdr.GetString(8);
                        txtPDetails.Text = sdr.GetString(9);
                        txtMatCare.Text = sdr.GetString(10);
                        txtDiscOffer.Text = sdr.GetDecimal(14).ToString();
                        ddlStatus.SelectedItem.Text = sdr.GetString(15);
                        ddlPrdOpt.SelectedItem.Text = sdr.GetString(16);
                    }

                }

                Int64 PQuantID = Convert.ToInt64(Request.QueryString["pid"]);
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Quantity FROM tblProductSizeQuantity WHERE PID = '"+ PQuantID + "'", con);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        txtQuantity.Text = ds.Tables[0].Rows[0]["Quantity"].ToString();
                    }
                }

                Int64 PImgID = Convert.ToInt64(Request.QueryString["pid"]);
                using (SqlConnection con = new SqlConnection(CS))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM tblProductImages WHERE PID = '" + PImgID + "'", con))
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
            else
            {
                Response.Redirect("~/ViewProduct.aspx");
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

    private void BindGender()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblGender", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlGender.DataSource = dt;
                ddlGender.DataTextField = "GenderName";
                ddlGender.DataValueField = "GenderID";
                ddlGender.DataBind();
                ddlGender.Items.Insert(0, new ListItem("- Select Gender -", "0"));
            }
        }
    }

    private void BindCategory()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblCategories", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlCategory.DataSource = dt;
                ddlCategory.DataTextField = "CatName";
                ddlCategory.DataValueField = "CatID";
                ddlCategory.DataBind();
                ddlCategory.Items.Insert(0, new ListItem("- Select Category -", "0"));
            }
        }
    }

    private void BindBrands()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblBrands", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlBrands.DataSource = dt;
                ddlBrands.DataTextField = "Name";
                ddlBrands.DataValueField = "BrandID";
                ddlBrands.DataBind();
                ddlBrands.Items.Insert(0, new ListItem("- Select Brand -", "0"));
            }
        }
    }

    protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblBrands WHERE MainCatID = '" + ddlCategory.SelectedItem.Value + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlBrands.DataSource = dt;
                ddlBrands.DataTextField = "Name";
                ddlBrands.DataValueField = "BrandID";
                ddlBrands.DataBind();
                ddlBrands.Items.Insert(0, new ListItem("- Select Brand -", "0"));
                ddlBrands.Enabled = true;
            }
        }

        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubCategories WHERE MainCatID = '" + ddlCategory.SelectedItem.Value + "' ", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                ddlSubCategory.DataSource = dt;
                ddlSubCategory.DataTextField = "SubCatName";
                ddlSubCategory.DataValueField = "SubCatID";
                ddlSubCategory.DataBind();
                ddlSubCategory.Items.Insert(0, new ListItem("- Select Sub Catgeory -", "0"));
                ddlSubCategory.Enabled = true;
            }
        }
    }

    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlSubCategory.SelectedIndex != 0)
        {
            ddlGender.Enabled = true;
        }
    }

    protected void ddlGender_SelectedIndexChanged(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblSizes WHERE BrandID = '" + ddlBrands.SelectedItem.Value + "' AND CategoryID = '" + ddlCategory.SelectedItem.Value + "' AND SubCategoryID = '" + ddlSubCategory.SelectedItem.Value + "' AND GenderID = '" + ddlGender.SelectedItem.Value + "'", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count != 0)
            {
                cblSize.DataSource = dt;
                cblSize.DataTextField = "SizeName";
                cblSize.DataValueField = "SizeID";
                cblSize.DataBind();
                //cblSize.Items.Insert(0, new ListItem("- Select Size -", "0"));
            }
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        // For Products
        Int64 PID = Convert.ToInt64(Request.QueryString["pid"]);
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("procUpdateProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PID", SqlDbType.BigInt).Value = Request.QueryString["pid"];
            cmd.Parameters.AddWithValue("@PName", txtPName.Text);
            cmd.Parameters.AddWithValue("@PPrice", txtPPrice.Text);
            cmd.Parameters.AddWithValue("@PSelPrice", txtSelPrice.Text);
            cmd.Parameters.AddWithValue("@PCategoryID", ddlCategory.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@PBrandID", ddlBrands.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@PSubCatID", ddlSubCategory.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@PGender", ddlGender.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@PDescription", txtDesc.Text);
            cmd.Parameters.AddWithValue("@PProductDetails", txtPDetails.Text);
            cmd.Parameters.AddWithValue("@PMaterialCare", txtMatCare.Text);
            cmd.Parameters.AddWithValue("@PDiscount", txtDiscOffer.Text);
            cmd.Parameters.AddWithValue("@Live", ddlStatus.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Option", ddlPrdOpt.SelectedItem.Text);

            //Free Delivery
            if (cbFD.Checked == true)
            {
                cmd.Parameters.AddWithValue("@FreeDelivery", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@FreeDelivery", 0.ToString());
            }

            //10 Day Return
            if (cb10Ret.Checked == true)
            {
                cmd.Parameters.AddWithValue("@DayReturns", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@DayReturns", 0.ToString());
            }

            // Cash On Delivery
            if (cbCOD.Checked == true)
            {
                cmd.Parameters.AddWithValue("@COD", 1.ToString());
            }
            else
            {
                cmd.Parameters.AddWithValue("@COD", 0.ToString());
            }
            con.Open();
            cmd.ExecuteNonQuery();
            if(cblSize.SelectedItem != null)
            {
                using (SqlCommand cmd2 = new SqlCommand("DELETE FROM tblProductSizeQuantity WHERE PID = '" + PID + "'", con))
                {
                    cmd2.ExecuteNonQuery();
                }
                // Insert Size Quantity
                for (int i = 0; i < cblSize.Items.Count; i++)
                {
                    if (cblSize.Items[i].Selected == true)
                    {
                        Int64 SizeID = Convert.ToInt64(cblSize.Items[i].Value);
                        string SizeName = cblSize.Items[i].Text;
                        int Quantity = Convert.ToInt32(txtQuantity.Text);
                        SqlCommand cmd1 = new SqlCommand("INSERT INTO tblProductSizeQuantity VALUES('" + PID + "','" + SizeID + "','" + Quantity + "','" + SizeName + "','" + ddlBrands.SelectedItem.Value + "','" + ddlCategory.SelectedItem.Value + "','" + ddlSubCategory.SelectedItem.Value + "','" + ddlGender.SelectedItem.Value + "')", con);
                        cmd1.ExecuteNonQuery();
                    }
                }
            }
            
            
            // IMage 1
            if(fuImg01.HasFile)
            {
                using (SqlCommand cmd3 = new SqlCommand("DELETE FROM tblProductImages WHERE PID = '"+PID+"'", con))
                {
                    cmd3.ExecuteNonQuery();
                }
                string SavePath = Server.MapPath("~/images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                string Extension = Path.GetExtension(fuImg01.PostedFile.FileName);
                fuImg01.SaveAs(SavePath + "\\" + txtPName.Text.ToString().Trim() + "01" + Extension);

                SqlCommand cmd4 = new SqlCommand("INSERT INTO tblProductImages VALUES('" + PID + "','" + txtPName.Text.ToString().Trim() + "01" + "','" + Extension + "')", con);
                cmd4.ExecuteNonQuery();
            }
            // IMage 2
            if(fuImg02.HasFile)
            {
                string SavePath = Server.MapPath("~/images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                string Extension = Path.GetExtension(fuImg02.PostedFile.FileName);
                fuImg02.SaveAs(SavePath + "\\" + txtPName.Text.ToString().Trim() + "02" + Extension);

                SqlCommand cmd6 = new SqlCommand("INSERT INTO tblProductImages VALUES('" + PID + "','" + txtPName.Text.ToString().Trim() + "02" + "','" + Extension + "')", con);
                cmd6.ExecuteNonQuery();
            }
            // Image 3
            if(fuImg03.HasFile)
            {                
                string SavePath = Server.MapPath("~/images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                string Extension = Path.GetExtension(fuImg03.PostedFile.FileName);
                fuImg03.SaveAs(SavePath + "\\" + txtPName.Text.ToString().Trim() + "03" + Extension);

                SqlCommand cmd8 = new SqlCommand("INSERT INTO tblProductImages VALUES('" + PID + "','" + txtPName.Text.ToString().Trim() + "03" + "','" + Extension + "')", con);
                cmd8.ExecuteNonQuery();
            }
            // IMage 4
            if(fuImg04.HasFile)
            {
                string SavePath = Server.MapPath("~/images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                string Extension = Path.GetExtension(fuImg04.PostedFile.FileName);
                fuImg04.SaveAs(SavePath + "\\" + txtPName.Text.ToString().Trim() + "04" + Extension);

                SqlCommand cmd10 = new SqlCommand("INSERT INTO tblProductImages VALUES('" + PID + "','" + txtPName.Text.ToString().Trim() + "04" + "','" + Extension + "')", con);
                cmd10.ExecuteNonQuery();
            }
            // IMage 5
            if(fuImg05.HasFile)
            {
                string SavePath = Server.MapPath("~/images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                string Extension = Path.GetExtension(fuImg05.PostedFile.FileName);
                fuImg05.SaveAs(SavePath + "\\" + txtPName.Text.ToString().Trim() + "05" + Extension);

                SqlCommand cmd12 = new SqlCommand("INSERT INTO tblProductImages VALUES('" + PID + "','" + txtPName.Text.ToString().Trim() + "05" + "','" + Extension + "')", con);
                cmd12.ExecuteNonQuery();
            }           
        }
        Response.Redirect("~/ViewProduct.aspx");
    }
}