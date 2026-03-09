using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnxietyScript : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private int maxAnxiety;
    [SerializeField] private int minAnxiety;
    [SerializeField] private float tickDownSpeed = 1f;
    [SerializeField] private int currentAnxiety;
    [SerializeField] private float delayTime;

    private float smoothVelocity = 0f;
    private Coroutine tickCoroutine;

    public Slider anxietySlider;
    [SerializeField] PlayerCourageScript playerCourageScript;

    void Start()
    {
        currentAnxiety = minAnxiety;
        anxietySlider.maxValue = maxAnxiety;
        anxietySlider.value = minAnxiety;
    }

    public void ChangeAnxiety(int amount)
    {
        currentAnxiety += amount;
        anxietySlider.value = currentAnxiety;

        if (currentAnxiety >= maxAnxiety)
        {
            playerCourageScript.ChangeCourage(-damage);

            if (tickCoroutine != null)
                StopCoroutine(tickCoroutine);

            tickCoroutine = StartCoroutine(AnxietyTickDown());
        }
    }

    IEnumerator AnxietyTickDown()
    {
        yield return new WaitForSeconds(delayTime);

        while (currentAnxiety > minAnxiety)
        {
            currentAnxiety -= 1;
            yield return new WaitForSeconds(tickDownSpeed);
        }

        tickCoroutine = null; // reset
    }

    void Update()
    {
        anxietySlider.value = Mathf.SmoothDamp(
            anxietySlider.value,
            currentAnxiety,
            ref smoothVelocity,
            0.15f
        );
    }
}
