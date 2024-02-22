Console.Write("Which filter do you want to use? (1=Even, 2=Positive, 3=MultipleOfTen) ");
int choice = Convert.ToInt32(Console.ReadLine());

Sieve sieve = choice switch {
	1 => new Sieve(n => n % 2 == 0),
	2 => new Sieve(n => n > 0),
	3 => new Sieve(n => n % 10 == 0)
};

while (true) {
	Console.Write("Enter a number: ");
	int number = Convert.ToInt32(Console.ReadLine());

	string goodOrEvil = sieve.IsGood(number) ? "good" : "evil";
	Console.WriteLine($"That number is {goodOrEvil}.");
}

public class Sieve {
	private Func<int, bool> _decisionFunction;

	public Sieve(Func<int, bool> decisionFunction) => _decisionFunction = decisionFunction;

	public bool IsGood(int number) {
		return _decisionFunction(number);
	}
}

// Question: Does this change make the program shorter or longer.
// Answer: Shorter; I eliminated 3 lines

// Question: Does this change make the program easier or harder to read?
// Answer: Harder. No longer do I have a function being passed as a delegate named "IsEven"; 
//         I have to infer what it does by looking at the code.