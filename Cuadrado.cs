namespace CodingChallenge.Data.Classes
{
    public class Cuadrado : FiguraGeometrica
    {
        private readonly decimal _lado;

        public Cuadrado(decimal lado)
        {
            Figura = Tipo.Cuadrado;
            _lado = lado;
        }

        public override decimal CalcularArea()
        {
            return _lado * _lado;
        }

        public override decimal CalcularPerimetro()
        {
            return _lado * 4;
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
            if (idioma == Idioma.Castellano) return cantidad == 1 ? "Cuadrado" : "Cuadrados";
            else if (idioma == Idioma.Frances) return cantidad == 1 ? "Carré" : "Carrés";
            else return cantidad == 1 ? "Square" : "Squares";
        }
    }
}
