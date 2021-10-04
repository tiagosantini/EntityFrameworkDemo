namespace EntityFrameworkDemo.Dominio.Entities.Shared
{
    public interface IOperacaoCadastravel
    {
        void InserirNovoRegistro();
        void EditarRegistro();
        void ExcluirRegistro();
        void SelecionarRegistroPorId();
        void SelecionarTodosRegistros();
    }
}
