using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyVision : MonoBehaviour
{
    public float visionRadius;
    public LayerMask playerLayer;
    public float targetX;
    
    private Vector2 target;
    private Vector2 startTarget;
    
    private AudioSource audioSource;
    private EnemyMovement enemyMovement;
    
    private bool isPlayerDetected;
    private bool isSoundPlayed;
    
    
    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        startTarget = transform.position;
        target.x = targetX;
        target.y = transform.position.y;
    }

    private void Update()
    {
        #region Follow to Target
        
        // Если игрок в не зоны видимости патрулирует между двумя точками
        if (!isPlayerDetected)
        {
            var distance = Vector2.Distance(transform.position, target);
            if (distance < 0.1f)
            {
                var tmp = target;
                target = startTarget;
                startTarget = tmp;
            }
            enemyMovement.FollowTo(target);
        }
        #endregion

        #region Check Player and folow to him
        //Проверяет наличие игрока в область и двигается к нему если обнаружит его
        var other = Physics2D.OverlapCircle(transform.position, visionRadius, playerLayer);
        if (other != null)
        {
            if (!isSoundPlayed)
            {
                audioSource.Play();
                isSoundPlayed = true;
            }
            isPlayerDetected = true;
            enemyMovement.FollowTo(other.transform.position);
        }
        else
        {
            isSoundPlayed = false;
            isPlayerDetected = false;
        }
        #endregion
    }

    /// <summary>
    /// Показывает точку патруля
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color= Color.cyan;
        Gizmos.DrawSphere(new Vector3(targetX, transform.position.y,transform.position.z), 0.1f);
    }
}
