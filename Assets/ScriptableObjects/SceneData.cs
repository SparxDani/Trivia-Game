using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Scenes", order = 1)]
public class SceneData : ScriptableObject
{
    public bool OrdenadoPorBloques;
    public bool UniendoPorLineas;
    public bool OpcionMultiple;
}
