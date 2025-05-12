# C# Tic Tac Toe Game

A simple command-line implementation of the classic Tic Tac Toe game written in C#.

## Overview

This is a console-based implementation of Tic Tac Toe that allows two players to take turns placing their marks ('X' and 'O') on a 3x3 grid. The game automatically detects winning conditions or a draw.

## Features

- Interactive command-line interface
- 3x3 game board with numeric field references (1-9)
- Alternating turns between two players (X and O)
- Win detection for rows, columns, and diagonals
- Draw detection when the board is full
- Input validation to prevent invalid moves
- Option to play again after game completion

## How to Play

1. The game board is represented as a 3x3 grid, with each cell numbered from 1 to 9:
   ```
    1 | 2 | 3 
   -----------
    4 | 5 | 6 
   -----------
    7 | 8 | 9 
   ```

2. Players take turns entering a number from 1-9 to place their mark in the corresponding cell.
3. The first player to get three of their marks in a row (horizontally, vertically, or diagonally) wins.
4. If all cells are filled and no player has won, the game ends in a draw.

## Technical Implementation

### Main Components

- **Game Board Initialization**: Creates a 3x3 grid numbered from 1 to 9
- **Game Loop**: Manages the flow of the game until a win or draw is detected
- **Player Move Logic**: Validates input and updates the board accordingly
- **Win Detection**: Checks for winning patterns after each move
- **Draw Detection**: Identifies when the board is full with no winner

### Key Functions

- `InitializeGameBoard()`: Sets up the initial game board with numbers 1-9
- `ShowBoard()`: Displays the current state of the game board
- `GetPlayerMove()`: Handles player input and validates moves
- `ChangePlayer()`: Switches the active player after a valid move
- `CheckWinCondition()`: Determines if the current player has won
- `CheckDraw()`: Checks if the game has ended in a draw

## Getting Started

### Prerequisites

- .NET SDK (5.0 or later recommended)
- A terminal or command prompt

### Running the Game

1. Clone this repository:
   ```
   git clone https://github.com/yourusername/tictactoe-csharp.git
   ```

2. Navigate to the project directory:
   ```
   cd tictactoe-csharp
   ```

3. Build the project:
   ```
   dotnet build
   ```

4. Run the application:
   ```
   dotnet run
   ```

## Development

### Project Structure

```
TicTacToe/
├── Program.cs    # Main game logic
├── TicTacToe.csproj
└── README.md
```

### Extending the Game

Some ideas for extending the game:

- Add an AI opponent with various difficulty levels
- Implement a scoring system to track wins across multiple games
- Create a graphical user interface
- Add network functionality for remote play
- Increase the board size beyond 3x3

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- This game was created as a learning exercise in C# programming
- Thanks to everyone who has played and provided feedback
