using com.etsoo.ApiModel.Dto.Maps;
using System.Text.Json.Serialization;

namespace com.etsoo.ApiModel
{
    [JsonSourceGenerationOptions(PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, DictionaryKeyPolicy = JsonKnownNamingPolicy.CamelCase, PropertyNameCaseInsensitive = true)]

    [JsonSerializable(typeof(Dto.Maps.PlaceAutocomplete))]
    [JsonSerializable(typeof(Dto.Maps.PlaceBase))]
    [JsonSerializable(typeof(Dto.Recaptcha.SiteVerifyDto))]
    [JsonSerializable(typeof(Dto.SmartERP.MessageQueue.ApiServiceKey))]
    [JsonSerializable(typeof(Dto.SmartERP.MessageQueue.OperationMessageResponse))]
    [JsonSerializable(typeof(Dto.SmartERP.MessageQueue.SendEmailDto))]
    [JsonSerializable(typeof(Dto.SmartERP.AddressCityDto))]
    [JsonSerializable(typeof(Dto.SmartERP.AddressDistrictDto))]
    [JsonSerializable(typeof(Dto.SmartERP.AddressRegionDto))]
    [JsonSerializable(typeof(Dto.SmartERP.AddressStateDto))]
    [JsonSerializable(typeof(Dto.SmartERP.ContactInfoDto))]
    [JsonSerializable(typeof(Dto.SmartERP.ExchangeRateDto))]
    [JsonSerializable(typeof(Dto.SmartERP.GetAddressNumDto))]
    [JsonSerializable(typeof(Dto.SmartERP.ListItem))]
    [JsonSerializable(typeof(Dto.SmartERP.ListItem1))]
    [JsonSerializable(typeof(Dto.SmartERP.ParsedPlaceDto))]

    [JsonSerializable(typeof(RQ.Maps.PlaceQueryRQ))]
    [JsonSerializable(typeof(RQ.Recaptcha.SiteVerifyRQ))]
    [JsonSerializable(typeof(RQ.SmartERP.ApiServiceRQ))]
    [JsonSerializable(typeof(RQ.SmartERP.AuthorizeApiServicesRQ))]
    [JsonSerializable(typeof(RQ.SmartERP.CityListRQ))]
    [JsonSerializable(typeof(RQ.SmartERP.DistrictListRQ))]
    [JsonSerializable(typeof(RQ.SmartERP.ParsePinRQ))]
    [JsonSerializable(typeof(RQ.SmartERP.ParsePlaceRQ))]
    [JsonSerializable(typeof(RQ.SmartERP.QRCodeOptions))]
    [JsonSerializable(typeof(RQ.SmartERP.StateListRQ))]

    [JsonSerializable(typeof(IEnumerable<PlaceCommon>))]
    public partial class ApiModelJsonSerializerContext : JsonSerializerContext
    {
    }
}