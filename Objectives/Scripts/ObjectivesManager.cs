using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class ObjectivesManager : MonoBehaviour
{
    //Card Prefab to create objectives UI with
    [Tooltip("Card Prefab to create objectives UI with")]
    public GameObject cardPrefab;

    //UI Panel to Parent the Card to
    [Tooltip("UI Panel to Parent the Card to")]
    public GameObject cardHolder;

    //Current Objectives on Display (UI)
    [Tooltip("Current Objectives on Display (UI)")]
    [SerializeField] private List<ObjectivesSO> Objectives;

    //Dictionary to keep track of each objective and its UI Card
    private List<Card> cards = new List<Card>();

    //singleton
    public static ObjectivesManager instance;

    private int index = 0;

    private void Awake()
    {
        if (instance == null) instance = this;
        else
            Destroy(this);

        GenerateCards();
    }

    public void GenerateCards()
    {
        index = 0;
        foreach (ObjectivesSO ob in Objectives)
        {
            AddCard(ob);
        }
    }

    private void ClearCards()
    {
        foreach (Card card in cards)
        {
            Destroy(card.gameObject);
            
        }
        cards.Clear();
    }

    public void ClearObjectives()
    {
        ClearCards();
        Objectives.Clear();
    }

    private void AddCard(ObjectivesSO objective)
    {
        //Code that generats the card UI for each objective
        //code has to be checked
        GameObject temp = Instantiate(cardPrefab);
        temp.transform.SetParent(cardHolder.transform, false);

        index++;
        temp.GetComponent<Card>().ChangeText(objective.Title);
        temp.GetComponent<Card>().associatedObjective = objective;
        cards.Add(temp.GetComponent<Card>());
    }

    public void AddObjective(ObjectivesSO objective)
    {
        Objectives.Add(objective);
        AddCard(objective);
    }

    public void RemoveObjective(ObjectivesSO objective)
    {
        Objectives.Remove(objective);
        RemoveCard(objective);
    }

    private void RemoveCard(ObjectivesSO objective)
    {
        List<Card> tmplist = new List<Card>();
        foreach (Card card in cards)
        {
            if (card.associatedObjective == objective)
            {
                Destroy(card.gameObject);
            }
            else
            {
                tmplist.Add(card);
            }
        }
        cards = tmplist;
        ClearCards();
        GenerateCards();
    }

    public void CheckObjective(ObjectivesSO objective)
    {
        foreach (Card card in cards)
        {
            if (card.associatedObjective == objective)
            {
                card.CheckCard();

                if (objective.removeOnCheck)
                {
                    StartCoroutine(card.Remove(objective.waitBeforeRemove));
                }
            }
        }
    }

    public void UnCheckObjective(ObjectivesSO objective)
    {
        foreach (Card card in cards)
        {
            if (card.associatedObjective == objective)
            {
                card.UnCheckCard();
            }
        }
    }
}