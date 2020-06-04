using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallenge.Data.Classes
{
    public abstract class FiguraGeometrica
    {
        public Tipo Figura { get; set; }

        public enum Idioma
        {
            Castellano = 1,
            Frances = 2,
            Ingles = 3
        }

        public enum Tipo
        {
            Cuadrado = 1,
            TrianguloEquilatero = 2,
            Circulo = 3,
            TrapecioIsosceles = 4
        }

        public abstract string TraducirForma(int cantidad, Idioma idioma);
        public abstract decimal CalcularArea();
        public abstract decimal CalcularPerimetro();
        public abstract string ObtenerLinea(int cantidad, decimal area, decimal perimetro, Idioma idioma);

        public static string Imprimir(List<FiguraGeometrica> formas, Idioma idioma)
        {
            var sb = new StringBuilder();

            if (!formas.Any())
            {
                if (idioma == Idioma.Castellano)
                    sb.Append("<h1>Lista vacía de formas!</h1>");
                else if (idioma == Idioma.Frances)
                    sb.Append("<h1>Liste vide de formes!</h1>");
                else
                    sb.Append("<h1>Empty list of shapes!</h1>");
            }
            else
            {
                if (idioma == Idioma.Castellano)
                    sb.Append("<h1>Reporte de Formas</h1>");
                else if (idioma == Idioma.Frances)
                    sb.Append("<h1>Rapport de forme</h1>");
                else
                    sb.Append("<h1>Shapes report</h1>");

                var cuadrados = formas.Where(x => x.Figura == Tipo.Cuadrado);
                var circulos = formas.Where(x => x.Figura == Tipo.Circulo);
                var triangulos = formas.Where(x => x.Figura == Tipo.TrianguloEquilatero);

                int numeroCuadrados = cuadrados.Count();
                int numeroCirculos = circulos.Count();
                int numeroTriangulos = triangulos.Count();

                decimal areaCuadrados = cuadrados.Sum(x => x.CalcularArea());
                decimal areaCirculos = circulos.Sum(x => x.CalcularArea());
                decimal areaTriangulos = triangulos.Sum(x => x.CalcularArea());

                decimal perimetroCuadrados = cuadrados.Sum(x => x.CalcularPerimetro());
                decimal perimetroCirculos = circulos.Sum(x => x.CalcularPerimetro());
                decimal perimetroTriangulos = triangulos.Sum(x => x.CalcularPerimetro());

                foreach (var item in formas.GroupBy(x => x.Figura))
                {
                    FiguraGeometrica tipo = item.FirstOrDefault();

                    switch (tipo.Figura)
                    {
                        case Tipo.Cuadrado:
                            sb.Append(tipo.ObtenerLinea(numeroCuadrados, areaCuadrados, perimetroCuadrados, idioma));
                            break;
                        case Tipo.Circulo:
                            sb.Append(tipo.ObtenerLinea(numeroCirculos, areaCirculos, perimetroCirculos, idioma));
                            break;
                        case Tipo.TrianguloEquilatero:
                            sb.Append(tipo.ObtenerLinea(numeroTriangulos, areaTriangulos, perimetroTriangulos, idioma));
                            break;
                    }
                }

                // FOOTER
                sb.Append("TOTAL:<br/>");
                sb.Append(numeroCuadrados + numeroCirculos + numeroTriangulos + " " + (idioma == Idioma.Castellano ? "formas" : "shapes") + " ");
                sb.Append((idioma == Idioma.Castellano ? "Perimetro " : "Perimeter ") + (perimetroCuadrados + perimetroTriangulos + perimetroCirculos).ToString("#.##") + " ");
                sb.Append("Area " + (areaCuadrados + areaCirculos + areaTriangulos).ToString("#.##"));
            }

            return sb.ToString();
        }

    }

}
