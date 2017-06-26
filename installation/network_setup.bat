certutil -p 0 -importPFX %~dp0certificate.pfx
netsh http add sslcert ipport=0.0.0.0:18081 certhash=12ca606b7de59c926e65a20e4063d29befd0727a appid={4724405f-6333-4320-9896-8aaac233293a}
netsh http add urlacl url=http://+:18080/ user=Everyone
netsh http add urlacl url=https://+:18081/ user=Everyone
certutil -p cryostat! -importPFX %~dp0ServerCertificate2.pfx
pause