using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI error_1Text;
    [SerializeField] TextMeshProUGUI error_2Text;
    [SerializeField] TextMeshProUGUI bestPlayersText;
    [SerializeField] TextMeshProUGUI gameRulesText;
    [SerializeField] Button rulesButton;
    [SerializeField] Button scoreButton;
    [SerializeField] TMP_InputField nameInputField;
    [SerializeField] GameObject placeholder;

    private const float displayDuration = 1.5f;
    private const int maxNameLength = 16;

    private void Start()
    {
        nameInputField.text = DataManager.Instance.PlayerName;
        bestPlayersText.text = $"{DataManager.Instance.BestPlayersList()}";
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

    public void ClearInputField()
    {
        var input = placeholder.GetComponent<TextMeshProUGUI>();
        input.text = "";
    }

    public void SetValueInputField()
    {
        var input = placeholder.GetComponent<TextMeshProUGUI>();
        input.text = "Enter name ...";
    }

    public void GetRules()
    {
        bestPlayersText.gameObject.SetActive(false);
        gameRulesText.gameObject.SetActive(true);
        rulesButton.gameObject.SetActive(false);
        scoreButton.gameObject.SetActive(true);
    }

    public void GetScore()
    {
        gameRulesText.gameObject.SetActive(false);
        bestPlayersText.gameObject.SetActive(true);
        scoreButton.gameObject.SetActive(false);
        rulesButton.gameObject.SetActive(true);
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
