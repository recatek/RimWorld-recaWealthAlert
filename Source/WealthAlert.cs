using RimWorld;
using Verse;

namespace recatek.WealthAlert
{
    [StaticConstructorOnStartup]
    public class WealthAlertMod : Mod
    {
        public WealthAlertMod(ModContentPack content) : base(content)
        {
            // Nothing to do
        }
    }

    public class Alert_WealthAlert : Alert
    {
        private static int GetWealth()
        {
            int wealth = 0;
            if (Find.CurrentMap != null && Find.CurrentMap.wealthWatcher != null)
                wealth += (int)Find.CurrentMap.wealthWatcher.WealthTotal;
            if (Find.CurrentGravship != null && (Find.CurrentGravship.Tile == Find.CurrentMap?.Tile))
                wealth += (int)Find.CurrentGravship.PlayerWealthForStoryteller;
            return wealth;
        }

        public override string GetLabel()
        {
            return "recatek.WealthAlert.Label".Translate(GetWealth());
        }

        public override AlertReport GetReport()
        {
            return GetWealth() > 0 ? AlertReport.Active : AlertReport.Inactive;
        }
    }
}
