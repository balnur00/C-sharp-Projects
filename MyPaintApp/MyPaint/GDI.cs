using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyPaint
{
    public class GDI
    {
        public IntPtr CreateSolidBRUSH(uint color)
        {
            return CreateSolidBrush(color);
        }

        public bool ExtFloodFILL(IntPtr hdcSourse, int x, int y, uint сolorRefColor, uint nFillType)
        {
            return ExtFloodFill(hdcSourse, x, y, сolorRefColor, nFillType);
        }

        public IntPtr SelectOBJECT(IntPtr hDCSourse, IntPtr hBitmap)
        {
            return SelectObject(hDCSourse, hBitmap);
        }

        public IntPtr CreateCOMPATIBLEDC(IntPtr hdcSourse)
        {
            return CreateCompatibleDC(hdcSourse);
        }

        public bool DeleteOBJECT(IntPtr hObject)
        {
            return DeleteObject(hObject);
        }


        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern IntPtr CreateSolidBrush(uint crColor);

        [DllImport("gdi32", CharSet = CharSet.Auto)]
        private static extern bool ExtFloodFill(IntPtr hDC, int x, int y, uint сolorRefColor, uint nFillType);

        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);
    }
}
