using UnityEngine;

namespace Alpha.Spawner
{
    [CreateAssetMenu(fileName = "NewWave", menuName = "EnemySpawn", order = 0)]
    public class Wave : ScriptableObject
    {
        public int georgeAmount;
        public int stanAmount;
        public int mikeAmount;
        public int leelaAmount;
    }
}