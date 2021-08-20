using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bentley.DgnPlatformNET;
using Bentley.MstnPlatformNET;
using Bentley.MstnPlatformNET.WinForms;
using static Bentley.MstnPlatformNET.AddIn;

namespace csAddins
{
    public partial class LevelChangedForm : Adapter
    {
        public LevelChangedForm()
        {
            InitializeComponent();
            MyAddin.Addin.LevelChangeEvent += LevelChangeEventHandler;
            MyAddin.Addin.NewDesignFileEvent += NewDesignFileEventHandler;
        }

        private void LevelChangedForm_Load(object sender, EventArgs e)
        {
            FileLevelCache fileLevelCache = Session.Instance.GetActiveDgnFile().GetLevelCache();
            LevelHandleCollection levelHandleCol = fileLevelCache.GetHandles();
            foreach (LevelHandle levelHandle in levelHandleCol)
            {
                listBox1.Items.Add(levelHandle.Name);
            }
        }

        private void LevelChangedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyAddin.Addin.LevelChangeEvent -= LevelChangeEventHandler;
            MyAddin.Addin.NewDesignFileEvent -= NewDesignFileEventHandler;
        }

        private void LevelChangeEventHandler(AddIn senderIn, LevelChangeEventArgs eventArgsIn)
        {
            if (eventArgsIn.Change == LevelChangeEventArgs.ChangeType.Create ||
                eventArgsIn.Change == LevelChangeEventArgs.ChangeType.Delete ||
                eventArgsIn.Change == LevelChangeEventArgs.ChangeType.TableRewrite ||
                eventArgsIn.Change == LevelChangeEventArgs.ChangeType.ChangeName)
                PopulateLevelList();
        }

        private void NewDesignFileEventHandler(AddIn sender, NewDesignFileEventArgs eventArgs)
        {
            if (AddIn.NewDesignFileEventArgs.When.AfterDesignFileOpen == eventArgs.WhenCode)
                PopulateLevelList();
        }

        private void PopulateLevelList()
        {
            listBox1.Items.Clear();
            LevelHandleCollection levelCollection = Session.Instance.GetActiveDgnFile().GetLevelCache().GetHandles();
            foreach (LevelHandle myLvl in levelCollection)
                listBox1.Items.Add(myLvl.Name);
        }
    }
}
