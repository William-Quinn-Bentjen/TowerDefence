using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//A modified version of It3ration's answer to https://answers.unity.com/questions/489942/how-to-make-a-readonly-property-in-inspector.html
//use by adding [ReadOnly] infront a value (if the variable is private or protected use [ReadOnly, SerializeField])
public class ReadOnlyAttribute : PropertyAttribute
{

}
#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
public class ReadOnlyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        GUI.enabled = true;
    }
}
#endif
