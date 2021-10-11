using UnityEngine;

namespace Alpha.Characters
{
    public class Obstacle : MonoBehaviour
    {
        public int enemyLayer;
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log($"other layer: {other.gameObject.layer} bullet enemy layer{enemyLayer}");
            if (other.gameObject.layer == enemyLayer)
            {
                Debug.Log($"Enemy detected");
                other.GetComponent<EnemyHealth>().Hit();
            }
        }
    }
}