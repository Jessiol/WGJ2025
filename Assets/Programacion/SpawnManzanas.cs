using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManzanas : MonoBehaviour
{
    float minPosX, maxPosX, minPosY, maxPosY;
    [SerializeField] GameObject food, leftBorder, rightBorder, bottomBorder, topBorder;


    // Start is called before the first frame update
    void Start()
    {
        float foodSizeX = food.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        float foodSizeY = food.GetComponent<SpriteRenderer>().sprite.bounds.size.y;

        minPosX = leftBorder.transform.position.x + leftBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2 + foodSizeX / 2;

        maxPosX = rightBorder.transform.position.x - rightBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2 - foodSizeX / 2;

        minPosY = bottomBorder.transform.position.y + bottomBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2 + foodSizeY / 2;

        maxPosY = topBorder.transform.position.y - topBorder.GetComponent<SpriteRenderer>().sprite.bounds.size.y / 2 - foodSizeY / 2;

        InvokeRepeating("Spawn", 2f, 1f);
    }

    void Spawn()
    {
        float posX = Random.Range(minPosX, maxPosX);
        float posY = Random.Range(minPosY, maxPosY);
        Vector3 randomPos = new Vector3(posX, posY);
        Instantiate(food, randomPos, Quaternion.identity, transform);
    }

}
