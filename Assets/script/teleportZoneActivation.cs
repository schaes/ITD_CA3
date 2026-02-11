using UnityEngine;

public class teleportZoneActivation : MonoBehaviour
{
    public GameObject teleportationZone; // Assign in inspector
    public GameObject completionIndicator; // Assign in inspector
    public GameObject codeHelp;
    [SerializeField] GameObject[] codeTriggerList; // Assign in inspector in the correct order
    [SerializeField] GameObject[] teleportTriggerList;
    static int currentCodeIndex;
    static int currentTeleportIndex;
    static bool sequenceComplete;

    /// <summary>
    /// Initializes the teleportation zone, completion indicator, and code help as inactive or active at the start of the game.
    /// </summary>
    void Start()
    {
        if (teleportationZone != null) // Ensure teleportation zone is not empty and initially inactive
        {
            teleportationZone.SetActive(false);
        }
        if (completionIndicator != null)
        {
            completionIndicator.SetActive(false);
        }
        if (codeHelp != null)
        {
            codeHelp.SetActive(true);
        }
    }
    

    /// <summary>
    /// Handles the logic for checking if the player has entered the triggers in the correct sequence.
    /// </summary>
    public void TriggerEnteredSequence()
    {
        if (!sequenceComplete)
        {
            if (currentCodeIndex < codeTriggerList.Length && codeTriggerList[currentCodeIndex].GetComponent<triggerBehaviour>().entered)
            {
                Debug.Log("Correct trigger entered: " + currentCodeIndex);
                currentCodeIndex++;
                if (currentCodeIndex >= codeTriggerList.Length)
                {
                    sequenceComplete = true;
                    teleportationZone.SetActive(true);
                }
            }
            else if (currentCodeIndex < codeTriggerList.Length && codeTriggerList[currentCodeIndex].GetComponent<triggerBehaviour>().entered == false)
            {
                Debug.Log("Wrong trigger entered. Resetting sequence.");
                ResetSequence();
            }
        }
        else // starts second sequence
        {
            if (codeHelp != null)
            {
                codeHelp.SetActive(false);
            }
            if (currentTeleportIndex < teleportTriggerList.Length && teleportTriggerList[currentTeleportIndex].GetComponent<triggerBehaviour>().entered)
            {
                Debug.Log("Correct trigger entered: " + currentTeleportIndex);
                currentTeleportIndex++;
                if (currentTeleportIndex >= teleportTriggerList.Length)
                {
                    sequenceComplete = true;
                    teleportationZone.SetActive(true);
                    if (completionIndicator != null)
                    {
                        completionIndicator.SetActive(true);
                    }
                }
            }
            else if (currentTeleportIndex < teleportTriggerList.Length && teleportTriggerList[currentTeleportIndex].GetComponent<triggerBehaviour>().entered == false)
            {
                Debug.Log("Wrong trigger entered. Resetting sequence.");
                ResetSequence();
            }
        }
    }


    /// <summary>
    /// Resets the trigger sequence if the player enters the wrong trigger.
    /// </summary>

    void ResetSequence()
    {
        if (!sequenceComplete)
        {
            currentCodeIndex = 0;
            foreach (GameObject trigger in codeTriggerList)
            {
                trigger.GetComponent<triggerBehaviour>().entered = false;
            }
        }
        else
        {
            currentTeleportIndex = 0;
            foreach (GameObject trigger in teleportTriggerList)
            {
                trigger.GetComponent<triggerBehaviour>().entered = false;
            }
        }



}
}
