using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace TelegramApps.Blazor.Models;

public class WebAppInitData
{
    [JsonPropertyName("query_id")]
    public string? QueryId { get; set; }

    [JsonPropertyName("user")]
    public WebAppUser? User { get; set; }

    [JsonPropertyName("receiver")]
    public WebAppUser? Receiver { get; set; }

    [JsonPropertyName("chat")]
    public WebAppChat? Chat { get; set; }

    [JsonPropertyName("chat_type")]
    public string? ChatType { get; set; }

    [JsonPropertyName("chat_instance")]
    public string? ChatInstance { get; set; }

    [JsonPropertyName("start_param")]
    public string? StartParam { get; set; }

    [JsonPropertyName("can_send_after")]
    public int? CanSendAfter { get; set; }

    [JsonPropertyName("auth_date")]
    public string AuthDate { get; set; } = string.Empty;

    [JsonPropertyName("hash")]
    public string Hash { get; set; } = string.Empty;

    public override string ToString()
    {
        var sb = new StringBuilder();

        void AppendParam(string name, string? value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (sb.Length > 0) sb.Append("&");
                sb.Append($"{name}={HttpUtility.UrlEncode(value)}");
            }
        }

        if (User != null)
        {
            string json = JsonSerializer.Serialize(User);
            AppendParam("user", json);
        }

        if (Receiver != null)
        {
            string json = JsonSerializer.Serialize(Receiver);
            AppendParam("receiver", json);
        }

        if (Chat != null)
        {
            string json = JsonSerializer.Serialize(Chat);
            AppendParam("chat", json);
        }

        AppendParam("chat_type", ChatType);
        AppendParam("chat_instance", ChatInstance);
        AppendParam("start_param", StartParam);
        AppendParam("auth_date", AuthDate);
        AppendParam("hash", Hash);

        return sb.ToString();
    }
}

public class WebAppUser
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("is_bot")]
    public bool? IsBot { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("language_code")]
    public string? LanguageCode { get; set; }

    [JsonPropertyName("is_premium")]
    public bool? IsPremium { get; set; }

    [JsonPropertyName("photo_url")]
    public string? PhotoUrl { get; set; }
}

public class WebAppChat
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("username")]
    public string? Username { get; set; }

    [JsonPropertyName("photo_url")]
    public string? PhotoUrl { get; set; }
}

public class ThemeParams
{
    [JsonPropertyName("bg_color")]
    public string? BackgroundColor { get; set; }

    [JsonPropertyName("text_color")]
    public string? TextColor { get; set; }

    [JsonPropertyName("hint_color")]
    public string? HintColor { get; set; }

    [JsonPropertyName("link_color")]
    public string? LinkColor { get; set; }

    [JsonPropertyName("button_color")]
    public string? ButtonColor { get; set; }

    [JsonPropertyName("button_text_color")]
    public string? ButtonTextColor { get; set; }

    [JsonPropertyName("secondary_bg_color")]
    public string? SecondaryBackgroundColor { get; set; }

    [JsonPropertyName("header_bg_color")]
    public string? HeaderBackgroundColor { get; set; }

    [JsonPropertyName("accent_text_color")]
    public string? AccentTextColor { get; set; }

    [JsonPropertyName("section_bg_color")]
    public string? SectionBackgroundColor { get; set; }

    [JsonPropertyName("section_header_text_color")]
    public string? SectionHeaderTextColor { get; set; }

    [JsonPropertyName("subtitle_text_color")]
    public string? SubtitleTextColor { get; set; }

    [JsonPropertyName("destructive_text_color")]
    public string? DestructiveTextColor { get; set; }
}

public class SafeAreaInset
{
    [JsonPropertyName("top")]
    public int Top { get; set; }

    [JsonPropertyName("bottom")]
    public int Bottom { get; set; }

    [JsonPropertyName("left")]
    public int Left { get; set; }

    [JsonPropertyName("right")]
    public int Right { get; set; }
}

public class ContentSafeAreaInset
{
    [JsonPropertyName("top")]
    public int Top { get; set; }

    [JsonPropertyName("bottom")]
    public int Bottom { get; set; }

    [JsonPropertyName("left")]
    public int Left { get; set; }

    [JsonPropertyName("right")]
    public int Right { get; set; }
}

public class PopupParams
{
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; } = string.Empty;

    [JsonPropertyName("buttons")]
    public PopupButton[]? Buttons { get; set; }
}

public class PopupButton
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("text")]
    public string? Text { get; set; }
}

public class ScanQrPopupParams
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }
}

public class LocationData
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }
}

public class ContactData
{
    [JsonPropertyName("contact")]
    public PhoneContact Contact { get; set; } = new();
}

public class PhoneContact
{
    [JsonPropertyName("phone_number")]
    public string PhoneNumber { get; set; } = string.Empty;

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("last_name")]
    public string? LastName { get; set; }

    [JsonPropertyName("user_id")]
    public long? UserId { get; set; }
}

public class BiometricRequestAccessParams
{
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }
}

public class BiometricAuthenticateParams
{
    [JsonPropertyName("reason")]
    public string? Reason { get; set; }
}