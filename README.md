# Inventory and Shop System - Unity Game 🎮🛒

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
- Benefits:
  - Easy to manage and extend item types.
  - Decouples data from logic for better reusability.

---

## Getting Started 🏁

### Prerequisites 📋
- Unity (Version 2021.3 or higher recommended)
- Basic knowledge of Unity's UI system and C# scripting

### Installation 💾
1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```
2. Open the project in Unity.
3. Play the game in the Unity Editor or build it for your desired platform.

---

## How to Play 🎮
1. Start the game and explore the Shop and Player Inventory panels.
2. Use the **Gather Resources** button to collect random items.
   - Ensure the total weight of items does not exceed the maximum allowed weight.
3. Hover over items to view their detailed descriptions.
4. Interact with the Shop to:
   - **Buy Items**: Use the currency to purchase items.
   - **Sell Items**: Exchange items from your inventory for currency.

---

## Future Enhancements 🔮
- Add sorting and filtering options for items in the inventory and shop.
- Introduce different rarity-based effects for items.
- Enable drag-and-drop functionality for better inventory management.
- Add sound effects and animations for item interactions.

---

## Acknowledgments 🙏
- This project demonstrates the use of **MVC architecture**, **Dependency Injection**, and **Scriptable Objects** for a clean and maintainable codebase.

---

## License 📜
This project is licensed under the MIT License. See the `LICENSE` file for more details.

---

Feel free to contribute or provide feedback to enhance the system further!

