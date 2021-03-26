using System;
using System.Collections.Generic;
using System.Text;

namespace series_aplication_dio
{
    public static class SerieService
    {
        private static SerieRepositorio repositorio = new SerieRepositorio();

        public static void GetAll()
        {
            Console.WriteLine("Listar séries");

            var list = repositorio.GetAll();
            
            if (list.Count == 0)
            {
                Console.WriteLine("Nenhuma série encontrada !");
                return;
            }

            foreach(var serie in list)
            {
                var excluido = serie.RetornaExcluido();
                Console.WriteLine($"#ID {serie.RetornaId()}: - {serie.RetornaTitulo()} {(excluido ? "*Excluído*":"")} ");
            }
        }

        public static void Insert()
        {
            Console.WriteLine("Inserir nova série");

            foreach(int genero in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{genero} - {Enum.GetName(typeof(Genero), genero)}");
            }

            Console.WriteLine("Digite o gênero da série: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(repositorio.NextId(),(Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);

            repositorio.Insert(novaSerie);

        }

        public static void Update()
        {
            Console.WriteLine("Digite o ID da série. ");
            int serieId = int.Parse(Console.ReadLine());

            serieId = VerificaId(serieId);

            if (serieId == -1)
            {
                return;
            }

            foreach (int genero in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{genero} - {Enum.GetName(typeof(Genero), genero)}");
            }

            Console.WriteLine("Digite o gênero da série: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o Ano de Início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a Descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie serieAlterada = new Serie(serieId, (Genero)entradaGenero, entradaTitulo, entradaDescricao, entradaAno);

            repositorio.Update(serieId, serieAlterada);

            Console.WriteLine("Série alterada com sucesso !");
        }

        public static void Delete()
        {
            Console.WriteLine("Digite o ID da série. ");
            int serieId = int.Parse(Console.ReadLine());

            serieId = VerificaId(serieId);

            if (serieId == -1)
            {
                return;
            }

            repositorio.Delete(serieId);

            Console.WriteLine("Série excluída com sucesso !");
        }

        public static void GetById()
        {
            Console.WriteLine("Digite o ID da série. ");
            int serieId = int.Parse(Console.ReadLine());

            serieId = VerificaId(serieId);

            if(serieId == -1)
            {
                return;
            }

            var serie = repositorio.GetById(serieId);

            Console.WriteLine(serie.ToString());
        }

        private static int VerificaId(int id)
        {

            if (id >= repositorio.NextId() || id < 0)
            {
                Console.WriteLine("Série não cadastrada");
                return -1;
            }
            else
            {
                return id;
            }

        }
    }
}
