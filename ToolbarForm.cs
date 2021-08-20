using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bentley.MstnPlatformNET;
using Bentley.MstnPlatformNET.GUI;
using Bentley.MstnPlatformNET.WinForms;

namespace csAddins
{
    public partial class ToolbarForm : Adapter, IGuiDockable
    {
        public ToolbarForm()
        {
            InitializeComponent();
        }

        public bool GetDockedExtent(GuiDockPosition dockPosition, ref GuiDockExtent extentFlag, ref System.Drawing.Size dockSize)
        {
            return false;
        }

        public bool WindowMoving(WindowMovingCorner corner, ref System.Drawing.Size newSize)
        {
            newSize = new System.Drawing.Size(118, 34);
            return true;
        }

        private void btnModal_Click(object sender, EventArgs e)
        {
            Session.Instance.Keyin("csAddins DemoForm Modal");
        }

        private void btnTopLevel_Click(object sender, EventArgs e)
        {
            Session.Instance.Keyin("csAddins DemoForm TopLevel");
        }

        private void btnToolSettings_Click(object sender, EventArgs e)
        {
            Session.Instance.Keyin("csAddins DemoForm ToolSettings");
        }
    }
}
