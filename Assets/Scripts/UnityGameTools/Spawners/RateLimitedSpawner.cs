using UnityEngine;
using UnityEngine.Events;
using UnityGameTools;

public class RateLimitedSpawner : MonoBehaviour
{
    public GameObjectShuffleBag shuffleBag;

    public UnityEvent<GameObject> OnSpawn;

    public float spawnedPerMinute = 0;

    private bool _isReady = true;

    public bool isContinuousSpawn = false;

    public bool spawnOnAwake;

    private void Awake()
    {
        if (!spawnOnAwake) return;
        Spawn();
    }

    public void SpawnedPerMinute(float spawnedPerMinute)
    {
        this.spawnedPerMinute = spawnedPerMinute;
    }

    public virtual void Spawn()
    {
        if (!CanSpawn())
        {
            return;
        }

        var instance = CreateInstance();
       
        OnSpawn?.Invoke(instance);

        if (spawnedPerMinute > 0)
        {
            _isReady = false;
            Invoke("Reset", 60f / spawnedPerMinute);
        }
    }

    protected virtual GameObject CreateInstance()
    {
        var prefab = shuffleBag.GetNext();
        return Instantiate(prefab, transform.position, transform.rotation);
    }

    protected virtual bool CanSpawn()
    {
        return _isReady;
    }

    public virtual void ToggleContinuousSpawn()
    {
        SetContinuousSpawn(!isContinuousSpawn);
    }

    public virtual void SetContinuousSpawn(bool continuousSpawn)
    {
        isContinuousSpawn = continuousSpawn;
    }

    public virtual void Reset()
    {
        _isReady = true;
    }

    void Update()
    {
        if (!isContinuousSpawn) return;
        
        Spawn();
    }
}
