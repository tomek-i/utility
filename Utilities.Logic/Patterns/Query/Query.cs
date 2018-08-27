using System;
using System.Linq;
using System.Linq.Expressions;

namespace TI.Utilities.Patterns.Query
{
    public class Query<T> : IQuery<T>
    {
        private readonly Expression<Func<T, bool>> _filteredExpression;

        private Query(Expression<Func<T, bool>> filteredExpression)
        {
            _filteredExpression = filteredExpression;
        }
        public static Query<T> Create(Expression<Func<T, bool>> expression)
        {
            return new Query<T>(expression);
        }

        public static Query<T> Create(string propertyName, OperationType operation, object value)
        {
            return new Query<T>(ExpressionBuilder.Build<T>(propertyName, operation, value));
        }
        public IQueryable<T> Filter(IQueryable<T> items)
        {
            return items.Where(_filteredExpression);
        }

        public Query<T> And(Query<T> other)
        {
            if (other == null || other._filteredExpression == null)
                return new Query<T>(_filteredExpression);

            return new Query<T>(_filteredExpression.And(other._filteredExpression));
        }

        public Query<T> Or(Query<T> other)
        {
            return new Query<T>(_filteredExpression.Or(other._filteredExpression));
        }
        public static Query<T> And(Query<T> a, Query<T> b)
        {
            if (a != null)
            {
                if (b != null)
                    return a.And(b);
                else return a;
            }
            else if (b != null)
            {
                if (a != null)
                    return b.And(a);
                else return b;
            }
            else throw new NotImplementedException();
        }

        public static Query<T> And(Query<T> a, params Query<T>[] b)
        {
            if (a == null) throw new ArgumentNullException();

            Query<T> result = a;
            foreach (var item in b)
            {
                result = Query<T>.And(a, b);
            }
            return result;
        }
    }
}
