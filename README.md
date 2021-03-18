# DevTools

**A privacy-focused set of tools for software developers.**

[Try it out on the DevTools demo page](https://d365zs3ub4ze90.cloudfront.net/). Or clone this repo and build locally using the cross-platform .NET Core SDK.

> The [demo page](https://d365zs3ub4ze90.cloudfront.net/) is written in Blazor (WebAssembly) which has known performance limitations. Performance will be dramatically improved when Microsoft releases .NET 6 in Nov 2021.

## Description

Tired of searching for 'RGB to Hex' converters, GUID generators, and other stuff you need in your day-to-day,
    only to find every result loads megabytes of advertisements, trackers, and other JavaScript nuisances?
    DevTools is a way to avoid these distractions and get your work done with peace of mind. It doesn't spy on you, track you, or try to sell you things. It's built with your privacy and safety first and foremost. DevTools loads no external content and never phones home.

DevTools can run as a native Windows 10 application or as a web application ([See demo page](https://d365zs3ub4ze90.cloudfront.net/)). A feature comparison across platforms is shown below:

| Feature                    | Desktop       | Web   |
|:-------------------------- |:------------- |:----- |
| JsonPath tester            | Yes           | Yes   |
| Json transformer           | Yes           | No    |
| Regular expression tester  | Yes           | Yes   |
| RGB to Hex converter       | Yes           | Yes   |
| Base64 encoder/decoder     | Yes           | Yes   |
| Hasher                     | Yes           | Yes   |
| File encryption/decryption | Yes           | No    |
| GUID/UUID generator        | Yes           | Yes   |

## Building and running locally

### Windows 10 with Visual Studio

1. Clone this repo
2. Open the `.sln` file in Visual Studio 2019
3. Set the **Start project** to `DevTools.UI` to run the native app or `DevTools.WebUI` to run the web app.
4. Press the **Debug** button or hit `F5` to build and run the app.

> On Linux and macOS, only the web application can be built; these cannot compile and run the Windows 10 native app.

### Bash terminal on Linux, macOS, or Windows
The DevTools web app can be built and run on any platform using the [.NET Core SDK](https://dotnet.microsoft.com/download). Clone the repo and then run the following commands:

```bash
cd src/DevTools.WebUI
dotnet build
dotnet run
```

The terminal output will display what port to open in your web browser:

```
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: https://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
```

## Screenshots (Web app)

The web version of DevTools is built in Blazor and uses Bootstrap.

### Text hasher:
![Hasher page in the DevTools web app](/images/web-image-05.png)

### GUID/UUID generator:
![GUID/UUID generator in the DevTools web app](/images/web-image-07.png)

## Screenshots (Native app)

The Windows 10 desktop version of DevTools is built in WPF and uses [ModernWpfUI](https://github.com/Kinnara/ModernWpf).

### Json path tester:
![Json Path tester](/images/image01.png)

### Regex tester:
![Regular expression tester](/images/image02.png)

### RGB-to-Hex and Hex-to-RGB converter:
![RGB to Hex converter](/images/image03.png)

### Base64 encoding and decoding:
![Base64 encoder and decoder](/images/image04.png)

### Text hasher:
![Hasher](/images/image05.png)

### File encryptor:
![File encryptor](/images/image06.png)

### GUID/UUID generator:
![GUID/UUID generator](/images/image07.png)
