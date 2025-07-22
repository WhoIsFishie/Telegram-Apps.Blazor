using TelegramApps.Blazor.Models;

namespace TelegramApps.Blazor.Services;

public interface ITelegramWebAppService
{
    // Core WebApp properties
    Task<bool> IsAvailableAsync();
    Task<string> GetVersionAsync();
    Task<string> GetPlatformAsync();
    Task<string> GetColorSchemeAsync();
    Task<bool> IsExpandedAsync();
    Task<ThemeParams?> GetThemeParamsAsync();
    Task<WebAppInitData?> GetInitDataAsync();
    Task<string> GetRawInitDataAsync();
    Task<SafeAreaInset?> GetSafeAreaInsetAsync();
    Task<ContentSafeAreaInset?> GetContentSafeAreaInsetAsync();

    // Core methods
    Task ReadyAsync();
    Task ExpandAsync();
    Task CloseAsync();
    Task SendDataAsync(string data);

    // Navigation
    Task OpenLinkAsync(string url, bool tryInstantView = false);
    Task OpenTelegramLinkAsync(string url);

    // Inline queries
    Task SwitchInlineQueryAsync(string query, string[]? chatTypes = null);

    // Main Button
    Task SetMainButtonTextAsync(string text);
    Task SetMainButtonColorAsync(string color);
    Task SetMainButtonTextColorAsync(string color);
    Task ShowMainButtonAsync();
    Task HideMainButtonAsync();
    Task EnableMainButtonAsync();
    Task DisableMainButtonAsync();
    Task SetMainButtonProgressAsync(bool visible);

    // Secondary Button
    Task SetSecondaryButtonTextAsync(string text);
    Task SetSecondaryButtonColorAsync(string color);
    Task SetSecondaryButtonTextColorAsync(string color);
    Task SetSecondaryButtonPositionAsync(string position);
    Task ShowSecondaryButtonAsync();
    Task HideSecondaryButtonAsync();
    Task EnableSecondaryButtonAsync();
    Task DisableSecondaryButtonAsync();
    Task SetSecondaryButtonProgressAsync(bool visible);

    // Back Button
    Task ShowBackButtonAsync();
    Task HideBackButtonAsync();

    // Settings Button
    Task ShowSettingsButtonAsync();
    Task HideSettingsButtonAsync();

    // Header color
    Task SetHeaderColorAsync(string color);
    Task SetBackgroundColorAsync(string color);
    Task SetBottomBarColorAsync(string color);

    // Popups
    Task ShowPopupAsync(PopupParams parameters);
    Task ShowAlertAsync(string message);
    Task<bool> ShowConfirmAsync(string message);
    Task<string?> ShowScanQrPopupAsync(ScanQrPopupParams? parameters = null);

    // Haptic feedback
    Task ImpactOccurredAsync(string style);
    Task NotificationOccurredAsync(string type);
    Task SelectionChangedAsync();

    // Cloud Storage
    Task<string[]> GetCloudStorageKeysAsync();
    Task<string?> GetCloudStorageItemAsync(string key);
    Task<Dictionary<string, string>> GetCloudStorageItemsAsync(string[] keys);
    Task SetCloudStorageItemAsync(string key, string value);
    Task RemoveCloudStorageItemAsync(string key);
    Task RemoveCloudStorageItemsAsync(string[] keys);

    // Location
    Task RequestLocationAsync();

    // Contacts
    Task RequestContactAsync();

    // Biometric
    Task<bool> IsBiometricAvailableAsync();
    Task<string> GetBiometricTypeAsync();
    Task<bool> IsBiometricAccessGrantedAsync();
    Task<bool> IsBiometricTokenSavedAsync();
    Task RequestBiometricAccessAsync(BiometricRequestAccessParams? parameters = null);
    Task AuthenticateBiometricAsync(BiometricAuthenticateParams? parameters = null);
    Task UpdateBiometricTokenAsync(string token);

    // Device orientation
    Task RequestDeviceOrientationAsync();
    Task<bool> IsDeviceOrientationAvailableAsync();

    // Accelerometer
    Task StartAccelerometerAsync();
    Task StopAccelerometerAsync();
    Task<bool> IsAccelerometerAvailableAsync();

    // Gyroscope
    Task StartGyroscopeAsync();
    Task StopGyroscopeAsync();
    Task<bool> IsGyroscopeAvailableAsync();

    // Event handling
    Task SubscribeToEventAsync(string eventType, string callbackId);
    Task UnsubscribeFromEventAsync(string eventType, string callbackId);

    // Downloads
    Task DownloadFileAsync(string url, string filename);
}