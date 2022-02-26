using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImenikWpf
{
    public class Osoba : INotifyPropertyChanged
    {
        private string _ime = string.Empty;

        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                _ime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Ime"));
            }
        }

        private string _prezime = string.Empty;

        public string Prezime
        {
            get
            {
                return _prezime;
            }
            set
            {
                _prezime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Prezime"));
            }
        }

        private string _brojTelefona = string.Empty;

        public string BrojTelefona
        {
            get
            {
                return _brojTelefona;
            }
            set
            {
                _brojTelefona = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BrojTelefona"));
            }
        }

        private string _email = string.Empty;

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Email"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public override bool Equals(object? obj)
        {
            if (obj is Osoba o && o.BrojTelefona == BrojTelefona && o.Email == Email)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return BrojTelefona.GetHashCode() + Email.GetHashCode();
        }
    }
}