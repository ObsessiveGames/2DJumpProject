using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public static DayNightCycle Instance;

    public float dayDuration = 10f;

    private float currentTime = 0f;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        float angle;

        if (dayDuration > PlayerController.Instance.Score)
        {
            angle = 360f * currentTime / (dayDuration - PlayerController.Instance.Score);
        }
        else
        {
            angle = 360f * currentTime / (dayDuration - (dayDuration - 1));
        }
        
        if (-angle <= -179f)
        {
            currentTime = 0f;
            angle = 0f;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, -angle));
    }
}