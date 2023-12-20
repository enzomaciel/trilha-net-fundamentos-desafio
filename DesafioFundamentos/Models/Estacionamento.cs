namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<Carro> veiculos = new List<Carro>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            //Implementado!!!!!!
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            Console.WriteLine("Digite o nome do veículo para estacionar:");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite a marca do veículo para estacionar:");
            string marca = Console.ReadLine();
            try
            {
                Carro carro = new Carro(placa,nome,marca);
                veiculos.Add(carro);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void RemoverVeiculo()
        {

            Console.WriteLine("Digite a placa do veículo para remover:");
            
            //Implementado!!!!!!
            string placa = Console.ReadLine().ToUpper();
            Console.WriteLine("Quantas horas o carro permaneceu?");
            Decimal horaspermanecidas = Decimal.Parse(Console.ReadLine());
            Decimal horasTotais = (horaspermanecidas * precoPorHora) + precoInicial; 
            foreach (Carro carro in veiculos)
            {
                if(carro.verificarPlacas(placa)){
                    if(carro.Placa == placa){
                        veiculos.Remove(carro);
                        Console.WriteLine($"Valor do estaciomento foi = R${horasTotais}");
                        Console.WriteLine($"Carro com a placa {placa} removido com sucesso");
                        break;
                    }
                }else{
                    Console.WriteLine("Placa fora do formato");
                    break;       
                }
            }
            
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                //Implementado!!!!!!
                foreach (Carro carro in veiculos)
                {
                    Console.WriteLine($"{carro.Placa} - {carro.Nome}");
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}