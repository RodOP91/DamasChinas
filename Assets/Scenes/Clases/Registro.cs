using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scenes.Clases
{
    public class Registro {
        private int PartidasJugadas;
        private int PartidasGanadas;
        private float PorcentajeVictorias;
        private int Puntos;
        private int IdUsuario;

        public Registro() {

        }

        public Registro(int partidasJugadas, int partidasGanadas, int puntos, int idUsuario)
        {
            PartidasJugadas = partidasJugadas;
            PartidasGanadas = partidasGanadas;
            PorcentajeVictorias = CalcularPorcentajeVictorias();
            Puntos = puntos;
            IdUsuario = idUsuario;
        }

        private float CalcularPorcentajeVictorias() {
            return (PartidasGanadas / PartidasJugadas) * 100;
        }
    }
}
