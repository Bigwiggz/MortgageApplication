using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace LoanAppWinFormsNET5UI.FormattingExtensions
{
    internal class ImageProcessing
    {
        public Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
    }
}
