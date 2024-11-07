using System.Windows.Forms;

public class BufferedPanel : Panel
{
    public BufferedPanel()
    {
        this.DoubleBuffered = true;
        this.ResizeRedraw = true;  
    }
}
