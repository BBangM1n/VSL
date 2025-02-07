using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillPopup : MonoBehaviour
{
    // Fields
    [SerializeField] private Button confirmButton;
    [SerializeField] private Button cancelButton;
    [SerializeField] private RawImage skillImage;
    [SerializeField] private Text skillNameText;
    [SerializeField] private Text skillDescriptionText;

    public string SkillCode { get; private set; }
    public int RequiredLevel { get; private set; }

    // Events
    public event Action OnConfirm;

    // Unity Messages
    private void Start()
    {
        confirmButton.onClick.AddListener(() =>
        {
            OnConfirm?.Invoke();
            gameObject.SetActive(false);
        });

        cancelButton.onClick.AddListener(() => gameObject.SetActive(false));
    }

    // Methods
    public void SetPopupInfo(SkillInfo skill)
    {
        skillImage.texture = skill.SkillImage.texture;
        skillNameText.text = skill.SkillName;
        skillDescriptionText.text = skill.SkillDescription;
        SkillCode = skill.SkillCode;
        RequiredLevel = skill.RequiredLevel;
    }
}