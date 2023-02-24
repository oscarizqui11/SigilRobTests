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
                var command = tempList.serializedProperty.GetArrayElementAtIndex(index);
                command.isExpanded = EditorGUI.BeginFoldoutHeaderGroup(new Rect(rect.x + 15, rect.y, rect.width - 15, EditorGUIUtility.singleLineHeight), command.isExpanded, "Command " + index + ":", EditorStyles.foldoutHeader);

                if (command.isExpanded)
                {
                    SerializedProperty scriptingActType = command.FindPropertyRelative(nameof(Script.Command.scriptingActType));
                    EditorGUI.PropertyField(new Rect(rect.x + 25, rect.y + 20, rect.width - 25, EditorGUIUtility.singleLineHeight), scriptingActType);

                    switch ((Script.Command.ScriptingActType)scriptingActType.intValue)
                    {
                        case Script.Command.ScriptingActType.talk:
                            EditorGUI.PropertyField(new Rect(rect.x + 25, rect.y + 40, rect.width - 25, EditorGUIUtility.singleLineHeight), command.FindPropertyRelative(nameof(Script.Command.conver)), new GUIContent("Conversation:"));
                            break;
                        case Script.Command.ScriptingActType.moveCamera:
                            EditorGUI.PropertyField(new Rect(rect.x + 25, rect.y + 40, rect.width - 25, EditorGUIUtility.singleLineHeight), command.FindPropertyRelative(nameof(Script.Command.varVector1)), new GUIContent("Pos:"));
                            EditorGUI.PropertyField(new Rect(rect.x + 25, rect.y + 60, rect.width - 25, EditorGUIUtility.singleLineHeight), command.FindPropertyRelative(nameof(Script.Command.varVector2)), new GUIContent("Rot:"));
                            EditorGUI.PropertyField(new Rect(rect.x + 25, rect.y + 80, rect.width - 25, EditorGUIUtility.singleLineHeight), command.FindPropertyRelative(nameof(Script.Command.varFloat1)), new GUIContent("Speed Pos:"));
                            EditorGUI.PropertyField(new Rect(rect.x + 25, rect.y + 100, rect.width - 25, EditorGUIUtility.singleLineHeight), command.FindPropertyRelative(nameof(Script.Command.varFloat2)), new GUIContent("Speed Rot:"));
                            break;
                        case Script.Command.ScriptingActType.playMusic:
                            EditorGUI.PropertyField(new Rect(rect.x + 25, rect.y + 40, rect.width - 25, EditorGUIUtility.singleLineHeight), command.FindPropertyRelative(nameof(Script.Command.varString)), new GUIContent("Music name:"));
                            break;
                        case Script.Command.ScriptingActType.playSFX:
                            EditorGUI.PropertyField(new Rect(rect.x + 25, rect.y + 40, rect.width - 25, EditorGUIUtility.singleLineHeight), command.FindPropertyRelative(nameof(Script.Command.varString)), new GUIContent("SFX name:"));
                            break;
                        case Script.Command.ScriptingActType.playVoice:
                            EditorGUI.PropertyField(new Rect(rect.x + 25, rect.y + 40, rect.width - 25, EditorGUIUtility.singleLineHeight), command.FindPropertyRelative(nameof(Script.Command.varString)), new GUIContent("Voice name:"));
                            break;
                        case Script.Command.ScriptingActType.stopMusic:
                            EditorGUI.PropertyField(new Rect(rect.x + 25, rect.y + 40, rect.width - 25, EditorGUIUtility.singleLineHeight), command.FindPropertyRelative(nameof(Script.Command.varString)), new GUIContent("Music name:"));
                            break;
                        case Script.Command.ScriptingActType.wait:
                            EditorGUI.PropertyField(new Rect(rect.x + 25, rect.y + 40, rect.width - 25, EditorGUIUtility.singleLineHeight), command.FindPropertyRelative(nameof(Script.Command.varFloat1)), new GUIContent("Time:"));
                            break;
                    }
                }

                EditorGUI.EndFoldoutHeaderGroup();
            },

            elementHeightCallback = index =>
            {
                var element = tempList.serializedProperty.GetArrayElementAtIndex(index);
                var elementHeight = EditorGUI.GetPropertyHeight(element);

                var height = 0;

                if (element.isExpanded)
                {
                    switch ((Script.Command.ScriptingActType)element.FindPropertyRelative(nameof(Script.Command.scriptingActType)).intValue)
                    {
                        case Script.Command.ScriptingActType.talk:
                            height = 95;
                            break;
                        case Script.Command.ScriptingActType.moveCamera:
                            height = 35;
                            break;
                        case Script.Command.ScriptingActType.playMusic:
                            height = 95;
                            break;
                        case Script.Command.ScriptingActType.playSFX:
                            height = 95;
                            break;
                        case Script.Command.ScriptingActType.playVoice:
                            height = 95;
                            break;
                        case Script.Command.ScriptingActType.stopMusic:
                            height = 95;
                            break;
                        case Script.Command.ScriptingActType.wait:
                            height = 95;
                            break;
                    }
                }

                return elementHeight - height;
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

