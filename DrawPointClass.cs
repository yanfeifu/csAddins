using Bentley.DgnPlatformNET;
using Bentley.DgnPlatformNET.DgnEC;
using Bentley.DgnPlatformNET.Elements;
using Bentley.ECObjects.Instance;
using Bentley.ECObjects.Schema;
using Bentley.GeometryNET;
using Bentley.MstnPlatformNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static Bentley.DgnPlatformNET.DgnHost;
using BIM = Bentley.Interop.MicroStationDGN;

namespace csAddins
{
    class DrawPointClass : DgnPrimitiveTool
    {
        private DPoint3d m_Point = new DPoint3d();
        private List<DPoint3d> m_Pts = new List<DPoint3d>();
        private int m_nPoints = 0;

        private double m_UorPerMas = Session.Instance.GetActiveDgnModel().GetModelInfo().UorPerMaster;

        public DrawPointClass() : base(0, 0)
        {

        }

        protected override bool OnDataButton(DgnButtonEvent ev)
        {

            //DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
            //ModelElementsCollection mc = dgnModel.GetGraphicElements();
            ////int a = mc.Count();
            //List<Element> elements = new List<Element>();
            //for (int i = 0; i < mc.Count(); i++)
            //{
            //    MSElementType elementType = mc.ElementAt(i).ElementType;
            //    string cellName = ((Bentley.DgnPlatformNET.Elements.CellHeaderElement)mc.ElementAt(i)).CellName;
            //    if (elementType == MSElementType.CellHeader && cellName == "SpecialPoint")
            //    {
            //        GetPropertyValue(mc.ElementAt(i));
            //        //elements.Add(mc.ElementAt(i));
            //    }
            //}
            //CreateTable();

            #region code
            //---------------------------------------------------------------------
            //DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
            //double UorPerMas = Session.Instance.GetActiveDgnModel().GetModelInfo().UorPerMaster;
            //DPoint3d[] dVertPoint3Ds = new DPoint3d[2];
            //DPoint3d[] dHortPoint3Ds = new DPoint3d[2];

            //DPoint3d pt = ev.Point;
            //pt.X = Math.Floor(pt.X);
            //pt.Y = Math.Floor(pt.Y);
            //pt.Z = Math.Floor(pt.Z);
            //dVertPoint3Ds[0] = new DPoint3d(pt.X, pt.Y + 10 * UorPerMas, pt.Z);
            //dVertPoint3Ds[1] = new DPoint3d(pt.X, pt.Y - 10 * UorPerMas, pt.Z);
            //dHortPoint3Ds[0] = new DPoint3d(pt.X + 10 * UorPerMas, pt.Y, pt.Z);
            //dHortPoint3Ds[1] = new DPoint3d(pt.X - 10 * UorPerMas, pt.Y, pt.Z);

            //LineStringElement line1 = new LineStringElement(dgnModel, null, dVertPoint3Ds);
            ////line1.AddToModel();

            //LineStringElement line2 = new LineStringElement(dgnModel, null, dHortPoint3Ds);
            ////line2.AddToModel();

            //List<Element> elements = new List<Element>();
            //elements.Add(line1);
            //elements.Add(line2);

            //DPoint3d ptOri = new DPoint3d();
            //ptOri = pt;
            //DMatrix3d rMatrix = DMatrix3d.Identity;
            //CellHeaderElement cell = new CellHeaderElement(dgnModel, "SpecialPoint", ptOri, rMatrix, elements);
            //cell.AddToModel();
            #endregion
            return true;
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

        public static void InstallNewTool()
        {
            DrawPointClass dp = new DrawPointClass();
            dp.InstallTool();
        }
    }

    class DrawTextTableClass : DgnPrimitiveTool
    {
        public DrawTextTableClass() : base(0, 0)
        {

        }

        protected override bool OnDataButton(DgnButtonEvent ev)
        {
            //get point origin
            DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
            ModelElementsCollection mc = dgnModel.GetGraphicElements();
            //int a = mc.Count();
            List<Element> elements = new List<Element>();
            for (int i = 0; i < mc.Count(); i++)
            {
                MSElementType elementType = mc.ElementAt(i).ElementType;
                string cellName = ((Bentley.DgnPlatformNET.Elements.CellHeaderElement)mc.ElementAt(i)).CellName;
                if (elementType == MSElementType.CellHeader && cellName == "SpecialPoint")
                {
                    GetPropertyValue(mc.ElementAt(i));
                    //elements.Add(mc.ElementAt(i));
                }
            }
            CreateTable();

            #region code
            //---------------------------------------------------------------------
            //DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
            //double UorPerMas = Session.Instance.GetActiveDgnModel().GetModelInfo().UorPerMaster;
            //DPoint3d[] dVertPoint3Ds = new DPoint3d[2];
            //DPoint3d[] dHortPoint3Ds = new DPoint3d[2];

            //DPoint3d pt = ev.Point;
            //pt.X = Math.Floor(pt.X);
            //pt.Y = Math.Floor(pt.Y);
            //pt.Z = Math.Floor(pt.Z);
            //dVertPoint3Ds[0] = new DPoint3d(pt.X, pt.Y + 10 * UorPerMas, pt.Z);
            //dVertPoint3Ds[1] = new DPoint3d(pt.X, pt.Y - 10 * UorPerMas, pt.Z);
            //dHortPoint3Ds[0] = new DPoint3d(pt.X + 10 * UorPerMas, pt.Y, pt.Z);
            //dHortPoint3Ds[1] = new DPoint3d(pt.X - 10 * UorPerMas, pt.Y, pt.Z);

            //LineStringElement line1 = new LineStringElement(dgnModel, null, dVertPoint3Ds);
            ////line1.AddToModel();

            //LineStringElement line2 = new LineStringElement(dgnModel, null, dHortPoint3Ds);
            ////line2.AddToModel();

            //List<Element> elements = new List<Element>();
            //elements.Add(line1);
            //elements.Add(line2);

            //DPoint3d ptOri = new DPoint3d();
            //ptOri = pt;
            //DMatrix3d rMatrix = DMatrix3d.Identity;
            //CellHeaderElement cell = new CellHeaderElement(dgnModel, "SpecialPoint", ptOri, rMatrix, elements);
            //cell.AddToModel();
            #endregion
            return true;
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

        public static void InstallNewTool()
        {
            DrawPointClass dp = new DrawPointClass();
            dp.InstallTool();
        }

        private void GetPropertyValue(Element element)
        {
            DgnECManager eCManager = DgnECManager.Manager;
            DgnECInstanceCollection eCPropertyValues = eCManager.GetElementProperties(element, ECQueryProcessFlags.SearchAllClasses);
            foreach (IDgnECInstance value in eCPropertyValues)
            {
                string name = value.ClassDefinition.Name;
                IEnumerator<IECProperty> propertyEnum = value.ClassDefinition.GetEnumerator();
                object dp3d;
                DPoint3d dp3dValue;
                while (propertyEnum.MoveNext())
                {
                    IECPropertyValue propertyValue = value.GetPropertyValue(propertyEnum.Current.Name);
                    if (propertyEnum.Current.Name.Contains("HatchOrigin") ||
                        propertyEnum.Current.Name.Contains("Origin"))
                    {
                        propertyValue.TryGetNativeValue(out dp3d);
                        if (dp3d != null)
                        {
                            dp3dValue = (DPoint3d)dp3d;
                        }
                    }
                    //if (propertyValue.IsArray)
                    //{
                    //    IECArrayValue arrayVal = propertyValue as IECArrayValue;
                    //    if (arrayVal.Count >= 1)
                    //        propertyValue = arrayVal[0];
                    //}
                    //string strVal;
                    //string strString;
                    //double dblVal;
                    //string strDouble;
                    //int intVal;
                    //string strInt;

                    //if (propertyValue.TryGetStringValue(out strVal))
                    //    strString = propertyEnum.Current.Name + ", value:" + strVal;
                    //else if (propertyValue.TryGetDoubleValue(out dblVal))
                    //    strDouble = propertyEnum.Current.Name + ", value" + dblVal.ToString();
                    //else if (propertyValue.TryGetIntValue(out intVal))
                    //    strInt = propertyEnum.Current.Name + ", value" + intVal.ToString();
                    //else if (propertyValue.TryGetNativeValue(out dp3d))
                    //    dp3dValue = (DPoint3d)dp3d;
                }
            }
        }

        private ElementId m_TextTableElementId;

        private DgnFile m_ActiveDgnFile;
        private DgnModel m_ActiveModel;

        /// <summary>
        /// Text Style and Id
        /// </summary>
        private DgnTextStyle m_TextStyle;
        private ElementId m_TextStyleId;

        List<string> m_columnNames = new List<string>() { "pointName", "pointX", "pointY" };
        List<string> data = new List<string>() { "1", "2", "3" };
        List<List<string>> m_rows = new List<List<string>>();

        private double m_UorPerMas = Session.Instance.GetActiveDgnModel().GetModelInfo().UorPerMaster;

        private void GetRequiredObjects()
        {
            m_ActiveModel = Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnModel();
            m_ActiveDgnFile = Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnFile();

            //If text style exists in file just get it. No need to create this each time.
            m_TextStyle = DgnTextStyle.GetByName("TextTable Style", m_ActiveDgnFile);

            if (null == m_TextStyle)
            {
                m_TextStyle = new DgnTextStyle("TextTable Style", m_ActiveDgnFile);
                m_TextStyle.SetProperty(TextStyleProperty.Width, 1000D);
                m_TextStyle.SetProperty(TextStyleProperty.Height, 1000D);
                m_TextStyle.Add(m_ActiveDgnFile);
            }

            m_TextStyleId = m_TextStyle.Id;
        }

        private TextTable CreateAndPopulateTextTable()
        {
            m_rows.Add(data);
            TextTable textTable = TextTable.Create((uint)4 + 1, (uint)3, m_TextStyleId, 1000, m_ActiveModel);
            DPoint3d tableOrigin = new DPoint3d(3235 * m_UorPerMas, 904 * m_UorPerMas, 0);
            textTable.Origin = tableOrigin;

            //for (uint row = 0; row < textTable.RowCount; row++)
            //{
            //    for (uint column = 0; column < textTable.ColumnCount; column++)
            //    {
            //        TableCellIndex index = new TableCellIndex(row, column);
            //        TextTableCell cell = textTable.GetCell(index);

            //        TextBlock tb = new TextBlock(m_TextStyle, m_ActiveModel);
            //        if (0 == row)
            //        {
            //            if (m_columnNames[(int)column].Length > 0)
            //                tb.AppendText(m_columnNames[(int)column]);
            //        }
            //        else
            //        {
            //            if (m_rows[(int)row - 1][(int)column].Length > 0)
            //                tb.AppendText(m_rows[(int)row - 1][(int)column]);
            //        }
            //        cell.TextBlock = tb;
            //    }
            //}
            return textTable;
        }

        private void CreateTextTableElement(TextTable textTable)//ref TextTable 
        {
            TextTableElement textTableElement = new TextTableElement(textTable);

            textTableElement.AddToModel();

            m_TextTableElementId = textTableElement.ElementId;
        }

        public void CreateTable()
        {
            GetRequiredObjects();
            TextTable textTable = CreateAndPopulateTextTable();

            DgnFile activeDgnFile = Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnFile();
            DgnModel activeDgnModel = Bentley.MstnPlatformNET.Session.Instance.GetActiveDgnModel();

            if (null == m_ActiveModel.FindElementById(m_TextTableElementId))
                CreateTextTableElement(textTable);

        }
    }
}
