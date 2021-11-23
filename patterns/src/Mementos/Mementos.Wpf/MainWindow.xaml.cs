using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mementos.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// main window is the caretaker
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Stack<IMemento> undoStates, redoStates ;
        public MainWindow()
        {
            InitializeComponent();
            undoStates = new();
            redoStates = new();
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Undo, OnUndoExecute));
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Redo, OnRedoExecute));
            canvas.MouseUp += Canvas_MouseUp;
           
            // intialize with empty state
            StoreState();
        }

        private void OnRedoExecute(object sender, ExecutedRoutedEventArgs e)
        {
            Redo(sender, e);
        }

        private void Redo(object sender, ExecutedRoutedEventArgs e)
        {
            var myWindow = sender as MainWindow;
            if (e.Command != ApplicationCommands.Redo)
            {
                return;
            }
            if (redoStates.Count > 1)
            {
                redoStates.Pop();
                var last = redoStates.Peek();
                undoStates.Push(canvas.GetMemento()); // store current state
                canvas.SetMemento(last);
            }
            label1.Content = undoStates.Count;
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            StoreState();
        }

        private void OnUndoExecute(object sender, ExecutedRoutedEventArgs e)
        {
            var myWindow = sender as MainWindow;
            if (e.Command == ApplicationCommands.Undo)
            {
                myWindow.Undo(sender, e);
            }
        }

        private void Undo(object sender, ExecutedRoutedEventArgs e)
        {
            if(undoStates.Count > 1)
            {
                undoStates.Pop();
                var last = undoStates.Peek();
                redoStates.Push(canvas.GetMemento()); // store current state
                canvas.SetMemento(last);
            }
            label1.Content = undoStates.Count;
        }

        private void StoreState()
        {
            var memento = canvas.CreateMemento();
            undoStates.Push(memento);
            redoStates.Push(memento);
            label1.Content = undoStates.Count;
        }
    }
    public interface IMemento
    {
        object State { get; set; }
    }
    public class InkCanvasMemento : IMemento
    {
        public object State { get; set; }
    }
    public class InkCanvasWithUndo : InkCanvas
    {
        public IMemento CreateMemento()
        {
            Stroke[] strokesCopy = Strokes.ToArray();
            return new InkCanvasMemento { State = strokesCopy };
        }
        public void SetMemento(IMemento memento)
        {
            Strokes = new StrokeCollection((Stroke[])memento.State);
        }

        public void GetImages()
        {
            // https://stackoverflow.com/questions/40913569/saving-image-from-inkcanvas-as-png-or-jpeg-file
        }

        public IMemento GetMemento() => new InkCanvasMemento { State = Strokes.ToArray() };
    }
}
