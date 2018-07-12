using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fafa10052018
{
    public partial class Pesquisar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Selecionado"] = null;
            if (Session["Usuario"] == null)
            {
                Response.Redirect("Index.aspx?");
            }            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Banco b = new Banco();
            DataTable DT = new DataTable();
            DT = b.Consultar("Select * from perfil where nome like '%" + TextBox1.Text + "%'");
            if (DT.Rows.Count > 0)
            {
                for (int i = 0; i < DT.Rows.Count; i++)
                {
                    if (int.Parse(DT.Rows[i]["IDperfil"].ToString()) != int.Parse(Session["Usuario"].ToString()))
                    {
                        Literal1.Text += "<a href=Perfil.aspx?IDperfil=" + DT.Rows[i]["IDperfil"] + ">" + DT.Rows[i]["nome"].ToString() + "<br></a>";
                    }
                }
            }
            else
            {
                Literal1.Text = "Não há ninguém com esse nome...";
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("MinhaPagina.aspx");
        }
    }
}