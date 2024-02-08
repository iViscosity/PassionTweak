using HarmonyLib;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace PassionTweak
{
	[HarmonyPatch(typeof(SkillUI), nameof(SkillUI.GetLearningFactor))]
	public class Patch_GetLearningFactor
	{
		public static void Postfix(ref float __result, Passion passion)
		{
			switch (passion)
			{
				case Passion.None:
					__result = PassionTweak.Settings.NoPassionValue;
					break;
				case Passion.Minor:
					__result = PassionTweak.Settings.MinorPassionValue;
					break;
				case Passion.Major:
					__result = PassionTweak.Settings.MajorPassionValue;
					break;
			}
		}
	}
}