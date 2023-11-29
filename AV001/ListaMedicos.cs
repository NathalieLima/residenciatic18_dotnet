class ListaMedicos : ListaPessoas
{
    private static bool isUniqueCRM(string CRM, var list_medicos) {
        return list_medicos.Any(item => item.CRM == CRM);
    }

    public static override void adicionarPessoa(var medico, var list) {
        if ( isUniqueCPF(medico.CRM, list) ) 
        {
            if ( isUniqueCRM(medico.CRM, list) ) {
                list.Add(medico);
            } else {
                throw new Exception("Já existe um CRM igual a esse no sistema.");
            }

            list.Add(medico);

        } else {
            throw new Exception("Já existe um CPF igual a esse no sistema.");
        }
    }
}