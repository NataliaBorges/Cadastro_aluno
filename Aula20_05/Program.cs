using System;
using System.IO;


namespace Aula20_05 {
    class Program {

        //Método para armazenamento de dados em arquivo.
        public static void ArmazenarDados(Aluno[] alunos, int qtd) {
            string path = @"../../../Dados.txt";

            try {
                using (StreamWriter sw = new StreamWriter(path)) {
                    for (int i = 0; i < qtd; i++) {
                        sw.WriteLine(alunos[i].Nome + ";" + alunos[i].Data_de_nascimento.ToShortDateString() + ";" + alunos[i].Status + ";" +
                        alunos[i].Matricula + ";" + alunos[i].Email + ";" + alunos[i].CPF + ";" + alunos[i].RG + ";" +
                        alunos[i].Curso + ";");
                    }
                }
            }catch(Exception e) {
                Console.WriteLine("Problema com a leitura do arquivo: {0}", e.ToString());
            }
        }


        //Método para carregamento de dados de arquivo.
        public static Aluno[] CarregarDados(Aluno[] alunos, ref int qtd) {
            string path = @"../../../Dados.txt";
            try {
                using (StreamReader sr = new StreamReader(path)) {
                    while(sr.Peek() >= 0) {
                        string entrada = sr.ReadLine();

                        //Tratamento dos dados de entrada

                        string[] div = entrada.Split(';');

                        Aluno Autxt = new Aluno(div[0], //Nome
                            Convert.ToDateTime( div[1]), //Data de Nascimento
                                                div[2], //Status
                                                div[3], //Matricula
                                                div[4], //Email
                                                div[5], //CPF
                                                div[6], //RG
                                                div[7]);//Curso
                        alunos[qtd++] = Autxt;
                    }
                }
            }
            catch(Exception e) {
                Console.WriteLine("Problema com a leitura do arquivo: {0}", e.ToString());
            }
            return alunos;
        }


        //Método para cadastro de um novo aluno.
        public static Aluno[] Cadastrar(int qtd, Aluno[] alunos) {

            string nome;
            DateTime data_de_nascimento;
            string status;
            string matricula;
            string email;
            string cpf;
            string rg;
            string curso;

            int op = 1;

            while (op != 0) {

                Console.WriteLine("Entre com o nome do aluno:");
                nome = Console.ReadLine();

                Console.WriteLine("Entre a data de nascimento do aluno (dd/mm/aaaa): ");
                data_de_nascimento = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Entre com o status do aluno:");
                status = Console.ReadLine();
                while (Aluno.ValidaStatus(status) == false) {
                    Console.WriteLine("Digite novamente Status ");
                    status = Console.ReadLine();
                }

                Console.WriteLine("Entre com a Matricula do aluno:");
                matricula = Console.ReadLine().ToUpper();

                Console.WriteLine("Entre com o Email do aluno:");
                email = Console.ReadLine();
                while (Aluno.ValidaEmail(email) == false) {
                    Console.WriteLine("Digite novamente o e-mail: ");
                    email = Console.ReadLine();
                }

                Console.WriteLine("Entre com CPF do aluno:");
                cpf = Console.ReadLine();
                while (Aluno.ValidarCPF(cpf) == false) {
                    Console.WriteLine("Digite novamente o CPF: ");
                    cpf = Console.ReadLine();
                }

                Console.WriteLine("Entre com o RG do aluno:");
                rg = Console.ReadLine();

                Console.WriteLine("Entre com o Curso do aluno:");
                curso = Console.ReadLine();

                alunos[qtd] = new Aluno(nome, data_de_nascimento, status, email, matricula, cpf, rg, curso);

                Console.WriteLine("1 - Cadastrar mais um aluno");
                Console.WriteLine("0 - Não cadastrar mais");

                op = int.Parse(Console.ReadLine());

                qtd++;
                Console.Clear();
            }
            return alunos;
        }


        //Método para visualização de dados de um aluno.
        public static void BuscarAluno(int qtd, Aluno[] alunos) {
            int pos;
            Console.WriteLine("Escolha um aluno pela posição: ");

            for(int i = 0; i < qtd; i++) {
                Console.WriteLine($"Posição: [{i}] - {alunos[i].Nome}");
            }

            pos = int.Parse(Console.ReadLine());

            Console.WriteLine(alunos[pos].ToString()); 
            
        }


        //Método para atualização de dados de um aluno.
        public static Aluno[] Atualizar(int qtd, Aluno[] alunos)
            {
            Console.WriteLine(" ATUALIZAR DADOS DE UM ALUNO ");
            Console.WriteLine(); 

            int pos;
            Console.WriteLine("Escolha um aluno pela posição: ");

            for (int i = 0; i < qtd; i++) {
                Console.WriteLine($"Posição: [{i}] - {alunos[i].Nome}");
            }pos = int.Parse(Console.ReadLine());


            int op;
            do {
                Console.WriteLine("Qual dado você deseja alterar?");
                Console.WriteLine("[1] - Nome");
                Console.WriteLine("[2] - Data de Nascimento");
                Console.WriteLine("[3] - Status");
                Console.WriteLine("[4] - Matricula");
                Console.WriteLine("[5] - Email");
                Console.WriteLine("[6] - CPF");
                Console.WriteLine("[7] - RG");
                Console.WriteLine("[8] - Curso");
                Console.WriteLine("[0] - Sair"); 

                op = int.Parse(Console.ReadLine());

                switch (op){
                    case 0:
                        Console.WriteLine("Obridaga por utilizar o sistema!");
                        break;
                    case 1:
                        Console.WriteLine("Digite o novo nome: ");
                        string nome = Console.ReadLine();
                        alunos[pos].Nome = nome;
                        break;
                    case 2:
                        Console.WriteLine("Digite a nova data de nascimento: ");
                        DateTime data_de_nascimento = Convert.ToDateTime(Console.ReadLine());
                        alunos[pos].Data_de_nascimento = data_de_nascimento;
                        break;
                    case 3:
                        Console.WriteLine("Digite o novo status: ");
                        string status = Console.ReadLine();

                        while (Aluno.ValidaStatus(status) == false) {
                            Console.WriteLine("Digite novamente Status ");
                            status = Console.ReadLine();
                        }
                        alunos[pos].Status = status;
                        break;
                    case 4:
                        Console.WriteLine("Digite a nova matricula: ");
                        string matricula = Console.ReadLine();
                        alunos[pos].Matricula = matricula;
                        break;
                    case 5:
                        Console.WriteLine("Digite o novo Email: ");
                        string email = Console.ReadLine();

                        while (Aluno.ValidaEmail(email) == false) {
                            Console.WriteLine("Digite novamente o email: ");
                            email = Console.ReadLine();
                        }
                        alunos[pos].Email = email;
                        break;
                    case 6:
                        Console.WriteLine("Digite o novo CPF: ");
                        string cpf = Console.ReadLine();
                        while (Aluno.ValidarCPF(cpf) == false) {
                            Console.WriteLine("Digite novamente o CPF: ");
                            cpf = Console.ReadLine();
                        }
                        alunos[pos].CPF = cpf;
                        break;
                    case 7:
                        Console.WriteLine("Digite o novo RG: ");
                        string rg = Console.ReadLine();
                        alunos[pos].RG = rg;
                        break;
                    case 8:
                        Console.WriteLine("Digite o novo Curso: ");
                        string curso = Console.ReadLine();
                        alunos[pos].Curso = curso;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida.");
                        break;
                }
                Console.Clear();
            } while (op != 0);
            return alunos;
    }


        //Método para atualização somente do status de um aluno.
        public static Aluno[] AlterarStatus(int qtd, Aluno[] alunos) {
            int pos;
            Console.WriteLine("Escolha um aluno pela posição: ");

            for (int i = 0; i < qtd; i++) {
                Console.WriteLine($"Posição: [{i}] - {alunos[i].Nome}");
            }

            pos = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o novo Status: ");

            string nStatus = Console.ReadLine();

            while (Aluno.ValidaStatus(nStatus) == false) {
                Console.WriteLine("Digite novamente Status ");
                nStatus = Console.ReadLine();
            }

            alunos[pos].Status = nStatus;
            return alunos;

        }


        //Método para pesquisa de um aluno por cpf ou matrícula.

        public static Aluno[] buscarCPFouMatricula(int qtd, Aluno[] alunos) {
            int op;

            Console.WriteLine("Você deseja Buscar por: ");
            Console.WriteLine("[1] - CPF");
            Console.WriteLine("[2] - Matricula");

            op = int.Parse(Console.ReadLine());


            if(op == 1) {

                Console.WriteLine("Digite o CPF da pessoa que deseja buscar: ");
                string cpf = Console.ReadLine();
                bool existe = false;

                for (int i = 0; i < qtd; i++){
                    if(cpf == alunos[i].CPF) {
                        Console.WriteLine(alunos[i].ToString());
                        existe = true;
                    }
                }
                while(existe == false) {
                    Console.WriteLine("CPF não encontrado");

                    Console.WriteLine("Digite o CPF novamente: ");
                    cpf = Console.ReadLine();

                    for (int i = 0; i < qtd; i++) {
                        if (cpf == alunos[i].CPF) {
                            Console.WriteLine(alunos[i].ToString());
                            existe = true;
                        }
                    }

                }
                
            }
            if(op == 2) {
                Console.WriteLine("Digite a matricula da pessoa que deseja buscar: ");
                string mat = Console.ReadLine().ToUpper();
                bool existe = false;

                for (int i = 0; i < qtd; i++) {
                    if (mat == alunos[i].Matricula) {
                        Console.WriteLine(alunos[i].ToString());
                        existe = true;
                    }
                }
                while (existe == false) {
                    Console.WriteLine("Matricula não encontrada");

                    Console.WriteLine("Digite a matricula novamente: ");
                    mat = Console.ReadLine();

                    for (int i = 0; i < qtd; i++) {
                        if (mat == alunos[i].Matricula) {
                            Console.WriteLine(alunos[i].ToString());
                            existe = true;
                        }
                    }
                }
            }

            return alunos;
        }
        static void Main(string[] args) {
            

            int qtd = 0;
            Aluno[] alunos = new Aluno[1000];

            //Carregar dados do arquivo.
            alunos = CarregarDados(alunos, ref qtd);
            for (int i = 0; i < 1000; i++) {
                if (alunos[i] != null) {
                    qtd = i + 1;
                }
            }

            int op;
            do {
                
                Console.WriteLine("---------------Programa Aluno--------------");
                Console.WriteLine("--------------------MENU-------------------");
                Console.WriteLine();
                Console.WriteLine("OPÇÃO [0] - Sair");
                Console.WriteLine("OPÇÃO [1] - Cadastrar Aluno ");
                Console.WriteLine("OPÇÃO [2] - Alunos Cadastrados");
                Console.WriteLine("OPÇÃO [3] - Buscar por posição");
                Console.WriteLine("OPÇÃO [4] - Buscar por CPF ou Matricula");
                Console.WriteLine("OPÇÃO [5] - Atualizar Dados do aluno");
                Console.WriteLine("OPÇÃO [6] - Atualizar Status do aluno");
                

                op = int.Parse(Console.ReadLine());

                switch (op) {
                    case 0:
                        Console.WriteLine("Obridaga por utilizar o sistema!");
                        break;

                    case 1:
                        alunos = Cadastrar(qtd, alunos);

                        for (int i = 0; i < 1000; i++) {
                            if (alunos[i] != null) {
                                qtd = i + 1;
                            }
                        }
                        break;

                    case 2:
                        for (int i = 0; i < qtd; i++) {
                            if (alunos[i] != null) {
                                Console.WriteLine(alunos[i].ToString());
                            }
                        }
                        break;

                    case 3:
                        BuscarAluno(qtd, alunos);
                        break;

                    case 4:
                        alunos = buscarCPFouMatricula(qtd, alunos);
                        break;

                    case 5:
                        alunos = Atualizar(qtd, alunos);
                        break;

                    case 6:
                        alunos = AlterarStatus(qtd, alunos);
                        break;

                    default:
                        Console.WriteLine("Opção Invalida.");
                        break;
                }
            } while (op != 0);

            //Armazenas Dados
            ArmazenarDados(alunos, qtd);
        }

    }
}
//Criar um mini sistema que seja capaz de gerenciar algumas informações da vida acadêmica de alunos.
//Seu sistema deve contemplar os seguintes requisitos:
//1 - Ser capaz de armazenar até 1000 alunos. Para cada aluno, armazenar os seguintes dados:
//  (Nome completo, data de nascimento, status, matrícula, e-mail, cpf, rg e curso.
//2 - Ser capaz de permitir o cadastro de novos alunos;
//3 - Ser capaz de exibir os dados de um aluno pela pesquisa do seu cpf ou matrícula.
//4 - Ser capaz de permitir a atualização do cadastro de um aluno.
//5 - Ser capaz de permitir a atualização do status do aluno (matriculado, evadido, trancado e concluído).
//Extra - Possuir um mecanismo de armazenamento de dados permanente para facilitar a testagem. Use arquivos.

