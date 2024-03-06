using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{
    private RoomTempletes templetes;

    private void Start()
    {
        templetes = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTempletes>();
        templetes.rooms.Add(this.gameObject);
    }
}
