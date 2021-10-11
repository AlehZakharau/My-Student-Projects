using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UIController : MonoBehaviour
{
    public GameObject ammoSprite;
    public GameObject ship;

    public float distanceAmmo = 30f;
    public Vector3 ammoPosition;
    // Start is called before the first frame update
    private GunContoller shipC;
    private uint ammoCapacity;
    
    private Vector3 spritePosition = new Vector3(-300, -180, 0);
    private GameObject[] ammoSprites;
    void Start()
    {
        shipC = ship.GetComponent<GunContoller>();
        ammoCapacity = shipC.ammoCapacity;
        ammoSprites = new GameObject[ammoCapacity];
        shipC.Launch += BulletLaunch;
        shipC.ReloadBullets += Reload;
        LoadSprites();
    }

    private void LoadSprites()
    {
        for (var i = 0; i < ammoCapacity; i++)
        {
            var ammoSprite = Instantiate(this.ammoSprite, ammoPosition + new Vector3(distanceAmmo*i,0,0), Quaternion.identity);
            ammoSprite.transform.SetParent (gameObject.transform, false);
            ammoSprites[i] = ammoSprite;
        }
    }

    private void BulletLaunch()
    {
        ammoSprites[shipC.ammoCapacity].SetActive(false);
    }

    private void Reload()
    {
        foreach (var sprite in ammoSprites)
        {
            sprite.SetActive(true);
        }
    }
}
