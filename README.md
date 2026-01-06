# Sistemas de Pedidos

Aplicação completa de pedidos com front-end em React e back-end em .NET Core. O projeto permite gerenciar o fluxo de pedidos, com uma interface web para operação e uma API para persistência e regras de negócio.

## Stack

- **Front-end:** React JS
- **Back-end:** .NET Core
- **Infra:** Docker / Docker Compose

## Estrutura do repositório

```
.
├── app/                # Back-end .NET Core
├── front/              # Front-end React
├── docker-compose.yaml # Orquestração dos serviços
└── Dockerfile          # Imagem base (quando aplicável)
```

## Requisitos

- Node.js (para o front-end)
- .NET SDK (para o back-end)
- Docker e Docker Compose (opcional, para subir via containers)

## Como executar com Docker

1. Suba os serviços:

   ```bash
   docker-compose up --build
   ```

2. Acesse o front-end no endereço exibido no terminal.

## Como executar localmente

### Back-end

```bash
cd app
# ajuste conforme a solução/projeto .NET
# exemplo:
# dotnet restore
# dotnet run
```

### Front-end

```bash
cd front
npm install
npm start
```

## Observações

- Ajuste os comandos do back-end conforme a estrutura da solução dentro de `app/`.
- Variáveis de ambiente podem ser necessárias dependendo da configuração local.
