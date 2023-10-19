using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinformTCPClient
{
    
    public class DrawCoordinate
    {
        public static void DotDraw(Graphics _Graphics, Pen dotpen, float formWidth, float formHeight)
        {
            _Graphics.DrawLine(dotpen, 0.1f * formWidth, 0, 0.1f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0.2f * formWidth, 0, 0.2f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0.3f * formWidth, 0, 0.3f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0.4f * formWidth, 0, 0.4f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0.5f * formWidth, 0, 0.5f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0.6f * formWidth, 0, 0.6f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0.7f * formWidth, 0, 0.7f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0.8f * formWidth, 0, 0.8f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0.9f * formWidth, 0, 0.9f * formWidth, formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.1f * formHeight, formWidth, 0.1f * formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.2f * formHeight, formWidth, 0.2f * formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.3f * formHeight, formWidth, 0.3f * formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.4f * formHeight, formWidth, 0.4f * formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.5f * formHeight, formWidth, 0.5f * formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.6f * formHeight, formWidth, 0.6f * formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.7f * formHeight, formWidth, 0.7f * formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.8f * formHeight, formWidth, 0.8f * formHeight);
            _Graphics.DrawLine(dotpen, 0, 0.9f * formHeight, formWidth, 0.9f * formHeight);
        }
        
    }
}
