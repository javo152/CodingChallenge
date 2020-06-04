using System;

namespace CodingChallenge.Data.Classes
{
    public class Circulo : FiguraGeometrica
    {
        private readonly decimal _diametro;

        public Circulo(decimal diametro)
        {
            Figura = Tipo.Circulo;
            _diametro = diametro;
        }

        public override decimal CalcularArea()
        {
            return (decimal)Math.PI * (_diametro / 2) * (_diametro / 2);
        }

        public override decimal CalcularPerimetro()
        {
            return (decimal)Math.PI * _diametro;
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
            if (idioma == Idioma.Castellano) return cantidad == 1 ? "Círculo" : "Círculos";
            else if (idioma == Idioma.Frances) return cantidad == 1 ? "Cercle" : "Cercles";
            else return cantidad == 1 ? "Circle" : "Circles";
        }

    }
}
