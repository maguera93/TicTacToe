using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IServiceModel
{
    GameObject cellGO { get; }
    IEnumerator LoadBundle();
    void Load();
}
