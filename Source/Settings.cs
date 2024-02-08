using System;
using UnityEngine;
using Verse;

namespace PassionTweak
{
	public class Settings : ModSettings
	{
		public bool Enabled = true;
		public float NoPassionValue = 1.0f;
		public float MinorPassionValue = 1.25f;
		public float MajorPassionValue = 1.50f;

		public bool MadSkillsCompatibilityPatch = false;

		public override void ExposeData()
		{
			base.ExposeData();
			Scribe_Values.Look(ref NoPassionValue, "NoPassionValue", 1.0f);
			Scribe_Values.Look(ref MinorPassionValue, "MinorPassionValue", 1.25f);
			Scribe_Values.Look(ref MajorPassionValue, "MajorPassionValue", 1.50f);
		}

		public void DoWindowContents(Rect canvas)
		{
			Listing_Standard list = new Listing_Standard();
			list.ColumnWidth = canvas.width / 3;

			list.Begin(canvas);

			list.CheckboxLabeled("Vis.Enabled".Translate(), ref Enabled);

			list.Label("Vis.NoPassionValue".Translate((NoPassionValue).ToStringPercent("F0")));
			NoPassionValue = Mathf.Round(list.Slider(100f * NoPassionValue, 10f, MinorPassionValue * 100 - 1)) / 100f;

			list.Gap();

			list.Label("Vis.MinorPassionValue".Translate((MinorPassionValue).ToStringPercent("F0")));
			MinorPassionValue = Mathf.Round(list.Slider(100f * MinorPassionValue, NoPassionValue * 100 + 1, MajorPassionValue * 100 - 1)) / 100f;

			list.Gap();

			list.Label("Vis.MajorPassionValue".Translate((MajorPassionValue).ToStringPercent("F0")));
			MajorPassionValue = Mathf.Round(list.Slider(100f * MajorPassionValue, 100f, 1000f)) / 100f;

			if (list.ButtonText("Vis.ResetVanilla".Translate()))
			{
				NoPassionValue = 0.35f;
				MinorPassionValue = 1f;
				MajorPassionValue = 1.50f;
			}

			if (list.ButtonText("Vis.ResetMod".Translate()))
			{
				NoPassionValue = 1f;
				MinorPassionValue = 1.25f;
				MajorPassionValue = 1.50f;
			}

			list.End();
		}
	}
}