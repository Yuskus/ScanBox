using ScanBoxWebApi.Abstractions;
using System.Text;
using System.Text.Json;

namespace ScanBoxWebApi.Implementations
{
    public class TableToCsvConverter : ITableConverter
    {
        public string Convert(string jsonArray)
        {
            var sb = new StringBuilder();

            using (JsonDocument jDoc = JsonDocument.Parse(jsonArray))
            {
                JsonElement jRoot = jDoc.RootElement;
                if (jRoot.ValueKind != JsonValueKind.Array) return string.Empty;

                JsonElement firstObj = jRoot.EnumerateArray().FirstOrDefault();

                if (firstObj.ValueKind != JsonValueKind.Object) return string.Empty;

                // перебор значений имён колонок
                sb.Append(string.Join(',', firstObj.EnumerateObject().Select(x => x.Name)));
                sb.Append(';');

                // перебор значений во всём списке (заполняем таблицу)
                foreach (var element in jRoot.EnumerateArray())
                {
                    sb.Append(string.Join(',', firstObj.EnumerateObject().Select(x => x.Value)));
                    sb.Append(';');
                }
            }

            return sb.ToString();
        }
    }
}
