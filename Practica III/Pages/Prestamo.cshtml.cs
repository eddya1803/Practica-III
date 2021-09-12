using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Practica_III.Pages
{
    public class PrestamoModel : PageModel
    {
        // Calcular las cuotas de un prestamo por metodo Frances, formula amortizaciones:
        // Cuota = Capital * interes / [1 - (1 + interes) ^ menos No. cuotas anual] 

        public double Monto { get; set; }

        public int CantidadCuotas { get; set; }

        public double InteresAnual { get; set; }

        public double CuotaMensual { get; set; } = 0;

       
        public void OnGet(double monto, int cantidadcuotas, double interesanual)
        {

          //CuotaMensual = 0;
            Monto = monto;
            CantidadCuotas = cantidadcuotas;
            double InteresMensual = interesanual / 12;

            CuotaMensual = (Monto *InteresMensual) / (1 - Math.Pow(1 + InteresMensual, - CantidadCuotas));
            CuotaMensual = Math.Round(CuotaMensual, 2);
        }
    }
}
