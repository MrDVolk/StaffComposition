using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StaffComposition.DAL.Models;

namespace StaffComposition.DAL
{
    public interface IService<TEntityDto> 
        where TEntityDto : IEntityDto
    {
        Task<ICollection<TEntityDto>> GetAll();

        Task<TEntityDto> Get(Guid id);

        Task<Guid> Create(TEntityDto entityDto);

        Task Update(TEntityDto entityDto);

        Task Delete(Guid id);
    }
}
