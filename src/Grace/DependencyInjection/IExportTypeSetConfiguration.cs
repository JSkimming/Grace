﻿using System;
using System.Collections.Generic;
using Grace.DependencyInjection.Conditions;
using Grace.DependencyInjection.Lifestyle;

namespace Grace.DependencyInjection
{
    public interface IExportTypeSetConfiguration
    {
        /// <summary>
        /// Add conditions for export
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        IExportTypeSetConfiguration AndCondition(Func<Type, IEnumerable<ICompiledCondition>> conditions);

        /// <summary>
        /// Export all types based on speficied type by Type
        /// </summary>
        /// <param name="baseType">base type to export</param>
        /// <returns>configuration object</returns>
        IExportTypeSetConfiguration BasedOn(Type baseType);

        /// <summary>
        /// Export all types based on speficied type by Type
        /// </summary>
        /// <returns>configuration object</returns>
        IExportTypeSetConfiguration BasedOn<T>();

        /// <summary>
        /// Export all objects that implements the specified interface
        /// </summary>
        /// <param name="interfaceType">interface type</param>
        /// <returns>configuration object</returns>
        IExportTypeSetConfiguration ByInterface(Type interfaceType);

        /// <summary>
        /// Export all objects that implements the specified interface
        /// </summary>
        /// <returns>configuration object</returns>
        IExportTypeSetConfiguration ByInterface<T>();

        /// <summary>
        /// Export all classes by interface or that match a set of interfaces
        /// </summary>
        /// <param name="whereClause">where clause to test if the interface should be used for exporting</param>
        /// <returns>configuration object</returns>
        IExportTypeSetConfiguration ByInterfaces(Func<Type, bool> whereClause = null);

        /// <summary>
        /// Export the selected classes by type
        /// </summary>
        /// <returns>configuration object</returns>
        IExportTypeSetConfiguration ByType();

        /// <summary>
        /// Exports by a set of types
        /// </summary>
        /// <param name="typeDelegate"></param>
        /// <returns></returns>
        IExportTypeSetConfiguration ByTypes(Func<Type, IEnumerable<Type>> typeDelegate);

        /// <summary>
        /// Export a type by a set of keyed types
        /// </summary>
        /// <param name="keyedDelegate">keyed types</param>
        /// <returns></returns>
        IExportTypeSetConfiguration ByKeyedTypes(Func<Type, IEnumerable<Tuple<Type, object>>> keyedDelegate);
        
        /// <summary>
        /// Exclude a type from being used
        /// </summary>
        /// <param name="exclude">exclude delegate</param>
        /// <returns>configuration object</returns>
        IExportTypeSetConfiguration Exclude(Func<Type, bool> exclude);

        /// <summary>
        /// Lifestyle for set
        /// </summary>
        ILifestylePicker<IExportTypeSetConfiguration> Lifestyle { get; }

        /// <summary>
        /// Set a particular life style
        /// </summary>
        /// <param name="container">lifestyle</param>
        /// <returns>configuration object</returns>
        IExportTypeSetConfiguration UsingLifestyle(ICompiledLifestyle container);

        /// <summary>
        /// Set a particular life style using a func
        /// </summary>
        /// <param name="lifestyleFunc">pick a lifestyle</param>
        /// <returns>configuration object</returns>
        IExportTypeSetConfiguration UsingLifestyle(Func<Type, ICompiledLifestyle> lifestyleFunc);

        /// <summary>
        /// Add condition to exports
        /// </summary>
        IWhenConditionConfiguration<IExportTypeSetConfiguration> When { get; }

        /// <summary>
        /// Export only types that match the filter provided
        /// </summary>
        /// <param name="typeFilter"></param>
        /// <returns></returns>
        IExportTypeSetConfiguration Where(Func<Type, bool> typeFilter);

        /// <summary>
        /// Add inspector for type set
        /// </summary>
        /// <param name="inspector"></param>
        /// <returns></returns>
        IExportTypeSetConfiguration WithInspector(IActivationStrategyInspector inspector);
    }
}
