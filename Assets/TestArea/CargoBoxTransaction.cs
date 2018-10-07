using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CargoBoxTransaction 
{
    public enum Result { Success, DoesNotFit }

    public static Result Move( TO_CargoBox from, TO_CargoBox to, List<CargoBoxContent> content )
    {
        if (CanFit(to, content) == false)
        {
            from.Content.AddRange(content);
            from.Content.Sort( (x, y) => x.Name.CompareTo(y.Name) );
            return Result.DoesNotFit;
        }

        to.Content.AddRange(content);
        to.Content.Sort((x, y) => x.Name.CompareTo(y.Name));

        return Result.Success;
    }

    private static bool CanFit( TO_CargoBox box, List<CargoBoxContent> content )
    {
        return content.Count <= box.MaxVol;
    }
}
