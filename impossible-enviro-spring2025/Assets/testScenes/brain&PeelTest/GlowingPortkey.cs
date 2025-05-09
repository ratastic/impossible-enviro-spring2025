using System.Collections;
using UnityEngine;

public class GlowingPortkey : MonoBehaviour
{
    public float flashDuration = 2f; 
    public float maxIntensity = 8f;
    public float minIntensity = 0f;

    private Light targetLight;

    void Start()
    {
        targetLight = GetComponent<Light>();
        targetLight.intensity = 0f;
        StartCoroutine(GlowingLight());

        GameObject.FindGameObjectWithTag("portkey").SetActive(false);
    }

    private IEnumerator GlowingLight()
    {
        float t = flashDuration;
        int direction = 1;

        yield return new WaitForSeconds(5f);

        GameObject.FindGameObjectWithTag("portkey").SetActive(true);

        while (true)
        {
            t += direction * Time.deltaTime;
            if (t >= flashDuration)
            {
                direction = -1;
            }

            else if (t <= 0f)
            {
                direction = 1;
            }

            targetLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, t / flashDuration);
            yield return null;
        }
    }

}


//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class GlowingPortkey : MonoBehaviour
//{
//    public float flashDuration; // how long the flash lasts
//    public float maxIntensity = 8f; // max intensity of the light flash
//    public float minIntensity = 0f; 
//    private Light targetLight; // light reference... obviously

//    void Start()
//    {
//        targetLight = GetComponent<Light>();
//        StartCoroutine("GlowingLight");
//    }

//    void Update()
//    {

//    }

//    public IEnumerator GlowingLight()
//    {
//       while (true)
//        {
//            while (targetLight.intensity <= maxIntensity) 
//            {
//                targetLight.intensity -= Mathf.Lerp(maxIntensity, minIntensity, flashDuration * Time.deltaTime);
//                yield return null;
//            }

//            while (targetLight.intensity >= minIntensity)  
//            {
//                targetLight.intensity += Mathf.Lerp(minIntensity, maxIntensity, flashDuration * Time.deltaTime);
//                yield return null;
//            }

//            yield return null;
//        }
//    }
//}
