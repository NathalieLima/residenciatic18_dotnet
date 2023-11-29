using Classes;

#region Exercício 1 - Criando classe Veiculo

Veiculo meu_veiculo = new Veiculo();
meu_veiculo.Modelo = "Honda";
meu_veiculo.Ano = 2022;
meu_veiculo.Cor = "Amarelo";

Console.WriteLine($"Modelo: {meu_veiculo.Modelo} | Ano: {meu_veiculo.Ano} | Cor: {meu_veiculo.Cor}");

#endregion

#region Exercício 3 - ContaBancaria

ContaBancaria minha_conta = new ContaBancaria();

try {
    minha_conta.Saldo = -100;
}
catch (Exception er) {
    Console.WriteLine($"Atenção: {er.Message}");
}

#endregion

#region Exercício 4 - Classe Aluno

Aluno novo_aluno = new Aluno();

Console.WriteLine($"Nome: {novo_aluno.Nome} | Idade: {novo_aluno.Idade}");

#endregion

#region Exercício 5 - Classe Agenda

// Agenda minha_agenda = new Agenda();
// // minha_agenda.Contatos.Add("Náthalie");
// // minha_agenda.Contatos.Add("Ciro");
// // minha_agenda.Contatos.Add("Lilívia");

// Console.WriteLine($"{minha_agenda.Contatos}");


#endregion