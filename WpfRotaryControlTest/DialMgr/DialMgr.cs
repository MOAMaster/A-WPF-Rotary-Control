using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace DialMgr
{
    public enum DangerZones { DangerNone, DangerLow, DangerHigh, DangerLowHigh };

    public class DialMgr
    {
        public RotaryControls.RotaryControl CreateSimpleDial(double MinValue,  double MaxValue, double CurrentValue, double TickIncrement,
                                                             int NumberMinorTicks, double DialScaleFactor, double FontScaleFactor)
        {
            RotaryControls.RotaryControl Dial = new RotaryControls.RotaryControl();

            Dial.Foreground = new SolidColorBrush(Colors.Black);
            Dial.Background = new SolidColorBrush(Colors.Transparent);
            Dial.FontSize = Dial.FontSize * FontScaleFactor;

            double NumberTicks = ((MaxValue - MinValue) / TickIncrement) + 1;
            Dial.MinimumValue = MinValue;
            Dial.Value = CurrentValue;
            Dial.NumberOfMajorTicks = (int)NumberTicks; // Combined with increment determines max
            Dial.MajorTickIncrement = TickIncrement;
            Dial.NumberOfMinorTicks = NumberMinorTicks;
            Dial.MajorTickBrush = new SolidColorBrush(Colors.White);
            Dial.MinorTickBrush = new SolidColorBrush(Colors.White);
            Dial.OuterDialFill = new SolidColorBrush(Colors.SteelBlue);

            Dial.OuterDialBorder = new SolidColorBrush(Colors.Transparent);
            Dial.OuterDialBorderThickness = 1;
            Dial.InnerDialRadius = 60;

            LinearGradientBrush PointerFillBrush = new LinearGradientBrush();
            PointerFillBrush.StartPoint = new Point(0.5, 1);
            PointerFillBrush.EndPoint = new Point(0.5, 0);
            GradientStopCollection Stops = new GradientStopCollection();
//            Stops.Add(new GradientStop(color: (Color)ColorConverter.ConvertFromString("#DDDDDD"), offset: 0));
//            Stops.Add(new GradientStop(color: (Color)ColorConverter.ConvertFromString("#BBBBBB"), offset: 1.0));
            Stops.Add(new GradientStop(color: Colors.Red, offset: 0));
            Stops.Add(new GradientStop(color: Colors.LightSalmon, offset: 1.0));
            PointerFillBrush.GradientStops = Stops;
            Dial.PointerFill = PointerFillBrush;

            // By default, the control is 200 units wide.
            Dial.LayoutTransform = new ScaleTransform(scaleX: DialScaleFactor, scaleY: DialScaleFactor);

            return Dial;
        }

        public RotaryControls.RotaryControl CreateDetailedDial(double MinValue, double MaxValue, double CurrentValue, double TickIncrement,
                                                              int NumberMinorTicks, double DialScaleFactor, double FontScaleFactor, DangerZones Zones)
        {
            RotaryControls.RotaryControl Dial = new RotaryControls.RotaryControl();

            Dial.Foreground = new SolidColorBrush(Colors.Black);
            Dial.Background = new SolidColorBrush(Colors.Transparent);
            Dial.FontBrush = new SolidColorBrush(Colors.White);
            Dial.FontSize = 10;
            Dial.FontSize = Dial.FontSize * FontScaleFactor;

            double NumberTicks = ((MaxValue - MinValue) / TickIncrement) + 1;
            Dial.MinimumValue = MinValue;
            Dial.Value = CurrentValue;
            Dial.NumberOfMajorTicks = (int)NumberTicks; // Combined with increment determines max
            Dial.MajorTickIncrement = TickIncrement;
            Dial.NumberOfMinorTicks = NumberMinorTicks;

            Dial.MajorTickBrush = new SolidColorBrush(Colors.White);
            Dial.MinorTickBrush = new SolidColorBrush(Colors.White);

            LinearGradientBrush PointerFillBrush = new LinearGradientBrush();
            PointerFillBrush.StartPoint = new Point(0.5, 1);
            PointerFillBrush.EndPoint = new Point(0.5, 0);
            GradientStopCollection Stops = new GradientStopCollection();
 //           Stops.Add(new GradientStop(color: (Color)ColorConverter.ConvertFromString("#DDDDDD"), offset: 0));
 //           Stops.Add(new GradientStop(color: (Color)ColorConverter.ConvertFromString("#AAAAAA"), offset: 1.0));
            Stops.Add(new GradientStop(color: Colors.Tomato, offset: 0));
            Stops.Add(new GradientStop(color: Colors.Tomato, offset: 1.0));
            PointerFillBrush.GradientStops = Stops;
            Dial.PointerFill = PointerFillBrush;
//   Dial.PointerLength = 45;
//          Dial.PointerWidth = 2;
            Dial.PointerLength = 72;
            Dial.PointerWidth = 5;
            Dial.PointerType = "standard";


            LinearGradientBrush OuterDialFillBrush = new LinearGradientBrush();
            OuterDialFillBrush.StartPoint = new Point(0.5, 1);
            OuterDialFillBrush.EndPoint = new Point(0.5, 0);
            GradientStopCollection ODStops = new GradientStopCollection();
            ODStops.Add(new GradientStop(color: Colors.Black, offset: 0));
            ODStops.Add(new GradientStop(color: Colors.Gray, offset: 0.5));
            ODStops.Add(new GradientStop(color: Colors.Black, offset: 1.0));
            OuterDialFillBrush.GradientStops = ODStops;
            Dial.OuterDialFill = OuterDialFillBrush;

            LinearGradientBrush OuterDialBorderBrush = new LinearGradientBrush();
            OuterDialBorderBrush.StartPoint = new Point(0.5, 1);
            OuterDialBorderBrush.EndPoint = new Point(0.5, 0);
            GradientStopCollection OBStops = new GradientStopCollection();
//            OBStops.Add(new GradientStop(color: Colors.Gray, offset: 0));
//            OBStops.Add(new GradientStop(color: Colors.White, offset: 0.5));
//            OBStops.Add(new GradientStop(color: Colors.Gray, offset: 1.0));
            OBStops.Add(new GradientStop(color: Colors.Turquoise, offset: 0));
            OBStops.Add(new GradientStop(color: Colors.Turquoise, offset: 0.5));
            OBStops.Add(new GradientStop(color: Colors.Turquoise, offset: 1.0));
            OuterDialBorderBrush.GradientStops = OBStops;
            Dial.OuterDialBorder = OuterDialBorderBrush;
//          Dial.OuterDialBorderThickness = 3;
            Dial.OuterDialBorderThickness = 5;

            LinearGradientBrush InnerDialFillBrush = new LinearGradientBrush();
            InnerDialFillBrush.StartPoint = new Point(0.5, 1);
            InnerDialFillBrush.EndPoint = new Point(0.5, 0);
            GradientStopCollection IDStops = new GradientStopCollection();
            IDStops.Add(new GradientStop(color: Colors.White, offset: 0));
            IDStops.Add(new GradientStop(color: Colors.White, offset: 0.5));
            IDStops.Add(new GradientStop(color: Colors.White, offset: 1.0));
            InnerDialFillBrush.GradientStops = IDStops;
            Dial.InnerDialFill = InnerDialFillBrush;
            Dial.InnerDialRadius = 0;

            Dial.LabelDialRadius = 48;
            Dial.StartAngleInDegrees = 210;
            Dial.EndAngleInDegrees = 150;

            LinearGradientBrush PointerAxleFillBrush = new LinearGradientBrush();
            PointerAxleFillBrush.StartPoint = new Point(0.5, 1);
            PointerAxleFillBrush.EndPoint = new Point(0.5, 0);
            GradientStopCollection PAStops = new GradientStopCollection();
            PAStops.Add(new GradientStop(color: Colors.Gray, offset: 0));
            PAStops.Add(new GradientStop(color: Colors.White, offset: 0.5));
            PAStops.Add(new GradientStop(color: Colors.Gray, offset: 1.0));
            PointerAxleFillBrush.GradientStops = PAStops;
            Dial.InnerDialFill = PointerAxleFillBrush;

            Dial.SegmentThickness = 5;
            Dial.SegmentRadius = 35;

            RotaryControls.RotaryControlSegment[] Segments = null;
            switch (Zones)
            {
                case DangerZones.DangerNone:
                    Segments = new RotaryControls.RotaryControlSegment[2];
                    Segments[0] = new RotaryControls.RotaryControlSegment();
                    Segments[0].Fill = new SolidColorBrush(Colors.YellowGreen); Segments[0].AngleInDegrees = 60;
                    Segments[1] = new RotaryControls.RotaryControlSegment();
                    Segments[1].Fill = new SolidColorBrush(Colors.YellowGreen); Segments[1].AngleInDegrees = 240;
                    break;
                case DangerZones.DangerLow:
                    Segments = new RotaryControls.RotaryControlSegment[4];
                    Segments[0] = new RotaryControls.RotaryControlSegment();
                    Segments[0].Fill = new SolidColorBrush(Colors.Crimson); Segments[0].AngleInDegrees = 60;
                    Segments[1] = new RotaryControls.RotaryControlSegment();
                    Segments[1].Fill = new SolidColorBrush(Colors.Orange); Segments[1].AngleInDegrees = 30;
                    Segments[2] = new RotaryControls.RotaryControlSegment();
                    Segments[2].Fill = new SolidColorBrush(Colors.Gold); Segments[2].AngleInDegrees = 30;
                    Segments[3] = new RotaryControls.RotaryControlSegment();
                    Segments[3].Fill = new SolidColorBrush(Colors.YellowGreen); Segments[3].AngleInDegrees = 30;
                    break;
                case DangerZones.DangerHigh:
                    Segments = new RotaryControls.RotaryControlSegment[4];
                    Segments[0] = new RotaryControls.RotaryControlSegment();
                    Segments[0].Fill = new SolidColorBrush(Colors.YellowGreen); Segments[0].AngleInDegrees = 210;
                    Segments[1] = new RotaryControls.RotaryControlSegment();
                    Segments[1].Fill = new SolidColorBrush(Colors.Gold); Segments[1].AngleInDegrees = 30;
                    Segments[2] = new RotaryControls.RotaryControlSegment();
                    Segments[2].Fill = new SolidColorBrush(Colors.Orange); Segments[2].AngleInDegrees = 30;
                    Segments[3] = new RotaryControls.RotaryControlSegment();
                    Segments[3].Fill = new SolidColorBrush(Colors.Crimson); Segments[3].AngleInDegrees = 30;
                    break;
                case DangerZones.DangerLowHigh:
                    Segments = new RotaryControls.RotaryControlSegment[8];
                    Segments[0] = new RotaryControls.RotaryControlSegment();
                    Segments[0].Fill = new SolidColorBrush(Colors.Crimson); Segments[0].AngleInDegrees = 34;
                    Segments[1] = new RotaryControls.RotaryControlSegment();
                    Segments[1].Fill = new SolidColorBrush(Colors.Orange); Segments[1].AngleInDegrees = 30;
                    Segments[2] = new RotaryControls.RotaryControlSegment();
                    Segments[2].Fill = new SolidColorBrush(Colors.Gold); Segments[2].AngleInDegrees = 30;
                    Segments[3] = new RotaryControls.RotaryControlSegment();
                    Segments[3].Fill = new SolidColorBrush(Colors.YellowGreen); Segments[3].AngleInDegrees = 30;
                    Segments[4] = new RotaryControls.RotaryControlSegment();
                    Segments[4].Fill = new SolidColorBrush(Colors.YellowGreen); Segments[4].AngleInDegrees = 84;
                    Segments[5] = new RotaryControls.RotaryControlSegment();
                    Segments[5].Fill = new SolidColorBrush(Colors.Gold); Segments[5].AngleInDegrees = 30;
                    Segments[6] = new RotaryControls.RotaryControlSegment();
                    Segments[6].Fill = new SolidColorBrush(Colors.Orange); Segments[6].AngleInDegrees = 30;
                    Segments[7] = new RotaryControls.RotaryControlSegment();
                    Segments[7].Fill = new SolidColorBrush(Colors.Crimson); Segments[7].AngleInDegrees = 30;
                    break;
            }
            Dial.Segments = Segments;

            // By default, the control is 200 units wide.
            Dial.LayoutTransform = new ScaleTransform(scaleX: DialScaleFactor, scaleY: DialScaleFactor);

            return Dial;
        }

    }
}
