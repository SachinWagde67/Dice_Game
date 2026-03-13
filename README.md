# Dice_Game

## Overview

This project implements a simple dice rolling system where the result updates an equation:

**Points × Multiplier = Total**

The system also includes **Spirit Cards** that modify the equation when specific dice values occur. The goal of this assignment is to demonstrate clean Unity architecture, event‑driven gameplay logic, UI updates, and basic game feel effects.

------------------------------------------------------------------------

# Unity Version

Developed using:

**Unity 6.3 LTS**

The project relies only on standard Unity APIs and should work in nearby Unity versions as well.

------------------------------------------------------------------------

# Controls

* Roll Dice -> Click **Roll Button** or **Space**
  
* Observe Result -> Equation UI updates automatically

### Gameplay Flow

1.  Click **Roll**
2.  Dice generates a value **between 1-6**
3.  Points are set equal to the dice result
4.  Multiplier defaults to **10**
5.  Total is calculated:

    **Points × Multiplier = Total**

6.  If a Spirit Card condition is met, its effect activates and recalculates the equation.
  - If the dice value is 6, Spirit Card A activates and overrides the default multiplier (10) with 2.  
  - If the dice value is 3, Spirit Card B activates and adds +10 to the points   

------------------------------------------------------------------------

# Equation Logic

### Default Behavior

    Points = Dice Result
    Multiplier = 10
    Total = Points × Multiplier

Example:

    4 × 10 = 40

------------------------------------------------------------------------

# Spirit Card System

Two Spirit Cards modify the equation when certain dice values occur.

## Spirit Card A --- Multiplier Modifier

**Trigger:** Dice Result = 6

Effect:

    Multiplier = 2
    Total = Points × 2

Example:

    6 × 2 = 12

------------------------------------------------------------------------

## Spirit Card B --- Bonus Points

**Trigger:** Dice Result = 3

Effect:

    Points = Points + 10
    Total = Points × 10

Example:

    (3 + 10) × 10 = 130

------------------------------------------------------------------------

# Implementation Notes

The project follows a **modular architecture**, separating gameplay
logic, UI, and data.

## Core Components

### DiceRoller

Responsible for:

-   Dice rolling logic
-   Random number generation (1--6)
-   Dice roll animation or feedback
-   Invoking the final dice result event

------------------------------------------------------------------------

### GameCalculator

Responsible for:

-   Maintaining Points, Multiplier, and Total
-   Handling equation calculation
-   Invoking the Equation Updated event

------------------------------------------------------------------------

### Spirit Card System

Spirit Cards are implemented using **ScriptableObjects**.

Each card contains:

-   Trigger Type
-   Points values
-   Modifier values

Advantages:

-   Data‑driven design
-   Easy to extend with new cards
-   Clean separation between logic and configuration

------------------------------------------------------------------------

### SpiritCardView

Handles the **visual representation of cards**:

-   Scale Up animation
-   Visual indication when the card effect triggers

------------------------------------------------------------------------

### UIEquationView

Responsible for displaying the equation:

    Points × Multiplier = Total

Handles:

-   Updating numbers on UI
-   UI transitions
-   Visuals when the calculation completes

------------------------------------------------------------------------

# Event Flow

The system follows an **event-driven architecture**:

    Roll Button
         ↓
    DiceRoller
         ↓
    Dice Roll Completed Event
         ↓
    Spirit Card Controller
         ↓
    Spirit Card View
         ↓ 
    Game Calculator
         ↓
    Equation Calculation
         ↓
    UI Update

This design prevents overlapping calculations and keeps responsibilities separated.

------------------------------------------------------------------------

# Visual Feedback / Game Feel

The project includes feedback for:

### Dice Roll

-   Dice roll animation
-   UI feedback when rolling

### Number Changes

-   Points and Multiplier text scale-up animation
-   UI feedback when scaling

### Spirit Card Activation

-   Cards scale up and scale down
-   Showing the card is activated.

------------------------------------------------------------------------

No paid assets were used.

Only **built‑in Unity tools and assets** were used for UI and effects.

------------------------------------------------------------------------
