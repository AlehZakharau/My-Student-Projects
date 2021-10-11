using Alpha.Characters.Enemy;
using Pool.Factory;
using UnityEngine;

namespace Pool
{
    [CreateAssetMenu(fileName = "NewEnemyPool", menuName = "Pool/Enemy Pool", order = 1)]
    public class EnemyPoolSO : ComponentPoolSO<Enemy>
    {
        [SerializeField] private EnemyFactorySO factory;

        public override IFactory<Enemy> Factory 
        {
            get => factory; 
            set => factory = value as EnemyFactorySO; 
        }
    }
}