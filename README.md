# GOSTechnology.Providers.CryptoProvider.LIB
## Crypto management provider in AES with key 256 bits and block (iv) 128 bits.
#### *Version Note: 1.0.1.*

[![N|Solid](https://raw.githubusercontent.com/gabrielmotakiru/GOSTechnology.Providers.CryptoProvider.LIB/main/GOSTechnology.Providers.CryptoProvider.LIB/icon.png)](https://github.com/gabrielmotakiru/GOSTechnology.Providers.CryptoProvider.LIB)

#### *View Client: [Encrypt & Decrypt](https://gabrielmotakiru.github.io/GOSTechnology.Providers.CryptoProvider.LIB/index.html)*
###### Client to configure connection strings, and test communication between front end / back end.

---

## 1 - CONFIGURING LIBRARY:
- **Add using namespace for library:**
> *using GOSTechnology.Providers.CryptoProvider.LIB;*

---

## 2 - USING ENCRYPT & DECRYPT:
- **Encrypt text in AES with key 256 bits and block 128 bits:**
> *var text = "Teste 1";*
>
> *var key = "12345678901234567890123456789012";*
>
> *var iv = "1234567890123456";*
>
> *var encrypt = CryptoProvider.EncryptAES(text, key, iv);*

- **Decrypt text in AES with key 256 bits and block 128 bits:**
> *var cipherText = "cNYfEsY2OjqmoyiSN6tZIA==";*
>
> *var key = "12345678901234567890123456789012";*
>
> *var iv = "1234567890123456";*
>
> *var decrypt = CryptoProvider.DecryptAES(cipherText, key, iv);*

---

## 3 - USING SET AND GET PASSWORD HASH:
- **Encrypt a password in AES with key 256 bits and block 128 bits, the key and block size are boarded into library:**
> *var password= "748596";*
>
> *var encrypt = CryptoProvider.SetPasswordHash(password);*

- **Decrypt a cipher password in AES with key 256 bits and block 128 bits, the key and block size are boarded into library:**
> *var cipherPassword = "hfGePuNUfVpNWXptURqXbg==";*
>
> *var decrypt = CryptoProvider.GetPasswordHash(cipherPassword);*

---

**Note**: CryptoProvider uses key until 256 bits and block size until 128 bits based in AES.

**Note**: The calls can be have by static call in the public class CryptoProvider, of namespace "GOSTechnology.Providers.CryptoProvider.LIB".

**Note**: Exists a scheme of method wich provide hash for passwords, with encrypt and decrypt.

**Note**: The key and block size are boarded into library.

---

#### Github for contribute or issues: https://github.com/gabrielmotakiru/GOSTechnology.Providers.CryptoProvider.LIB
