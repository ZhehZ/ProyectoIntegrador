using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijoSi.Modelos
{
    public class Reserva
    {
        public string   idBuffet       { get; set; }
        public string   idFotografo    { get; set; }
        public string   idLocal        { get; set; }
        public string   idUsuario      { get; set; }
        public string   idReserva      { get; set; }
        public DateTime fechaReserva   { get; set; }
        public bool     estado         { get; set; }
        public bool     Selecciona     { get; set; }
    }
}
