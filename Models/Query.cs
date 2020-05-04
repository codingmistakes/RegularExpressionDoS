using System.ComponentModel.DataAnnotations;

namespace RegularExpressionDoS.Models
{
    public class Query
    {
        // Requirement RQ-103: Users should be able to search two words
        // Example 1: apple banana
        // Example 2: 23abc back

        // https://referencesource.microsoft.com/#System.ComponentModel.DataAnnotations/DataAnnotations/RegularExpressionAttribute.cs,1f7d1bfbe78b4626
        // [RegularExpression("^([a-zA-Z0-9]+ ?)+$")]
        public string Search { get; set; }
    }
}
