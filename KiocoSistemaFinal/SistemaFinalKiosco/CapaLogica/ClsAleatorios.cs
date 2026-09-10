using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Security.Cryptography;
using System;
using System.Linq;


namespace CapaLogica
{
    public static class Aleatorios
    {
        public static string Armar(bool esCaracteres, int cant, int cantCaractEspeciales = 0)
        {
            const string numeros = "0123456789";
            const string letras = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string especiales = "!@#$%^&*()_-+=<>?";

            if (!esCaracteres)
            {
                return Generar(cant, numeros);
            }

            if (cantCaractEspeciales > cant) cantCaractEspeciales = cant;

            char[] resultado = new char[cant];

            var posicionesEspeciales = Enumerable.Range(0, cant)
                .OrderBy(x => RandomNumberGenerator.GetInt32(int.MaxValue))
                .Take(cantCaractEspeciales)
                .ToHashSet();

            for (int i = 0; i < cant; i++)
            {
                if (posicionesEspeciales.Contains(i))
                {
                    resultado[i] = especiales[
                        RandomNumberGenerator.GetInt32(especiales.Length)
                    ];
                }
                else
                {
                    string alfaNumerico = numeros + letras;

                    resultado[i] = alfaNumerico[
                        RandomNumberGenerator.GetInt32(alfaNumerico.Length)
                    ];
                }
            }

            return new string(resultado);
        }

        private static string Generar(int longitud, string caracteres)
        {
            return new string(
                Enumerable.Range(0, longitud)
                    .Select(_ => caracteres[
                        RandomNumberGenerator.GetInt32(caracteres.Length)
                    ])
                    .ToArray()
            );
        }
    }
}

