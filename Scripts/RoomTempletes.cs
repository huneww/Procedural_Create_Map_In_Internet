using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTempletes : MonoBehaviour
{
    public GameObject[] bootomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnBoss;
    public GameObject boos;

    private void Update()
    {
        if (waitTime <= 0 && spawnBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    Instantiate(boos, rooms[i].transform.position, Quaternion.identity);
                    spawnBoss = true;
                }
            }
        }
        else if (waitTime > -0.1f)
        {
            waitTime -= Time.deltaTime;
        }
    }

}
