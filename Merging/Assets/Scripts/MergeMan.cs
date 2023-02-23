using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeMan : MonoBehaviour
{
    public GameObject mergedObjectPrefab; // the prefab for the object that will be created when three objects merge
    public float mergeTime = 1f; // the time it takes for three objects to merge

    private bool isMerging = false; // whether these objects are currently merging with other objects
    private MergeMan mergeTarget; // the object that these objects are merging with

    private void OnTriggerEnter(Collider other)
    {
        MergeMan otherObjects = other.gameObject.GetComponent<MergeMan>();
        if (otherObjects != null && !otherObjects.isMerging && !isMerging)
        {
            StartCoroutine(MergeCoroutine(otherObjects));
        }
    }

    private IEnumerator MergeCoroutine(MergeMan otherObjects)
    {
        isMerging = true;
        mergeTarget = otherObjects;

        // wait for mergeTime
        yield return new WaitForSeconds(mergeTime);

        // get the three objects' positions
        Vector3 position1 = transform.position;
        Vector3 position2 = mergeTarget.transform.position;
        Vector3 position3 = (transform.position + mergeTarget.transform.position) / 2f; // calculate the midpoint between the two objects

        // instantiate the new merged object at the centroid of the three objects
        Vector3 centroid = (position1 + position2 + position3) / 3f;
        GameObject mergedObject = Instantiate(mergedObjectPrefab, centroid, Quaternion.identity);

        // destroy the old objects
        Destroy(gameObject);
        Destroy(mergeTarget.gameObject);
    }
}
