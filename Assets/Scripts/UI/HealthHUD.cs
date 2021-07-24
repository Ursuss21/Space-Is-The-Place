using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHUD : MonoBehaviour
{
    [SerializeField]
    GameObject healthPrefab;

    List<GameObject> health;

    public static HealthHUD instance { get; set; }

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
            health.Add(Instantiate(healthPrefab, new Vector2((i * 110.0f) + 10.0f, -10.0f), Quaternion.identity));
            health[i].transform.SetParent(gameObject.transform, false);
        }
    }

    public void DecrementHealth()
    {
        Destroy(health[Player.instance.GetLives() - 1].gameObject);
        health.RemoveAt(health.Count - 1);
    }
    
    public void IncrementHealth()
    {
        health.Add(Instantiate(healthPrefab, new Vector2((health.Count * 110.0f) + 10.0f, -10.0f), Quaternion.identity));
        health[health.Count - 1].transform.SetParent(gameObject.transform, false);
    }
}
