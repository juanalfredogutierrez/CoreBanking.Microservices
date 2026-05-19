# CoreBanking.Microservices

Proyecto de arquitectura de microservicios desarrollado con .NET 8, SQL Server, Docker y Kubernetes.

## Tecnologías utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Docker
- Docker Compose
- Kubernetes
- Clean Architecture
- HttpClientFactory
- Resilience Handler

---

# Arquitectura

El proyecto contiene dos microservicios:

- AccountService
- CustomerService

Los servicios se comunican vía HTTP utilizando HttpClient.

---

# Infraestructura Kubernetes

El proyecto incluye:

- Deployments
- Services
- Namespace
- SQL Server en Kubernetes
- Networking interno entre microservicios

---

# Estructura

```text
CoreBanking.Microservices
│
├── AccountService.API
├── AccountService.Application
├── AccountService.Domain
├── AccountService.Infrastructure
│
├── CustomerService.API
├── CustomerService.Application
├── CustomerService.Domain
├── CustomerService.Infrastructure
│
├── k8s
│   ├── namespace.yaml
│   ├── sqlserver
│   ├── accountservice
│   └── customerservice
