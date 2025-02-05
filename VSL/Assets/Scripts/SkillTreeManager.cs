using System.Collections.Generic;
using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    public static SkillTreeManager Instance { get; private set; }

    [SerializeField] private List<SkillInfo> allSkills;

    // 🔹 skillAs → skillBranchA
    // 🔹 skillBs → skillBranchB
    public List<SkillInfo> SkillBranchA { get; private set; } = new List<SkillInfo>();
    public List<SkillInfo> SkillBranchB { get; private set; } = new List<SkillInfo>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        CategorizeSkills();
    }

    private void CategorizeSkills()
    {
        foreach (var skill in allSkills)
        {
            if (skill.SkillCode.StartsWith("A"))
            {
                SkillBranchA.Add(skill);
            }
            else if (skill.SkillCode.StartsWith("B"))
            {
                SkillBranchB.Add(skill);
            }
        }
    }
}
