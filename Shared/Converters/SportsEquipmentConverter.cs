using System.Text.Json;
using System.Text.Json.Serialization;
using RentalApp.Shared.Models.Equipment;
using RentalApp.Shared.Models.Equipment.Skates;

namespace RentalApp.Shared.Converters;

public class SportsEquipmentConverter : JsonConverter<SportsEquipment>
{
    public override SportsEquipment? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var jsonDocument = JsonDocument.ParseValue(ref reader);
        var jsonObject = jsonDocument.RootElement.Clone();
        var discriminator = jsonObject.GetProperty("Discriminator").GetString();

        SportsEquipment? result = discriminator switch
        {
            "IceSkates" => JsonSerializer.Deserialize<IceSkates>(jsonObject.GetRawText()),
            "InlineSkates" => JsonSerializer.Deserialize<InlineSkates>(jsonObject.GetRawText()),
            "RollerSkates" => JsonSerializer.Deserialize<RollerSkates>(jsonObject.GetRawText()),
            _ => throw new ArgumentException($"Invalid discriminator value: {discriminator}")
        };

        return result;
    }


    public override void Write(Utf8JsonWriter writer, SportsEquipment value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteNumber("Id", value.Id);
        writer.WriteNumber("Size", value.Size);
        writer.WriteString("Purpose", value.Purpose);
        writer.WriteBoolean("IsFunctional", value.IsFunctional);
        writer.WriteNumber("HourlyFee", value.HourlyFee);

        switch (value)
        {
            case IceSkates iceSkates:
                writer.WriteString("Discriminator", "IceSkates");
                writer.WriteString("BladeMaterial", iceSkates.BladeMaterial);
                writer.WriteBoolean("HasToePick", iceSkates.HasToePick);
                break;
            case InlineSkates inlineSkates:
                writer.WriteString("Discriminator", "InlineSkates");
                writer.WriteNumber("WheelDiameter", inlineSkates.WheelDiameter);
                writer.WriteString("BearingType", inlineSkates.BearingType);
                break;
            case RollerSkates rollerSkates:
                writer.WriteString("Discriminator", "RollerSkates");
                writer.WriteNumber("WheelHardness", rollerSkates.WheelHardness);
                break;
            default:
                throw new ArgumentException($"Invalid type: {value.GetType().Name}");
        }

        writer.WriteEndObject();
    }
}