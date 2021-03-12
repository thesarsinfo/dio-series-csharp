using System;

namespace Dio.Series
{
    class Program
    {
        static SeriesRepositorio repositorio = new SeriesRepositorio();
        static void Main(string[] args)
        {
            string opcaousuario = ObterOpcaoUsuario();
            while ( opcaousuario.ToUpper() != "X" )
            {
                switch (opcaousuario)
                {
                    case "1":
                        ListarSerie();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Valor informado errado!");
                        break;

                }
                opcaousuario = ObterOpcaoUsuario();
            }
        }
         public static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bem vindo ao DIO Series");
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1- Listar Series");
            Console.WriteLine("2- Inserir nova Serie");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaousuario;

        }
        private static void ListarSerie()
        {
            Console.Write("Listar séries");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Lista cadastrada");
                return;
            }
            foreach (var serie in lista)
            {
                Console.WriteLine("#ID {0}: - {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }
        private static void InserirSerie()
        {
           Console.WriteLine("Inserir nova série");

           foreach (int i in Enum.GetValues(typeof(Genero)))
           {
               Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
           }
           Console.Write("digite o gênero entre as opções acima: ");
           int entradaGenero = int.Parse(Console.ReadLine());
           Console.Write("digite o nome da série: ");
           string entradaTitulo = Console.ReadLine();
           Console.Write("digite o ano de inicio da serie: ");
           int entradaAno = int.Parse(Console.ReadLine());
           Console.Write("digite a descrição da série: ");
           string entradaDescricao = Console.ReadLine();

           Series novaSerie = new Series(id: repositorio.ProximoId(),
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }
        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar a série ");
            int indiceSerie =int.Parse(Console.ReadLine());

           foreach (int i in Enum.GetValues(typeof(Genero)))
           {
               Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
           }
           Console.Write("digite o gênero entre as opções acima: ");
           int entradaGenero = int.Parse(Console.ReadLine());
           Console.Write("digite o nome da série: ");
           string entradaTitulo = Console.ReadLine();
           Console.Write("digite o ano de inicio da serie: ");
           int entradaAno = int.Parse(Console.ReadLine());
           Console.Write("digite a descrição da série: ");
           string entradaDescricao = Console.ReadLine();

           Series atualizaSerie = new Series(id: indiceSerie,
                                            genero: (Genero)entradaGenero,
                                            titulo: entradaTitulo,
                                            ano: entradaAno,
                                            descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }
        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da serie: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }
    
        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            var serie = repositorio.RetornaPorId(indiceSerie);
            Console.WriteLine(serie);
        }
    }
}
