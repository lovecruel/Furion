﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Fur.DatabaseAccessor
{
    /// <summary>
    /// 可插入的仓储分部类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public partial class EFCoreRepository<TEntity> : IRepository<TEntity>, IUpdateableRepository<TEntity>
         where TEntity : class, IDbEntityBase, new()
    {
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> Update(TEntity entity)
        {
            return Entities.Update(entity);
        }

        /// <summary>
        /// 更新多个实体
        /// </summary>
        /// <param name="entities"></param>
        public virtual void UpdateRange(params TEntity[] entities)
        {
            Entities.UpdateRange(entities);
        }

        /// <summary>
        /// 更新多个实体
        /// </summary>
        /// <param name="entities"></param>
        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            Entities.UpdateRange(entities);
        }

        /// <summary>
        /// 更新实体（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual Task<EntityEntry<TEntity>> UpdateAsync(TEntity entity)
        {
            return Task.FromResult(Entities.Update(entity));
        }

        /// <summary>
        /// 更新多个实体（异步）
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual Task UpdateRangeAsync(params TEntity[] entities)
        {
            Entities.UpdateRange(entities);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 更新多个实体（异步）
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            Entities.UpdateRange(entities);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 更新实体并立即保存
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateSaveChanges(TEntity entity)
        {
            var entityEntry = Update(entity);
            SaveChanges();
            return entityEntry;
        }

        /// <summary>
        /// 更新实体并立即保存
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateSaveChanges(TEntity entity, bool acceptAllChangesOnSuccess)
        {
            var entityEntry = Update(entity);
            SaveChanges(acceptAllChangesOnSuccess);
            return entityEntry;
        }

        /// <summary>
        /// 更新多个实体并立即保存
        /// </summary>
        /// <param name="entities"></param>
        public virtual void UpdateRangeSaveChanges(params TEntity[] entities)
        {
            UpdateRange(entities);
            SaveChanges();
        }

        /// <summary>
        /// 更新多个实体并立即保存
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="entities"></param>
        public virtual void UpdateRangeSaveChanges(bool acceptAllChangesOnSuccess, params TEntity[] entities)
        {
            UpdateRange(entities);
            SaveChanges(acceptAllChangesOnSuccess);
        }

        /// <summary>
        /// 更新多个实体并立即保存
        /// </summary>
        /// <param name="entities"></param>
        public virtual void UpdateRangeSaveChanges(IEnumerable<TEntity> entities)
        {
            UpdateRange(entities);
            SaveChanges();
        }

        /// <summary>
        /// 更新多个实体并立即保存
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        public virtual void UpdateRangeSaveChanges(IEnumerable<TEntity> entities, bool acceptAllChangesOnSuccess)
        {
            UpdateRange(entities);
            SaveChanges(acceptAllChangesOnSuccess);
        }

        /// <summary>
        /// 更新实体并立即保存（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateSaveChangesAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            var entityEntry = await UpdateAsync(entity);
            await SaveChangesAsync(cancellationToken);
            return entityEntry;
        }

        /// <summary>
        /// 更新实体并立即保存（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateSaveChangesAsync(TEntity entity, bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entityEntry = await UpdateAsync(entity);
            await SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            return entityEntry;
        }

        /// <summary>
        /// 更新多个实体并立即保存（异步）
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual async Task UpdateRangeSaveChangesAsync(params TEntity[] entities)
        {
            await UpdateRangeAsync(entities);
            await SaveChangesAsync();
        }

        /// <summary>
        /// 更新多个实体并立即保存（异步）
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="entities"></param>
        /// <returns></returns>
        public virtual async Task UpdateRangeSaveChangesAsync(bool acceptAllChangesOnSuccess, params TEntity[] entities)
        {
            await UpdateRangeAsync(entities);
            await SaveChangesAsync(acceptAllChangesOnSuccess);
        }

        /// <summary>
        /// 更新多个实体并立即保存（异步）
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task UpdateRangeSaveChangesAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await UpdateRangeAsync(entities);
            await SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 更新多个实体并立即保存（异步）
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task UpdateRangeSaveChangesAsync(IEnumerable<TEntity> entities, bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            await UpdateRangeAsync(entities);
            await SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        /// <summary>
        /// 更新特定属性
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateInclude(TEntity entity, params string[] propertyNames)
        {
            var entityEntry = Attach(entity);
            foreach (var propertyName in propertyNames)
            {
                EntityPropertyEntry(entity, propertyName).IsModified = true;
            }
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateInclude(TEntity entity, params Expression<Func<TEntity, object>>[] propertyExpressions)
        {
            var entityEntry = Attach(entity);
            foreach (var propertyExpression in propertyExpressions)
            {
                EntityPropertyEntry(entity, propertyExpression).IsModified = true;
            }
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateInclude(TEntity entity, IEnumerable<string> propertyNames)
        {
            return UpdateInclude(entity, propertyNames.ToArray());
        }

        /// <summary>
        /// 更新特定属性
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateInclude(TEntity entity, IEnumerable<Expression<Func<TEntity, object>>> propertyExpressions)
        {
            return UpdateInclude(entity, propertyExpressions.ToArray());
        }

        /// <summary>
        /// 更新特定属性
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual Task<EntityEntry<TEntity>> UpdateIncludeAsync(TEntity entity, params string[] propertyNames)
        {
            return Task.FromResult(UpdateInclude(entity, propertyNames));
        }

        /// <summary>
        /// 更新特定属性
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual Task<EntityEntry<TEntity>> UpdateIncludeAsync(TEntity entity, params Expression<Func<TEntity, object>>[] propertyExpressions)
        {
            return Task.FromResult(UpdateInclude(entity, propertyExpressions));
        }

        /// <summary>
        /// 更新特定属性
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual Task<EntityEntry<TEntity>> UpdateIncludeAsync(TEntity entity, IEnumerable<string> propertyNames)
        {
            return Task.FromResult(UpdateInclude(entity, propertyNames));
        }

        /// <summary>
        /// 更新特定属性
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual Task<EntityEntry<TEntity>> UpdateIncludeAsync(TEntity entity, IEnumerable<Expression<Func<TEntity, object>>> propertyExpressions)
        {
            return Task.FromResult(UpdateInclude(entity, propertyExpressions));
        }

        /// <summary>
        /// 更新特定属性并立即提交
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateIncludeSaveChanges(TEntity entity, params string[] propertyNames)
        {
            var entityEntry = UpdateInclude(entity, propertyNames);
            SaveChanges();
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性并立即提交
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateIncludeSaveChanges(TEntity entity, bool acceptAllChangesOnSuccess, params string[] propertyNames)
        {
            var entityEntry = UpdateInclude(entity, propertyNames);
            SaveChanges(acceptAllChangesOnSuccess);
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性并立即提交
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateIncludeSaveChanges(TEntity entity, params Expression<Func<TEntity, object>>[] propertyExpressions)
        {
            var entityEntry = UpdateInclude(entity, propertyExpressions);
            SaveChanges();
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性并立即提交
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateIncludeSaveChanges(TEntity entity, bool acceptAllChangesOnSuccess, params Expression<Func<TEntity, object>>[] propertyExpressions)
        {
            var entityEntry = UpdateInclude(entity, propertyExpressions);
            SaveChanges(acceptAllChangesOnSuccess);
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性并立即提交
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateIncludeSaveChanges(TEntity entity, IEnumerable<string> propertyNames)
        {
            var entityEntry = UpdateInclude(entity, propertyNames);
            SaveChanges();
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性并立即提交
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateIncludeSaveChanges(TEntity entity, bool acceptAllChangesOnSuccess, IEnumerable<string> propertyNames)
        {
            var entityEntry = UpdateInclude(entity, propertyNames);
            SaveChanges(acceptAllChangesOnSuccess);
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性并立即提交
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateIncludeSaveChanges(TEntity entity, IEnumerable<Expression<Func<TEntity, object>>> propertyExpressions)
        {
            var entityEntry = UpdateInclude(entity, propertyExpressions);
            SaveChanges();
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性并立即提交
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateIncludeSaveChanges(TEntity entity, bool acceptAllChangesOnSuccess, IEnumerable<Expression<Func<TEntity, object>>> propertyExpressions)
        {
            var entityEntry = UpdateInclude(entity, propertyExpressions);
            SaveChanges(acceptAllChangesOnSuccess);
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性并立即提交（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateIncludeSaveChangesAsync(TEntity entity, params string[] propertyNames)
        {
            var entityEntry = await UpdateIncludeAsync(entity, propertyNames);
            await SaveChangesAsync();
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性并立即提交（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateIncludeSaveChangesAsync(TEntity entity, bool acceptAllChangesOnSuccess, params string[] propertyNames)
        {
            var entityEntry = await UpdateIncludeAsync(entity, propertyNames);
            await SaveChangesAsync(acceptAllChangesOnSuccess);
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性并立即提交（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateIncludeSaveChangesAsync(TEntity entity, params Expression<Func<TEntity, object>>[] propertyExpressions)
        {
            var entityEntry = await UpdateIncludeAsync(entity, propertyExpressions);
            await SaveChangesAsync();
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性并立即提交（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateIncludeSaveChangesAsync(TEntity entity, bool acceptAllChangesOnSuccess, params Expression<Func<TEntity, object>>[] propertyExpressions)
        {
            var entityEntry = await UpdateIncludeAsync(entity, propertyExpressions);
            await SaveChangesAsync(acceptAllChangesOnSuccess);
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性并立即提交（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateIncludeSaveChangesAsync(TEntity entity, IEnumerable<string> propertyNames, CancellationToken cancellationToken = default)
        {
            var entityEntry = await UpdateIncludeAsync(entity, propertyNames);
            await SaveChangesAsync(cancellationToken);
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性并立即提交（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateIncludeSaveChangesAsync(TEntity entity, IEnumerable<string> propertyNames, bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entityEntry = await UpdateIncludeAsync(entity, propertyNames);
            await SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性并立即提交（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateIncludeSaveChangesAsync(TEntity entity, IEnumerable<Expression<Func<TEntity, object>>> propertyExpressions, CancellationToken cancellationToken = default)
        {
            var entityEntry = await UpdateIncludeAsync(entity, propertyExpressions);
            await SaveChangesAsync(cancellationToken);
            return entityEntry;
        }

        /// <summary>
        /// 更新特定属性并立即提交（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateIncludeSaveChangesAsync(TEntity entity, IEnumerable<Expression<Func<TEntity, object>>> propertyExpressions, bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entityEntry = await UpdateIncludeAsync(entity, propertyExpressions);
            await SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateExclude(TEntity entity, params string[] propertyNames)
        {
            var entityEntry = Attach(entity);
            entityEntry.State = EntityState.Modified;
            foreach (var propertyName in propertyNames)
            {
                EntityPropertyEntry(entity, propertyName).IsModified = false;
            }
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateExclude(TEntity entity, params Expression<Func<TEntity, object>>[] propertyExpressions)
        {
            var entityEntry = Attach(entity);
            entityEntry.State = EntityState.Modified;
            foreach (var propertyExpression in propertyExpressions)
            {
                EntityPropertyEntry(entity, propertyExpression).IsModified = false;
            }
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateExclude(TEntity entity, IEnumerable<string> propertyNames)
        {
            return UpdateExclude(entity, propertyNames.ToArray());
        }

        /// <summary>
        /// 排除特定属性更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateExclude(TEntity entity, IEnumerable<Expression<Func<TEntity, object>>> propertyExpressions)
        {
            return UpdateExclude(entity, propertyExpressions.ToArray());
        }

        /// <summary>
        /// 排除特定属性更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual Task<EntityEntry<TEntity>> UpdateExcludeAsync(TEntity entity, params string[] propertyNames)
        {
            return Task.FromResult(UpdateExclude(entity, propertyNames));
        }

        /// <summary>
        /// 排除特定属性更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual Task<EntityEntry<TEntity>> UpdateExcludeAsync(TEntity entity, params Expression<Func<TEntity, object>>[] propertyExpressions)
        {
            return Task.FromResult(UpdateExclude(entity, propertyExpressions));
        }

        /// <summary>
        /// 排除特定属性更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual Task<EntityEntry<TEntity>> UpdateExcludeAsync(TEntity entity, IEnumerable<string> propertyNames)
        {
            return Task.FromResult(UpdateExclude(entity, propertyNames));
        }

        /// <summary>
        /// 排除特定属性更新
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual Task<EntityEntry<TEntity>> UpdateExcludeAsync(TEntity entity, IEnumerable<Expression<Func<TEntity, object>>> propertyExpressions)
        {
            return Task.FromResult(UpdateExclude(entity, propertyExpressions));
        }

        /// <summary>
        /// 排除特定属性更新并立即提交
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateExcludeSaveChanges(TEntity entity, params string[] propertyNames)
        {
            var entityEntry = UpdateExclude(entity, propertyNames);
            SaveChanges();
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新并立即提交
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateExcludeSaveChanges(TEntity entity, bool acceptAllChangesOnSuccess, params string[] propertyNames)
        {
            var entityEntry = UpdateExclude(entity, propertyNames);
            SaveChanges(acceptAllChangesOnSuccess);
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新并立即提交
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateExcludeSaveChanges(TEntity entity, params Expression<Func<TEntity, object>>[] propertyExpressions)
        {
            var entityEntry = UpdateExclude(entity, propertyExpressions);
            SaveChanges();
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新并立即提交
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateExcludeSaveChanges(TEntity entity, bool acceptAllChangesOnSuccess, params Expression<Func<TEntity, object>>[] propertyExpressions)
        {
            var entityEntry = UpdateExclude(entity, propertyExpressions);
            SaveChanges(acceptAllChangesOnSuccess);
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新并立即提交
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateExcludeSaveChanges(TEntity entity, IEnumerable<string> propertyNames)
        {
            var entityEntry = UpdateExclude(entity, propertyNames);
            SaveChanges();
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新并立即提交
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateExcludeSaveChanges(TEntity entity, bool acceptAllChangesOnSuccess, IEnumerable<string> propertyNames)
        {
            var entityEntry = UpdateExclude(entity, propertyNames);
            SaveChanges(acceptAllChangesOnSuccess);
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新并立即提交
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateExcludeSaveChanges(TEntity entity, IEnumerable<Expression<Func<TEntity, object>>> propertyExpressions)
        {
            var entityEntry = UpdateExclude(entity, propertyExpressions);
            SaveChanges();
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新并立即提交
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual EntityEntry<TEntity> UpdateExcludeSaveChanges(TEntity entity, bool acceptAllChangesOnSuccess, IEnumerable<Expression<Func<TEntity, object>>> propertyExpressions)
        {
            var entityEntry = UpdateExclude(entity, propertyExpressions);
            SaveChanges(acceptAllChangesOnSuccess);
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新并立即提交（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateExcludeSaveChangesAsync(TEntity entity, params string[] propertyNames)
        {
            var entityEntry = await UpdateExcludeAsync(entity, propertyNames);
            await SaveChangesAsync();
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新并立即提交（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="propertyNames"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateExcludeSaveChangesAsync(TEntity entity, bool acceptAllChangesOnSuccess, params string[] propertyNames)
        {
            var entityEntry = await UpdateExcludeAsync(entity, propertyNames);
            await SaveChangesAsync(acceptAllChangesOnSuccess);
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新并立即提交（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateExcludeSaveChangesAsync(TEntity entity, params Expression<Func<TEntity, object>>[] propertyExpressions)
        {
            var entityEntry = await UpdateExcludeAsync(entity, propertyExpressions);
            await SaveChangesAsync();
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新并立即提交（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="propertyExpressions"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateExcludeSaveChangesAsync(TEntity entity, bool acceptAllChangesOnSuccess, params Expression<Func<TEntity, object>>[] propertyExpressions)
        {
            var entityEntry = await UpdateExcludeAsync(entity, propertyExpressions);
            await SaveChangesAsync(acceptAllChangesOnSuccess);
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新并立即提交（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateExcludeSaveChangesAsync(TEntity entity, IEnumerable<string> propertyNames, CancellationToken cancellationToken = default)
        {
            var entityEntry = await UpdateExcludeAsync(entity, propertyNames);
            await SaveChangesAsync(cancellationToken);
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新并立即提交（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyNames"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateExcludeSaveChangesAsync(TEntity entity, IEnumerable<string> propertyNames, bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entityEntry = await UpdateExcludeAsync(entity, propertyNames);
            await SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新并立即提交（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateExcludeSaveChangesAsync(TEntity entity, IEnumerable<Expression<Func<TEntity, object>>> propertyExpressions, CancellationToken cancellationToken = default)
        {
            var entityEntry = await UpdateExcludeAsync(entity, propertyExpressions);
            await SaveChangesAsync(cancellationToken);
            return entityEntry;
        }

        /// <summary>
        /// 排除特定属性更新并立即提交（异步）
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyExpressions"></param>
        /// <param name="acceptAllChangesOnSuccess"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual async Task<EntityEntry<TEntity>> UpdateExcludeSaveChangesAsync(TEntity entity, IEnumerable<Expression<Func<TEntity, object>>> propertyExpressions, bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entityEntry = await UpdateExcludeAsync(entity, propertyExpressions);
            await SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            return entityEntry;
        }
    }
}