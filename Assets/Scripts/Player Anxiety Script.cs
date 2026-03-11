using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnxietyScript : MonoBehaviour
{
    [Header("Anxiety Settings")]
    [SerializeField] private int damage = 1;
    [SerializeField] private int maxAnxiety = 10;
    [SerializeField] private int minAnxiety = 0;
    [SerializeField] private float tickDownSpeed = 0.5f;
    [SerializeField] private float cooldownTime = 2f;    

    private int currentAnxiety;
    private float smoothVelocity = 0f;

    private Coroutine tickCoroutine;
    private float cooldownTimer = 0f;

    public Slider anxietySlider;
    [SerializeField] PlayerCourageScript playerCourageScript;

    void Start()
    {
        currentAnxiety = minAnxiety;
        anxietySlider.maxValue = maxAnxiety;
        anxietySlider.value = minAnxiety;

        tickCoroutine = StartCoroutine(AnxietyTickDown());
    }

    public void ChangeAnxiety(int amount)
    {
        currentAnxiety = Mathf.Clamp(currentAnxiety + amount, minAnxiety, maxAnxiety);
        anxietySlider.value = currentAnxiety;


        cooldownTimer = cooldownTime;


        if (currentAnxiety >= maxAnxiety)
        {
            playerCourageScript.ChangeCourage(-damage);
        }
    }

    IEnumerator AnxietyTickDown()
    {
        while (true)
        {

            if (cooldownTimer > 0)
            {
                cooldownTimer -= Time.deltaTime;
                yield return null;
                continue;
            }

            if (currentAnxiety > minAnxiety)
            {
                currentAnxiety -= 1;
                yield return new WaitForSeconds(tickDownSpeed);
            }
            else
            {
                yield return null;
            }
        }
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
