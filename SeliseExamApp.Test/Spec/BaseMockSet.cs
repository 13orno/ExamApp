﻿using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeliseExamApp.Test.Spec
{
    public static class DbSetMocking
    {
        private static Mock<IDbSet<T>> CreateMockSet<T>(IQueryable<T> data)
            where T : class
        {
            var queryableData = data.AsQueryable();
            var mockSet = new Mock<IDbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider)
                    .Returns(queryableData.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression)
                    .Returns(queryableData.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType)
                    .Returns(queryableData.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator())
                    .Returns(queryableData.GetEnumerator());
            return mockSet;
        }
    }
}
