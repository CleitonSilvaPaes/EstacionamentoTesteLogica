using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Estacionamento.Tests.Extensions
{
    public static class MockDbSetExtensions
    {
        // Referencia
        // https://www.loganfranken.com/blog/mocking-dbset-queries-in-ef6
        public static Mock<DbSet<T>> CreateMockDbSet<T>(this IEnumerable<T> sourceList) where T : class
        {
            // Converte a lista de origem em uma consulta (queryable)
            var queryable = sourceList.AsQueryable();

            // Cria um mock de DbSet para a entidade T
            var dbSet = new Mock<DbSet<T>>();

            // Configura o mock para implementar a interface IQueryable<T>
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            // Configura o mock para implementar a interface IEnumerable<T>
            dbSet.As<IEnumerable<T>>().Setup(m => m.GetEnumerator()).Returns(queryable.GetEnumerator());

            // Retorna o mock configurado
            return dbSet;
        }

    }
}
