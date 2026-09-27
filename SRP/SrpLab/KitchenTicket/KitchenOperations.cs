namespace SrpLab;

public sealed class KitchenOperations
{
    public IReadOnlyList<string> DetectAllergens(KitchenTicket ticket)
    {
        var hits = new HashSet<string>(
            StringComparer.OrdinalIgnoreCase);

        foreach (var (_, ingredients, _) in ticket.Items)
        {
            foreach (var ingredient in ingredients)
            {
                if (ingredient.Contains("milk") ||
                    ingredient.Contains("cheese") ||
                    ingredient.Contains("butter"))
                    hits.Add("dairy");

                if (ingredient.Contains("wheat") ||
                    ingredient.Contains("flour") ||
                    ingredient.Contains("bread"))
                    hits.Add("gluten");

                if (ingredient.Contains("peanut") ||
                    ingredient.Contains("almond") ||
                    ingredient.Contains("cashew"))
                    hits.Add("nuts");

                if (ingredient.Contains("shrimp") ||
                    ingredient.Contains("prawn") ||
                    ingredient.Contains("crab"))
                    hits.Add("shellfish");
            }
        }

        return hits.OrderBy(x => x).ToList();
    }

    public int EstimatedReadyMinutes(
        KitchenTicket ticket,
        int openStations)
    {
        if (openStations <= 0)
            openStations = 1;

        var sequential = ticket.Items.Sum(i => i.PrepMinutes);

        var parallel = (int)Math.Ceiling(
            sequential / (double)openStations);

        if (DetectAllergens(ticket).Count > 0)
            parallel += 3;

        var longest = ticket.Items.Count == 0
            ? 0
            : ticket.Items.Max(i => i.PrepMinutes);

        return Math.Max(parallel, longest);
    }

    public string ExpoLaneHint(KitchenTicket ticket)
    {
        var allergens = DetectAllergens(ticket);

        if (allergens.Count > 0)
            return "LANE-ALLERGY";

        return EstimatedReadyMinutes(ticket, 2) > 20
            ? "LANE-SLOW"
            : "LANE-FAST";
    }
}
