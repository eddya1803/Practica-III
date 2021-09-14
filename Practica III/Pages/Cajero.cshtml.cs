using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Practica_III.Pages
{
    public class CajeroModel : PageModel
    {
        public string NombreBanco { get; set; }

        public int Solicitado { get; set; }

        public int CantidadMil { get; set; }

        public int CantidadQuinientos { get; set; }

        public int CantidadCien { get; set; }

        public string Mensaje { get; set; }

        public Boolean Continuar { get; set; }

        public CajeroModel()
        {
            this.Solicitado = 0;
            this.Mensaje = "";
            this.Continuar = false;
        }

        public void OnGet(string nombrebanco, int solicitado, Boolean continuar)
        {
            var Mil = 9;
            var Quinientos = 19;
            var Cien = 99;
            var Disponible = (1000 * Mil) + (500 * Quinientos) + (100 * Cien);

            NombreBanco = nombrebanco;
            Solicitado = solicitado;
            Continuar = continuar;
            do
            {
                CantidadMil = 0;
                CantidadQuinientos = 0;
                CantidadCien = 0;
                var restoQuinientos = 0;
                var restoMil = 0;

                if (Solicitado % 100 == 0 && Disponible >= Solicitado) // Verificando que el retiror sea multiplo de cien
                {

                    if (NombreBanco == "ABC") // Comprovando si es el Bco ABC
                    {

                        if (Solicitado > 10000) // Condicionando que no exceda el limite por retiro en ABC
                        {

                            Mensaje = "Este monto excede el limite permitido  por el banco";
                            Continuar = true;

                        }
                        else
                        {
                            if (Solicitado >= 1000 && Mil > 0)
                            {

                                CantidadMil = Solicitado / 1000;
                                restoMil = Solicitado % 1000;
                                Mil = Mil - CantidadMil;
                                Disponible = Disponible - (CantidadMil * 1000);

                            }
                            else
                            {
                                restoMil = Solicitado;
                            }

                            if (restoMil >= 500 && Quinientos >= restoMil)
                            {

                                CantidadQuinientos = restoMil / 500;
                                restoQuinientos = restoMil % 500;
                                Quinientos = Quinientos - CantidadQuinientos;
                                Disponible = Disponible - (CantidadQuinientos * 500);

                            }
                            else
                            {
                                restoQuinientos = restoMil;
                            }

                            if (restoQuinientos > 100 && Cien >= restoQuinientos)
                            {

                                CantidadCien = restoMil / 100;
                                Cien = Cien - CantidadCien;
                                Disponible = Disponible - (CantidadCien * 100);

                            }
                            Mensaje = "Retiro Realizado";

                        };

                    }
                    else
                    {

                        if (Solicitado > 2000)  // Limite para un banco diferente a "ABC"
                        {

                            Mensaje = "Este monto excede el limite permitido por el banco";
                            Continuar = true;

                        }
                        else
                        {
                            if (Solicitado >= 1000 && Mil > 0)
                            {

                                CantidadMil = Solicitado / 1000;
                                restoMil = Solicitado % 1000;
                                Mil = Mil - CantidadMil;
                                Disponible = Disponible - (CantidadMil * 1000);

                            }
                            else
                            {
                                restoMil = Solicitado;
                            }

                            if (restoMil >= 500 && Quinientos >= restoMil)
                            {

                                CantidadQuinientos = restoMil / 500;
                                restoQuinientos = restoMil % 500;
                                Quinientos = Quinientos - CantidadQuinientos;
                                Disponible = Disponible - (CantidadQuinientos * 500); 

                            }
                            else
                            {
                                restoQuinientos = restoMil;
                            }

                            if (restoQuinientos >= 100 && Cien >= restoQuinientos)
                            {

                                CantidadCien = restoMil / 100;
                                Cien = Cien - CantidadCien;
                                Disponible = Disponible - (CantidadCien * 100);

                            }
                            Mensaje = "Retiro Realizado";

                        }

                    }

                }
                else
                {
                    Mensaje = "Cantidad NO puede ser dispensada";
                    Continuar = true;
                }
                               
            } while (Continuar == false);

        }

    }

}
