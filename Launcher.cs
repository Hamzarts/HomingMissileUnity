using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public GameObject missilePrefab;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void launchMissile(GameObject target)
    {
        if (spawnPoint)
        {
            GameObject missile = Instantiate(missilePrefab, spawnPoint.transform, true);

        }
        else
        {
            GameObject missile = Instantiate(missilePrefab, transform.position, Quaternion.identity);

        }
        missilePrefab.GetComponent<HomingMissile>().AssignTarget(target);
    }

}
