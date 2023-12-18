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
            //Implementado!!!!!!
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine();
            if(verificarPlacas(placa)){
                veiculos.Add(placa);
                Console.WriteLine($"Veiculo de placa {placa} adicionado com sucesso");
            }else{
                Console.WriteLine($"Placa invalidade, por favor corrija a placa");
            }
            
            
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            
            //Implementado!!!!!!
            string placa = Console.ReadLine();
            if(verificarPlacas(placa)){
                 //Implementado!!!!!!
                if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                    //Implementado!!!!!!               
                    int horas = 0;
                    horas = int.Parse(Console.ReadLine());
                    decimal valorTotal = 0;
                    valorTotal = precoInicial + precoPorHora * horas;
                    //Implementado!!!!!!
                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
            }else{
                Console.WriteLine($"Placa invalidade, por favor corrija a placa");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                //Implementado!!!!!!
                foreach (string veiculo in veiculos)
                {
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
        //Coloquei o desafio de verificas se estão no formato das placas padrões do Brasilm, Implementado!!!!!!
        public bool verificarPlacas(string placa)
        {
            placa = placa.ToLower();
            string letras ="qwertyuiopasdfghjklzxcvbnm" ;
            string numeros = "1234567890";
            if(placa.Length == 8){
                string placa_letras = placa.Remove(3,5);
                string placa_numeros = placa.Remove(0,4);
                int verificador1 = 0;
                foreach (char letra in placa_letras)
                {
                    if(letras.IndexOf(letra) != -1 ){
                        verificador1++;
                    }
                }
                foreach (char numero in placa_numeros)
                {
                    if(numeros.IndexOf(numero) != -1){
                        verificador1++;
                    }
                }
                if(verificador1 == 7){
                    return true;
                }else{
                    return false;
                }
            }else if(placa.Length == 7)
            {
                string placa_parte1 = placa.Remove(3,4);
                string placa_parte2 = placa.Substring(3,2);
                string placa_parte3 = placa.Remove(0,5);
                int verificador2 = 0;
                foreach (char element in placa_parte2)
                {
                    if(numeros.IndexOf(element) != -1){
                        verificador2++;
                    }
                }
                if(verificador2 >= 1){
                        foreach (char element in placa_parte1)
                        {
                            if(letras.IndexOf(element) != -1){
                                verificador2++;
                            }
                        }
                        foreach (char element in placa_parte3)
                        {
                            if(numeros.IndexOf(element) != -1){
                                verificador2++;
                            }
                        }
                        if(verificador2 == 7){
                            return true;
                        }
                }else{
                    return false;
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
