﻿using System.Collections.Generic;
using Coderr.Client.ContextProviders;
using Coderr.Client.Contracts;
using Coderr.Client.Reporters;

namespace Coderr.Client.AspNet.Mvc5.ContextProviders
{
    /// <summary>
    ///     Name: "ViewData"
    /// </summary>
    public class ViewDataProvider : IContextInfoProvider
    {
        /// <inheritdoc />
        public ContextCollectionDTO Collect(IErrorReporterContext context)
        {
            var aspNetContext = context as AspNetMvcContext;
            if (aspNetContext?.ViewData == null || aspNetContext.ViewData.Count == 0)
                return null;

            var di = new Dictionary<string, string>();
            using (var kIt = aspNetContext.ViewData.Keys.GetEnumerator())
            {
                using (var vIt = aspNetContext.ViewData.Values.GetEnumerator())
                {
                    while (kIt.MoveNext() && vIt.MoveNext())
                        di[kIt.Current] = vIt.Current.ToString();
                }
            }

            return new ContextCollectionDTO(Name, di);
        }

        /// <summary>ViewData</summary>
        public string Name => "ViewData";
    }
}