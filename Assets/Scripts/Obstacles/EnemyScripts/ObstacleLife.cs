using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleLife : MonoBehaviour
{
    [Tooltip("Lifespan of the Object before it is returned to the pool")]
    public float lifeTimer;
    private float fullLifeTimer;


    private void Awake()
    {
        fullLifeTimer = lifeTimer;
    }
    private void OnEnable()
    {
        lifeTimer = fullLifeTimer;
    }
    // Update is called once per frame
    void Update()
    {
        LifeTimer();
    }
    public void LifeTimer()
    {
        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0.00f)
        {
            //Destroy(gameObject);
        }
    }
}