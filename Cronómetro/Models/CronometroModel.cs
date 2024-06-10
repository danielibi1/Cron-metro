using Cronómetro.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Timers;

namespace Cronómetro.Models
{
    public class CronometroModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Timer _timerCronometro;
        private DateTime _tiempo;
        public DateTime Tiempo 
        {
            get { return _tiempo; }
            private set
            {
                _tiempo = value;
                OnPropertyChanged(nameof(Tiempo));
            }
        }

        private bool _isRunning;


        public bool IsRunning => _isRunning;

        public CronometroModel() 
        {
            //Iniciamos Timer con un intervalo de 1 segundo
            _timerCronometro = new Timer(1000);
            _timerCronometro.Elapsed += OnTimedEvent;
            _timerCronometro.AutoReset = true;
            _timerCronometro.Enabled = true;
            _tiempo = DateTime.Today;
        }
        public void Start()
        {
            if (!_isRunning)
            {
                _isRunning = true;
                _timerCronometro.Start();

            }

        }

        public void Stop() 
        { 
            _isRunning= false;
            _timerCronometro.Stop();
            Tiempo = DateTime.Today;
        }
        public void Pause()
        {
            if (_isRunning)
            {
                _isRunning = false;
                _timerCronometro.Stop();
            }
        }

        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (_isRunning)
            {
                Tiempo = Tiempo.AddSeconds(1);
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
