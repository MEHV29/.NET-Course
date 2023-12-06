using System.Text.Json;
using System.Text.Json.Serialization;

namespace Task6
{
    internal class BookEntryConverter : JsonConverter<List<BookEntry>>
    {
        public override List<BookEntry> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            using (JsonDocument doc = JsonDocument.ParseValue(ref reader))
            {
                // Deserialize each BookEntry within the Books list
                return doc.RootElement.EnumerateArray()
                    .Select(entry => JsonSerializer.Deserialize<BookEntry>(entry.GetRawText(), options))
                    .ToList();
            }
        }

        public override void Write(Utf8JsonWriter writer, List<BookEntry> value, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }
    }
}