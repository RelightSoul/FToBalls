using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
using TMPro;
#endif

public class MenuUIHandler : MonoBehaviour
{
    private Button startButton;
    private Button exitButton;

    public TextMeshProUGUI error_1Text;
    public TextMeshProUGUI error_2Text;
    public TextMeshProUGUI bestFiveText;
    public TMP_InputField nameInputField;

    private void Start()
    {
        startButton = GameObject.Find("Start Button").GetComponent<Button>();
        exitButton = GameObject.Find("Exit Button").GetComponent<Button>();

        startButton.onClick.AddListener(StartGame);
        exitButton.onClick.AddListener(ExitGame);

        bestFiveText.text = $"\tTop-5" +
            $"\n1 {DataManager.Instance.bestPlayerName} {DataManager.Instance.bestPlayerScore}";
    }

    public void StartGame()
    {
        int maxNameLength = 16;

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
            DataManager.Instance.playerName = nameInputField.text;
            SceneManager.LoadScene(1);
        }
    }

    private void Error_1Message()
    {
        float displayDuration = 1.5f;

        error_1Text.gameObject.SetActive(true);
        Invoke("Error_1Deactivate", displayDuration);
    }
    private void Error_1Deactivate()
    {
        error_1Text.gameObject.SetActive(false);
    }

    private void Error_2Message()
    {
        float displayDuration = 1.5f;

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
