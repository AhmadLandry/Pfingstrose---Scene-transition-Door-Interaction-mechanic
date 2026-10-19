using UnityEngine;

public class PlayerPersistence : MonoBehaviour
{
    private static bool playerExists = false;

    void Awake()
    {
        // If a player already exists in the new scene, destroy the duplicate
        if (playerExists)
        {
            Destroy(gameObject);
            return;
        }

        playerExists = true;
        DontDestroyOnLoad(gameObject); // Keeps this player when loading a new scene
    }
}
