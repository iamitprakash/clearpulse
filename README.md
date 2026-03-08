# 🛡️ Clearpulse: Anonymous Feedback Platform

Clearpulse is an enterprise-grade anonymous feedback platform designed for absolute privacy, safety, and simplicity. It features a professional **N-tier .NET** backend and a high-fidelity **Vue 3** frontend with glassmorphic aesthetics.

## 🚀 Key Features

- **N-Tier Architecture**: Clean separation between Domain, Application, Infrastructure, and API layers.
- **Code First Database**: Powered by **PostgreSQL** with Entity Framework Core migrations.
- **Identity-less Security**: Strictly no accounts, no IP logging, and no identity tracking.
- **Premium UI**: Responsive Vue 3 application with a modern, "safe space" design.
- **Swagger Documentation**: Interactive API testing and exploration.

## 🏗️ Technical Stack

- **Backend**: .NET 10 (N-Tier)
- **Frontend**: Vue 3 (Composition API) + Vite + Tailwind CSS
- **Database**: PostgreSQL (OR EF Core compatible)
- **State Management**: Pinia (with local storage persistence for secret tokens)
- **Icons**: Lucide-Vue-Next

## 🛠️ Getting Started

### Prerequisites

- .NET 10 SDK
- Node.js (v18+) & focus npm
- Docker (for PostgreSQL)

### 1. Database Setup

Ensure your PostgreSQL instance is running. If using the provided `docker-compose.yml`:

```bash
docker-compose up -d
```

Update the connection string in `Clearpulse.Api/appsettings.Development.json` if necessary.

### 2. Backend Initialization

```bash
cd Clearpulse.Api
dotnet run
```

The API will be available at `http://localhost:5036`. Explore the documentation at `http://localhost:5036/swagger`.

### 3. Frontend Initialization

```bash
cd clearpulse-web
npm install
npm run dev
```

Open `http://localhost:5173` in your browser.

## 📄 Project Structure

- `Clearpulse.Domain`: Core entities (`Pulse`, `Feedback`).
- `Clearpulse.Application`: Service interfaces and business abstractions.
- `Clearpulse.Infrastructure`: Data access implementations and EF Core migrations.
- `Clearpulse.Api`: Web API controllers and configuration.
- `clearpulse-web`: Vue 3 frontend application.

## 🛡️ Privacy Commitment

Clearpulse is built on the principle that feedback should be truly anonymous. We do not store:

- User accounts or personal identities.
- Submitter IP addresses or browser fingerprints.
- Any metadata that could link feedback to a specific individual.

---

_Built for honest communication._
