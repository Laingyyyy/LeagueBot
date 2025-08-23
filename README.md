# ⚽ Discord League Tournament Bot  

A Discord bot built in **C# (.NET + DSharpPlus)** to manage competitive gaming leagues directly inside Discord.  
It handles everything from **league creation** to **fixture generation**, **scheduling**, **match reporting**, and **standings** — helping teams and organisers save time.  

---

## ✨ Features  

- 🏆 **League Management**
  - Create new leagues with custom names, formats (round-robin / knockout), and team limits.  
  - Register teams and link them to Discord users.  

- 📅 **Scheduling**
  - Auto-generate fixtures.  
  - Create text channels per match with correct permissions.  
  - Schedule matches (time zones handled).  
  - Automated reminders before matches.  

- 📊 **Match Results & Tables**
  - Report scores via slash commands.  
  - Live standings table (Points, W/D/L, GF/GA, GD).  
  - Configurable tie-breaker rules.  

- 🔒 **Admin Tools**
  - Assign tournament organiser roles.  
  - Forfeit or reschedule matches.  
  - Configurable rules (points per win, default forfeit score, etc.).  

---

## 🛠️ Tech Stack  

- **Language:** C# (.NET 9)  
- **Discord API:** DSharpPlus 5  
- **Database:** EF Core + PostgreSQL  
- **Hosting:** Docker (deployable to VPS / Azure)  
- **Logging:** Serilog  

---

## 📷 Screenshots (to add later)  

> Example: league creation, fixture list, standings table.  

---

## 📖 Commands Overview  

| Command | Description |
|---------|-------------|
| `/league create` | Create a new league. |
| `/team register` | Register a new team. |
| `/league table` | Show current standings. |
| `/fixture schedule` | Schedule a match. |
| `/fixture report` | Report a score. |
| `/admin set-staff` | Assign organiser permissions. |

---

## 🧩 Project Structure

TournamentBot.sln ├── TournamentBot.Domain/       # Core entities, value objects ├── TournamentBot.Application/  # Services, use-cases ├── TournamentBot.Infrastructure/ # EF Core, repositories ├── TournamentBot.Bot/          # DSharpPlus, command handlers └── TournamentBot.Tests/        # Unit tests

---

## 🚀 Getting Started  

### Prerequisites
- .NET 9 SDK  
- Discord Bot Token  
- SQLite/Postgres  

### Run Locally  
```bash
git clone https://github.com/laingyyyy/Leaguebot.git
cd LeagueBot.Bot
dotnet run --project LeagueBot.Bot

Run with Docker

docker-compose up -d


---

🧪 Tests

xUnit test suite for league creation, fixture generation, and standings.

Run with:


dotnet test


---

📌 Roadmap

[ ] League Creation/Management

[ ] Elo/MMR system

[ ] Knockout bracket visualisation

[ ] Web dashboard (Blazor + API)

[ ] Localization support



---

📜 License

MIT License — free to use and adapt.


---

👤 Author

Laingyy

GitHub: @Laingyyyy

LinkedIn: https://www.linkedin.com/in/shaun-laing-064385263