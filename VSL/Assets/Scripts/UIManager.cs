using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Fields
    [SerializeField] private Slider expSlider;
    [SerializeField] private Text expText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text timerText;

    // Unity Messages
    private void LateUpdate()
    {
        uiExpUpdate();
        uiLevelUpdate();
        uiTimerUpdate();
    }

    private void uiExpUpdate()
    {
        float curExp = GameManager.Instance.Exp;
        float maxExp = GameManager.Instance.MaxExp;

        var targetExpValue = curExp / maxExp;

        expSlider.value = Mathf.Lerp(expSlider.value, targetExpValue, Time.deltaTime * 5f);

        int percentage = Mathf.RoundToInt(targetExpValue * 100f);

        string curExpFormatted = curExp.ToString("N0");
        string maxExpFormatted = maxExp.ToString("N0");

        expText.text = $"{curExpFormatted} / {maxExpFormatted} ({percentage}%)";
    }
    private void uiLevelUpdate()
    {
        levelText.text = "Lv." + GameManager.Instance.Level.ToString();
    }
    private void uiTimerUpdate()
    {
        float remainTime = GameManager.Instance.MaxGameTime - GameManager.Instance.GameTime;
        int min = Mathf.FloorToInt(remainTime / 60);
        int sec = Mathf.FloorToInt(remainTime % 60);
        timerText.text = string.Format("{0:D2} : {1:D2}", min, sec);
    }

    // Methods
    // Functions
    // Event Handlers

    // Unity Coroutine
    // Interface
}
