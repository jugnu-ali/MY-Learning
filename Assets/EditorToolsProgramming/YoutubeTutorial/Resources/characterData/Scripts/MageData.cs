using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName="New Mage Data", menuName="CharacterData/Mage")]
public class MageData : CharacterData
{
    // Start is called before the first frame update
    public MageDmgType mageDmg;
    public MageWpnType wpnType;
}
