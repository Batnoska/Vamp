using System;
using System.Collections;
using UnityEngine;

public class BloodPoolFade : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    void Start()
    {
        StartCoroutine(FadeOut());
    }
    
    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(2f);

        float time = 0;

        Color color =
            spriteRenderer.color;

        while (time < 2f)
        {
            time += Time.deltaTime;

            color.a =
                Mathf.Lerp(1, 0, time / 2f);

            spriteRenderer.color = color;

            yield return null;
        }

        Destroy(gameObject);
    }
}
