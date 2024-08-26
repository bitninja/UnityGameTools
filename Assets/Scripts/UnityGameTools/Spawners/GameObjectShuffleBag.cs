using System;
using UnityEngine;

namespace UnityGameTools
{
    [Serializable]
    public class GameObjectShuffleBag : MonoBehaviour
    {
        private ShuffleBag<GameObject> _bag;

        public GameObjectShuffleBagEntry[] entries;

        private void Awake()
        {
            _bag = new ShuffleBag<GameObject>(entries);
        }

        public GameObject GetNext() => _bag.Next;        
    }

    [Serializable]
    public class GameObjectShuffleBagEntry : ShuffleBag<GameObject>.IShuffleBagEntry
    {
        public int occurenceCount;
        public GameObject gameObject;

        public int OccurenceCount => occurenceCount;

        public GameObject Item => gameObject;
    }
}