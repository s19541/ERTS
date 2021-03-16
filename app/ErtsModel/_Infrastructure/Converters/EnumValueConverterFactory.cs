using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace ErtsModel._Infrastructure.Converters
{
    class EnumValueConverterFactory
    {
        public static ValueConverter<TEnum, string> Create<TEnum>()
            where TEnum : Enum
        {
            return new ValueConverter<TEnum, string>(
                v => v.ToString(),
                v => (TEnum)Enum.Parse(typeof(TEnum), v));
        }
    }
}
