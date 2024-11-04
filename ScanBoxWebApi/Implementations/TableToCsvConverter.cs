using ScanBoxWebApi.Abstractions;
using System.Text;
using System.Text.Json;

namespace ScanBoxWebApi.Implementations
{
    public class TableToCsvConverter<T> : ITableConverter<T> where T : class
    {
        public string Convert(IEnumerable<T> array)
        {
            var sb = new StringBuilder();

            string jsonArray = JsonSerializer.Serialize(array);

            using JsonDocument jDoc = JsonDocument.Parse(jsonArray);

            JsonElement jRoot = jDoc.RootElement;
            if (jRoot.ValueKind != JsonValueKind.Array) return string.Empty;

            JsonElement firstObj = jRoot.EnumerateArray().FirstOrDefault();

            if (firstObj.ValueKind != JsonValueKind.Object) return string.Empty;

            // перебор значений имён колонок
            sb.AppendLine(string.Join("; ", firstObj.EnumerateObject().Select(x => x.Name)));

            // перебор значений во всём списке (заполняем таблицу)
            foreach (var element in jRoot.EnumerateArray())
            {
                sb.AppendLine(string.Join("; ", element.EnumerateObject().Select(x => x.Value)));
            }

            return sb.ToString();
        }
    }
}
