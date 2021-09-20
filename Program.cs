using System;

namespace _123
{
    class Program
    {
        static void Main(string[] args)
        {
            aluno [] alunos = new aluno[5];
            var indicealuno = 0;
            string opcaousuario = ObterOpcao();

            while (opcaousuario.ToUpper() != "X")
            {
                switch(opcaousuario)
                {
                    case "1":
                    // todo: adicionar aluno
                        Console.WriteLine("Informe o nome do aluno");
                        var  aluno = new aluno();
                        aluno.nome = Console.ReadLine();
                        
                        Console.WriteLine("Digite a nota deste aluno");
                        
                        if ( decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor deve ser decimal");
                        }

                        alunos[indicealuno] = aluno;
                        indicealuno ++;

                        Console.WriteLine();

                        break;

                    case "2":
                    //todo: listar alunos
                        foreach( var a in alunos )
                        {
                            if (!string.IsNullOrEmpty(a.nome))
                            {
                                Console.WriteLine($"Aluno: {a.nome} - nota {a.nota}");
                            }
                        }
                        Console.WriteLine();
                        break;


                    case "3":
                    //todo: calcular media geral
                        decimal notatotal = 0;
                        var nraluno = 0 ;

                        for (int i=0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].nome))
                            {
                                notatotal = notatotal + alunos[i].nota;
                                nraluno++;
                            }
                            
                        }

                        var media = notatotal/nraluno;
                        conceito ceonceitogeral;

                        if (media < 2)
                        {
                            ceonceitogeral = conceito.E;
                        }
                        else if (media <4)
                        {
                            ceonceitogeral = conceito.D;
                        }
                        else if (media <6)
                        {
                            ceonceitogeral = conceito.C;
                        }
                        else if (media <8)
                        {
                            ceonceitogeral = conceito.B;
                        }
                        else
                        {
                            ceonceitogeral = conceito.A;
                        }

                        Console.WriteLine($"Media geral : {media} - Conceito Geral: {ceonceitogeral}.");
                        Console.WriteLine();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaousuario = ObterOpcao();
            }

        }

            private static string ObterOpcao()
            {
                Console.WriteLine("Informe a opção desejada:");
                Console.WriteLine("1 - inserir novo aluno:");
                Console.WriteLine("2 - listar alunos:");
                Console.WriteLine("3 - Calcular média geral:");
                Console.WriteLine("X - Sair");
                Console.WriteLine();
                
                string opcaousuario = Console.ReadLine();
                Console.WriteLine();
                return opcaousuario;
            }
    }
}
