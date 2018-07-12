using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Fafa10052018
{
    public partial class Cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox2.Text==TextBox3.Text)
            {
                Usuario u = new Usuario(TextBox1.Text, TextBox2.Text);
                //int fileLen = FileUpload1.PostedFile.ContentLength;
                if (FileUpload1.HasFile)
                {
                    byte[] input = ReadFully(FileUpload1.PostedFile.InputStream);
                    u.gravarUsuarioFoto(input);
                }
                else
                {
                    u.gravarUsuario();
                    Response.Write("<script> alert('Usuário cadastrado!!!');</script>");
                }
                
            }
            else
            {
                Response.Write("<script> alert('As senhas não conferem...')</script>");
            }            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx");
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