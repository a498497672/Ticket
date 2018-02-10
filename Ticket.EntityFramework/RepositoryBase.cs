using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace Ticket.EntityFramework
{
    public class RepositoryBase<TEntity> where TEntity : class
    {
        protected DbContext _dbContext;
        public DbSet<TEntity> _dbset
        {
            get
            {
                return _dbContext.Set<TEntity>();
            }
        }

        public RepositoryBase()
        {
        }

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 提供LINQ使用的可查询对象
        /// </summary>
        public IQueryable AsQueryable()
        {
            return _dbset.AsQueryable();
        }

        /// <summary>
        /// 根据条件表达式获取满足条件的所有类型为TEntity的数据
        /// </summary>
        /// <param name="expression">条件表达式</param>
        /// <returns>返回满足条件的所有类型为TEntity的数据</returns>
        public virtual IQueryable Find(Expression<Func<TEntity, bool>> expression)
        {
            return _dbset.Where(expression);
        }

        /// <summary>
        /// 根据条件表达式获取满足条件的所有类型为TEntity的数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> Find(string sql)
        {
            return _dbContext.Database.SqlQuery<TEntity>(sql, new Object[] { }).AsQueryable();
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.Where(predicate).Single();
        }

        public TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.Where(predicate).FirstOrDefault();
        }

        public TEntity FirstOrDefault<S>(Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, S>> orderbyLambda, bool isAsc = true)
        {
            if (isAsc)
            {
                return _dbset.Where(whereLambda).OrderBy(orderbyLambda).FirstOrDefault();
            }
            else
            {
                return _dbset.Where(whereLambda).OrderByDescending(orderbyLambda).FirstOrDefault();
            }
        }

        public TEntity FirstOrDefault()
        {
            return _dbset.AsQueryable().FirstOrDefault();
        }

        public List<TEntity> GetList()
        {
            return _dbset.ToList();
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbset.Where(predicate).ToList();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbset;
        }

        /// <summary>
        /// 根据条件表达式统计满足条件的数据条数
        /// </summary>
        /// <param name="expression">条件表达式</param>
        /// <returns>满足条件的记录数量</returns>
        public int Count(Expression<Func<TEntity, bool>> expression)
        {
            return _dbset.Count(expression);
        }

        /// <summary>
        /// 根据主键获取类型为TEntity的数据 如果不存在则返回null
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>返回类型为TEntity的数据</returns>
        public virtual TEntity Get(object id)
        {
            return _dbset.Find(id);
        }

        /// <summary>
        /// 根据条件表达式获取满足条件的首个类型为TEntity的数据,如果不存在则返回NULL
        /// </summary>
        /// <param name="expression">条件表达式</param>
        /// <returns>返回满足条件的首个类型为TEntity的数据</returns>
        public virtual TEntity First(Expression<Func<TEntity, bool>> expression)
        {
            return _dbset.AsQueryable().FirstOrDefault(expression);
        }

        public IQueryable<TEntity> GetPageList<S>(int pageSize, int pageIndex, out int total, Expression<Func<TEntity, bool>> whereLambda, Expression<Func<TEntity, S>> orderbyLambda, bool isAsc = true)
        {
            total = _dbset.Where(whereLambda).Count();
            if (isAsc)
            {
                return _dbset.Where(whereLambda).OrderBy(orderbyLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();
            }
            else
            {
                return _dbset.Where(whereLambda).OrderByDescending(orderbyLambda).Skip(pageSize * (pageIndex - 1)).Take(pageSize).AsQueryable();
            }
        }

        public void Add(TEntity entity)
        {
            _dbset.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity, string[] propertys)
        {
            if (propertys == null || propertys.Length == 0)
            {
                throw new Exception("当前更新的实体必须至少指定一个字段名称");
            }

            //1.0 关闭EF的 实体验证检查
            _dbContext.Configuration.ValidateOnSaveEnabled = false;

            //2.0 将实体手工追加到EF容器中
            DbEntityEntry entry = _dbContext.Entry(entity);
            //3.0 将EF容器中当前实体的代理类状态修改成Unchanged
            entry.State = EntityState.Unchanged;
            //4.0 遍历用户传入的属性数值，将代理类中的属性对应的IsModified设置成true
            foreach (var item in propertys)
            {
                entry.Property(item).IsModified = true;
            }
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _dbset.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(List<TEntity> entitys, bool isAddedEFContext = true)
        {
            foreach (var entity in entitys)
            {
                _dbset.Remove(entity);
            }
            _dbContext.SaveChanges();
        }


        public int SaveChanges()
        {
            return _dbContext.SaveChanges();
        }
    }
}
