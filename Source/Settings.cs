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

			string str = NoPassionValue.ToString();
			list.Label("Vis.NoPassionValue".Translate());
			list.TextFieldNumeric(ref NoPassionValue, ref str);
			list.Gap();

			str = MinorPassionValue.ToString();
			list.Label("Vis.MinorPassionValue".Translate());
			list.TextFieldNumeric(ref MinorPassionValue, ref str);
			list.Gap();

			str = MajorPassionValue.ToString();
			list.Label("Vis.MajorPassionValue".Translate());
			list.TextFieldNumeric(ref MajorPassionValue, ref str);

			list.End();
		}
	}
}