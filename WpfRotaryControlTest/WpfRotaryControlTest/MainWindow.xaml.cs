using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DialMgr;

namespace WpfRotaryControlTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeDisplay();

            this.Width = 550;
            this.Height = 240;

            Thread thread = new Thread(DisplayValues);
            thread.Start();
        }

        Canvas MainCanvas;
        Button ButtonView;
        DialMgr.DialMgr DialMgr;
        RotaryControls.RotaryControl SimpleDial;
        RotaryControls.RotaryControl DetailedDial;

        void InitializeDisplay()
        {
            MainCanvas = canvasMain;

            ButtonView = new Button();
            ButtonView.Content = "Display Value";
            MainCanvas.Children.Add(ButtonView);
            ButtonView.AddHandler(Button.ClickEvent, new RoutedEventHandler(ButtonView_Click));
            Canvas.SetLeft(ButtonView, 50);
            Canvas.SetTop(ButtonView, 75);

            DialMgr = new DialMgr.DialMgr();
            SimpleDial = DialMgr.CreateSimpleDial(MinValue: -20.0, MaxValue: 20.0, CurrentValue: 0.0, TickIncrement: 2.0,
                                                       NumberMinorTicks: 5, DialScaleFactor: 0.7, FontScaleFactor: 1.2);
            MainCanvas.Children.Add(SimpleDial);
            Canvas.SetLeft(SimpleDial, 175);
            Canvas.SetTop(SimpleDial, 25);

            DetailedDial = DialMgr.CreateDetailedDial(MinValue: 0.1, MaxValue: 0.4, CurrentValue: 0.18, TickIncrement: 0.05,
                                            NumberMinorTicks: 5, DialScaleFactor: 0.7, FontScaleFactor: 1.2,DangerZones.DangerLowHigh);

            MainCanvas.Children.Add(DetailedDial);
            Canvas.SetLeft(DetailedDial, 350);
            Canvas.SetTop(DetailedDial, 25);

            // if you read the Dial values here,
            // need to surround with a try/catch block
            // in case user closes, then opens GUI
        }
        // Called within same GUI Thread
        void ButtonView_Click(object sender, RoutedEventArgs e)
        {
            string Msg ;

           Msg = "Simple Dial Value: " + SimpleDial.Value.ToString("0.##");
           Msg = Msg + "\n\n";
            Msg = Msg + "Detailed Dial Value: " + DetailedDial.Value.ToString("0.##");

            System.Windows.MessageBox.Show(Msg);
        }

        private void DisplayValues()
        {
            int Limit = 3;
            for (int i = 0; i < Limit; i = i + 1)
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));
                // need to wrap as some real time feeds, such
                // as VST plugins can end up calling this after
                // audio stops, creating a crash
                try
                {
                    string Msg;
                    // requires a method in RotaryControl to wrap
                    // access in Dispatcher.Invoke to defeat cross
                    // thread limitation
                    double TheGain = SimpleDial.GetCurrentValue();
                    double ThePan = DetailedDial.GetCurrentValue();

                    Msg = "Simple Dial Value: " + TheGain.ToString("0.##");
                    Msg = Msg + "\n\n";
                    Msg = Msg + "Detailed Dial Value: " + ThePan.ToString("0.##");
                
                    System.Windows.MessageBox.Show(Msg);

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
  }
