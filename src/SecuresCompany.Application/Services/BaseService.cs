namespace SecuresCompany.Application.Core;

public interface IBaseService<T>
{
    Task<ServiceResult> AddAsync(T dto);
    Task<ServiceResult> UpdateAsync(T dto);
    Task<ServiceResult> DeleteAsync(int id);
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
}