using System.Text.Json;
using System.Text.Json.Serialization;
using RentalApp.Shared.Models.Equipment;
using RentalApp.Shared.Models.Equipment.Skates;

namespace RentalApp.Shared.Converters;

public class SportsEquipmentConverter : JsonConverter<SportsEquipment>
{
    private const string IdPropertyName = "Id";
    private const string SizePropertyName = "Size";
    private const string PurposePropertyName = "Purpose";
    private const string IsFunctionalPropertyName = "IsFunctional";
    private const string HourlyFeePropertyName = "HourlyFee";
    private const string DiscriminatorPropertyName = "Discriminator";
    private const string BladeMaterialPropertyName = "BladeMaterial";
    private const string HasToePickPropertyName = "HasToePick";
    private const string WheelDiameterPropertyName = "WheelDiameter";
    private const string BearingTypePropertyName = "BearingType";
    private const string WheelHardnessPropertyName = "WheelHardness";

    public override SportsEquipment? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonObject = jsonDocument.RootElement.Clone();

        // Retrieve the naming policy from options
        var namingPolicy = options.PropertyNamingPolicy;

        // Map the property name to match the naming policy
        // In case of null namingPolicy the default is PascalCase as per language standard
        var discriminatorName = "Discriminator";
        if (namingPolicy != null)
            discriminatorName = namingPolicy.ConvertName(discriminatorName);
        else if (options.PropertyNameCaseInsensitive)
            // If case insensitive assume camelCase
            discriminatorName = JsonNamingPolicy.CamelCase.ConvertName(discriminatorName);

        var discriminator = jsonObject.GetProperty(discriminatorName).GetString();

        SportsEquipment? result = discriminator switch
        {
            "IceSkates" => JsonSerializer.Deserialize<IceSkates>(jsonObject.GetRawText(), options),
            "InlineSkates" => JsonSerializer.Deserialize<InlineSkates>(jsonObject.GetRawText(), options),
            "RollerSkates" => JsonSerializer.Deserialize<RollerSkates>(jsonObject.GetRawText(), options),
            _ => throw new ArgumentException($"Invalid discriminator value: {discriminator}")
        };

        return result;
    }

    public override void Write(Utf8JsonWriter writer, SportsEquipment value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        var namingPolicy = options.PropertyNamingPolicy;

        writer.WriteNumber(namingPolicy?.ConvertName(IdPropertyName) ?? IdPropertyName, value.Id);
        writer.WriteNumber(namingPolicy?.ConvertName(SizePropertyName) ?? SizePropertyName, value.Size);
        writer.WriteString(namingPolicy?.ConvertName(PurposePropertyName) ?? PurposePropertyName, value.Purpose);
        writer.WriteBoolean(namingPolicy?.ConvertName(IsFunctionalPropertyName) ?? IsFunctionalPropertyName,
            value.IsFunctional);
        writer.WriteNumber(namingPolicy?.ConvertName(HourlyFeePropertyName) ?? HourlyFeePropertyName, value.HourlyFee);

        switch (value)
        {
            case IceSkates iceSkates:
                writer.WriteString(namingPolicy?.ConvertName(DiscriminatorPropertyName) ?? DiscriminatorPropertyName,
                    "IceSkates");
                writer.WriteString(namingPolicy?.ConvertName(BladeMaterialPropertyName) ?? BladeMaterialPropertyName,
                    iceSkates.BladeMaterial);
                writer.WriteBoolean(namingPolicy?.ConvertName(HasToePickPropertyName) ?? HasToePickPropertyName,
                    iceSkates.HasToePick);
                break;
            case InlineSkates inlineSkates:
                writer.WriteString(namingPolicy?.ConvertName(DiscriminatorPropertyName) ?? DiscriminatorPropertyName,
                    "InlineSkates");
                writer.WriteNumber(namingPolicy?.ConvertName(WheelDiameterPropertyName) ?? WheelDiameterPropertyName,
                    inlineSkates.WheelDiameter);
                writer.WriteString(namingPolicy?.ConvertName(BearingTypePropertyName) ?? BearingTypePropertyName,
                    inlineSkates.BearingType);
                break;
            case RollerSkates rollerSkates:
                writer.WriteString(namingPolicy?.ConvertName(DiscriminatorPropertyName) ?? DiscriminatorPropertyName,
                    "RollerSkates");
                writer.WriteNumber(namingPolicy?.ConvertName(WheelHardnessPropertyName) ?? WheelHardnessPropertyName,
                    rollerSkates.WheelHardness);
                break;
            default:
                throw new ArgumentException($"Invalid type: {value.GetType().Name}");
        }

        writer.WriteEndObject();
    }
}