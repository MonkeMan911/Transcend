using UnityEngine;
using TMPro;

public class ChangeFontScript : MonoBehaviour
{
    [SerializeField] private TMP_FontAsset basicFont;
    [SerializeField] private TMP_FontAsset prideFont;

    private TMP_Text[] text;
    private bool isBasic;
    private bool isPride;

    void Start()
    {
        GameObject[] textAssets = GameObject.FindGameObjectsWithTag("Text");

        text = new TMP_Text[textAssets.Length];

        for (int i = 0; i < textAssets.Length; i++)
        {
            text[i] = textAssets[i].GetComponent<TMP_Text>();
        }

            int savedPride = PlayerPrefs.GetInt("FontIsPride", 0);

            if (savedPride == 1)
                SetFontPride();

        int savedBasic = PlayerPrefs.GetInt("FontIsBasic", 0);
        if (savedBasic == 1)
            SetFontBasic();
    }

    public void SetFontBasic()
    {
        foreach (TMP_Text t in text)
            t.font = basicFont;
            isBasic = true;
            isPride = false;
        PlayerPrefs.SetInt("FontIsBasic", 1);
        PlayerPrefs.SetInt("FontIsPride", 0);
    }

    public void SetFontPride()
    {
        foreach (TMP_Text t in text)
            t.font = prideFont;
            isPride = true;
            isBasic = false;
        PlayerPrefs.SetInt("FontIsPride", 1);
        PlayerPrefs.SetInt("FontIsBasic", 0);
    }
}