using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
using Bentley.MstnPlatformNET;
using BIM = Bentley.Interop.MicroStationDGN;

namespace csAddins
{
    class MultiScaleCopyClass : DgnElementSetTool
    {
        private MultiScaleCopyForm m_myForm;

        public MultiScaleCopyClass() : base(0, 0)
        {

        }

        public static void InstallNewTool()
        {
            MultiScaleCopyClass multiScaleCopyClass = new MultiScaleCopyClass();
            multiScaleCopyClass.InstallTool();
        }

        protected override void OnPostInstall()
        {
            if (m_myForm == null)
            {
                m_myForm = new MultiScaleCopyForm();
                m_myForm.AttachToToolSettings(MyAddin.Addin);
                m_myForm.Show();
            }
            base.OnPostInstall();
        }

        protected override void OnCleanup()
        {
            m_myForm.DetachFromMicroStation();
        }

        protected override bool OnResetButton(DgnButtonEvent ev)
        {
            OnRestartTool();
            return true;
        }

        protected override void OnRestartTool()
        {
            InstallNewTool();
        }
        protected override bool NeedAcceptPoint()
        {
            return false;
        }

        public override StatusInt OnElementModify(Element element)
        {
            Bentley.Interop.MicroStationDGN.Element newEl;
            double dScale = double.Parse(m_myForm.txtScale.Text);
            DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
            double uorPerMaster = dgnModel.GetModelInfo().UorPerMaster;
            DPoint3d offsetPnt = new DPoint3d(double.Parse(m_myForm.txtXOffset.Text) * uorPerMaster,
                                                   double.Parse(m_myForm.txtYOffset.Text) * uorPerMaster,
                                                   double.Parse(m_myForm.txtZOffset.Text) * uorPerMaster);
            BIM.Application app = Bentley.MstnPlatformNET.InteropServices.Utilities.ComApp;
            long eleId = element.ElementId;
            Bentley.Interop.MicroStationDGN.Element BIMEle = app.ActiveModelReference.GetElementByID(ref eleId);

            for (int i = 0; i < int.Parse(m_myForm.txtCopies.Text); i++)
            {
                newEl = app.ActiveModelReference.CopyElement(BIMEle);
                long longid = newEl.ID;
                ElementId elementId = new ElementId(ref longid);
                Element newElement = dgnModel.FindElementById(elementId);
                DRange3d range = new DRange3d();
                ((DisplayableElement)newElement).CalcElementRange(out range);
                DTransform3d dTransform = DTransform3d.Identity;
                dTransform.Translation = new DPoint3d(-(range.Low.X + range.High.X) / 2, -(range.Low.Y + range.High.Y) / 2,
                    -(range.Low.Z + range.High.Z) / 2);
                DTransform3d dTransform2 = new DTransform3d(new DMatrix3d(dScale, 0, 0, 0, dScale, 0, 0, 0, dScale));
                dTransform2 = DTransform3d.Multiply(dTransform2, dTransform);
                dTransform = DTransform3d.Identity;
                dTransform.Translation = new DPoint3d((range.Low.X + range.High.X) / 2 + offsetPnt.X, (range.Low.Y + range.High.Y) / 2 + offsetPnt.Y,
                    (range.Low.Z + range.High.Z) / 2 + offsetPnt.Z);
                dTransform2 = DTransform3d.Multiply(dTransform, dTransform2);
                newElement.ApplyTransform(new TransformInfo(dTransform2));
                newElement.ReplaceInModel(newElement);

                eleId = newElement.ElementId;
                BIMEle = app.ActiveModelReference.GetElementByID(ref eleId);

            }
            return StatusInt.Error;
        }
    }
}
