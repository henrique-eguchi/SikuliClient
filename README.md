# SikuliClient
.NET wrapper of Sikuli to send commands remotely to the SikuliServer. Based on Sikuli4Net https://sourceforge.net/projects/sikuli4net/ project.


## Usage

Reference the NETSikuliClient.dll to your .NET application and do the following:

```cs
  Pattern p = new Pattern(@"..\..\..\NETSikuliClientTests\1478714104.png");
  Screen s = new Screen("200.160.12.10", 9000);
  
  s.Click(p, true);
```

Note: If a SikuliServer is not running on the given IP and PORT, the application will not work.
