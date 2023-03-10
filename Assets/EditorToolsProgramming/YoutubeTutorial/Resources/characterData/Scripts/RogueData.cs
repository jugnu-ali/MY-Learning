using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenuAttribute(fileName = "New Rogue Data", menuName = "CharacterData/Rogue")]

public class RogueData : CharacterData
{
    public RogueDmgType rogueDmg;
    public RogueWpnType rogueWpn;
}
