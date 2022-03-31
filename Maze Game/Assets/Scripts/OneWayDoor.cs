using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayDoor : MonoBehaviour
{
    public GameObject door;
    private void Awake()
    {
        Reset();
    }
    public void Reset()
    {
        door.SetActive(false);
    }
    private void OnTriggerExit(Collider other)
    {
        Invoke(nameof(Activate), 0.1f);
    }
    private void Activate() {
        door.SetActive(true);
    }
}
