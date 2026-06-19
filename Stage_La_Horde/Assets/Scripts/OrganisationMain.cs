using UnityEngine;

public class OrganisationMain : MonoBehaviour
{
    public float espace = 150;

    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).localPosition =
            new Vector3(i * espace, 0, 0);
        }
    }
}