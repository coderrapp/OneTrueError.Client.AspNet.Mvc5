﻿using System.Collections.Generic;
using Coderr.Client.ContextProviders;
using Coderr.Client.Contracts;
using Coderr.Client.Reporters;

namespace Coderr.Client.AspNet.Mvc5.ContextProviders
{
    /// <summary>
    ///     "RouteData"
    /// </summary>
    public class RouteDataProvider : IContextInfoProvider
    {
        /// <inheritdoc />
        public ContextCollectionDTO Collect(IErrorReporterContext context)
        {
            var aspNetContext = context as AspNetMvcContext;
            if (aspNetContext?.RouteData == null || aspNetContext.RouteData.Values.Count == 0)
                return null;

            var dict = new Dictionary<string, string>();
            foreach (var token in aspNetContext.RouteData.DataTokens)
                dict.Add($"DataToken[\"{token.Key}\"]", token.Value.ToString());
            foreach (var token in aspNetContext.RouteData.Values)
                dict.Add($"Values[\"{token.Key}\"]", token.Value.ToString());

            return new ContextCollectionDTO(Name, dict);
        }

        /// <summary>"RouteData"</summary>
        public string Name => "RouteData";
    }
}