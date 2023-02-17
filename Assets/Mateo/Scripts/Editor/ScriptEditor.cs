using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;

[CustomEditor(typeof(Script))]
public class ScriptEditor : Editor
{
    private ReorderableList tempList;

    private void OnEnable()
    {
        tempList = new ReorderableList(serializedObject, serializedObject.FindProperty(nameof(Script.commands)), true, true, true, true);
        tempList.drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) => {
            var command = tempList.serializedProperty.GetArrayElementAtIndex(index);

            command.isExpanded = EditorGUI.BeginFoldoutHeaderGroup(new Rect(rect.x + 10, rect.y, rect.width - 60 - 30, rect.height * 5), command.isExpanded, "Command " + index + ":", EditorStyles.foldoutHeader);

            if (command.isExpanded)
            {
                SerializedProperty scriptingActType = command.FindPropertyRelative("scriptingActType");
                EditorGUI.PropertyField(new Rect(rect.x, rect.y + rect.height, rect.width - 60 - 30, EditorGUIUtility.standardVerticalSpacing), scriptingActType);

                switch ((Script.Command.ScriptingActType)scriptingActType.intValue)
                {
                    case Script.Command.ScriptingActType.talk:
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width - 60 - 30, EditorGUIUtility.singleLineHeight), command.FindPropertyRelative("conver"));
                        break;
                    case Script.Command.ScriptingActType.moveCamera:
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + rect.height * 2, rect.width - 60 - 30, EditorGUIUtility.standardVerticalSpacing), command.FindPropertyRelative("varVector1"));
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + rect.height * 3, rect.width - 60 - 30, EditorGUIUtility.standardVerticalSpacing), command.FindPropertyRelative("varVector2"));
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + rect.height * 4, rect.width - 60 - 30, EditorGUIUtility.standardVerticalSpacing), command.FindPropertyRelative("varFloat1"));
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y + rect.height * 5, rect.width - 60 - 30, EditorGUIUtility.standardVerticalSpacing), command.FindPropertyRelative("varFloat2"));
                        break;
                    case Script.Command.ScriptingActType.playAudio:
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width - 60 - 30, EditorGUIUtility.singleLineHeight), command.FindPropertyRelative("varString"));
                        break;
                    case Script.Command.ScriptingActType.stopAudio:
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width - 60 - 30, EditorGUIUtility.singleLineHeight), command.FindPropertyRelative("varString"));
                        break;
                    case Script.Command.ScriptingActType.wait:
                        EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width - 60 - 30, EditorGUIUtility.singleLineHeight), command.FindPropertyRelative("varFloat1"));
                        break;
                }
            }
            
            EditorGUILayout.EndFoldoutHeaderGroup();
        };

        tempList.drawHeaderCallback = (Rect rect) => { 
                EditorGUI.LabelField(rect, "Commands:");
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        tempList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }

    /*public override void OnInspectorGUI()
    {
        Script script = (Script)target;

        EditorGUILayout.Space(10);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Commands:", EditorStyles.boldLabel);
        script.ArrayLeght = EditorGUILayout.IntField(script.ArrayLeght);
        EditorGUILayout.EndHorizontal();

        serializedObject.Update();

        SerializedProperty commands = serializedObject.FindProperty(nameof(Script.commands));
        commands.arraySize = script.ArrayLeght; 

        for (int i = 0; i < script.ArrayLeght; i++)
        {
            SerializedProperty command = commands.GetArrayElementAtIndex(i);

            command.isExpanded = EditorGUILayout.BeginFoldoutHeaderGroup(command.isExpanded, "Command " + i + ":", EditorStyles.foldoutHeader);

            if (command.isExpanded)
            {
                SerializedProperty scriptingActType = command.FindPropertyRelative("scriptingActType");
                EditorGUILayout.PropertyField(scriptingActType);

                switch ((Script.Command.ScriptingActType)scriptingActType.intValue)
                {
                    case Script.Command.ScriptingActType.talk:
                        EditorGUILayout.PropertyField(command.FindPropertyRelative("conver"));
                        EditorGUILayout.Space(10);
                        break;
                    case Script.Command.ScriptingActType.moveCamera:
                        EditorGUILayout.PropertyField(command.FindPropertyRelative("varVector1"));
                        EditorGUILayout.PropertyField(command.FindPropertyRelative("varVector2"));
                        EditorGUILayout.PropertyField(command.FindPropertyRelative("varFloat1"));
                        EditorGUILayout.PropertyField(command.FindPropertyRelative("varFloat2"));
                        EditorGUILayout.Space(10);
                        break;
                    case Script.Command.ScriptingActType.playAudio:
                        EditorGUILayout.PropertyField(command.FindPropertyRelative("varString"));
                        EditorGUILayout.Space(10);
                        break;
                    case Script.Command.ScriptingActType.stopAudio:
                        EditorGUILayout.PropertyField(command.FindPropertyRelative("varString"));
                        EditorGUILayout.Space(10);
                        break;
                    case Script.Command.ScriptingActType.wait:
                        EditorGUILayout.PropertyField(command.FindPropertyRelative("varFloat1"));
                        EditorGUILayout.Space(10);
                        break;
                }
            }

            EditorGUILayout.EndFoldoutHeaderGroup();
        }

        serializedObject.ApplyModifiedProperties();
    }*/
}

