![Screenshot](screenshot.png)


# Top tips

- What's new in .NET Framework 4.7
https://docs.microsoft.com/en-us/dotnet/framework/whats-new/#v47

* How's my SSL?
** https://www.howsmyssl.com/
** JSON response: https://www.howsmyssl.com/a/check

* Qualys SSL Labs (Ivan Ristic)
** https://www.ssllabs.com/ssltest/
** API Documentation: https://github.com/ssllabs/ssllabs-scan/blob/stable/ssllabs-api-docs.md

* Enumerate remote ciphers with `nmap`:


```
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

