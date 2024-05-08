namespace _4Tables2._0.Domain.Base.Messages
{
    public static class DefaultMessage
    {
        public static string SearchCompletedSuccessfully() => "Requisição realizada com sucesso.";
        public static string SearchByPropertyNotFound(string property, object value) => $"Requisição por {property.ToString()} - {value} não teve registros encontrados.";
        public static string PropertyAtualizateSuccessfully(string entity, string property, object value) => $"{entity.ToString()} com {property.ToString()} - {value} atualizado com sucesso.";
        public static string InvalidItens() => "Itens inválidos.";
        public static string PropertiesCreateWithSuccessfully() => "Itens criados com sucesso.";
        public static string PropertieCreateWithSuccessfully() => "Item criado com sucesso.";
        public static string PropertieNotFoundInSytem(string property) => $"{property.ToString()} não encontrada no sistema.";
        public static string InternalError(string message) => $"Erro interno no servidor : {message}.";
        public static string TableNumberAndOrderNotEquals() => $"O número da Ordem não condiz com o número da mesa.";
    }
}
