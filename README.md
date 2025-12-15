# 🎮 Sync Dash

Sync Dash is a split-screen endless runner game where the player races forward while a delayed ghost player mirrors their actions using state synchronization. The challenge is to survive obstacles and collect orbs while managing increasing speed and precision jumps.

---

## 🕹️ Gameplay Overview

- The player runs forward automatically with speed increasing over time  
- Tap / click to jump  
- Obstacles end the run on collision  
- Orbs can be collected for score  
- A ghost (remote) player follows the main player with a slight delay, synced using buffered player states  

---

## ✨ Core Mechanics

- Endless forward movement  
- Jump with gravity-based falling  
- Speed increases gradually over time  
- Obstacle collision with camera shake feedback  
- Orb collection system  
- Ghost player movement using state buffering and interpolation  
- Simple UI with main menu and restart flow  
- Sound effects for jump, collision, and collectables 

---

## 🛠️ Technical Details

- Engine: **Unity 2021 LTS or later**
- Platform: **Android**
- Movement: Rigidbody-based physics
- State Sync: Position, rotation, orb collection
- Optimization: Object pooling for ground tiles
- Camera: Follow camera with shake effect on collision
- Audio: Background music and one-shot sound effects

---

## 🎥 Gameplay Video

▶️ Watch Gameplay Demo:  
https://drive.google.com/file/d/1sWxDc3AFip2-IM05m9iB0XQ2uILZn-7g/view?usp=sharing

---

## 📦 Android Build (.apk)

📱 Download Android APK:  
https://drive.google.com/file/d/1r76Efbq30iiAqYR_4eq-hiTkK5SJ6umW/view?usp=sharing

- APK Size: **30 MB**
- Orientation: **Landscape (1920 x 1080)**

---

## 📱 Controls

- **Tap / Left Mouse Button / Space** → Jump

---

## 🚀 How to Run the Project

1. Clone the repository
2. Open the project in **Unity 2021 LTS or later**
3. Open the Main Menu scene
4. Press Play or build for Android

---

## 👤 Developer

Developed by **Mirsab KM**  
Unity Game Developer
