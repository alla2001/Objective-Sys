using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneObjective : MonoBehaviour
{
    /*
     * add this script to a trigger collider GameObject and the "objectiveToBeValidate"
     * will get Validated when inSide the Trigger Zone
    */
    public ObjectivesSO objectiveToBeValidated;

    private void OnTriggerEnter(Collider other)
    {
       
        ObjectivesManager.instance.CheckObjective(objectiveToBeValidated);
    }

    private void OnTriggerExit(Collider other)
    {
        ObjectivesManager.instance.UnCheckObjective(objectiveToBeValidated);
    }
}