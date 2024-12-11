# Inventory and Shop System 🎮🛒

## Overview 🌟
This project is a Unity game featuring an **Inventory and Shop System**. The game divides the screen into two UI panels: one for the Shop and one for the Player's Inventory. Players can gather resources, manage their inventory, and interact with the shop to buy or sell items.

---

## Gameplay Features

### Game Layout 🗂️
- The game screen is divided into two distinct UI panels:
  - **Shop Panel**: Displays items available for purchase.
  - **Player Inventory Panel**: Displays items the player has collected.

### Initial State 🚀
- **Player Inventory**: Initially empty.
- **Currency**: Starts at 0.

### Item Details 🛠️
Each item in the Shop or Inventory has the following attributes:
- **Type**: The category of the item (e.g., Weapon, Armor, etc.).
- **Icon**: A visual representation of the item.
- **Buying Price**: The cost to purchase the item from the shop.
- **Selling Price**: The value received when selling the item.
- **Weight**: The item's weight, affecting inventory capacity.
- **Rarity**: The rarity level of the item.
- **Quantity**: The number of the item available.

### Resource Gathering 🌱
- Players can gather random items by clicking the **Gather Items** button.
- **Weight Restriction**: The gathering process halts when the total weight in the inventory exceeds the maximum allowed weight.
- **Hover Descriptions**: Hovering over items reveals detailed descriptions.

---

## Technical Implementation 🛠️

### Architectural Design 🏗️
The game employs the **MVC (Model-View-Controller)** architecture for modular and scalable code:
1. **Shop MVC**: Manages shop-related logic, data, and UI.
2. **Inventory MVC**: Handles inventory-related operations and UI updates.
3. **Currency MVC**: Manages player currency and updates related UI elements.
4. **Weight MVC**: Ensures the player's inventory weight is tracked and restricted correctly.

### Dependency Injection 🔌
- The game uses **Dependency Injection** to facilitate communication between various scripts and ensure a loosely coupled codebase.
- It enhances testability by allowing mock implementations of dependencies during unit testing. The game uses **Dependency Injection** to facilitate communication between various scripts and ensure a loosely coupled codebase.

### Scriptable Objects 📜
- **Scriptable Objects** are used for item definitions and audio configurations.
- Benefits:
  - Easy to manage and extend item types.
  - Decouples data from logic for better reusability.
  - Allows centralized data modification without altering multiple scripts, improving scalability. **Scriptable Objects** are used for item definitions and audio configurations.

---

## How to Play 🎮
1. Start the game and explore the Shop and Player Inventory panels.
2. Use the **Gather Resources** button to collect random items.
   - Ensure the total weight of items does not exceed the maximum allowed weight.
3. Hover over items to view their detailed descriptions.
4. Interact with the Shop to:
   - **Buy Items**: Use the currency to purchase items.
5. Interact with the Inventory to:
   - **Sell Items**: Click on an inventory item to sell it and exchange it for currency.

---

## Block Diagram-
![Code diagram](https://github.com/user-attachments/assets/6000f783-9795-481c-a6a5-b70f0f660d57)

---

## Play here-
https://outscal.com/utkarshsharan99/game/play-inventory-and-shop-system-game

---

## Watch here-
https://www.loom.com/share/e303201bcb234dde8c1a958c81670449?sid=34a9f03f-a637-4d55-9822-1e517541d302
