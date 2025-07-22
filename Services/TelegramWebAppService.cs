using Microsoft.JSInterop;
using System.Text.Json;
using TelegramApps.Blazor.Models;

namespace TelegramApps.Blazor.Services;

public class TelegramWebAppService : ITelegramWebAppService, IAsyncDisposable
{
    private readonly IJSRuntime _jsRuntime;
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public TelegramWebAppService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
        _moduleTask = new(() => LoadModuleAsync().AsTask());
    }

    private async ValueTask<IJSObjectReference> LoadModuleAsync()
    {
        return await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Telegram-Apps.Blazor/js/telegram-interop.js");
    }

    // Core WebApp properties
    public async Task<bool> IsAvailableAsync()
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<bool>("isWebAppAvailable");
    }

    public async Task<string> GetVersionAsync()
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<string>("getVersion");
    }

    public async Task<string> GetPlatformAsync()
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<string>("getPlatform");
    }

    public async Task<string> GetColorSchemeAsync()
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<string>("getColorScheme");
    }

    public async Task<bool> IsExpandedAsync()
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<bool>("isExpanded");
    }

    public async Task<ThemeParams?> GetThemeParamsAsync()
    {
        var module = await _moduleTask.Value;
        var json = await module.InvokeAsync<string>("getThemeParams");
        return string.IsNullOrEmpty(json) ? null : JsonSerializer.Deserialize<ThemeParams>(json);
    }

    public async Task<WebAppInitData?> GetInitDataAsync()
    {
        var module = await _moduleTask.Value;
        var json = await module.InvokeAsync<string>("getInitData");
        return string.IsNullOrEmpty(json) ? null : JsonSerializer.Deserialize<WebAppInitData>(json);
    }

    public async Task<string> GetRawInitDataAsync()
    {
        var module = await _moduleTask.Value;
        var json = await module.InvokeAsync<string>("getRawInitData");
        return json;
    }

    public async Task<SafeAreaInset?> GetSafeAreaInsetAsync()
    {
        var module = await _moduleTask.Value;
        var json = await module.InvokeAsync<string>("getSafeAreaInset");
        return string.IsNullOrEmpty(json) ? null : JsonSerializer.Deserialize<SafeAreaInset>(json);
    }

    public async Task<ContentSafeAreaInset?> GetContentSafeAreaInsetAsync()
    {
        var module = await _moduleTask.Value;
        var json = await module.InvokeAsync<string>("getContentSafeAreaInset");
        return string.IsNullOrEmpty(json) ? null : JsonSerializer.Deserialize<ContentSafeAreaInset>(json);
    }

    // Core methods
    public async Task ReadyAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("ready");
    }

    public async Task ExpandAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("expand");
    }

    public async Task CloseAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("close");
    }

    public async Task SendDataAsync(string data)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("sendData", data);
    }

    // Navigation
    public async Task OpenLinkAsync(string url, bool tryInstantView = false)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("openLink", url, tryInstantView);
    }

    public async Task OpenTelegramLinkAsync(string url)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("openTelegramLink", url);
    }

    public async Task SwitchInlineQueryAsync(string query, string[]? chatTypes = null)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("switchInlineQuery", query, chatTypes);
    }

    // Main Button
    public async Task SetMainButtonTextAsync(string text)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setMainButtonText", text);
    }

    public async Task SetMainButtonColorAsync(string color)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setMainButtonColor", color);
    }

    public async Task SetMainButtonTextColorAsync(string color)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setMainButtonTextColor", color);
    }

    public async Task ShowMainButtonAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("showMainButton");
    }

    public async Task HideMainButtonAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("hideMainButton");
    }

    public async Task EnableMainButtonAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("enableMainButton");
    }

    public async Task DisableMainButtonAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("disableMainButton");
    }

    public async Task SetMainButtonProgressAsync(bool visible)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setMainButtonProgress", visible);
    }

    // Secondary Button
    public async Task SetSecondaryButtonTextAsync(string text)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setSecondaryButtonText", text);
    }

    public async Task SetSecondaryButtonColorAsync(string color)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setSecondaryButtonColor", color);
    }

    public async Task SetSecondaryButtonTextColorAsync(string color)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setSecondaryButtonTextColor", color);
    }

    public async Task SetSecondaryButtonPositionAsync(string position)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setSecondaryButtonPosition", position);
    }

    public async Task ShowSecondaryButtonAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("showSecondaryButton");
    }

    public async Task HideSecondaryButtonAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("hideSecondaryButton");
    }

    public async Task EnableSecondaryButtonAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("enableSecondaryButton");
    }

    public async Task DisableSecondaryButtonAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("disableSecondaryButton");
    }

    public async Task SetSecondaryButtonProgressAsync(bool visible)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setSecondaryButtonProgress", visible);
    }

    // Back Button
    public async Task ShowBackButtonAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("showBackButton");
    }

    public async Task HideBackButtonAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("hideBackButton");
    }

    // Settings Button
    public async Task ShowSettingsButtonAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("showSettingsButton");
    }

    public async Task HideSettingsButtonAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("hideSettingsButton");
    }

    // Header and background colors
    public async Task SetHeaderColorAsync(string color)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setHeaderColor", color);
    }

    public async Task SetBackgroundColorAsync(string color)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setBackgroundColor", color);
    }

    public async Task SetBottomBarColorAsync(string color)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setBottomBarColor", color);
    }

    // Popups
    public async Task ShowPopupAsync(PopupParams parameters)
    {
        var module = await _moduleTask.Value;
        var json = JsonSerializer.Serialize(parameters);
        await module.InvokeVoidAsync("showPopup", json);
    }

    public async Task ShowAlertAsync(string message)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("showAlert", message);
    }

    public async Task<bool> ShowConfirmAsync(string message)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<bool>("showConfirm", message);
    }

    public async Task<string?> ShowScanQrPopupAsync(ScanQrPopupParams? parameters = null)
    {
        var module = await _moduleTask.Value;
        var json = parameters != null ? JsonSerializer.Serialize(parameters) : null;
        return await module.InvokeAsync<string?>("showScanQrPopup", json);
    }

    // Haptic feedback
    public async Task ImpactOccurredAsync(string style)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("impactOccurred", style);
    }

    public async Task NotificationOccurredAsync(string type)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("notificationOccurred", type);
    }

    public async Task SelectionChangedAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("selectionChanged");
    }

    // Cloud Storage
    public async Task<string[]> GetCloudStorageKeysAsync()
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<string[]>("getCloudStorageKeys");
    }

    public async Task<string?> GetCloudStorageItemAsync(string key)
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<string?>("getCloudStorageItem", key);
    }

    public async Task<Dictionary<string, string>> GetCloudStorageItemsAsync(string[] keys)
    {
        var module = await _moduleTask.Value;
        var json = await module.InvokeAsync<string>("getCloudStorageItems", keys);
        return JsonSerializer.Deserialize<Dictionary<string, string>>(json) ?? new Dictionary<string, string>();
    }

    public async Task SetCloudStorageItemAsync(string key, string value)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("setCloudStorageItem", key, value);
    }

    public async Task RemoveCloudStorageItemAsync(string key)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("removeCloudStorageItem", key);
    }

    public async Task RemoveCloudStorageItemsAsync(string[] keys)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("removeCloudStorageItems", keys);
    }

    // Location
    public async Task RequestLocationAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("requestLocation");
    }

    // Contacts
    public async Task RequestContactAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("requestContact");
    }

    // Biometric
    public async Task<bool> IsBiometricAvailableAsync()
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<bool>("isBiometricAvailable");
    }

    public async Task<string> GetBiometricTypeAsync()
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<string>("getBiometricType");
    }

    public async Task<bool> IsBiometricAccessGrantedAsync()
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<bool>("isBiometricAccessGranted");
    }

    public async Task<bool> IsBiometricTokenSavedAsync()
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<bool>("isBiometricTokenSaved");
    }

    public async Task RequestBiometricAccessAsync(BiometricRequestAccessParams? parameters = null)
    {
        var module = await _moduleTask.Value;
        var json = parameters != null ? JsonSerializer.Serialize(parameters) : null;
        await module.InvokeVoidAsync("requestBiometricAccess", json);
    }

    public async Task AuthenticateBiometricAsync(BiometricAuthenticateParams? parameters = null)
    {
        var module = await _moduleTask.Value;
        var json = parameters != null ? JsonSerializer.Serialize(parameters) : null;
        await module.InvokeVoidAsync("authenticateBiometric", json);
    }

    public async Task UpdateBiometricTokenAsync(string token)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("updateBiometricToken", token);
    }

    // Device orientation
    public async Task RequestDeviceOrientationAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("requestDeviceOrientation");
    }

    public async Task<bool> IsDeviceOrientationAvailableAsync()
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<bool>("isDeviceOrientationAvailable");
    }

    // Accelerometer
    public async Task StartAccelerometerAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("startAccelerometer");
    }

    public async Task StopAccelerometerAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("stopAccelerometer");
    }

    public async Task<bool> IsAccelerometerAvailableAsync()
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<bool>("isAccelerometerAvailable");
    }

    // Gyroscope
    public async Task StartGyroscopeAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("startGyroscope");
    }

    public async Task StopGyroscopeAsync()
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("stopGyroscope");
    }

    public async Task<bool> IsGyroscopeAvailableAsync()
    {
        var module = await _moduleTask.Value;
        return await module.InvokeAsync<bool>("isGyroscopeAvailable");
    }

    // Event handling
    public async Task SubscribeToEventAsync(string eventType, string callbackId)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("subscribeToEvent", eventType, callbackId);
    }

    public async Task UnsubscribeFromEventAsync(string eventType, string callbackId)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("unsubscribeFromEvent", eventType, callbackId);
    }

    // Downloads
    public async Task DownloadFileAsync(string url, string filename)
    {
        var module = await _moduleTask.Value;
        await module.InvokeVoidAsync("downloadFile", url, filename);
    }

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}