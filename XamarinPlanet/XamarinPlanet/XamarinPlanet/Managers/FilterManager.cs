using System;
using System.Collections.Generic;
using System.Linq;
using XamarinPlanet.Models;

namespace XamarinPlanet
{
    public class FilterManager
    {
        public List<Contributor> FilterByContributors(IEnumerable<Contributor> contributors, string text)
            => contributors
                .Where(c => c.Name.IndexOf(text, StringComparison.OrdinalIgnoreCase) > -1)
                .ToList();
    }
}