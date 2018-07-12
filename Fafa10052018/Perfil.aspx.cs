using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fafa10052018
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Button1.Text = "Seguir";
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Index.aspx?");
            }
            Usuario u = new Usuario(int.Parse(Request.QueryString["IDperfil"]));
            DataTable DT = new DataTable();
            Label1.Text = u.getNome();
            byte[] teste = u.getImagem();
            if (teste==null)
            {
                Image1.ImageUrl = "~/Resources/img/profile-placeholder.png";
            }
            else
            {
                Image1.ImageUrl = "data:image/jpeg;base64," + Convert.ToBase64String(u.getImagem());
            }                        
            DT = u.pegarTweets();
            if (DT.Rows.Count > 0)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    Literal1.Text += DT.Rows[i]["Nome"].ToString() + ": " + DT.Rows[i]["conteudo"].ToString() + " - " + DT.Rows[i]["quando"].ToString() + "<br>";
                }
            }
            else
            {
                Literal1.Text = "Este usuário não postou nada ainda...";
            }
            DataTable DT2 = new DataTable();
            DT2 = u.buscaSeguidores();
            for (int i = 0; i < DT2.Rows.Count; i++)
            {
                //se der pau, tem que converter o session
                if (int.Parse(DT2.Rows[i]["seguidor"].ToString())==int.Parse(Session["Usuario"].ToString()))
                {
                    Button1.Text = "Parar de seguir";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Button1.Text=="Seguir")
            {
                Usuario u = new Usuario(int.Parse(Request.QueryString["IDperfil"]));
                u.seguir(int.Parse(Session["Usuario"].ToString()));
                Response.Redirect("Perfil.aspx?IDperfil="+Request.QueryString["IDperfil"]);
            }
            else
            {
                Usuario u = new Usuario(int.Parse(Request.QueryString["IDperfil"]));
                u.pararDeSeguir(int.Parse(Session["Usuario"].ToString()));
                Response.Redirect("Perfil.aspx?IDperfil=" + Request.QueryString["IDperfil"]);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Pesquisar.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("MinhaPagina.aspx");
        }
    }
}