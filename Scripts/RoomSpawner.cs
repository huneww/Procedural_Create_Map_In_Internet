using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;

    private RoomTempletes templetes;
    private int randomValue;
    public bool isSpawn = false;

    private void Start()
    {
        templetes = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTempletes>();
        Invoke("CreateRoom", 0.1f);
    }

    public void CreateRoom()
    {
        if (isSpawn == false)
        {
            if (openingDirection == 1)
            {
                // spawn Bottom
                randomValue = Random.Range(0, templetes.bootomRooms.Length);
                Instantiate(templetes.bootomRooms[randomValue], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 2)
            {
                // spawn Top
                randomValue = Random.Range(0, templetes.topRooms.Length);
                Instantiate(templetes.topRooms[randomValue], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 3)
            {
                // spawn Left
                randomValue = Random.Range(0, templetes.leftRooms.Length);
                Instantiate(templetes.leftRooms[randomValue], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 4)
            {
                // spawn Right
                randomValue = Random.Range(0, templetes.rightRooms.Length);
                Instantiate(templetes.rightRooms[randomValue], transform.position, Quaternion.identity);
            }
            isSpawn = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            if (collision.GetComponent<RoomSpawner>().isSpawn == false && isSpawn == true)
            {
                Destroy(this.gameObject);
            }
            isSpawn = true;
        }
    }

}
