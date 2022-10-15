using System;
using System.Collections.Generic;
using UnityEngine.GameFoundation.DefaultCatalog;

namespace UnityEngine.GameFoundation.OptionalModules.DiceNotation.OptionalModules.Randomization
{
    [Serializable]
    public class CurrencyInitialBalanceRandomizer : IExternalValueProvider
    {
        public List<CatalogItemRandomRange> InitialBalanceRanges;

        public bool TryGetValue(string catalogItemFieldName, string catalogItemKey, out Property value)
        {
            foreach (CatalogItemRandomRange range in InitialBalanceRanges)
            {
                if (catalogItemFieldName != range.Field)
                {
                    continue;
                }
                if (range.Item != catalogItemKey)
                {
                    continue;
                }

                // Randomize the value.

                value = default;
                long newValue = (long)Random.Range(range.MinimumValue, range.MaximumValue);

                // Make sure the value is positive.
                value = Mathf.Max(0, newValue);

                return true;
            }

            // No match found.
            value = default;

            return default;
        }
    }
}