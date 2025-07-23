using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    public RectTransform fill;

    private float maxWidth = 0f;

    void Start()
    {
        if (fill != null)
            maxWidth = fill.sizeDelta.x;
    }

    public void SetHealth(float current, float max)
    {
        if (maxWidth == 0f && fill != null)
        {
            maxWidth = fill.sizeDelta.x;
        }

        float width = (current / max) * maxWidth;
        fill.sizeDelta = new Vector2(width, fill.sizeDelta.y);
    }

    public void SetHealth(float current)
    {
        fill.sizeDelta = new Vector2(current, fill.sizeDelta.y);
    }
    public void SetMaxHealth(float max)
    {
        fill.sizeDelta = new Vector2(max, fill.sizeDelta.y);
    }
}
