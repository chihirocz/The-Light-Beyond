using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(MapGenerator))]
public class MapGeneratorEditor : Editor {

	public override void OnInspectorGUI()
	{
		MapGenerator generator = (MapGenerator) target;
		bool safe = true;



		generator.cubeObj = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/Cube.prefab", typeof(GameObject));
		generator.bonus1Obj = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/Powerup_Disappear.prefab", typeof(GameObject));
		generator.bonus2Obj = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/Powerup_Freeze.prefab", typeof(GameObject));
		generator.bonus3Obj = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/Powerup_Navigate.prefab", typeof(GameObject));
		generator.bonus4Obj = AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/Powerup_PlusLife.prefab", typeof(GameObject));

		generator.sizeX = EditorGUILayout.FloatField("sizeX",generator.sizeX);
		generator.sizeY = EditorGUILayout.FloatField("sizeY",generator.sizeY);
		generator.sizeZ = EditorGUILayout.FloatField("sizeZ",generator.sizeZ);

		generator.positionX = EditorGUILayout.FloatField("positionX",generator.positionX);
		generator.positionY = EditorGUILayout.FloatField("positionY",generator.positionY);
		generator.positionZ = EditorGUILayout.FloatField("positionZ",generator.positionZ);

		generator.maxRotationX = EditorGUILayout.FloatField("maxRotationX",generator.maxRotationX);
		generator.maxRotationY = EditorGUILayout.FloatField("maxRotationY",generator.maxRotationY);
		generator.maxRotationZ = EditorGUILayout.FloatField("maxRotationZ",generator.maxRotationZ);

		generator.minDepth = EditorGUILayout.IntField("minDepth",generator.minDepth);
		generator.maxDepth = EditorGUILayout.IntField("maxDepth",generator.maxDepth);
		generator.timesToMove = EditorGUILayout.IntField("times to move",generator.timesToMove);
		generator.timesToUnsafeMove = EditorGUILayout.IntField("times to unsafe move",generator.timesToUnsafeMove);
		generator.maxMove = EditorGUILayout.IntField("maxMove",generator.maxMove);

		generator.safeZone = EditorGUILayout.FloatField("safeZone",generator.safeZone);

		generator.pBonus = EditorGUILayout.IntField("pBonus",generator.pBonus);
		generator.pCube = EditorGUILayout.IntField("pCube",generator.pCube);
		generator.pRozdel = EditorGUILayout.IntField("pRozdel",generator.pRozdel);

		if(GUILayout.Button("Generate"))
		{
			generator.Generate();
		}

		if(GUILayout.Button("Move"))
		{
			generator.skusPosunut();
		}

		if(GUILayout.Button("Make Safe"))
		{
			generator.makeSafe();
		}

		if(GUILayout.Button("unsafe move"))
		{
			safe = false;
			generator.unsaveMove();
		}

		if(GUILayout.Button("try to make no collision"))
		{
			safe = generator.makeNonTuching();
		}

		EditorGUILayout.DelayedTextField("safe: " + safe.ToString());
	}
}
