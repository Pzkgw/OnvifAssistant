using Ozeki.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnvifAssistant.Cam
{
    class ImgHandler : DrawingImageProvider
    {
        public ImgHandler()
        {

        }

        protected override void OnDataReceived(object sender, VideoData data)
        {
            base.OnDataReceived(sender, data);
            //data.Format <<
        }

    }
}
