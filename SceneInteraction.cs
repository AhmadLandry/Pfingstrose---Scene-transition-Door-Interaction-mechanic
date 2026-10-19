using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneInteraction : MonoBehaviour
{
     public string sceneToLoad;           // Name of the scene you want to load
    public KeyCode interactKey = KeyCode.E; // Key to press
    private bool isPlayerInside = false; // Tracks if player is inside trigger
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string doorID; // The unique ID of this door
    public string targetSpawnID;  // NEW

    void Awake()
    {
         // Automatically use the GameObject's name as door ID
        doorID = gameObject.name.Trim();
    }

    
   private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering is the player
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            Debug.Log("Press " + interactKey + " to switch scene.");
             Debug.Log("Entered door trigger: " + doorID);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // Reset when player leaves the trigger
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
             Debug.Log("Exited trigger of door: " + doorID);
        }
    }
    private void Update()
    {
        // Only listen for key press if player is inside trigger
        if (isPlayerInside && Input.GetKeyDown(interactKey))
        {
            // Remember which door we used
            DoorManager.lastDoorID = doorID;
             DoorManager.lastDoorID = targetSpawnID.Trim();
            Debug.Log("Using door: " + doorID + " → Loading scene: " + sceneToLoad);

            // Load the scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    
}
