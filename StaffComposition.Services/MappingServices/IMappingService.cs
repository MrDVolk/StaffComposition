using StaffComposition.DAL;
using StaffComposition.DAL.Models;
using StaffComposition.Data;
using StaffComposition.Data.Models;

namespace StaffComposition.Services.MappingServices
{
    public interface IMappingService<TEntity, TEntityDto>
        where TEntity : class, IEntity
        where TEntityDto : class, IEntityDto
    {
        TEntityDto Map(TEntity entity);

        TEntity Map(TEntityDto entity);

        void Update(TEntity dest, TEntityDto source);
    }
}