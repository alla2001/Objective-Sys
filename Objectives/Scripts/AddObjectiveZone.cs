using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObjectiveZone : MonoBehaviour
{
    /*
     * add this script to a trigger collider GameObject and select a "objective"
     * that will get added when inSide the Trigger Zone and removed when leaving it
    */
    public ObjectivesSO objective;

    private void OnTriggerEnter(Collider other)
    {
        ObjectivesManager.instance.AddObjective(objective);
    }

    private void OnTriggerExit(Collider other)
    {
        ObjectivesManager.instance.RemoveObjective(objective);
    }
}