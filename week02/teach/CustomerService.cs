/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(10);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: User inputs a max size of 0. The system should default to a max size of 10.
        // Expected Result: [size=0 max_size=10 => ]
        Console.WriteLine("Test 1");
        var service1 = new CustomerService(0);
        Console.WriteLine(service1);

        // Defect(s) Found: None.

        Console.WriteLine("=================");
        
        // Test 2
        // Scenario: Create a queue of size 10 and add one customer. 
        // Verify the customer is actually in the queue.
        // Expected Result: [size=1 max_size=10 => Name (ID) : Problem]
        Console.WriteLine("Test 2");
        var service2 = new CustomerService(10);

        service2.AddNewCustomer();

        Console.WriteLine(service2);

        // Defect(s) Found: None.

        Console.WriteLine("=================");

        // Test 3
        // Scenario: Create a queue of size 2. Add two customers, then try to add a third.
        // Expected Result: The third attempt should display "Maximum Number of Customers in Queue."
        Console.WriteLine("Test 3");
        var service3 = new CustomerService(2);

        service3.AddNewCustomer(); // Add Customer 1.
        service3.AddNewCustomer(); // Add Customer 2.
        service3.AddNewCustomer(); // Add Customer 3. This should trigger the error message.

        Console.WriteLine(service3);

        // Defect(s) Found: Outputting 3 customers even though the max size is 2. The error message is not being displayed.

        Console.WriteLine("=================");

        // Test 4
        // Scenario: Add two customers and then serve the first one.
        // Expected Result: Display the first customer's details and remove them.
        Console.WriteLine("Test 4");

        var service4 = new CustomerService(10);
        service4.AddNewCustomer(); // Enter "User A"
        service4.AddNewCustomer(); // Enter "User B"
        service4.ServeCustomer(); 

        Console.WriteLine(service4);

        // Defect(s) Found: It served User B instead of User A. The first customer is not being removed from the queue before serving, so the second customer is being served instead of the first.

        Console.WriteLine("=================");
        // Test 5
        // Scenario: Try to serve a customer when the queue is empty.
        // Expected Result: Error message (e.g., "The queue is empty") should display.
        Console.WriteLine("Test 5");

        var service5 = new CustomerService(10);
        service5.ServeCustomer(); 

        Console.WriteLine(service5);
        
        // Defect(s) Found: The code does not check if the queue is empty before trying to serve a customer, which leads to an out-of-range error when it tries to access the first element of the queue.

        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count > _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        _queue.RemoveAt(0);
        var customer = _queue[0];
        Console.WriteLine(customer);
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}