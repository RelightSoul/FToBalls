using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using TMPro;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI error_1Text;
    public TextMeshProUGUI error_2Text;
    public TextMeshProUGUI bestFiveText;
    public TMP_InputField nameInputField;

    private const float displayDuration = 1.5f;
    private const int maxNameLength = 16;

    private void Start()
    {
        bestFiveText.text = $"\tTop-5\n1 {DataManager.Instance.BestPlayerName} {DataManager.Instance.BestPlayerScore}";
    }

    public void StartGame()
    {
        if (nameInputField.text == "")
        {
            Error_1Message();
            return;
        }
        if (nameInputField.text.Length > maxNameLength)
        {
            Error_2Message();
            return;
        }
        else
        {
            DataManager.Instance.PlayerName = nameInputField.text;
            SceneManager.LoadScene(1);
        }
    }

    private void Error_1Message()
    {   
        error_1Text.gameObject.SetActive(true);
        Invoke("Error_1Deactivate", displayDuration);
    }
    private void Error_1Deactivate()
    {
        error_1Text.gameObject.SetActive(false);
    }

    private void Error_2Message()
    {
        error_2Text.gameObject.SetActive(true);
        Invoke("Error_2Deactivate", displayDuration);
    }
    private void Error_2Deactivate()
    {
        error_2Text.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
