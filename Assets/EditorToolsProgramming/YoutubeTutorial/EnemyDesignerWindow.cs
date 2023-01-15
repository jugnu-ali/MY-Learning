using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using Types;

public class EnemyDesignerWindow : EditorWindow
{
    Texture2D headerSectionTexture;
    Texture2D mageSectionTexture;
    Texture2D rogueSectionTexture;
    Texture2D warriorSectionTexture;

    Texture2D mageTexture;
    Texture2D warriorTexture;
    Texture2D rogueTexture;

    Color headerSectionColor = new Color(13 / 255f, 32 / 255f, 44 / 255f, 1f);

    Rect headerSection;
    Rect mageSection;
    Rect rogueSection;
    Rect warriorSection;

    Rect mageIconSection;
    Rect warriorIconSection;
    Rect rogueIconSection;

    float iconSize = 80;

    GUISkin skin;

    static MageData mageData;
    static WarriorData warriorData;
    static RogueData rogueData;

    public static MageData mageInfo { get { return mageData; } }
    public static WarriorData warriorInfo { get { return warriorData; } }
    public static RogueData rogueInfo { get { return rogueData; } }

    [MenuItem("Window/Enemy Designer Window")]
    public static void ShowWindow()
    {
        EnemyDesignerWindow window = GetWindow<EnemyDesignerWindow>();
        window.titleContent = new GUIContent("Enemy Window");
        window.minSize = new Vector2(600, 300);
        window.Show();

    }


    /// <summary>
    /// Similar to start or Awake
    /// </summary>
    private void OnEnable()
    {
        InitTexture();
        InitData();

        skin = Resources.Load<GUISkin>("guiStyles/EnemyDesignerSkin");
    }

    public static void InitData()
    {
        mageData = (MageData)ScriptableObject.CreateInstance(typeof(MageData));
        warriorData = (WarriorData)ScriptableObject.CreateInstance(typeof(WarriorData));
        rogueData = (RogueData)ScriptableObject.CreateInstance(typeof(RogueData));
    }

    void InitTexture()
    {
        headerSectionTexture = new Texture2D(1, 1);
        headerSectionTexture.SetPixel(0, 0, headerSectionColor);
        headerSectionTexture.Apply();

        mageSectionTexture = Resources.Load<Texture2D>("icons/Mage");
        rogueSectionTexture = Resources.Load<Texture2D>("icons/Rogue");
        warriorSectionTexture = Resources.Load<Texture2D>("icons/Warrior");

        mageTexture = Resources.Load<Texture2D>("icons/mageIcon");
        warriorTexture = Resources.Load<Texture2D>("icons/warriorIcon");
        rogueTexture = Resources.Load<Texture2D>("icons/rogueIcon");
    }

    /// <summary>
    /// Similar to Update & LateUpdate. Called 1 or more times per interaction
    /// </summary>
    void OnGUI()
    {
        Debug.Log(Screen.width);
        DrawLayout();
        DrawHeader();
        DrawMageSetting();
        DrawRogueSetting();
        DrawWarriorSetting();
    }

    void DrawHeader()
    {
        GUILayout.BeginArea(headerSection);

        GUILayout.Label("Enemy Designer", skin.GetStyle("Header1"));

        GUILayout.EndArea();
    }

    void DrawLayout()
    {
        headerSection.x = 0;
        headerSection.y = 0;
        headerSection.width = Screen.width;
        headerSection.height = 50;

        mageSection.x = 0;
        mageSection.y = 50;
        mageSection.width = Screen.width/3f;
        mageSection.height = Screen.height - 50;

        mageIconSection.x = (mageSection.x + mageSection.width / 2f) - iconSize/2f;
        mageIconSection.y = mageSection.y + 8;
        mageIconSection.width = iconSize;
        mageIconSection.height = iconSize;

        warriorSection.x = Screen.width / 3f;
        warriorSection.y = 50;
        warriorSection.width = Screen.width / 3f;
        warriorSection.height = Screen.height - 50;

        warriorIconSection.x = (warriorSection.x + warriorSection.width / 2f) - iconSize / 2f;
        warriorIconSection.y = warriorSection.y + 8;
        warriorIconSection.width = iconSize;
        warriorIconSection.height = iconSize;

        rogueSection.x = (Screen.width/3f) * 2;
        rogueSection.y = 50;
        rogueSection.width = Screen.width/3f;
        rogueSection.height = Screen.height - 50;

        rogueIconSection.x = (rogueSection.x + rogueSection.width / 2f) - iconSize / 2f;
        rogueIconSection.y = rogueSection.y + 8;
        rogueIconSection.width = iconSize;
        rogueIconSection.height = iconSize;

        GUI.DrawTexture(headerSection, headerSectionTexture);
        GUI.DrawTexture(mageSection, mageSectionTexture);
        GUI.DrawTexture(warriorSection, warriorSectionTexture);
        GUI.DrawTexture(rogueSection, rogueSectionTexture);
        GUI.DrawTexture(mageIconSection, mageTexture);
        GUI.DrawTexture(warriorIconSection, warriorTexture);
        GUI.DrawTexture(rogueIconSection, rogueTexture);
    }

    void DrawMageSetting()
    {
        GUILayout.BeginArea(mageSection);

        GUILayout.Space(iconSize + 8);

        GUILayout.Label("Mage", skin.GetStyle("MageHeader"));

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage", skin.GetStyle("MageField"));
        mageData.mageDmg = (MageDmgType)EditorGUILayout.EnumPopup(mageData.mageDmg);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon", skin.GetStyle("MageField"));
        mageData.wpnType = (MageWpnType)EditorGUILayout.EnumPopup(mageData.wpnType);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.MAGE);
        }

        GUILayout.EndArea();
    }

    void DrawRogueSetting()
    {
        GUILayout.BeginArea(rogueSection);

        GUILayout.Space(iconSize + 8);

        GUILayout.Label("Rogue");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage");
        rogueData.rogueDmg = (RogueDmgType)EditorGUILayout.EnumPopup(rogueData.rogueDmg);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon");
        rogueData.rogueWpn = (RogueWpnType)EditorGUILayout.EnumPopup(rogueData.rogueWpn);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.ROGUE);
        }

        GUILayout.EndArea();
    }

    void DrawWarriorSetting()
    {
        GUILayout.BeginArea(warriorSection);

        GUILayout.Space(iconSize + 8);

        GUILayout.Label("Warrior");

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage");
        warriorData.warriorDmg = (WarriorDmgType)EditorGUILayout.EnumPopup(warriorData.warriorDmg);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Weapon");
        warriorData.warriorWpn = (WarriorWpnType)EditorGUILayout.EnumPopup(warriorData.warriorWpn);
        EditorGUILayout.EndHorizontal();

        if (GUILayout.Button("Create!", GUILayout.Height(40)))
        {
            GeneralSettings.OpenWindow(GeneralSettings.SettingsType.WARRIOR);
        }

        GUILayout.EndArea();
    }
}

public class GeneralSettings : EditorWindow
{
    public enum SettingsType
    {
        MAGE,
        WARRIOR,
        ROGUE
    }

    static SettingsType dataSetting;
    static GeneralSettings window;

    public static void OpenWindow(SettingsType setting)
    {
        dataSetting = setting;
        window = (GeneralSettings)GetWindow(typeof(GeneralSettings));
        window.minSize = new Vector2(250, 200);
        window.Show();
    }

    private void OnGUI()
    {
        switch(dataSetting)
        {
            case SettingsType.MAGE:
                DrawSettings((CharacterData)EnemyDesignerWindow.mageInfo);
                break;

            case SettingsType.ROGUE:
                DrawSettings((CharacterData)EnemyDesignerWindow.rogueInfo);
                break;

            case SettingsType.WARRIOR:
                DrawSettings((CharacterData)EnemyDesignerWindow.warriorInfo);
                break;
        }

    }

    void DrawSettings(CharacterData charData)
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Prefab");
        charData.prefab = (GameObject)EditorGUILayout.ObjectField(charData.prefab, typeof(GameObject), false);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max Health");
        charData.maxHealth = EditorGUILayout.FloatField(charData.maxHealth);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Max Energy");
        charData.maxEnergy = EditorGUILayout.FloatField(charData.maxEnergy);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Power");
        charData.power = EditorGUILayout.Slider(charData.power, 0, 100);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("% Crit Chance");
        charData.critChange = EditorGUILayout.Slider(charData.critChange, 0, charData.power);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Name");
        charData.name = EditorGUILayout.TextField(charData.name);
        EditorGUILayout.EndHorizontal();

        if(charData.prefab == null)
        {
            EditorGUILayout.HelpBox("This enemy needs a [Prefab] before it can be created", MessageType.Warning);
        }
        else if(charData.name == null || charData.name.Length < 1)
        {
            EditorGUILayout.HelpBox("This enemy needs a [Name] before it can be created", MessageType.Warning);
        }
        else if (GUILayout.Button("Finish and Save", GUILayout.Height(30)))
        {
            SaveCharacterData();
            window.Close();
        }
    }

    void SaveCharacterData()
    {
        string prefabPath;
        string newPrefabPath = "Assets/EditorToolsProgramming/YoutubeTutorial/Prefabs/Characters/";
        string dataPath = "Assets/EditorToolsProgramming/YoutubeTutorial/Resources/characterData/Data/";

        switch(dataSetting)
        {
            case SettingsType.MAGE:
                // Create the .asset file
                dataPath += "mage/" + EnemyDesignerWindow.mageInfo.name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.mageInfo, dataPath);

                newPrefabPath += "mage/" + EnemyDesignerWindow.mageInfo.name + ".prefab";

                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.mageInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject magePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));

                if(!magePrefab.GetComponent<Mage>())
                {
                    magePrefab.AddComponent(typeof(Mage));
                }
                magePrefab.GetComponent<Mage>().mageData = EnemyDesignerWindow.mageInfo;

                break;

            case SettingsType.WARRIOR:

                dataPath += "warrior/" + EnemyDesignerWindow.warriorInfo.name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.warriorInfo, dataPath);

                newPrefabPath += "warrior/" + EnemyDesignerWindow.warriorInfo.name + ".prefab";

                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.warriorInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject warriorPrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));

                if (!warriorPrefab.GetComponent<Warrior>())
                {
                    warriorPrefab.AddComponent(typeof(Warrior));
                }
                warriorPrefab.GetComponent<Warrior>().warriorData = EnemyDesignerWindow.warriorInfo;

                break;

            case SettingsType.ROGUE:

                dataPath += "rogue/" + EnemyDesignerWindow.rogueInfo.name + ".asset";
                AssetDatabase.CreateAsset(EnemyDesignerWindow.rogueInfo, dataPath);

                newPrefabPath += "rogue/" + EnemyDesignerWindow.rogueInfo.name + ".prefab";

                prefabPath = AssetDatabase.GetAssetPath(EnemyDesignerWindow.rogueInfo.prefab);
                AssetDatabase.CopyAsset(prefabPath, newPrefabPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                GameObject roguePrefab = (GameObject)AssetDatabase.LoadAssetAtPath(newPrefabPath, typeof(GameObject));

                if (!roguePrefab.GetComponent<Rogue>())
                {
                    roguePrefab.AddComponent(typeof(Rogue));
                }
                roguePrefab.GetComponent<Rogue>().rogueData = EnemyDesignerWindow.rogueInfo;

                break;
        }

    }
}
