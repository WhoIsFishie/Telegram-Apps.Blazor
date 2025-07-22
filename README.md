# Telegram-Apps.Blazor

A comprehensive library for integrating Telegram WebApp functionality into Blazor Server and WebAssembly applications.

## Features

- 🚀 **Full Telegram WebApp API Support** - Complete coverage of the Telegram WebApp JavaScript API
- 🌐 **Cross-Platform** - Works with both Blazor Server and Blazor WebAssembly
- 🔒 **Type-Safe** - Strongly-typed C# models for all Telegram data structures
- 🛡️ **Error Handling** - Graceful fallbacks when running outside Telegram environment
- 📱 **Modern UI** - Includes ready-to-use demo components
- 🎨 **Customizable** - Flexible configuration options

## Installation

```bash
dotnet add package Telegram-Apps.Blazor
```

## Quick Start

### 1. Register Services

**Program.cs (Blazor Server or WASM):**
```csharp
using TelegramApps.Blazor.Extensions;

var builder = WebApplication.CreateBuilder(args);
// ... other services

// Add Telegram WebApp services
builder.Services.AddTelegramWebApp();

var app = builder.Build();
```

### 2. Include Telegram Script

**_Host.cshtml (Blazor Server) or index.html (Blazor WASM):**
```html
<head>
    <!-- ... other head content -->
    <script src="https://telegram.org/js/telegram-web-app.js"></script>
</head>
```

### 3. Use in Components

```razor
@using TelegramApps.Blazor.Services
@inject ITelegramWebAppService TelegramService

<button @onclick="InitializeTelegram">Initialize</button>

@code {
    private async Task InitializeTelegram()
    {
        var isAvailable = await TelegramService.IsAvailableAsync();
        if (isAvailable)
        {
            await TelegramService.ReadyAsync();
            var user = await TelegramService.GetInitDataAsync();
            // Use Telegram WebApp features
        }
    }
}
```

## API Coverage

### Core Features
- ✅ WebApp initialization and lifecycle
- ✅ User information and authentication
- ✅ Theme parameters and UI customization
- ✅ Main button, secondary button, back button controls
- ✅ Popup dialogs and confirmations

### Advanced Features
- ✅ Haptic feedback
- ✅ Cloud storage
- ✅ Location services
- ✅ Contact sharing
- ✅ Biometric authentication
- ✅ Device sensors (accelerometer, gyroscope)
- ✅ QR code scanning
- ✅ File downloads

## Components

### TelegramWebAppDemo
A comprehensive demo component that showcases ALL available Telegram WebApp features:

```razor
<TelegramWebAppDemo />
```

**Demo Features Include:**
- **WebApp Status** - Real-time status information, version, platform detection
- **User Information** - Complete user profile data display  
- **Raw Init Data Viewer** - JSON-formatted initialization data with refresh capability
- **Cloud Storage Testing** - Full CRUD operations (Create, Read, Update, Delete, List, Clear)
- **Biometric Authentication** - Status checking, access requests, authentication flows
- **Device Sensors** - Accelerometer, gyroscope, and device orientation testing
- **Advanced Features** - QR code scanning, file downloads, inline query switching
- **UI Customization** - Live color picker for header, background, and bottom bar
- **Popup & Dialog Testing** - Custom popups, multi-button dialogs, destructive confirmations
- **Haptic Feedback Testing** - All impact styles and notification types
- **Button Controls** - Main, secondary, back, and settings button management
- **Theme Integration** - Live theme parameter display with color swatches

This makes it the most comprehensive Telegram WebApp testing tool available for Blazor applications!

## Configuration

Configure advanced options:

```csharp
builder.Services.AddTelegramWebApp(options =>
{
    options.EnableDebugLogging = true;
    options.InteropTimeoutMs = 10000;
    options.ScriptUrl = "https://telegram.org/js/telegram-web-app.js";
});
```

## Models

All Telegram data structures are available as strongly-typed C# models:

- `WebAppInitData` - User and chat initialization data
- `WebAppUser` - Telegram user information
- `ThemeParams` - UI theme colors and styling
- `PopupParams` - Popup dialog configuration
- `LocationData` - Geolocation information
- And many more...

## Browser Compatibility

The library includes graceful fallbacks for development and testing outside the Telegram environment. All methods will safely return default values or display appropriate messages when Telegram WebApp APIs are not available.

## License

MIT License - see LICENSE file for details.

## Contributing

Contributions are welcome! Please feel free to submit issues and pull requests.