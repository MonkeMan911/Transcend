using UnityEngine;

public class GradualColourFill : MonoBehaviour
{
    [SerializeField] private BossPhase2BoxHoverScript box;

    [SerializeField] private SpriteRenderer[] spriteRenderer;

    void Start()
    {
        GameObject[] boxes = GameObject.FindGameObjectsWithTag("FilledBox");

        spriteRenderer = new SpriteRenderer[boxes.Length];

        for (int i = 0; i < boxes.Length; i++)
        {
            spriteRenderer[i] = boxes[i].GetComponent<SpriteRenderer>();
        }

        if (spriteRenderer.Length < 4)
        {
            Debug.LogError("Not enough SpriteRenderers found. Need at least 4.");
        }
    }

    void Update()
    {
        if (spriteRenderer.Length < 4 || box == null) return;

        SetAlpha(spriteRenderer[3], box.boxProgress1, box.targetNum);

        SetAlpha(spriteRenderer[2], box.boxProgress2, box.targetNum);

        SetAlpha(spriteRenderer[1], box.boxProgress3, box.targetNum);

        SetAlpha(spriteRenderer[0], box.boxProgress4, box.targetNum);
    }

    private void SetAlpha(SpriteRenderer sr, float progress, float target)
    {
        if (sr == null || target <= 0f) return;

        float t = Mathf.Clamp01(progress / target); // 0 → 1
        Color c = sr.color;
        c.a = t;
        sr.color = c;
    }
}
