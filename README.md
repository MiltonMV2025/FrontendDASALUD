# FrontendDASALUD

## URL DE SISTEMA PUBLICADO: https://dasaludpublicfrontend.runasp.net/


Este repositorio contiene el frontend en Blazor WebAssembly para la aplicación DASALUD.

## Requisitos

- .NET 8 SDK: https://dotnet.microsoft.com/download/dotnet/8.0
- (Opcional) Visual Studio 2022/2023 con soporte para .NET 8 o Visual Studio Code con la extensión C#.
- Backend/API disponible y accesible (la aplicación consume endpoints HTTP).

## Estructura relevante

- `FrontendDASALUD/` - proyecto Blazor WebAssembly principal.
- `FrontendDASALUD/wwwroot/appsettings.json` - archivo de configuración para la URL base del API y otras opciones públicas.

## Configuración

1. Clona el repositorio:

```bash
git clone https://github.com/MiltonMV2025/FrontendDASALUD.git
cd FrontendDASALUD
```

2. Ajusta la URL del backend/API (si aplica):

- Abre `FrontendDASALUD/wwwroot/appsettings.json` y configura la clave que contenga la URL del API (por ejemplo `ApiBaseUrl`) con la dirección donde esté corriendo tu backend (ej. `https://localhost:5001`).

## Ejecutar localmente

### Usando la CLI de .NET

```bash
cd FrontendDASALUD
dotnet restore
dotnet build
dotnet run
```

Después de ejecutar `dotnet run`, revisa la consola para la URL donde se hospeda la app (normalmente `https://localhost:5xxx` o `http://localhost:5xxx`) y ábrela en tu navegador.

### Usando Visual Studio

- Abre la solución `FrontendDASALUD.sln` en Visual Studio.
- Establece como proyecto de inicio `FrontendDASALUD` y ejecuta (F5 o Ctrl+F5).

## Autenticación

La aplicación utiliza tokens Bearer para autenticación. el backend requiere autenticación, asegúrate de:

- Tener el backend corriendo y accesible.
- Crear usuarios/credenciales en el backend o usar cuentas de prueba para iniciar sesión desde la UI (`/login`).

Las llamadas HTTP del cliente usan un servicio de autenticación que guarda el token (revisar `IAuthService`).