namespace Classes;
using System;
using System.Globalization;

class Pessoa
{
    protected string nome;
    protected DateTime data_nascimento;
    protected string cpf;

    public string Nome 
    { 
        get { return this.nome; }
        set
        {
            string formated_value = Utilities.capitalize(value.Trim());     
            Console.WriteLine($"{value} | {formated_value}");           

            this.nome = formated_value;
            
        } 
    }
    
    public DateTime DataNascimento  
    {
        get { return this.data_nascimento; }
        set 
        {
            CultureInfo ptBR = new CultureInfo("pt-BR");
            string date_string = value.ToString("DD/MM/YYYY");

            if (!DateTime.TryParseExact(date_string, "DD/MM/YYYY", ptBR, DateTimeStyles.None, out DateTime data))
            {
                throw new Exception("Data inválida!");
            }

            this.data_nascimento = data;
        }
    }

    public string CPF 
    { 
        get { return this.cpf; }
        set 
        {
            var tupla_erro = Utilities.isValidCPF(value);

            if ( !tupla_erro.Error ) {
                this.cpf = value;
            } else {
                throw new Exception(tupla_erro.Message);
            }
        }
    }

    public int calcularIdade() {
        int year_diff = DateTime.Now.Year - data_nascimento.Year;
        int month_diff = DateTime.Now.Month - data_nascimento.Month; // 10 - 08 = 20
        int date_diff = DateTime.Now.Day - data_nascimento.Day; // 05 - 04 = 20

        Console.WriteLine($"idade {data_nascimento.Year}");
        

        if ( month_diff <= 0 ) {
            if ( date_diff >= 0 ) {
                return year_diff + 1;
            }
        } else {
            return year_diff + 1;
        }

        return year_diff;
    }

    private void ValidateName(string value) {
        // Verificar se o nome recebido não é vazio ou nulo
        if ( Utilities.isEmptyValue(value) ) {
            throw new Exception($"Insira algum valor {value} que não seja vazio ou nulo.");
        } 
    }
}