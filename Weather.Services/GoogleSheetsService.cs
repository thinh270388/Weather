using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

namespace Weather.Services
{
    public class GoogleSheetsService
    {
        private readonly SheetsService _sheetsService;
        public GoogleSheetsService(string credentialsJson)
        {
            try
            {
                var credential = GoogleCredential.FromJson(credentialsJson)
                    .CreateScoped(new[] { SheetsService.Scope.Spreadsheets });

                _sheetsService = new SheetsService(new BaseClientService.Initializer
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Weather"
                });
            }
            catch (Exception ex)
            {
                throw new Exception($"Không thể khởi tạo dịch vụ Google Sheets: {ex.Message}");
            }
        }
        public async Task<IList<IList<object>>> ReadEntireSheetAsync(string spreadsheetId, string sheetName)
        {
            try
            {
                var range = $"{sheetName}!A1:ZZ";
                var request = _sheetsService.Spreadsheets.Values.Get(spreadsheetId, range);
                var response = await request.ExecuteAsync();
                var rawData = response.Values ?? new List<IList<object>>();

                int maxColumns = rawData.Max(row => row.Count);
                var normalizedData = rawData
                    .Select(row =>
                        (IList<object>)row.Concat(Enumerable.Repeat<object>(string.Empty, maxColumns - row.Count)).ToList())
                    .ToList();
                return normalizedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Đã xảy ra lỗi khi đọc dữ liệu từ Google Sheets", ex);
            }
        }
        public async Task<IList<IList<object>>> ReadEntireSheetNewAsync(string spreadsheetId, string sheetName)
        {
            try
            {
                var range = $"{sheetName}!A1:ZZ";
                var request = _sheetsService.Spreadsheets.Values.Get(spreadsheetId, range);
                var response = await request.ExecuteAsync();
                return response.Values ?? new List<IList<object>>();
            }
            catch (Exception ex)
            {
                throw new Exception("Đã xảy ra lỗi khi đọc dữ liệu từ Google Sheets", ex);
            }
        }
        public async Task<List<string>> GetSheetNamesAsync(string spreadsheetId)
        {
            try
            {
                var request = _sheetsService.Spreadsheets.Get(spreadsheetId);
                var response = await request.ExecuteAsync();

                return response.Sheets.Select(sheet => sheet.Properties.Title).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Đã xảy ra lỗi khi lấy danh sách các sheets", ex);
            }
        }
    }
}
