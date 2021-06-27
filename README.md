# GOSTechnology.Providers.CryptoProvider.LIB
## Crypto management provider in AES 128bits.
#### *Version Note: 1.0.0-preview1.*

[![N|Solid](https://img.icons8.com/dusk/2x/security-aes.png)](https://github.com/gabrielmotakiru/GOSTechnology.Providers.CryptoProvider.LIB)

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

- **EncryptAsync text in AES 128 bits:**
> *var text = "Teste 1";*
>
> *var key = "1234567890123456";*
>
> *var iv = "1234567890123456";*
>
> *var encrypt = await this._cryptoProvider.EncryptAESAsync(text, key, iv);*

- **Deccrypt cipherText in AES 128 bits:**
> *var cipherText = "3DwRxK7jYU4o13/ySZKL2w==";*
>
> *var key = "1234567890123456";*
>
> *var iv = "1234567890123456";*
>
> *var decrypt = this._cryptoProvider.DecryptAES(cipherText, key, iv);*

- **DecryptAsync cipherText in AES 128 bits:**
> *var cipherText = "3DwRxK7jYU4o13/ySZKL2w==";*
>
> *var key = "1234567890123456";*
>
> *var iv = "1234567890123456";*
>
> *var decrypt = await this._cryptoProvider.DecryptAESAsync(cipherText, key, iv);*

---

#### **Note**: CryptoProvider uses 128 bits for key/iv based in RijndaelManaged.
#### **Note**: Interface base is ICryptoProvider for uses in dependency injection.
#### **Note**: CryptoExtension class can be used directly in a way static, with your methods EncryptAES and DecryptAES.

---

#### Github for contribute or issues: https://github.com/gabrielmotakiru/GOSTechnology.Providers.CryptoProvider.LIB