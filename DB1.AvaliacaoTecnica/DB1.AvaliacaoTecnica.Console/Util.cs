using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Console
{
    /// <summary>
    /// Classe Util
    /// somente para atributos utilizados durante a execução do procedimento
    /// </summary>
    public class Util
    {
        public List<Int32> ListaExercicio2 { get; set; }

        public List<Int32> ListaExercicio3_1 { get; set; }

        public List<Int32> ListaExercicio3_2 { get; set; }

        public Util()
        {

            this.ListaExercicio2 = new List<Int32>();
            this.ListaExercicio3_1 = new List<Int32>();
            this.ListaExercicio3_2 = new List<Int32>();
        }


        public void EsvaziaLista()
        {
            ListaExercicio2.Clear();
            ListaExercicio3_1.Clear();
            ListaExercicio3_2.Clear();
        }

    }
}
