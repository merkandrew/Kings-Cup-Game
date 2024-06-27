# King's Cup API Documentation

Welcome to the King's Cup API, a .NET-based service designed to bring the classic party game to life digitally. Currently featuring a handful of essential endpoints, this API serves as the foundation for an interactive King's Cup experience.

## Current Endpoints

### Welcome Endpoints
* ***GET*** `/api/welcome` - Show the welcome message.
* ***GET*** `/api/welcome/rules` - This will return a dictionary of all the rules.

### GameController Endpoints

#### GET Requests
* ***GET*** `/api/game/draw` 
    - Description: Draws a card from the deck.
    - Response: The drawn card or a message indicating no more cards in the deck.
* ***GET*** `/api/game/deck`
    - Description: Retrieves the remaining cards in the deck.
    - Response: List of remaining cards.
* ***GET*** `/api/game/rule/{rank}`
    - Description: Retrieves the rule for a specific card rank.
    - Response: The rule for the specified card rank.
* ***GET*** `/api/game/rules`
    - Description: Retrieves all the rules of the game.
    - Response: Dictionary of card ranks and their corresponding rules.
* ***GET*** `api/game/players`
    - Description: Retrieves the list of players in the game.
    - Response: List of players in the game.
* ***GET*** `api/game/history`
    - Description: Retrieves the history of drawn cards.
    - Response: List of drawn cards.
* ***GET*** `/api/game/player/{name}`
    - Description: Retrieves details of a specific player.
    - Response: The player's details.
* ***GET*** `/api/game/state`
    - Description: Gets the current state of the game.
    - Response: Object containing current players, remaining deck, and card draw history.
* ***GET*** `/api/game/statistics`
    - Description: Retrieves game statistics such as the most frequently drawn card.
    - Response: Object containing game statistics.
* ***GET*** `/api/game/history/{playerName}`
    - Description: Gets the history of actions taken by a specific player.
    - Response: List of actions taken by the specified player.

#### Post Requests
* ***POST** `/api/game/player`
    - Description: Adds a player to the game.
    - Request Body: The player's name(string).
    - Response: Success message
* ***POST*** `/api/game/reset`
    - Description: Resets the game, clearing players and reinitializing the deck.
    - Response: Success message.
* ***POST*** `/api/game/config`
    - Description: Configures the game settings.
    - Request Body: **GameConfig** object containing game configuration details.
    - Response: Success message.

#### PUT Requests
* ***PUT*** `/api/game/player/{oldName}`
    - Description: Updates a player's name.
    - Request Body: New player name (string).
    - Response: Success message.

#### DELETE Requests
* ***DELETE*** `/api/game/player/{name}`
    - Description: Removes a player from the game.
    - Response: Success message.

## Planned Features

In the upcoming updates, I aim to expand the functionality of the API and enhance the user interface to provide a more immersive and customizable King's Cup experience. Planned features include:

- **Dynamic Rules Management**: Enable the addition, modification, and removal of game rules via API endpoints.
- **Game Progress Tracking**: Implement endpoints to track the game's progress, including current player turns and the state of the game.
- **Real-time Updates**: Integrate WebSocket support for real-time updates to players and spectators.
- **Player Interactions**: Allow players to interact with the game via API calls, such as drawing cards or performing rule-based actions.

## Future UI Enhancements

To complement the robust API, I will also revamp the user interface with modern design principles and interactive elements. Key UI enhancements will include:

- **Responsive Design**: Ensure compatibility across various devices and screen sizes.
- **Intuitive Controls**: Streamline player interactions and provide clear visual feedback.
- **Customization Options**: Allow users to personalize their game settings and preferences.

## Get Involved

I'm excited about the future of the King's Cup API and invite you to contribute ideas and feedback. Stay tuned for updates as I continue to expand and improve your digital King's Cup experience!
