![Screenshot](screenshot.png)


# Top tips

- What's new in .NET Framework 4.7
https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#v47

### How's my SSL?
  * https://www.howsmyssl.com/
  * JSON response: https://www.howsmyssl.com/a/check

### Qualys SSL Labs (Ivan Ristic)
  * https://www.ssllabs.com/ssltest/
  * API Documentation: https://github.com/ssllabs/ssllabs-scan/blob/stable/ssllabs-api-docs.md

### SSL Labs exact protocol version listeners (Thank you, Ivan!)
  * **SSL 3.0**-only listener at https://ssllabs.com:10300/
  * **TLS 1.0**-only listener at https://ssllabs.com:10301/
  * **TLS 1.1**-only listener at https://ssllabs.com:10302/
  * **TLS 1.2**-only listener at https://ssllabs.com:10303/

### Listen for specific protocol version locally

```bash
$ openssl req -x509 -newkey rsa:2048 -keyout key.pem -out cert.pem -days 365 -nodes

# Spin up a simple web server on port 4433 that talks one protocol version only
$ openssl s_server -key key.pem -cert cert.pem -accept 4433 -www -tls1

 # -ssl3         - just use SSLv3
 # -tls1_2       - just use TLSv1.2
 # -tls1_1       - just use TLSv1.1
 # -tls1         - just use TLSv1
```

### Enumerate remote ciphers with `nmap`

```bash
$ sudo apt install nmap -y

$ nmap -sV --script ssl-enum-ciphers -p 443 pages.github.io

Nmap scan report for pages.github.io (151.101.37.147)

PORT    STATE SERVICE        VERSION
443/tcp open  ssl/http-proxy Varnish
|_http-server-header: GitHub.com
| ssl-enum-ciphers:
|   TLSv1.2:
|     ciphers:
|       TLS_ECDHE_RSA_WITH_AES_128_GCM_SHA256 (rsa 2048) - A
|       TLS_ECDHE_RSA_WITH_AES_256_GCM_SHA384 (rsa 2048) - A
|       TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA256 (rsa 2048) - A
|       TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA384 (rsa 2048) - A
|       TLS_ECDHE_RSA_WITH_AES_128_CBC_SHA (rsa 2048) - A
|       TLS_ECDHE_RSA_WITH_AES_256_CBC_SHA (rsa 2048) - A
|       TLS_RSA_WITH_AES_128_GCM_SHA256 (rsa 2048) - A
|       TLS_RSA_WITH_AES_128_CBC_SHA (rsa 2048) - A
|       TLS_RSA_WITH_AES_256_CBC_SHA (rsa 2048) - A
|     compressors:
|       NULL
|     cipher preference: server
|_  least strength: A
```
