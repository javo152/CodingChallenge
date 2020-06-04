using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes
{
    public class TrapecioIsosceles : FiguraGeometrica
    {
        private readonly decimal _baseMenor;
        private readonly decimal _baseMayor;
        private readonly decimal _altura;
        public TrapecioIsosceles(decimal baseMayor, decimal baseMenor, decimal altura)
        {
            Figura = Tipo.TrapecioIsosceles;
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _altura = altura;
        }

        public override decimal CalcularArea()
        {
            return (_baseMenor + _baseMayor) * _altura / 2;
        }

        public override decimal CalcularPerimetro()
        {
            decimal x = (_baseMayor - _baseMenor) / 2;
            return (_baseMayor - x) * 2 + _altura * 2;
        }

        public override string ObtenerLinea(int cantidad, decimal area, decimal perimetro, Idioma idioma)
        {
            if (cantidad > 0)
            {
                if (idioma == Idioma.Castellano)
                    return $"{cantidad} {TraducirForma(cantidad, idioma)} | Area {area:#.##} | Perimetro {perimetro:#.##} <br/>";
                else if (idioma == Idioma.Frances)
                    return $"{cantidad} {TraducirForma(cantidad, idioma)} | Aire {area:#.##} | périmètre {perimetro:#.##} <br/>";

                return $"{cantidad} {TraducirForma(cantidad, idioma)} | Area {area:#.##} | Perimeter {perimetro:#.##} <br/>";
            }

            return string.Empty;
        }

        public override string TraducirForma(int cantidad, Idioma idioma)
        {
            if (idioma == Idioma.Castellano) return cantidad == 1 ? "Trapecio" : "Trapecios";
            else if (idioma == Idioma.Frances) return cantidad == 1 ? "trapèze" : "trapèzes";
            else return cantidad == 1 ? "trapeze" : "trapezes";
        }
    }
}
