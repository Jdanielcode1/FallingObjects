using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metal : MonoBehaviour
{

    [SerializeField] GameObject[] metalPrefab;

    [SerializeField] float secondSpawn = 0.3f;

    [SerializeField] float minTras;

    [SerializeField] float maxTras;

    public int destroyedCount = 0;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(MetalSpawn());


    }



    IEnumerator MetalSpawn()
    {
        while(true) {

            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(metalPrefab[Random.Range(0, metalPrefab.Length)],
            position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 0.6f);



        }
    }
}