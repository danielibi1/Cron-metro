using Cronómetro.Commands;
using Cronómetro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cronómetro.ViewModels
{

    public class CronometroViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public readonly CronometroModel _cronometro = new CronometroModel();
        public string TiempoVista
        {
            get { return _cronometro.Tiempo.ToString("HH:mm:ss"); }
        }
        public ICommand StartCommand { get; }
        public ICommand PauseCommand { get; }
        public ICommand StopCommand { get; }
        public CronometroViewModel()
        {
            StartCommand = new RelayCommand(Start);
            PauseCommand = new RelayCommand(Pause);
            StopCommand = new RelayCommand(Stop);
            _cronometro.PropertyChanged += Cronometro_PropertyChanged;
        }

        private void Start()
        {
            _cronometro.Start();
        }

        private void Pause()
        {
            _cronometro.Pause();
            
        }

        private void Stop()
        {
            _cronometro.Stop();
        }
        private void Cronometro_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CronometroModel.Tiempo))
            {
                OnPropertyChanged(nameof(TiempoVista));
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
