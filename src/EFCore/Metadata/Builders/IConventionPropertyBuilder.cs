// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Microsoft.EntityFrameworkCore.Metadata.Builders
{
    /// <summary>
    ///     <para>
    ///         Provides a simple API surface for configuring an <see cref="IConventionProperty" /> from conventions.
    ///     </para>
    ///     <para>
    ///         This interface is typically used by database providers (and other extensions). It is generally
    ///         not used in application code.
    ///     </para>
    /// </summary>
    /// <remarks>
    ///     See <see href="https://aka.ms/efcore-docs-conventions">Model building conventions</see> for more information.
    /// </remarks>
    public interface IConventionPropertyBuilder : IConventionPropertyBaseBuilder
    {
        /// <summary>
        ///     Gets the property being configured.
        /// </summary>
        new IConventionProperty Metadata { get; }

        /// <summary>
        ///     Configures whether this property must have a value assigned or <see langword="null" /> is a valid value.
        ///     A property can only be configured as non-required if it is based on a CLR type that can be
        ///     assigned <see langword="null" />.
        /// </summary>
        /// <param name="required">
        ///     A value indicating whether the property is required.
        ///     <see langword="null" /> to reset to default.
        /// </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the requiredness was configured,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? IsRequired(bool? required, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether this property requiredness can be configured
        ///     from the current configuration source.
        /// </summary>
        /// <param name="required">
        ///     A value indicating whether the property is required.
        ///     <see langword="null" /> to reset to default.
        /// </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns> <see langword="true" /> if the property requiredness can be configured. </returns>
        bool CanSetIsRequired(bool? required, bool fromDataAnnotation = false);

        /// <summary>
        ///     Sets a value indicating when a value for this property will be generated by the database. Even when the
        ///     property is set to be generated by the database, EF may still attempt to save a specific value (rather than
        ///     having one generated by the database) when the entity is added and a value is assigned, or the property is
        ///     marked as modified for an existing entity. See <see cref="IReadOnlyProperty.GetBeforeSaveBehavior" /> and
        ///     <see cref="IReadOnlyProperty.GetAfterSaveBehavior" /> for more information.
        /// </summary>
        /// <param name="valueGenerated">
        ///     A value indicating when a value for this property will be generated by the database.
        ///     <see langword="null" /> to reset to default.
        /// </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the requiredness was configured,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? ValueGenerated(ValueGenerated? valueGenerated, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the property value generation can be configured
        ///     from the current configuration source.
        /// </summary>
        /// <param name="valueGenerated">
        ///     A value indicating when a value for this property will be generated by the database.
        ///     <see langword="null" /> to reset to default.
        /// </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns> <see langword="true" /> if the property value generation can be configured. </returns>
        bool CanSetValueGenerated(ValueGenerated? valueGenerated, bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures whether this property should be used as a concurrency token. When a property is configured
        ///     as a concurrency token the value in the database will be checked when an instance of this entity type
        ///     is updated or deleted during <see cref="DbContext.SaveChanges()" /> to ensure it has not changed since
        ///     the instance was retrieved from the database. If it has changed, an exception will be thrown and the
        ///     changes will not be applied to the database.
        /// </summary>
        /// <param name="concurrencyToken"> A value indicating whether this property is a concurrency token. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? IsConcurrencyToken(bool? concurrencyToken, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the property can be configured as a concurrency token
        ///     from the current configuration source.
        /// </summary>
        /// <param name="concurrencyToken"> A value indicating whether this property is a concurrency token. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns> <see langword="true" /> if the property can be configured as a concurrency token. </returns>
        bool CanSetIsConcurrencyToken(bool? concurrencyToken, bool fromDataAnnotation = false);

        /// <summary>
        ///     Sets the backing field to use for this property.
        /// </summary>
        /// <param name="fieldName"> The field name. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        new IConventionPropertyBuilder? HasField(string? fieldName, bool fromDataAnnotation = false);

        /// <summary>
        ///     Sets the backing field to use for this property.
        /// </summary>
        /// <param name="fieldInfo"> The field. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        new IConventionPropertyBuilder? HasField(FieldInfo? fieldInfo, bool fromDataAnnotation = false);

        /// <summary>
        ///     Sets the <see cref="PropertyAccessMode" /> to use for this property.
        /// </summary>
        /// <param name="propertyAccessMode"> The <see cref="PropertyAccessMode" /> to use for this property. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        new IConventionPropertyBuilder? UsePropertyAccessMode(PropertyAccessMode? propertyAccessMode, bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures the maximum length of data that can be stored in this property.
        /// </summary>
        /// <param name="maxLength"> The maximum length of data allowed in the property. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? HasMaxLength(int? maxLength, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the maximum length of data allowed can be set for this property
        ///     from the current configuration source.
        /// </summary>
        /// <param name="maxLength"> The maximum length of data allowed in the property. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns> <see langword="true" /> if the maximum length of data allowed can be set for this property. </returns>
        bool CanSetMaxLength(int? maxLength, bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures whether the property as capable of persisting unicode characters.
        /// </summary>
        /// <param name="unicode"> A value indicating whether the property can contain unicode characters. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? IsUnicode(bool? unicode, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the property can be configured as capable of persisting unicode characters
        ///     from the current configuration source.
        /// </summary>
        /// <param name="unicode"> A value indicating whether the property can contain unicode characters. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns> <see langword="true" /> if the capability of persisting unicode characters can be configured for this property. </returns>
        bool CanSetIsUnicode(bool? unicode, bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures the precision of the property.
        /// </summary>
        /// <param name="precision"> The precision of the property. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? HasPrecision(int? precision, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the precision of data allowed can be set for this property
        ///     from the current configuration source.
        /// </summary>
        /// <param name="precision"> The precision of the property. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns> <see langword="true" /> if the precision of data allowed can be set for this property. </returns>
        bool CanSetPrecision(int? precision, bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures the scale of the property.
        /// </summary>
        /// <param name="scale"> The scale of the property. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? HasScale(int? scale, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the scale of data allowed can be set for this property
        ///     from the current configuration source.
        /// </summary>
        /// <param name="scale"> The scale of the property. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns> <see langword="true" /> if the scale of data allowed can be set for this property. </returns>
        bool CanSetScale(int? scale, bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures whether this property can be modified before the entity is saved to the database.
        /// </summary>
        /// <param name="behavior">
        ///     A value indicating whether this property can be modified before the entity is
        ///     saved to the database. <see langword="null" /> to reset to default.
        /// </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? BeforeSave(PropertySaveBehavior? behavior, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the ability to be modified before the entity is saved to the database
        ///     can be configured for this property from the current configuration source.
        /// </summary>
        /// <param name="behavior">
        ///     A value indicating whether this property can be modified before the entity is
        ///     saved to the database. <see langword="null" /> to reset to default.
        /// </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     <see langword="true" /> if the ability to be modified before the entity is saved to the database can be configured for this property.
        /// </returns>
        bool CanSetBeforeSave(PropertySaveBehavior? behavior, bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures whether this property can be modified after the entity is saved to the database.
        /// </summary>
        /// <param name="behavior">
        ///     Sets a value indicating whether this property can be modified after the entity is
        ///     saved to the database. <see langword="null" /> to reset to default.
        /// </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? AfterSave(PropertySaveBehavior? behavior, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the ability to be modified after the entity is saved to the database
        ///     can be configured for this property from the current configuration source.
        /// </summary>
        /// <param name="behavior">
        ///     A value indicating whether this property can be modified after the entity is
        ///     saved to the database. <see langword="null" /> to reset to default.
        /// </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     <see langword="true" /> if the ability to be modified after the entity is saved to the database can be configured for this property.
        /// </returns>
        bool CanSetAfterSave(PropertySaveBehavior? behavior, bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures the <see cref="ValueGenerator" /> that will generate values for this property.
        /// </summary>
        /// <param name="valueGeneratorType"> A type that inherits from <see cref="ValueGenerator" />. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? HasValueGenerator(Type? valueGeneratorType, bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures the <see cref="ValueGenerator" /> that will generate values for this property.
        /// </summary>
        /// <param name="factory"> A delegate that will be used to create value generator instances. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? HasValueGenerator(
            Func<IProperty, IEntityType, ValueGenerator>? factory,
            bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures the <see cref="ValueGeneratorFactory" /> for creating a <see cref="ValueGenerator" /> that will
        ///     generate values for this property.
        /// </summary>
        /// <param name="valueGeneratorFactoryType"> A type that inherits from <see cref="ValueGeneratorFactory" />. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? HasValueGeneratorFactory(Type? valueGeneratorFactoryType, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the <see cref="ValueGenerator" /> can be configured for this property
        ///     from the current configuration source.
        /// </summary>
        /// <param name="factory"> A delegate that will be used to create value generator instances. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        /// <returns>
        ///     <see langword="true" /> if the <see cref="ValueGenerator" /> can be configured for this property.
        /// </returns>
        bool CanSetValueGenerator(
            Func<IProperty, IEntityType, ValueGenerator>? factory,
            bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the <see cref="ValueGeneratorFactory" /> can be configured for this property
        ///     from the current configuration source.
        /// </summary>
        /// <param name="valueGeneratorFactoryType"> A type that inherits from <see cref="ValueGeneratorFactory" />. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        /// <returns>
        ///     <see langword="true" /> if the <see cref="ValueGenerator" /> can be configured for this property.
        /// </returns>
        bool CanSetValueGeneratorFactory(
            Type? valueGeneratorFactoryType,
            bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures the property so that the property value is converted to and from the database
        ///     using the given <see cref="ValueConverter" />.
        /// </summary>
        /// <param name="converter"> The converter to use. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? HasConversion(ValueConverter? converter, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the <see cref="ValueConverter" /> can be configured for this property
        ///     from the current configuration source.
        /// </summary>
        /// <param name="converter"> The converter to use. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     <see langword="true" /> if the <see cref="ValueConverter" /> can be configured for this property.
        /// </returns>
        bool CanSetConversion(ValueConverter? converter, bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures the property so that the property value is converted to the given type before
        ///     writing to the database and converted back when reading from the database.
        /// </summary>
        /// <param name="providerClrType"> The type to convert to and from. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? HasConversion(Type? providerClrType, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the given type to convert values to and from
        ///     can be configured for this property from the current configuration source.
        /// </summary>
        /// <param name="providerClrType"> The type to convert to and from. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     <see langword="true" /> if the given type to convert values to and from can be configured for this property.
        /// </returns>
        bool CanSetConversion(Type? providerClrType, bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures the property so that the property value is converted to and from the database
        ///     using the given <see cref="ValueConverter" />.
        /// </summary>
        /// <param name="converterType">
        ///     A type that derives from <see cref="ValueConverter"/>,
        ///     or <see langword="null" /> to remove any previously set converter.
        /// </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? HasConverter(Type? converterType, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the <see cref="ValueConverter" /> can be configured for this property
        ///     from the current configuration source.
        /// </summary>
        /// <param name="converterType">
        ///     A type that derives from <see cref="ValueConverter"/>,
        ///     or <see langword="null" /> to remove any previously set converter.
        /// </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     <see langword="true" /> if the <see cref="ValueConverter" /> can be configured for this property.
        /// </returns>
        bool CanSetConverter(Type? converterType, bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures the <see cref="CoreTypeMapping" /> for this property.
        /// </summary>
        /// <param name="typeMapping"> The type mapping, or <see langword="null" /> to remove any previously set type mapping. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? HasTypeMapping(CoreTypeMapping? typeMapping, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the given <see cref="CoreTypeMapping" />
        ///     can be configured for this property from the current configuration source.
        /// </summary>
        /// <param name="typeMapping"> The type mapping. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     <see langword="true" /> if the given <see cref="ValueComparer" /> can be configured for this property.
        /// </returns>
        bool CanSetTypeMapping(CoreTypeMapping typeMapping, bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures the <see cref="ValueComparer" /> for this property.
        /// </summary>
        /// <param name="comparer"> The comparer, or <see langword="null" /> to remove any previously set comparer. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied, <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? HasValueComparer(ValueComparer? comparer, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the given <see cref="ValueComparer" />
        ///     can be configured for this property from the current configuration source.
        /// </summary>
        /// <param name="comparer"> The comparer, or <see langword="null" /> to remove any previously set comparer. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     <see langword="true" /> if the given <see cref="ValueComparer" /> can be configured for this property.
        /// </returns>
        bool CanSetValueComparer(ValueComparer? comparer, bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures the <see cref="ValueComparer" /> for this property.
        /// </summary>
        /// <param name="comparerType">
        ///     A type that derives from <see cref="ValueComparer"/>,
        ///     or <see langword="null" /> to remove any previously set comparer.
        /// </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied, <see langword="null" /> otherwise.
        /// </returns>
        IConventionPropertyBuilder? HasValueComparer(Type? comparerType, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the given <see cref="ValueComparer" />
        ///     can be configured for this property from the current configuration source.
        /// </summary>
        /// <param name="comparerType">
        ///     A type that derives from <see cref="ValueComparer"/>,
        ///     or <see langword="null" /> to remove any previously set comparer.
        /// </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     <see langword="true" /> if the given <see cref="ValueComparer" /> can be configured for this property.
        /// </returns>
        bool CanSetValueComparer(Type? comparerType, bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures the <see cref="ValueComparer" /> to be used for key comparisons for this property.
        /// </summary>
        /// <param name="comparer"> The comparer, or <see langword="null" /> to remove any previously set comparer. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        [Obsolete("Use HasValueComparer. Only a single value comparer is allowed for a given property.")]
        IConventionPropertyBuilder? HasKeyValueComparer(ValueComparer? comparer, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the given <see cref="ValueComparer" />
        ///     can be configured for this property from the current configuration source.
        /// </summary>
        /// <param name="comparer"> The comparer, or <see langword="null" /> to remove any previously set comparer. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     <see langword="true" /> if the given <see cref="ValueComparer" /> can be configured for this property.
        /// </returns>
        [Obsolete("Use CanSetValueComparer. Only a single value comparer is allowed for a given property.")]
        bool CanSetKeyValueComparer(ValueComparer? comparer, bool fromDataAnnotation = false);

        /// <summary>
        ///     Configures the <see cref="ValueComparer" /> to be used for structural comparisons for this property.
        /// </summary>
        /// <param name="comparer"> The comparer, or <see langword="null" /> to remove any previously set comparer. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     The same builder instance if the configuration was applied,
        ///     <see langword="null" /> otherwise.
        /// </returns>
        [Obsolete("Use HasValueComparer. Only a single value comparer is allowed for a given property.")]
        IConventionPropertyBuilder? HasStructuralValueComparer(ValueComparer? comparer, bool fromDataAnnotation = false);

        /// <summary>
        ///     Returns a value indicating whether the given <see cref="ValueComparer" />
        ///     can be configured for this property from the current configuration source.
        /// </summary>
        /// <param name="comparer"> The comparer, or <see langword="null" /> to remove any previously set comparer. </param>
        /// <param name="fromDataAnnotation"> Indicates whether the configuration was specified using a data annotation. </param>
        /// <returns>
        ///     <see langword="true" /> if the given <see cref="ValueComparer" /> can be configured for this property.
        /// </returns>
        [Obsolete("Use CanSetValueComparer. Only a single value comparer is allowed for a given property.")]
        bool CanSetStructuralValueComparer(ValueComparer? comparer, bool fromDataAnnotation = false);
    }
}
