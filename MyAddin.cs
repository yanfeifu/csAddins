using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bentley.MstnPlatformNET;
using System.Windows.Forms;

namespace csAddins
{
    [AddIn(MdlTaskID = "csAddins")]
    internal sealed class MyAddin : AddIn
    {
        public static  MyAddin Addin = null;

        private MyAddin(System.IntPtr mdlDesc) : base(mdlDesc)
        {
            Addin = this;
        }

        protected override int Run(string[] commandLine)
        {
            MessageBox.Show("Hello World!");
            //CreateElement.DrawPoint(null);
            //CreateElement.LineAndLineString1(null);
            //CreateElement.LineAndLineString2(null);
            //CreateElement.LineAndLineString3(null);
            //CreateElement.ShapeAndComplexShape(null);
            //CreateElement.TextString(null);
            //CreateElement.Cell(null);
            //CreateElement.Dimension(null);
            //CreateElement.BsplineCurve(null);
            //CreateElement.Cone(null);
            Session.Instance.Keyin("csAddins DemoForm Toolbar");
            return 0;
        }
    }
}
