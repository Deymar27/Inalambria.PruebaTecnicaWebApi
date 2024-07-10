namespace Inalambria.PruebaTecnica.Convertidor
{
    public class ConvertirNumero
    {
        public string ConvertirATexto(double param)
        {
            string letra = "";
                if (param == 0)
                {
                    letra = "Cero";
                }
                else if (param == 1)
                {
                    letra = "uno";
                }
                else if (param == 2)
                {
                    letra = "dos";
                }
                else if (param == 3)
                {
                    letra = "tres";
                }
                else if (param == 4)
                {
                    letra = "cuatro";
                }
                else if (param == 5)
                {
                    letra = "cinco";
                }
                else if (param == 6)
                {
                    letra = "seis";
                }
                else if (param == 7)
                {
                    letra = "siete";
                }
                else if (param == 8)
                {
                    letra = "ocho";
                }
                else if (param == 9)
                {
                    letra = "nueve";
                }
                else if (param == 10)
                {
                    letra = "diez";
                }
                else if (param == 11)
                {
                    letra = "once";
                }
                else if (param == 12)
                {
                    letra = "doce";
                }
                else if (param == 13)
                {
                    letra = "trece";
                }
                else if (param == 14)
                {
                    letra = "catorce";
                }
                else if (param == 15)
                {
                    letra = "quince";
                }
                else if (param < 20)
                {
                    letra = "dieci" + ConvertirATexto(param - 10);
                }
                else if (param == 20)
                {
                    letra = "veinte";
                }
                else if (param < 30)
                {
                    letra = "veinti" + ConvertirATexto(param - 20);
                }
                else if (param == 30)
                {
                    letra = "treinta";
                }
                else if (param == 40)
                {
                    letra = "cuarenta";
                }
                else if (param == 50)
                {
                    letra = "cincuenta";
                }
                else if (param == 60)
                {
                    letra = "Sesenta";
                }
                else if (param == 70)
                {
                    letra = "setenta";
                }
                else if (param == 80)
                {
                    letra = "ochenta";
                }
                else if (param == 90)
                {
                    letra = "noventa";
                }
                else if (param < 100)
                {
                    letra = ConvertirATexto(Math.Truncate(param / 10) * 10) + " y " + ConvertirATexto((param % 10));
                }
                else if (param == 100)
                {
                    letra = "cien";
                }
                else if (param < 200)
                {
                    letra = "ciento" + " " + ConvertirATexto(param - 100);
                }
                else if (param == 200 || param == 300 || param == 400 || param == 600 || param == 800)
                {
                    letra = ConvertirATexto(param / 100) + "cientos";
                }
                else if (param == 500)
                {
                    letra = "quinientos";
                }
                else if (param == 700)
                {
                    letra = "setecientos";
                }
                else if (param == 900)
                {
                    letra = "novecientos";
                }
                else if (param < 1000)
                {
                    letra = ConvertirATexto(Math.Truncate(param / 100) * 100) + " " + ConvertirATexto(param % 100);
                }
                else if (param == 1000)
                {
                    letra = "mil";
                }
                else if (param < 2000)
                {
                    letra = "mil " + ConvertirATexto((param % 1000));
                }
                else if (param < 1000000)
                {
                    letra = ConvertirATexto(Math.Truncate(param / 1000)) + " mil";
                    if (Math.Truncate(param % 1000) != 0)
                    {
                        letra = letra + " " + ConvertirATexto(param % 1000);
                    }
                }
                else if (param == 1000000)
                {
                    letra = "un millon";
                }
                else if (param < 2000000)
                {
                    letra = "un millon " + ConvertirATexto(Math.Truncate(param % 1000000));
                }
                else if (param < 1000000000000)
                {
                    letra = ConvertirATexto(Math.Truncate(param / 1000000)) + " millones";
                    if ((param - (Math.Truncate(param / 1000000) * 1000000)) != 0)
                    {
                        letra = letra + " " + ConvertirATexto(param - (Math.Truncate(param / 1000000) * 1000000));
                    }
                }
            return letra.ToUpper();
        }
    }
}
