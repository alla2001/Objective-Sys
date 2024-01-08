using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Objective", menuName = "Objective")]
public class ObjectivesSO : ScriptableObject
{
    public string Title;

    [TextArea]
    public string description;

    public bool removeOnCheck = false;
    public float waitBeforeRemove = 0f;
    //add any fields you want the objective Scriptable objects to have
}