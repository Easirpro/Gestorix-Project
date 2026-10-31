using System.Text.RegularExpressions;

namespace CapaLogica
{
    // Requisitos de una contraseña nueva, iguales en el primer ingreso y en la recuperación.
    public static class ClsReglasPassword
    {
        public const string Requisitos =
            "La contraseña debe tener como mínimo 8 caracteres, una mayúscula, una minúscula y un número.";

        public static bool CumpleRequisitos(string password)
        {
            return Regex.IsMatch(password ?? "", @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$");
        }
    }
}
