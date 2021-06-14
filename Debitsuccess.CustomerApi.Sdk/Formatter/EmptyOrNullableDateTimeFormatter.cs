using System;
using System.Globalization;
using Utf8Json;
using Utf8Json.Formatters;

namespace Debitsuccess.CustomerApi.Sdk.Formatter
{
    public sealed class EmptyOrNullableDateTimeFormatter: IJsonFormatter<DateTime?>
    {
        private readonly DateTimeFormatter innerFormatter;
        private readonly string _formatString;
        public EmptyOrNullableDateTimeFormatter()
        {
            this._formatString = "";
            this.innerFormatter = new DateTimeFormatter();
        }

        public EmptyOrNullableDateTimeFormatter(string formatString)
        {
            this._formatString = formatString;
            this.innerFormatter = new DateTimeFormatter(formatString);
        }

        public void Serialize(ref JsonWriter writer, DateTime? value, IJsonFormatterResolver formatterResolver)
        {
            if (value == null) { writer.WriteNull(); return; }

            innerFormatter.Serialize(ref writer, value.Value, formatterResolver);
        }

        public DateTime? Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
        {
            if (reader.ReadIsNull()) return null;
            var str = reader.ReadString();
            if(string.IsNullOrWhiteSpace(str))
            {
                return null;
            }
            else if (string.IsNullOrEmpty(_formatString))
            {
                return DateTime.Parse(str, CultureInfo.InvariantCulture);
            }
            else
            {
                return DateTime.ParseExact(str, _formatString, CultureInfo.InvariantCulture);
            }
        }
    }
}
