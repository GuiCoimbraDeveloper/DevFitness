using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFitness.ConsoleApp
{
    public class Refeicao
    {

        public Refeicao(string descricao, int calorias)
        {
            Descricao = descricao;
            Calorias = calorias;
        }

        //public: o acesso e publico
        //protected: o acesso esta limitado para a propria classe ou classes derivadas
        //internal: o acesso esta limitado ao assembly atual
        //private : o acesso está limitado a propria classe

        public string Descricao { get; private set; }
        public int Calorias { get; private set; }

        public virtual void ImprimirMensagem()
        {
            Console.WriteLine($"{Descricao}, com {Calorias} calorias.");
        }
    }
}
