using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Bentley.DgnPlatformNET;
using Bentley.MstnPlatformNET;

namespace csAddins
{
    class DemoForm
    {
        private static LevelChangedForm myLevelForm = null;


        public static void Toolbar(string unparsed)
        {
            ToolbarForm myForm = new ToolbarForm();
            myForm.AttachAsGuiDockable(MyAddin.Addin, "toolbar");
            myForm.Show();
        }

        public static void Modal(string unparsed)
        {
            ModalForm myForm = new ModalForm();
            if (DialogResult.OK == myForm.ShowDialog())
                MessageBox.Show(myForm.textBox1.Text.ToString());
        }

        public static void TopLevel(string unparsed)
        {
            MultiScaleCopyClass.InstallNewTool();
            //MultiScaleCopyForm myForm = new MultiScaleCopyForm();
            //myForm.AttachAsTopLevelForm(MyAddin.Addin, false);
            //myForm.Show();
        }

        public static void ToolSettings(string unparsed)
        {
            NoteCoordClass.InstallNewTool();
            //NoteCoordForm myForm = new NoteCoordForm();
            //myForm.AttachToToolSettings(MyAddin.Addin);
            //myForm.Show();
        }

        public static void LevelChanged(string unparsed)
        {
            if (null == myLevelForm || myLevelForm.IsDisposed)
            {
                myLevelForm = new LevelChangedForm();
                myLevelForm.AttachAsTopLevelForm(MyAddin.Addin, false);
                myLevelForm.Show();
            }
            else
                myLevelForm.Activate();
        }

        unsafe public static void ShowLevelNames(string unparsed)
        {
            List<string> namesList = new List<string>();
            LevelHandleCollection lvlHanCol = Session.Instance.GetActiveDgnFile().GetLevelCache().GetHandles();
            foreach (LevelHandle lvlHan in lvlHanCol)
            {
                namesList.Add(lvlHan.Name);
            }
            int namesCnt = 0;
            void** namesvpp = GetDgnlibLevelNames(ref namesCnt);
            IntPtr ptr = new IntPtr(namesvpp);
            for (int i = 0; i < namesCnt; i++)
            {
                IntPtr ptr1 = new IntPtr(ptr.ToInt64() + 8 * i);
                string lvlName = Marshal.PtrToStringUni(new IntPtr(*(void**)ptr1.ToPointer()));
                namesList.Add(lvlName);

            }
            ReleaseDgnlibLevelNames(namesvpp, namesCnt);
            foreach (string lvlName in namesList)
            {
                MessageCenter.Instance.ShowInfoMessage(lvlName, lvlName, false);
            }
        }

        [DllImport("SampleNative.dll")]
        public static unsafe extern void** GetDgnlibLevelNames(ref int namesCnt);

        [DllImport("SampleNative.dll")]
        public static unsafe extern void ReleaseDgnlibLevelNames(void** namesPP, int namesCnt);

    }
}
