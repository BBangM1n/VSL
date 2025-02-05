using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfo : MonoBehaviour
{
    public string SkillCode;
    public Texture SkillImage;
    public int RequiredLevel;
    public Button SkillButton;
    public bool IsUnlocked;
    public string SkillName;
    public string SkillDescription;

    public event Action<SkillInfo> OnSkillSelected;

    private void Start()
    {
        SkillButton.onClick.AddListener(() => OnSkillSelected?.Invoke(this));
        SkillButton.gameObject.SetActive(false);
    }

    public void RegisterClickEvent(Action<SkillInfo> action)
    {
        OnSkillSelected += action;
    }
}
