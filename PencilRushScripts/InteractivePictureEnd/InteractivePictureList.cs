using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewInteractivePictureList",  menuName ="SO/InteractivePictureList", order = 51)]
public class InteractivePictureList : ScriptableObject
{
    [SerializeField] private List<InteractivePictureEnd> _pictures;

    public IReadOnlyList<InteractivePictureEnd> Pictures => _pictures;
}
