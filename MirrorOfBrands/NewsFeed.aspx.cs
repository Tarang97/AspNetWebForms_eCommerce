using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;

public partial class NewsFeed : System.Web.UI.Page
{
    public static String CS = ConfigurationManager.ConnectionStrings["MirrorOfBrandsDB"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        BindNewsFeed();
        btnUpdate.Visible = false;
        if(Request.QueryString["nfid"] != null)
        {
            Int64 NewsID = Convert.ToInt64(Request.QueryString["nfid"]);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM tblNews WHERE NewsID = '"+NewsID+"'", con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        if(Request.QueryString["enfid"] != null)
        {
            EditNewsFeed();
        }
    }

    private void EditNewsFeed()
    {
        btnCreateNews.Visible = false;
        btnUpdate.Visible = true;
        if (Request.QueryString["enfid"] != null)
        {
            String imagelink;
            Int64 NewsEdit = Convert.ToInt64(Request.QueryString["enfid"]);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM tblNews WHERE NewsID = '"+NewsEdit+"'", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dtNews = new DataTable();
                sda.Fill(dtNews);
                if(dtNews.Rows.Count != 0)
                {
                    txtNewsName.Text = dtNews.Rows[0]["NewsName"].ToString();
                    txtNewsMessage.Text = dtNews.Rows[0]["NewsMessage"].ToString();
                    imagelink = dtNews.Rows[0]["NewsImage"].ToString() + dtNews.Rows[0]["Extension"].ToString();
                    Image1.ImageUrl = "images/" + imagelink;
                }
            }
        }
    }

    private void BindNewsFeed()
    {
        using (SqlConnection con = new SqlConnection(CS))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblNews", con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtNews = new DataTable();
            sda.Fill(dtNews);
            rptrNewsFeed.DataSource = dtNews;
            rptrNewsFeed.DataBind();
        }
    }

    protected void btnCreateNews_Click(object sender, EventArgs e)
    {
        if(fupNewsImg.HasFile)
        {
            string SavePath = Server.MapPath("~/images/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extension = Path.GetExtension(fupNewsImg.PostedFile.FileName);
            fupNewsImg.SaveAs(SavePath + "\\" + txtNewsName.Text.ToString().Trim() + Extension);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO tblNews VALUES('"+txtNewsName.Text.Trim()+ "','"+txtNewsName.Text.ToString()+"','"+txtNewsMessage.Text.Trim()+"','"+Extension+"')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                lblSuccess.Text = "News Created Successfully.";
            }
            txtNewsName.Text = string.Empty;
            txtNewsMessage.Text = string.Empty;
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Int64 NewsEdit = Convert.ToInt64(Request.QueryString["enfid"]);
        if (fupNewsImg.HasFile)
        {
            string SavePath = Server.MapPath("~/images/");
            if (!Directory.Exists(SavePath))
            {
                Directory.CreateDirectory(SavePath);
            }
            string Extension = Path.GetExtension(fupNewsImg.PostedFile.FileName);
            fupNewsImg.SaveAs(SavePath + "\\" + txtNewsName.Text.ToString().Trim() + Extension);
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblNews SET NewsName = '"+txtNewsName.Text+"', NewsMessage = '"+txtNewsMessage.Text+"', NewsImage = '"+ txtNewsName.Text.ToString().Trim() + "', Extension = '"+Extension+"' WHERE NewsID = '"+NewsEdit+"'", con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            Response.Redirect("NewsFeed.aspx");
        }
        else
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd1 = new SqlCommand("UPDATE tblNews SET NewsName = '" + txtNewsName.Text + "', NewsMessage = '" + txtNewsMessage.Text + "' WHERE NewsID = '" + NewsEdit + "'", con);
                con.Open();
                cmd1.ExecuteNonQuery();
            }
            Response.Redirect("NewsFeed.aspx");
        }
    }
}