using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillInfo : MonoBehaviour
{
    // Fields
    public string SkillCode;
    public RawImage SkillImage;
    public int RequiredLevel;
    public Button SkillButton;
    public bool IsUnlocked;
    public string SkillName;
    public string SkillDescription;

    // Events
    public event Action<SkillInfo> OnSkillSelected;

    // Unity Messages
    private void Start()
    {
        SkillButton.onClick.AddListener(() => OnSkillSelected?.Invoke(this));
        SkillButton.gameObject.SetActive(false);
    }

    // Methods
    public void RegisterClickEvent(Action<SkillInfo> action)
    {
        OnSkillSelected += action;
    }
}
