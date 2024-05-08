namespace _4Tables2._0.Infra.Base.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
        void SaveChanges();
    }
}
