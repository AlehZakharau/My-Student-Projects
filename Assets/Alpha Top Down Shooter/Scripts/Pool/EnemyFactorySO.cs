using Alpha.Characters.Enemy;
using Pool.Factory;
using UnityEngine;

namespace Pool
{
    [CreateAssetMenu(fileName = "NewEnemyFactory", menuName = "Factories/Enemy Factory", order = 1)]
    public class EnemyFactorySO : FactorySO<Enemy>
    {
        [SerializeField] private Enemy bullet;
        
        public override Enemy Create()
        {
            return Instantiate(bullet);
        }
    }
}