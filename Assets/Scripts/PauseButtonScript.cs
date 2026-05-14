using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour
{
    private Button pauseButton;

    private void Start()
    {
        pauseButton = GetComponent<Button>();
        pauseButton.onClick.AddListener(OnPauseButtonClick);
        Debug.Log("Pause button initialized and listener added.");
    }

    private void OnPauseButtonClick()
    {
        Debug.Log("Pause button clicked.");
        GameManager.Instance.TogglePause();
    }
}
