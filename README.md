# Simulator
PP-Simulator is a C# simulation framework that models interactions of different entities (like Orcs, Elves, and Animals) on a map. The simulation allows for movement, interactions, and progression, with various map types influencing behavior. The project includes both a console-based and web-based (Razor Pages) version, along with unit tests for validation.

# 🏹 Features
🏰 Simulation Logic (in Simulator project)

## Characters:
Orcs (Rage ability) & Elves (Sing ability)

Both have attributes like Power and Leveling Up

## Map System:

Big or Small (different size constraints)

Square (stops at edge)

Torus (wraps around the edges)

Bounce (bounces back from edges)

## Other Mappables (Interface):
Animals → Birds (fly+ and fly-) move differently

## Simulation Tracking:
SimulationHistory (stores past states)

SimulationTurnLog (logs movements per turn)

Direction Enum + DirectionParser (extracts movement from input)

Validator (checks name format and level constraints [0-10])

## 🖥️ Console Version (SimConsole project)
MapVisualizer → Creates & displays the simulation grid

LogVisualizer → Logs each turn & allows viewing past states

Box → Generates the grid-based map for console output

## 🌍 Web Version (SimWeb project)
Blazor-based UI for interacting with the simulation visually

## 🏃 Application Runner (Runner project)
Runs the simulation in console mode

## ✅ Unit Testing (TestSimulator project)
Uses xUnit (Visual Studio extension) to test core simulation logic

## 🛠️ Technologies Used
C# + .NET

Razor Pages (Web UI)

xUnit (Unit testing)

Visual Studio (Development)


## 🚀 Installation & Usage
Clone the repository:

git clone https://github.com/Patrycja-Bien/PP-Simulator.git

cd PP-Simulator

Open in Visual Studio and restore dependencies

Run the desired project:

Console Mode: Run Runner

Web UI: Run SimWeb (Blazor)

Tests: Run TestSimulator
