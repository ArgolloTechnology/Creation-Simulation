using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ElementCombination : MonoBehaviour
{
	public ElementData elementA;
	public ElementData elementB;

	// Lista de todos os ElementDatas dispon�veis no jogo
	public ElementData[] allElements;

	private void Start()
	{
		allElements = Resources.LoadAll("Elements", typeof(ElementData)).Cast<ElementData>().ToArray();
	}

	// M�todo para combinar dois elementos
	public ElementData CombineElements()
	{
		if (elementA != null && elementB != null)
		{
			// Verifica se algum ElementData tem uma combina��o com o elementoA e elementoB
			foreach (ElementData element in allElements)
			{
				ElementData combination = element.GetCombination(elementA,elementB);
				if (combination != null)
				{
					Debug.Log($"Combina��o encontrada: {elementA.name} + {elementB.name} = {combination.name}");
					return combination;
				}
			}

			Debug.Log($"N�o h� combina��o conhecida para: {elementA.name} + {elementB.name}");
		}

		return null;
	}

	private void Update()
	{
		CombineElements();
	}
}
