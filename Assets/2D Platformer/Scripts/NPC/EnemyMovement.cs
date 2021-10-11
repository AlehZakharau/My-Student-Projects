using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;

    private bool isFacingRight;
    
    /// <summary>
    /// Двигает спрайт в заданную точку
    /// </summary>
    /// <param name="target">Цель</param>
    public void FollowTo(Vector2 target)
    {
        //Проверка в какую сторону повернуть спрайт
        if (transform.position.x > target.x && isFacingRight)
        {
            Flip(false);
        }
        else if(transform.position.x < target.x && !isFacingRight)
        {
            Flip(true);
        }
        
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
        
    }
    /// <summary>
    /// Поворачивает спрайт
    /// </summary>
    /// <param name="turn"></param>
    private void Flip(bool turn)
    {
        isFacingRight = turn;
        var scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
