using System.Collections.Generic;
using UnityEngine;

public class CountLimitedSpawner : RateLimitedSpawner
{
    public int maxCount=1;

    private List<GameObject> _created = new List<GameObject>();

    protected override bool CanSpawn()
    {
        // Remove all of the deleted GameObject instances.
        _created.RemoveAll(c => c == null);

        return base.CanSpawn() && _created.Count < maxCount;
    }

    protected override GameObject CreateInstance()
    {
        var instance = base.CreateInstance();
        _created.Add(instance);
        return instance;
    }

    public void SetMaxCount(int maxCount)
    {
        this.maxCount = maxCount;
    }
}
