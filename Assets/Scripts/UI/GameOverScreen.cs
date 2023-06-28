using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    private CanvasGroup _canvasGroup;

    private void OnEnable()
    {
        _player._died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _player._died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    private void OnDied()
    {
        StartCoroutine(WaitBeforeDie());
    }

    private IEnumerator WaitBeforeDie()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2f);
        _canvasGroup.alpha = 1;
    }

    private void OnRestartButtonClick()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    
    private void OnExitButtonClick()
    {
        SceneManager.LoadScene(0);
    }
}
