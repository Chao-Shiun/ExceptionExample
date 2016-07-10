using System;
using System.Runtime.Serialization;

namespace WebApplication3
{
    public partial class Example : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            /*
             Reference
             [1] http://blog.miniasp.com/post/2009/09/30/How-to-Designing-Custom-Exceptions.aspx
             [2] https://msdn.microsoft.com/zh-tw/library/ms229064.aspx
             [3] https://dotblogs.com.tw/atowngit/2009/12/06/12298
             */
            try
            {
                if (string.IsNullOrWhiteSpace(TextBox1.Text))
                {
                    throw new IsNullOrWhiteSpaceException();
                }
                int x;
                if (!int.TryParse(Label1.Text, out x))
                {
                    throw new FormatException("你輸入的不是一個整數");
                }
            }
            catch (IsNullOrWhiteSpaceException INWSE)
            {
                Label1.Text = INWSE.Message;
                throw INWSE;//通常都是這裡無法處理的錯誤才會throw或是丟給外面的程式去處理
            }
            catch (FormatException FE)
            {
                Label1.Text = FE.Message;
                //你沒寫throw就代表自行處理完畢，程式會繼續往下跑
                //切勿幹把Exception吃掉裝沒事這種害人害己的鳥事，真的無法處理該throw還是要throw
            }
            catch (Exception EX)
            {
                Label1.Text = "你可以搞出這錯誤也滿厲害的，這個錯誤應該是" + EX.Message;
                throw EX;
            }
            finally
            {
                Response.Write("<script>alert('我在finally的話，不管怎樣都一定會執行到我啦!(請記得下中斷點)');</script>");
                //在Web的話，throw Exception還是會執行到這邊，但是頁面已經掛了所以這一段的效果不會出來喔!
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }

    class IsNullOrWhiteSpaceException : Exception, ISerializable
    {
        public IsNullOrWhiteSpaceException() : base("你至少隨便key個字吧，不要什麼都沒key")
        {
        }
    }
}