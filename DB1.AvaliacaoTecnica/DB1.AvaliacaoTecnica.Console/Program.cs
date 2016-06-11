using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using System.Text;
using System.Threading.Tasks;

namespace DB1.AvaliacaoTecnica.Console
{
    static class Program
    {
        #region "main"
        static IExercicio1 repositorio1;
        static IExercicio2 repositorio2;
        static IExercicio3 repositorio3;

        static void Main(string[] args)
        {
            #region "Configurando as dependencias"
            IKernel kernal = new StandardKernel();
            kernal.Bind<IExercicio1>().To<Exercicio1>();
            kernal.Bind<IExercicio2>().To<Exercicio2>();
            kernal.Bind<IExercicio3>().To<Exercicio3>();
            repositorio1 = kernal.Get<IExercicio1>();
            repositorio2 = kernal.Get<IExercicio2>();
            repositorio3 = kernal.Get<IExercicio3>();
            #endregion

            IniciaExercicios();
        }
        #endregion
        #region "Inicializa"
        static void IniciaExercicios()
        {
            System.Console.Clear();
            System.Console.WriteLine(" Digite 1 ,2 OU 3 para entrar nos exercicios (SOMENTE NUMEROS INTEIROS POSITIVOS)");
            var answer = System.Console.ReadLine();
            switch (Convert.ToInt32(answer))
            {
                case 1:
                    System.Console.Clear();
                    repositorio1.Resolucao_Exercicio1();
                    break;
                case 2:
                    System.Console.Clear();
                    repositorio2.Resolucao_Exercicio2();
                    break;

                case 3:
                    System.Console.Clear();
                    repositorio3.Resolucao_Exercicio3();
                    break;
                default:
                    System.Console.WriteLine("Esse valor não foi fornecido (APERTE QUALQUER TECLA PARA VOLTAR)");
                    System.Console.ReadKey();
                    IniciaExercicios();
                    break;
            }
        }
        #endregion


        #region "Interfaces"
        interface IExercicio1
        {

            /// <summary>
            /// Assinatura a ser complementada pela classe que a implementa
            /// </summary>
            void Resolucao_Exercicio1();

            /// <summary>
            /// Assinatura do método que retorna o Count do numero de sequencia COllatz
            /// </summary>
            /// <param name="n"></param>
            /// <returns></returns>
            int GetCycleLength(int n);

            /// <summary>
            /// Efetua os procedimentos para os calculos para Collatz
            /// </summary>
            /// <param name="n"></param>
            void Collatz(ref int n);

        }

        interface IExercicio2
        {
            /// <summary>
            /// Repostiorio que inicia o procedimento do exercicio 2
            /// </summary>
            void Resolucao_Exercicio2();

            /// <summary>
            /// Repositorio usado somente para preenchimento do IList
            /// </summary>
            /// <param name="number"></param>
            void PreencheArrrayExercicio2(Int32 number);

            /// <summary>
            /// Repotistorio que esvazia lista
            /// </summary>
            void EsvaziaLista();

        }

        interface IExercicio3
        {

            /// <summary>
            /// Repostiorio que inicia o processamento do exercicio 3
            /// </summary>
            void Resolucao_Exercicio3();

            /// <summary>
            /// Preenchimento do Array
            /// </summary>
            void PreencheArray_32();

            /// <summary>
            /// Repotistorio que esvazia lista
            /// </summary>
            void EsvaziaLista();

            /// <summary>
            /// Repostiorio que fornece o resultado final da intersecção de arrays
            /// </summary>
            void CruzaArraysExercicio3();
        }
        #endregion

        #region "Exercicio1"
        class Exercicio1 : IExercicio1
        {

            public void Resolucao_Exercicio1()
            {
                try
                {
                    IList<Int32> lista = new List<Int32>();
                    System.Console.WriteLine("EXERCICIO  - 1 ");
                    System.Console.WriteLine("\n");
                    System.Console.WriteLine(" Entre com um numero INTEIRO POSITIVO para achar o numero que produz a maior sequencia de Collatz ");
                    var retorno = Convert.ToInt32(System.Console.ReadLine());
                    if (retorno > 0)
                    {
                        System.Console.WriteLine("Processando...");
                        for (int i = 1; i < retorno + 1; i++)
                        {
                            lista.Add(GetCycleLength(i));
                        }
                        System.Console.WriteLine(String.Format("A maior sequencia é {0} e o numero que tem essa maior sequencia é: {1}", lista.Max(), lista.IndexOf(lista.Max()) + 1));
                        System.Console.ReadKey();
                        System.Console.WriteLine("Digite 1 para voltar ao exercicio ou qualquer tecla para retonar ao Inicio");
                        switch (Convert.ToString(System.Console.ReadLine()))
                        {
                            case "1":
                                System.Console.Clear();
                                Resolucao_Exercicio1();
                                break;
                            default:
                                Program.IniciaExercicios();
                                break;
                        }
                    }
                    else
                    {
                        System.Console.Clear();
                        Resolucao_Exercicio1();
                    }
                }
                catch
                {
                    System.Console.Clear();
                    Resolucao_Exercicio1();
                }
            }

            public int GetCycleLength(int n)
            {
                if (n > 0)
                {
                    int count = 1;
                    while (n != 1)
                    {
                        Collatz(ref n);
                        count++;
                    }
                    return count;
                }
                else
                {
                    return -1;
                }
            }

            public void Collatz(ref int n)
            {
                if (n % 2 == 0)
                {
                    n /= 2;
                }
                else
                {
                    n = (3 * n) + 1;
                }
            }
        }
        #endregion

        #region "Exercicio2"
        class Exercicio2 : IExercicio2
        {
            Util util = new Util();
            public void Resolucao_Exercicio2()
            {
                try
                {

                    bool somenteImpar = true;
                    System.Console.WriteLine("EXERCICIO (2) -- Entre com o numero inteiro (Positivo) do elemento do array ou (-1) para verificar o conteúdo do array");
                    var answer = Convert.ToInt32(System.Console.ReadLine());
                    if (answer != -1)
                    {
                        PreencheArrrayExercicio2(answer);
                        Resolucao_Exercicio2();
                    }
                    else
                    {
                        util.ListaExercicio2.Sort();
                        foreach (int valor in util.ListaExercicio2)
                        {
                            if (valor % 2 == 0)
                                somenteImpar = false;
                        }
                        StringBuilder retorno = new StringBuilder();
                        if (util.ListaExercicio2.Count() > 0)
                        {
                            if (somenteImpar)
                            {
                                retorno.Append("O array contem somente valores ímpares : {");
                                foreach (int valor in util.ListaExercicio2)
                                    retorno.Append(String.Format("{0},", valor));
                                retorno.Append(" }").Replace(" , }", "}");

                                System.Console.WriteLine(retorno.ToString());
                                System.Console.WriteLine("\n");
                                System.Console.WriteLine("Aperte 2 para voltar ao exercicio ou qualquer outra tecla para voltar ao inicio");
                                switch (Convert.ToString(System.Console.ReadLine()))
                                {
                                    case "2":
                                        System.Console.Clear();
                                        EsvaziaLista();
                                        Resolucao_Exercicio2();
                                        break;

                                    default:
                                        EsvaziaLista();
                                        Program.IniciaExercicios();
                                        break;
                                }
                            }
                            else
                            {
                                retorno.Append("O array também contem valores pares : {");
                                foreach (int valor in util.ListaExercicio2)
                                    retorno.Append(String.Format("{0}  ,", valor));
                                retorno.Append(" }").Replace(" , }", "}");

                                System.Console.WriteLine(retorno.ToString());
                                System.Console.WriteLine("\n");
                                System.Console.WriteLine("Aperte 2 para voltar ao exercicio ou qualquer outra tecla para voltar ao inicio");
                                switch (Convert.ToString(System.Console.ReadLine()))
                                {
                                    case "2":
                                        System.Console.Clear();
                                        EsvaziaLista();
                                        Resolucao_Exercicio2();
                                        break;

                                    default:
                                        System.Console.Clear();
                                        EsvaziaLista();
                                        Program.IniciaExercicios();
                                        break;
                                }
                            }
                        }
                        else
                        {
                            retorno.Append("O array está vazio { } DIGITE 2 PARA VOLTAR AO EXERCICIO OU QUALQUER TECLA PARA VOLTAR AO INICIO");
                            System.Console.WriteLine(retorno.ToString());
                            switch (Convert.ToString(System.Console.ReadLine()))
                            {
                                case "2":
                                    System.Console.Clear();
                                    EsvaziaLista();
                                    Resolucao_Exercicio2();
                                    break;

                                default:
                                    System.Console.Clear();
                                    EsvaziaLista();
                                    Program.IniciaExercicios();
                                    break;
                            }
                        }


                    }

                }
                catch
                {
                    System.Console.Clear();
                    EsvaziaLista();
                    Resolucao_Exercicio2();
                }
            }

            public void PreencheArrrayExercicio2(int number)
            {
                util.ListaExercicio2.Add(number);
            }

            public void EsvaziaLista()
            {
                util.ListaExercicio2.Clear();
            }
        }
        #endregion

        #region "Exercicio3"
        class Exercicio3 : IExercicio3
        {
            Util util = new Util();
            public void Resolucao_Exercicio3()
            {
                try
                {
                    System.Console.WriteLine("EXERCICIO 3 - ENTRE COM O VALOR INTEIRO PARA O PRIMEIRO ARRAY (APERTE   S   PARA PREENCHER O SEGUNDO ARRAY) ");
                    var retorno = Convert.ToString(System.Console.ReadLine()).ToUpper();
                    switch (retorno)
                    {
                        case "S":
                            PreencheArray_32();
                            break;

                        default:
                            util.ListaExercicio3_1.Add(Convert.ToInt32(retorno));
                            Resolucao_Exercicio3();
                            break;
                    }
                }
                catch
                {

                    System.Console.WriteLine("ENTRADA DE DADOS ERRADA, APERTE QUALQUER TECLA PARA VOLTAR AO EXERCICIO 3");
                    System.Console.Clear();
                    EsvaziaLista();
                    Resolucao_Exercicio3();
                }
            }

            public void PreencheArray_32()
            {
                try
                {
                    System.Console.WriteLine("EXERCICIO 3 - ENTRE COM O VALOR INTEIRO PARA O SEGUNDO ARRAY (APERTE   P    PARA PREENCHER O PRIMEIRO ARRAY OU  C  PARA CRUZAR OS VALORES DOS DOIS ARRAYS)  ");
                    var retorno = Convert.ToString(System.Console.ReadLine()).ToUpper();
                    switch (Convert.ToString(retorno))
                    {
                        case "P":
                            Resolucao_Exercicio3();
                            break;

                        case "C":
                            CruzaArraysExercicio3();
                            break;
                        default:
                            util.ListaExercicio3_2.Add(Convert.ToInt32(retorno));
                            PreencheArray_32();
                            break;
                    }
                }
                catch
                {
                    System.Console.WriteLine("ENTRADA DE DADOS ERRADA, APERTE QUALQUER TECLA PARA VOLTAR AO EXERCICIO 3");
                    System.Console.Clear();
                    EsvaziaLista();
                    Resolucao_Exercicio3();
                }
            }

            public void EsvaziaLista()
            {
                util.ListaExercicio3_1.Clear();
                util.ListaExercicio3_2.Clear();
            }

            public void CruzaArraysExercicio3()
            {
                System.Console.Clear();
                IEnumerable<int> aOnlyNumbers = util.ListaExercicio3_1.Except(util.ListaExercicio3_2);
                StringBuilder resultado = new StringBuilder();
                resultado.Append("A DIFERENÇA DO PRIMEIRO ARRAY EM RELAÇÃO AO SEGUNDO FOI : [");
                foreach (var n in aOnlyNumbers)
                {
                    resultado.Append(String.Format(" {0} ,", Convert.ToString(n)));
                }
                resultado.Append("]").Replace(",]", "]");
                System.Console.WriteLine(resultado.ToString());
                System.Console.ReadKey();
                resultado.Append("APERTE 1 PARA VOLTAR A RESOLUÇÃO DO EXERCICIO 3 OU QUALQUER OUTRA TECLA PRA VOLTAR AO INCIO ");
                var retorno = Convert.ToString(System.Console.ReadLine()).ToUpper();
                switch (Convert.ToString(retorno))
                {
                    case "1":
                        Resolucao_Exercicio3();
                        break;
                    default:
                        Program.IniciaExercicios();
                        break;
                }
            }
        }
        #endregion
    }
}