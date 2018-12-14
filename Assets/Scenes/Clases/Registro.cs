using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scenes.Clases
{
    public class Registro {
        private int PartidasJugadas;
        private int PartidasGanadas;
        private int PorcentajeVictorias;
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

        private int CalcularPorcentajeVictorias() {
            if (PartidasJugadas == 0) {
                return 0;
            } else {
                return (PartidasGanadas * 100) / PartidasJugadas;
            }

        }

        public int GetPjugadas()
        {
            return PartidasJugadas;
        }
        public int GetPganadas()
        {
            return PartidasGanadas;
        }
        public int GetPorVictorias()
        {
            return PorcentajeVictorias;
        }
        public int GetPuntos()
        {
            return Puntos;
        }
    }
}
