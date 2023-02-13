using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Renderer))]
public class DayNightChange : MonoBehaviour
{
    public static DayNightChange Instance;

    [SerializeField] private Material dayMaterial;
    [SerializeField] private Material nightMaterial;
    [SerializeField] private Sprite sunSprite;
    [SerializeField] private Sprite moonSprite;
    [SerializeField] private float transitionDuration = 1f;

    private SpriteRenderer spriteRenderer;
    private bool isDay;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(DayCycle());
    }

    private IEnumerator DayCycle()
    {
        while (true)
        {
            float currentTime = Time.time;
            float dayPercentage = currentTime % DayNightCycle.Instance.dayDuration / DayNightCycle.Instance.dayDuration;

            Material newMaterial = dayPercentage >= 0.5f ? nightMaterial : dayMaterial;
            Sprite newSprite = dayPercentage >= 0.5f ? moonSprite : sunSprite;
            bool newIsDay = dayPercentage < 0.5f;

            if (newMaterial != spriteRenderer.material)
            {
                float elapsedTime = 0f;
                Material currentMaterial = spriteRenderer.material;

                while (elapsedTime < transitionDuration)
                {
                    spriteRenderer.material.Lerp(currentMaterial, newMaterial, elapsedTime / transitionDuration);
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                spriteRenderer.material = newMaterial;
                spriteRenderer.sprite = newSprite;
                isDay = newIsDay;
            }

            yield return null;
        }
    }

    public bool IsDay()
    {
        return isDay;
    }
}