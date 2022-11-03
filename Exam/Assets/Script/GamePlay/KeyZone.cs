using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyZone : MonoBehaviour
{

    [SerializeField]
    private float spawnTimeConfig;

    [SerializeField] private GameObject keySample;
    private GameObject key;
    private float remainSpawnTime;
    
    // Start is called before the first frame update
    void Start()
    {
        Reset();
        GameLogic.Instance.OnKeyCollectCallback = collectKey;
    }

    public void Reset()
    {
        //TODO: Change to using ObjectPool later

        remainSpawnTime = spawnTimeConfig;
        GameObject.Destroy(key);
    }

    // Update is called once per frame
    void Update()
    {
        if (key == null)
        {
            remainSpawnTime -= Time.deltaTime;
            if (remainSpawnTime <= 0)
            {
                //spawnKey
                key = GameObject.Instantiate(keySample, transform);
            }
        }
    }

    private void collectKey()
    {
        Reset();
    }
}
