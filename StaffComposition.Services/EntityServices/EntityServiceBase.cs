﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StaffComposition.DAL;
using StaffComposition.DAL.Models;
using StaffComposition.Data.Models;
using StaffComposition.Services.MappingServices;

namespace StaffComposition.Services.EntityServices
{
    public class EntityServiceBase<TEntity, TEntityDto> : IService<TEntityDto> 
        where TEntity : class, IEntity 
        where TEntityDto : class, IEntityDto
    {
        private readonly Func<StaffDbContext> _contextFactory;
        private readonly IMappingService<TEntity, TEntityDto> _mappingService;

        public EntityServiceBase(
            Func<StaffDbContext> contextFactory,
            IMappingService<TEntity, TEntityDto> mappingService)
        {
            _contextFactory = contextFactory;
            _mappingService = mappingService;
        }

        public async Task<ICollection<TEntityDto>> GetAll()
        {
            using (var db = _contextFactory())
            {
                var query =
                    from e in db.Set<TEntity>()
                    where !e.RecordDeleted.HasValue
                    select e;

                var entities = await query.ToListAsync();
                var dtos = entities.Select(x => _mappingService.Map(x)).ToList();

                return dtos;
            }
        }

        public async Task<TEntityDto> Get(Guid id)
        {
            using (var db = _contextFactory())
            {
                var query =
                    from e in db.Set<TEntity>()
                    where !e.RecordDeleted.HasValue
                    where e.Id == id
                    select e;

                var entity = await query.SingleOrDefaultAsync();
                if (entity == null)
                    throw new ArgumentException($"Сущность с Id={id} не найдена!");

                var dto = _mappingService.Map(entity);
                return dto;
            }
        }

        public async Task<Guid> Create(TEntityDto entityDto)
        {
            using (var db = _contextFactory())
            {
                var entity = _mappingService.Map(entityDto);
                entity.RecordCreated = DateTime.Now;

                db.Add(entity);
                await db.SaveChangesAsync();

                return entity.Id;
            }
        }

        public async Task Update(TEntityDto entityDto)
        {
            using (var db = _contextFactory())
            {
                if(!entityDto.Id.HasValue)
                    throw new ArgumentException($"Не указан Id сущности. Невозможно провести обновление.");

                var query =
                    from e in db.Set<TEntity>()
                    where e.Id == entityDto.Id
                    select e;

                var entity = await query.SingleOrDefaultAsync();
                if (entity == null)
                    throw new ArgumentException($"Сущность с Id={entityDto.Id} не найдена!");

                _mappingService.Update(entity, entityDto);
                entity.RecordModified = DateTime.Now;
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            using (var db = _contextFactory())
            {
                var query =
                    from e in db.Set<TEntity>()
                    where !e.RecordDeleted.HasValue
                    where e.Id == id
                    select e;

                var entity = await query.SingleOrDefaultAsync();
                if (entity == null)
                    throw new ArgumentException($"Сущность с Id={id} не найдена!");

                entity.RecordDeleted = DateTime.Now;
                await db.SaveChangesAsync();
            }
        }
    }
}