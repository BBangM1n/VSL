using UnityEngine;

public class SkillTree : MonoBehaviour
{
    // Fields
    [SerializeField] private SkillPopup skillPopup;

    // Unity Messages
    private void OnEnable()
    {
        skillPopup.OnConfirm += UnlockSkill;
    }
    private void OnDisable()
    {
        skillPopup.OnConfirm -= UnlockSkill;
    }
    private void Start()
    {
        RegisterSkillButtons();
        UpdateSkillTree();
    }

    // Functions
    private void RegisterSkillButtons()
    {
        foreach (var skill in SkillTreeManager.Instance.SkillBranchA)
        {
            skill.RegisterClickEvent(ShowPopup);
        }
        foreach (var skill in SkillTreeManager.Instance.SkillBranchB)
        {
            skill.RegisterClickEvent(ShowPopup);
        }
    }
    private void UnlockSkill()
    {
        if (GameManager.Instance.Level >= skillPopup.RequiredLevel)
        {
            GameManager.Instance.LearnedSkillCode = skillPopup.SkillCode;
            UpdateSkillTree();
        }
        else
        {
            Debug.Log("레벨이 부족합니다.");
        }
    }
    private void UpdateSkillTree()
    {
        string learnedSkillCode = GameManager.Instance.LearnedSkillCode;

        if (string.IsNullOrEmpty(learnedSkillCode))
        {
            if (SkillTreeManager.Instance.SkillBranchA.Count > 0)
            {
                SkillTreeManager.Instance.SkillBranchA[0].SkillButton.gameObject.SetActive(true);
            }
            if (SkillTreeManager.Instance.SkillBranchB.Count > 0)
            {
                SkillTreeManager.Instance.SkillBranchB[0].SkillButton.gameObject.SetActive(true);
            }
            return;
        }

        if (learnedSkillCode.StartsWith("A") && SkillTreeManager.Instance.SkillBranchB.Count > 0)
        {
            SkillTreeManager.Instance.SkillBranchB[0].SkillButton.gameObject.SetActive(false);
        }

        else if (learnedSkillCode.StartsWith("B") && SkillTreeManager.Instance.SkillBranchA.Count > 0)
        {
            SkillTreeManager.Instance.SkillBranchA[0].SkillButton.gameObject.SetActive(false);
        }

        var skillList = learnedSkillCode.StartsWith("A") ? SkillTreeManager.Instance.SkillBranchA : SkillTreeManager.Instance.SkillBranchB;
        int skillIndex = int.Parse(learnedSkillCode.Substring(1));

        for (int i = 0; i <= skillIndex; i++)
        {
            skillList[i].IsUnlocked = true;
            skillList[i].SkillButton.gameObject.SetActive(false);
        }

        if (skillIndex + 1 < skillList.Count)
        {
            var nextSkill = skillList[skillIndex + 1];
            nextSkill.SkillButton.gameObject.SetActive(true);
            skillPopup.SetPopupInfo(nextSkill);
        }
    }
    private void ShowPopup(SkillInfo skill)
    {
        skillPopup.SetPopupInfo(skill);
        skillPopup.gameObject.SetActive(true);
    }
}