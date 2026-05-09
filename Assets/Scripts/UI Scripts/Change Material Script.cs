using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialScript : MonoBehaviour
{
    [SerializeField] Material[] colourMaterials;
    [SerializeField] Material greyMaterial;
    [SerializeField] GameObject[] gObject;

    private void Start()
    {
        colourMaterials = new Material[gObject.Length];
        for (int i = 0; i < gObject.Length; i++)
        {
            colourMaterials[i] = gObject[i].GetComponent<Renderer>().material;
        }
            foreach (var Gobj in gObject)
        {
            Gobj.GetComponent<Renderer>().material = greyMaterial;
        }
    }
    public void MatterialSwapper()
    {
        if (gObject != null && colourMaterials != null)
        {
           for (int i = 0; i < gObject.Length; i++) 
            {
                gObject[i].GetComponent<Renderer>().material = colourMaterials[i];
            }
        }
        else

            Debug.LogWarning("Objects" + null);
    }
}
