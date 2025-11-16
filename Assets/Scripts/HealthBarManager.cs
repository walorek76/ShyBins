using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [Header("Players")]
    [SerializeField] PlayerHealth playerHealth1;
    [SerializeField] PlayerHealth playerHealth2;

    [Header("Heart Prefab")]
    public GameObject heartPrefab;

    [Header("UI Containers")]
    public Transform heartsContainer1;
    public Transform heartsContainer2;

    private List<GameObject> hearts1 = new List<GameObject>();
    private List<GameObject> hearts2 = new List<GameObject>();

    void Start()
    {
        CreateHearts(playerHealth1.maxHealth, heartsContainer1, hearts1);
        CreateHearts(playerHealth2.maxHealth, heartsContainer2, hearts2);
    }

    void Update()
    {
        UpdateHearts(playerHealth1.currentHealth, hearts1);
        UpdateHearts(playerHealth2.currentHealth, hearts2);
    }

    void CreateHearts(int count, Transform container, List<GameObject> list)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject heart = Instantiate(heartPrefab, container);
            list.Add(heart);
        }
    }

    void UpdateHearts(int currentHealth, List<GameObject> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].SetActive(i < currentHealth);
        }
    }
}
