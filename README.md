# [GOSTechnology.Providers.CryptoProvider.LIB](https://www.nuget.org/packages/GOSTechnology.Providers.CryptoProvider.LIB/)
## Crypto management provider in AES 128bits.
#### *Version Note: [1.0.0 (nuget.org)](https://www.nuget.org/packages/GOSTechnology.Providers.CryptoProvider.LIB/)*

[![N|Solid](https://img.icons8.com/dusk/2x/security-aes.png)](https://github.com/gabrielmotakiru/GOSTechnology.Providers.CryptoProvider.LIB)

#### *View Client: [Encrypt & Decrypt](https://gabrielmotakiru.github.io/GOSTechnology.Providers.CryptoProvider.LIB/index.html)*
###### Client to use crypto AES 128 bits in JavaScript for encapsulating data (connection strings, communication between front end and back end).

---

## 1 - CONFIGURING LIBRARY:
- **Add using namespace for library:**
> *using GOSTechnology.Providers.CryptoProvider.LIB;*

- **Add dependency injection (ConfigureServices - Startup.cs):**
> *services.AddCryptoProvider();*

---

## 2 - USING LIBRARY:
- **Encrypt text in AES 128 bits:**
> *var text = "Teste 1";*
>
> *var key = "1234567890123456";*
>
> *var iv = "1234567890123456";*
>
> *var encrypt = this._cryptoProvider.EncryptAES(text, key, iv);*

- **Encrypt Async text in AES 128 bits:**
> *var text = "Teste 1";*
>
> *var key = "1234567890123456";*
>
> *var iv = "1234567890123456";*
>
> *var encrypt = await this._cryptoProvider.EncryptAESAsync(text, key, iv);*

- **Deccrypt text in AES 128 bits:**
> *var cipherText = "3DwRxK7jYU4o13/ySZKL2w==";*
>
> *var key = "1234567890123456";*
>
> *var iv = "1234567890123456";*
>
> *var decrypt = this._cryptoProvider.DecryptAES(cipherText, key, iv);*

- **Decrypt Async text in AES 128 bits:**
> *var cipherText = "3DwRxK7jYU4o13/ySZKL2w==";*
>
> *var key = "1234567890123456";*
>
> *var iv = "1234567890123456";*
>
> *var decrypt = await this._cryptoProvider.DecryptAESAsync(cipherText, key, iv);*

---

#### **Note**: CryptoProvider uses 128 bits for key/iv based in RijndaelManaged.
#### **Note**: Base interface of object "this._cryptoProvider" is ICryptoProvider for uses in dependency injection.
#### **Note**: CryptoExtension class can be used directly in a way static, with your methods EncryptAES and DecryptAES.

---

#### Github for contribute or issues: https://github.com/gabrielmotakiru/GOSTechnology.Providers.CryptoProvider.LIB
