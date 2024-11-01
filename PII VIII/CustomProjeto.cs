using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace PII_VIII
{
    public class CustomProjeto : ToolStripProfessionalRenderer
    {
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            e.TextColor = Color.White;
            base.OnRenderItemText(e);
        }
        protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
        {
             if (e.Item.Selected)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(31, 31, 31)), e.Item.ContentRectangle);
        }
        else
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(51, 51, 51)), e.Item.ContentRectangle);
        }
        base.OnRenderItemBackground(e);
        }
    }
    
       
}    
