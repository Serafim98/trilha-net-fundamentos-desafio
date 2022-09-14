using System.Text.RegularExpressions;
namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            string placa;
            do{
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            placa = Console.ReadLine();
            }
            while(ValidarPlaca(placa) == false);
            
            veiculos.Add(placa);
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                // *IMPLEMENTE AQUI*
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial + precoPorHora * horas; 

                // TODO: Remover a placa digitada da lista de veículos
                // *IMPLEMENTE AQUI*
                veiculos.Remove(placa);


                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                for(int i=0; i<veiculos.Count(); i++)
                    Console.WriteLine(veiculos[i]);
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }

        private static bool ValidarPlaca(string placa)
        {
            if (string.IsNullOrWhiteSpace(placa)) { 
                Console.WriteLine("Placa Inválida");
                Console.WriteLine("Digite qualquer tecla para inserir nova placa");
                Console.ReadLine();
                return false; 
            }

            if (placa.Length > 8) { 
                Console.WriteLine("Placa Inválida");
                Console.WriteLine("Digite qualquer tecla para inserir nova placa");
                Console.ReadLine();
                return false; 
            }

            placa = placa.Replace("-", "").Trim();

            if (char.IsLetter(placa, 4))
            {
                var padraoMercosul = new Regex("[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}");
                if(padraoMercosul.IsMatch(placa)==false){
                    Console.WriteLine("Placa Inválida");
                    Console.WriteLine("Digite qualquer tecla para inserir nova placa");
                    Console.ReadLine();
                }
                return padraoMercosul.IsMatch(placa);
            }
            else
            {
                var padraoNormal = new Regex("[a-zA-Z]{3}[0-9]{4}");
                if(padraoNormal.IsMatch(placa) == false){
                    Console.WriteLine("Placa Inválida");
                    Console.WriteLine("Digite qualquer tecla para inserir nova placa");
                    Console.ReadLine();
                }
                return padraoNormal.IsMatch(placa);
            }
        }
    }
}

