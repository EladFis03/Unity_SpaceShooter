using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemey : MonoBehaviour
{
    [SerializeField] GameObject DeathFX;
    [SerializeField] Transform Parent;
    [SerializeField] int ScorePerHit = 12;
    [SerializeField] int Hits = 50;
    /// צריך להוסיף עוד מספר 1 לכמות הפגיעות שאני רוצה, נגיד ואני רוצה שלוש פגיעות
    /// אז לרשום 4 פגיעות, הפגיעה הראשונה לא תחשב כ"ניקוד", אז להוסיף עוד אחת.
    

    ScoreBorad scoreBorad;

    // Start is called before the first frame update
    void Start()
    {
        AddnonTriggerBoxCollider();
        scoreBorad = FindObjectOfType<ScoreBorad>();
    }

    private void AddnonTriggerBoxCollider()
    {
        
       Collider boxCollider = gameObject.AddComponent<BoxCollider>();
        boxCollider.isTrigger = false;
    }
    private float hitFrame = 0;

    void OnParticleCollision(GameObject other)
    {
        if (this.hitFrame == Time.frameCount)
        {
            return;
        }
        ProcessHit();

        if (Hits <= 1)
        {
            KillEnemy();
        }

        this.hitFrame = Time.frameCount;
    }

    private void ProcessHit()
    {
        scoreBorad.ScoreHit(ScorePerHit);
        Hits = Hits - 1;
    }

    private void KillEnemy()
    {
        GameObject fx = Instantiate(DeathFX, transform.position, Quaternion.identity);
        fx.transform.parent = Parent;
        Destroy(gameObject);
    }
}
