using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.Elements;
using Bentley.GeometryNET;
using Bentley.MstnPlatformNET;

namespace csAddins
{
    class NoteCoordClass : DgnPrimitiveTool
    {
        private NoteCoordForm m_myForm;
        private DPoint3d m_Point = new DPoint3d();
        private int m_nPoints = 0;

        public NoteCoordClass() : base(0, 0)
        {
        }

        public static void InstallNewTool()
        {
            NoteCoordClass noteCoordClass = new NoteCoordClass();
            noteCoordClass.InstallTool();
        }

        protected override void OnPostInstall()
        {
            if (m_myForm == null)
            {
                m_myForm = new NoteCoordForm();
                m_myForm.AttachToToolSettings(MyAddin.Addin);
                m_myForm.Show();

            }
            AccuSnap.SnapEnabled = true;
            base.OnPostInstall();
        }


        private Element CreateNoteElement(DgnButtonEvent ev)
        {
            if (1 != m_nPoints)
                return null;
            DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
            DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
            string[] txtStr = new string[2];
            DPoint3d[] txtPts = new DPoint3d[2];
            Element[] elems = new Element[3];

            txtStr[0] = (m_myForm.rdoEN.Checked ? "E=" : "X=") + m_Point.X.ToString("F2");
            txtStr[1] = (m_myForm.rdoEN.Checked ? "N=" : "Y=") + m_Point.Y.ToString("F2");
            DgnTextStyle txtStyle = DgnTextStyle.GetSettings(dgnFile);
            double width = 0, txtLineSpacing = 0;
            txtStyle.GetProperty(TextStyleProperty.Width, out width);
            txtStyle.GetProperty(TextStyleProperty.Height, out txtLineSpacing);
            double txtLen = width * Math.Max(txtStr[0].Length, txtStr[1].Length);
            DPoint3d pt1 = ev.Point, pt2 = new DPoint3d();
            if (m_myForm.rdoHoriz.Checked)
            {
                pt2.X = pt1.X + (m_Point.X > pt1.X ? -txtLen : txtLen) * 1.2;
                pt2.Y = pt1.Y;
                txtPts[0].X = (pt1.X + pt2.X) / 2;
                txtPts[0].Y = pt1.Y + txtLineSpacing / 2;
                txtPts[1].X = txtPts[0].X;
                txtPts[1].Y = pt1.Y - txtLineSpacing / 2 * 3;
            }
            else
            {
                pt2.X = pt1.X;
                pt2.Y = pt1.Y + (m_Point.Y > pt1.Y ? -txtLen : txtLen) * 1.2;
                txtPts[0].X = pt1.X - txtLineSpacing / 2;
                txtPts[0].Y = (pt1.Y + pt2.Y) / 2;
                txtPts[1].X = pt1.X + txtLineSpacing / 2 * 3;
                txtPts[1].Y = txtPts[0].Y;
            }
            DPoint3d[] ptArr = new DPoint3d[3];
            ptArr[0] = m_Point;
            ptArr[1] = pt1;
            ptArr[2] = pt2;
            LineStringElement lineStrEle = new LineStringElement(dgnModel, null, ptArr);
            List<Element> eleList = new List<Element>();
            eleList.Add(lineStrEle);
            for (int i = 1; i < 3; i++)
            {
                TextBlockProperties txtBlockProp = new TextBlockProperties(dgnModel);
                txtBlockProp.IsViewIndependent = false;
                ParagraphProperties paraProp = new ParagraphProperties(dgnModel);
                paraProp.Justification = TextElementJustification.CenterMiddle;
                RunProperties runProp = new RunProperties(txtStyle, dgnModel);
                TextBlock txtBlock = new TextBlock(txtBlockProp, paraProp, runProp, dgnModel);
                txtBlock.AppendText(txtStr[i - 1]);
                TextHandlerBase txtHandlerBase = TextHandlerBase.CreateElement(null, txtBlock);
                DTransform3d trans = DTransform3d.Identity;
                DPoint3d offset = new DPoint3d();
                if (m_myForm.rdoVert.Checked)
                {
                    DRange3d range3d = new DRange3d();
                    txtHandlerBase.CalcElementRange(out range3d);
                    trans.Matrix = DMatrix3d.FromColumns(new DVector3d(0, 1, 0), new DVector3d(-1, 0, 0), new DVector3d(0, 0, 1));
                    offset = new DPoint3d((range3d.Low.Y - range3d.High.Y) / 2 + txtPts[i - 1].X,
                      (range3d.Low.X - range3d.High.X) / 2 + txtPts[i - 1].Y, 0);
                }
                else
                {
                    DRange3d range3d = new DRange3d();
                    txtHandlerBase.CalcElementRange(out range3d);
                    offset = new DPoint3d((range3d.Low.X - range3d.High.X) / 2 + txtPts[i - 1].X,
                      (range3d.High.Y - range3d.Low.Y) / 2 + txtPts[i - 1].Y, 0);
                }
                trans.Translation = offset;

                TransformInfo transInfo = new TransformInfo(trans);
                txtHandlerBase.ApplyTransform(transInfo);
                eleList.Add(txtHandlerBase);
                //if (myForm.rdoVert.Checked)
                //    elems[i].RotateAboutZ(txtPts[i - 1], Math.PI / 2);
            }
            DMatrix3d rMatrix = DMatrix3d.Identity;
            DPoint3d ptScale = new DPoint3d(1, 1, 1);
            CellHeaderElement cellHeaderEle = new CellHeaderElement(dgnModel, "NoteCoordCell", m_Point, rMatrix, eleList);

            return cellHeaderEle;
        }

        protected override bool OnDataButton(DgnButtonEvent ev)
        {
            if (0 == m_nPoints)
            {
                BeginDynamics();
                m_Point = ev.Point;
                m_nPoints = 1;
                return false;
            }
            Element element = CreateNoteElement(ev);
            element.AddToModel();
            OnReinitialize();
            return true;
        }

        protected override void OnDynamicFrame(DgnButtonEvent ev)
        {
            Element element = CreateNoteElement(ev);
            if (null == element)
                return;

            RedrawElems redrawElems = new RedrawElems();
            redrawElems.SetDynamicsViewsFromActiveViewSet(Bentley.MstnPlatformNET.Session.GetActiveViewport());
            redrawElems.DrawMode = DgnDrawMode.TempDraw;
            redrawElems.DrawPurpose = DrawPurpose.Dynamics;

            redrawElems.DoRedraw(element);
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
    }
}
