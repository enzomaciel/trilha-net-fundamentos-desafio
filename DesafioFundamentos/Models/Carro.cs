using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFundamentos.Models
{
    public class Carro
    {
        public Carro(string placa, string nome, string marca){
            Placa = placa;
            Nome = nome;
            Marca = marca;
        }
        

        private string _placa;
        private string _nome;
        private string _marca;
        public string Placa 
        { 
            get=>_placa.ToUpper();  
            set
            {
                if(value == ""){
                    throw new ArgumentException("Nenhum valor inserido na placa");
                }
                if(verificarPlacas(value)){
                    _placa = value;
                }else{
                    throw new ArgumentException("Placa Invalidade");
                }
            }
        
        }
        public string Nome 
        { 
            get => _nome; 
            set
            {
                if(value == ""){
                    throw new ArgumentException("Nenhum valor inserido no nome");
                }
                _nome = value;
            }
        }
        public string Marca 
        { 
            get => _marca; 
            set
            {
                if(value == ""){
                    throw new ArgumentException("Nenhum valor inserido na marca");
                }
                _marca = value;
            }
        }




    // Função para verificar se a placa é verdadeira
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