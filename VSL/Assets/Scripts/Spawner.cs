using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Fields
    [SerializeField] private Transform[] spawnPoints;

    public float timer;

    // Unity Messages
    private void Awake()
    {
        spawnPoints = GetComponentsInChildren<Transform>();
    }
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > 0.2f && GameManager.Instance.MaxUnitCount > GameManager.Instance.UnitCount)
        {
            timer = 0;
            Spawn();
        }
    }

    // Functions
    private void Spawn()
    {
        GameObject enemy = GameManager.Instance.poolMgr.Get(0);
        enemy.transform.position = spawnPoints[Random.Range(1, spawnPoints.Length)].position;
        GameManager.Instance.UnitCount++;
    }
}
