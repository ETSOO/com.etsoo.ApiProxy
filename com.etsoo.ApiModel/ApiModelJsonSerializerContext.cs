using com.etsoo.ApiModel.Dto.Maps;
using System.Text.Json.Serialization;

namespace com.etsoo.ApiModel
{
    [JsonSourceGenerationOptions(
        PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase,
        DictionaryKeyPolicy = JsonKnownNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    )]

    [JsonSerializable(typeof(IEnumerable<PlaceAutocomplete>))]
    [JsonSerializable(typeof(PlaceBase))]
    [JsonSerializable(typeof(Dto.Recaptcha.SiteVerifyDto))]

    [JsonSerializable(typeof(Dto.SmartERP.MessageQueue.SendEmailMessage))]
    [JsonSerializable(typeof(Dto.SmartERP.MessageQueue.SendSMSMessage))]
    [JsonSerializable(typeof(Dto.SmartERP.ChinaPinData))]

    [JsonSerializable(typeof(RQ.Maps.PlaceQueryRQ))]
    [JsonSerializable(typeof(RQ.Recaptcha.SiteVerifyRQ))]

    [JsonSerializable(typeof(RQ.SmartERP.BarcodeSimpleOptions))]
    [JsonSerializable(typeof(RQ.SmartERP.PinyinRQ))]
    [JsonSerializable(typeof(RQ.SmartERP.TimestampKeyRQ))]
    [JsonSerializable(typeof(RQ.SmartERP.TokenAuthRQ))]

    [JsonSerializable(typeof(IEnumerable<PlaceCommon>))]
    public partial class ApiModelJsonSerializerContext : JsonSerializerContext
    {
    }
}