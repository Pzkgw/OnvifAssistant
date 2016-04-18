using Ozeki.Media;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Network_Video_Recorder01.Gui
{
    class VideoView : VideoViewerWF
    {
        public VideoView( string name)
        {

            this.Name = name;
            //this.Size = new Size(704, 576);
            //this.BackColor = Color.Black;
            this.TabStop = false;
            this.Dock = DockStyle.Fill;
            //this.Location = new Point(14, 19);
            
        }



    }
}
