using UnityEngine;
using UnityEditor;
using System.Collections;

public class ScriptableObjectAssetCreator {
	
	[MenuItem("Assets/ScriptableObject/Create asset(s)")]
	static private void MenuCreateSO() {

		string[] allGUIDS = Selection.assetGUIDs;
		foreach (string guid in allGUIDS) {
			string sourceFilePath = AssetDatabase.GUIDToAssetPath(guid);
			Object o = AssetDatabase.LoadAssetAtPath(sourceFilePath, typeof(MonoScript));
			System.Type t = ScriptableObjectTypeInAsset(o);
			if (t == null) {
				continue;
			}

			// Examine the selected type.
			if (t.ContainsGenericParameters) {
				// We cannot build an instance of this thing because it's
				// a generic class with unassigned generic parameters.

				// Update: Unity 4.6 does not advertise open generic types in MonoScripts.
				// So in that version this test is useless. This is undocumented though.
				EditorUtility.DisplayDialog("Unable to instantiate this type",
				                            string.Format("The type {0} found in script file {1} inherits " +
				              "from {2}, but it cannot be instantiated because it's " +
				              "generic and not all of its generic parameters are set.\n" +
				              "You may want to create another script file defining a child class " +
				              "were the generic parameters are set and instantiate that.",
				              t, sourceFilePath, typeof(ScriptableObject)), "OK");
			} else {
				// Let's try to create that stuff ...
				ScriptableObject newAsset = ScriptableObject.CreateInstance(t) as ScriptableObject;
				int extPos = sourceFilePath.LastIndexOf('.');
				string assetBaseName = sourceFilePath.Substring(0, extPos);
				string desiredName = assetBaseName + ".asset";
				int i = 1;
				const int maxTries = 1000;
				while (i < maxTries) {
					if (System.IO.File.Exists(desiredName) || System.IO.Directory.Exists(desiredName)) {
						i++;
						desiredName = assetBaseName + " " + i + ".asset";
					} else {
						try {
							AssetDatabase.CreateAsset(newAsset, desiredName);
						} catch {
							EditorUtility.DisplayDialog("Unable to instantiate this ScriptableObject",
							    string.Format("The type {0} found in script file {1} " +
							    "could not be instantiated because of reasons.",
							    t, sourceFilePath), "OK");
						}
						break;
					}
				}
			}
		}
	}
	
	[MenuItem("Assets/ScriptableObject/Create asset(s)", true)]
	static private bool MenuCreateSOValidation() {
		string[] allGUIDS = Selection.assetGUIDs;
		foreach (string guid in allGUIDS) {
			string assetPath = AssetDatabase.GUIDToAssetPath(guid);
			Object o = AssetDatabase.LoadAssetAtPath(assetPath, typeof(MonoScript));
			if (IsScriptableObjectSourceAsset(o)) {
				return true;
			}
		}
		return false;
	}

	static private bool IsScriptableObjectSourceAsset(Object asset) {
		return ScriptableObjectTypeInAsset(asset) != null;
	}

	static private System.Type ScriptableObjectTypeInAsset(Object asset) {
		MonoScript script = asset as MonoScript;
		if (script == null) {
			return null;
		}

		System.Type foundType = script.GetClass();
		if (foundType != null && typeof(ScriptableObject).IsAssignableFrom(foundType)) {
			return foundType;
		} else {
			return null;
		}
	}

}
