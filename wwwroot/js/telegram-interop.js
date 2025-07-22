// Telegram Web App JavaScript Interop

// Helper function to check if WebApp is available
export function isWebAppAvailable() {
    return typeof window.Telegram !== 'undefined' && 
           typeof window.Telegram.WebApp !== 'undefined';
}

// Helper function to safely execute WebApp methods
function safeWebAppCall(callback, fallbackValue = null) {
    try {
        if (!isWebAppAvailable()) {
            return fallbackValue;
        }
        return callback();
    } catch (error) {
        console.warn('Telegram WebApp method not supported:', error.message);
        return fallbackValue;
    }
}

// Core WebApp properties
export function getVersion() {
    return safeWebAppCall(() => window.Telegram.WebApp.version, '');
}

export function getPlatform() {
    return safeWebAppCall(() => window.Telegram.WebApp.platform, '');
}

export function getColorScheme() {
    return safeWebAppCall(() => window.Telegram.WebApp.colorScheme, 'light');
}

export function isExpanded() {
    return safeWebAppCall(() => window.Telegram.WebApp.isExpanded, false);
}

export function getThemeParams() {
    return safeWebAppCall(() => {
        return JSON.stringify(window.Telegram.WebApp.themeParams);
    });
}

export function getInitData() {
    return safeWebAppCall(() => {
        const initData = window.Telegram.WebApp.initDataUnsafe;
        if (!initData) return null;
        
        // Convert auth_date to string to avoid JSON parsing issues
        const sanitizedData = { ...initData };
        if (sanitizedData.auth_date) {
            sanitizedData.auth_date = sanitizedData.auth_date.toString();
        }
        
        return JSON.stringify(sanitizedData);
    });
}

export function getRawInitData() {
    return safeWebAppCall(() => {
        const initData = window.Telegram.WebApp.initData;
        if (!initData) return null;

        return initData;
    });
}

export function getSafeAreaInset() {
    if (!isWebAppAvailable()) return null;
    return JSON.stringify(window.Telegram.WebApp.safeAreaInset);
}

export function getContentSafeAreaInset() {
    if (!isWebAppAvailable()) return null;
    return JSON.stringify(window.Telegram.WebApp.contentSafeAreaInset);
}

// Core methods
export function ready() {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.ready();
    }
}

export function expand() {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.expand();
    }
}

export function close() {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.close();
    }
}

export function sendData(data) {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.sendData(data);
    }
}

// Navigation
export function openLink(url, tryInstantView = false) {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.openLink(url, { try_instant_view: tryInstantView });
    }
}

export function openTelegramLink(url) {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.openTelegramLink(url);
    }
}

export function switchInlineQuery(query, chatTypes = null) {
    if (isWebAppAvailable()) {
        const options = chatTypes ? { chat_types: chatTypes } : {};
        window.Telegram.WebApp.switchInlineQuery(query, options);
    }
}

// Main Button
export function setMainButtonText(text) {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.MainButton.setText(text);
    }
}

export function setMainButtonColor(color) {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.MainButton.setParams({ color: color });
    }
}

export function setMainButtonTextColor(color) {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.MainButton.setParams({ text_color: color });
    }
}

export function showMainButton() {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.MainButton.show();
    }
}

export function hideMainButton() {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.MainButton.hide();
    }
}

export function enableMainButton() {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.MainButton.enable();
    }
}

export function disableMainButton() {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.MainButton.disable();
    }
}

export function setMainButtonProgress(visible) {
    if (isWebAppAvailable()) {
        if (visible) {
            window.Telegram.WebApp.MainButton.showProgress();
        } else {
            window.Telegram.WebApp.MainButton.hideProgress();
        }
    }
}

// Secondary Button
export function setSecondaryButtonText(text) {
    if (isWebAppAvailable() && window.Telegram.WebApp.SecondaryButton) {
        window.Telegram.WebApp.SecondaryButton.setText(text);
    }
}

export function setSecondaryButtonColor(color) {
    if (isWebAppAvailable() && window.Telegram.WebApp.SecondaryButton) {
        window.Telegram.WebApp.SecondaryButton.setParams({ color: color });
    }
}

export function setSecondaryButtonTextColor(color) {
    if (isWebAppAvailable() && window.Telegram.WebApp.SecondaryButton) {
        window.Telegram.WebApp.SecondaryButton.setParams({ text_color: color });
    }
}

export function setSecondaryButtonPosition(position) {
    if (isWebAppAvailable() && window.Telegram.WebApp.SecondaryButton) {
        window.Telegram.WebApp.SecondaryButton.setParams({ position: position });
    }
}

export function showSecondaryButton() {
    if (isWebAppAvailable() && window.Telegram.WebApp.SecondaryButton) {
        window.Telegram.WebApp.SecondaryButton.show();
    }
}

export function hideSecondaryButton() {
    if (isWebAppAvailable() && window.Telegram.WebApp.SecondaryButton) {
        window.Telegram.WebApp.SecondaryButton.hide();
    }
}

export function enableSecondaryButton() {
    if (isWebAppAvailable() && window.Telegram.WebApp.SecondaryButton) {
        window.Telegram.WebApp.SecondaryButton.enable();
    }
}

export function disableSecondaryButton() {
    if (isWebAppAvailable() && window.Telegram.WebApp.SecondaryButton) {
        window.Telegram.WebApp.SecondaryButton.disable();
    }
}

export function setSecondaryButtonProgress(visible) {
    if (isWebAppAvailable() && window.Telegram.WebApp.SecondaryButton) {
        if (visible) {
            window.Telegram.WebApp.SecondaryButton.showProgress();
        } else {
            window.Telegram.WebApp.SecondaryButton.hideProgress();
        }
    }
}

// Back Button
export function showBackButton() {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.BackButton.show();
    }
}

export function hideBackButton() {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.BackButton.hide();
    }
}

// Settings Button
export function showSettingsButton() {
    if (isWebAppAvailable() && window.Telegram.WebApp.SettingsButton) {
        window.Telegram.WebApp.SettingsButton.show();
    }
}

export function hideSettingsButton() {
    if (isWebAppAvailable() && window.Telegram.WebApp.SettingsButton) {
        window.Telegram.WebApp.SettingsButton.hide();
    }
}

// Header and background colors
export function setHeaderColor(color) {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.setHeaderColor(color);
    }
}

export function setBackgroundColor(color) {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.setBackgroundColor(color);
    }
}

export function setBottomBarColor(color) {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.setBottomBarColor(color);
    }
}

// Popups
export function showPopup(paramsJson) {
    if (isWebAppAvailable()) {
        const params = JSON.parse(paramsJson);
        window.Telegram.WebApp.showPopup(params);
    }
}

export function showAlert(message) {
    if (isWebAppAvailable()) {
        window.Telegram.WebApp.showAlert(message);
    }
}

export function showConfirm(message) {
    return new Promise((resolve) => {
        if (isWebAppAvailable()) {
            window.Telegram.WebApp.showConfirm(message, (confirmed) => {
                resolve(confirmed);
            });
        } else {
            resolve(false);
        }
    });
}

export function showScanQrPopup(paramsJson) {
    return new Promise((resolve) => {
        if (isWebAppAvailable() && window.Telegram.WebApp.showScanQrPopup) {
            const params = paramsJson ? JSON.parse(paramsJson) : {};
            window.Telegram.WebApp.showScanQrPopup(params, (result) => {
                resolve(result);
            });
        } else {
            resolve(null);
        }
    });
}

// Haptic feedback
export function impactOccurred(style) {
    if (isWebAppAvailable() && window.Telegram.WebApp.HapticFeedback) {
        window.Telegram.WebApp.HapticFeedback.impactOccurred(style);
    }
}

export function notificationOccurred(type) {
    if (isWebAppAvailable() && window.Telegram.WebApp.HapticFeedback) {
        window.Telegram.WebApp.HapticFeedback.notificationOccurred(type);
    }
}

export function selectionChanged() {
    if (isWebAppAvailable() && window.Telegram.WebApp.HapticFeedback) {
        window.Telegram.WebApp.HapticFeedback.selectionChanged();
    }
}

// Cloud Storage
export function getCloudStorageKeys() {
    return new Promise((resolve) => {
        if (isWebAppAvailable() && window.Telegram.WebApp.CloudStorage) {
            window.Telegram.WebApp.CloudStorage.getKeys((error, keys) => {
                resolve(error ? [] : keys);
            });
        } else {
            resolve([]);
        }
    });
}

export function getCloudStorageItem(key) {
    return new Promise((resolve) => {
        if (isWebAppAvailable() && window.Telegram.WebApp.CloudStorage) {
            window.Telegram.WebApp.CloudStorage.getItem(key, (error, value) => {
                resolve(error ? null : value);
            });
        } else {
            resolve(null);
        }
    });
}

export function getCloudStorageItems(keys) {
    return new Promise((resolve) => {
        if (isWebAppAvailable() && window.Telegram.WebApp.CloudStorage) {
            window.Telegram.WebApp.CloudStorage.getItems(keys, (error, items) => {
                resolve(error ? '{}' : JSON.stringify(items));
            });
        } else {
            resolve('{}');
        }
    });
}

export function setCloudStorageItem(key, value) {
    if (isWebAppAvailable() && window.Telegram.WebApp.CloudStorage) {
        window.Telegram.WebApp.CloudStorage.setItem(key, value);
    }
}

export function removeCloudStorageItem(key) {
    if (isWebAppAvailable() && window.Telegram.WebApp.CloudStorage) {
        window.Telegram.WebApp.CloudStorage.removeItem(key);
    }
}

export function removeCloudStorageItems(keys) {
    if (isWebAppAvailable() && window.Telegram.WebApp.CloudStorage) {
        window.Telegram.WebApp.CloudStorage.removeItems(keys);
    }
}

// Location
export function requestLocation() {
    safeWebAppCall(() => {
        if (window.Telegram.WebApp.LocationManager && 
            typeof window.Telegram.WebApp.LocationManager.getLocation === 'function') {
            window.Telegram.WebApp.LocationManager.getLocation();
        } else {
            throw new Error('Location manager not available');
        }
    });
}

// Contacts
export function requestContact() {
    safeWebAppCall(() => {
        if (typeof window.Telegram.WebApp.requestContact === 'function') {
            window.Telegram.WebApp.requestContact();
        } else {
            throw new Error('requestContact method not available');
        }
    });
}

// Biometric
export function isBiometricAvailable() {
    return isWebAppAvailable() && 
           window.Telegram.WebApp.BiometricManager && 
           window.Telegram.WebApp.BiometricManager.isInited;
}

export function getBiometricType() {
    if (isWebAppAvailable() && window.Telegram.WebApp.BiometricManager) {
        return window.Telegram.WebApp.BiometricManager.biometricType || '';
    }
    return '';
}

export function isBiometricAccessGranted() {
    return isWebAppAvailable() && 
           window.Telegram.WebApp.BiometricManager && 
           window.Telegram.WebApp.BiometricManager.isAccessGranted;
}

export function isBiometricTokenSaved() {
    return isWebAppAvailable() && 
           window.Telegram.WebApp.BiometricManager && 
           window.Telegram.WebApp.BiometricManager.isTokenSaved;
}

export function requestBiometricAccess(paramsJson) {
    if (isWebAppAvailable() && window.Telegram.WebApp.BiometricManager) {
        const params = paramsJson ? JSON.parse(paramsJson) : {};
        window.Telegram.WebApp.BiometricManager.requestAccess(params);
    }
}

export function authenticateBiometric(paramsJson) {
    if (isWebAppAvailable() && window.Telegram.WebApp.BiometricManager) {
        const params = paramsJson ? JSON.parse(paramsJson) : {};
        window.Telegram.WebApp.BiometricManager.authenticate(params);
    }
}

export function updateBiometricToken(token) {
    if (isWebAppAvailable() && window.Telegram.WebApp.BiometricManager) {
        window.Telegram.WebApp.BiometricManager.updateBiometricToken(token);
    }
}

// Device orientation
export function requestDeviceOrientation() {
    if (isWebAppAvailable() && window.Telegram.WebApp.DeviceOrientation) {
        window.Telegram.WebApp.DeviceOrientation.start();
    }
}

export function isDeviceOrientationAvailable() {
    return isWebAppAvailable() && 
           window.Telegram.WebApp.DeviceOrientation && 
           window.Telegram.WebApp.DeviceOrientation.isStarted;
}

// Accelerometer
export function startAccelerometer() {
    if (isWebAppAvailable() && window.Telegram.WebApp.Accelerometer) {
        window.Telegram.WebApp.Accelerometer.start();
    }
}

export function stopAccelerometer() {
    if (isWebAppAvailable() && window.Telegram.WebApp.Accelerometer) {
        window.Telegram.WebApp.Accelerometer.stop();
    }
}

export function isAccelerometerAvailable() {
    return isWebAppAvailable() && 
           window.Telegram.WebApp.Accelerometer && 
           window.Telegram.WebApp.Accelerometer.isStarted;
}

// Gyroscope
export function startGyroscope() {
    if (isWebAppAvailable() && window.Telegram.WebApp.Gyroscope) {
        window.Telegram.WebApp.Gyroscope.start();
    }
}

export function stopGyroscope() {
    if (isWebAppAvailable() && window.Telegram.WebApp.Gyroscope) {
        window.Telegram.WebApp.Gyroscope.stop();
    }
}

export function isGyroscopeAvailable() {
    return isWebAppAvailable() && 
           window.Telegram.WebApp.Gyroscope && 
           window.Telegram.WebApp.Gyroscope.isStarted;
}

// Event handling
const eventCallbacks = new Map();

export function subscribeToEvent(eventType, callbackId) {
    if (!isWebAppAvailable()) return;
    
    const callback = (data) => {
        // Notify Blazor component through custom event
        window.dispatchEvent(new CustomEvent(`telegram-${eventType}`, {
            detail: { callbackId, data }
        }));
    };
    
    eventCallbacks.set(callbackId, callback);
    window.Telegram.WebApp.onEvent(eventType, callback);
}

export function unsubscribeFromEvent(eventType, callbackId) {
    if (!isWebAppAvailable()) return;
    
    const callback = eventCallbacks.get(callbackId);
    if (callback) {
        window.Telegram.WebApp.offEvent(eventType, callback);
        eventCallbacks.delete(callbackId);
    }
}

// Downloads
export function downloadFile(url, filename) {
    if (isWebAppAvailable() && window.Telegram.WebApp.downloadFile) {
        window.Telegram.WebApp.downloadFile({ url, file_name: filename });
    }
}