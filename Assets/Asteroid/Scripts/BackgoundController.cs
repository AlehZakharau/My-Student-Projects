using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgoundController : MonoBehaviour
{
    public GameObject[] backgrounds;
    public float backgroundCheckTime = 1f;

    private float backgroundWidth;
    private float checkTime;

    private Transform shipTransform;
    private Vector3 currentPosition;

    private Vector3 leftMove;
    private Vector3 rightMove;
    private Vector3 upMove;
    private Vector3 downMove;

    private GameObject[] checkArray;
    // Start is called before the first frame update
    void Start()
    {
        currentPosition = backgrounds[4].transform.position;
        backgroundWidth = backgrounds[1].GetComponent<Renderer>().bounds.extents.x;
        shipTransform = GetComponent<Transform>();
        leftMove = new Vector3(-backgroundWidth * 6, 0,0);
        rightMove = new Vector3(backgroundWidth * 6, 0,0);
        upMove = new Vector3(0, backgroundWidth * 6,0);
        downMove = new Vector3(0, -backgroundWidth * 6, 0);
    }

    // Update is called once per frame
    void Update()
    {
        checkTime += Time.deltaTime;

        if (checkTime > backgroundCheckTime)
        {
            checkTime = 0f;
            CheckPosition();
        }
    }

    private void CheckPosition()
    {
        var shipPos = shipTransform.position;
        if (shipPos.x > backgroundWidth + currentPosition.x)
        {
            MoveRight();
        }
        else if (shipPos.x < -backgroundWidth + currentPosition.x)
        {
            MoveLeft();
        }
        if (shipPos.y > backgroundWidth + currentPosition.y)
        {
            MoveUp();
        }
        else if (shipPos.y < -backgroundWidth + currentPosition.y)
        {
            MoveDown();
        }
    }

    private void MoveRight()
    {
        backgrounds[0].transform.position += rightMove;
        backgrounds[1].transform.position += rightMove;
        backgrounds[2].transform.position += rightMove;
        SortBackground();
    }

    private void MoveLeft()
    {
        backgrounds[6].transform.position += leftMove;
        backgrounds[7].transform.position += leftMove;
        backgrounds[8].transform.position += leftMove;
        SortBackground();
    }

    private void MoveUp()
    {
        backgrounds[0].transform.position += upMove;
        backgrounds[3].transform.position += upMove;
        backgrounds[6].transform.position += upMove;
        SortBackground();
    }

    private void MoveDown()
    {
        backgrounds[2].transform.position += downMove;
        backgrounds[5].transform.position += downMove;
        backgrounds[8].transform.position += downMove;
        SortBackground();
    }

    private void SortBackground()
    {
        backgrounds = backgrounds.OrderBy(backgrounds => Mathf.Round(backgrounds.transform.position.x))
            .ThenBy(backgrounds => Mathf.Round(backgrounds.transform.position.y)).ToArray();
        currentPosition = backgrounds[4].transform.position;
    }
}
