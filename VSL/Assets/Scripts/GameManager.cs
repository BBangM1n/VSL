using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    // Delegate
    // Events

    // Definitions
    // Properties
    // Fields
    [SerializeField] private GameObject levelUpObject;
    public PoolManager poolMgr;
    public Player player;
    public Spawner spawner;

    public int Level = 1;
    public float MaxExp = 20;
    public float Exp = 0;

    public float MaxGameTime = 900;
    public float GameTime = 0;

    public int UnitCount = 0;
    public int MaxUnitCount = 50;

    public string LearnedSkillCode = "A1";

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
        
        if(MaxExp <= Exp)
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
    // Interface
}
