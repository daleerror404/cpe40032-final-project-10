using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public float strength = 1f;
    public float duration = 0.5f;
    Transform camTrans;
    Vector3 oldCamPos;

    // Start is called before the first frame update
    void Start()
    {
        camTrans = Camera.main.transform;
        
    }

    // Update is called once per frame
    public void Shake()
    {
        oldCamPos = camTrans.position;
        StartCoroutine("DoShakeCamera");
    }

    IEnumerator DoShakeCamera()
    {
        float smoothness = 0.05f;
        float progress = 0f;
        float increment = smoothness / duration;
        Debug.Log("DoShakeCamera");

        while (progress < duration)
        {
            Vector3 newPos = camTrans.position + new Vector3(Random.Range(-1f, 1) * strength, Random.Range(-1f, 1) * strength);
            camTrans.position = newPos;
            progress += increment;
            yield return new WaitForSeconds(smoothness);

        }
        camTrans.position = oldCamPos;
        yield return true;
    }
}
