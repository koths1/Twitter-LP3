using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fafa10052018
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Usuario u = new Usuario(TextBox1.Text, TextBox2.Text);            
            try
            {                
                if (u.validarUsuario())
                {
                    //Window.location.href = "Minh´Pagina.aspx";

                    Response.Write("<script>alert('Usuário logado');</script>");

                    Session["Usuario"] = u.getId();

                    Response.Redirect("MinhaPagina.aspx?");

                    //original Response.Redirect("MinhaPagina.aspx");

                    //Envia QueryString
                    //Response.Redirect("MinhaPagina.aspx?NewsID=928&autor=fulano");

                    //Resgata QueryString
                    /* if(Request.QueryString.HasKeys()){
                     * 
                     *      string valor=Request.QueryString["nome"]; 
                     * 
                     * }
                     */
                }
                else
                {
                    Response.Write("<script>alert(Dados inválidos);</script>");
                }                
            }
            catch (Exception ex)
            {
                throw;
            }
            
            

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cadastro.aspx");
        }
    }
}