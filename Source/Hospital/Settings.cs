using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace Hospital;

public class Settings : ModSettings
{
    public bool AcceptPatients;
    public bool AcceptSurgery;
    public float PatientLimit;
    public float BedsForColonists = 0.50f;
    public float SilverMultiplier = 1f;
    
    public override void ExposeData()
    {
        Scribe_Values.Look(ref AcceptPatients, "acceptPatients", true);
        Scribe_Values.Look(ref AcceptSurgery, "acceptSurgery", true);
        Scribe_Values.Look(ref PatientLimit, "patientLimit", 0);
        Scribe_Values.Look(ref BedsForColonists, "bedsForColonists", 0.50f);
        Scribe_Values.Look(ref SilverMultiplier, "silverMultiplier", 1f);
        base.ExposeData();
    }

    public void DoWindowContents(Rect inRect)
    {
        Listing_Standard listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);
        listingStandard.CheckboxLabeled("AcceptPatients".Translate(), ref AcceptPatients, "AcceptPatientsTooltip".Translate());
        listingStandard.CheckboxLabeled("AcceptSurgery".Translate(), ref AcceptSurgery, "AcceptSurgeryTooltip".Translate());
        listingStandard.SliderLabeled("PatientLimit".Translate(), ref PatientLimit, PatientLimit.ToString("0"), 0f, 100f,
            "PatientLimitTooltip".Translate());
        listingStandard.SliderLabeled("PctBedsForColonists".Translate(), ref BedsForColonists, BedsForColonists.ToString("0%"), 0f, 1f,
            "PctBedsForColonistsTooltip".Translate());
        listingStandard.SliderLabeled("SilverMultiplier".Translate(), ref SilverMultiplier, SilverMultiplier.ToString("0%"), 0f, 2f,
            "SilverMultiplierTooltip".Translate());        
        listingStandard.End();
    }
}