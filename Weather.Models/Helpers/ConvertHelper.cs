using System.Collections.ObjectModel;
using Weather.Models.DTOs;

namespace Weather.Models.Helpers
{
    public class ConvertHelper
    {
        public static string AirPollutionOW(int index)
        {
            string vi = string.Empty;
            switch (index)
            {
                case 1: vi = "Tốt"; break;
                case 2: vi = "Khá"; break;
                case 3: vi = "Vừa phải"; break;
                case 4: vi = "Kém"; break;
                default: vi = "Rất kém"; break;
            }
            return vi;
        }
        public static string ConvertLocalWeather(int code)
        {
            string vi = string.Empty;
            switch (code)
            {
                case 1: vi = "Quang mây, không mưa"; break;
                case 2: vi = "Quang mây, ngày trời nắng"; break;
                case 3: vi = "Quang mây, đêm không mưa"; break;
                case 11: vi = "Quang mây, trời nắng nóng"; break;
                case 12: vi = "Quang mây, ngày nắng nóng"; break;
                case 21: vi = "Quang mây, trời nắng nóng gay gắt"; break;
                case 22: vi = "Quang mây, ngày nắng nóng gay gắt"; break;
                case 31: vi = "Quang mây, trời nắng nóng đặc biệt gay gắt"; break;
                case 32: vi = "Quang mây, ngày nắng nóng đặc biệt gay gắt"; break;
                case 1001: vi = "Ít mây, không mưa"; break;
                case 1002: vi = "Ít mây, ngày trời nắng"; break;
                case 1003: vi = "Ít mây, đêm không mưa"; break;
                case 1011: vi = "Ít mây, trời nắng nóng"; break;
                case 1012: vi = "Ít mây, ngày nắng nóng"; break;
                case 1021: vi = "Ít mây, trời nắng nóng gay gắt"; break;
                case 1022: vi = "Ít mây, ngày nắng nóng gay gắt"; break;
                case 1031: vi = "Ít mây, trời nắng nóng đặc biệt gay gắt"; break;
                case 1032: vi = "Ít mây, ngày nắng nóng đặc biệt gay gắt"; break;
                case 1081: vi = "Ít mây, có sương mù"; break;
                case 1082: vi = "Ít mây, ngày có sương mù"; break;
                case 1083: vi = "Ít mây, đêm có sương mù"; break;
                case 2001: vi = "Có mây, không mưa"; break;
                case 2002: vi = "Có mây, ngày không mưa"; break;
                case 2003: vi = "Có mây, đêm không mưa"; break;
                case 2301: vi = "Có mây, có mưa rào"; break;
                case 2302: vi = "Có mây, ngày có mưa rào"; break;
                case 2303: vi = "Có mây, đêm có mưa rào và dông"; break;
                case 2501: vi = "Có mây, có mưa rào và dông"; break;
                case 2502: vi = "Có mây, ngày có mưa rào và dông"; break;
                case 2503: vi = "Có mây, đêm có mưa rào và dông"; break;
                case 4001: vi = "Nhiều mây, không mưa"; break;
                case 4041: vi = "Nhiều mây, không mưa; trời rét"; break;
                case 4051: vi = "Nhiều mây, không mưa; trời rét đậm"; break;
                case 4061: vi = "Nhiều mây, không mưa; trời rét hại"; break;
                case 4341: vi = "Nhiều mây, có mưa; trời rét"; break;
                case 4351: vi = "Nhiều mây, có mưa; trời rét đậm"; break;
                case 4361: vi = "Nhiều mây, có mưa; trời rét hại"; break;
                case 4391: vi = "Nhiều mây, có mưa; trời rét hại kèm khả năng băng giá, mưa tuyết"; break;
                case 4091: vi = "Nhiều mây, không mưa; trời rét hại kèm khả năng sương muối"; break;
                case 4101: vi = "Nhiều mây, có mưa phùn"; break;
                case 4181: vi = "Nhiều mây, có mưa phùn và sương mù"; break;
                case 4201: vi = "Nhiều mây, có mưa nhỏ"; break;
                case 4301: vi = "Nhiều mây, có mưa, mưa rào"; break;
                case 4401: vi = "Nhiều mây, có mưa vừa"; break;
                case 4541: vi = "Nhiều mây, có mưa dông"; break;
                case 4601: vi = "Nhiều mây, có mưa to"; break;
                case 4701: vi = "Có mưa đá"; break;
                case 4571: vi = "Nhiều mây, có mưa dông; trong cơn dông có khả năng xảy ra tố, lốc, gió giật mạnh"; break;
                default: vi = code.ToString(); break;
            }
            return vi;
        }
        public static string ConvertLocalTourism(int code)
        {
            string vi = string.Empty;
            switch (code)
            {
                case 1: vi = "Thời tiết lý tưởng để đi du lịch! Trời quang đãng, không mưa sẽ thuận lợi cho các hoạt động ngoài trời như tham quan, dã ngoại, và chụp ảnh."; break;
                case 2: vi = "Rất thích hợp để khám phá các điểm đến! Tuy nhiên, hãy chuẩn bị mũ, kính râm và nước uống để tránh nắng gắt ban ngày."; break;
                case 3: vi = "Buổi tối trời quang đãng, không mưa, là cơ hội tuyệt vời để trải nghiệm không khí mát mẻ, ngắm sao hoặc dạo chơi buổi đêm."; break;
                case 11: vi = "Thời tiết khá oi bức. Nếu đi du lịch, bạn nên ưu tiên các điểm có bóng râm, gần sông hồ hoặc có điều kiện làm mát tốt."; break;
                case 12: vi = "Ngày nắng nóng thích hợp cho các chuyến đi biển, hồ bơi. Tuy nhiên, đừng quên kem chống nắng và bảo vệ da."; break;
                case 21: vi = "Thời tiết khắc nghiệt, nắng nóng gay gắt. Bạn nên hạn chế hoạt động ngoài trời vào giữa trưa và chuẩn bị đầy đủ nước uống."; break;
                case 22: vi = "Đi du lịch vào ngày này cần chuẩn bị tốt để tránh nắng, ưu tiên các hoạt động trong nhà hoặc khu vực có điều hòa."; break;
                case 31: vi = "Thời tiết rất khắc nghiệt. Cân nhắc hạn chế đi du lịch, đặc biệt với các hoạt động ngoài trời kéo dài."; break;
                case 32: vi = "Hãy cẩn thận nếu quyết định đi du lịch. Tốt nhất nên chọn các khu vực có khí hậu mát mẻ hoặc tránh các vùng nắng mạnh."; break;
                case 1001: vi = "Điều kiện thời tiết thuận lợi cho chuyến du lịch. Trời ít mây sẽ giúp bạn có những trải nghiệm thoải mái và dễ chịu."; break;
                case 1002: vi = "Thời tiết tốt cho các chuyến du lịch ngoài trời. Tuy nhiên, chuẩn bị nón và nước uống để bảo vệ sức khỏe."; break;
                case 1003: vi = "Tận hưởng không gian buổi tối mát mẻ, ít mây. Đây là thời điểm đẹp để khám phá chợ đêm hoặc đi dạo ven biển."; break;
                case 1011: vi = "Thời tiết hơi nóng, nên đi các khu vực mát mẻ hoặc có điều kiện làm mát tốt."; break;
                case 1012: vi = "Cần bảo vệ da khi đi dưới nắng. Tận hưởng chuyến đi tại các khu vực có nước hoặc râm mát."; break;
                case 1021: vi = "Thời tiết khá khắc nghiệt. Tránh xa các hoạt động ngoài trời kéo dài, đặc biệt vào buổi trưa."; break;
                case 1022: vi = "Nên cân nhắc kỹ trước khi di chuyển. Ưu tiên các hoạt động trong nhà hoặc khu vực gần biển."; break;
                case 1031: vi = "Điều kiện thời tiết rất khắc nghiệt. Nếu được, nên tránh các chuyến đi xa hoặc ngoài trời."; break;
                case 1032: vi = "Rất khó khăn cho các chuyến du lịch. Hãy ở nhà hoặc chọn nơi có điều kiện khí hậu mát mẻ."; break;
                case 1081: vi = "Sương mù nhẹ làm không gian thêm thú vị. Tuy nhiên, nên chú ý an toàn khi di chuyển."; break;
                case 1082: vi = "Thích hợp cho chuyến đi khám phá vùng núi. Lưu ý an toàn khi lái xe do tầm nhìn hạn chế."; break;
                case 1083: vi = "Khung cảnh đẹp nhưng cần cẩn thận khi đi lại vào ban đêm do sương mù."; break;
                case 2001: vi = "Thời tiết dễ chịu, hoàn hảo cho mọi hoạt động du lịch. Bạn có thể tận hưởng chuyến đi mà không lo lắng thời tiết."; break;
                case 2002: vi = "Ngày trời dịu nhẹ, thích hợp cho các chuyến tham quan. Không cần mang ô dù!"; break;
                case 2003: vi = "Lý tưởng để trải nghiệm không khí buổi đêm hoặc các hoạt động ngoài trời nhẹ nhàng."; break;
                case 2301: vi = "Mang theo ô hoặc áo mưa. Mưa rào có thể làm chuyến đi thú vị nhưng cũng hơi bất tiện."; break;
                case 2302: vi = "Nên kiểm tra dự báo mưa cụ thể tại điểm đến. Mang theo ô dù để phòng tránh."; break;
                case 2303: vi = "Thời tiết bất ổn vào ban đêm. Nên hạn chế di chuyển nếu không cần thiết."; break;
                case 2501: vi = "Chuyến đi có thể bị ảnh hưởng bởi mưa dông. Ưu tiên các hoạt động trong nhà."; break;
                case 2502: vi = "Cần kiểm tra kỹ dự báo trước khi đi. Nên có kế hoạch dự phòng cho mưa dông."; break;
                case 2503: vi = "Rất hạn chế di chuyển ban đêm. Tìm nơi trú an toàn nếu thời tiết xấu."; break;
                case 4001: vi = "Thời tiết dễ chịu, thích hợp cho du lịch. Trời nhiều mây tạo không gian mát mẻ."; break;
                case 4041: vi = "Không khí lạnh nhưng dễ chịu. Rất thích hợp để khám phá những vùng có khí hậu mát mẻ."; break;
                case 4051: vi = "Cần mang theo quần áo ấm. Trời lạnh hơn bình thường nhưng vẫn thú vị để đi du lịch."; break;
                case 4061: vi = "Trời lạnh khắc nghiệt. Chỉ nên du lịch nếu bạn có đủ trang phục ấm và điều kiện phù hợp."; break;
                case 4341: vi = "Trời rét và có mưa, có thể làm chuyến đi bất tiện. Nên kiểm tra kỹ dự báo trước."; break;
                case 4351: vi = "Thời tiết không lý tưởng. Chỉ nên di chuyển nếu cần thiết, chuẩn bị kỹ đồ giữ ấm."; break;
                case 4361: vi = "Không nên đi du lịch. Thời tiết khắc nghiệt với mưa và rét mạnh."; break;
                case 4391: vi = "Không phù hợp để du lịch, trừ khi bạn có kế hoạch đặc biệt để ngắm băng tuyết."; break;
                case 4091: vi = "Chỉ nên đi các điểm an toàn, chuẩn bị trang phục ấm đủ để chống rét."; break;
                case 4101: vi = "Mưa phùn nhẹ có thể làm không khí thêm lãng mạn."; break;
                case 4181: vi = "Không khí khá ẩm ướt và có thể hạn chế tầm nhìn. Phù hợp để tận hưởng các chuyến đi nhẹ nhàng như đi bộ, tham quan quán cà phê hoặc các khu vực trong nhà. Đảm bảo mặc ấm và chuẩn bị áo chống nước nếu cần ra ngoài."; break;
                case 4201: vi = "Thời tiết tương đối dễ chịu nhưng hơi bất tiện cho các hoạt động ngoài trời dài. Có thể đi thăm các khu bảo tàng, thư viện hoặc các địa điểm du lịch trong nhà. Mang theo ô hoặc áo mưa nhẹ."; break;
                case 4301: vi = "Thời tiết không lý tưởng cho các hoạt động ngoài trời, đặc biệt là leo núi hoặc các chuyến đi xa. Nên chọn các hoạt động trong nhà để đảm bảo thoải mái và an toàn."; break;
                case 4401: vi = "Khá bất tiện cho du lịch, đặc biệt ở các khu vực có khả năng ngập nước hoặc đường sá không tốt. Nếu phải di chuyển, hãy lên kế hoạch cẩn thận và chuẩn bị sẵn các vật dụng chống nước."; break;
                case 4541: vi = "Thời tiết khá nguy hiểm, đặc biệt là ở các khu vực trống trải hoặc gần sông suối. Không nên di chuyển xa hoặc tham gia các hoạt động ngoài trời. Theo dõi dự báo thời tiết thường xuyên."; break;
                case 4601: vi = "Hoàn toàn không phù hợp cho du lịch.Thời tiết này tiềm ẩn nguy cơ ngập úng, sạt lở đất hoặc tai nạn khi di chuyển.Nên hoãn mọi chuyến đi."; break;
                case 4701: vi = "Mưa đá là hiện tượng thời tiết nguy hiểm. Không nên ra ngoài hoặc di chuyển trừ trường hợp thật sự cần thiết. Tìm nơi trú an toàn để tránh bị thương do mưa đá."; break;
                case 4571: vi = "Cực kỳ nguy hiểm cho mọi hoạt động ngoài trời hoặc di chuyển. Tránh xa khu vực trống trải, nhà kính hoặc các nơi có nguy cơ đổ sập. Ở yên trong nhà hoặc nơi trú an toàn, tuân theo hướng dẫn của cơ quan chức năng."; break;
                default: vi = code.ToString(); break;
            }
            return vi;
        }
        public static string TranslateOW(int code)
        {
            string vi = string.Empty;
            switch (code)
            {
                case 200:
                    vi = "Giông bão kèm theo mưa nhẹ";
                    break;
                case 201:
                    vi = "Giông bão kèm theo mưa";
                    break;
                case 202:
                    vi = "Giông bão kèm theo mưa lớn";
                    break;
                case 210:
                    vi = "Cơn giông nhẹ";
                    break;
                case 211:
                    vi = "Dông";
                    break;
                case 212:
                    vi = "Cơn giông lớn";
                    break;
                case 221:
                    vi = "Cơn giông dữ dội";
                    break;
                case 230:
                    vi = "Giông bão kèm theo mưa phùn nhẹ";
                    break;
                case 231:
                    vi = "Giông bão kèm theo mưa phùn";
                    break;
                case 232:
                    vi = "Giông bão kèm theo mưa phùn nặng hạt";
                    break;

                case 300:
                    vi = "Cường độ nhẹ mưa phùn";
                    break;
                case 301:
                    vi = "Mưa phùn";
                    break;
                case 302:
                    vi = "Mưa phùn cường độ lớn";
                    break;
                case 310:
                    vi = "Cường độ nhẹ mưa phùn mưa";
                    break;
                case 311:
                    vi = "Mưa phùn";
                    break;
                case 312:
                    vi = "Mưa phùn cường độ lớn";
                    break;
                case 313:
                    vi = "Mưa rào và mưa phùn";
                    break;
                case 314:
                    vi = "Mưa rào lớn và mưa phùn";
                    break;
                case 321:
                    vi = "Mưa phùn";
                    break;

                case 500:
                    vi = "Mưa nhẹ";
                    break;
                case 501:
                    vi = "Mưa vừa";
                    break;
                case 502:
                    vi = "Mưa cường độ lớn";
                    break;
                case 503:
                    vi = "Mưa rất to";
                    break;
                case 504:
                    vi = "Mưa cực lớn";
                    break;
                case 511:
                    vi = "Mưa đá";
                    break;
                case 520:
                    vi = "Cường độ nhẹ mưa rào";
                    break;
                case 521:
                    vi = "Mưa tắm";
                    break;
                case 522:
                    vi = "Mưa rào cường độ lớn";
                    break;
                case 531:
                    vi = "Mưa rào rào";
                    break;
                case 600:
                    vi = "Tuyết rơi nhẹ";
                    break;
                case 601:
                    vi = "Tuyết";
                    break;
                case 602:
                    vi = "Tuyết rơi dày";
                    break;
                case 611:
                    vi = "Mưa đá";
                    break;
                case 612:
                    vi = "Mưa đá nhẹ";
                    break;
                case 613:
                    vi = "Mưa đá";
                    break;
                case 615:
                    vi = "Mưa nhẹ và tuyết";
                    break;
                case 616:
                    vi = "Mưa và tuyết";
                    break;
                case 620:
                    vi = "Mưa tuyết nhẹ";
                    break;
                case 621:
                    vi = "Tắm tuyết";
                    break;
                case 622:
                    vi = "Mưa tuyết lớn";
                    break;
                case 701:
                    vi = "Sương mù";
                    break;
                case 711:
                    vi = "Khói";
                    break;
                case 721:
                    vi = "Sương mù";
                    break;
                case 731:
                    vi = "Xoáy cát/bụi";
                    break;
                case 741:
                    vi = "Sương mù";
                    break;
                case 751:
                    vi = "Cát";
                    break;
                case 761:
                    vi = "Bụi";
                    break;
                case 762:
                    vi = "Tro núi lửa";
                    break;
                case 771:
                    vi = "Cơn giông";
                    break;
                case 781:
                    vi = "Cơn lốc xoáy";
                    break;

                case 800:
                    vi = "Bầu trời trong xanh";
                    break;
                case 801:
                    vi = "Ít mây: 11-25%";
                    break;
                case 802:
                    vi = "Mây rải rác: 25-50%";
                    break;
                case 803:
                    vi = "Mây vỡ: 51-84%";
                    break;
                case 804:
                    vi = "Mây u ám: 85-100%";
                    break;

                default:
                    vi = code.ToString();
                    break;
            }
            return vi;
        }
        public static string WindWarning(double? speedWind)
        {
            if (speedWind >= 0 && speedWind <= 5.4) // Cấp 0-3
            {
                return "- Gió nhẹ. Không gây nguy hại.";
            }
            else if (speedWind >= 5.5 && speedWind <= 10.7) // Cấp 4-5
            {
                return "- Cây nhỏ có lá bắt đầu lay động, ảnh hưởng đến lúa đang phơi màu. Biển hơi động. Thuyền đánh cá bị chao nghiêng, phải cuốn bớt buồm.";
            }
            else if (speedWind >= 10.8 && speedWind <= 17.1)    // Cấp 6-7
            {
                return "- Cây cối rung chuyển. Khó đi ngược gió. Biển động. Nguy hiểm đối với tàu, thuyền.";
            }
            else if (speedWind >= 17.2 && speedWind <= 24.4)    // Cấp 8-9
            {
                return "- Gió làm gãy cành cây, tốc mái nhà gây thiệt hại về nhà cửa. Không thể đi ngược gió. Biển động rất mạnh. Rất nguy hiểm đối với tàu, thuyền.";
            }
            else if (speedWind >= 24.5 && speedWind <= 32.6)    // Cấp 10-11
            {
                return "- Làm đổ cây cối, nhà cửa, cột điện. Gây thiệt hại rất nặng. Biển động dữ dội. Làm đắm tàu biển.";
            }
            else if (speedWind >= 32.7 && speedWind <= 61.2)    // Cấp 12-17
            {
                return "- Sức phá hoại cực kỳ lớn. Sóng biển cực kỳ mạnh. Đánh đắm tàu biển có trọng tải lớn.";
            }
            else
            {
                return "Không xác định được.";
            }
        }
        public static string TemperatureWarning(double? temperature)
        {
            if (temperature == null)
            {
                return "- Không có dữ liệu về nhiệt độ.";
            }

            if (temperature < 0)
            {
                return "- Cảnh báo: Nhiệt độ quá thấp! Cần phải giữ ấm nghiêm ngặt.";
            }
            else if (temperature >= 0 && temperature < 10)
            {
                return "- Nhiệt độ lạnh. Hãy mặc ấm và hạn chế ra ngoài.";
            }
            else if (temperature >= 10 && temperature < 18)
            {
                return "- Nhiệt độ lạnh. Hãy mặc đủ ấm.";
            }
            else if (temperature >= 18 && temperature < 25)
            {
                return "- Nhiệt độ dễ chịu. Có thể ra ngoài.";
            }
            else if (temperature >= 25 && temperature < 30)
            {
                return "- Nhiệt độ ấm áp, hãy uống đủ nước.";
            }
            else if (temperature >= 30 && temperature < 40)
            {
                return "- Cảnh báo: Nhiệt độ cao. Hãy ở trong nhà và uống nhiều nước.";
            }
            else
            {
                return "- Cảnh báo nguy hiểm: Nhiệt độ quá cao! Tránh ra ngoài và tìm nơi mát mẻ ngay lập tức.";
            }
        }

        private static readonly Dictionary<string, string> translations = new Dictionary<string, string>
        {
            { "sunny", "Nắng" },
            { "clear", "Trong lành" },
            { "partly cloudy", "Ít mây" },
            { "cloudy", "Nhiều mây" },
            { "overcast", "U ám" },
            { "mist", "Sương mù" },
            { "patchy rain possible", "Có thể mưa rải rác" },
            { "patchy snow possible", "Có thể có tuyết rải rác" },
            { "patchy sleet possible", "Có thể có mưa tuyết rải rác" },
            { "patchy freezing drizzle possible", "Có thể có mưa phùn đóng băng rải rác" },
            { "thundery outbreaks possible", "Có thể có giông" },
            { "blowing snow", "Gió và tuyết" },
            { "blizzard", "Bão tuyết" },
            { "fog", "Sương mù" },
            { "freezing fog", "Sương mù đóng băng" },
            { "patchy light drizzle", "Có mưa phùn nhẹ rải rác" },
            { "light drizzle", "Mưa phùn nhẹ" },
            { "freezing drizzle", "Mưa phùn đóng băng" },
            { "heavy freezing drizzle", "Mưa phùn đóng băng nặng" },
            { "patchy light rain", "Có mưa nhẹ rải rác" },
            { "light rain", "Mưa nhẹ" },
            { "moderate rain at times", "Mưa vừa thỉnh thoảng" },
            { "moderate rain", "Mưa vừa" },
            { "heavy rain at times", "Mưa to thỉnh thoảng" },
            { "heavy rain", "Mưa to" },
            { "light freezing rain", "Mưa lạnh nhẹ" },
            { "moderate or heavy freezing rain", "Mưa lạnh vừa hoặc nặng" },
            { "light sleet", "Mưa tuyết nhẹ" },
            { "moderate or heavy sleet", "Mưa tuyết vừa hoặc nặng" },
            { "patchy light snow", "Có tuyết nhẹ rải rác" },
            { "light snow", "Tuyết nhẹ" },
            { "patchy moderate snow", "Tuyết vừa rải rác" },
            { "moderate snow", "Tuyết vừa" },
            { "patchy heavy snow", "Tuyết dày rải rác" },
            { "heavy snow", "Tuyết dày" },
            { "ice pellets", "Mưa đá" },
            { "light rain shower", "Mưa rào nhẹ" },
            { "moderate or heavy rain shower", "Mưa rào vừa hoặc nặng" },
            { "torrential rain shower", "Mưa như trút nước" },
            { "light sleet showers", "Mưa tuyết rào nhẹ" },
            { "moderate or heavy sleet showers", "Mưa tuyết rào vừa hoặc nặng" },
            { "light snow showers", "Tuyết rào nhẹ" },
            { "moderate or heavy snow showers", "Tuyết rào vừa hoặc nặng" },
            { "light showers of ice pellets", "Mưa đá nhẹ" },
            { "moderate or heavy showers of ice pellets", "Mưa đá vừa hoặc nặng" },
            { "patchy light rain with thunder", "Mưa nhẹ kèm giông rải rác" },
            { "moderate or heavy rain with thunder", "Mưa vừa hoặc nặng kèm giông" },
            { "patchy light snow with thunder", "Tuyết nhẹ kèm giông rải rác" },
            { "moderate or heavy snow with thunder", "Tuyết vừa hoặc nặng kèm giông" }
        };

        // Hàm chuyển đổi từ tiếng Anh sang tiếng Việt
        public static string ConvertWeatherApi(string en)
        {
            if (translations.ContainsKey(en))
            {
                return translations[en];
            }
            return "Không xác định";
        }

        public static ObservableCollection<Agriculture> NongNghiep(string location, int? tm, int? tx, int? humidity)
        {
            ObservableCollection<Agriculture> agricultures = new();
            string s = string.Empty;

            switch (location)
            {
                case "Phan Rang":
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: NHO", Content = NongNghiep_Nho(tm, tx, humidity).Trim() });
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: MĂNG TÂY", Content = NongNghiep_MangTay(tm, tx, humidity).Trim() });
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: LÚA", Content = NongNghiep_Lua(tm, tx, humidity).Trim() });
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: TÁO", Content = NongNghiep_Tao(tm, tx, humidity).Trim() });
                    break;
                case "Ninh Hải":
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: NHO", Content = NongNghiep_Nho(tm, tx, humidity).Trim() });
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: MĂNG TÂY", Content = NongNghiep_MangTay(tm, tx, humidity).Trim() });
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: LÚA", Content = NongNghiep_Lua(tm, tx, humidity).Trim() });
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: HÀNH TÍM", Content = NongNghiep_HanhTim(tm, tx, humidity).Trim() });
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: TÁO", Content = NongNghiep_Tao(tm, tx, humidity).Trim() });
                    break;
                case "Thuận Bắc":
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: MĂNG TÂY", Content = NongNghiep_MangTay(tm, tx, humidity).Trim() });
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: LÚA", Content = NongNghiep_Lua(tm, tx, humidity).Trim() });
                    break;
                case "Ninh Phước":
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: NHO", Content = NongNghiep_Nho(tm, tx, humidity).Trim() });
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: MĂNG TÂY", Content = NongNghiep_MangTay(tm, tx, humidity).Trim() });
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: LÚA", Content = NongNghiep_Lua(tm, tx, humidity).Trim() });
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: NGÔ", Content = NongNghiep_Ngo(tm, tx, humidity).Trim() });
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: TÁO", Content = NongNghiep_Tao(tm, tx, humidity).Trim() });
                    break;
                case "Thuận Nam":
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: LÚA", Content = NongNghiep_Lua(tm, tx, humidity).Trim() });
                    break;
                case "Ninh Sơn":
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: NHO", Content = NongNghiep_Nho(tm, tx, humidity).Trim() });
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: TÁO", Content = NongNghiep_Tao(tm, tx, humidity).Trim() });
                    break;
                case "Bác Ái":
                    agricultures.Add(new Agriculture() { Title = "CÂY TRỒNG: LÚA", Content = NongNghiep_Lua(tm, tx, humidity).Trim() });
                    break;
                default:
                    agricultures = new();
                    break;
            }
            return agricultures;
        }

        private static string NongNghiep_Nho(int? tm, int? tx, int? humidity)
        {
            string s = string.Empty;
            if (tm != null)
            {
                if (tm < 27)
                {
                    s += $"NHIỆT ĐỘ thấp nhất là {tm}°C dưới mức 27°C:\n";
                    s += "- Nho không chịu được nhiệt độ thấp. Khi nhiệt độ giảm dưới 27°C, cần tăng cường biện pháp bảo vệ như sử dụng lưới che hoặc phủ bạt để giữ nhiệt và tránh thiệt hại do sương giá.\r\n- Tưới nước vào buổi sáng sớm để giữ ấm cho đất và cây.\r\n";
                }
                else if (tm >= 27 && tm <= 30)
                {
                    s += $"NHIỆT ĐỘ thấp nhất là {tm}°C: Phù hợp với cây trồng.\n";
                }
            }

            if (tx != null)
            {
                if (tx > 30)
                {
                    s += $"NHIỆT ĐỘ cao nhất là {tx}°C trên mức 30°C:\n";
                    s += "- Dùng lưới che nắng hoặc các biện pháp che phủ khác để bảo vệ cây khỏi nhiệt độ cao.\r\n- Tăng cường tưới nước vào sáng sớm và chiều tối, đồng thời sử dụng hệ thống phun sương để làm mát cây.\r\n";
                }
                else if (tx >= 27 && tx <= 30)
                {
                    s += $"NHIỆT ĐỘ cao nhất là {tx}°C: Phù hợp với cây trồng.\n";
                }
            }

            if (humidity != null && humidity < 70)
            {
                s += $"ĐỘ ẨM là {humidity}% dưới mức 70%:\n";
                s += "- Duy trì độ ẩm đất bằng hệ thống tưới nhỏ giọt hoặc phun sương, đặc biệt trong mùa khô hạn.\r\n";
            }
            else if (humidity != null && humidity > 80)
            {
                s += $"ĐỘ ẨM là {humidity}% trên mức 80%:\n";
                s += "- Kiểm soát độ ẩm bằng cách cải thiện hệ thống thoát nước, tránh tình trạng thối rễ do ngập úng.\r\n";
            }
            else if (humidity != null)
            {
                s += $"ĐỘ ẨM {humidity}% phù hợp với cây trồng. Từ 70-80 (%).";
            }

            return s;
        }

        private static string NongNghiep_Lua(int? tm, int? tx, int? humidity)
        {
            string s = string.Empty;
            if (tm != null)
            {
                if (tm < 20)
                {
                    s += $"NHIỆT ĐỘ thấp nhất là {tm}°C dưới mức 20°C:\n";
                    s += "- Lúa không phát triển tốt khi nhiệt độ dưới 20°C. Cần che phủ cây trong những ngày lạnh hoặc sử dụng màng phủ để bảo vệ cây khỏi nhiệt độ thấp.\r\n- Tưới nước vào buổi sáng để giúp cây tăng cường hấp thụ nhiệt từ mặt trời.\r\n";
                }
                else if (tm >= 20 && tm <= 30)
                {
                    s += $"NHIỆT ĐỘ thấp nhất là {tm}°C: Phù hợp với cây trồng.\n";
                }
            }

            if (tx != null)
            {
                if (tx > 30)
                {
                    s += $"NHIỆT ĐỘ cao nhất là {tx}°C trên mức 30°C:\n";
                    s += "- Điều chỉnh lịch tưới tiêu vào sáng sớm và chiều tối để giữ mát cho cây.\r\n- Sử dụng hệ thống phun sương để làm mát cây lúa và giảm stress nhiệt cho cây.\r\n";
                }
                else if (tx >= 20 && tx <= 30)
                {
                    s += $"NHIỆT ĐỘ cao nhất là {tx}°C: Phù hợp với cây trồng.\n";
                }
            }

            if (humidity != null && humidity < 70)
            {
                s += $"ĐỘ ẨM là {humidity}% dưới mức 70%:\n";
                s += "- Duy trì độ ẩm đất thông qua hệ thống tưới nhỏ giọt hoặc tưới phun sương.\r\n";
            }
            else if (humidity != null && humidity > 90)
            {
                s += $"ĐỘ ẨM là {humidity}% trên mức 90%:\n";
                s += "- Giảm lượng nước tưới và cải thiện hệ thống thoát nước, tránh tình trạng ngập úng.\r\n";
            }
            else if (humidity != null)
            {
                s += $"ĐỘ ẨM {humidity}% phù hợp với cây trồng. Từ 70-90 (%).";
            }

            return s;
        }

        private static string NongNghiep_MangTay(int? tm, int? tx, int? humidity)
        {
            string s = string.Empty;
            if (tm != null)
            {
                if (tm < 25)
                {
                    s += $"NHIỆT ĐỘ thấp nhất là {tm}°C dưới mức 25°C:\n";
                    s += "- Cần sử dụng màng phủ hoặc lưới che để bảo vệ măng tây khỏi những đợt lạnh đột ngột.\r\n- Tưới nước vào buổi sáng để giữ ấm cho cây.\r\n";
                }
                else if (tm >= 25 && tm <= 33)
                {
                    s += $"NHIỆT ĐỘ thấp nhất là {tm}°C: Phù hợp với cây trồng.\n";
                }
            }

            if (tx != null)
            {
                if (tx > 33)
                {
                    s += $"NHIỆT ĐỘ cao nhất là {tx}°C trên mức 33°C:\n";
                    s += "- Phun sương vào buổi trưa để giảm bớt nhiệt độ và làm mát cây.\r\n- Cần che phủ cây trong những ngày nắng nóng để giảm stress nhiệt.\r\n";
                }
                else if (tx >= 25 && tx <= 33)
                {
                    s += $"NHIỆT ĐỘ cao nhất là {tx}°C: Phù hợp với cây trồng.\n";
                }
            }

            if (humidity != null && humidity < 60)
            {
                s += $"ĐỘ ẨM là {humidity}% dưới mức 60%:\n";
                s += "- Sử dụng hệ thống tưới nhỏ giọt để duy trì độ ẩm cho đất.\r\n";
            }
            else if (humidity != null && humidity > 70)
            {
                s += $"ĐỘ ẨM là {humidity}% trên mức 70%:\n";
                s += "- Kiểm soát thoát nước để tránh ngập úng, cải thiện tình trạng thoát nước khi mưa nhiều.\r\n";
            }
            else if (humidity != null)
            {
                s += $"ĐỘ ẨM {humidity}% phù hợp với cây trồng. Từ 60-70 (%).";
            }

            return s;
        }

        private static string NongNghiep_HanhTim(int? tm, int? tx, int? humidity)
        {
            string s = string.Empty;
            if (tm != null)
            {
                if (tm < 15)
                {
                    s += $"NHIỆT ĐỘ thấp nhất là {tm}°C dưới mức 15°C:\n";
                    s += "- Sử dụng lưới che hoặc bạt phủ để bảo vệ hành tím khỏi nhiệt độ quá lạnh.\r\n- Áp dụng biện pháp che phủ hoặc chuyển cây vào khu vực ấm hơn trong những đợt lạnh.\r\n";
                }
                else if (tm >= 15 && tm <= 20)
                {
                    s += $"NHIỆT ĐỘ thấp nhất là {tm}°C: Phù hợp với cây trồng.\n";
                }
            }

            if (tx != null)
            {
                if (tx > 20)
                {
                    s += $"NHIỆT ĐỘ cao nhất là {tx}°C trên mức 20°C:\n";
                    s += "- Sử dụng biện pháp che phủ để bảo vệ hành tím khỏi ánh nắng trực tiếp.\r\n- Tăng cường tưới nước vào sáng sớm và chiều tối.\r\n";
                }
                else if (tx >= 15 && tx <= 20)
                {
                    s += $"NHIỆT ĐỘ cao nhất là {tx}°C: Phù hợp với cây trồng.\n";
                }
            }

            if (humidity != null && humidity < 80)
            {
                s += $"ĐỘ ẨM là {humidity}% dưới mức 80%:\n";
                s += "- Sử dụng hệ thống tưới nhỏ giọt để duy trì độ ẩm đất và cây hành.\r\n";
            }
            else if (humidity != null && humidity > 80)
            {
                s += $"ĐỘ ẨM là {humidity}% trên mức 70%:\n";
                s += "- Tăng cường thoát nước, cải thiện hệ thống tưới tiêu để giảm độ ẩm quá cao, tránh thối củ.";
            }
            else if (humidity != null)
            {
                s += $"ĐỘ ẨM {humidity}% phù hợp với cây trồng. Khoảng 80 (%).";
            }

            return s;
        }

        private static string NongNghiep_Ngo(int? tm, int? tx, int? humidity)
        {
            string s = string.Empty;
            if (tm != null)
            {
                if (tm < 25)
                {
                    s += $"NHIỆT ĐỘ thấp nhất là {tm}°C dưới mức 25°C:\n";
                    s += "- Ngô cần nhiệt độ tối thiểu là 25°C để phát triển tốt, do đó cần che phủ hoặc sử dụng màng phủ giữ nhiệt khi nhiệt độ quá thấp.\r\n";
                }
                else if (tm >= 25 && tm <= 30)
                {
                    s += $"NHIỆT ĐỘ thấp nhất là {tm}°C: Phù hợp với cây trồng.\n";
                }
            }

            if (tx != null)
            {
                if (tx > 30)
                {
                    s += $"NHIỆT ĐỘ cao nhất là {tx}°C trên mức 30°C:\n";
                    s += "- Tăng cường tưới nước vào sáng sớm và chiều tối, sử dụng phun sương để làm mát cây ngô.\r\n- Sử dụng lưới che nắng để bảo vệ cây ngô khỏi nhiệt độ cao.\r\n";
                }
                else if (tx >= 25 && tx <= 30)
                {
                    s += $"NHIỆT ĐỘ cao nhất là {tx}°C: Phù hợp với cây trồng.\n";
                }
            }

            if (humidity != null && humidity < 75)
            {
                s += $"ĐỘ ẨM là {humidity}% dưới mức 75%:\n";
                s += "- Duy trì độ ẩm cho đất bằng cách tưới tiêu thường xuyên, sử dụng hệ thống tưới nhỏ giọt hoặc tưới phun.\r\n";
            }
            else if (humidity != null && humidity > 80)
            {
                s += $"ĐỘ ẨM là {humidity}% trên mức 80%:\n";
                s += "- Điều chỉnh lượng nước tưới và cải thiện hệ thống thoát nước để tránh ngập úng.\r\n";
            }
            else if (humidity != null)
            {
                s += $"ĐỘ ẨM {humidity}% phù hợp với cây trồng. Từ 70-80 (%).";
            }

            return s;
        }

        private static string NongNghiep_Tao(int? tm, int? tx, int? humidity)
        {
            string s = string.Empty;
            if (tm != null)
            {
                if (tm < 25)
                {
                    s += $"NHIỆT ĐỘ thấp nhất là {tm}°C dưới mức 25°C:\n";
                    s += "- Che phủ đất bằng rơm hoặc màng phủ để giữ ấm gốc cây.\r\n- Sử dụng nguồn nước ấm để tưới hoặc lắp đặt hệ thống sưởi nhỏ trong vườn.\r\n";
                }
                else if (tm >= 25 && tm <= 32)
                {
                    s += $"NHIỆT ĐỘ thấp nhất là {tm}°C: Phù hợp với cây trồng.\n";
                }
            }

            if (tx != null)
            {
                if (tx > 32)
                {
                    s += $"NHIỆT ĐỘ cao nhất là {tx}°C trên mức 32°C:\n";
                    s += "- Áp dụng hệ thống phun sương để giảm nhiệt độ môi trường.\r\n- Che phủ cây bằng lưới cắt nắng để hạn chế tác động từ bức xạ mặt trời.\r\n";
                }
                else if (tx >= 25 && tx <= 32)
                {
                    s += $"NHIỆT ĐỘ cao nhất là {tx}°C: Phù hợp với cây trồng.\n";
                }
            }

            if (humidity != null && humidity < 70)
            {
                s += $"ĐỘ ẨM là {humidity}% dưới mức 70%:\n";
                s += "- Tăng cường tưới nước vào sáng sớm hoặc chiều mát.\r\n- Sử dụng lớp phủ hữu cơ quanh gốc cây để giữ độ ẩm.\r\n";
            }
            else if (humidity != null && humidity > 80)
            {
                s += $"ĐỘ ẨM là {humidity}% trên mức 80%:\n";
                s += "- Tỉa bớt lá để tạo sự thông thoáng, giảm độ ẩm trong tán cây.\r\n- Phun thuốc bảo vệ thực vật sinh học để ngăn ngừa nấm mốc.\r\n";
            }
            else if (humidity != null)
            {
                s += $"ĐỘ ẨM {humidity}% phù hợp với cây trồng. Từ 70-80 (%).";
            }

            return s;
        }
    }
}
