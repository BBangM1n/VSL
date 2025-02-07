using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance;

    // Fields
    [SerializeField] private GameObject levelUpObject;
    public PoolManager poolMgr;
    public Player player;
    public Spawner spawner;

    [Header("Player Info")]
    public int Level = 1;
    public float MaxExp = 20;
    public float Exp = 0;
    public string LearnedSkillCode = "A1";
    [Header("Time")]
    public float MaxGameTime = 900;
    public float GameTime = 0;
    [Header("Unit")]
    public int UnitCount = 0;
    public int MaxUnitCount = 50;



    // Unity Messages
    void Awake()
    {
        Instance = this;

        MaxExp = 20;
    }
    void Update()
    {
        GameTime += Time.deltaTime;
    }

    // Methods
    public void getExp(float exp)
    {
        Exp += exp;

        if (MaxExp <= Exp)
        {
            levelUp();
        }
    }
    // Functions
    private void levelUp()
    {
        Level++;
        MaxExp = MaxExp * 1.5f;
        Exp = 0;
        StartCoroutine(levelUpAnim());
    }
    // Event Handlers

    // Unity Coroutine
    IEnumerator levelUpAnim()
    {
        levelUpObject.SetActive(true);

        yield return new WaitForSeconds(1f);

        levelUpObject.SetActive(false);
    }
}
