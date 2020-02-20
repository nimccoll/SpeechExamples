using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SystemSpeechDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SpeechRecognitionEngine _recognizer = null;

        public MainWindow()
        {
            InitializeComponent();

            var uriSource = new Uri(@"/SystemSpeechDemo;component/Assets/thumbsup.png", UriKind.Relative);
            imgRotator.Source = new BitmapImage(uriSource);

            _recognizer = new SpeechRecognitionEngine();
            _recognizer.LoadGrammar(new Grammar(new GrammarBuilder(new Choices(new string[] { "reset", "up", "down", "right", "left", "thumbs up" }))));
            _recognizer.SpeechRecognized += _recognizer_SpeechRecognized;
            _recognizer.SetInputToDefaultAudioDevice();
            _recognizer.RecognizeAsync(RecognizeMode.Multiple);
        }

        private void _recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                case "reset":
                    Reset();
                    break;
                case "thumbs up":
                    Reset();
                    break;
                case "up":
                    MoveUp();
                    break;
                case "down":
                    MoveDown();
                    break;
                case "right":
                    MoveRight();
                    break;
                case "left":
                    MoveLeft();
                    break;
                default:
                    break;
            }
        }

        private void btnUp_Click(object sender, RoutedEventArgs e)
        {
            MoveUp();
        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            MoveDown();
        }

        private void btnLeft_Click(object sender, RoutedEventArgs e)
        {
            MoveLeft();
        }

        private void btnRight_Click(object sender, RoutedEventArgs e)
        {
            MoveRight();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            var uriSource = new Uri(@"/SystemSpeechDemo;component/Assets/thumbsup.png", UriKind.Relative);
            imgRotator.Source = new BitmapImage(uriSource);
        }

        private void MoveUp()
        {
            var uriSource = new Uri(@"/SystemSpeechDemo;component/Assets/pointup.png", UriKind.Relative);
            imgRotator.Source = new BitmapImage(uriSource);
        }

        private void MoveDown()
        {
            var uriSource = new Uri(@"/SystemSpeechDemo;component/Assets/pointdown.png", UriKind.Relative);
            imgRotator.Source = new BitmapImage(uriSource);
        }

        private void MoveRight()
        {
            var uriSource = new Uri(@"/SystemSpeechDemo;component/Assets/pointright.png", UriKind.Relative);
            imgRotator.Source = new BitmapImage(uriSource);
        }

        private void MoveLeft()
        {
            var uriSource = new Uri(@"/SystemSpeechDemo;component/Assets/pointleft.png", UriKind.Relative);
            imgRotator.Source = new BitmapImage(uriSource);
        }
    }
}
