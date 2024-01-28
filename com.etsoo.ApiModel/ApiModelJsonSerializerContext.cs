using System.Text.Json.Serialization;

namespace com.etsoo.ApiModel
{
    [JsonSerializable(typeof(Dto.Maps.Location))]
    [JsonSerializable(typeof(Dto.Maps.PlaceAutocomplete))]
    [JsonSerializable(typeof(Dto.Maps.PlaceBase))]
    [JsonSerializable(typeof(Dto.Maps.PlaceCommon))]
    [JsonSerializable(typeof(Dto.Recaptcha.SiteVerifyDto))]
    [JsonSerializable(typeof(Dto.SmartERP.MessageQueue.ApiServiceKey))]
    [JsonSerializable(typeof(Dto.SmartERP.MessageQueue.MessageImportance))]
    [JsonSerializable(typeof(Dto.SmartERP.MessageQueue.MessagePriority))]
    [JsonSerializable(typeof(Dto.SmartERP.MessageQueue.OperationMessageDto))]
    [JsonSerializable(typeof(Dto.SmartERP.MessageQueue.OperationMessageResponse))]
    [JsonSerializable(typeof(Dto.SmartERP.MessageQueue.SendEmailDto))]
    [JsonSerializable(typeof(Dto.SmartERP.AddressCityDto))]
    [JsonSerializable(typeof(Dto.SmartERP.AddressDistrictDto))]
    [JsonSerializable(typeof(Dto.SmartERP.AddressRegionDto))]
    [JsonSerializable(typeof(Dto.SmartERP.AddressStateDto))]
    [JsonSerializable(typeof(Dto.SmartERP.ApiServiceEnum))]
    [JsonSerializable(typeof(Dto.SmartERP.ContactInfoDto))]
    [JsonSerializable(typeof(Dto.SmartERP.CurrencyDto))]
    [JsonSerializable(typeof(Dto.SmartERP.ExchangeRateDto))]
    [JsonSerializable(typeof(Dto.SmartERP.GetAddressNumDto))]
    [JsonSerializable(typeof(Dto.SmartERP.ListItem))]
    [JsonSerializable(typeof(Dto.SmartERP.ListItem1))]
    [JsonSerializable(typeof(Dto.SmartERP.ParsedPlaceDto))]
    [JsonSerializable(typeof(Dto.SmartERP.PinDto))]

    [JsonSerializable(typeof(RQ.Maps.ApiOutput))]
    [JsonSerializable(typeof(RQ.Maps.ApiProvider))]
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
    public partial class ApiModelJsonSerializerContext : JsonSerializerContext
    {
    }
}