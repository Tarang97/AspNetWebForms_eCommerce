using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

public partial class ProductPgSlider : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        String imagelink;
        if(!IsPostBack)
        {
            BindProductPgSlider();
            btnUpdate.Visible = false;
            if(Request.QueryString["ppsid"] != null)
            {
                btnUpdate.Visible = true;
                btnSubmit.Visible = false;
                Int64 PPSID = Convert.ToInt64(Request.QueryString["ppsid"]);
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tblProductPgSlider WHERE ID = @ID", con);
                    cmd.Parameters.AddWithValue("@ID", PPSID);
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    if(ds.Tables[0].Rows.Count > 0)
                    {
                        tbImg1Txt1.Text = ds.Tables[0].Rows[0]["Text1Img1"].ToString();
                        tbImg1Txt2.Text = ds.Tables[0].Rows[0]["Text2Img1"].ToString();
                        tbImg1Txt3.Text = ds.Tables[0].Rows[0]["Text3Img1"].ToString();
                        imagelink = ds.Tables[0].Rows[0]["Image1"].ToString();
                        Image1.ImageUrl = "images/ProductPgSlider/"+imagelink+ ds.Tables[0].Rows[0]["Extension1"].ToString();

                        tbImg2Txt1.Text = ds.Tables[0].Rows[0]["Text1Img2"].ToString();
                        tbImg2Txt2.Text = ds.Tables[0].Rows[0]["Text2Img2"].ToString();
                        tbImg2Txt3.Text = ds.Tables[0].Rows[0]["Text3Img2"].ToString();
                        imagelink = ds.Tables[0].Rows[0]["Image2"].ToString();
                        Image2.ImageUrl = "images/ProductPgSlider/" + imagelink + ds.Tables[0].Rows[0]["Extension2"].ToString();

                        tbImg3Txt1.Text = ds.Tables[0].Rows[0]["Text1Img3"].ToString();
                        tbImg3Txt2.Text = ds.Tables[0].Rows[0]["Text2Img3"].ToString();
                        tbImg3Txt3.Text = ds.Tables[0].Rows[0]["Text3Img3"].ToString();
                        imagelink = ds.Tables[0].Rows[0]["Image3"].ToString() + ds.Tables[0].Rows[0]["Extension3"].ToString();
                        Image3.ImageUrl = "images/ProductPgSlider/" + imagelink;
                    }
                }
            }
            else
            {
                Image1.Visible = false;
                Image2.Visible = false;
                Image3.Visible = false;
                btnUpdate.Visible = false;
                btnSubmit.Visible = true;
            }
        }
    }

    private void BindProductPgSlider()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM tblProductPgSlider ORDER BY ID DESC", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            rptrImage.DataSource = dt;
            rptrImage.DataBind();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (fuImg1.HasFile && fuImg2.HasFile && fuImg3.HasFile)
        {
            string SavePath = Server.MapPath("~/images/ProductPgSlider/");
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

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblProductPgSlider VALUES('"+tbImg1Txt1.Text.Trim()+"','"+tbImg1Txt2.Text.Trim()+"','"
                    +tbImg1Txt3.Text.Trim()+"','"+ myGUID1 + "','"+Extension1+"','"+tbImg2Txt1.Text.Trim()+"','"
                    +tbImg2Txt2.Text.Trim()+"','"+tbImg2Txt3.Text.Trim()+"','"+ myGUID2 + "','"+Extension2+"','"
                    +tbImg3Txt1.Text.Trim()+"','"+tbImg3Txt2.Text.Trim()+"','"+tbImg3Txt3.Text.Trim()+"','"+myGUID3+"','"
                    +Extension3+"')", con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        Response.Redirect("ProductPgSlider.aspx");
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Int64 PPSID = Convert.ToInt64(Request.QueryString["ppsid"]);
        if(fuImg1.HasFile)
        {
            string SavePath = Server.MapPath("~/images/ProductPgSlider/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID4 = Guid.NewGuid().ToString();
            string Extension1 = Path.GetExtension(fuImg1.PostedFile.FileName);
            fuImg1.SaveAs(SavePath + "\\" + myGUID4 + Extension1);

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd1 = new SqlCommand("UPDATE tblProductPgSlider SET Text1Img1 = '" + tbImg1Txt1.Text + "',Text2Img1 = '" + tbImg1Txt2.Text + "',Text3Img1 = '"
                    + tbImg1Txt3.Text + "',Image1 = '" + myGUID4 + "',Extension1 = '" + Extension1 + "' WHERE ID = '"+PPSID+"'", con);
                con.Open();
                cmd1.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ProductPgSlider.aspx");
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd2 = new SqlCommand("UPDATE tblProductPgSlider SET Text1Img1 = '" + tbImg1Txt1.Text + "',Text2Img1 = '" + tbImg1Txt2.Text + "',Text3Img1 = '"
                    + tbImg1Txt3.Text + "' WHERE ID = '" + PPSID + "'", con);
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ProductPgSlider.aspx");
        }
        if(fuImg2.HasFile)
        {
            string SavePath = Server.MapPath("~/images/ProductPgSlider/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID5 = Guid.NewGuid().ToString();
            string Extension2 = Path.GetExtension(fuImg2.PostedFile.FileName);
            fuImg2.SaveAs(SavePath + "\\" + myGUID5 + Extension2);

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd3 = new SqlCommand("UPDATE tblProductPgSlider SET Text1Img2 = '"
                    + tbImg2Txt1.Text + "',Text2Img2 = '" + tbImg2Txt2.Text + "',Text3Img2 = '" + tbImg2Txt3.Text + "',Image2 = '"
                    + myGUID5 + "',Extension2 = '" + Extension2 + "' WHERE ID = '"+PPSID+"'", con);
                con.Open();
                cmd3.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ProductPgSlider.aspx");
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd4 = new SqlCommand("UPDATE tblProductPgSlider SET Text1Img2 = '"
                    + tbImg2Txt1.Text + "',Text2Img2 = '" + tbImg2Txt2.Text + "',Text3Img2 = '" + tbImg2Txt3.Text + "' WHERE ID = '" + PPSID + "'", con);
                con.Open();
                cmd4.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ProductPgSlider.aspx");
        }
        if(fuImg3.HasFile)
        {
            string SavePath = Server.MapPath("~/images/ProductPgSlider/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            String myGUID6 = Guid.NewGuid().ToString();
            string Extension3 = Path.GetExtension(fuImg3.PostedFile.FileName);
            fuImg3.SaveAs(SavePath + "\\" + myGUID6 + Extension3);

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd5 = new SqlCommand("UPDATE tblProductPgSlider SET Text1Img3 = '" + tbImg3Txt1.Text.Trim() + "',Text2Img3 = '"
                    + tbImg3Txt2.Text.Trim() + "',Text3Img3 = '" + tbImg3Txt3.Text.Trim() + "',Image3 = '" + myGUID6 + "',Extension3 = '" + Extension3 + "' WHERE ID = '"+PPSID+"'", con);
                con.Open();
                cmd5.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ProductPgSlider.aspx");
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd6 = new SqlCommand("UPDATE tblProductPgSlider SET Text1Img3 = '" + tbImg3Txt1.Text.Trim() + "',Text2Img3 = '"
                    + tbImg3Txt2.Text.Trim() + "',Text3Img3 = '" + tbImg3Txt3.Text.Trim() + "' WHERE ID = '" + PPSID + "'", con);
                con.Open();
                cmd6.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ProductPgSlider.aspx");
        }
        if (fuImg1.HasFile && fuImg2.HasFile && fuImg3.HasFile)
        {
            string SavePath = Server.MapPath("~/images/ProductPgSlider/");
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

            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblProductPgSlider SET Text1Img1 = '"+tbImg1Txt1.Text+"',Text2Img1 = '"+tbImg1Txt2.Text+"',Text3Img1 = '"
                    +tbImg1Txt3.Text+"',Image1 = '"+ myGUID1 + "',Extension1 = '"+Extension1+"',Text1Img2 = '"
                    +tbImg2Txt1.Text+"',Text2Img2 = '"+tbImg2Txt2.Text+"',Text3Img2 = '"+tbImg2Txt3.Text+"',Image2 = '"
                    + myGUID2 + "',Extension2 = '"+Extension2+"',Text1Img3 = '"+tbImg3Txt1.Text.Trim()+"',Text2Img3 = '"
                    +tbImg3Txt2.Text.Trim()+"',Text3Img3 = '"+tbImg3Txt3.Text.Trim()+"',Image3 = '"+ myGUID3 + "',Extension3 = '"+Extension3+"' WHERE ID = @ID", con);
                cmd.Parameters.AddWithValue("@ID", PPSID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ProductPgSlider.aspx");
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd7 = new SqlCommand("UPDATE tblProductPgSlider SET Text1Img1 = '" + tbImg1Txt1.Text + "',Text2Img1 = '" + tbImg1Txt2.Text + "',Text3Img1 = '"
                    + tbImg1Txt3.Text + "',Text1Img2 = '"+ tbImg2Txt1.Text + "',Text2Img2 = '" + tbImg2Txt2.Text + "',Text3Img2 = '" + tbImg2Txt3.Text + "',Text1Img3 = '" 
                    + tbImg3Txt1.Text.Trim() + "',Text2Img3 = '"+ tbImg3Txt2.Text.Trim() + "',Text3Img3 = '" + tbImg3Txt3.Text.Trim() + "' WHERE ID = @ID", con);
                cmd7.Parameters.AddWithValue("@ID", PPSID);
                con.Open();
                cmd7.ExecuteNonQuery();
                con.Close();
            }
            Response.Redirect("ProductPgSlider.aspx");
        }
    }
}