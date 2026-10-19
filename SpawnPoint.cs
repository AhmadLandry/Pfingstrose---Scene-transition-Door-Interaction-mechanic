using System.Collections;  // Needed for IEnumerator
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [Tooltip("Must match the name of the door that leads here")]
    public string doorID;

    void Start()
    {
        StartCoroutine(SpawnPlayerNextFrame());
    }

    private IEnumerator SpawnPlayerNextFrame()
    {
        yield return null; // Wait for one frame
        string cleanedDoorID = doorID.Trim();
        string cleanedLastDoorID = DoorManager.lastDoorID.Trim();
        Debug.Log("SpawnPoint " + gameObject.name + " checking against lastDoorID = " + DoorManager.lastDoorID);
        Debug.Log($"SpawnPoint '{cleanedDoorID}' comparing to lastDoorID '{cleanedLastDoorID}'");
        if (DoorManager.lastDoorID == doorID)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
                if (rb != null) rb.linearVelocity = Vector2.zero;

                player.transform.position = transform.position;

                Debug.Log(" Spawned player at spawn point for door: " + doorID);
            }
            else
            {
                Debug.LogWarning(" Player not found in scene!");
            }
        }
        else
        {
            
            Debug.Log($"SpawnPoint '{cleanedDoorID}' does NOT match lastDoorID '{cleanedLastDoorID}'");
            Debug.Log("SpawnPoint " + gameObject.name + " does NOT match lastDoorID");
        }
    }
}

