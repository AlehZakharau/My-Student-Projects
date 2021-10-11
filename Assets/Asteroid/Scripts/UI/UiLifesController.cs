using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UiLifesController : MonoBehaviour
{
    public GameObject lifeSprite;
    public GameObject ship;

    public float distanceLife = 30f;
    public Vector3 lifePosition;

    private ShipController shipC;
    private GameObject[] lifeSprites;

    private uint lifes;
    // Start is called before the first frame update
    void Start()
    {
        shipC = ship.GetComponent<ShipController>();
        lifes = shipC.lifes;
        lifeSprites = new GameObject[lifes];
        shipC.LoseLifeUI += LoseLife;
        LoadSprites();
    }

    private void LoadSprites()
    {
        for (var i = 0; i < lifes; i++)
        {
            var life = Instantiate(this.lifeSprite, lifePosition + new Vector3(distanceLife * i, 0, 0),
                Quaternion.identity);
            life.transform.SetParent(this.transform, false);
            lifeSprites[i] = life;
        }
    }

    private void LoseLife()
    {
        lifes -= 1;
        lifeSprites[lifes].SetActive(false);
    }
}
