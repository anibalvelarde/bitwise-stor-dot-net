using System;
using System.Collections;

namespace BitwiseStor.Constants
{
    private static class Values
    {
        public const int UPPER_LIMIT = 16777215;
        public const string MASK = "000000000000000000000000";
        public const string[] LABELS = { "PROPS", "bwsPackedPropNames", "VALUE", "bwsPackedValue" };
    }

    private enum Errors 
    {
        [Description("Upper limit exceeded.")]
        UPPER_LIMIT_EXCEEDED,
        [Description("Value must be positive integer.")]
        VALUE_MUST_BE_POSITIVE,
        [Description("Value must be a string.")]
        VALUE_MUST_BE_STRING,
        [Description("Value must be numeric.")]
        VALUE_MUST_BE_NUMERIC,
        [Description("Value must be an Array.")]
        VALUE_MUST_BE_ARRAY,
        [Description("Element of bits array must be zero or 1.")]
        ARRAY_ELEMENTS_MUST_BE_ZERO_OR_ONE,
        [Description("Element of array must be of boolean values.")]
        ARRAY_ELEMENTS_MUST_BE_BOOLEAN,
        [Description("Improperly packed object.")]
        IMPROPERLY_PACKED_OBJECT,
        [Description("Inconsistent proerty to values count.")]
        INCONSISTENT_PROP_TO_VALUE_COUNT
    }
}