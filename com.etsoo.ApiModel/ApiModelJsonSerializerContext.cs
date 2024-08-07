﻿using com.etsoo.ApiModel.Dto.Maps;
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
    [JsonSerializable(typeof(Dto.SmartERP.MessageQueue.ApiServiceKey))]
    [JsonSerializable(typeof(Dto.SmartERP.MessageQueue.OperationMessageResponse))]
    [JsonSerializable(typeof(Dto.SmartERP.MessageQueue.SendEmailDto))]
    [JsonSerializable(typeof(IEnumerable<Dto.SmartERP.AddressCityDto>))]
    [JsonSerializable(typeof(IEnumerable<Dto.SmartERP.AddressDistrictDto>))]
    [JsonSerializable(typeof(IEnumerable<Dto.SmartERP.AddressRegionDto>))]
    [JsonSerializable(typeof(IEnumerable<Dto.SmartERP.AddressStateDto>))]
    [JsonSerializable(typeof(Dto.SmartERP.ContactInfoDto))]
    [JsonSerializable(typeof(IEnumerable<Dto.SmartERP.ExchangeRateDto>))]
    [JsonSerializable(typeof(IEnumerable<Dto.SmartERP.CurrencyDto>))]
    [JsonSerializable(typeof(Dto.SmartERP.GetAddressNumDto))]
    [JsonSerializable(typeof(IEnumerable<Dto.SmartERP.ListItem>))]
    [JsonSerializable(typeof(IEnumerable<Dto.SmartERP.ListItem1>))]
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