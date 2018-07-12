using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fafa10052018
{
    public partial class MinhaPagina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button5.Visible = false;
            FileUpload1.Visible = false;
            if (Session["Usuario"]==null)
            {
                Response.Redirect("Index.aspx?");
            }
            Usuario u = new Usuario(int.Parse(Session["Usuario"].ToString()));
            DataTable DT = new DataTable();
            Label1.Text="Bem Vindo "+u.getNome();
            byte[] teste = u.getImagem();
            if (teste == null)
            {
                Image1.ImageUrl = "~/Resources/img/profile-placeholder.png";
            }
            else
            {
                Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(u.getImagem());
            }
            DT = u.pegarTweetsSeguidos();
            byte[] imgi;
            if (DT.Rows.Count > 0)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    if (DT.Rows[i]["Foto"] != DBNull.Value)
                    {
                        imgi = (byte[])DT.Rows[i]["Foto"];
                        Literal1.Text += "<img Height='50px' Width='50px' src='data:image/jpeg;base64," + Convert.ToBase64String(imgi) + "' alt=''></img>" + "<a href=Perfil.aspx?IDperfil=" + DT.Rows[i]["IDperfil"] + ">" + DT.Rows[i]["nome"].ToString() + "</a>: " + DT.Rows[i]["conteudo"].ToString() + " - " + DT.Rows[i]["quando"].ToString() + "<br><br>";
                    }
                    else
                    {
                        Literal1.Text += "<img Height='50px' Width='50px' src='~/Resources/img/profile-placeholder.png' alt=''></img>" + "<a href=Perfil.aspx?IDperfil=" + DT.Rows[i]["IDperfil"] + ">" + DT.Rows[i]["nome"].ToString()+ "</a>: " + DT.Rows[i]["conteudo"].ToString() + " - " + DT.Rows[i]["quando"].ToString() + "<br><br>";
                    }
                    
                }
            }
            else
            {
                Literal1.Text = "Você ainda não tweetou nada!!! vá fofocar um pouco!!!";
            }            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario(int.Parse(Session["Usuario"].ToString()));
            u.Tweetar(TextBox1.Text,System.DateTime.Now);
            Response.Redirect("MinhaPagina.aspx?");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pesquisar.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Session["Usuario"] = null;
            Response.Redirect("Index.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            FileUpload1.Visible = false;
            Button5.Visible = false;
            Button4.Text = "Alterar foto";
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            if (Button4.Text=="Alterar foto")
            {
                FileUpload1.Visible = true;
                Button5.Visible = true;
                Button4.Text = "Enviar foto";
            }
            else if (Button4.Text=="Enviar foto"&&FileUpload1.HasFile)
            {
                byte[] input = ReadFully(FileUpload1.PostedFile.InputStream);                
                Usuario u = new Usuario(int.Parse(Session["Usuario"].ToString()));
                u.setImagem(input);
                u.alterarFoto();
                Button4.Text = "Alterar foto";
                Response.Redirect("MinhaPagina.aspx");
            }
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[input.Length];
            //byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}