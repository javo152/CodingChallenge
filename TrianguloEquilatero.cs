using System;

namespace CodingChallenge.Data.Classes
{
    public class TrianguloEquilatero : FiguraGeometrica
    {
        private readonly decimal _lado;

        public TrianguloEquilatero(decimal lado)
        {
            Figura = Tipo.TrianguloEquilatero;
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 3;
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
            if (idioma == Idioma.Castellano) return cantidad == 1 ? "Triángulo" : "Triángulos";
            else return cantidad == 1 ? "Triangle" : "Triangles";  //Igual en frances e inglés.
        }
    }
}
