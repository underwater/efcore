﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.Diagnostics.CodeAnalysis;

namespace Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

/// <summary>
///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
///     the same compatibility standards as public APIs. It may be changed or removed without notice in
///     any release. You should only use it directly in your code with extreme caution and knowing that
///     doing so can result in application failures when updating to a new Entity Framework Core release.
/// </summary>
public class SqlServerQueryCompilationContext : RelationalQueryCompilationContext
{
    private readonly bool _multipleActiveResultSetsEnabled;

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public SqlServerQueryCompilationContext(
        QueryCompilationContextDependencies dependencies,
        RelationalQueryCompilationContextDependencies relationalDependencies,
        bool async,
        bool multipleActiveResultSetsEnabled)
        : this(
            dependencies, relationalDependencies, async, multipleActiveResultSetsEnabled, precompiling: false,
            nonNullableReferenceTypeParameters: null)
    {
        _multipleActiveResultSetsEnabled = multipleActiveResultSetsEnabled;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    [Experimental(EFDiagnostics.PrecompiledQueryExperimental)]
    public SqlServerQueryCompilationContext(
        QueryCompilationContextDependencies dependencies,
        RelationalQueryCompilationContextDependencies relationalDependencies,
        bool async,
        bool multipleActiveResultSetsEnabled,
        bool precompiling,
        IReadOnlySet<string>? nonNullableReferenceTypeParameters)
        : base(dependencies, relationalDependencies, async, precompiling, nonNullableReferenceTypeParameters)
    {
        _multipleActiveResultSetsEnabled = multipleActiveResultSetsEnabled;
    }

    /// <summary>
    ///     This is an internal API that supports the Entity Framework Core infrastructure and not subject to
    ///     the same compatibility standards as public APIs. It may be changed or removed without notice in
    ///     any release. You should only use it directly in your code with extreme caution and knowing that
    ///     doing so can result in application failures when updating to a new Entity Framework Core release.
    /// </summary>
    public override bool IsBuffering
        => base.IsBuffering
            || (QuerySplittingBehavior == EntityFrameworkCore.QuerySplittingBehavior.SplitQuery
                && !_multipleActiveResultSetsEnabled);

    /// <inheritdoc />
    public override bool SupportsPrecompiledQuery => true;
}
