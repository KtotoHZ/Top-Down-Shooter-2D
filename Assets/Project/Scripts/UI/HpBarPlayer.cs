using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HpBarPlayer : MonoBehaviour
{
    [SerializeField] private Image _bar;

    [Inject] private PlayerController _playerController;
  
    private void OnEnable()
    {
        _playerController.Health.OnHealthChanged += ChangeBar;
    }
    private void OnDisable()
    {
        _playerController.Health.OnHealthChanged -= ChangeBar;
    }

    private void ChangeBar(int currentHealth, int maxHealth) => 
        _bar.fillAmount = (float)currentHealth / (float)maxHealth;
}
