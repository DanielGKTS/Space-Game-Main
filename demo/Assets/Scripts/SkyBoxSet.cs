using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Skybox))]
public class SkyBoxSet : MonoBehaviour
{
    [SerializeField] List<Material> skyboxMaterials;

    Skybox skybox;

    void Awake()
    {
        skybox = GetComponent<Skybox>();
    }

    void OnEnable()
    {
        ChangeSkybox(0);
    }

    void ChangeSkybox(int skyboxIndex)
    {
        if (skyboxIndex >= 0 && skyboxIndex < skyboxMaterials.Count)
        {
            skybox.material = skyboxMaterials[skyboxIndex];
        }
    }
}

