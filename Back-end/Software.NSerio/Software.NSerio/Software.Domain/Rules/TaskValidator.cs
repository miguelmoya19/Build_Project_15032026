using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Software.Domain.Rules
{
    public static class TaskValidator
    {
        public static void ValidateFieldDescription(string text)
        {
            if (String.IsNullOrEmpty(text)) throw new Exception("No puede contener el titulo en vacio.");
        }
        public static void ValidatorLengthTitle(string text)
        {
            if (string.IsNullOrWhiteSpace(text) || text.Length > 200) throw new Exception("El tamaño max es 20 caracteres");
        }
        public static void ValidatorLengthStatus(string text) { if (String.IsNullOrEmpty(text) || text.Length > 20) throw new Exception("No se puede tener vacio el campo de titulo"); string[] validator = ["ToDo", "InProgress", "Blocked", "Completed"]; if (!validator.Contains(text)) throw new Exception("Valores no aceptados en el campo del estado."); }
        public static void ValidatorEstimatedComplexity(int value)
        {
            if (value <= 0 || value > 5) throw new Exception("No se puede obtener ese rango de estados.");
        }
        public static void ValidatorFkProjectAndDev(int? dev,int? proj)
        {
            if (dev is null) throw new ArgumentNullException("Error: no se puede tener el id como null del desarollador.");
            if (proj is null) throw new ArgumentNullException("Error: no se puede tener el id como null del proyecto.");
        }
    }
}
    