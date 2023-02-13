using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class DayNightChange : MonoBehaviour
{
    public static DayNightChange Instance;

    [SerializeField] private Material dayMaterial;
    [SerializeField] private Material nightMaterial;
    [SerializeField] private Sprite sunSprite;
    [SerializeField] private Sprite moonSprite;

    private SpriteRenderer spriteRenderer;
    private bool isDay;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float currentTime = Time.time;
        float dayPercentage = currentTime % DayNightCycle.Instance.dayDuration / DayNightCycle.Instance.dayDuration;

        if (dayPercentage >= 0.5f)
        {
            spriteRenderer.material = nightMaterial;
            spriteRenderer.sprite = moonSprite;
            isDay = false;
        }
        else
        {
            spriteRenderer.material = dayMaterial;
            spriteRenderer.sprite = sunSprite;
            isDay = true;
        }
    }

    public bool IsDay()
    {
        return isDay;
    }
}