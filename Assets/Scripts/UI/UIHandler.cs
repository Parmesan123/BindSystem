using UnityEngine;
using UnityEngine.SceneManagement;


public class UIHandler : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenuPanel;
    [SerializeField] private GameObject _settingsPanel;

    public void StartPlay()
    {
        SceneManager.LoadScene("TestBindScene");
    }

    public void CloseApp()
    {
        Application.Quit();
    }
    
    public void OpenSettings()
    {
        if(_settingsPanel.gameObject.activeInHierarchy)
            return;
        
        _mainMenuPanel.gameObject.SetActive(false);
        _settingsPanel.gameObject.SetActive(true);
    }

    public void OpenMainMenu()
    {
        if (_mainMenuPanel.gameObject.activeInHierarchy)
            return;
        
        _settingsPanel.gameObject.SetActive(false);
        _mainMenuPanel.gameObject.SetActive(true);
    }
}
