
using System.Collections.Generic;

namespace SnakesAndLadders.Game;

public class GameState
{
    private IReadOnlyCollection<GameEvent> _gameEventQueue;

    public GameState()
    {
        _gameEventQueue = new Queue<GameEvent>();
    }
}