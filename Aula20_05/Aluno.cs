using System;


namespace Aula20_05 {
    class Aluno {
        public string Nome;
        public DateTime Data_de_nascimento;
        public string Status;
        public string Matricula;
        public string Email;
        public string CPF;
        public string RG;
        public string Curso;


        public Aluno(string nome, DateTime data_de_nascimento, string status, string email, string matricula, string cpf, string rg, string curso) {
            Nome = nome;
            Data_de_nascimento = data_de_nascimento;
            Status = status;
            Email = email;
            Matricula = matricula;
            CPF = cpf;
            RG = rg;
            Curso = curso;
        }

        public override string ToString() {
            return ($"Nome: {Nome} " +
                    $"\nData de nascimento: {Data_de_nascimento} " +
                    $"\nStatos: {Status} " +
                    $"\nEmail: {Email}" +
                    $"\nMatricula: {Matricula}" +
                    $"\nCPF: {CPF} " +
                    $"\nRG: {RG}" +
                    $"\nCurso: {Curso}\n");
        }


        public static bool ValidaEmail(string email) {
            if (email.Contains('@') && email.Contains(".com"))
                return true;
            else
                return false;
        }

        public static bool ValidarCPF(string cpf) {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool ValidaStatus(string status) {
            if (status.ToUpper().Contains("MATRICULADO") || status.ToUpper().Contains("EVADIDO") || status.ToUpper().Contains("TRANCADO") ||
                status.ToUpper().Contains("CONCLUIDO") || status.ToUpper().Contains("CONCLUÍDO")) {
                return true;
            }
            return false;
        }
    }
}
//Atributos ou características de um aluno.

//Método construtor para recebimento dos dados de um aluno.

//Outros métodos que julgar necessário para validação de algum dado. 

//Método para retorno dos dados formatados ToString. 
