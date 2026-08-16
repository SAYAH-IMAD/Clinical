namespace Clinical.Common.Application.Contract;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}