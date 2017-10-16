﻿using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using Wolverine.Logic;

namespace Wolverine
{
    /// <summary>
    /// Hediff for growing body parts.
    /// </summary>
    public class GrowingPartHediff : Hediff_AddedPart
    {
        public override bool ShouldRemove => Severity >= def.maxSeverity;

        public override void ExposeData()
        {
            base.ExposeData();
        }

        public override string TipStringExtra
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(base.TipStringExtra);
                stringBuilder.AppendLine("Efficiency".Translate() + ": " + this.def.addedPartProps.partEfficiency.ToStringPercent());
                stringBuilder.AppendLine("Growth" + ": " + Severity.ToStringPercent());
                return stringBuilder.ToString();
            }
        }

        public override void PostRemoved()
        {
            base.PostRemoved();

            if (Severity >= 1f)
            {
                BodypartUtility.ReplaceHediffFromBodypart(pawn, Part, HediffDefOf.MissingBodyPart, WolverineHediffDefOf.WolverineCuredBodypart);
            }
        }
    }
}
