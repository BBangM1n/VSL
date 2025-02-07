using UnityEngine;

public class SkillManager : MonoBehaviour
{
    // Fields
    [SerializeField] private GameObject[] skill1Prefabs;
    [SerializeField] private CoolDown[] coolDowns; // 추후 수정

    // Methods
    public void CastSkill(string skillName, Vector3 direction, int skillLevel = 1)
    {

        GameObject skill = null;

        switch (skillName)
        {
            case "Skill1":
                if (direction != Vector3.zero)
                {
                    skill = Instantiate(skill1Prefabs[0], transform.position, Quaternion.identity);
                    skill.GetComponent<SkillBase>().SetDirection(direction);
                    StartCoroutine(coolDowns[0].CoolTimeCoroutine(5f));
                }
                break;

            case "Skill2":
                skill = Instantiate(skill1Prefabs[1], transform.position, Quaternion.identity);
                Skill2 skill2 = skill.GetComponent<Skill2>();
                if (skill2 != null)
                {
                    skill2.skillLevel = skillLevel;
                    skill2.SetDirection(Vector3.zero);
                    skill2.ActivateSkill();
                    StartCoroutine(coolDowns[1].CoolTimeCoroutine(10f));
                }
                break;
            default:
                Debug.LogWarning("Unknown skill: " + skillName);
                break;
        }
    }
}
