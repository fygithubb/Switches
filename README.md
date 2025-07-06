# Switches
🔁 Switch Puzzle Game
A simple and fun ASP.NET Core MVC puzzle game. The objective is to turn all the lights on using a limited number of switch presses. Each switch toggles specific lights, making it a great brain-teaser.

You can check the game here on this link : https://switches.onrender.com/

🎮 Game Rules
You have 4 moves to turn on all 3 lights.

Switch behavior:

Switch A → toggles light A & B

Switch B → toggles light B & C

Switch C → toggles only light C

Game ends if:

All lights are ON ✅

You've used all moves ❌

🛠 Setup Instructions
Follow these steps to run the project locally:

📦 Requirements
.NET 6 SDK or later

Visual Studio 2022+ or VS Code

Git

🚀 Running the App
bash
Copy
Edit
git clone https://github.com/fygithubb/Switches.git
cd Switches
dotnet build
dotnet run
Visit:

arduino
Copy
Edit
https://localhost:5001/Game
You should see the switch puzzle interface with lights and buttons.

🧠 How It Works
State and move tracking handled in SwitchGameService.cs

ASP.NET Session used to persist game state

AJAX used for responsive game interaction without full page reloads

Beautiful and minimalistic front-end styling

🌍 Deployment Tips
Want to share this game?

You can deploy it to:

Azure App Service

Render.com

Railway.app

IIS on Windows

Docker (for containerized deployments)

🤝 Contributions
Feel free to fork the repo, customize the logic, or extend the UI.
Pull requests and ideas are always welcome!
