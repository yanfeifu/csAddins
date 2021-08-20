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
    class CreateDimensionCallbacks : DimensionCreateData
    {
        private DimensionStyle m_dimStyle;
        private DgnTextStyle m_textStyle;
        private Symbology m_symbology;
        private LevelId m_levelId;
        private DirectionFormatter m_directionFormatter;

        public CreateDimensionCallbacks(DimensionStyle dimStyle, DgnTextStyle textStyle, Symbology symb, LevelId levelId, DirectionFormatter formatter)
        {
            m_dimStyle = dimStyle;
            m_textStyle = textStyle;
            m_symbology = symb;
            m_levelId = levelId;
            m_directionFormatter = formatter;
        }

        public override DimensionStyle GetDimensionStyle()
        {
            return m_dimStyle;
        }

        public override DgnTextStyle GetTextStyle()
        {
            return m_textStyle;
        }

        public override Symbology GetSymbology()
        {
            return m_symbology;
        }

        public override LevelId GetLevelId()
        {
            return m_levelId;
        }

        public override int GetViewNumber()
        {
            return 0;
        }
        
        public override DMatrix3d GetDimensionRotation()
        {
            return DMatrix3d.Identity;
        }

        public override DMatrix3d GetViewRotation()
        {
            return DMatrix3d.Identity;
        }

        public override DirectionFormatter GetDirectionFormatter()
        {
            return m_directionFormatter;
        }
    }

    class CreateElement
    {
        static double UorPerMas = Session.Instance.GetActiveDgnModel().GetModelInfo().UorPerMaster;

        public static void DrawTextTable()
        {

        }

        public static void DrawPoint(string unparsed)
        {
            //cell 绘制点，四舍五入取数据，将点数据获取填入表中，表放置在图上
            DrawPointClass.InstallNewTool();
        }

        public static void LineAndLineString1(string unparsed)
        {
            BIM.Application app = Bentley.MstnPlatformNET.InteropServices.Utilities.ComApp;
            BIM.Point3d ptStart = app.Point3dZero();
            BIM.Point3d ptEnd = ptStart;
            ptStart.X = 10;
            BIM.LineElement lineEle = app.CreateLineElement2(null, ref ptStart, ref ptEnd);
            lineEle.Color = 0; lineEle.LineWeight = 2;
            app.ActiveModelReference.AddElement(lineEle);

            //DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
            //ModelInfo modelInfo = dgnModel.GetModelInfo();
            //DPoint3d[] ptArr = new DPoint3d[2];
            //ptArr[0] = new DPoint3d(0 * UorPerMas, 0 * UorPerMas, 0 * UorPerMas);
            //ptArr[1] = new DPoint3d(10 * UorPerMas, 0 * UorPerMas, 0 * UorPerMas);
            //CurvePrimitive curPri = CurvePrimitive.CreateLineString(ptArr);
            //Element ele = DraftingElementSchema.ToElement(dgnModel, curPri, null);
            //ele.AddToModel();
        }

        public static void LineAndLineString2(string unparsed)
        {
            DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
            ModelInfo modelInfo = dgnModel.GetModelInfo();
            DSegment3d seg = new DSegment3d(0 * UorPerMas, 5 * UorPerMas, 0 * UorPerMas, 10 * UorPerMas, 10 * UorPerMas, 0 * UorPerMas);
            LineElement lineEle = new LineElement(dgnModel, null, seg);
            lineEle.AddToModel();

            DPoint3d[] ptArr = new DPoint3d[5];
            ptArr[0] = new DPoint3d(15 * UorPerMas, 10 * UorPerMas, 0);
            ptArr[1] = new DPoint3d(16 * UorPerMas, 12 * UorPerMas, 0);
            ptArr[2] = new DPoint3d(18 * UorPerMas, 8 * UorPerMas, 0 * UorPerMas);
            ptArr[3] = new DPoint3d(20 * UorPerMas, 12 * UorPerMas, 0 * UorPerMas);
            ptArr[4] = new DPoint3d(21 * UorPerMas, 10 * UorPerMas, 0 * UorPerMas);
            LineStringElement lineStrEle = new LineStringElement(dgnModel, null, ptArr);
            lineStrEle.AddToModel();
        }

        public static void LineAndLineString3(string unparsed)
        {
            DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
            ModelInfo modelInfo = dgnModel.GetModelInfo();
            DPoint3d[] ptArr = new DPoint3d[5];
            ptArr[0] = new DPoint3d(0 * UorPerMas, 10 * UorPerMas, 0 * UorPerMas);
            ptArr[1] = new DPoint3d(1 * UorPerMas, 12 * UorPerMas, 0 * UorPerMas);
            ptArr[2] = new DPoint3d(3 * UorPerMas, 8 * UorPerMas, 0 * UorPerMas);
            ptArr[3] = new DPoint3d(5 * UorPerMas, 12 * UorPerMas, 0 * UorPerMas);
            ptArr[4] = new DPoint3d(6 * UorPerMas, 10 * UorPerMas, 0 * UorPerMas);
            CurvePrimitive curPri = CurvePrimitive.CreateLineString(ptArr);
            Element ele = DraftingElementSchema.ToElement(dgnModel, curPri, null);
            ele.AddToModel();
        }

        public static void ShapeAndComplexShape(string unparsed)
        {
            DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
            DPoint3d[] ptArr = new DPoint3d[6];
            ptArr[0] = new DPoint3d(0 * UorPerMas, -6 * UorPerMas, 0 * UorPerMas);
            ptArr[1] = new DPoint3d(0 * UorPerMas, -2 * UorPerMas, 0 * UorPerMas);
            ptArr[2] = new DPoint3d(2 * UorPerMas, -2 * UorPerMas, 0 * UorPerMas);
            ptArr[3] = new DPoint3d(2 * UorPerMas, -4 * UorPerMas, 0 * UorPerMas);
            ptArr[4] = new DPoint3d(4 * UorPerMas, -4 * UorPerMas, 0 * UorPerMas);
            ptArr[5] = new DPoint3d(4 * UorPerMas, -6 * UorPerMas, 0 * UorPerMas);
            ShapeElement shapeEle = new ShapeElement(dgnModel, null, ptArr);
            ElementPropertiesSetter elePropSet = new ElementPropertiesSetter();
            elePropSet.SetColor(0);
            elePropSet.SetWeight(2);
            elePropSet.Apply(shapeEle);
            shapeEle.AddToModel();
            for (int i = 0; i < 6; i++)
                ptArr[i].X += 5 * UorPerMas;
            CurvePrimitive curvePri = CurvePrimitive.CreateLineString(ptArr);
            CurveVector curVec = CurveVector.Create(CurveVector.BoundaryType.Outer);
            curVec.Add(curvePri);
            ptArr[2].Y = -8;
            DEllipse3d ellipse = new DEllipse3d();
            if (DEllipse3d.TryCircularArcFromCenterStartEnd(ptArr[2], ptArr[5], ptArr[0], out ellipse))
            {
                curvePri = CurvePrimitive.CreateArc(ellipse);
                curVec.Add(curvePri);
                Element eleTemp = DraftingElementSchema.ToElement(dgnModel, curVec, null);
                eleTemp.AddToModel();
                elePropSet.SetColor(1);
                elePropSet.SetWeight(2);
                elePropSet.Apply(eleTemp);
                eleTemp.AddToModel();
            }
        }

        public static void TextString(string unparsed)
        {
            DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
            DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
            TextBlockProperties txtBlockProp = new TextBlockProperties(dgnModel);
            txtBlockProp.IsViewIndependent = true;
            ParagraphProperties paraProp = new ParagraphProperties(dgnModel);
            DgnTextStyle txtStyle = DgnTextStyle.GetSettings(dgnFile);
            RunProperties runProp = new RunProperties(txtStyle, dgnModel);

            TextBlock txtBlock = new TextBlock(txtBlockProp, paraProp, runProp, dgnModel);
            txtBlock.AppendText("This is a textBlock Element");
            TextHandlerBase txtHandlerBase = TextHandlerBase.CreateElement(null, txtBlock);
            DTransform3d trans = DTransform3d.Identity;
            trans.Translation = new DVector3d(6 * UorPerMas, 2 * UorPerMas, 3 * UorPerMas);  //UOR unit
            TransformInfo transInfo = new TransformInfo(trans);
            txtHandlerBase.ApplyTransform(transInfo);
            txtHandlerBase.AddToModel();
        }

        public static void Cell(string unparsed)
        {
            DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
            DPoint3d[] ptArr = new DPoint3d[5];
            ptArr[0] = new DPoint3d(-15 * UorPerMas, -5 * UorPerMas, 0 * UorPerMas);
            ptArr[1] = new DPoint3d(-15 * UorPerMas, 5 * UorPerMas, 0 * UorPerMas);
            ptArr[2] = new DPoint3d(-5 * UorPerMas, 5 * UorPerMas, 0 * UorPerMas);
            ptArr[3] = new DPoint3d(-5 * UorPerMas, -5 * UorPerMas, 0 * UorPerMas);
            ptArr[4] = new DPoint3d(-15 * UorPerMas, -5 * UorPerMas, 0 * UorPerMas);
            ShapeElement shapeEle = new ShapeElement(dgnModel, null, ptArr);
            DPlacementZX dPlaceZX = DPlacementZX.Identity;
            dPlaceZX.Origin = new DPoint3d(-10 * UorPerMas, 0, 0);
            DEllipse3d ellipse = new DEllipse3d(dPlaceZX, 5 * UorPerMas, 5 * UorPerMas, Angle.Zero, Angle.TWOPI);
            EllipseElement elliEle = new EllipseElement(dgnModel, null, ellipse);
            List<Element> listEle = new List<Element>();
            listEle.Add(shapeEle);
            listEle.Add(elliEle);
            DPoint3d ptOri = new DPoint3d();
            DMatrix3d rMatrix = DMatrix3d.Identity;
            DPoint3d ptScale = new DPoint3d(1, 1, 1);
            CellHeaderElement cellHeaderEle = new CellHeaderElement(dgnModel, "CellElementSample", ptOri, rMatrix, listEle);
            cellHeaderEle.AddToModel();
        }

        public static void Dimension(string unparsed)
        {
            DgnFile dgnFile = Session.Instance.GetActiveDgnFile();
            DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
            double uorPerMast = dgnModel.GetModelInfo().UorPerMaster;
            DimensionStyle dimStyle = new DimensionStyle("DimStyle", dgnFile);
            dimStyle.SetBooleanProp(true, DimStyleProp.Placement_UseStyleAnnotationScale_BOOLINT);
            dimStyle.SetDoubleProp(1, DimStyleProp.Placement_AnnotationScale_DOUBLE);
            dimStyle.SetBooleanProp(true, DimStyleProp.Text_OverrideHeight_BOOLINT);
            dimStyle.SetDistanceProp(0.5 * uorPerMast, DimStyleProp.Text_Height_DISTANCE, dgnModel);
            dimStyle.SetBooleanProp(true, DimStyleProp.Text_OverrideWidth_BOOLINT);
            dimStyle.SetDistanceProp(0.4 * uorPerMast, DimStyleProp.Text_Width_DISTANCE, dgnModel);
            dimStyle.SetBooleanProp(true, DimStyleProp.General_UseMinLeader_BOOLINT);
            dimStyle.SetDoubleProp(0.01, DimStyleProp.Terminator_MinLeader_DOUBLE);
            dimStyle.SetBooleanProp(true, DimStyleProp.Value_AngleMeasure_BOOLINT);
            dimStyle.SetAccuracyProp((byte)AnglePrecision.Use1Place, DimStyleProp.Value_AnglePrecision_INTEGER);
            int alignInt = (int)DimStyleProp_General_Alignment.True;
            StatusInt status = dimStyle.SetIntegerProp(alignInt, DimStyleProp.General_Alignment_INTEGER);
            int valueOut;
            dimStyle.GetIntegerProp(out valueOut, DimStyleProp.General_Alignment_INTEGER);
            DgnTextStyle textStyle = new DgnTextStyle("TestStyle", dgnFile);
            LevelId lvlId = Settings.GetLevelIdFromName("Default");
            CreateDimensionCallbacks callbacks = new CreateDimensionCallbacks(dimStyle, textStyle, new Symbology(), lvlId, null);
            DimensionElement dimEle = new DimensionElement(dgnModel, callbacks, DimensionType.SizeArrow);
            if (dimEle.IsValid)
            {
                DPoint3d pt1 = DPoint3d.Zero, pt2 = DPoint3d.FromXY(uorPerMast * 10, uorPerMast * 0);
                dimEle.InsertPoint(pt1, null, dimStyle, -1);
                dimEle.InsertPoint(pt2, null, dimStyle, -1);
                dimEle.SetHeight(uorPerMast);
                DMatrix3d rMatrix = DMatrix3d.Identity;
                dimEle.SetRotationMatrix(rMatrix);
                dimEle.AddToModel();
            }
        }

        public static void BsplineCurve(string unparsed)
        {
            DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
            DPoint3d[] ptArr = new DPoint3d[5];
            ptArr[0] = new DPoint3d(0 * UorPerMas, 25 * UorPerMas, 0 * UorPerMas);
            ptArr[1] = new DPoint3d(5 * UorPerMas, 35 * UorPerMas, 0 * UorPerMas);
            ptArr[2] = new DPoint3d(10 * UorPerMas, 25 * UorPerMas, 0 * UorPerMas);
            ptArr[3] = new DPoint3d(15 * UorPerMas, 35 * UorPerMas, 0 * UorPerMas);
            ptArr[4] = new DPoint3d(20 * UorPerMas, 25 * UorPerMas, 0 * UorPerMas);
            MSBsplineCurve msBsplineCurve = MSBsplineCurve.CreateFromPoles(ptArr, null, null, 3, false, true);
            CurvePrimitive curvePri = CurvePrimitive.CreateBsplineCurve(msBsplineCurve);
            Element ele = DraftingElementSchema.ToElement(dgnModel, curvePri, null);
            ele.AddToModel();
        }

        public static void Cone(string unparsed)
        {
            DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
            DPoint3d ptTop = new DPoint3d(2 * UorPerMas, -15 * UorPerMas, 0 * UorPerMas);
            DPoint3d ptBottom = new DPoint3d(2 * UorPerMas, -15 * UorPerMas, 3 * UorPerMas);
            DMatrix3d rMatrix = DMatrix3d.Identity;
            ConeElement coneEle = new ConeElement(dgnModel, null, 2 * UorPerMas, 1 * UorPerMas, ptTop, ptBottom, rMatrix, true);
            coneEle.AddToModel();
        }

        public static void TestConvertToDgnNetEle(string unparsed)
        {
            BIM.Application app = Bentley.MstnPlatformNET.InteropServices.Utilities.ComApp;
            BIM.Point3d ptStart = app.Point3dZero();
            BIM.Point3d ptEnd = ptStart;
            ptStart.X = 10;
            BIM.LineElement lineEle = app.CreateLineElement2(null, ref ptStart, ref ptEnd);
            Element ele = SampleMixed.ElementOperation.ConvertToDgnNetEle(lineEle);
            ElementPropertiesSetter elePropSetter = new ElementPropertiesSetter();
            elePropSetter.SetColor(1);
            elePropSetter.SetWeight(2);
            elePropSetter.Apply(ele);
            ele.AddToModel();
        }

        public static void TestConvertToInteropEle(string unparsed)
        {
            DgnModel dgnModel = Session.Instance.GetActiveDgnModel();
            ModelInfo modelInfo = dgnModel.GetModelInfo();
            DPoint3d[] ptArr = new DPoint3d[5];
            ptArr[0] = new DPoint3d(0 * UorPerMas, 10 * UorPerMas, 0 * UorPerMas);
            ptArr[1] = new DPoint3d(1 * UorPerMas, 12 * UorPerMas, 0 * UorPerMas);
            ptArr[2] = new DPoint3d(3 * UorPerMas, 8 * UorPerMas, 0 * UorPerMas);
            ptArr[3] = new DPoint3d(5 * UorPerMas, 12 * UorPerMas, 0 * UorPerMas);
            ptArr[4] = new DPoint3d(6 * UorPerMas, 10 * UorPerMas, 0 * UorPerMas);
            CurvePrimitive curPri = CurvePrimitive.CreateLineString(ptArr);
            Element ele = DraftingElementSchema.ToElement(dgnModel, curPri, null);
            BIM.Element eleInterop = SampleMixed.ElementOperation.ConvertToInteropEle(ele);
            eleInterop.Color = 3;
            eleInterop.LineWeight = 4;
            ele.AddToModel();
        }
    }
}
