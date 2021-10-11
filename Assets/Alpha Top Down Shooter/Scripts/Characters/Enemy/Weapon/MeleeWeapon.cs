using UnityEngine;

namespace Alpha.Characters.Enemy
{
    public class MeleeWeapon : MonoBehaviour, IWeapon
    {

        public void Fire(GameObject player)
        {
            player.GetComponent<IHealth>().Hit();
        }
    }
}