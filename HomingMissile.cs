using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public GameObject target;
    public float manuverability = 0.05f;
    public float speed=40;
    public float minSpeed = 20;
    public GameObject explosion;

    Quaternion previousRotation;
    Vector3 previousTargetPosition;

    public float life = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        life -= Time.deltaTime;

        if (life < 0)
        {
            Destroy(gameObject);
        }
        previousRotation = transform.rotation;
        AdjustAngle();
        SpeedAdjustment();
        if (target)
        {
            previousTargetPosition = target.transform.position;
        }

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

    }

    void AdjustAngle()
    {
        if (target)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(Vector3.forward, target.transform.position - transform.position), manuverability);
        }

        if (Vector3.Distance(transform.position, target.transform.position)<0.5)
        {
            manuverability = 1;
        }

    }

    void SpeedAdjustment()
    {
        if ( target && target.transform.position == previousTargetPosition && transform.rotation != previousRotation)
        {
            if (speed > minSpeed)
            {
                speed=speed*0.99f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (explosion)
        {
            Instantiate(explosion,collision.transform.position,Quaternion.identity);
        }

        Destroy(collision.collider.gameObject);
        Destroy(gameObject);
    }

    public void AssignTarget (GameObject newTarget)
    {
        target = newTarget;
    }

    



}
