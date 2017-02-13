using System.Linq.Expressions;

namespace TIUtilities.Logic.ValidationFramework.RulesEngine
{
    ///
    /// The Rule type
    /// 
    public class Rule
    {
        ///
        /// Denotes the rules predictate (e.g. Name); comparison operator(e.g. ExpressionType.GreaterThan); value (e.g. "Cole")
        /// 
        public string ComparisonPredicate { get; set; }

        public ExpressionType ComparisonOperator { get; set; }
        public string ComparisonValue { get; set; }

        /// 
        /// The rule method that 
        /// 
        public Rule(string comparisonPredicate, ExpressionType comparisonOperator, string comparisonValue)
        {
            ComparisonPredicate = comparisonPredicate;
            ComparisonOperator = comparisonOperator;
            ComparisonValue = comparisonValue;
        }
    }

    //usage
//https: //mobiusstraits.com/2015/08/12/expression-trees/

    /*
     * List<Rule> rules = new List<Rule> 
{
     // Create some rules using LINQ.ExpressionTypes for the comparison operators
     new Rule ( "Year", ExpressionType.GreaterThan, "2012"),
     new Rule ( "Make", ExpressionType.Equal, "El Diablo"),
     new Rule ( "Model", ExpressionType.Equal, "Torch" )
};

var compiledMakeModelYearRules= PrecompiledRules.CompileRule(new List<ICar>(), rules);


    OR

    // Create a list to house your test cars
List cars = new List();

// Create a car that's year and model fail the rules validations      
Car car1_Bad = new Car { 
    Year = 2011,
    Make = "El Diablo",
    Model = "Torche"
};
            
// Create a car that meets all the conditions of the rules validations
Car car2_Good = new Car
{
    Year = 2015,
    Make = "El Diablo",
    Model = "Torch"
};

// Add your cars to the list
cars.Add(car1_Bad);
cars.Add(car2_Good);

// Iterate through your list of cars to see which ones meet the rules vs. the ones that don't
cars.ForEach(car => {
    if (compiledMakeModelYearRules.TakeWhile(rule => rule(car)).Count() > 0)
    {
        Console.WriteLine(string.Concat("Car model: ", car.Model, " Passed the compiled rules engine check!"));
    }
    else
    {
        Console.WriteLine(string.Concat("Car model: ", car.Model, " Failed the compiled rules engine check!"));
    }
});

*/
}