using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewElement", menuName = "ElementData")]
public class ElementData : ScriptableObject
{
	public new string name;
	public List<ElementData> combinations = new List<ElementData>();

	// Método para verificar se este elemento combina com outro
	public ElementData GetCombination(ElementData ElementA, ElementData ElementB)
	{
		if (combinations.Count == 0) return null;
		if (combinations[0] != ElementA) return null;
		if (combinations[1] != ElementB) return null;

		return this;
	}
}
