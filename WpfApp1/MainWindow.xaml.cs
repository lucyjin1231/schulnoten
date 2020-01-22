using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class FachMitNote : INotifyPropertyChanged
        {
            private double _note;
            private string _name;

            public string Name
            {
                get => _name;
                set
                {
                    if (_name != value)
                    {
                        _name = value;
                        OnPropertyChanged("Name");
                    }
                }
            }

            public double Note
            {
                get => _note;
                set
                {
                    if(_note != value)
                    {
                        _note = value;
                        OnPropertyChanged("Name");
                    }
                }
            }

            #region PropertyChanged

            private PropertyChangedEventHandler _propertyChanged;


            public virtual event PropertyChangedEventHandler PropertyChanged
            {
                add
                {
                    if (_propertyChanged != null)
                    {
                        foreach (Delegate d in _propertyChanged.GetInvocationList())
                        {
                            if (d.Equals(value))
                            {
                                return;
                            }
                        }
                    }

                    _propertyChanged += value;
                }
                remove
                {
                    if (_propertyChanged != null)
                    {
                        _propertyChanged -= value;
                    }
                }
            }

            protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
            {
                _propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }

            #endregion
        }

        public ObservableCollection<FachMitNote> FächerMitNoten { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            FächerMitNoten = new ObservableCollection<FachMitNote>();
            FächerMitNoten.CollectionChanged += FächerMitNoten_CollectionChanged;
            dg_fachNoten.ItemsSource = FächerMitNoten;
            dg_fachNoten.DataContext = FächerMitNoten;
        }

        public void Schlechtestenote()
        {
            double snote = 1;
            var noten = FächerMitNoten.Count();
            for (int i = 0; i < noten; i++)
            {
                var note = FächerMitNoten[i];
                if (snote < note.Note)
                {
                    snote = note.Note;
                }
            }
            tb_snote.Text = snote.ToString();

        }

        public void Bestenote()
        {
            double bestenote = FächerMitNoten.FirstOrDefault().Note;
            var noten = FächerMitNoten.Count();
            for (int i = 0; i < noten; i++)
            {
                var note = FächerMitNoten[i];
                if (bestenote > note.Note)
                {
                    bestenote = note.Note;
                }
            }
            tb_bestenote.Text = bestenote.ToString();

        }

        private void FächerMitNoten_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            int notenAnzahl = 0;
            double gesammtwert = 0;

            //Fächer mit Note ausgeben
            foreach (FachMitNote fachMitNote in FächerMitNoten)
            {
                notenAnzahl += 1;
                gesammtwert += fachMitNote.Note;
            }

            double notendurchschnitt = gesammtwert / notenAnzahl;

            tb_durchschnitt.Text = notendurchschnitt.ToString();
            Bestenote();
            Schlechtestenote();
        }

        private void Btn_neu_Click(object sender, RoutedEventArgs e)
        {
            btn_save.IsEnabled = true;
            btn_abbrechen.IsEnabled = true;
            tb_fach.IsEnabled = true;
            tb_note.IsEnabled = true;
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {

            dg_fachNoten.IsEnabled = true;
            if(double.TryParse(tb_note.Text, out double noteDouble))
            {
                var newFachMitNote = new FachMitNote { Name = tb_fach.Text, Note = noteDouble };

                if (newFachMitNote.Note >= 7)
                {
                    tbl_anweisung.Text = "Note ungültig!"; 
                }
                else
                {
                    FächerMitNoten.Add(newFachMitNote);
                    tb_fach.Text = "";
                    tb_note.Text = "";
                    tbl_anweisung.Text = "";
                    btn_save.IsEnabled = false;
                    btn_abbrechen.IsEnabled = false;
                    tb_fach.IsEnabled = false;
                    tb_note.IsEnabled = false;
                }
               
            }
            else
            {
                tbl_anweisung.Text = "Note ungültig!";
            }
        }

        private void Btn_abbrechen_Click(object sender, RoutedEventArgs e)
        {
            tb_fach.Text = "";
            tb_note.Text = "";
            btn_save.IsEnabled = false;
            btn_abbrechen.IsEnabled = false;
        }

        private void Btn_löschen_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dg_fachNoten.SelectedItems.Count; i++)
            {
                var selectedItem = dg_fachNoten.SelectedItems[i];

                if (selectedItem is FachMitNote fachMitNote)
                {
                    if(FächerMitNoten.Contains(fachMitNote))
                    {
                        FächerMitNoten.Remove(fachMitNote);
                        i--;
                    }
                }
            }
        }
    }
}
