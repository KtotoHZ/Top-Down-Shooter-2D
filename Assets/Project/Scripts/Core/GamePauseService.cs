using UnityEngine;
using Zenject;

public class GamePauseService : IGamePauseService
{
    [Inject] private SignalBus _signalBus;
    public void PauseGame()
    {
        Time.timeScale = 0;

        _signalBus.Fire(new GamePauseSignal(true));
    }

    public void ResumeGame()
    {
        Time.timeScale = 1.0f;

        _signalBus.Fire(new GamePauseSignal(false));
    }
}
