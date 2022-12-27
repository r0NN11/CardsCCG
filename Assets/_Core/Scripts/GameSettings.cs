using UnityEngine;

namespace _Core.Scripts
{
    [CreateAssetMenu(fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private int _minSpawnCount = 4;
        [SerializeField] private int _maxSpawnCount = 6;
        [SerializeField] private int _minChangeValue = -2;
        [SerializeField] private int _maxChangeValue = 9;
        public int GetSpawnCount() => Random.Range(_minSpawnCount, _maxSpawnCount + 1);
        public int GetNewValue() => Random.Range(_minChangeValue, _maxChangeValue + 1);
    }
}