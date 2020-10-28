using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

public partial class FeaturedCategoriesImg : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            BindFeaturedCat();
            if(Request.QueryString["fcid"] != null)
            {
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
            }
            else
            {
                btnAdd.Visible = true;
                btnUpdate.Visible = false;
            }
        }
    }

    private void BindFeaturedCat()
    {
        String imagelink;
        String redirectlink;
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblFeatCatImg", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count != 0)
            {
                lblID.Text = dt.Rows[0]["FCID"].ToString();
                redirectlink = lblID.Text;
                imagelink = dt.Rows[0]["Image1"].ToString() + dt.Rows[0]["Extension1"].ToString();
                Image1.ImageUrl = "images/FeaturedCategories/" + imagelink;
                Extension1.Text = dt.Rows[0]["Extension1"].ToString();

                imagelink = dt.Rows[0]["Image2"].ToString() + dt.Rows[0]["Extension2"].ToString();
                Image2.ImageUrl = "images/FeaturedCategories/" + imagelink;
                Extension2.Text = dt.Rows[0]["Extension2"].ToString();

                imagelink = dt.Rows[0]["Image3"].ToString() + dt.Rows[0]["Extension3"].ToString();
                Image3.ImageUrl = "images/FeaturedCategories/" + imagelink;
                Extension3.Text = dt.Rows[0]["Extension3"].ToString();

                imagelink = dt.Rows[0]["Image4"].ToString() + dt.Rows[0]["Extension4"].ToString();
                Image4.ImageUrl = "images/FeaturedCategories/" + imagelink;
                Extension4.Text = dt.Rows[0]["Extension4"].ToString();

                imagelink = dt.Rows[0]["Image5"].ToString() + dt.Rows[0]["Extension5"].ToString();
                Image5.ImageUrl = "images/FeaturedCategories/" + imagelink;
                Extension5.Text = dt.Rows[0]["Extension5"].ToString();

                imagelink = dt.Rows[0]["Image6"].ToString() + dt.Rows[0]["Extension6"].ToString();
                Image6.ImageUrl = "images/FeaturedCategories/" + imagelink;
                Extension6.Text = dt.Rows[0]["Extension6"].ToString();

                HyperLink1.NavigateUrl = "FeaturedCategoriesImg.aspx?fcid="+redirectlink;
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Int64 FeatID = Convert.ToInt64(Request.QueryString["fcid"]);

        if(fuImg1.HasFile)
        {
            string SavePath = Server.MapPath("~/images/FeaturedCategories/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID = Guid.NewGuid().ToString();
            string Extension1 = Path.GetExtension(fuImg1.PostedFile.FileName);
            fuImg1.SaveAs(SavePath + "\\" + myGUID + Extension1);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd1 = new SqlCommand("UPDATE tblFeatCatImg SET Image1 = '" + myGUID + "', Extension1 = '"
                    + Extension1 + "' WHERE FCID = '" + FeatID + "'", con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("FeaturedCategoriesImg.aspx");
        }
        if (fuImg2.HasFile)
        {
            string SavePath = Server.MapPath("~/images/FeaturedCategories/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID2 = Guid.NewGuid().ToString();
            string Extension2 = Path.GetExtension(fuImg2.PostedFile.FileName);
            fuImg2.SaveAs(SavePath + "\\" + myGUID2 + Extension2);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd2 = new SqlCommand("UPDATE tblFeatCatImg SET Image2 = '" + myGUID2 + "', Extension2 = '"
                    + Extension2 + "' WHERE FCID = '" + FeatID + "'", con);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("FeaturedCategoriesImg.aspx");
        }
        if (fuImg3.HasFile)
        {
            string SavePath = Server.MapPath("~/images/FeaturedCategories/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID3 = Guid.NewGuid().ToString();
            string Extension3 = Path.GetExtension(fuImg3.PostedFile.FileName);
            fuImg3.SaveAs(SavePath + "\\" + myGUID3 + Extension3);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd3 = new SqlCommand("UPDATE tblFeatCatImg SET Image3 = '" + myGUID3 + "', Extension3 = '"
                    + Extension3 + "' WHERE FCID = '" + FeatID + "'", con);
                con.Open();
                cmd3.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("FeaturedCategoriesImg.aspx");
        }
        if (fuImg4.HasFile)
        {
            string SavePath = Server.MapPath("~/images/FeaturedCategories/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID4 = Guid.NewGuid().ToString();
            string Extension4 = Path.GetExtension(fuImg4.PostedFile.FileName);
            fuImg4.SaveAs(SavePath + "\\" + myGUID4 + Extension4);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd4 = new SqlCommand("UPDATE tblFeatCatImg SET Image4 = '" + myGUID4 + "', Extension4 = '"
                    + Extension4 + "' WHERE FCID = '" + FeatID + "'", con);
                con.Open();
                cmd4.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("FeaturedCategoriesImg.aspx");
        }
        if (fuImg5.HasFile)
        {
            string SavePath = Server.MapPath("~/images/FeaturedCategories/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID5 = Guid.NewGuid().ToString();
            string Extension5 = Path.GetExtension(fuImg5.PostedFile.FileName);
            fuImg5.SaveAs(SavePath + "\\" + myGUID5 + Extension5);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd5 = new SqlCommand("UPDATE tblFeatCatImg SET Image5 = '" + myGUID5 + "', Extension5 = '"
                    + Extension5 + "' WHERE FCID = '" + FeatID + "'", con);
                con.Open();
                cmd5.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("FeaturedCategoriesImg.aspx");
        }
        if (fuImg6.HasFile)
        {
            string SavePath = Server.MapPath("~/images/FeaturedCategories/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID6 = Guid.NewGuid().ToString();
            string Extension6 = Path.GetExtension(fuImg6.PostedFile.FileName);
            fuImg6.SaveAs(SavePath + "\\" + myGUID6 + Extension6);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd6 = new SqlCommand("UPDATE tblFeatCatImg SET Image6 = '" + myGUID6 + "', Extension6 = '"
                    + Extension6 + "' WHERE FCID = '" + FeatID + "'", con);
                con.Open();
                cmd6.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("FeaturedCategoriesImg.aspx");
        }
        if (fuImg1.HasFile && fuImg2.HasFile && fuImg3.HasFile && fuImg4.HasFile && fuImg5.HasFile && fuImg6.HasFile)
        {
            string SavePath = Server.MapPath("~/images/FeaturedCategories/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID1 = Guid.NewGuid().ToString();
            string Extension1 = Path.GetExtension(fuImg1.PostedFile.FileName);
            fuImg1.SaveAs(SavePath + "\\" + myGUID1 + Extension1);

            String myGUID2 = Guid.NewGuid().ToString();
            string Extension2 = Path.GetExtension(fuImg2.PostedFile.FileName);
            fuImg2.SaveAs(SavePath + "\\" + myGUID2 + Extension2);

            String myGUID3 = Guid.NewGuid().ToString();
            string Extension3 = Path.GetExtension(fuImg3.PostedFile.FileName);
            fuImg3.SaveAs(SavePath + "\\" + myGUID3 + Extension3);

            String myGUID4 = Guid.NewGuid().ToString();
            string Extension4 = Path.GetExtension(fuImg4.PostedFile.FileName);
            fuImg4.SaveAs(SavePath + "\\" + myGUID4 + Extension4);

            String myGUID5 = Guid.NewGuid().ToString();
            string Extension5 = Path.GetExtension(fuImg5.PostedFile.FileName);
            fuImg5.SaveAs(SavePath + "\\" + myGUID5 + Extension5);

            String myGUID6 = Guid.NewGuid().ToString();
            string Extension6 = Path.GetExtension(fuImg6.PostedFile.FileName);
            fuImg6.SaveAs(SavePath + "\\" + myGUID6 + Extension6);

            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE tblFeatCatImg SET Image1 = '"+myGUID1+"', Extension1 = '"
                    +Extension1+"', Image2 = '"+myGUID2+"', Extension2 = '"+Extension2+"', Image3 = '"
                    +myGUID3+"', Extension3 = '"+Extension3+"', Image4 = '"+myGUID4+"', Extension4 = '"
                    +Extension4+"', Image5 = '"+myGUID5+"', Extension5 = '"+Extension5+"', Image6 = '"
                    +myGUID6+"', Extension6 = '"+Extension6+"' WHERE FCID = '"+FeatID+"' ", con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            Response.Redirect("FeaturedCategoriesImg.aspx");
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (fuImg1.HasFile && fuImg2.HasFile && fuImg3.HasFile && fuImg4.HasFile && fuImg5.HasFile && fuImg6.HasFile)
        {
            string SavePath = Server.MapPath("~/images/FeaturedCategories/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID1 = Guid.NewGuid().ToString();
            string Extension1 = Path.GetExtension(fuImg1.PostedFile.FileName);
            fuImg1.SaveAs(SavePath + "\\" + myGUID1 + Extension1);

            String myGUID2 = Guid.NewGuid().ToString();
            string Extension2 = Path.GetExtension(fuImg2.PostedFile.FileName);
            fuImg2.SaveAs(SavePath + "\\" + myGUID2 + Extension2);

            String myGUID3 = Guid.NewGuid().ToString();
            string Extension3 = Path.GetExtension(fuImg3.PostedFile.FileName);
            fuImg3.SaveAs(SavePath + "\\" + myGUID3 + Extension3);

            String myGUID4 = Guid.NewGuid().ToString();
            string Extension4 = Path.GetExtension(fuImg4.PostedFile.FileName);
            fuImg4.SaveAs(SavePath + "\\" + myGUID4 + Extension4);

            String myGUID5 = Guid.NewGuid().ToString();
            string Extension5 = Path.GetExtension(fuImg5.PostedFile.FileName);
            fuImg5.SaveAs(SavePath + "\\" + myGUID5 + Extension5);

            String myGUID6 = Guid.NewGuid().ToString();
            string Extension6 = Path.GetExtension(fuImg6.PostedFile.FileName);
            fuImg6.SaveAs(SavePath + "\\" + myGUID6 + Extension6);

            using (SqlConnection con = new SqlConnection(CS))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO tblFeatCatImg VALUES('"+myGUID1+"','"+Extension1+"','"
                    +myGUID2+"','"+Extension2+"','"+myGUID3+"','"+Extension3+"','"+myGUID4+"','"
                    +Extension4+"','"+myGUID5+"','"+Extension5+"','"+myGUID6+"','"
                    +Extension6+"')", con))
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            Response.Redirect("FeaturedCategoriesImg.aspx");
        }
    }
}