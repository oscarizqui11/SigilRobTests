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
        tempList = new ReorderableList(serializedObject, serializedObject.FindProperty(nameof(Script.commands)), true, true, true, true)
        {
            drawHeaderCallback = (Rect rect) => {
                EditorGUI.LabelField(rect, "Commands:");
            },

            drawElementCallback = (Rect rect, int index, bool isActive, bool isFocused) =>
            {
                var command = tempList.serializedProperty.GetArrayElementAtIndex(index); //new Rect(rect.x, rect.y, rect.width, rect.height)
                command.isExpanded = EditorGUI.BeginFoldoutHeaderGroup(new Rect(rect.x + 25, rect.y, rect.width, rect.height), command.isExpanded, "Command " + index + ":", EditorStyles.foldoutHeader);

                if (command.isExpanded)
                {
                    SerializedProperty scriptingActType = command.FindPropertyRelative(nameof(Script.Command.scriptingActType));
                    EditorGUI.PropertyField(new Rect(rect.x + 5, rect.y + 10, rect.width, rect.height), scriptingActType);

                    switch ((Script.Command.ScriptingActType)scriptingActType.intValue)
                    {
                        case Script.Command.ScriptingActType.talk:
                            EditorGUI.PropertyField(new Rect(rect.x + 5, rect.y, rect.width, rect.height), command.FindPropertyRelative(nameof(Script.Command.conver)));
                            break;
                        case Script.Command.ScriptingActType.moveCamera:
                            EditorGUI.PropertyField(rect, command.FindPropertyRelative(nameof(Script.Command.varVector1)));
                            EditorGUI.PropertyField(rect, command.FindPropertyRelative(nameof(Script.Command.varVector2)));
                            EditorGUI.PropertyField(rect, command.FindPropertyRelative(nameof(Script.Command.varFloat1)));
                            EditorGUI.PropertyField(rect, command.FindPropertyRelative(nameof(Script.Command.varFloat2)));
                            break;
                        case Script.Command.ScriptingActType.playAudio:
                            EditorGUI.PropertyField(rect, command.FindPropertyRelative(nameof(Script.Command.varString)));
                            break;
                        case Script.Command.ScriptingActType.stopAudio:
                            EditorGUI.PropertyField(rect, command.FindPropertyRelative(nameof(Script.Command.varString)));
                            break;
                        case Script.Command.ScriptingActType.wait:
                            EditorGUI.PropertyField(rect, command.FindPropertyRelative(nameof(Script.Command.varFloat1)));
                            break;
                    }
                }

                EditorGUI.EndFoldoutHeaderGroup();
            }
        };
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        tempList.DoLayoutList();
        serializedObject.ApplyModifiedProperties();
    }
}

