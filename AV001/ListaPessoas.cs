class ListaPessoas
{

    private static bool isUniqueCPF(string CPF, var list) {
        return list.Any(item => item.CPF == CPF);
    }

    public static virtual void adicionarPessoa(var pessoa, var list) {
        if ( isUniqueCPF(pessoa.CPF, list) ) {
            list.Add(pessoa);
        } else {
            throw new Exception("Já existe um CPF igual a esse no sistema.");
        }
    }
}