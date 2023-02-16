using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Script))]
public class ScriptEditor : Editor
{
    public override void OnInspectorGUI()
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

        EditorGUILayout.Space(10);

        bool showFoldout = true;

        for (int i = 0; i < script.ArrayLeght; i++)
        {
            SerializedProperty command = commands.GetArrayElementAtIndex(i);

            showFoldout = EditorGUILayout.BeginFoldoutHeaderGroup(showFoldout, "Command " + i + ":", EditorStyles.foldoutHeader);

            if (showFoldout)
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
    }
}

