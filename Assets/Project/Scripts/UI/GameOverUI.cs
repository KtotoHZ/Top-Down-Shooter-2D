using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private float _delayActivation;
    [Inject] private PlayerController _playerController;
    [Inject] private IGamePauseService _gamePauseService;

    private void OnEnable() => _playerController.OnDeath += OnGameOver;
    private void OnDisable() => _playerController.OnDeath -= OnGameOver;

    private void OnGameOver() => DelayWindowsActivate().Forget();

    private async UniTaskVoid DelayWindowsActivate()
    {
        await UniTask.WaitForSeconds(_delayActivation, ignoreTimeScale: true);

        _gameOverPanel.SetActive(true);
    }
    public void RestartLevel()
    {
        _gamePauseService.ResumeGame();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
