﻿using System;
using System.Collections.Generic;
using System.Text;
using WorkflowCore.Interface;
using WorkflowCore.Persistence.PostgreSQL;
using WorkflowCore.UnitTests;
using Xunit;
using Xunit.Abstractions;

namespace WorkflowCore.Tests.PostgreSQL
{
    [Collection("Postgres collection")]
    public class PostgresPersistenceProviderFixture : BasePersistenceFixture
    {
        private readonly IPersistenceProvider _subject;
        protected override IPersistenceProvider Subject => _subject;

        public PostgresPersistenceProviderFixture(PostgresDockerSetup dockerSetup, ITestOutputHelper output)
        {
            output.WriteLine($"Connecting on {PostgresDockerSetup.ConnectionString}");
            _subject = new PostgresPersistenceProvider(PostgresDockerSetup.ConnectionString, true, true);
            _subject.EnsureStoreExists();
        }
    }
}
