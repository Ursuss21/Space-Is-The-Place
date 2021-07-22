using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    GameObject healthPrefab;

    List<GameObject> health;

    public static Health instance { get; set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        health = new List<GameObject>();
        for(int i = 0; i < Player.instance.GetLives(); ++i)
        {
            health.Add(Instantiate(healthPrefab, new Vector2(i * 110.0f, 0.0f), Quaternion.identity));
            health[i].transform.SetParent(gameObject.transform, false);
        }
    }

    public void DecrementHealth()
    {
        Destroy(health[Player.instance.GetLives()].gameObject);
    }
}
