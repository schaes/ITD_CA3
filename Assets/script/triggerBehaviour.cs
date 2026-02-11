using UnityEngine;

public class triggerBehaviour : MonoBehaviour
{
    public bool entered;
    public teleportZoneActivation teleportZoneManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        entered = false;
    }

    /// <summary>
    /// Handles player entering trigger zones in a specific sequence to activate teleportation zone.
    /// </summary>
    /// <param name="other"></param>
    void OnTriggerEnter(Collider other)
    {

        Debug.Log("Player entered trigger: " + gameObject.name);
        entered = true;
        teleportZoneManager.TriggerEnteredSequence();
    }
}
