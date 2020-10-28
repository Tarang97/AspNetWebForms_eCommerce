using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
public partial class AddProduct : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindBrands();
            BindCategory();
            BindGender();
            
            ddlSubCategory.Enabled = false;
            ddlGender.Enabled = false;
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("procInsertProducts", con);
            cmd.CommandType = CommandType.StoredProcedure;
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
            if(cbFD.Checked == true)
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
            Int64 PID = Convert.ToInt64(cmd.ExecuteScalar());

            // Insert Size Quantity
            for(int i = 0; i < cblSize.Items.Count; i++)
            {
                if(cblSize.Items[i].Selected == true)
                {
                    Int64 SizeID = Convert.ToInt64(cblSize.Items[i].Value);
                    string SizeName = cblSize.Items[i].Text;
                    int Quantity = Convert.ToInt32(txtQuantity.Text);

                    SqlCommand cmd1 = new SqlCommand("INSERT INTO tblProductSizeQuantity VALUES('"+PID+"','"+SizeID+"','"+Quantity+ "','" + SizeName + "','" + ddlBrands.SelectedItem.Value+"','"+ddlCategory.SelectedItem.Value+"','"+ddlSubCategory.SelectedItem.Value+"','"+ddlGender.SelectedItem.Value+"')",con);
                    cmd1.ExecuteNonQuery();
                }
            }

            // Insert and Upload Images
            // Image 1
            if(fuImg01.HasFile)
            {
                string SavePath = Server.MapPath("~/images/ProductImages/") + PID;
                if(!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                string Extension = Path.GetExtension(fuImg01.PostedFile.FileName);
                fuImg01.SaveAs(SavePath + "\\" + txtPName.Text.ToString().Trim() + "01" + Extension);

                SqlCommand cmd2 = new SqlCommand("INSERT INTO tblProductImages VALUES('" + PID + "','" + txtPName.Text.ToString().Trim() + "01" + "','" + Extension + "')", con);
                cmd2.ExecuteNonQuery();
            }

            // Image 2
            if (fuImg02.HasFile)
            {
                string SavePath = Server.MapPath("~/images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                string Extension = Path.GetExtension(fuImg02.PostedFile.FileName);
                fuImg02.SaveAs(SavePath + "\\" + txtPName.Text.ToString().Trim() + "02" + Extension);

                SqlCommand cmd3 = new SqlCommand("INSERT INTO tblProductImages VALUES('" + PID + "','" + txtPName.Text.ToString().Trim() + "02" + "','" + Extension + "')", con);
                cmd3.ExecuteNonQuery();
            }

            // Image 3
            if (fuImg03.HasFile)
            {
                string SavePath = Server.MapPath("~/images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                string Extension = Path.GetExtension(fuImg03.PostedFile.FileName);
                fuImg03.SaveAs(SavePath + "\\" + txtPName.Text.ToString().Trim() + "03" + Extension);

                SqlCommand cmd4 = new SqlCommand("INSERT INTO tblProductImages VALUES('" + PID + "','" + txtPName.Text.ToString().Trim() + "03" + "','" + Extension + "')", con);
                cmd4.ExecuteNonQuery();
            }

            // Image 4
            if (fuImg04.HasFile)
            {
                string SavePath = Server.MapPath("~/images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                string Extension = Path.GetExtension(fuImg04.PostedFile.FileName);
                fuImg04.SaveAs(SavePath + "\\" + txtPName.Text.ToString().Trim() + "04" + Extension);

                SqlCommand cmd5 = new SqlCommand("INSERT INTO tblProductImages VALUES('" + PID + "','" + txtPName.Text.ToString().Trim() + "04" + "','" + Extension + "')", con);
                cmd5.ExecuteNonQuery();
            }

            // Image 5
            if (fuImg05.HasFile)
            {
                string SavePath = Server.MapPath("~/images/ProductImages/") + PID;
                if (!Directory.Exists(SavePath))
                {
                    Directory.CreateDirectory(SavePath);
                }
                string Extension = Path.GetExtension(fuImg05.PostedFile.FileName);
                fuImg05.SaveAs(SavePath + "\\" + txtPName.Text.ToString().Trim() + "05" + Extension);

                SqlCommand cmd6 = new SqlCommand("INSERT INTO tblProductImages VALUES('" + PID + "','" + txtPName.Text.ToString().Trim() + "05" + "','" + Extension + "')", con);
                cmd6.ExecuteNonQuery();
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
        //int MainCategoryID = Convert.ToInt32(ddlCategory.SelectedItem.Value);
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
        //using (SqlConnection con = new SqlConnection(CS))
        //{
        //    SqlCommand cmd = new SqlCommand("SELECT * FROM tblSubCategories WHERE MainCatID = '" + ddlCategory.SelectedItem.Value + "' ", con);
        //    con.Open();
        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    sda.Fill(dt);

        //    if (dt.Rows.Count != 0)
        //    {
        //        ddlSubCategory.DataSource = dt;
        //        ddlSubCategory.DataTextField = "SubCatName";
        //        ddlSubCategory.DataValueField = "SubCatID";
        //        ddlSubCategory.DataBind();
        //        ddlSubCategory.Items.Insert(0, new ListItem("- Select Sub Catgeory -", "0"));
        //        ddlSubCategory.Enabled = true;
        //    }
        //}
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

    protected void ddlSubCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(ddlSubCategory.SelectedIndex != 0)
        {
            ddlGender.Enabled = true;
        }
    }
}