using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public GameObject text;
    public GameObject checkMark;
    public ObjectivesSO associatedObjective;
    private bool Checked;

    public void ChangeText(string text)
    {
        this.text.GetComponent<TextMeshProUGUI>().text = text;
        //change the text of the card to objective text
    }

    public IEnumerator Remove(float time)
    {
        yield return new WaitForSeconds(time);
        ObjectivesManager.instance.RemoveObjective(associatedObjective);
    }

    public void CheckCard()
    {
        checkMark.SetActive(true);
        Checked = true;

        /*add code here to excute when card gets checked*/
    }

    public void UnCheckCard()
    {
        checkMark.SetActive(false);
        Checked = false;

        /*add code here to excute when card gets Unchecked*/
    }
}